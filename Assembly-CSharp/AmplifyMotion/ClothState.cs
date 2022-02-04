using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace AmplifyMotion
{
	// Token: 0x0200057F RID: 1407
	internal class ClothState : MotionState
	{
		// Token: 0x060023B4 RID: 9140 RVA: 0x001F5100 File Offset: 0x001F3300
		public ClothState(AmplifyMotionCamera owner, AmplifyMotionObjectBase obj) : base(owner, obj)
		{
			this.m_cloth = this.m_obj.GetComponent<Cloth>();
		}

		// Token: 0x060023B5 RID: 9141 RVA: 0x001F511B File Offset: 0x001F331B
		private void IssueError(string message)
		{
			if (!ClothState.m_uniqueWarnings.Contains(this.m_obj))
			{
				Debug.LogWarning(message);
				ClothState.m_uniqueWarnings.Add(this.m_obj);
			}
			this.m_error = true;
		}

		// Token: 0x060023B6 RID: 9142 RVA: 0x001F5150 File Offset: 0x001F3350
		internal override void Initialize()
		{
			if (this.m_cloth.vertices == null)
			{
				this.IssueError(string.Concat(new string[]
				{
					"[AmplifyMotion] Invalid ",
					this.m_cloth.GetType().Name,
					" vertices in object ",
					this.m_obj.name,
					". Skipping."
				}));
				return;
			}
			Mesh sharedMesh = this.m_cloth.gameObject.GetComponent<SkinnedMeshRenderer>().sharedMesh;
			if (sharedMesh == null || sharedMesh.vertices == null || sharedMesh.triangles == null)
			{
				this.IssueError("[AmplifyMotion] Invalid Mesh on Cloth-enabled object " + this.m_obj.name);
				return;
			}
			base.Initialize();
			this.m_renderer = this.m_cloth.gameObject.GetComponent<Renderer>();
			int vertexCount = sharedMesh.vertexCount;
			Vector3[] vertices = sharedMesh.vertices;
			Vector2[] uv = sharedMesh.uv;
			int[] triangles = sharedMesh.triangles;
			this.m_targetRemap = new int[vertexCount];
			if (this.m_cloth.vertices.Length == sharedMesh.vertices.Length)
			{
				for (int i = 0; i < vertexCount; i++)
				{
					this.m_targetRemap[i] = i;
				}
			}
			else
			{
				Dictionary<Vector3, int> dictionary = new Dictionary<Vector3, int>();
				int num = 0;
				for (int j = 0; j < vertexCount; j++)
				{
					int num2;
					if (dictionary.TryGetValue(vertices[j], out num2))
					{
						this.m_targetRemap[j] = num2;
					}
					else
					{
						this.m_targetRemap[j] = num;
						dictionary.Add(vertices[j], num++);
					}
				}
			}
			this.m_targetVertexCount = vertexCount;
			this.m_prevVertices = new Vector3[this.m_targetVertexCount];
			this.m_currVertices = new Vector3[this.m_targetVertexCount];
			this.m_clonedMesh = new Mesh();
			this.m_clonedMesh.vertices = vertices;
			this.m_clonedMesh.normals = vertices;
			this.m_clonedMesh.uv = uv;
			this.m_clonedMesh.triangles = triangles;
			this.m_sharedMaterials = base.ProcessSharedMaterials(this.m_renderer.sharedMaterials);
			this.m_wasVisible = false;
		}

		// Token: 0x060023B7 RID: 9143 RVA: 0x001F5357 File Offset: 0x001F3557
		internal override void Shutdown()
		{
			UnityEngine.Object.Destroy(this.m_clonedMesh);
		}

		// Token: 0x060023B8 RID: 9144 RVA: 0x001F5364 File Offset: 0x001F3564
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
			bool isVisible = this.m_renderer.isVisible;
			if (!this.m_error && (isVisible || starting) && !starting && this.m_wasVisible)
			{
				Array.Copy(this.m_currVertices, this.m_prevVertices, this.m_targetVertexCount);
			}
			this.m_currLocalToWorld = Matrix4x4.TRS(this.m_transform.position, this.m_transform.rotation, Vector3.one);
			if (starting || !this.m_wasVisible)
			{
				this.m_prevLocalToWorld = this.m_currLocalToWorld;
			}
			this.m_starting = starting;
			this.m_wasVisible = isVisible;
		}

		// Token: 0x060023B9 RID: 9145 RVA: 0x001F5424 File Offset: 0x001F3624
		internal override void RenderVectors(Camera camera, CommandBuffer renderCB, float scale, Quality quality)
		{
			if (this.m_initialized && !this.m_error && this.m_renderer.isVisible)
			{
				bool flag = (this.m_owner.Instance.CullingMask & 1 << this.m_obj.gameObject.layer) != 0;
				int num = flag ? this.m_owner.Instance.GenerateObjectId(this.m_obj.gameObject) : 255;
				Vector3[] vertices = this.m_cloth.vertices;
				for (int i = 0; i < this.m_targetVertexCount; i++)
				{
					this.m_currVertices[i] = vertices[this.m_targetRemap[i]];
				}
				if (this.m_starting || !this.m_wasVisible)
				{
					Array.Copy(this.m_currVertices, this.m_prevVertices, this.m_targetVertexCount);
				}
				this.m_clonedMesh.vertices = this.m_currVertices;
				this.m_clonedMesh.normals = this.m_prevVertices;
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
				for (int j = 0; j < this.m_sharedMaterials.Length; j++)
				{
					MotionState.MaterialDesc materialDesc = this.m_sharedMaterials[j];
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
					renderCB.DrawMesh(this.m_clonedMesh, this.m_currLocalToWorld, this.m_owner.Instance.ClothVectorsMaterial, j, shaderPass, materialDesc.propertyBlock);
				}
			}
		}

		// Token: 0x04004B4C RID: 19276
		private Cloth m_cloth;

		// Token: 0x04004B4D RID: 19277
		private Renderer m_renderer;

		// Token: 0x04004B4E RID: 19278
		private MotionState.Matrix3x4 m_prevLocalToWorld;

		// Token: 0x04004B4F RID: 19279
		private MotionState.Matrix3x4 m_currLocalToWorld;

		// Token: 0x04004B50 RID: 19280
		private int m_targetVertexCount;

		// Token: 0x04004B51 RID: 19281
		private int[] m_targetRemap;

		// Token: 0x04004B52 RID: 19282
		private Vector3[] m_prevVertices;

		// Token: 0x04004B53 RID: 19283
		private Vector3[] m_currVertices;

		// Token: 0x04004B54 RID: 19284
		private Mesh m_clonedMesh;

		// Token: 0x04004B55 RID: 19285
		private MotionState.MaterialDesc[] m_sharedMaterials;

		// Token: 0x04004B56 RID: 19286
		private bool m_starting;

		// Token: 0x04004B57 RID: 19287
		private bool m_wasVisible;

		// Token: 0x04004B58 RID: 19288
		private static HashSet<AmplifyMotionObjectBase> m_uniqueWarnings = new HashSet<AmplifyMotionObjectBase>();
	}
}
