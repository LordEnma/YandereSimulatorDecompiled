using System;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200055C RID: 1372
	public sealed class MotionBlurComponent : PostProcessingComponentCommandBuffer<MotionBlurModel>
	{
		// Token: 0x170004F6 RID: 1270
		// (get) Token: 0x060022EF RID: 8943 RVA: 0x001F1451 File Offset: 0x001EF651
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

		// Token: 0x170004F7 RID: 1271
		// (get) Token: 0x060022F0 RID: 8944 RVA: 0x001F146C File Offset: 0x001EF66C
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

		// Token: 0x170004F8 RID: 1272
		// (get) Token: 0x060022F1 RID: 8945 RVA: 0x001F1488 File Offset: 0x001EF688
		public override bool active
		{
			get
			{
				MotionBlurModel.Settings settings = base.model.settings;
				return base.model.enabled && ((settings.shutterAngle > 0f && this.reconstructionFilter.IsSupported()) || settings.frameBlending > 0f) && SystemInfo.graphicsDeviceType != GraphicsDeviceType.OpenGLES2 && !this.context.interrupted;
			}
		}

		// Token: 0x060022F2 RID: 8946 RVA: 0x001F14ED File Offset: 0x001EF6ED
		public override string GetName()
		{
			return "Motion Blur";
		}

		// Token: 0x060022F3 RID: 8947 RVA: 0x001F14F4 File Offset: 0x001EF6F4
		public void ResetHistory()
		{
			if (this.m_FrameBlendingFilter != null)
			{
				this.m_FrameBlendingFilter.Dispose();
			}
			this.m_FrameBlendingFilter = null;
		}

		// Token: 0x060022F4 RID: 8948 RVA: 0x001F1510 File Offset: 0x001EF710
		public override DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.Depth | DepthTextureMode.MotionVectors;
		}

		// Token: 0x060022F5 RID: 8949 RVA: 0x001F1513 File Offset: 0x001EF713
		public override CameraEvent GetCameraEvent()
		{
			return CameraEvent.BeforeImageEffects;
		}

		// Token: 0x060022F6 RID: 8950 RVA: 0x001F1517 File Offset: 0x001EF717
		public override void OnEnable()
		{
			this.m_FirstFrame = true;
		}

		// Token: 0x060022F7 RID: 8951 RVA: 0x001F1520 File Offset: 0x001EF720
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

		// Token: 0x060022F8 RID: 8952 RVA: 0x001F1717 File Offset: 0x001EF917
		public override void OnDisable()
		{
			if (this.m_FrameBlendingFilter != null)
			{
				this.m_FrameBlendingFilter.Dispose();
			}
		}

		// Token: 0x04004ACC RID: 19148
		private MotionBlurComponent.ReconstructionFilter m_ReconstructionFilter;

		// Token: 0x04004ACD RID: 19149
		private MotionBlurComponent.FrameBlendingFilter m_FrameBlendingFilter;

		// Token: 0x04004ACE RID: 19150
		private bool m_FirstFrame = true;

		// Token: 0x020006A1 RID: 1697
		private static class Uniforms
		{
			// Token: 0x0400506C RID: 20588
			internal static readonly int _VelocityScale = Shader.PropertyToID("_VelocityScale");

			// Token: 0x0400506D RID: 20589
			internal static readonly int _MaxBlurRadius = Shader.PropertyToID("_MaxBlurRadius");

			// Token: 0x0400506E RID: 20590
			internal static readonly int _RcpMaxBlurRadius = Shader.PropertyToID("_RcpMaxBlurRadius");

			// Token: 0x0400506F RID: 20591
			internal static readonly int _VelocityTex = Shader.PropertyToID("_VelocityTex");

			// Token: 0x04005070 RID: 20592
			internal static readonly int _MainTex = Shader.PropertyToID("_MainTex");

			// Token: 0x04005071 RID: 20593
			internal static readonly int _Tile2RT = Shader.PropertyToID("_Tile2RT");

			// Token: 0x04005072 RID: 20594
			internal static readonly int _Tile4RT = Shader.PropertyToID("_Tile4RT");

			// Token: 0x04005073 RID: 20595
			internal static readonly int _Tile8RT = Shader.PropertyToID("_Tile8RT");

			// Token: 0x04005074 RID: 20596
			internal static readonly int _TileMaxOffs = Shader.PropertyToID("_TileMaxOffs");

			// Token: 0x04005075 RID: 20597
			internal static readonly int _TileMaxLoop = Shader.PropertyToID("_TileMaxLoop");

			// Token: 0x04005076 RID: 20598
			internal static readonly int _TileVRT = Shader.PropertyToID("_TileVRT");

			// Token: 0x04005077 RID: 20599
			internal static readonly int _NeighborMaxTex = Shader.PropertyToID("_NeighborMaxTex");

			// Token: 0x04005078 RID: 20600
			internal static readonly int _LoopCount = Shader.PropertyToID("_LoopCount");

			// Token: 0x04005079 RID: 20601
			internal static readonly int _TempRT = Shader.PropertyToID("_TempRT");

			// Token: 0x0400507A RID: 20602
			internal static readonly int _History1LumaTex = Shader.PropertyToID("_History1LumaTex");

			// Token: 0x0400507B RID: 20603
			internal static readonly int _History2LumaTex = Shader.PropertyToID("_History2LumaTex");

			// Token: 0x0400507C RID: 20604
			internal static readonly int _History3LumaTex = Shader.PropertyToID("_History3LumaTex");

			// Token: 0x0400507D RID: 20605
			internal static readonly int _History4LumaTex = Shader.PropertyToID("_History4LumaTex");

			// Token: 0x0400507E RID: 20606
			internal static readonly int _History1ChromaTex = Shader.PropertyToID("_History1ChromaTex");

			// Token: 0x0400507F RID: 20607
			internal static readonly int _History2ChromaTex = Shader.PropertyToID("_History2ChromaTex");

			// Token: 0x04005080 RID: 20608
			internal static readonly int _History3ChromaTex = Shader.PropertyToID("_History3ChromaTex");

			// Token: 0x04005081 RID: 20609
			internal static readonly int _History4ChromaTex = Shader.PropertyToID("_History4ChromaTex");

			// Token: 0x04005082 RID: 20610
			internal static readonly int _History1Weight = Shader.PropertyToID("_History1Weight");

			// Token: 0x04005083 RID: 20611
			internal static readonly int _History2Weight = Shader.PropertyToID("_History2Weight");

			// Token: 0x04005084 RID: 20612
			internal static readonly int _History3Weight = Shader.PropertyToID("_History3Weight");

			// Token: 0x04005085 RID: 20613
			internal static readonly int _History4Weight = Shader.PropertyToID("_History4Weight");
		}

		// Token: 0x020006A2 RID: 1698
		private enum Pass
		{
			// Token: 0x04005087 RID: 20615
			VelocitySetup,
			// Token: 0x04005088 RID: 20616
			TileMax1,
			// Token: 0x04005089 RID: 20617
			TileMax2,
			// Token: 0x0400508A RID: 20618
			TileMaxV,
			// Token: 0x0400508B RID: 20619
			NeighborMax,
			// Token: 0x0400508C RID: 20620
			Reconstruction,
			// Token: 0x0400508D RID: 20621
			FrameCompression,
			// Token: 0x0400508E RID: 20622
			FrameBlendingChroma,
			// Token: 0x0400508F RID: 20623
			FrameBlendingRaw
		}

		// Token: 0x020006A3 RID: 1699
		public class ReconstructionFilter
		{
			// Token: 0x0600271A RID: 10010 RVA: 0x00200597 File Offset: 0x001FE797
			public ReconstructionFilter()
			{
				this.CheckTextureFormatSupport();
			}

			// Token: 0x0600271B RID: 10011 RVA: 0x002005B4 File Offset: 0x001FE7B4
			private void CheckTextureFormatSupport()
			{
				if (!SystemInfo.SupportsRenderTextureFormat(this.m_PackedRTFormat))
				{
					this.m_PackedRTFormat = RenderTextureFormat.ARGB32;
				}
			}

			// Token: 0x0600271C RID: 10012 RVA: 0x002005CA File Offset: 0x001FE7CA
			public bool IsSupported()
			{
				return SystemInfo.supportsMotionVectors;
			}

			// Token: 0x0600271D RID: 10013 RVA: 0x002005D4 File Offset: 0x001FE7D4
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

			// Token: 0x04005090 RID: 20624
			private RenderTextureFormat m_VectorRTFormat = RenderTextureFormat.RGHalf;

			// Token: 0x04005091 RID: 20625
			private RenderTextureFormat m_PackedRTFormat = RenderTextureFormat.ARGB2101010;
		}

		// Token: 0x020006A4 RID: 1700
		public class FrameBlendingFilter
		{
			// Token: 0x0600271E RID: 10014 RVA: 0x002008B6 File Offset: 0x001FEAB6
			public FrameBlendingFilter()
			{
				this.m_UseCompression = MotionBlurComponent.FrameBlendingFilter.CheckSupportCompression();
				this.m_RawTextureFormat = MotionBlurComponent.FrameBlendingFilter.GetPreferredRenderTextureFormat();
				this.m_FrameList = new MotionBlurComponent.FrameBlendingFilter.Frame[4];
			}

			// Token: 0x0600271F RID: 10015 RVA: 0x002008E0 File Offset: 0x001FEAE0
			public void Dispose()
			{
				foreach (MotionBlurComponent.FrameBlendingFilter.Frame frame in this.m_FrameList)
				{
					frame.Release();
				}
			}

			// Token: 0x06002720 RID: 10016 RVA: 0x00200914 File Offset: 0x001FEB14
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

			// Token: 0x06002721 RID: 10017 RVA: 0x00200984 File Offset: 0x001FEB84
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

			// Token: 0x06002722 RID: 10018 RVA: 0x00200AE0 File Offset: 0x001FECE0
			private static bool CheckSupportCompression()
			{
				return SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.R8) && SystemInfo.supportedRenderTargetCount > 1;
			}

			// Token: 0x06002723 RID: 10019 RVA: 0x00200AF8 File Offset: 0x001FECF8
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

			// Token: 0x06002724 RID: 10020 RVA: 0x00200B34 File Offset: 0x001FED34
			private MotionBlurComponent.FrameBlendingFilter.Frame GetFrameRelative(int offset)
			{
				int num = (Time.frameCount + this.m_FrameList.Length + offset) % this.m_FrameList.Length;
				return this.m_FrameList[num];
			}

			// Token: 0x04005092 RID: 20626
			private bool m_UseCompression;

			// Token: 0x04005093 RID: 20627
			private RenderTextureFormat m_RawTextureFormat;

			// Token: 0x04005094 RID: 20628
			private MotionBlurComponent.FrameBlendingFilter.Frame[] m_FrameList;

			// Token: 0x04005095 RID: 20629
			private int m_LastFrameCount;

			// Token: 0x020006F1 RID: 1777
			private struct Frame
			{
				// Token: 0x0600277D RID: 10109 RVA: 0x002028B8 File Offset: 0x00200AB8
				public float CalculateWeight(float strength, float currentTime)
				{
					if (Mathf.Approximately(this.m_Time, 0f))
					{
						return 0f;
					}
					float num = Mathf.Lerp(80f, 16f, strength);
					return Mathf.Exp((this.m_Time - currentTime) * num);
				}

				// Token: 0x0600277E RID: 10110 RVA: 0x00202900 File Offset: 0x00200B00
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

				// Token: 0x0600277F RID: 10111 RVA: 0x00202950 File Offset: 0x00200B50
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

				// Token: 0x06002780 RID: 10112 RVA: 0x00202A24 File Offset: 0x00200C24
				public void MakeRecordRaw(CommandBuffer cb, RenderTargetIdentifier source, int width, int height, RenderTextureFormat format)
				{
					this.Release();
					this.lumaTexture = RenderTexture.GetTemporary(width, height, 0, format);
					this.lumaTexture.filterMode = FilterMode.Point;
					cb.SetGlobalTexture(MotionBlurComponent.Uniforms._MainTex, source);
					cb.Blit(source, this.lumaTexture);
					this.m_Time = Time.time;
				}

				// Token: 0x040051FE RID: 20990
				public RenderTexture lumaTexture;

				// Token: 0x040051FF RID: 20991
				public RenderTexture chromaTexture;

				// Token: 0x04005200 RID: 20992
				private float m_Time;

				// Token: 0x04005201 RID: 20993
				private RenderTargetIdentifier[] m_MRT;
			}
		}
	}
}
