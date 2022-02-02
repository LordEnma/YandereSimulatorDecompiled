using System;
using System.Collections.Generic;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000553 RID: 1363
	public sealed class BuiltinDebugViewsComponent : PostProcessingComponentCommandBuffer<BuiltinDebugViewsModel>
	{
		// Token: 0x170004ED RID: 1261
		// (get) Token: 0x060022AA RID: 8874 RVA: 0x001EFA84 File Offset: 0x001EDC84
		public override bool active
		{
			get
			{
				return base.model.IsModeActive(BuiltinDebugViewsModel.Mode.Depth) || base.model.IsModeActive(BuiltinDebugViewsModel.Mode.Normals) || base.model.IsModeActive(BuiltinDebugViewsModel.Mode.MotionVectors);
			}
		}

		// Token: 0x060022AB RID: 8875 RVA: 0x001EFAB0 File Offset: 0x001EDCB0
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

		// Token: 0x060022AC RID: 8876 RVA: 0x001EFAF7 File Offset: 0x001EDCF7
		public override CameraEvent GetCameraEvent()
		{
			if (base.model.settings.mode != BuiltinDebugViewsModel.Mode.MotionVectors)
			{
				return CameraEvent.BeforeImageEffectsOpaque;
			}
			return CameraEvent.BeforeImageEffects;
		}

		// Token: 0x060022AD RID: 8877 RVA: 0x001EFB11 File Offset: 0x001EDD11
		public override string GetName()
		{
			return "Builtin Debug Views";
		}

		// Token: 0x060022AE RID: 8878 RVA: 0x001EFB18 File Offset: 0x001EDD18
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

		// Token: 0x060022AF RID: 8879 RVA: 0x001EFBA8 File Offset: 0x001EDDA8
		private void DepthPass(CommandBuffer cb)
		{
			Material mat = this.context.materialFactory.Get("Hidden/Post FX/Builtin Debug Views");
			BuiltinDebugViewsModel.DepthSettings depth = base.model.settings.depth;
			cb.SetGlobalFloat(BuiltinDebugViewsComponent.Uniforms._DepthScale, 1f / depth.scale);
			cb.Blit(null, BuiltinRenderTextureType.CameraTarget, mat, 0);
		}

		// Token: 0x060022B0 RID: 8880 RVA: 0x001EFC04 File Offset: 0x001EDE04
		private void DepthNormalsPass(CommandBuffer cb)
		{
			Material mat = this.context.materialFactory.Get("Hidden/Post FX/Builtin Debug Views");
			cb.Blit(null, BuiltinRenderTextureType.CameraTarget, mat, 1);
		}

		// Token: 0x060022B1 RID: 8881 RVA: 0x001EFC38 File Offset: 0x001EDE38
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

		// Token: 0x060022B2 RID: 8882 RVA: 0x001EFE2C File Offset: 0x001EE02C
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

		// Token: 0x060022B3 RID: 8883 RVA: 0x001EFEA4 File Offset: 0x001EE0A4
		public override void OnDisable()
		{
			if (this.m_Arrows != null)
			{
				this.m_Arrows.Release();
			}
			this.m_Arrows = null;
		}

		// Token: 0x04004ABC RID: 19132
		private const string k_ShaderString = "Hidden/Post FX/Builtin Debug Views";

		// Token: 0x04004ABD RID: 19133
		private BuiltinDebugViewsComponent.ArrowArray m_Arrows;

		// Token: 0x02000690 RID: 1680
		private static class Uniforms
		{
			// Token: 0x04005005 RID: 20485
			internal static readonly int _DepthScale = Shader.PropertyToID("_DepthScale");

			// Token: 0x04005006 RID: 20486
			internal static readonly int _TempRT = Shader.PropertyToID("_TempRT");

			// Token: 0x04005007 RID: 20487
			internal static readonly int _Opacity = Shader.PropertyToID("_Opacity");

			// Token: 0x04005008 RID: 20488
			internal static readonly int _MainTex = Shader.PropertyToID("_MainTex");

			// Token: 0x04005009 RID: 20489
			internal static readonly int _TempRT2 = Shader.PropertyToID("_TempRT2");

			// Token: 0x0400500A RID: 20490
			internal static readonly int _Amplitude = Shader.PropertyToID("_Amplitude");

			// Token: 0x0400500B RID: 20491
			internal static readonly int _Scale = Shader.PropertyToID("_Scale");
		}

		// Token: 0x02000691 RID: 1681
		private enum Pass
		{
			// Token: 0x0400500D RID: 20493
			Depth,
			// Token: 0x0400500E RID: 20494
			Normals,
			// Token: 0x0400500F RID: 20495
			MovecOpacity,
			// Token: 0x04005010 RID: 20496
			MovecImaging,
			// Token: 0x04005011 RID: 20497
			MovecArrows
		}

		// Token: 0x02000692 RID: 1682
		private class ArrowArray
		{
			// Token: 0x17000584 RID: 1412
			// (get) Token: 0x060026F8 RID: 9976 RVA: 0x0020007A File Offset: 0x001FE27A
			// (set) Token: 0x060026F9 RID: 9977 RVA: 0x00200082 File Offset: 0x001FE282
			public Mesh mesh { get; private set; }

			// Token: 0x17000585 RID: 1413
			// (get) Token: 0x060026FA RID: 9978 RVA: 0x0020008B File Offset: 0x001FE28B
			// (set) Token: 0x060026FB RID: 9979 RVA: 0x00200093 File Offset: 0x001FE293
			public int columnCount { get; private set; }

			// Token: 0x17000586 RID: 1414
			// (get) Token: 0x060026FC RID: 9980 RVA: 0x0020009C File Offset: 0x001FE29C
			// (set) Token: 0x060026FD RID: 9981 RVA: 0x002000A4 File Offset: 0x001FE2A4
			public int rowCount { get; private set; }

			// Token: 0x060026FE RID: 9982 RVA: 0x002000B0 File Offset: 0x001FE2B0
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

			// Token: 0x060026FF RID: 9983 RVA: 0x00200253 File Offset: 0x001FE453
			public void Release()
			{
				GraphicsUtils.Destroy(this.mesh);
				this.mesh = null;
			}
		}
	}
}
