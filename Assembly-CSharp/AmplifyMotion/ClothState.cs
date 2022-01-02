using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace AmplifyMotion
{
	// Token: 0x0200057C RID: 1404
	internal class ClothState : MotionState
	{
		// Token: 0x060023A1 RID: 9121 RVA: 0x001F2ED8 File Offset: 0x001F10D8
		public ClothState(AmplifyMotionCamera owner, AmplifyMotionObjectBase obj) : base(owner, obj)
		{
			this.m_cloth = this.m_obj.GetComponent<Cloth>();
		}

		// Token: 0x060023A2 RID: 9122 RVA: 0x001F2EF3 File Offset: 0x001F10F3
		private void IssueError(string message)
		{
			if (!ClothState.m_uniqueWarnings.Contains(this.m_obj))
			{
				Debug.LogWarning(message);
				ClothState.m_uniqueWarnings.Add(this.m_obj);
			}
			this.m_error = true;
		}

		// Token: 0x060023A3 RID: 9123 RVA: 0x001F2F28 File Offset: 0x001F1128
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

		// Token: 0x060023A4 RID: 9124 RVA: 0x001F312F File Offset: 0x001F132F
		internal override void Shutdown()
		{
			UnityEngine.Object.Destroy(this.m_clonedMesh);
		}

		// Token: 0x060023A5 RID: 9125 RVA: 0x001F313C File Offset: 0x001F133C
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

		// Token: 0x060023A6 RID: 9126 RVA: 0x001F31FC File Offset: 0x001F13FC
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

		// Token: 0x04004B20 RID: 19232
		private Cloth m_cloth;

		// Token: 0x04004B21 RID: 19233
		private Renderer m_renderer;

		// Token: 0x04004B22 RID: 19234
		private MotionState.Matrix3x4 m_prevLocalToWorld;

		// Token: 0x04004B23 RID: 19235
		private MotionState.Matrix3x4 m_currLocalToWorld;

		// Token: 0x04004B24 RID: 19236
		private int m_targetVertexCount;

		// Token: 0x04004B25 RID: 19237
		private int[] m_targetRemap;

		// Token: 0x04004B26 RID: 19238
		private Vector3[] m_prevVertices;

		// Token: 0x04004B27 RID: 19239
		private Vector3[] m_currVertices;

		// Token: 0x04004B28 RID: 19240
		private Mesh m_clonedMesh;

		// Token: 0x04004B29 RID: 19241
		private MotionState.MaterialDesc[] m_sharedMaterials;

		// Token: 0x04004B2A RID: 19242
		private bool m_starting;

		// Token: 0x04004B2B RID: 19243
		private bool m_wasVisible;

		// Token: 0x04004B2C RID: 19244
		private static HashSet<AmplifyMotionObjectBase> m_uniqueWarnings = new HashSet<AmplifyMotionObjectBase>();
	}
}
