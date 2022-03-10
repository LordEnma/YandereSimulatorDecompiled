using System;
using System.Collections.Generic;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000556 RID: 1366
	public sealed class BuiltinDebugViewsComponent : PostProcessingComponentCommandBuffer<BuiltinDebugViewsModel>
	{
		// Token: 0x170004EF RID: 1263
		// (get) Token: 0x060022C5 RID: 8901 RVA: 0x001F1A0C File Offset: 0x001EFC0C
		public override bool active
		{
			get
			{
				return base.model.IsModeActive(BuiltinDebugViewsModel.Mode.Depth) || base.model.IsModeActive(BuiltinDebugViewsModel.Mode.Normals) || base.model.IsModeActive(BuiltinDebugViewsModel.Mode.MotionVectors);
			}
		}

		// Token: 0x060022C6 RID: 8902 RVA: 0x001F1A38 File Offset: 0x001EFC38
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

		// Token: 0x060022C7 RID: 8903 RVA: 0x001F1A7F File Offset: 0x001EFC7F
		public override CameraEvent GetCameraEvent()
		{
			if (base.model.settings.mode != BuiltinDebugViewsModel.Mode.MotionVectors)
			{
				return CameraEvent.BeforeImageEffectsOpaque;
			}
			return CameraEvent.BeforeImageEffects;
		}

		// Token: 0x060022C8 RID: 8904 RVA: 0x001F1A99 File Offset: 0x001EFC99
		public override string GetName()
		{
			return "Builtin Debug Views";
		}

		// Token: 0x060022C9 RID: 8905 RVA: 0x001F1AA0 File Offset: 0x001EFCA0
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

		// Token: 0x060022CA RID: 8906 RVA: 0x001F1B30 File Offset: 0x001EFD30
		private void DepthPass(CommandBuffer cb)
		{
			Material mat = this.context.materialFactory.Get("Hidden/Post FX/Builtin Debug Views");
			BuiltinDebugViewsModel.DepthSettings depth = base.model.settings.depth;
			cb.SetGlobalFloat(BuiltinDebugViewsComponent.Uniforms._DepthScale, 1f / depth.scale);
			cb.Blit(null, BuiltinRenderTextureType.CameraTarget, mat, 0);
		}

		// Token: 0x060022CB RID: 8907 RVA: 0x001F1B8C File Offset: 0x001EFD8C
		private void DepthNormalsPass(CommandBuffer cb)
		{
			Material mat = this.context.materialFactory.Get("Hidden/Post FX/Builtin Debug Views");
			cb.Blit(null, BuiltinRenderTextureType.CameraTarget, mat, 1);
		}

		// Token: 0x060022CC RID: 8908 RVA: 0x001F1BC0 File Offset: 0x001EFDC0
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

		// Token: 0x060022CD RID: 8909 RVA: 0x001F1DB4 File Offset: 0x001EFFB4
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

		// Token: 0x060022CE RID: 8910 RVA: 0x001F1E2C File Offset: 0x001F002C
		public override void OnDisable()
		{
			if (this.m_Arrows != null)
			{
				this.m_Arrows.Release();
			}
			this.m_Arrows = null;
		}

		// Token: 0x04004AFB RID: 19195
		private const string k_ShaderString = "Hidden/Post FX/Builtin Debug Views";

		// Token: 0x04004AFC RID: 19196
		private BuiltinDebugViewsComponent.ArrowArray m_Arrows;

		// Token: 0x02000695 RID: 1685
		private static class Uniforms
		{
			// Token: 0x04005049 RID: 20553
			internal static readonly int _DepthScale = Shader.PropertyToID("_DepthScale");

			// Token: 0x0400504A RID: 20554
			internal static readonly int _TempRT = Shader.PropertyToID("_TempRT");

			// Token: 0x0400504B RID: 20555
			internal static readonly int _Opacity = Shader.PropertyToID("_Opacity");

			// Token: 0x0400504C RID: 20556
			internal static readonly int _MainTex = Shader.PropertyToID("_MainTex");

			// Token: 0x0400504D RID: 20557
			internal static readonly int _TempRT2 = Shader.PropertyToID("_TempRT2");

			// Token: 0x0400504E RID: 20558
			internal static readonly int _Amplitude = Shader.PropertyToID("_Amplitude");

			// Token: 0x0400504F RID: 20559
			internal static readonly int _Scale = Shader.PropertyToID("_Scale");
		}

		// Token: 0x02000696 RID: 1686
		private enum Pass
		{
			// Token: 0x04005051 RID: 20561
			Depth,
			// Token: 0x04005052 RID: 20562
			Normals,
			// Token: 0x04005053 RID: 20563
			MovecOpacity,
			// Token: 0x04005054 RID: 20564
			MovecImaging,
			// Token: 0x04005055 RID: 20565
			MovecArrows
		}

		// Token: 0x02000697 RID: 1687
		private class ArrowArray
		{
			// Token: 0x17000588 RID: 1416
			// (get) Token: 0x0600271C RID: 10012 RVA: 0x002020CA File Offset: 0x002002CA
			// (set) Token: 0x0600271D RID: 10013 RVA: 0x002020D2 File Offset: 0x002002D2
			public Mesh mesh { get; private set; }

			// Token: 0x17000589 RID: 1417
			// (get) Token: 0x0600271E RID: 10014 RVA: 0x002020DB File Offset: 0x002002DB
			// (set) Token: 0x0600271F RID: 10015 RVA: 0x002020E3 File Offset: 0x002002E3
			public int columnCount { get; private set; }

			// Token: 0x1700058A RID: 1418
			// (get) Token: 0x06002720 RID: 10016 RVA: 0x002020EC File Offset: 0x002002EC
			// (set) Token: 0x06002721 RID: 10017 RVA: 0x002020F4 File Offset: 0x002002F4
			public int rowCount { get; private set; }

			// Token: 0x06002722 RID: 10018 RVA: 0x00202100 File Offset: 0x00200300
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

			// Token: 0x06002723 RID: 10019 RVA: 0x002022A3 File Offset: 0x002004A3
			public void Release()
			{
				GraphicsUtils.Destroy(this.mesh);
				this.mesh = null;
			}
		}
	}
}
