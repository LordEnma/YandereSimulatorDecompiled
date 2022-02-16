using System;
using System.Collections.Generic;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000554 RID: 1364
	public sealed class BuiltinDebugViewsComponent : PostProcessingComponentCommandBuffer<BuiltinDebugViewsModel>
	{
		// Token: 0x170004EF RID: 1263
		// (get) Token: 0x060022B6 RID: 8886 RVA: 0x001F0454 File Offset: 0x001EE654
		public override bool active
		{
			get
			{
				return base.model.IsModeActive(BuiltinDebugViewsModel.Mode.Depth) || base.model.IsModeActive(BuiltinDebugViewsModel.Mode.Normals) || base.model.IsModeActive(BuiltinDebugViewsModel.Mode.MotionVectors);
			}
		}

		// Token: 0x060022B7 RID: 8887 RVA: 0x001F0480 File Offset: 0x001EE680
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

		// Token: 0x060022B8 RID: 8888 RVA: 0x001F04C7 File Offset: 0x001EE6C7
		public override CameraEvent GetCameraEvent()
		{
			if (base.model.settings.mode != BuiltinDebugViewsModel.Mode.MotionVectors)
			{
				return CameraEvent.BeforeImageEffectsOpaque;
			}
			return CameraEvent.BeforeImageEffects;
		}

		// Token: 0x060022B9 RID: 8889 RVA: 0x001F04E1 File Offset: 0x001EE6E1
		public override string GetName()
		{
			return "Builtin Debug Views";
		}

		// Token: 0x060022BA RID: 8890 RVA: 0x001F04E8 File Offset: 0x001EE6E8
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

		// Token: 0x060022BB RID: 8891 RVA: 0x001F0578 File Offset: 0x001EE778
		private void DepthPass(CommandBuffer cb)
		{
			Material mat = this.context.materialFactory.Get("Hidden/Post FX/Builtin Debug Views");
			BuiltinDebugViewsModel.DepthSettings depth = base.model.settings.depth;
			cb.SetGlobalFloat(BuiltinDebugViewsComponent.Uniforms._DepthScale, 1f / depth.scale);
			cb.Blit(null, BuiltinRenderTextureType.CameraTarget, mat, 0);
		}

		// Token: 0x060022BC RID: 8892 RVA: 0x001F05D4 File Offset: 0x001EE7D4
		private void DepthNormalsPass(CommandBuffer cb)
		{
			Material mat = this.context.materialFactory.Get("Hidden/Post FX/Builtin Debug Views");
			cb.Blit(null, BuiltinRenderTextureType.CameraTarget, mat, 1);
		}

		// Token: 0x060022BD RID: 8893 RVA: 0x001F0608 File Offset: 0x001EE808
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

		// Token: 0x060022BE RID: 8894 RVA: 0x001F07FC File Offset: 0x001EE9FC
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

		// Token: 0x060022BF RID: 8895 RVA: 0x001F0874 File Offset: 0x001EEA74
		public override void OnDisable()
		{
			if (this.m_Arrows != null)
			{
				this.m_Arrows.Release();
			}
			this.m_Arrows = null;
		}

		// Token: 0x04004ACE RID: 19150
		private const string k_ShaderString = "Hidden/Post FX/Builtin Debug Views";

		// Token: 0x04004ACF RID: 19151
		private BuiltinDebugViewsComponent.ArrowArray m_Arrows;

		// Token: 0x02000691 RID: 1681
		private static class Uniforms
		{
			// Token: 0x04005017 RID: 20503
			internal static readonly int _DepthScale = Shader.PropertyToID("_DepthScale");

			// Token: 0x04005018 RID: 20504
			internal static readonly int _TempRT = Shader.PropertyToID("_TempRT");

			// Token: 0x04005019 RID: 20505
			internal static readonly int _Opacity = Shader.PropertyToID("_Opacity");

			// Token: 0x0400501A RID: 20506
			internal static readonly int _MainTex = Shader.PropertyToID("_MainTex");

			// Token: 0x0400501B RID: 20507
			internal static readonly int _TempRT2 = Shader.PropertyToID("_TempRT2");

			// Token: 0x0400501C RID: 20508
			internal static readonly int _Amplitude = Shader.PropertyToID("_Amplitude");

			// Token: 0x0400501D RID: 20509
			internal static readonly int _Scale = Shader.PropertyToID("_Scale");
		}

		// Token: 0x02000692 RID: 1682
		private enum Pass
		{
			// Token: 0x0400501F RID: 20511
			Depth,
			// Token: 0x04005020 RID: 20512
			Normals,
			// Token: 0x04005021 RID: 20513
			MovecOpacity,
			// Token: 0x04005022 RID: 20514
			MovecImaging,
			// Token: 0x04005023 RID: 20515
			MovecArrows
		}

		// Token: 0x02000693 RID: 1683
		private class ArrowArray
		{
			// Token: 0x17000586 RID: 1414
			// (get) Token: 0x06002704 RID: 9988 RVA: 0x00200A4A File Offset: 0x001FEC4A
			// (set) Token: 0x06002705 RID: 9989 RVA: 0x00200A52 File Offset: 0x001FEC52
			public Mesh mesh { get; private set; }

			// Token: 0x17000587 RID: 1415
			// (get) Token: 0x06002706 RID: 9990 RVA: 0x00200A5B File Offset: 0x001FEC5B
			// (set) Token: 0x06002707 RID: 9991 RVA: 0x00200A63 File Offset: 0x001FEC63
			public int columnCount { get; private set; }

			// Token: 0x17000588 RID: 1416
			// (get) Token: 0x06002708 RID: 9992 RVA: 0x00200A6C File Offset: 0x001FEC6C
			// (set) Token: 0x06002709 RID: 9993 RVA: 0x00200A74 File Offset: 0x001FEC74
			public int rowCount { get; private set; }

			// Token: 0x0600270A RID: 9994 RVA: 0x00200A80 File Offset: 0x001FEC80
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

			// Token: 0x0600270B RID: 9995 RVA: 0x00200C23 File Offset: 0x001FEE23
			public void Release()
			{
				GraphicsUtils.Destroy(this.mesh);
				this.mesh = null;
			}
		}
	}
}
