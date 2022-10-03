// Decompiled with JetBrains decompiler
// Type: UnityEngine.PostProcessing.EyeAdaptationComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;

namespace UnityEngine.PostProcessing
{
  public sealed class EyeAdaptationComponent : 
    PostProcessingComponentRenderTexture<EyeAdaptationModel>
  {
    private ComputeShader m_EyeCompute;
    private ComputeBuffer m_HistogramBuffer;
    private readonly RenderTexture[] m_AutoExposurePool = new RenderTexture[2];
    private int m_AutoExposurePingPing;
    private RenderTexture m_CurrentAutoExposure;
    private RenderTexture m_DebugHistogram;
    private static uint[] s_EmptyHistogramBuffer;
    private bool m_FirstFrame = true;
    private const int k_HistogramBins = 64;
    private const int k_HistogramThreadX = 16;
    private const int k_HistogramThreadY = 16;

    public override bool active => this.model.enabled && SystemInfo.supportsComputeShaders && !this.context.interrupted;

    public void ResetHistory() => this.m_FirstFrame = true;

    public override void OnEnable() => this.m_FirstFrame = true;

    public override void OnDisable()
    {
      foreach (UnityEngine.Object @object in this.m_AutoExposurePool)
        GraphicsUtils.Destroy(@object);
      if (this.m_HistogramBuffer != null)
        this.m_HistogramBuffer.Release();
      this.m_HistogramBuffer = (ComputeBuffer) null;
      if ((UnityEngine.Object) this.m_DebugHistogram != (UnityEngine.Object) null)
        this.m_DebugHistogram.Release();
      this.m_DebugHistogram = (RenderTexture) null;
    }

    private Vector4 GetHistogramScaleOffsetRes()
    {
      EyeAdaptationModel.Settings settings = this.model.settings;
      float x = 1f / (float) (settings.logMax - settings.logMin);
      float y = (float) -settings.logMin * x;
      return new Vector4(x, y, Mathf.Floor((float) this.context.width / 2f), Mathf.Floor((float) this.context.height / 2f));
    }

    public Texture Prepare(RenderTexture source, Material uberMaterial)
    {
      EyeAdaptationModel.Settings settings = this.model.settings;
      if ((UnityEngine.Object) this.m_EyeCompute == (UnityEngine.Object) null)
        this.m_EyeCompute = Resources.Load<ComputeShader>("Shaders/EyeHistogram");
      Material mat1 = this.context.materialFactory.Get("Hidden/Post FX/Eye Adaptation");
      mat1.shaderKeywords = (string[]) null;
      if (this.m_HistogramBuffer == null)
        this.m_HistogramBuffer = new ComputeBuffer(64, 4);
      if (EyeAdaptationComponent.s_EmptyHistogramBuffer == null)
        EyeAdaptationComponent.s_EmptyHistogramBuffer = new uint[64];
      Vector4 histogramScaleOffsetRes = this.GetHistogramScaleOffsetRes();
      RenderTexture renderTexture1 = this.context.renderTextureFactory.Get((int) histogramScaleOffsetRes.z, (int) histogramScaleOffsetRes.w, format: source.format);
      Graphics.Blit((Texture) source, renderTexture1);
      if ((UnityEngine.Object) this.m_AutoExposurePool[0] == (UnityEngine.Object) null || !this.m_AutoExposurePool[0].IsCreated())
        this.m_AutoExposurePool[0] = new RenderTexture(1, 1, 0, RenderTextureFormat.RFloat);
      if ((UnityEngine.Object) this.m_AutoExposurePool[1] == (UnityEngine.Object) null || !this.m_AutoExposurePool[1].IsCreated())
        this.m_AutoExposurePool[1] = new RenderTexture(1, 1, 0, RenderTextureFormat.RFloat);
      this.m_HistogramBuffer.SetData((Array) EyeAdaptationComponent.s_EmptyHistogramBuffer);
      int kernel = this.m_EyeCompute.FindKernel("KEyeHistogram");
      this.m_EyeCompute.SetBuffer(kernel, "_Histogram", this.m_HistogramBuffer);
      this.m_EyeCompute.SetTexture(kernel, "_Source", (Texture) renderTexture1);
      this.m_EyeCompute.SetVector("_ScaleOffsetRes", histogramScaleOffsetRes);
      this.m_EyeCompute.Dispatch(kernel, Mathf.CeilToInt((float) renderTexture1.width / 16f), Mathf.CeilToInt((float) renderTexture1.height / 16f), 1);
      this.context.renderTextureFactory.Release(renderTexture1);
      settings.highPercent = Mathf.Clamp(settings.highPercent, 1.01f, 99f);
      settings.lowPercent = Mathf.Clamp(settings.lowPercent, 1f, settings.highPercent - 0.01f);
      mat1.SetBuffer("_Histogram", this.m_HistogramBuffer);
      mat1.SetVector(EyeAdaptationComponent.Uniforms._Params, new Vector4(settings.lowPercent * 0.01f, settings.highPercent * 0.01f, Mathf.Exp(settings.minLuminance * 0.6931472f), Mathf.Exp(settings.maxLuminance * 0.6931472f)));
      mat1.SetVector(EyeAdaptationComponent.Uniforms._Speed, (Vector4) new Vector2(settings.speedDown, settings.speedUp));
      mat1.SetVector(EyeAdaptationComponent.Uniforms._ScaleOffsetRes, histogramScaleOffsetRes);
      mat1.SetFloat(EyeAdaptationComponent.Uniforms._ExposureCompensation, settings.keyValue);
      if (settings.dynamicKeyValue)
        mat1.EnableKeyword("AUTO_KEY_VALUE");
      if (this.m_FirstFrame || !Application.isPlaying)
      {
        this.m_CurrentAutoExposure = this.m_AutoExposurePool[0];
        Graphics.Blit((Texture) null, this.m_CurrentAutoExposure, mat1, 1);
        Graphics.Blit((Texture) this.m_AutoExposurePool[0], this.m_AutoExposurePool[1]);
      }
      else
      {
        int exposurePingPing = this.m_AutoExposurePingPing;
        int num1;
        RenderTexture source1 = this.m_AutoExposurePool[(num1 = exposurePingPing + 1) % 2];
        int num2;
        RenderTexture renderTexture2 = this.m_AutoExposurePool[(num2 = num1 + 1) % 2];
        RenderTexture dest = renderTexture2;
        Material mat2 = mat1;
        int adaptationType = (int) settings.adaptationType;
        Graphics.Blit((Texture) source1, dest, mat2, adaptationType);
        int num3;
        this.m_AutoExposurePingPing = (num3 = num2 + 1) % 2;
        this.m_CurrentAutoExposure = renderTexture2;
      }
      if (this.context.profile.debugViews.IsModeActive(BuiltinDebugViewsModel.Mode.EyeAdaptation))
      {
        if ((UnityEngine.Object) this.m_DebugHistogram == (UnityEngine.Object) null || !this.m_DebugHistogram.IsCreated())
        {
          RenderTexture renderTexture3 = new RenderTexture(256, 128, 0, RenderTextureFormat.ARGB32);
          renderTexture3.filterMode = FilterMode.Point;
          renderTexture3.wrapMode = TextureWrapMode.Clamp;
          this.m_DebugHistogram = renderTexture3;
        }
        mat1.SetFloat(EyeAdaptationComponent.Uniforms._DebugWidth, (float) this.m_DebugHistogram.width);
        Graphics.Blit((Texture) null, this.m_DebugHistogram, mat1, 2);
      }
      this.m_FirstFrame = false;
      return (Texture) this.m_CurrentAutoExposure;
    }

    public void OnGUI()
    {
      if ((UnityEngine.Object) this.m_DebugHistogram == (UnityEngine.Object) null || !this.m_DebugHistogram.IsCreated())
        return;
      GUI.DrawTexture(new Rect((float) ((double) this.context.viewport.x * (double) Screen.width + 8.0), 8f, (float) this.m_DebugHistogram.width, (float) this.m_DebugHistogram.height), (Texture) this.m_DebugHistogram);
    }

    private static class Uniforms
    {
      internal static readonly int _Params = Shader.PropertyToID(nameof (_Params));
      internal static readonly int _Speed = Shader.PropertyToID(nameof (_Speed));
      internal static readonly int _ScaleOffsetRes = Shader.PropertyToID(nameof (_ScaleOffsetRes));
      internal static readonly int _ExposureCompensation = Shader.PropertyToID(nameof (_ExposureCompensation));
      internal static readonly int _AutoExposure = Shader.PropertyToID(nameof (_AutoExposure));
      internal static readonly int _DebugWidth = Shader.PropertyToID(nameof (_DebugWidth));
    }
  }
}
