using System;
using System.Collections.Generic;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000561 RID: 1377
	public sealed class BuiltinDebugViewsComponent : PostProcessingComponentCommandBuffer<BuiltinDebugViewsModel>
	{
		// Token: 0x170004F1 RID: 1265
		// (get) Token: 0x06002305 RID: 8965 RVA: 0x001F75FC File Offset: 0x001F57FC
		public override bool active
		{
			get
			{
				return base.model.IsModeActive(BuiltinDebugViewsModel.Mode.Depth) || base.model.IsModeActive(BuiltinDebugViewsModel.Mode.Normals) || base.model.IsModeActive(BuiltinDebugViewsModel.Mode.MotionVectors);
			}
		}

		// Token: 0x06002306 RID: 8966 RVA: 0x001F7628 File Offset: 0x001F5828
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

		// Token: 0x06002307 RID: 8967 RVA: 0x001F766F File Offset: 0x001F586F
		public override CameraEvent GetCameraEvent()
		{
			if (base.model.settings.mode != BuiltinDebugViewsModel.Mode.MotionVectors)
			{
				return CameraEvent.BeforeImageEffectsOpaque;
			}
			return CameraEvent.BeforeImageEffects;
		}

		// Token: 0x06002308 RID: 8968 RVA: 0x001F7689 File Offset: 0x001F5889
		public override string GetName()
		{
			return "Builtin Debug Views";
		}

		// Token: 0x06002309 RID: 8969 RVA: 0x001F7690 File Offset: 0x001F5890
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

		// Token: 0x0600230A RID: 8970 RVA: 0x001F7720 File Offset: 0x001F5920
		private void DepthPass(CommandBuffer cb)
		{
			Material mat = this.context.materialFactory.Get("Hidden/Post FX/Builtin Debug Views");
			BuiltinDebugViewsModel.DepthSettings depth = base.model.settings.depth;
			cb.SetGlobalFloat(BuiltinDebugViewsComponent.Uniforms._DepthScale, 1f / depth.scale);
			cb.Blit(null, BuiltinRenderTextureType.CameraTarget, mat, 0);
		}

		// Token: 0x0600230B RID: 8971 RVA: 0x001F777C File Offset: 0x001F597C
		private void DepthNormalsPass(CommandBuffer cb)
		{
			Material mat = this.context.materialFactory.Get("Hidden/Post FX/Builtin Debug Views");
			cb.Blit(null, BuiltinRenderTextureType.CameraTarget, mat, 1);
		}

		// Token: 0x0600230C RID: 8972 RVA: 0x001F77B0 File Offset: 0x001F59B0
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

		// Token: 0x0600230D RID: 8973 RVA: 0x001F79A4 File Offset: 0x001F5BA4
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

		// Token: 0x0600230E RID: 8974 RVA: 0x001F7A1C File Offset: 0x001F5C1C
		public override void OnDisable()
		{
			if (this.m_Arrows != null)
			{
				this.m_Arrows.Release();
			}
			this.m_Arrows = null;
		}

		// Token: 0x04004BB8 RID: 19384
		private const string k_ShaderString = "Hidden/Post FX/Builtin Debug Views";

		// Token: 0x04004BB9 RID: 19385
		private BuiltinDebugViewsComponent.ArrowArray m_Arrows;

		// Token: 0x020006A0 RID: 1696
		private static class Uniforms
		{
			// Token: 0x0400510E RID: 20750
			internal static readonly int _DepthScale = Shader.PropertyToID("_DepthScale");

			// Token: 0x0400510F RID: 20751
			internal static readonly int _TempRT = Shader.PropertyToID("_TempRT");

			// Token: 0x04005110 RID: 20752
			internal static readonly int _Opacity = Shader.PropertyToID("_Opacity");

			// Token: 0x04005111 RID: 20753
			internal static readonly int _MainTex = Shader.PropertyToID("_MainTex");

			// Token: 0x04005112 RID: 20754
			internal static readonly int _TempRT2 = Shader.PropertyToID("_TempRT2");

			// Token: 0x04005113 RID: 20755
			internal static readonly int _Amplitude = Shader.PropertyToID("_Amplitude");

			// Token: 0x04005114 RID: 20756
			internal static readonly int _Scale = Shader.PropertyToID("_Scale");
		}

		// Token: 0x020006A1 RID: 1697
		private enum Pass
		{
			// Token: 0x04005116 RID: 20758
			Depth,
			// Token: 0x04005117 RID: 20759
			Normals,
			// Token: 0x04005118 RID: 20760
			MovecOpacity,
			// Token: 0x04005119 RID: 20761
			MovecImaging,
			// Token: 0x0400511A RID: 20762
			MovecArrows
		}

		// Token: 0x020006A2 RID: 1698
		private class ArrowArray
		{
			// Token: 0x1700058A RID: 1418
			// (get) Token: 0x0600275C RID: 10076 RVA: 0x00207F1E File Offset: 0x0020611E
			// (set) Token: 0x0600275D RID: 10077 RVA: 0x00207F26 File Offset: 0x00206126
			public Mesh mesh { get; private set; }

			// Token: 0x1700058B RID: 1419
			// (get) Token: 0x0600275E RID: 10078 RVA: 0x00207F2F File Offset: 0x0020612F
			// (set) Token: 0x0600275F RID: 10079 RVA: 0x00207F37 File Offset: 0x00206137
			public int columnCount { get; private set; }

			// Token: 0x1700058C RID: 1420
			// (get) Token: 0x06002760 RID: 10080 RVA: 0x00207F40 File Offset: 0x00206140
			// (set) Token: 0x06002761 RID: 10081 RVA: 0x00207F48 File Offset: 0x00206148
			public int rowCount { get; private set; }

			// Token: 0x06002762 RID: 10082 RVA: 0x00207F54 File Offset: 0x00206154
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

			// Token: 0x06002763 RID: 10083 RVA: 0x002080F7 File Offset: 0x002062F7
			public void Release()
			{
				GraphicsUtils.Destroy(this.mesh);
				this.mesh = null;
			}
		}
	}
}
