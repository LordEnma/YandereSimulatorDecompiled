// Decompiled with JetBrains decompiler
// Type: UnityEngine.PostProcessing.MotionBlurComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
  public sealed class MotionBlurComponent : PostProcessingComponentCommandBuffer<MotionBlurModel>
  {
    private MotionBlurComponent.ReconstructionFilter m_ReconstructionFilter;
    private MotionBlurComponent.FrameBlendingFilter m_FrameBlendingFilter;
    private bool m_FirstFrame = true;

    public MotionBlurComponent.ReconstructionFilter reconstructionFilter
    {
      get
      {
        if (this.m_ReconstructionFilter == null)
          this.m_ReconstructionFilter = new MotionBlurComponent.ReconstructionFilter();
        return this.m_ReconstructionFilter;
      }
    }

    public MotionBlurComponent.FrameBlendingFilter frameBlendingFilter
    {
      get
      {
        if (this.m_FrameBlendingFilter == null)
          this.m_FrameBlendingFilter = new MotionBlurComponent.FrameBlendingFilter();
        return this.m_FrameBlendingFilter;
      }
    }

    public override bool active
    {
      get
      {
        MotionBlurModel.Settings settings = this.model.settings;
        return this.model.enabled && ((double) settings.shutterAngle > 0.0 && this.reconstructionFilter.IsSupported() || (double) settings.frameBlending > 0.0) && SystemInfo.graphicsDeviceType != GraphicsDeviceType.OpenGLES2 && !this.context.interrupted;
      }
    }

    public override string GetName() => "Motion Blur";

    public void ResetHistory()
    {
      if (this.m_FrameBlendingFilter != null)
        this.m_FrameBlendingFilter.Dispose();
      this.m_FrameBlendingFilter = (MotionBlurComponent.FrameBlendingFilter) null;
    }

    public override DepthTextureMode GetCameraFlags() => DepthTextureMode.Depth | DepthTextureMode.MotionVectors;

    public override CameraEvent GetCameraEvent() => CameraEvent.BeforeImageEffects;

    public override void OnEnable() => this.m_FirstFrame = true;

    public override void PopulateCommandBuffer(CommandBuffer cb)
    {
      if (this.m_FirstFrame)
      {
        this.m_FirstFrame = false;
      }
      else
      {
        Material material = this.context.materialFactory.Get("Hidden/Post FX/Motion Blur");
        Material mat = this.context.materialFactory.Get("Hidden/Post FX/Blit");
        MotionBlurModel.Settings settings = this.model.settings;
        RenderTextureFormat format = this.context.isHdr ? RenderTextureFormat.DefaultHDR : RenderTextureFormat.Default;
        int tempRt = MotionBlurComponent.Uniforms._TempRT;
        cb.GetTemporaryRT(tempRt, this.context.width, this.context.height, 0, FilterMode.Point, format);
        if ((double) settings.shutterAngle > 0.0 && (double) settings.frameBlending > 0.0)
        {
          this.reconstructionFilter.ProcessImage(this.context, cb, ref settings, (RenderTargetIdentifier) BuiltinRenderTextureType.CameraTarget, (RenderTargetIdentifier) tempRt, material);
          this.frameBlendingFilter.BlendFrames(cb, settings.frameBlending, (RenderTargetIdentifier) tempRt, (RenderTargetIdentifier) BuiltinRenderTextureType.CameraTarget, material);
          this.frameBlendingFilter.PushFrame(cb, (RenderTargetIdentifier) tempRt, this.context.width, this.context.height, material);
        }
        else if ((double) settings.shutterAngle > 0.0)
        {
          cb.SetGlobalTexture(MotionBlurComponent.Uniforms._MainTex, (RenderTargetIdentifier) BuiltinRenderTextureType.CameraTarget);
          cb.Blit((RenderTargetIdentifier) BuiltinRenderTextureType.CameraTarget, (RenderTargetIdentifier) tempRt, mat, 0);
          this.reconstructionFilter.ProcessImage(this.context, cb, ref settings, (RenderTargetIdentifier) tempRt, (RenderTargetIdentifier) BuiltinRenderTextureType.CameraTarget, material);
        }
        else if ((double) settings.frameBlending > 0.0)
        {
          cb.SetGlobalTexture(MotionBlurComponent.Uniforms._MainTex, (RenderTargetIdentifier) BuiltinRenderTextureType.CameraTarget);
          cb.Blit((RenderTargetIdentifier) BuiltinRenderTextureType.CameraTarget, (RenderTargetIdentifier) tempRt, mat, 0);
          this.frameBlendingFilter.BlendFrames(cb, settings.frameBlending, (RenderTargetIdentifier) tempRt, (RenderTargetIdentifier) BuiltinRenderTextureType.CameraTarget, material);
          this.frameBlendingFilter.PushFrame(cb, (RenderTargetIdentifier) tempRt, this.context.width, this.context.height, material);
        }
        cb.ReleaseTemporaryRT(tempRt);
      }
    }

    public override void OnDisable()
    {
      if (this.m_FrameBlendingFilter == null)
        return;
      this.m_FrameBlendingFilter.Dispose();
    }

    private static class Uniforms
    {
      internal static readonly int _VelocityScale = Shader.PropertyToID(nameof (_VelocityScale));
      internal static readonly int _MaxBlurRadius = Shader.PropertyToID(nameof (_MaxBlurRadius));
      internal static readonly int _RcpMaxBlurRadius = Shader.PropertyToID(nameof (_RcpMaxBlurRadius));
      internal static readonly int _VelocityTex = Shader.PropertyToID(nameof (_VelocityTex));
      internal static readonly int _MainTex = Shader.PropertyToID(nameof (_MainTex));
      internal static readonly int _Tile2RT = Shader.PropertyToID(nameof (_Tile2RT));
      internal static readonly int _Tile4RT = Shader.PropertyToID(nameof (_Tile4RT));
      internal static readonly int _Tile8RT = Shader.PropertyToID(nameof (_Tile8RT));
      internal static readonly int _TileMaxOffs = Shader.PropertyToID(nameof (_TileMaxOffs));
      internal static readonly int _TileMaxLoop = Shader.PropertyToID(nameof (_TileMaxLoop));
      internal static readonly int _TileVRT = Shader.PropertyToID(nameof (_TileVRT));
      internal static readonly int _NeighborMaxTex = Shader.PropertyToID(nameof (_NeighborMaxTex));
      internal static readonly int _LoopCount = Shader.PropertyToID(nameof (_LoopCount));
      internal static readonly int _TempRT = Shader.PropertyToID(nameof (_TempRT));
      internal static readonly int _History1LumaTex = Shader.PropertyToID(nameof (_History1LumaTex));
      internal static readonly int _History2LumaTex = Shader.PropertyToID(nameof (_History2LumaTex));
      internal static readonly int _History3LumaTex = Shader.PropertyToID(nameof (_History3LumaTex));
      internal static readonly int _History4LumaTex = Shader.PropertyToID(nameof (_History4LumaTex));
      internal static readonly int _History1ChromaTex = Shader.PropertyToID(nameof (_History1ChromaTex));
      internal static readonly int _History2ChromaTex = Shader.PropertyToID(nameof (_History2ChromaTex));
      internal static readonly int _History3ChromaTex = Shader.PropertyToID(nameof (_History3ChromaTex));
      internal static readonly int _History4ChromaTex = Shader.PropertyToID(nameof (_History4ChromaTex));
      internal static readonly int _History1Weight = Shader.PropertyToID(nameof (_History1Weight));
      internal static readonly int _History2Weight = Shader.PropertyToID(nameof (_History2Weight));
      internal static readonly int _History3Weight = Shader.PropertyToID(nameof (_History3Weight));
      internal static readonly int _History4Weight = Shader.PropertyToID(nameof (_History4Weight));
    }

    private enum Pass
    {
      VelocitySetup,
      TileMax1,
      TileMax2,
      TileMaxV,
      NeighborMax,
      Reconstruction,
      FrameCompression,
      FrameBlendingChroma,
      FrameBlendingRaw,
    }

    public class ReconstructionFilter
    {
      private RenderTextureFormat m_VectorRTFormat = RenderTextureFormat.RGHalf;
      private RenderTextureFormat m_PackedRTFormat = RenderTextureFormat.ARGB2101010;

      public ReconstructionFilter() => this.CheckTextureFormatSupport();

      private void CheckTextureFormatSupport()
      {
        if (SystemInfo.SupportsRenderTextureFormat(this.m_PackedRTFormat))
          return;
        this.m_PackedRTFormat = RenderTextureFormat.ARGB32;
      }

      public bool IsSupported() => SystemInfo.supportsMotionVectors;

      public void ProcessImage(
        PostProcessingContext context,
        CommandBuffer cb,
        ref MotionBlurModel.Settings settings,
        RenderTargetIdentifier source,
        RenderTargetIdentifier destination,
        Material material)
      {
        int num1 = (int) (5.0 * (double) context.height / 100.0);
        int num2 = ((num1 - 1) / 8 + 1) * 8;
        float num3 = settings.shutterAngle / 360f;
        cb.SetGlobalFloat(MotionBlurComponent.Uniforms._VelocityScale, num3);
        cb.SetGlobalFloat(MotionBlurComponent.Uniforms._MaxBlurRadius, (float) num1);
        cb.SetGlobalFloat(MotionBlurComponent.Uniforms._RcpMaxBlurRadius, 1f / (float) num1);
        int velocityTex = MotionBlurComponent.Uniforms._VelocityTex;
        cb.GetTemporaryRT(velocityTex, context.width, context.height, 0, FilterMode.Point, this.m_PackedRTFormat, RenderTextureReadWrite.Linear);
        cb.Blit((Texture) null, (RenderTargetIdentifier) velocityTex, material, 0);
        int tile2Rt = MotionBlurComponent.Uniforms._Tile2RT;
        cb.GetTemporaryRT(tile2Rt, context.width / 2, context.height / 2, 0, FilterMode.Point, this.m_VectorRTFormat, RenderTextureReadWrite.Linear);
        cb.SetGlobalTexture(MotionBlurComponent.Uniforms._MainTex, (RenderTargetIdentifier) velocityTex);
        cb.Blit((RenderTargetIdentifier) velocityTex, (RenderTargetIdentifier) tile2Rt, material, 1);
        int tile4Rt = MotionBlurComponent.Uniforms._Tile4RT;
        cb.GetTemporaryRT(tile4Rt, context.width / 4, context.height / 4, 0, FilterMode.Point, this.m_VectorRTFormat, RenderTextureReadWrite.Linear);
        cb.SetGlobalTexture(MotionBlurComponent.Uniforms._MainTex, (RenderTargetIdentifier) tile2Rt);
        cb.Blit((RenderTargetIdentifier) tile2Rt, (RenderTargetIdentifier) tile4Rt, material, 2);
        cb.ReleaseTemporaryRT(tile2Rt);
        int tile8Rt = MotionBlurComponent.Uniforms._Tile8RT;
        cb.GetTemporaryRT(tile8Rt, context.width / 8, context.height / 8, 0, FilterMode.Point, this.m_VectorRTFormat, RenderTextureReadWrite.Linear);
        cb.SetGlobalTexture(MotionBlurComponent.Uniforms._MainTex, (RenderTargetIdentifier) tile4Rt);
        cb.Blit((RenderTargetIdentifier) tile4Rt, (RenderTargetIdentifier) tile8Rt, material, 2);
        cb.ReleaseTemporaryRT(tile4Rt);
        Vector2 vector2 = Vector2.one * (float) ((double) num2 / 8.0 - 1.0) * -0.5f;
        cb.SetGlobalVector(MotionBlurComponent.Uniforms._TileMaxOffs, (Vector4) vector2);
        cb.SetGlobalFloat(MotionBlurComponent.Uniforms._TileMaxLoop, (float) (int) ((double) num2 / 8.0));
        int tileVrt = MotionBlurComponent.Uniforms._TileVRT;
        cb.GetTemporaryRT(tileVrt, context.width / num2, context.height / num2, 0, FilterMode.Point, this.m_VectorRTFormat, RenderTextureReadWrite.Linear);
        cb.SetGlobalTexture(MotionBlurComponent.Uniforms._MainTex, (RenderTargetIdentifier) tile8Rt);
        cb.Blit((RenderTargetIdentifier) tile8Rt, (RenderTargetIdentifier) tileVrt, material, 3);
        cb.ReleaseTemporaryRT(tile8Rt);
        int neighborMaxTex = MotionBlurComponent.Uniforms._NeighborMaxTex;
        int width = context.width / num2;
        int height = context.height / num2;
        cb.GetTemporaryRT(neighborMaxTex, width, height, 0, FilterMode.Point, this.m_VectorRTFormat, RenderTextureReadWrite.Linear);
        cb.SetGlobalTexture(MotionBlurComponent.Uniforms._MainTex, (RenderTargetIdentifier) tileVrt);
        cb.Blit((RenderTargetIdentifier) tileVrt, (RenderTargetIdentifier) neighborMaxTex, material, 4);
        cb.ReleaseTemporaryRT(tileVrt);
        cb.SetGlobalFloat(MotionBlurComponent.Uniforms._LoopCount, (float) Mathf.Clamp(settings.sampleCount / 2, 1, 64));
        cb.SetGlobalTexture(MotionBlurComponent.Uniforms._MainTex, source);
        cb.Blit(source, destination, material, 5);
        cb.ReleaseTemporaryRT(velocityTex);
        cb.ReleaseTemporaryRT(neighborMaxTex);
      }
    }

    public class FrameBlendingFilter
    {
      private bool m_UseCompression;
      private RenderTextureFormat m_RawTextureFormat;
      private MotionBlurComponent.FrameBlendingFilter.Frame[] m_FrameList;
      private int m_LastFrameCount;

      public FrameBlendingFilter()
      {
        this.m_UseCompression = MotionBlurComponent.FrameBlendingFilter.CheckSupportCompression();
        this.m_RawTextureFormat = MotionBlurComponent.FrameBlendingFilter.GetPreferredRenderTextureFormat();
        this.m_FrameList = new MotionBlurComponent.FrameBlendingFilter.Frame[4];
      }

      public void Dispose()
      {
        foreach (MotionBlurComponent.FrameBlendingFilter.Frame frame in this.m_FrameList)
          frame.Release();
      }

      public void PushFrame(
        CommandBuffer cb,
        RenderTargetIdentifier source,
        int width,
        int height,
        Material material)
      {
        int frameCount = Time.frameCount;
        if (frameCount == this.m_LastFrameCount)
          return;
        int index = frameCount % this.m_FrameList.Length;
        if (this.m_UseCompression)
          this.m_FrameList[index].MakeRecord(cb, source, width, height, material);
        else
          this.m_FrameList[index].MakeRecordRaw(cb, source, width, height, this.m_RawTextureFormat);
        this.m_LastFrameCount = frameCount;
      }

      public void BlendFrames(
        CommandBuffer cb,
        float strength,
        RenderTargetIdentifier source,
        RenderTargetIdentifier destination,
        Material material)
      {
        float time = Time.time;
        MotionBlurComponent.FrameBlendingFilter.Frame frameRelative1 = this.GetFrameRelative(-1);
        MotionBlurComponent.FrameBlendingFilter.Frame frameRelative2 = this.GetFrameRelative(-2);
        MotionBlurComponent.FrameBlendingFilter.Frame frameRelative3 = this.GetFrameRelative(-3);
        MotionBlurComponent.FrameBlendingFilter.Frame frameRelative4 = this.GetFrameRelative(-4);
        cb.SetGlobalTexture(MotionBlurComponent.Uniforms._History1LumaTex, (RenderTargetIdentifier) (Texture) frameRelative1.lumaTexture);
        cb.SetGlobalTexture(MotionBlurComponent.Uniforms._History2LumaTex, (RenderTargetIdentifier) (Texture) frameRelative2.lumaTexture);
        cb.SetGlobalTexture(MotionBlurComponent.Uniforms._History3LumaTex, (RenderTargetIdentifier) (Texture) frameRelative3.lumaTexture);
        cb.SetGlobalTexture(MotionBlurComponent.Uniforms._History4LumaTex, (RenderTargetIdentifier) (Texture) frameRelative4.lumaTexture);
        cb.SetGlobalTexture(MotionBlurComponent.Uniforms._History1ChromaTex, (RenderTargetIdentifier) (Texture) frameRelative1.chromaTexture);
        cb.SetGlobalTexture(MotionBlurComponent.Uniforms._History2ChromaTex, (RenderTargetIdentifier) (Texture) frameRelative2.chromaTexture);
        cb.SetGlobalTexture(MotionBlurComponent.Uniforms._History3ChromaTex, (RenderTargetIdentifier) (Texture) frameRelative3.chromaTexture);
        cb.SetGlobalTexture(MotionBlurComponent.Uniforms._History4ChromaTex, (RenderTargetIdentifier) (Texture) frameRelative4.chromaTexture);
        cb.SetGlobalFloat(MotionBlurComponent.Uniforms._History1Weight, frameRelative1.CalculateWeight(strength, time));
        cb.SetGlobalFloat(MotionBlurComponent.Uniforms._History2Weight, frameRelative2.CalculateWeight(strength, time));
        cb.SetGlobalFloat(MotionBlurComponent.Uniforms._History3Weight, frameRelative3.CalculateWeight(strength, time));
        cb.SetGlobalFloat(MotionBlurComponent.Uniforms._History4Weight, frameRelative4.CalculateWeight(strength, time));
        cb.SetGlobalTexture(MotionBlurComponent.Uniforms._MainTex, source);
        cb.Blit(source, destination, material, this.m_UseCompression ? 7 : 8);
      }

      private static bool CheckSupportCompression() => SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.R8) && SystemInfo.supportedRenderTargetCount > 1;

      private static RenderTextureFormat GetPreferredRenderTextureFormat()
      {
        RenderTextureFormat[] renderTextureFormatArray = new RenderTextureFormat[3]
        {
          RenderTextureFormat.RGB565,
          RenderTextureFormat.ARGB1555,
          RenderTextureFormat.ARGB4444
        };
        foreach (RenderTextureFormat format in renderTextureFormatArray)
        {
          if (SystemInfo.SupportsRenderTextureFormat(format))
            return format;
        }
        return RenderTextureFormat.Default;
      }

      private MotionBlurComponent.FrameBlendingFilter.Frame GetFrameRelative(
        int offset)
      {
        return this.m_FrameList[(Time.frameCount + this.m_FrameList.Length + offset) % this.m_FrameList.Length];
      }

      private struct Frame
      {
        public RenderTexture lumaTexture;
        public RenderTexture chromaTexture;
        private float m_Time;
        private RenderTargetIdentifier[] m_MRT;

        public float CalculateWeight(float strength, float currentTime)
        {
          if (Mathf.Approximately(this.m_Time, 0.0f))
            return 0.0f;
          float num = Mathf.Lerp(80f, 16f, strength);
          return Mathf.Exp((this.m_Time - currentTime) * num);
        }

        public void Release()
        {
          if ((Object) this.lumaTexture != (Object) null)
            RenderTexture.ReleaseTemporary(this.lumaTexture);
          if ((Object) this.chromaTexture != (Object) null)
            RenderTexture.ReleaseTemporary(this.chromaTexture);
          this.lumaTexture = (RenderTexture) null;
          this.chromaTexture = (RenderTexture) null;
        }

        public void MakeRecord(
          CommandBuffer cb,
          RenderTargetIdentifier source,
          int width,
          int height,
          Material material)
        {
          this.Release();
          this.lumaTexture = RenderTexture.GetTemporary(width, height, 0, RenderTextureFormat.R8, RenderTextureReadWrite.Linear);
          this.chromaTexture = RenderTexture.GetTemporary(width, height, 0, RenderTextureFormat.R8, RenderTextureReadWrite.Linear);
          this.lumaTexture.filterMode = FilterMode.Point;
          this.chromaTexture.filterMode = FilterMode.Point;
          if (this.m_MRT == null)
            this.m_MRT = new RenderTargetIdentifier[2];
          this.m_MRT[0] = (RenderTargetIdentifier) (Texture) this.lumaTexture;
          this.m_MRT[1] = (RenderTargetIdentifier) (Texture) this.chromaTexture;
          cb.SetGlobalTexture(MotionBlurComponent.Uniforms._MainTex, source);
          cb.SetRenderTarget(this.m_MRT, (RenderTargetIdentifier) (Texture) this.lumaTexture);
          cb.DrawMesh(GraphicsUtils.quad, Matrix4x4.identity, material, 0, 6);
          this.m_Time = Time.time;
        }

        public void MakeRecordRaw(
          CommandBuffer cb,
          RenderTargetIdentifier source,
          int width,
          int height,
          RenderTextureFormat format)
        {
          this.Release();
          this.lumaTexture = RenderTexture.GetTemporary(width, height, 0, format);
          this.lumaTexture.filterMode = FilterMode.Point;
          cb.SetGlobalTexture(MotionBlurComponent.Uniforms._MainTex, source);
          cb.Blit(source, (RenderTargetIdentifier) (Texture) this.lumaTexture);
          this.m_Time = Time.time;
        }
      }
    }
  }
}
