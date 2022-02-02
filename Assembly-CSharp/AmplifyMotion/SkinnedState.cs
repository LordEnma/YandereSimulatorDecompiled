using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering;

namespace AmplifyMotion
{
	// Token: 0x02000582 RID: 1410
	internal class SkinnedState : MotionState
	{
		// Token: 0x060023CA RID: 9162 RVA: 0x001F5E9F File Offset: 0x001F409F
		public SkinnedState(AmplifyMotionCamera owner, AmplifyMotionObjectBase obj) : base(owner, obj)
		{
			this.m_renderer = this.m_obj.GetComponent<SkinnedMeshRenderer>();
		}

		// Token: 0x060023CB RID: 9163 RVA: 0x001F5EBA File Offset: 0x001F40BA
		private void IssueWarning(string message)
		{
			if (!SkinnedState.m_uniqueWarnings.Contains(this.m_obj))
			{
				Debug.LogWarning(message);
				SkinnedState.m_uniqueWarnings.Add(this.m_obj);
			}
		}

		// Token: 0x060023CC RID: 9164 RVA: 0x001F5EE5 File Offset: 0x001F40E5
		private void IssueError(string message)
		{
			this.IssueWarning(message);
			this.m_error = true;
		}

		// Token: 0x060023CD RID: 9165 RVA: 0x001F5EF8 File Offset: 0x001F40F8
		internal override void Initialize()
		{
			if (!this.m_renderer.sharedMesh.isReadable)
			{
				this.IssueError("[AmplifyMotion] Read/Write Import Setting disabled in object " + this.m_obj.name + ". Skipping.");
				return;
			}
			Transform[] bones = this.m_renderer.bones;
			this.m_useFallback = (bones == null || bones.Length == 0);
			if (!this.m_useFallback)
			{
				this.m_useGPU = this.m_owner.Instance.CanUseGPU;
			}
			base.Initialize();
			this.m_vertexCount = this.m_renderer.sharedMesh.vertexCount;
			this.m_prevVertices = new Vector3[this.m_vertexCount];
			this.m_currVertices = new Vector3[this.m_vertexCount];
			this.m_clonedMesh = new Mesh();
			if (!this.m_useFallback)
			{
				if (this.m_renderer.quality == SkinQuality.Auto)
				{
					this.m_weightCount = (int)QualitySettings.skinWeights;
				}
				else
				{
					this.m_weightCount = (int)this.m_renderer.quality;
				}
				this.m_boneTransforms = this.m_renderer.bones;
				this.m_boneCount = this.m_renderer.bones.Length;
				this.m_bones = new MotionState.Matrix3x4[this.m_boneCount];
				Vector4[] baseVertices = new Vector4[this.m_vertexCount * this.m_weightCount];
				int[] boneIndices = new int[this.m_vertexCount * this.m_weightCount];
				float[] boneWeights = (this.m_weightCount > 1) ? new float[this.m_vertexCount * this.m_weightCount] : null;
				if (this.m_weightCount == 1)
				{
					this.InitializeBone1(baseVertices, boneIndices);
				}
				else if (this.m_weightCount == 2)
				{
					this.InitializeBone2(baseVertices, boneIndices, boneWeights);
				}
				else
				{
					this.InitializeBone4(baseVertices, boneIndices, boneWeights);
				}
				this.m_baseVertices = baseVertices;
				this.m_boneIndices = boneIndices;
				this.m_boneWeights = boneWeights;
				Mesh sharedMesh = this.m_renderer.sharedMesh;
				this.m_clonedMesh.vertices = sharedMesh.vertices;
				this.m_clonedMesh.normals = sharedMesh.vertices;
				this.m_clonedMesh.uv = sharedMesh.uv;
				this.m_clonedMesh.subMeshCount = sharedMesh.subMeshCount;
				for (int i = 0; i < sharedMesh.subMeshCount; i++)
				{
					this.m_clonedMesh.SetTriangles(sharedMesh.GetTriangles(i), i);
				}
				if (this.m_useGPU)
				{
					if (!this.InitializeGPUSkinDeform())
					{
						Debug.LogWarning("[AmplifyMotion] Failed initializing GPU skin deform for object " + this.m_obj.name + ". Falling back to CPU path.");
						this.m_useGPU = false;
					}
					else
					{
						this.m_boneIndices = null;
						this.m_boneWeights = null;
						this.m_baseVertices = null;
						this.m_prevVertices = null;
						this.m_currVertices = null;
					}
				}
				if (!this.m_useGPU)
				{
					this.m_asyncUpdateSignal = new ManualResetEvent(false);
					this.m_asyncUpdateTriggered = false;
				}
			}
			this.m_sharedMaterials = base.ProcessSharedMaterials(this.m_renderer.sharedMaterials);
			this.m_wasVisible = false;
		}

		// Token: 0x060023CE RID: 9166 RVA: 0x001F61C8 File Offset: 0x001F43C8
		internal override void Shutdown()
		{
			if (!this.m_useFallback && !this.m_useGPU)
			{
				this.WaitForAsyncUpdate();
			}
			if (this.m_useGPU)
			{
				this.ShutdownGPUSkinDeform();
			}
			if (this.m_clonedMesh != null)
			{
				UnityEngine.Object.Destroy(this.m_clonedMesh);
				this.m_clonedMesh = null;
			}
			this.m_boneTransforms = null;
			this.m_bones = null;
			this.m_boneIndices = null;
			this.m_boneWeights = null;
			this.m_baseVertices = null;
			this.m_prevVertices = null;
			this.m_currVertices = null;
			this.m_sharedMaterials = null;
		}

		// Token: 0x060023CF RID: 9167 RVA: 0x001F6254 File Offset: 0x001F4454
		private bool InitializeGPUSkinDeform()
		{
			bool result = true;
			try
			{
				this.m_gpuBoneTexWidth = this.m_boneCount;
				this.m_gpuBoneTexHeight = 3;
				this.m_gpuVertexTexWidth = Mathf.CeilToInt(Mathf.Sqrt((float)this.m_vertexCount));
				this.m_gpuVertexTexHeight = Mathf.CeilToInt((float)this.m_vertexCount / (float)this.m_gpuVertexTexWidth);
				this.m_gpuSkinDeformMat = new Material(Shader.Find("Hidden/Amplify Motion/GPUSkinDeform"))
				{
					hideFlags = HideFlags.DontSave
				};
				this.m_gpuBones = new Texture2D(this.m_gpuBoneTexWidth, this.m_gpuBoneTexHeight, TextureFormat.RGBAFloat, false, true);
				this.m_gpuBones.hideFlags = HideFlags.DontSave;
				this.m_gpuBones.name = "AM-" + this.m_obj.name + "-Bones";
				this.m_gpuBones.filterMode = FilterMode.Point;
				this.m_gpuBoneData = new Color[this.m_gpuBoneTexWidth * this.m_gpuBoneTexHeight];
				this.UpdateBonesGPU();
				TextureFormat textureFormat = TextureFormat.RHalf;
				textureFormat = ((this.m_weightCount == 2) ? TextureFormat.RGHalf : textureFormat);
				textureFormat = ((this.m_weightCount == 4) ? TextureFormat.RGBAHalf : textureFormat);
				this.m_gpuBoneIndices = new Texture2D(this.m_gpuVertexTexWidth, this.m_gpuVertexTexHeight, textureFormat, false, true);
				this.m_gpuBoneIndices.hideFlags = HideFlags.DontSave;
				this.m_gpuBoneIndices.name = "AM-" + this.m_obj.name + "-Bones";
				this.m_gpuBoneIndices.filterMode = FilterMode.Point;
				this.m_gpuBoneIndices.wrapMode = TextureWrapMode.Clamp;
				BoneWeight[] boneWeights = this.m_renderer.sharedMesh.boneWeights;
				Color[] array = new Color[this.m_gpuVertexTexWidth * this.m_gpuVertexTexHeight];
				for (int i = 0; i < this.m_vertexCount; i++)
				{
					int num = i % this.m_gpuVertexTexWidth;
					int num2 = i / this.m_gpuVertexTexWidth * this.m_gpuVertexTexWidth + num;
					BoneWeight boneWeight = boneWeights[i];
					array[num2] = new Vector4((float)boneWeight.boneIndex0, (float)boneWeight.boneIndex1, (float)boneWeight.boneIndex2, (float)boneWeight.boneIndex3);
				}
				this.m_gpuBoneIndices.SetPixels(array);
				this.m_gpuBoneIndices.Apply();
				this.m_gpuBaseVertices = new Texture2D[this.m_weightCount];
				for (int j = 0; j < this.m_weightCount; j++)
				{
					this.m_gpuBaseVertices[j] = new Texture2D(this.m_gpuVertexTexWidth, this.m_gpuVertexTexHeight, TextureFormat.RGBAFloat, false, true);
					this.m_gpuBaseVertices[j].hideFlags = HideFlags.DontSave;
					this.m_gpuBaseVertices[j].name = "AM-" + this.m_obj.name + "-BaseVerts";
					this.m_gpuBaseVertices[j].filterMode = FilterMode.Point;
				}
				List<Color[]> list = new List<Color[]>(this.m_weightCount);
				for (int k = 0; k < this.m_weightCount; k++)
				{
					list.Add(new Color[this.m_gpuVertexTexWidth * this.m_gpuVertexTexHeight]);
				}
				for (int l = 0; l < this.m_vertexCount; l++)
				{
					int num3 = l % this.m_gpuVertexTexWidth;
					int num4 = l / this.m_gpuVertexTexWidth * this.m_gpuVertexTexWidth + num3;
					for (int m = 0; m < this.m_weightCount; m++)
					{
						list[m][num4] = this.m_baseVertices[l * this.m_weightCount + m];
					}
				}
				for (int n = 0; n < this.m_weightCount; n++)
				{
					this.m_gpuBaseVertices[n].SetPixels(list[n]);
					this.m_gpuBaseVertices[n].Apply();
				}
				this.m_gpuPrevVertices = new RenderTexture(this.m_gpuVertexTexWidth, this.m_gpuVertexTexHeight, 0, RenderTextureFormat.ARGBFloat, RenderTextureReadWrite.Linear);
				this.m_gpuPrevVertices.hideFlags = HideFlags.DontSave;
				this.m_gpuPrevVertices.name = "AM-" + this.m_obj.name + "-PrevVerts";
				this.m_gpuPrevVertices.filterMode = FilterMode.Point;
				this.m_gpuPrevVertices.wrapMode = TextureWrapMode.Clamp;
				this.m_gpuPrevVertices.Create();
				this.m_gpuCurrVertices = new RenderTexture(this.m_gpuVertexTexWidth, this.m_gpuVertexTexHeight, 0, RenderTextureFormat.ARGBFloat, RenderTextureReadWrite.Linear);
				this.m_gpuCurrVertices.hideFlags = HideFlags.DontSave;
				this.m_gpuCurrVertices.name = "AM-" + this.m_obj.name + "-CurrVerts";
				this.m_gpuCurrVertices.filterMode = FilterMode.Point;
				this.m_gpuCurrVertices.wrapMode = TextureWrapMode.Clamp;
				this.m_gpuCurrVertices.Create();
				this.m_gpuSkinDeformMat.SetTexture("_AM_BONE_TEX", this.m_gpuBones);
				this.m_gpuSkinDeformMat.SetTexture("_AM_BONE_INDEX_TEX", this.m_gpuBoneIndices);
				for (int num5 = 0; num5 < this.m_weightCount; num5++)
				{
					this.m_gpuSkinDeformMat.SetTexture("_AM_BASE_VERTEX" + num5.ToString() + "_TEX", this.m_gpuBaseVertices[num5]);
				}
				Vector4 vector = new Vector4(1f / (float)this.m_gpuBoneTexWidth, 1f / (float)this.m_gpuBoneTexHeight, (float)this.m_gpuBoneTexWidth, (float)this.m_gpuBoneTexHeight);
				Vector4 vector2 = new Vector4(1f / (float)this.m_gpuVertexTexWidth, 1f / (float)this.m_gpuVertexTexHeight, (float)this.m_gpuVertexTexWidth, (float)this.m_gpuVertexTexHeight);
				this.m_gpuSkinDeformMat.SetVector("_AM_BONE_TEXEL_SIZE", vector);
				this.m_gpuSkinDeformMat.SetVector("_AM_BONE_TEXEL_HALFSIZE", vector * 0.5f);
				this.m_gpuSkinDeformMat.SetVector("_AM_VERTEX_TEXEL_SIZE", vector2);
				this.m_gpuSkinDeformMat.SetVector("_AM_VERTEX_TEXEL_HALFSIZE", vector2 * 0.5f);
				Vector2[] array2 = new Vector2[this.m_vertexCount];
				for (int num6 = 0; num6 < this.m_vertexCount; num6++)
				{
					float num7 = (float)(num6 % this.m_gpuVertexTexWidth);
					int num8 = num6 / this.m_gpuVertexTexWidth;
					float x = num7 / (float)this.m_gpuVertexTexWidth + vector2.x * 0.5f;
					float y = (float)num8 / (float)this.m_gpuVertexTexHeight + vector2.y * 0.5f;
					array2[num6] = new Vector2(x, y);
				}
				this.m_clonedMesh.uv2 = array2;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060023D0 RID: 9168 RVA: 0x001F6898 File Offset: 0x001F4A98
		private void ShutdownGPUSkinDeform()
		{
			if (this.m_gpuSkinDeformMat != null)
			{
				UnityEngine.Object.DestroyImmediate(this.m_gpuSkinDeformMat);
				this.m_gpuSkinDeformMat = null;
			}
			this.m_gpuBoneData = null;
			if (this.m_gpuBones != null)
			{
				UnityEngine.Object.DestroyImmediate(this.m_gpuBones);
				this.m_gpuBones = null;
			}
			if (this.m_gpuBoneIndices != null)
			{
				UnityEngine.Object.DestroyImmediate(this.m_gpuBoneIndices);
				this.m_gpuBoneIndices = null;
			}
			if (this.m_gpuBaseVertices != null)
			{
				for (int i = 0; i < this.m_gpuBaseVertices.Length; i++)
				{
					UnityEngine.Object.DestroyImmediate(this.m_gpuBaseVertices[i]);
				}
				this.m_gpuBaseVertices = null;
			}
			if (this.m_gpuPrevVertices != null)
			{
				RenderTexture.active = null;
				this.m_gpuPrevVertices.Release();
				UnityEngine.Object.DestroyImmediate(this.m_gpuPrevVertices);
				this.m_gpuPrevVertices = null;
			}
			if (this.m_gpuCurrVertices != null)
			{
				RenderTexture.active = null;
				this.m_gpuCurrVertices.Release();
				UnityEngine.Object.DestroyImmediate(this.m_gpuCurrVertices);
				this.m_gpuCurrVertices = null;
			}
		}

		// Token: 0x060023D1 RID: 9169 RVA: 0x001F69A0 File Offset: 0x001F4BA0
		private void UpdateBonesGPU()
		{
			for (int i = 0; i < this.m_boneCount; i++)
			{
				for (int j = 0; j < this.m_gpuBoneTexHeight; j++)
				{
					this.m_gpuBoneData[j * this.m_gpuBoneTexWidth + i] = this.m_bones[i].GetRow(j);
				}
			}
			this.m_gpuBones.SetPixels(this.m_gpuBoneData);
			this.m_gpuBones.Apply();
		}

		// Token: 0x060023D2 RID: 9170 RVA: 0x001F6A18 File Offset: 0x001F4C18
		private void UpdateVerticesGPU(CommandBuffer updateCB, bool starting)
		{
			if (!starting && this.m_wasVisible)
			{
				this.m_gpuPrevVertices.DiscardContents();
				updateCB.Blit(new RenderTargetIdentifier(this.m_gpuCurrVertices), this.m_gpuPrevVertices);
			}
			updateCB.SetGlobalMatrix("_AM_WORLD_TO_LOCAL_MATRIX", this.m_worldToLocalMatrix);
			this.m_gpuCurrVertices.DiscardContents();
			RenderTexture tex = null;
			updateCB.Blit(new RenderTargetIdentifier(tex), this.m_gpuCurrVertices, this.m_gpuSkinDeformMat, Mathf.Min(this.m_weightCount - 1, 2));
			if (starting || !this.m_wasVisible)
			{
				this.m_gpuPrevVertices.DiscardContents();
				updateCB.Blit(new RenderTargetIdentifier(this.m_gpuCurrVertices), this.m_gpuPrevVertices);
			}
		}

		// Token: 0x060023D3 RID: 9171 RVA: 0x001F6AD8 File Offset: 0x001F4CD8
		private void UpdateBones()
		{
			for (int i = 0; i < this.m_boneCount; i++)
			{
				this.m_bones[i] = ((this.m_boneTransforms[i] != null) ? this.m_boneTransforms[i].localToWorldMatrix : Matrix4x4.identity);
			}
			this.m_worldToLocalMatrix = this.m_transform.worldToLocalMatrix;
			if (this.m_useGPU)
			{
				this.UpdateBonesGPU();
			}
		}

		// Token: 0x060023D4 RID: 9172 RVA: 0x001F6B50 File Offset: 0x001F4D50
		private void UpdateVerticesFallback(bool starting)
		{
			if (!starting && this.m_wasVisible)
			{
				Array.Copy(this.m_currVertices, this.m_prevVertices, this.m_vertexCount);
			}
			this.m_renderer.BakeMesh(this.m_clonedMesh);
			if (this.m_clonedMesh.vertexCount == 0 || this.m_clonedMesh.vertexCount != this.m_prevVertices.Length)
			{
				this.IssueError("[AmplifyMotion] Invalid mesh obtained from SkinnedMeshRenderer.BakeMesh in object " + this.m_obj.name + ". Skipping.");
				return;
			}
			Array.Copy(this.m_clonedMesh.vertices, this.m_currVertices, this.m_vertexCount);
			if (starting || !this.m_wasVisible)
			{
				Array.Copy(this.m_currVertices, this.m_prevVertices, this.m_vertexCount);
			}
		}

		// Token: 0x060023D5 RID: 9173 RVA: 0x001F6C14 File Offset: 0x001F4E14
		private void AsyncUpdateVertices(bool starting)
		{
			if (!starting && this.m_wasVisible)
			{
				Array.Copy(this.m_currVertices, this.m_prevVertices, this.m_vertexCount);
			}
			for (int i = 0; i < this.m_boneCount; i++)
			{
				this.m_bones[i] = this.m_worldToLocalMatrix * this.m_bones[i];
			}
			if (this.m_weightCount == 1)
			{
				this.UpdateVerticesBone1();
			}
			else if (this.m_weightCount == 2)
			{
				this.UpdateVerticesBone2();
			}
			else
			{
				this.UpdateVerticesBone4();
			}
			if (starting || !this.m_wasVisible)
			{
				Array.Copy(this.m_currVertices, this.m_prevVertices, this.m_vertexCount);
			}
		}

		// Token: 0x060023D6 RID: 9174 RVA: 0x001F6CC4 File Offset: 0x001F4EC4
		private void InitializeBone1(Vector4[] baseVertices, int[] boneIndices)
		{
			Vector3[] vertices = this.m_renderer.sharedMesh.vertices;
			Matrix4x4[] bindposes = this.m_renderer.sharedMesh.bindposes;
			BoneWeight[] boneWeights = this.m_renderer.sharedMesh.boneWeights;
			for (int i = 0; i < this.m_vertexCount; i++)
			{
				int num = i * this.m_weightCount;
				int num2 = boneIndices[num] = boneWeights[i].boneIndex0;
				Vector3 vector = bindposes[num2].MultiplyPoint3x4(vertices[i]);
				baseVertices[num] = new Vector4(vector.x, vector.y, vector.z, 1f);
			}
		}

		// Token: 0x060023D7 RID: 9175 RVA: 0x001F6D74 File Offset: 0x001F4F74
		private void InitializeBone2(Vector4[] baseVertices, int[] boneIndices, float[] boneWeights)
		{
			Vector3[] vertices = this.m_renderer.sharedMesh.vertices;
			Matrix4x4[] bindposes = this.m_renderer.sharedMesh.bindposes;
			BoneWeight[] boneWeights2 = this.m_renderer.sharedMesh.boneWeights;
			for (int i = 0; i < this.m_vertexCount; i++)
			{
				int num = i * this.m_weightCount;
				int num2 = num + 1;
				BoneWeight boneWeight = boneWeights2[i];
				int num3 = boneIndices[num] = boneWeight.boneIndex0;
				int num4 = boneIndices[num2] = boneWeight.boneIndex1;
				float num5 = boneWeight.weight0;
				float num6 = boneWeight.weight1;
				float num7 = 1f / (num5 + num6);
				num5 = (boneWeights[num] = num5 * num7);
				num6 = (boneWeights[num2] = num6 * num7);
				Vector3 vector = num5 * bindposes[num3].MultiplyPoint3x4(vertices[i]);
				Vector3 vector2 = num6 * bindposes[num4].MultiplyPoint3x4(vertices[i]);
				baseVertices[num] = new Vector4(vector.x, vector.y, vector.z, num5);
				baseVertices[num2] = new Vector4(vector2.x, vector2.y, vector2.z, num6);
			}
		}

		// Token: 0x060023D8 RID: 9176 RVA: 0x001F6EC4 File Offset: 0x001F50C4
		private void InitializeBone4(Vector4[] baseVertices, int[] boneIndices, float[] boneWeights)
		{
			Vector3[] vertices = this.m_renderer.sharedMesh.vertices;
			Matrix4x4[] bindposes = this.m_renderer.sharedMesh.bindposes;
			BoneWeight[] boneWeights2 = this.m_renderer.sharedMesh.boneWeights;
			for (int i = 0; i < this.m_vertexCount; i++)
			{
				int num = i * this.m_weightCount;
				int num2 = num + 1;
				int num3 = num + 2;
				int num4 = num + 3;
				BoneWeight boneWeight = boneWeights2[i];
				int num5 = boneIndices[num] = boneWeight.boneIndex0;
				int num6 = boneIndices[num2] = boneWeight.boneIndex1;
				int num7 = boneIndices[num3] = boneWeight.boneIndex2;
				int num8 = boneIndices[num4] = boneWeight.boneIndex3;
				float num9 = boneWeights[num] = boneWeight.weight0;
				float num10 = boneWeights[num2] = boneWeight.weight1;
				float num11 = boneWeights[num3] = boneWeight.weight2;
				float num12 = boneWeights[num4] = boneWeight.weight3;
				Vector3 vector = num9 * bindposes[num5].MultiplyPoint3x4(vertices[i]);
				Vector3 vector2 = num10 * bindposes[num6].MultiplyPoint3x4(vertices[i]);
				Vector3 vector3 = num11 * bindposes[num7].MultiplyPoint3x4(vertices[i]);
				Vector3 vector4 = num12 * bindposes[num8].MultiplyPoint3x4(vertices[i]);
				baseVertices[num] = new Vector4(vector.x, vector.y, vector.z, num9);
				baseVertices[num2] = new Vector4(vector2.x, vector2.y, vector2.z, num10);
				baseVertices[num3] = new Vector4(vector3.x, vector3.y, vector3.z, num11);
				baseVertices[num4] = new Vector4(vector4.x, vector4.y, vector4.z, num12);
			}
		}

		// Token: 0x060023D9 RID: 9177 RVA: 0x001F70D4 File Offset: 0x001F52D4
		private void UpdateVerticesBone1()
		{
			for (int i = 0; i < this.m_vertexCount; i++)
			{
				MotionState.MulPoint3x4_XYZ(ref this.m_currVertices[i], ref this.m_bones[this.m_boneIndices[i]], this.m_baseVertices[i]);
			}
		}

		// Token: 0x060023DA RID: 9178 RVA: 0x001F7124 File Offset: 0x001F5324
		private void UpdateVerticesBone2()
		{
			Vector3 zero = Vector3.zero;
			for (int i = 0; i < this.m_vertexCount; i++)
			{
				int num = i * 2;
				int num2 = num + 1;
				int num3 = this.m_boneIndices[num];
				int num4 = this.m_boneIndices[num2];
				float num5 = this.m_boneWeights[num2];
				MotionState.MulPoint3x4_XYZW(ref zero, ref this.m_bones[num3], this.m_baseVertices[num]);
				if (num5 != 0f)
				{
					MotionState.MulAddPoint3x4_XYZW(ref zero, ref this.m_bones[num4], this.m_baseVertices[num2]);
				}
				this.m_currVertices[i] = zero;
			}
		}

		// Token: 0x060023DB RID: 9179 RVA: 0x001F71C4 File Offset: 0x001F53C4
		private void UpdateVerticesBone4()
		{
			Vector3 zero = Vector3.zero;
			for (int i = 0; i < this.m_vertexCount; i++)
			{
				int num = i * 4;
				int num2 = num + 1;
				int num3 = num + 2;
				int num4 = num + 3;
				int num5 = this.m_boneIndices[num];
				int num6 = this.m_boneIndices[num2];
				int num7 = this.m_boneIndices[num3];
				int num8 = this.m_boneIndices[num4];
				float num9 = this.m_boneWeights[num2];
				float num10 = this.m_boneWeights[num3];
				float num11 = this.m_boneWeights[num4];
				MotionState.MulPoint3x4_XYZW(ref zero, ref this.m_bones[num5], this.m_baseVertices[num]);
				if (num9 != 0f)
				{
					MotionState.MulAddPoint3x4_XYZW(ref zero, ref this.m_bones[num6], this.m_baseVertices[num2]);
				}
				if (num10 != 0f)
				{
					MotionState.MulAddPoint3x4_XYZW(ref zero, ref this.m_bones[num7], this.m_baseVertices[num3]);
				}
				if (num11 != 0f)
				{
					MotionState.MulAddPoint3x4_XYZW(ref zero, ref this.m_bones[num8], this.m_baseVertices[num4]);
				}
				this.m_currVertices[i] = zero;
			}
		}

		// Token: 0x060023DC RID: 9180 RVA: 0x001F72F0 File Offset: 0x001F54F0
		internal override void AsyncUpdate()
		{
			try
			{
				this.AsyncUpdateVertices(this.m_starting);
			}
			catch (Exception ex)
			{
				this.IssueError("[AmplifyMotion] Failed on SkinnedMeshRenderer data. Please contact support.\n" + ex.Message);
			}
			finally
			{
				this.m_asyncUpdateSignal.Set();
			}
		}

		// Token: 0x060023DD RID: 9181 RVA: 0x001F7350 File Offset: 0x001F5550
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
			if (!this.m_error && (isVisible || starting))
			{
				this.UpdateBones();
				this.m_starting = (!this.m_wasVisible || starting);
				if (!this.m_useFallback)
				{
					if (!this.m_useGPU)
					{
						this.m_asyncUpdateSignal.Reset();
						this.m_asyncUpdateTriggered = true;
						this.m_owner.Instance.WorkerPool.EnqueueAsyncUpdate(this);
					}
					else
					{
						this.UpdateVerticesGPU(updateCB, this.m_starting);
					}
				}
				else
				{
					this.UpdateVerticesFallback(this.m_starting);
				}
			}
			if (!this.m_useFallback)
			{
				this.m_currLocalToWorld = this.m_transform.localToWorldMatrix;
			}
			else
			{
				this.m_currLocalToWorld = Matrix4x4.TRS(this.m_transform.position, this.m_transform.rotation, Vector3.one);
			}
			if (starting || !this.m_wasVisible)
			{
				this.m_prevLocalToWorld = this.m_currLocalToWorld;
			}
			this.m_wasVisible = isVisible;
		}

		// Token: 0x060023DE RID: 9182 RVA: 0x001F7472 File Offset: 0x001F5672
		private void WaitForAsyncUpdate()
		{
			if (this.m_asyncUpdateTriggered)
			{
				if (!this.m_asyncUpdateSignal.WaitOne(100))
				{
					Debug.LogWarning("[AmplifyMotion] Aborted abnormally long Async Skin deform operation. Not a critical error but might indicate a problem. Please contact support.");
					return;
				}
				this.m_asyncUpdateTriggered = false;
			}
		}

		// Token: 0x060023DF RID: 9183 RVA: 0x001F74A0 File Offset: 0x001F56A0
		internal override void RenderVectors(Camera camera, CommandBuffer renderCB, float scale, Quality quality)
		{
			if (this.m_initialized && !this.m_error && this.m_renderer.isVisible)
			{
				if (!this.m_useFallback && !this.m_useGPU)
				{
					this.WaitForAsyncUpdate();
				}
				if (!this.m_useGPU)
				{
					if (!this.m_useFallback)
					{
						this.m_clonedMesh.vertices = this.m_currVertices;
					}
					this.m_clonedMesh.normals = this.m_prevVertices;
				}
				bool flag = (this.m_owner.Instance.CullingMask & 1 << this.m_obj.gameObject.layer) != 0;
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
				if (this.m_useGPU)
				{
					Vector4 vector = new Vector4(1f / (float)this.m_gpuVertexTexWidth, 1f / (float)this.m_gpuVertexTexHeight, (float)this.m_gpuVertexTexWidth, (float)this.m_gpuVertexTexHeight);
					renderCB.SetGlobalVector("_AM_VERTEX_TEXEL_SIZE", vector);
					renderCB.SetGlobalVector("_AM_VERTEX_TEXEL_HALFSIZE", vector * 0.5f);
					renderCB.SetGlobalTexture("_AM_PREV_VERTEX_TEX", this.m_gpuPrevVertices);
					renderCB.SetGlobalTexture("_AM_CURR_VERTEX_TEX", this.m_gpuCurrVertices);
				}
				int num2 = this.m_useGPU ? 4 : 0;
				int num3 = (quality == Quality.Mobile) ? 0 : 2;
				int num4 = num2 + num3;
				for (int i = 0; i < this.m_sharedMaterials.Length; i++)
				{
					MotionState.MaterialDesc materialDesc = this.m_sharedMaterials[i];
					int shaderPass = num4 + (materialDesc.coverage ? 1 : 0);
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
					renderCB.DrawMesh(this.m_clonedMesh, this.m_currLocalToWorld, this.m_owner.Instance.SkinnedVectorsMaterial, i, shaderPass, materialDesc.propertyBlock);
				}
			}
		}

		// Token: 0x04004B69 RID: 19305
		private SkinnedMeshRenderer m_renderer;

		// Token: 0x04004B6A RID: 19306
		private int m_boneCount;

		// Token: 0x04004B6B RID: 19307
		private Transform[] m_boneTransforms;

		// Token: 0x04004B6C RID: 19308
		private MotionState.Matrix3x4[] m_bones;

		// Token: 0x04004B6D RID: 19309
		private int m_weightCount;

		// Token: 0x04004B6E RID: 19310
		private int[] m_boneIndices;

		// Token: 0x04004B6F RID: 19311
		private float[] m_boneWeights;

		// Token: 0x04004B70 RID: 19312
		private int m_vertexCount;

		// Token: 0x04004B71 RID: 19313
		private Vector4[] m_baseVertices;

		// Token: 0x04004B72 RID: 19314
		private Vector3[] m_prevVertices;

		// Token: 0x04004B73 RID: 19315
		private Vector3[] m_currVertices;

		// Token: 0x04004B74 RID: 19316
		private int m_gpuBoneTexWidth;

		// Token: 0x04004B75 RID: 19317
		private int m_gpuBoneTexHeight;

		// Token: 0x04004B76 RID: 19318
		private int m_gpuVertexTexWidth;

		// Token: 0x04004B77 RID: 19319
		private int m_gpuVertexTexHeight;

		// Token: 0x04004B78 RID: 19320
		private Material m_gpuSkinDeformMat;

		// Token: 0x04004B79 RID: 19321
		private Color[] m_gpuBoneData;

		// Token: 0x04004B7A RID: 19322
		private Texture2D m_gpuBones;

		// Token: 0x04004B7B RID: 19323
		private Texture2D m_gpuBoneIndices;

		// Token: 0x04004B7C RID: 19324
		private Texture2D[] m_gpuBaseVertices;

		// Token: 0x04004B7D RID: 19325
		private RenderTexture m_gpuPrevVertices;

		// Token: 0x04004B7E RID: 19326
		private RenderTexture m_gpuCurrVertices;

		// Token: 0x04004B7F RID: 19327
		private Mesh m_clonedMesh;

		// Token: 0x04004B80 RID: 19328
		private MotionState.Matrix3x4 m_worldToLocalMatrix;

		// Token: 0x04004B81 RID: 19329
		private MotionState.Matrix3x4 m_prevLocalToWorld;

		// Token: 0x04004B82 RID: 19330
		private MotionState.Matrix3x4 m_currLocalToWorld;

		// Token: 0x04004B83 RID: 19331
		private MotionState.MaterialDesc[] m_sharedMaterials;

		// Token: 0x04004B84 RID: 19332
		private ManualResetEvent m_asyncUpdateSignal;

		// Token: 0x04004B85 RID: 19333
		private bool m_asyncUpdateTriggered;

		// Token: 0x04004B86 RID: 19334
		private bool m_starting;

		// Token: 0x04004B87 RID: 19335
		private bool m_wasVisible;

		// Token: 0x04004B88 RID: 19336
		private bool m_useFallback;

		// Token: 0x04004B89 RID: 19337
		private bool m_useGPU;

		// Token: 0x04004B8A RID: 19338
		private static HashSet<AmplifyMotionObjectBase> m_uniqueWarnings = new HashSet<AmplifyMotionObjectBase>();
	}
}
