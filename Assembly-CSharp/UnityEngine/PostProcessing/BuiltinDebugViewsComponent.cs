using System;
using System.Collections.Generic;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200055F RID: 1375
	public sealed class BuiltinDebugViewsComponent : PostProcessingComponentCommandBuffer<BuiltinDebugViewsModel>
	{
		// Token: 0x170004F0 RID: 1264
		// (get) Token: 0x060022ED RID: 8941 RVA: 0x001F51E4 File Offset: 0x001F33E4
		public override bool active
		{
			get
			{
				return base.model.IsModeActive(BuiltinDebugViewsModel.Mode.Depth) || base.model.IsModeActive(BuiltinDebugViewsModel.Mode.Normals) || base.model.IsModeActive(BuiltinDebugViewsModel.Mode.MotionVectors);
			}
		}

		// Token: 0x060022EE RID: 8942 RVA: 0x001F5210 File Offset: 0x001F3410
		public override DepthTextureMode GetCameraFlags()
		{
			BuiltinDebugViewsModel.Mode mode = base.model.settings.mode;
			DepthTextureMode depthTextureMode = DepthTextureMode.None;
			switch (mode)
			{
			case BuiltinDebugViewsModel.Mode.Depth:
				depthTextureMode |= DepthTextureMode.Depth;
				break;
			case BuiltinDebugViewsModel.Mode.Normals:
				depthTextureMode |= DepthTextureMode.DepthNormals;
				break;
			case BuiltinDebugViewsModel.Mode.MotionVectors:
				depthTextureMode |= (DepthTextureMode.Depth | DepthTextureMode.MotionVectors);
				break;
			}
			return depthTextureMode;
		}

		// Token: 0x060022EF RID: 8943 RVA: 0x001F5257 File Offset: 0x001F3457
		public override CameraEvent GetCameraEvent()
		{
			if (base.model.settings.mode != BuiltinDebugViewsModel.Mode.MotionVectors)
			{
				return CameraEvent.BeforeImageEffectsOpaque;
			}
			return CameraEvent.BeforeImageEffects;
		}

		// Token: 0x060022F0 RID: 8944 RVA: 0x001F5271 File Offset: 0x001F3471
		public override string GetName()
		{
			return "Builtin Debug Views";
		}

		// Token: 0x060022F1 RID: 8945 RVA: 0x001F5278 File Offset: 0x001F3478
		public override void PopulateCommandBuffer(CommandBuffer cb)
		{
			ref BuiltinDebugViewsModel.Settings settings = base.model.settings;
			Material material = this.context.materialFactory.Get("Hidden/Post FX/Builtin Debug Views");
			material.shaderKeywords = null;
			if (this.context.isGBufferAvailable)
			{
				material.EnableKeyword("SOURCE_GBUFFER");
			}
			switch (settings.mode)
			{
			case BuiltinDebugViewsModel.Mode.Depth:
				this.DepthPass(cb);
				break;
			case BuiltinDebugViewsModel.Mode.Normals:
				this.DepthNormalsPass(cb);
				break;
			case BuiltinDebugViewsModel.Mode.MotionVectors:
				this.MotionVectorsPass(cb);
				break;
			}
			this.context.Interrupt();
		}

		// Token: 0x060022F2 RID: 8946 RVA: 0x001F5308 File Offset: 0x001F3508
		private void DepthPass(CommandBuffer cb)
		{
			Material mat = this.context.materialFactory.Get("Hidden/Post FX/Builtin Debug Views");
			BuiltinDebugViewsModel.DepthSettings depth = base.model.settings.depth;
			cb.SetGlobalFloat(BuiltinDebugViewsComponent.Uniforms._DepthScale, 1f / depth.scale);
			cb.Blit(null, BuiltinRenderTextureType.CameraTarget, mat, 0);
		}

		// Token: 0x060022F3 RID: 8947 RVA: 0x001F5364 File Offset: 0x001F3564
		private void DepthNormalsPass(CommandBuffer cb)
		{
			Material mat = this.context.materialFactory.Get("Hidden/Post FX/Builtin Debug Views");
			cb.Blit(null, BuiltinRenderTextureType.CameraTarget, mat, 1);
		}

		// Token: 0x060022F4 RID: 8948 RVA: 0x001F5398 File Offset: 0x001F3598
		private void MotionVectorsPass(CommandBuffer cb)
		{
			Material material = this.context.materialFactory.Get("Hidden/Post FX/Builtin Debug Views");
			BuiltinDebugViewsModel.MotionVectorsSettings motionVectors = base.model.settings.motionVectors;
			int nameID = BuiltinDebugViewsComponent.Uniforms._TempRT;
			cb.GetTemporaryRT(nameID, this.context.width, this.context.height, 0, FilterMode.Bilinear);
			cb.SetGlobalFloat(BuiltinDebugViewsComponent.Uniforms._Opacity, motionVectors.sourceOpacity);
			cb.SetGlobalTexture(BuiltinDebugViewsComponent.Uniforms._MainTex, BuiltinRenderTextureType.CameraTarget);
			cb.Blit(BuiltinRenderTextureType.CameraTarget, nameID, material, 2);
			if (motionVectors.motionImageOpacity > 0f && motionVectors.motionImageAmplitude > 0f)
			{
				int tempRT = BuiltinDebugViewsComponent.Uniforms._TempRT2;
				cb.GetTemporaryRT(tempRT, this.context.width, this.context.height, 0, FilterMode.Bilinear);
				cb.SetGlobalFloat(BuiltinDebugViewsComponent.Uniforms._Opacity, motionVectors.motionImageOpacity);
				cb.SetGlobalFloat(BuiltinDebugViewsComponent.Uniforms._Amplitude, motionVectors.motionImageAmplitude);
				cb.SetGlobalTexture(BuiltinDebugViewsComponent.Uniforms._MainTex, nameID);
				cb.Blit(nameID, tempRT, material, 3);
				cb.ReleaseTemporaryRT(nameID);
				nameID = tempRT;
			}
			if (motionVectors.motionVectorsOpacity > 0f && motionVectors.motionVectorsAmplitude > 0f)
			{
				this.PrepareArrows();
				float num = 1f / (float)motionVectors.motionVectorsResolution;
				float x = num * (float)this.context.height / (float)this.context.width;
				cb.SetGlobalVector(BuiltinDebugViewsComponent.Uniforms._Scale, new Vector2(x, num));
				cb.SetGlobalFloat(BuiltinDebugViewsComponent.Uniforms._Opacity, motionVectors.motionVectorsOpacity);
				cb.SetGlobalFloat(BuiltinDebugViewsComponent.Uniforms._Amplitude, motionVectors.motionVectorsAmplitude);
				cb.DrawMesh(this.m_Arrows.mesh, Matrix4x4.identity, material, 0, 4);
			}
			cb.SetGlobalTexture(BuiltinDebugViewsComponent.Uniforms._MainTex, nameID);
			cb.Blit(nameID, BuiltinRenderTextureType.CameraTarget);
			cb.ReleaseTemporaryRT(nameID);
		}

		// Token: 0x060022F5 RID: 8949 RVA: 0x001F558C File Offset: 0x001F378C
		private void PrepareArrows()
		{
			int motionVectorsResolution = base.model.settings.motionVectors.motionVectorsResolution;
			int num = motionVectorsResolution * Screen.width / Screen.height;
			if (this.m_Arrows == null)
			{
				this.m_Arrows = new BuiltinDebugViewsComponent.ArrowArray();
			}
			if (this.m_Arrows.columnCount != num || this.m_Arrows.rowCount != motionVectorsResolution)
			{
				this.m_Arrows.Release();
				this.m_Arrows.BuildMesh(num, motionVectorsResolution);
			}
		}

		// Token: 0x060022F6 RID: 8950 RVA: 0x001F5604 File Offset: 0x001F3804
		public override void OnDisable()
		{
			if (this.m_Arrows != null)
			{
				this.m_Arrows.Release();
			}
			this.m_Arrows = null;
		}

		// Token: 0x04004B8C RID: 19340
		private const string k_ShaderString = "Hidden/Post FX/Builtin Debug Views";

		// Token: 0x04004B8D RID: 19341
		private BuiltinDebugViewsComponent.ArrowArray m_Arrows;

		// Token: 0x0200069E RID: 1694
		private static class Uniforms
		{
			// Token: 0x040050DA RID: 20698
			internal static readonly int _DepthScale = Shader.PropertyToID("_DepthScale");

			// Token: 0x040050DB RID: 20699
			internal static readonly int _TempRT = Shader.PropertyToID("_TempRT");

			// Token: 0x040050DC RID: 20700
			internal static readonly int _Opacity = Shader.PropertyToID("_Opacity");

			// Token: 0x040050DD RID: 20701
			internal static readonly int _MainTex = Shader.PropertyToID("_MainTex");

			// Token: 0x040050DE RID: 20702
			internal static readonly int _TempRT2 = Shader.PropertyToID("_TempRT2");

			// Token: 0x040050DF RID: 20703
			internal static readonly int _Amplitude = Shader.PropertyToID("_Amplitude");

			// Token: 0x040050E0 RID: 20704
			internal static readonly int _Scale = Shader.PropertyToID("_Scale");
		}

		// Token: 0x0200069F RID: 1695
		private enum Pass
		{
			// Token: 0x040050E2 RID: 20706
			Depth,
			// Token: 0x040050E3 RID: 20707
			Normals,
			// Token: 0x040050E4 RID: 20708
			MovecOpacity,
			// Token: 0x040050E5 RID: 20709
			MovecImaging,
			// Token: 0x040050E6 RID: 20710
			MovecArrows
		}

		// Token: 0x020006A0 RID: 1696
		private class ArrowArray
		{
			// Token: 0x17000589 RID: 1417
			// (get) Token: 0x06002744 RID: 10052 RVA: 0x002059F2 File Offset: 0x00203BF2
			// (set) Token: 0x06002745 RID: 10053 RVA: 0x002059FA File Offset: 0x00203BFA
			public Mesh mesh { get; private set; }

			// Token: 0x1700058A RID: 1418
			// (get) Token: 0x06002746 RID: 10054 RVA: 0x00205A03 File Offset: 0x00203C03
			// (set) Token: 0x06002747 RID: 10055 RVA: 0x00205A0B File Offset: 0x00203C0B
			public int columnCount { get; private set; }

			// Token: 0x1700058B RID: 1419
			// (get) Token: 0x06002748 RID: 10056 RVA: 0x00205A14 File Offset: 0x00203C14
			// (set) Token: 0x06002749 RID: 10057 RVA: 0x00205A1C File Offset: 0x00203C1C
			public int rowCount { get; private set; }

			// Token: 0x0600274A RID: 10058 RVA: 0x00205A28 File Offset: 0x00203C28
			public void BuildMesh(int columns, int rows)
			{
				Vector3[] array = new Vector3[]
				{
					new Vector3(0f, 0f, 0f),
					new Vector3(0f, 1f, 0f),
					new Vector3(0f, 1f, 0f),
					new Vector3(-1f, 1f, 0f),
					new Vector3(0f, 1f, 0f),
					new Vector3(1f, 1f, 0f)
				};
				int num = 6 * columns * rows;
				List<Vector3> list = new List<Vector3>(num);
				List<Vector2> list2 = new List<Vector2>(num);
				for (int i = 0; i < rows; i++)
				{
					for (int j = 0; j < columns; j++)
					{
						Vector2 item = new Vector2((0.5f + (float)j) / (float)columns, (0.5f + (float)i) / (float)rows);
						for (int k = 0; k < 6; k++)
						{
							list.Add(array[k]);
							list2.Add(item);
						}
					}
				}
				int[] array2 = new int[num];
				for (int l = 0; l < num; l++)
				{
					array2[l] = l;
				}
				this.mesh = new Mesh
				{
					hideFlags = HideFlags.DontSave
				};
				this.mesh.SetVertices(list);
				this.mesh.SetUVs(0, list2);
				this.mesh.SetIndices(array2, MeshTopology.Lines, 0);
				this.mesh.UploadMeshData(true);
				this.columnCount = columns;
				this.rowCount = rows;
			}

			// Token: 0x0600274B RID: 10059 RVA: 0x00205BCB File Offset: 0x00203DCB
			public void Release()
			{
				GraphicsUtils.Destroy(this.mesh);
				this.mesh = null;
			}
		}
	}
}
