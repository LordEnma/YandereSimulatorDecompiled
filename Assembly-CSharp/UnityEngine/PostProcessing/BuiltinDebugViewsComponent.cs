using System;
using System.Collections.Generic;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200054E RID: 1358
	public sealed class BuiltinDebugViewsComponent : PostProcessingComponentCommandBuffer<BuiltinDebugViewsModel>
	{
		// Token: 0x170004EC RID: 1260
		// (get) Token: 0x06002285 RID: 8837 RVA: 0x001EBE50 File Offset: 0x001EA050
		public override bool active
		{
			get
			{
				return base.model.IsModeActive(BuiltinDebugViewsModel.Mode.Depth) || base.model.IsModeActive(BuiltinDebugViewsModel.Mode.Normals) || base.model.IsModeActive(BuiltinDebugViewsModel.Mode.MotionVectors);
			}
		}

		// Token: 0x06002286 RID: 8838 RVA: 0x001EBE7C File Offset: 0x001EA07C
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

		// Token: 0x06002287 RID: 8839 RVA: 0x001EBEC3 File Offset: 0x001EA0C3
		public override CameraEvent GetCameraEvent()
		{
			if (base.model.settings.mode != BuiltinDebugViewsModel.Mode.MotionVectors)
			{
				return CameraEvent.BeforeImageEffectsOpaque;
			}
			return CameraEvent.BeforeImageEffects;
		}

		// Token: 0x06002288 RID: 8840 RVA: 0x001EBEDD File Offset: 0x001EA0DD
		public override string GetName()
		{
			return "Builtin Debug Views";
		}

		// Token: 0x06002289 RID: 8841 RVA: 0x001EBEE4 File Offset: 0x001EA0E4
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

		// Token: 0x0600228A RID: 8842 RVA: 0x001EBF74 File Offset: 0x001EA174
		private void DepthPass(CommandBuffer cb)
		{
			Material mat = this.context.materialFactory.Get("Hidden/Post FX/Builtin Debug Views");
			BuiltinDebugViewsModel.DepthSettings depth = base.model.settings.depth;
			cb.SetGlobalFloat(BuiltinDebugViewsComponent.Uniforms._DepthScale, 1f / depth.scale);
			cb.Blit(null, BuiltinRenderTextureType.CameraTarget, mat, 0);
		}

		// Token: 0x0600228B RID: 8843 RVA: 0x001EBFD0 File Offset: 0x001EA1D0
		private void DepthNormalsPass(CommandBuffer cb)
		{
			Material mat = this.context.materialFactory.Get("Hidden/Post FX/Builtin Debug Views");
			cb.Blit(null, BuiltinRenderTextureType.CameraTarget, mat, 1);
		}

		// Token: 0x0600228C RID: 8844 RVA: 0x001EC004 File Offset: 0x001EA204
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

		// Token: 0x0600228D RID: 8845 RVA: 0x001EC1F8 File Offset: 0x001EA3F8
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

		// Token: 0x0600228E RID: 8846 RVA: 0x001EC270 File Offset: 0x001EA470
		public override void OnDisable()
		{
			if (this.m_Arrows != null)
			{
				this.m_Arrows.Release();
			}
			this.m_Arrows = null;
		}

		// Token: 0x04004A4E RID: 19022
		private const string k_ShaderString = "Hidden/Post FX/Builtin Debug Views";

		// Token: 0x04004A4F RID: 19023
		private BuiltinDebugViewsComponent.ArrowArray m_Arrows;

		// Token: 0x02000690 RID: 1680
		private static class Uniforms
		{
			// Token: 0x04004FB9 RID: 20409
			internal static readonly int _DepthScale = Shader.PropertyToID("_DepthScale");

			// Token: 0x04004FBA RID: 20410
			internal static readonly int _TempRT = Shader.PropertyToID("_TempRT");

			// Token: 0x04004FBB RID: 20411
			internal static readonly int _Opacity = Shader.PropertyToID("_Opacity");

			// Token: 0x04004FBC RID: 20412
			internal static readonly int _MainTex = Shader.PropertyToID("_MainTex");

			// Token: 0x04004FBD RID: 20413
			internal static readonly int _TempRT2 = Shader.PropertyToID("_TempRT2");

			// Token: 0x04004FBE RID: 20414
			internal static readonly int _Amplitude = Shader.PropertyToID("_Amplitude");

			// Token: 0x04004FBF RID: 20415
			internal static readonly int _Scale = Shader.PropertyToID("_Scale");
		}

		// Token: 0x02000691 RID: 1681
		private enum Pass
		{
			// Token: 0x04004FC1 RID: 20417
			Depth,
			// Token: 0x04004FC2 RID: 20418
			Normals,
			// Token: 0x04004FC3 RID: 20419
			MovecOpacity,
			// Token: 0x04004FC4 RID: 20420
			MovecImaging,
			// Token: 0x04004FC5 RID: 20421
			MovecArrows
		}

		// Token: 0x02000692 RID: 1682
		private class ArrowArray
		{
			// Token: 0x17000583 RID: 1411
			// (get) Token: 0x060026E7 RID: 9959 RVA: 0x001FCB06 File Offset: 0x001FAD06
			// (set) Token: 0x060026E8 RID: 9960 RVA: 0x001FCB0E File Offset: 0x001FAD0E
			public Mesh mesh { get; private set; }

			// Token: 0x17000584 RID: 1412
			// (get) Token: 0x060026E9 RID: 9961 RVA: 0x001FCB17 File Offset: 0x001FAD17
			// (set) Token: 0x060026EA RID: 9962 RVA: 0x001FCB1F File Offset: 0x001FAD1F
			public int columnCount { get; private set; }

			// Token: 0x17000585 RID: 1413
			// (get) Token: 0x060026EB RID: 9963 RVA: 0x001FCB28 File Offset: 0x001FAD28
			// (set) Token: 0x060026EC RID: 9964 RVA: 0x001FCB30 File Offset: 0x001FAD30
			public int rowCount { get; private set; }

			// Token: 0x060026ED RID: 9965 RVA: 0x001FCB3C File Offset: 0x001FAD3C
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

			// Token: 0x060026EE RID: 9966 RVA: 0x001FCCDF File Offset: 0x001FAEDF
			public void Release()
			{
				GraphicsUtils.Destroy(this.mesh);
				this.mesh = null;
			}
		}
	}
}
