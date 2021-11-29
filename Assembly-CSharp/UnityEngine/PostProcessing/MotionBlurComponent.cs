using System;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000557 RID: 1367
	public sealed class MotionBlurComponent : PostProcessingComponentCommandBuffer<MotionBlurModel>
	{
		// Token: 0x170004F5 RID: 1269
		// (get) Token: 0x060022CE RID: 8910 RVA: 0x001EE0BD File Offset: 0x001EC2BD
		public MotionBlurComponent.ReconstructionFilter reconstructionFilter
		{
			get
			{
				if (this.m_ReconstructionFilter == null)
				{
					this.m_ReconstructionFilter = new MotionBlurComponent.ReconstructionFilter();
				}
				return this.m_ReconstructionFilter;
			}
		}

		// Token: 0x170004F6 RID: 1270
		// (get) Token: 0x060022CF RID: 8911 RVA: 0x001EE0D8 File Offset: 0x001EC2D8
		public MotionBlurComponent.FrameBlendingFilter frameBlendingFilter
		{
			get
			{
				if (this.m_FrameBlendingFilter == null)
				{
					this.m_FrameBlendingFilter = new MotionBlurComponent.FrameBlendingFilter();
				}
				return this.m_FrameBlendingFilter;
			}
		}

		// Token: 0x170004F7 RID: 1271
		// (get) Token: 0x060022D0 RID: 8912 RVA: 0x001EE0F4 File Offset: 0x001EC2F4
		public override bool active
		{
			get
			{
				MotionBlurModel.Settings settings = base.model.settings;
				return base.model.enabled && ((settings.shutterAngle > 0f && this.reconstructionFilter.IsSupported()) || settings.frameBlending > 0f) && SystemInfo.graphicsDeviceType != GraphicsDeviceType.OpenGLES2 && !this.context.interrupted;
			}
		}

		// Token: 0x060022D1 RID: 8913 RVA: 0x001EE159 File Offset: 0x001EC359
		public override string GetName()
		{
			return "Motion Blur";
		}

		// Token: 0x060022D2 RID: 8914 RVA: 0x001EE160 File Offset: 0x001EC360
		public void ResetHistory()
		{
			if (this.m_FrameBlendingFilter != null)
			{
				this.m_FrameBlendingFilter.Dispose();
			}
			this.m_FrameBlendingFilter = null;
		}

		// Token: 0x060022D3 RID: 8915 RVA: 0x001EE17C File Offset: 0x001EC37C
		public override DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.Depth | DepthTextureMode.MotionVectors;
		}

		// Token: 0x060022D4 RID: 8916 RVA: 0x001EE17F File Offset: 0x001EC37F
		public override CameraEvent GetCameraEvent()
		{
			return CameraEvent.BeforeImageEffects;
		}

		// Token: 0x060022D5 RID: 8917 RVA: 0x001EE183 File Offset: 0x001EC383
		public override void OnEnable()
		{
			this.m_FirstFrame = true;
		}

		// Token: 0x060022D6 RID: 8918 RVA: 0x001EE18C File Offset: 0x001EC38C
		public override void PopulateCommandBuffer(CommandBuffer cb)
		{
			if (this.m_FirstFrame)
			{
				this.m_FirstFrame = false;
				return;
			}
			Material material = this.context.materialFactory.Get("Hidden/Post FX/Motion Blur");
			Material mat = this.context.materialFactory.Get("Hidden/Post FX/Blit");
			MotionBlurModel.Settings settings = base.model.settings;
			RenderTextureFormat format = this.context.isHdr ? RenderTextureFormat.DefaultHDR : RenderTextureFormat.Default;
			int tempRT = MotionBlurComponent.Uniforms._TempRT;
			cb.GetTemporaryRT(tempRT, this.context.width, this.context.height, 0, FilterMode.Point, format);
			if (settings.shutterAngle > 0f && settings.frameBlending > 0f)
			{
				this.reconstructionFilter.ProcessImage(this.context, cb, ref settings, BuiltinRenderTextureType.CameraTarget, tempRT, material);
				this.frameBlendingFilter.BlendFrames(cb, settings.frameBlending, tempRT, BuiltinRenderTextureType.CameraTarget, material);
				this.frameBlendingFilter.PushFrame(cb, tempRT, this.context.width, this.context.height, material);
			}
			else if (settings.shutterAngle > 0f)
			{
				cb.SetGlobalTexture(MotionBlurComponent.Uniforms._MainTex, BuiltinRenderTextureType.CameraTarget);
				cb.Blit(BuiltinRenderTextureType.CameraTarget, tempRT, mat, 0);
				this.reconstructionFilter.ProcessImage(this.context, cb, ref settings, tempRT, BuiltinRenderTextureType.CameraTarget, material);
			}
			else if (settings.frameBlending > 0f)
			{
				cb.SetGlobalTexture(MotionBlurComponent.Uniforms._MainTex, BuiltinRenderTextureType.CameraTarget);
				cb.Blit(BuiltinRenderTextureType.CameraTarget, tempRT, mat, 0);
				this.frameBlendingFilter.BlendFrames(cb, settings.frameBlending, tempRT, BuiltinRenderTextureType.CameraTarget, material);
				this.frameBlendingFilter.PushFrame(cb, tempRT, this.context.width, this.context.height, material);
			}
			cb.ReleaseTemporaryRT(tempRT);
		}

		// Token: 0x060022D7 RID: 8919 RVA: 0x001EE383 File Offset: 0x001EC583
		public override void OnDisable()
		{
			if (this.m_FrameBlendingFilter != null)
			{
				this.m_FrameBlendingFilter.Dispose();
			}
		}

		// Token: 0x04004A69 RID: 19049
		private MotionBlurComponent.ReconstructionFilter m_ReconstructionFilter;

		// Token: 0x04004A6A RID: 19050
		private MotionBlurComponent.FrameBlendingFilter m_FrameBlendingFilter;

		// Token: 0x04004A6B RID: 19051
		private bool m_FirstFrame = true;

		// Token: 0x0200069B RID: 1691
		private static class Uniforms
		{
			// Token: 0x04004FFD RID: 20477
			internal static readonly int _VelocityScale = Shader.PropertyToID("_VelocityScale");

			// Token: 0x04004FFE RID: 20478
			internal static readonly int _MaxBlurRadius = Shader.PropertyToID("_MaxBlurRadius");

			// Token: 0x04004FFF RID: 20479
			internal static readonly int _RcpMaxBlurRadius = Shader.PropertyToID("_RcpMaxBlurRadius");

			// Token: 0x04005000 RID: 20480
			internal static readonly int _VelocityTex = Shader.PropertyToID("_VelocityTex");

			// Token: 0x04005001 RID: 20481
			internal static readonly int _MainTex = Shader.PropertyToID("_MainTex");

			// Token: 0x04005002 RID: 20482
			internal static readonly int _Tile2RT = Shader.PropertyToID("_Tile2RT");

			// Token: 0x04005003 RID: 20483
			internal static readonly int _Tile4RT = Shader.PropertyToID("_Tile4RT");

			// Token: 0x04005004 RID: 20484
			internal static readonly int _Tile8RT = Shader.PropertyToID("_Tile8RT");

			// Token: 0x04005005 RID: 20485
			internal static readonly int _TileMaxOffs = Shader.PropertyToID("_TileMaxOffs");

			// Token: 0x04005006 RID: 20486
			internal static readonly int _TileMaxLoop = Shader.PropertyToID("_TileMaxLoop");

			// Token: 0x04005007 RID: 20487
			internal static readonly int _TileVRT = Shader.PropertyToID("_TileVRT");

			// Token: 0x04005008 RID: 20488
			internal static readonly int _NeighborMaxTex = Shader.PropertyToID("_NeighborMaxTex");

			// Token: 0x04005009 RID: 20489
			internal static readonly int _LoopCount = Shader.PropertyToID("_LoopCount");

			// Token: 0x0400500A RID: 20490
			internal static readonly int _TempRT = Shader.PropertyToID("_TempRT");

			// Token: 0x0400500B RID: 20491
			internal static readonly int _History1LumaTex = Shader.PropertyToID("_History1LumaTex");

			// Token: 0x0400500C RID: 20492
			internal static readonly int _History2LumaTex = Shader.PropertyToID("_History2LumaTex");

			// Token: 0x0400500D RID: 20493
			internal static readonly int _History3LumaTex = Shader.PropertyToID("_History3LumaTex");

			// Token: 0x0400500E RID: 20494
			internal static readonly int _History4LumaTex = Shader.PropertyToID("_History4LumaTex");

			// Token: 0x0400500F RID: 20495
			internal static readonly int _History1ChromaTex = Shader.PropertyToID("_History1ChromaTex");

			// Token: 0x04005010 RID: 20496
			internal static readonly int _History2ChromaTex = Shader.PropertyToID("_History2ChromaTex");

			// Token: 0x04005011 RID: 20497
			internal static readonly int _History3ChromaTex = Shader.PropertyToID("_History3ChromaTex");

			// Token: 0x04005012 RID: 20498
			internal static readonly int _History4ChromaTex = Shader.PropertyToID("_History4ChromaTex");

			// Token: 0x04005013 RID: 20499
			internal static readonly int _History1Weight = Shader.PropertyToID("_History1Weight");

			// Token: 0x04005014 RID: 20500
			internal static readonly int _History2Weight = Shader.PropertyToID("_History2Weight");

			// Token: 0x04005015 RID: 20501
			internal static readonly int _History3Weight = Shader.PropertyToID("_History3Weight");

			// Token: 0x04005016 RID: 20502
			internal static readonly int _History4Weight = Shader.PropertyToID("_History4Weight");
		}

		// Token: 0x0200069C RID: 1692
		private enum Pass
		{
			// Token: 0x04005018 RID: 20504
			VelocitySetup,
			// Token: 0x04005019 RID: 20505
			TileMax1,
			// Token: 0x0400501A RID: 20506
			TileMax2,
			// Token: 0x0400501B RID: 20507
			TileMaxV,
			// Token: 0x0400501C RID: 20508
			NeighborMax,
			// Token: 0x0400501D RID: 20509
			Reconstruction,
			// Token: 0x0400501E RID: 20510
			FrameCompression,
			// Token: 0x0400501F RID: 20511
			FrameBlendingChroma,
			// Token: 0x04005020 RID: 20512
			FrameBlendingRaw
		}

		// Token: 0x0200069D RID: 1693
		public class ReconstructionFilter
		{
			// Token: 0x060026F9 RID: 9977 RVA: 0x001FD1DF File Offset: 0x001FB3DF
			public ReconstructionFilter()
			{
				this.CheckTextureFormatSupport();
			}

			// Token: 0x060026FA RID: 9978 RVA: 0x001FD1FC File Offset: 0x001FB3FC
			private void CheckTextureFormatSupport()
			{
				if (!SystemInfo.SupportsRenderTextureFormat(this.m_PackedRTFormat))
				{
					this.m_PackedRTFormat = RenderTextureFormat.ARGB32;
				}
			}

			// Token: 0x060026FB RID: 9979 RVA: 0x001FD212 File Offset: 0x001FB412
			public bool IsSupported()
			{
				return SystemInfo.supportsMotionVectors;
			}

			// Token: 0x060026FC RID: 9980 RVA: 0x001FD21C File Offset: 0x001FB41C
			public void ProcessImage(PostProcessingContext context, CommandBuffer cb, ref MotionBlurModel.Settings settings, RenderTargetIdentifier source, RenderTargetIdentifier destination, Material material)
			{
				int num = (int)(5f * (float)context.height / 100f);
				int num2 = ((num - 1) / 8 + 1) * 8;
				float value = settings.shutterAngle / 360f;
				cb.SetGlobalFloat(MotionBlurComponent.Uniforms._VelocityScale, value);
				cb.SetGlobalFloat(MotionBlurComponent.Uniforms._MaxBlurRadius, (float)num);
				cb.SetGlobalFloat(MotionBlurComponent.Uniforms._RcpMaxBlurRadius, 1f / (float)num);
				int velocityTex = MotionBlurComponent.Uniforms._VelocityTex;
				cb.GetTemporaryRT(velocityTex, context.width, context.height, 0, FilterMode.Point, this.m_PackedRTFormat, RenderTextureReadWrite.Linear);
				cb.Blit(null, velocityTex, material, 0);
				int tile2RT = MotionBlurComponent.Uniforms._Tile2RT;
				cb.GetTemporaryRT(tile2RT, context.width / 2, context.height / 2, 0, FilterMode.Point, this.m_VectorRTFormat, RenderTextureReadWrite.Linear);
				cb.SetGlobalTexture(MotionBlurComponent.Uniforms._MainTex, velocityTex);
				cb.Blit(velocityTex, tile2RT, material, 1);
				int tile4RT = MotionBlurComponent.Uniforms._Tile4RT;
				cb.GetTemporaryRT(tile4RT, context.width / 4, context.height / 4, 0, FilterMode.Point, this.m_VectorRTFormat, RenderTextureReadWrite.Linear);
				cb.SetGlobalTexture(MotionBlurComponent.Uniforms._MainTex, tile2RT);
				cb.Blit(tile2RT, tile4RT, material, 2);
				cb.ReleaseTemporaryRT(tile2RT);
				int tile8RT = MotionBlurComponent.Uniforms._Tile8RT;
				cb.GetTemporaryRT(tile8RT, context.width / 8, context.height / 8, 0, FilterMode.Point, this.m_VectorRTFormat, RenderTextureReadWrite.Linear);
				cb.SetGlobalTexture(MotionBlurComponent.Uniforms._MainTex, tile4RT);
				cb.Blit(tile4RT, tile8RT, material, 2);
				cb.ReleaseTemporaryRT(tile4RT);
				Vector2 v = Vector2.one * ((float)num2 / 8f - 1f) * -0.5f;
				cb.SetGlobalVector(MotionBlurComponent.Uniforms._TileMaxOffs, v);
				cb.SetGlobalFloat(MotionBlurComponent.Uniforms._TileMaxLoop, (float)((int)((float)num2 / 8f)));
				int tileVRT = MotionBlurComponent.Uniforms._TileVRT;
				cb.GetTemporaryRT(tileVRT, context.width / num2, context.height / num2, 0, FilterMode.Point, this.m_VectorRTFormat, RenderTextureReadWrite.Linear);
				cb.SetGlobalTexture(MotionBlurComponent.Uniforms._MainTex, tile8RT);
				cb.Blit(tile8RT, tileVRT, material, 3);
				cb.ReleaseTemporaryRT(tile8RT);
				int neighborMaxTex = MotionBlurComponent.Uniforms._NeighborMaxTex;
				int width = context.width / num2;
				int height = context.height / num2;
				cb.GetTemporaryRT(neighborMaxTex, width, height, 0, FilterMode.Point, this.m_VectorRTFormat, RenderTextureReadWrite.Linear);
				cb.SetGlobalTexture(MotionBlurComponent.Uniforms._MainTex, tileVRT);
				cb.Blit(tileVRT, neighborMaxTex, material, 4);
				cb.ReleaseTemporaryRT(tileVRT);
				cb.SetGlobalFloat(MotionBlurComponent.Uniforms._LoopCount, (float)Mathf.Clamp(settings.sampleCount / 2, 1, 64));
				cb.SetGlobalTexture(MotionBlurComponent.Uniforms._MainTex, source);
				cb.Blit(source, destination, material, 5);
				cb.ReleaseTemporaryRT(velocityTex);
				cb.ReleaseTemporaryRT(neighborMaxTex);
			}

			// Token: 0x04005021 RID: 20513
			private RenderTextureFormat m_VectorRTFormat = RenderTextureFormat.RGHalf;

			// Token: 0x04005022 RID: 20514
			private RenderTextureFormat m_PackedRTFormat = RenderTextureFormat.ARGB2101010;
		}

		// Token: 0x0200069E RID: 1694
		public class FrameBlendingFilter
		{
			// Token: 0x060026FD RID: 9981 RVA: 0x001FD4FE File Offset: 0x001FB6FE
			public FrameBlendingFilter()
			{
				this.m_UseCompression = MotionBlurComponent.FrameBlendingFilter.CheckSupportCompression();
				this.m_RawTextureFormat = MotionBlurComponent.FrameBlendingFilter.GetPreferredRenderTextureFormat();
				this.m_FrameList = new MotionBlurComponent.FrameBlendingFilter.Frame[4];
			}

			// Token: 0x060026FE RID: 9982 RVA: 0x001FD528 File Offset: 0x001FB728
			public void Dispose()
			{
				foreach (MotionBlurComponent.FrameBlendingFilter.Frame frame in this.m_FrameList)
				{
					frame.Release();
				}
			}

			// Token: 0x060026FF RID: 9983 RVA: 0x001FD55C File Offset: 0x001FB75C
			public void PushFrame(CommandBuffer cb, RenderTargetIdentifier source, int width, int height, Material material)
			{
				int frameCount = Time.frameCount;
				if (frameCount == this.m_LastFrameCount)
				{
					return;
				}
				int num = frameCount % this.m_FrameList.Length;
				if (this.m_UseCompression)
				{
					this.m_FrameList[num].MakeRecord(cb, source, width, height, material);
				}
				else
				{
					this.m_FrameList[num].MakeRecordRaw(cb, source, width, height, this.m_RawTextureFormat);
				}
				this.m_LastFrameCount = frameCount;
			}

			// Token: 0x06002700 RID: 9984 RVA: 0x001FD5CC File Offset: 0x001FB7CC
			public void BlendFrames(CommandBuffer cb, float strength, RenderTargetIdentifier source, RenderTargetIdentifier destination, Material material)
			{
				float time = Time.time;
				MotionBlurComponent.FrameBlendingFilter.Frame frameRelative = this.GetFrameRelative(-1);
				MotionBlurComponent.FrameBlendingFilter.Frame frameRelative2 = this.GetFrameRelative(-2);
				MotionBlurComponent.FrameBlendingFilter.Frame frameRelative3 = this.GetFrameRelative(-3);
				MotionBlurComponent.FrameBlendingFilter.Frame frameRelative4 = this.GetFrameRelative(-4);
				cb.SetGlobalTexture(MotionBlurComponent.Uniforms._History1LumaTex, frameRelative.lumaTexture);
				cb.SetGlobalTexture(MotionBlurComponent.Uniforms._History2LumaTex, frameRelative2.lumaTexture);
				cb.SetGlobalTexture(MotionBlurComponent.Uniforms._History3LumaTex, frameRelative3.lumaTexture);
				cb.SetGlobalTexture(MotionBlurComponent.Uniforms._History4LumaTex, frameRelative4.lumaTexture);
				cb.SetGlobalTexture(MotionBlurComponent.Uniforms._History1ChromaTex, frameRelative.chromaTexture);
				cb.SetGlobalTexture(MotionBlurComponent.Uniforms._History2ChromaTex, frameRelative2.chromaTexture);
				cb.SetGlobalTexture(MotionBlurComponent.Uniforms._History3ChromaTex, frameRelative3.chromaTexture);
				cb.SetGlobalTexture(MotionBlurComponent.Uniforms._History4ChromaTex, frameRelative4.chromaTexture);
				cb.SetGlobalFloat(MotionBlurComponent.Uniforms._History1Weight, frameRelative.CalculateWeight(strength, time));
				cb.SetGlobalFloat(MotionBlurComponent.Uniforms._History2Weight, frameRelative2.CalculateWeight(strength, time));
				cb.SetGlobalFloat(MotionBlurComponent.Uniforms._History3Weight, frameRelative3.CalculateWeight(strength, time));
				cb.SetGlobalFloat(MotionBlurComponent.Uniforms._History4Weight, frameRelative4.CalculateWeight(strength, time));
				cb.SetGlobalTexture(MotionBlurComponent.Uniforms._MainTex, source);
				cb.Blit(source, destination, material, this.m_UseCompression ? 7 : 8);
			}

			// Token: 0x06002701 RID: 9985 RVA: 0x001FD728 File Offset: 0x001FB928
			private static bool CheckSupportCompression()
			{
				return SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.R8) && SystemInfo.supportedRenderTargetCount > 1;
			}

			// Token: 0x06002702 RID: 9986 RVA: 0x001FD740 File Offset: 0x001FB940
			private static RenderTextureFormat GetPreferredRenderTextureFormat()
			{
				RenderTextureFormat[] array = new RenderTextureFormat[3];
				RuntimeHelpers.InitializeArray(array, fieldof(<PrivateImplementationDetails>.04841F4DCEC5FD57BE2018FC808EA3A6F022D53A90A2CC7BE3B174D29A7D5D96).FieldHandle);
				foreach (RenderTextureFormat renderTextureFormat in array)
				{
					if (SystemInfo.SupportsRenderTextureFormat(renderTextureFormat))
					{
						return renderTextureFormat;
					}
				}
				return RenderTextureFormat.Default;
			}

			// Token: 0x06002703 RID: 9987 RVA: 0x001FD77C File Offset: 0x001FB97C
			private MotionBlurComponent.FrameBlendingFilter.Frame GetFrameRelative(int offset)
			{
				int num = (Time.frameCount + this.m_FrameList.Length + offset) % this.m_FrameList.Length;
				return this.m_FrameList[num];
			}

			// Token: 0x04005023 RID: 20515
			private bool m_UseCompression;

			// Token: 0x04005024 RID: 20516
			private RenderTextureFormat m_RawTextureFormat;

			// Token: 0x04005025 RID: 20517
			private MotionBlurComponent.FrameBlendingFilter.Frame[] m_FrameList;

			// Token: 0x04005026 RID: 20518
			private int m_LastFrameCount;

			// Token: 0x020006EB RID: 1771
			private struct Frame
			{
				// Token: 0x0600275C RID: 10076 RVA: 0x001FF500 File Offset: 0x001FD700
				public float CalculateWeight(float strength, float currentTime)
				{
					if (Mathf.Approximately(this.m_Time, 0f))
					{
						return 0f;
					}
					float num = Mathf.Lerp(80f, 16f, strength);
					return Mathf.Exp((this.m_Time - currentTime) * num);
				}

				// Token: 0x0600275D RID: 10077 RVA: 0x001FF548 File Offset: 0x001FD748
				public void Release()
				{
					if (this.lumaTexture != null)
					{
						RenderTexture.ReleaseTemporary(this.lumaTexture);
					}
					if (this.chromaTexture != null)
					{
						RenderTexture.ReleaseTemporary(this.chromaTexture);
					}
					this.lumaTexture = null;
					this.chromaTexture = null;
				}

				// Token: 0x0600275E RID: 10078 RVA: 0x001FF598 File Offset: 0x001FD798
				public void MakeRecord(CommandBuffer cb, RenderTargetIdentifier source, int width, int height, Material material)
				{
					this.Release();
					this.lumaTexture = RenderTexture.GetTemporary(width, height, 0, RenderTextureFormat.R8, RenderTextureReadWrite.Linear);
					this.chromaTexture = RenderTexture.GetTemporary(width, height, 0, RenderTextureFormat.R8, RenderTextureReadWrite.Linear);
					this.lumaTexture.filterMode = FilterMode.Point;
					this.chromaTexture.filterMode = FilterMode.Point;
					if (this.m_MRT == null)
					{
						this.m_MRT = new RenderTargetIdentifier[2];
					}
					this.m_MRT[0] = this.lumaTexture;
					this.m_MRT[1] = this.chromaTexture;
					cb.SetGlobalTexture(MotionBlurComponent.Uniforms._MainTex, source);
					cb.SetRenderTarget(this.m_MRT, this.lumaTexture);
					cb.DrawMesh(GraphicsUtils.quad, Matrix4x4.identity, material, 0, 6);
					this.m_Time = Time.time;
				}

				// Token: 0x0600275F RID: 10079 RVA: 0x001FF66C File Offset: 0x001FD86C
				public void MakeRecordRaw(CommandBuffer cb, RenderTargetIdentifier source, int width, int height, RenderTextureFormat format)
				{
					this.Release();
					this.lumaTexture = RenderTexture.GetTemporary(width, height, 0, format);
					this.lumaTexture.filterMode = FilterMode.Point;
					cb.SetGlobalTexture(MotionBlurComponent.Uniforms._MainTex, source);
					cb.Blit(source, this.lumaTexture);
					this.m_Time = Time.time;
				}

				// Token: 0x0400518F RID: 20879
				public RenderTexture lumaTexture;

				// Token: 0x04005190 RID: 20880
				public RenderTexture chromaTexture;

				// Token: 0x04005191 RID: 20881
				private float m_Time;

				// Token: 0x04005192 RID: 20882
				private RenderTargetIdentifier[] m_MRT;
			}
		}
	}
}
