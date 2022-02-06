using System;
using System.Collections.Generic;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000553 RID: 1363
	public sealed class BuiltinDebugViewsComponent : PostProcessingComponentCommandBuffer<BuiltinDebugViewsModel>
	{
		// Token: 0x170004EE RID: 1262
		// (get) Token: 0x060022AF RID: 8879 RVA: 0x001EFFA0 File Offset: 0x001EE1A0
		public override bool active
		{
			get
			{
				return base.model.IsModeActive(BuiltinDebugViewsModel.Mode.Depth) || base.model.IsModeActive(BuiltinDebugViewsModel.Mode.Normals) || base.model.IsModeActive(BuiltinDebugViewsModel.Mode.MotionVectors);
			}
		}

		// Token: 0x060022B0 RID: 8880 RVA: 0x001EFFCC File Offset: 0x001EE1CC
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

		// Token: 0x060022B1 RID: 8881 RVA: 0x001F0013 File Offset: 0x001EE213
		public override CameraEvent GetCameraEvent()
		{
			if (base.model.settings.mode != BuiltinDebugViewsModel.Mode.MotionVectors)
			{
				return CameraEvent.BeforeImageEffectsOpaque;
			}
			return CameraEvent.BeforeImageEffects;
		}

		// Token: 0x060022B2 RID: 8882 RVA: 0x001F002D File Offset: 0x001EE22D
		public override string GetName()
		{
			return "Builtin Debug Views";
		}

		// Token: 0x060022B3 RID: 8883 RVA: 0x001F0034 File Offset: 0x001EE234
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

		// Token: 0x060022B4 RID: 8884 RVA: 0x001F00C4 File Offset: 0x001EE2C4
		private void DepthPass(CommandBuffer cb)
		{
			Material mat = this.context.materialFactory.Get("Hidden/Post FX/Builtin Debug Views");
			BuiltinDebugViewsModel.DepthSettings depth = base.model.settings.depth;
			cb.SetGlobalFloat(BuiltinDebugViewsComponent.Uniforms._DepthScale, 1f / depth.scale);
			cb.Blit(null, BuiltinRenderTextureType.CameraTarget, mat, 0);
		}

		// Token: 0x060022B5 RID: 8885 RVA: 0x001F0120 File Offset: 0x001EE320
		private void DepthNormalsPass(CommandBuffer cb)
		{
			Material mat = this.context.materialFactory.Get("Hidden/Post FX/Builtin Debug Views");
			cb.Blit(null, BuiltinRenderTextureType.CameraTarget, mat, 1);
		}

		// Token: 0x060022B6 RID: 8886 RVA: 0x001F0154 File Offset: 0x001EE354
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

		// Token: 0x060022B7 RID: 8887 RVA: 0x001F0348 File Offset: 0x001EE548
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

		// Token: 0x060022B8 RID: 8888 RVA: 0x001F03C0 File Offset: 0x001EE5C0
		public override void OnDisable()
		{
			if (this.m_Arrows != null)
			{
				this.m_Arrows.Release();
			}
			this.m_Arrows = null;
		}

		// Token: 0x04004AC5 RID: 19141
		private const string k_ShaderString = "Hidden/Post FX/Builtin Debug Views";

		// Token: 0x04004AC6 RID: 19142
		private BuiltinDebugViewsComponent.ArrowArray m_Arrows;

		// Token: 0x02000690 RID: 1680
		private static class Uniforms
		{
			// Token: 0x0400500E RID: 20494
			internal static readonly int _DepthScale = Shader.PropertyToID("_DepthScale");

			// Token: 0x0400500F RID: 20495
			internal static readonly int _TempRT = Shader.PropertyToID("_TempRT");

			// Token: 0x04005010 RID: 20496
			internal static readonly int _Opacity = Shader.PropertyToID("_Opacity");

			// Token: 0x04005011 RID: 20497
			internal static readonly int _MainTex = Shader.PropertyToID("_MainTex");

			// Token: 0x04005012 RID: 20498
			internal static readonly int _TempRT2 = Shader.PropertyToID("_TempRT2");

			// Token: 0x04005013 RID: 20499
			internal static readonly int _Amplitude = Shader.PropertyToID("_Amplitude");

			// Token: 0x04005014 RID: 20500
			internal static readonly int _Scale = Shader.PropertyToID("_Scale");
		}

		// Token: 0x02000691 RID: 1681
		private enum Pass
		{
			// Token: 0x04005016 RID: 20502
			Depth,
			// Token: 0x04005017 RID: 20503
			Normals,
			// Token: 0x04005018 RID: 20504
			MovecOpacity,
			// Token: 0x04005019 RID: 20505
			MovecImaging,
			// Token: 0x0400501A RID: 20506
			MovecArrows
		}

		// Token: 0x02000692 RID: 1682
		private class ArrowArray
		{
			// Token: 0x17000585 RID: 1413
			// (get) Token: 0x060026FD RID: 9981 RVA: 0x00200596 File Offset: 0x001FE796
			// (set) Token: 0x060026FE RID: 9982 RVA: 0x0020059E File Offset: 0x001FE79E
			public Mesh mesh { get; private set; }

			// Token: 0x17000586 RID: 1414
			// (get) Token: 0x060026FF RID: 9983 RVA: 0x002005A7 File Offset: 0x001FE7A7
			// (set) Token: 0x06002700 RID: 9984 RVA: 0x002005AF File Offset: 0x001FE7AF
			public int columnCount { get; private set; }

			// Token: 0x17000587 RID: 1415
			// (get) Token: 0x06002701 RID: 9985 RVA: 0x002005B8 File Offset: 0x001FE7B8
			// (set) Token: 0x06002702 RID: 9986 RVA: 0x002005C0 File Offset: 0x001FE7C0
			public int rowCount { get; private set; }

			// Token: 0x06002703 RID: 9987 RVA: 0x002005CC File Offset: 0x001FE7CC
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

			// Token: 0x06002704 RID: 9988 RVA: 0x0020076F File Offset: 0x001FE96F
			public void Release()
			{
				GraphicsUtils.Destroy(this.mesh);
				this.mesh = null;
			}
		}
	}
}
