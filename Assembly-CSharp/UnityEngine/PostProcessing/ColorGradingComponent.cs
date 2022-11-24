// Decompiled with JetBrains decompiler
// Type: UnityEngine.PostProcessing.ColorGradingComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

namespace UnityEngine.PostProcessing
{
  public sealed class ColorGradingComponent : PostProcessingComponentRenderTexture<ColorGradingModel>
  {
    private const int k_InternalLogLutSize = 32;
    private const int k_CurvePrecision = 128;
    private const float k_CurveStep = 0.0078125f;
    private Texture2D m_GradingCurves;
    private Color[] m_pixels = new Color[256];

    public override bool active => this.model.enabled && !this.context.interrupted;

    private float StandardIlluminantY(float x) => (float) (2.869999885559082 * (double) x - 3.0 * (double) x * (double) x - 0.27509507536888123);

    private Vector3 CIExyToLMS(float x, float y)
    {
      float num1 = 1f;
      float num2 = num1 * x / y;
      float num3 = num1 * (1f - x - y) / y;
      double x1 = 0.73280000686645508 * (double) num2 + 0.42960000038146973 * (double) num1 - 0.1624000072479248 * (double) num3;
      float num4 = (float) (-0.70359998941421509 * (double) num2 + 1.6974999904632568 * (double) num1 + 0.0060999998822808266 * (double) num3);
      float num5 = (float) (3.0 / 1000.0 * (double) num2 + 0.01360000018030405 * (double) num1 + 0.98339998722076416 * (double) num3);
      double y1 = (double) num4;
      double z = (double) num5;
      return new Vector3((float) x1, (float) y1, (float) z);
    }

    private Vector3 CalculateColorBalance(float temperature, float tint)
    {
      float num1 = temperature / 55f;
      float num2 = tint / 55f;
      float x = (float) (0.3127099871635437 - (double) num1 * ((double) num1 < 0.0 ? 0.10000000149011612 : 0.05000000074505806));
      float y = this.StandardIlluminantY(x) + num2 * 0.05f;
      Vector3 vector3 = new Vector3(0.949237f, 1.03542f, 1.08728f);
      Vector3 lms = this.CIExyToLMS(x, y);
      return new Vector3(vector3.x / lms.x, vector3.y / lms.y, vector3.z / lms.z);
    }

    private static Color NormalizeColor(Color c)
    {
      float a = (float) (((double) c.r + (double) c.g + (double) c.b) / 3.0);
      if (Mathf.Approximately(a, 0.0f))
        return new Color(1f, 1f, 1f, c.a);
      return new Color()
      {
        r = c.r / a,
        g = c.g / a,
        b = c.b / a,
        a = c.a
      };
    }

    private static Vector3 ClampVector(Vector3 v, float min, float max) => new Vector3(Mathf.Clamp(v.x, min, max), Mathf.Clamp(v.y, min, max), Mathf.Clamp(v.z, min, max));

    public static Vector3 GetLiftValue(Color lift)
    {
      Color color = ColorGradingComponent.NormalizeColor(lift);
      float num1 = (float) (((double) color.r + (double) color.g + (double) color.b) / 3.0);
      double x = ((double) color.r - (double) num1) * 0.10000000149011612 + (double) lift.a;
      float num2 = (float) (((double) color.g - (double) num1) * 0.10000000149011612) + lift.a;
      float num3 = (float) (((double) color.b - (double) num1) * 0.10000000149011612) + lift.a;
      double y = (double) num2;
      double z = (double) num3;
      return ColorGradingComponent.ClampVector(new Vector3((float) x, (float) y, (float) z), -1f, 1f);
    }

    public static Vector3 GetGammaValue(Color gamma)
    {
      Color color = ColorGradingComponent.NormalizeColor(gamma);
      float num1 = (float) (((double) color.r + (double) color.g + (double) color.b) / 3.0);
      gamma.a *= (double) gamma.a < 0.0 ? 0.8f : 5f;
      float b1 = Mathf.Pow(2f, (float) (((double) color.r - (double) num1) * 0.5)) + gamma.a;
      float b2 = Mathf.Pow(2f, (float) (((double) color.g - (double) num1) * 0.5)) + gamma.a;
      float b3 = Mathf.Pow(2f, (float) (((double) color.b - (double) num1) * 0.5)) + gamma.a;
      double x = 1.0 / (double) Mathf.Max(0.01f, b1);
      float num2 = 1f / Mathf.Max(0.01f, b2);
      float num3 = 1f / Mathf.Max(0.01f, b3);
      double y = (double) num2;
      double z = (double) num3;
      return ColorGradingComponent.ClampVector(new Vector3((float) x, (float) y, (float) z), 0.0f, 5f);
    }

    public static Vector3 GetGainValue(Color gain)
    {
      Color color = ColorGradingComponent.NormalizeColor(gain);
      float num1 = (float) (((double) color.r + (double) color.g + (double) color.b) / 3.0);
      gain.a *= (double) gain.a > 0.0 ? 3f : 1f;
      double x = (double) Mathf.Pow(2f, (float) (((double) color.r - (double) num1) * 0.5)) + (double) gain.a;
      float num2 = Mathf.Pow(2f, (float) (((double) color.g - (double) num1) * 0.5)) + gain.a;
      float num3 = Mathf.Pow(2f, (float) (((double) color.b - (double) num1) * 0.5)) + gain.a;
      double y = (double) num2;
      double z = (double) num3;
      return ColorGradingComponent.ClampVector(new Vector3((float) x, (float) y, (float) z), 0.0f, 4f);
    }

    public static void CalculateLiftGammaGain(
      Color lift,
      Color gamma,
      Color gain,
      out Vector3 outLift,
      out Vector3 outGamma,
      out Vector3 outGain)
    {
      outLift = ColorGradingComponent.GetLiftValue(lift);
      outGamma = ColorGradingComponent.GetGammaValue(gamma);
      outGain = ColorGradingComponent.GetGainValue(gain);
    }

    public static Vector3 GetSlopeValue(Color slope)
    {
      Color color = ColorGradingComponent.NormalizeColor(slope);
      float num1 = (float) (((double) color.r + (double) color.g + (double) color.b) / 3.0);
      slope.a *= 0.5f;
      double x = ((double) color.r - (double) num1) * 0.10000000149011612 + (double) slope.a + 1.0;
      float num2 = (float) (((double) color.g - (double) num1) * 0.10000000149011612 + (double) slope.a + 1.0);
      float num3 = (float) (((double) color.b - (double) num1) * 0.10000000149011612 + (double) slope.a + 1.0);
      double y = (double) num2;
      double z = (double) num3;
      return ColorGradingComponent.ClampVector(new Vector3((float) x, (float) y, (float) z), 0.0f, 2f);
    }

    public static Vector3 GetPowerValue(Color power)
    {
      Color color = ColorGradingComponent.NormalizeColor(power);
      float num1 = (float) (((double) color.r + (double) color.g + (double) color.b) / 3.0);
      power.a *= 0.5f;
      float b1 = (float) (((double) color.r - (double) num1) * 0.10000000149011612 + (double) power.a + 1.0);
      float b2 = (float) (((double) color.g - (double) num1) * 0.10000000149011612 + (double) power.a + 1.0);
      float b3 = (float) (((double) color.b - (double) num1) * 0.10000000149011612 + (double) power.a + 1.0);
      double x = 1.0 / (double) Mathf.Max(0.01f, b1);
      float num2 = 1f / Mathf.Max(0.01f, b2);
      float num3 = 1f / Mathf.Max(0.01f, b3);
      double y = (double) num2;
      double z = (double) num3;
      return ColorGradingComponent.ClampVector(new Vector3((float) x, (float) y, (float) z), 0.5f, 2.5f);
    }

    public static Vector3 GetOffsetValue(Color offset)
    {
      Color color = ColorGradingComponent.NormalizeColor(offset);
      float num1 = (float) (((double) color.r + (double) color.g + (double) color.b) / 3.0);
      offset.a *= 0.5f;
      double x = ((double) color.r - (double) num1) * 0.05000000074505806 + (double) offset.a;
      float num2 = (float) (((double) color.g - (double) num1) * 0.05000000074505806) + offset.a;
      float num3 = (float) (((double) color.b - (double) num1) * 0.05000000074505806) + offset.a;
      double y = (double) num2;
      double z = (double) num3;
      return ColorGradingComponent.ClampVector(new Vector3((float) x, (float) y, (float) z), -0.8f, 0.8f);
    }

    public static void CalculateSlopePowerOffset(
      Color slope,
      Color power,
      Color offset,
      out Vector3 outSlope,
      out Vector3 outPower,
      out Vector3 outOffset)
    {
      outSlope = ColorGradingComponent.GetSlopeValue(slope);
      outPower = ColorGradingComponent.GetPowerValue(power);
      outOffset = ColorGradingComponent.GetOffsetValue(offset);
    }

    private TextureFormat GetCurveFormat() => SystemInfo.SupportsTextureFormat(TextureFormat.RGBAHalf) ? TextureFormat.RGBAHalf : TextureFormat.RGBA32;

    private Texture2D GetCurveTexture()
    {
      if ((Object) this.m_GradingCurves == (Object) null)
      {
        Texture2D texture2D = new Texture2D(128, 2, this.GetCurveFormat(), false, true);
        texture2D.name = "Internal Curves Texture";
        texture2D.hideFlags = HideFlags.DontSave;
        texture2D.anisoLevel = 0;
        texture2D.wrapMode = TextureWrapMode.Clamp;
        texture2D.filterMode = FilterMode.Bilinear;
        this.m_GradingCurves = texture2D;
      }
      ColorGradingModel.CurvesSettings curves = this.model.settings.curves;
      curves.hueVShue.Cache();
      curves.hueVSsat.Cache();
      for (int index = 0; index < 128; ++index)
      {
        float t = (float) index * (1f / 128f);
        float r1 = curves.hueVShue.Evaluate(t);
        float g1 = curves.hueVSsat.Evaluate(t);
        float b1 = curves.satVSsat.Evaluate(t);
        float a1 = curves.lumVSsat.Evaluate(t);
        this.m_pixels[index] = new Color(r1, g1, b1, a1);
        float a2 = curves.master.Evaluate(t);
        float r2 = curves.red.Evaluate(t);
        float g2 = curves.green.Evaluate(t);
        float b2 = curves.blue.Evaluate(t);
        this.m_pixels[index + 128] = new Color(r2, g2, b2, a2);
      }
      this.m_GradingCurves.SetPixels(this.m_pixels);
      this.m_GradingCurves.Apply(false, false);
      return this.m_GradingCurves;
    }

    private bool IsLogLutValid(RenderTexture lut) => (Object) lut != (Object) null && lut.IsCreated() && lut.height == 32;

    private RenderTextureFormat GetLutFormat() => SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.ARGBHalf) ? RenderTextureFormat.ARGBHalf : RenderTextureFormat.ARGB32;

    private void GenerateLut()
    {
      ColorGradingModel.Settings settings = this.model.settings;
      if (!this.IsLogLutValid(this.model.bakedLut))
      {
        GraphicsUtils.Destroy((Object) this.model.bakedLut);
        ColorGradingModel model = this.model;
        RenderTexture renderTexture = new RenderTexture(1024, 32, 0, this.GetLutFormat());
        renderTexture.name = "Color Grading Log LUT";
        renderTexture.hideFlags = HideFlags.DontSave;
        renderTexture.filterMode = FilterMode.Bilinear;
        renderTexture.wrapMode = TextureWrapMode.Clamp;
        renderTexture.anisoLevel = 0;
        model.bakedLut = renderTexture;
      }
      Material mat = this.context.materialFactory.Get("Hidden/Post FX/Lut Generator");
      mat.SetVector(ColorGradingComponent.Uniforms._LutParams, new Vector4(32f, 0.00048828125f, 1f / 64f, 1.032258f));
      mat.shaderKeywords = (string[]) null;
      ColorGradingModel.TonemappingSettings tonemapping = settings.tonemapping;
      switch (tonemapping.tonemapper)
      {
        case ColorGradingModel.Tonemapper.ACES:
          mat.EnableKeyword("TONEMAPPING_FILMIC");
          break;
        case ColorGradingModel.Tonemapper.Neutral:
          mat.EnableKeyword("TONEMAPPING_NEUTRAL");
          float num1 = (float) ((double) tonemapping.neutralBlackIn * 20.0 + 1.0);
          float num2 = (float) ((double) tonemapping.neutralBlackOut * 10.0 + 1.0);
          double num3 = (double) tonemapping.neutralWhiteIn / 20.0;
          float num4 = (float) (1.0 - (double) tonemapping.neutralWhiteOut / 20.0);
          float t1 = num1 / num2;
          double num5 = (double) num4;
          float t2 = (float) (num3 / num5);
          float y = Mathf.Max(0.0f, Mathf.LerpUnclamped(0.57f, 0.37f, t1));
          float z = Mathf.LerpUnclamped(0.01f, 0.24f, t2);
          float w = Mathf.Max(0.0f, Mathf.LerpUnclamped(0.02f, 0.2f, t1));
          mat.SetVector(ColorGradingComponent.Uniforms._NeutralTonemapperParams1, new Vector4(0.2f, y, z, w));
          mat.SetVector(ColorGradingComponent.Uniforms._NeutralTonemapperParams2, new Vector4(0.02f, 0.3f, tonemapping.neutralWhiteLevel, tonemapping.neutralWhiteClip / 10f));
          break;
      }
      mat.SetFloat(ColorGradingComponent.Uniforms._HueShift, settings.basic.hueShift / 360f);
      mat.SetFloat(ColorGradingComponent.Uniforms._Saturation, settings.basic.saturation);
      mat.SetFloat(ColorGradingComponent.Uniforms._Contrast, settings.basic.contrast);
      mat.SetVector(ColorGradingComponent.Uniforms._Balance, (Vector4) this.CalculateColorBalance(settings.basic.temperature, settings.basic.tint));
      Vector3 outLift;
      Vector3 outGamma;
      Vector3 outGain;
      ColorGradingComponent.CalculateLiftGammaGain(settings.colorWheels.linear.lift, settings.colorWheels.linear.gamma, settings.colorWheels.linear.gain, out outLift, out outGamma, out outGain);
      mat.SetVector(ColorGradingComponent.Uniforms._Lift, (Vector4) outLift);
      mat.SetVector(ColorGradingComponent.Uniforms._InvGamma, (Vector4) outGamma);
      mat.SetVector(ColorGradingComponent.Uniforms._Gain, (Vector4) outGain);
      Vector3 outSlope;
      Vector3 outPower;
      Vector3 outOffset;
      ColorGradingComponent.CalculateSlopePowerOffset(settings.colorWheels.log.slope, settings.colorWheels.log.power, settings.colorWheels.log.offset, out outSlope, out outPower, out outOffset);
      mat.SetVector(ColorGradingComponent.Uniforms._Slope, (Vector4) outSlope);
      mat.SetVector(ColorGradingComponent.Uniforms._Power, (Vector4) outPower);
      mat.SetVector(ColorGradingComponent.Uniforms._Offset, (Vector4) outOffset);
      mat.SetVector(ColorGradingComponent.Uniforms._ChannelMixerRed, (Vector4) settings.channelMixer.red);
      mat.SetVector(ColorGradingComponent.Uniforms._ChannelMixerGreen, (Vector4) settings.channelMixer.green);
      mat.SetVector(ColorGradingComponent.Uniforms._ChannelMixerBlue, (Vector4) settings.channelMixer.blue);
      mat.SetTexture(ColorGradingComponent.Uniforms._Curves, (Texture) this.GetCurveTexture());
      Graphics.Blit((Texture) null, this.model.bakedLut, mat, 0);
    }

    public override void Prepare(Material uberMaterial)
    {
      if (this.model.isDirty || !this.IsLogLutValid(this.model.bakedLut))
      {
        this.GenerateLut();
        this.model.isDirty = false;
      }
      uberMaterial.EnableKeyword(this.context.profile.debugViews.IsModeActive(BuiltinDebugViewsModel.Mode.PreGradingLog) ? "COLOR_GRADING_LOG_VIEW" : "COLOR_GRADING");
      RenderTexture bakedLut = this.model.bakedLut;
      uberMaterial.SetTexture(ColorGradingComponent.Uniforms._LogLut, (Texture) bakedLut);
      uberMaterial.SetVector(ColorGradingComponent.Uniforms._LogLut_Params, (Vector4) new Vector3(1f / (float) bakedLut.width, 1f / (float) bakedLut.height, (float) bakedLut.height - 1f));
      float num = Mathf.Exp(this.model.settings.basic.postExposure * 0.6931472f);
      uberMaterial.SetFloat(ColorGradingComponent.Uniforms._ExposureEV, num);
    }

    public void OnGUI()
    {
      RenderTexture bakedLut = this.model.bakedLut;
      GUI.DrawTexture(new Rect((float) ((double) this.context.viewport.x * (double) Screen.width + 8.0), 8f, (float) bakedLut.width, (float) bakedLut.height), (Texture) bakedLut);
    }

    public override void OnDisable()
    {
      GraphicsUtils.Destroy((Object) this.m_GradingCurves);
      GraphicsUtils.Destroy((Object) this.model.bakedLut);
      this.m_GradingCurves = (Texture2D) null;
      this.model.bakedLut = (RenderTexture) null;
    }

    private static class Uniforms
    {
      internal static readonly int _LutParams = Shader.PropertyToID(nameof (_LutParams));
      internal static readonly int _NeutralTonemapperParams1 = Shader.PropertyToID(nameof (_NeutralTonemapperParams1));
      internal static readonly int _NeutralTonemapperParams2 = Shader.PropertyToID(nameof (_NeutralTonemapperParams2));
      internal static readonly int _HueShift = Shader.PropertyToID(nameof (_HueShift));
      internal static readonly int _Saturation = Shader.PropertyToID(nameof (_Saturation));
      internal static readonly int _Contrast = Shader.PropertyToID(nameof (_Contrast));
      internal static readonly int _Balance = Shader.PropertyToID(nameof (_Balance));
      internal static readonly int _Lift = Shader.PropertyToID(nameof (_Lift));
      internal static readonly int _InvGamma = Shader.PropertyToID(nameof (_InvGamma));
      internal static readonly int _Gain = Shader.PropertyToID(nameof (_Gain));
      internal static readonly int _Slope = Shader.PropertyToID(nameof (_Slope));
      internal static readonly int _Power = Shader.PropertyToID(nameof (_Power));
      internal static readonly int _Offset = Shader.PropertyToID(nameof (_Offset));
      internal static readonly int _ChannelMixerRed = Shader.PropertyToID(nameof (_ChannelMixerRed));
      internal static readonly int _ChannelMixerGreen = Shader.PropertyToID(nameof (_ChannelMixerGreen));
      internal static readonly int _ChannelMixerBlue = Shader.PropertyToID(nameof (_ChannelMixerBlue));
      internal static readonly int _Curves = Shader.PropertyToID(nameof (_Curves));
      internal static readonly int _LogLut = Shader.PropertyToID(nameof (_LogLut));
      internal static readonly int _LogLut_Params = Shader.PropertyToID(nameof (_LogLut_Params));
      internal static readonly int _ExposureEV = Shader.PropertyToID(nameof (_ExposureEV));
    }
  }
}
