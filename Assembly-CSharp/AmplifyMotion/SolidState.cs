using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace AmplifyMotion
{
	// Token: 0x02000583 RID: 1411
	internal class SolidState : MotionState
	{
		// Token: 0x060023DD RID: 9181 RVA: 0x001F6EC7 File Offset: 0x001F50C7
		public SolidState(AmplifyMotionCamera owner, AmplifyMotionObjectBase obj) : base(owner, obj)
		{
			this.m_meshRenderer = this.m_obj.GetComponent<MeshRenderer>();
		}

		// Token: 0x060023DE RID: 9182 RVA: 0x001F6EE2 File Offset: 0x001F50E2
		private void IssueError(string message)
		{
			if (!SolidState.m_uniqueWarnings.Contains(this.m_obj))
			{
				Debug.LogWarning(message);
				SolidState.m_uniqueWarnings.Add(this.m_obj);
			}
			this.m_error = true;
		}

		// Token: 0x060023DF RID: 9183 RVA: 0x001F6F14 File Offset: 0x001F5114
		internal override void Initialize()
		{
			MeshFilter component = this.m_obj.GetComponent<MeshFilter>();
			if (component == null || component.sharedMesh == null)
			{
				this.IssueError("[AmplifyMotion] Invalid MeshFilter/Mesh in object " + this.m_obj.name + ". Skipping.");
				return;
			}
			base.Initialize();
			this.m_mesh = component.sharedMesh;
			this.m_sharedMaterials = base.ProcessSharedMaterials(this.m_meshRenderer.sharedMaterials);
			this.m_wasVisible = false;
		}

		// Token: 0x060023E0 RID: 9184 RVA: 0x001F6F98 File Offset: 0x001F5198
		internal override void UpdateTransform(CommandBuffer updateCB, bool starting)
		{
			if (!this.m_initialized)
			{
				this.Initialize();
				return;
			}
			if (!starting && this.m_wasVisible)
			{
				this.m_prevLocalToWorld = this.m_currLocalToWorld;
			}
			this.m_currLocalToWorld = this.m_transform.localToWorldMatrix;
			this.m_moved = true;
			if (!this.m_owner.Overlay)
			{
				this.m_moved = (starting || MotionState.MatrixChanged(this.m_currLocalToWorld, this.m_prevLocalToWorld));
			}
			if (starting || !this.m_wasVisible)
			{
				this.m_prevLocalToWorld = this.m_currLocalToWorld;
			}
			this.m_wasVisible = this.m_meshRenderer.isVisible;
		}

		// Token: 0x060023E1 RID: 9185 RVA: 0x001F703C File Offset: 0x001F523C
		internal override void RenderVectors(Camera camera, CommandBuffer renderCB, float scale, Quality quality)
		{
			if (this.m_initialized && !this.m_error && this.m_meshRenderer.isVisible)
			{
				bool flag = (this.m_owner.Instance.CullingMask & 1 << this.m_obj.gameObject.layer) != 0;
				if (!flag || (flag && this.m_moved))
				{
					int num = flag ? this.m_owner.Instance.GenerateObjectId(this.m_obj.gameObject) : 255;
					Matrix4x4 value;
					if (this.m_obj.FixedStep)
					{
						value = this.m_owner.PrevViewProjMatrixRT * this.m_currLocalToWorld;
					}
					else
					{
						value = this.m_owner.PrevViewProjMatrixRT * this.m_prevLocalToWorld;
					}
					renderCB.SetGlobalMatrix("_AM_MATRIX_PREV_MVP", value);
					renderCB.SetGlobalFloat("_AM_OBJECT_ID", (float)num * 0.003921569f);
					renderCB.SetGlobalFloat("_AM_MOTION_SCALE", flag ? scale : 0f);
					int num2 = (quality == Quality.Mobile) ? 0 : 2;
					for (int i = 0; i < this.m_sharedMaterials.Length; i++)
					{
						MotionState.MaterialDesc materialDesc = this.m_sharedMaterials[i];
						int shaderPass = num2 + (materialDesc.coverage ? 1 : 0);
						if (materialDesc.coverage)
						{
							Texture mainTexture = materialDesc.material.mainTexture;
							if (mainTexture != null)
							{
								materialDesc.propertyBlock.SetTexture("_MainTex", mainTexture);
							}
							if (materialDesc.cutoff)
							{
								materialDesc.propertyBlock.SetFloat("_Cutoff", materialDesc.material.GetFloat("_Cutoff"));
							}
						}
						renderCB.DrawMesh(this.m_mesh, this.m_transform.localToWorldMatrix, this.m_owner.Instance.SolidVectorsMaterial, i, shaderPass, materialDesc.propertyBlock);
					}
				}
			}
		}

		// Token: 0x04004B80 RID: 19328
		private MeshRenderer m_meshRenderer;

		// Token: 0x04004B81 RID: 19329
		private MotionState.Matrix3x4 m_prevLocalToWorld;

		// Token: 0x04004B82 RID: 19330
		private MotionState.Matrix3x4 m_currLocalToWorld;

		// Token: 0x04004B83 RID: 19331
		private Mesh m_mesh;

		// Token: 0x04004B84 RID: 19332
		private MotionState.MaterialDesc[] m_sharedMaterials;

		// Token: 0x04004B85 RID: 19333
		public bool m_moved;

		// Token: 0x04004B86 RID: 19334
		private bool m_wasVisible;

		// Token: 0x04004B87 RID: 19335
		private static HashSet<AmplifyMotionObjectBase> m_uniqueWarnings = new HashSet<AmplifyMotionObjectBase>();
	}
}
