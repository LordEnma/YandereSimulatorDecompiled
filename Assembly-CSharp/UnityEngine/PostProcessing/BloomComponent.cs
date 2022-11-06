// Decompiled with JetBrains decompiler
// Type: UnityEngine.PostProcessing.BloomComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

namespace UnityEngine.PostProcessing
{
  public sealed class BloomComponent : PostProcessingComponentRenderTexture<BloomModel>
  {
    private const int k_MaxPyramidBlurLevel = 16;
    private readonly RenderTexture[] m_BlurBuffer1 = new RenderTexture[16];
    private readonly RenderTexture[] m_BlurBuffer2 = new RenderTexture[16];

    public override bool active => this.model.enabled && (double) this.model.settings.bloom.intensity > 0.0 && !this.context.interrupted;

    public void Prepare(RenderTexture source, Material uberMaterial, Texture autoExposure)
    {
      BloomModel.BloomSettings bloom = this.model.settings.bloom;
      BloomModel.LensDirtSettings lensDirt = this.model.settings.lensDirt;
      Material mat = this.context.materialFactory.Get("Hidden/Post FX/Bloom");
      mat.shaderKeywords = (string[]) null;
      mat.SetTexture(BloomComponent.Uniforms._AutoExposure, autoExposure);
      int width = this.context.width / 2;
      int num1 = this.context.height / 2;
      RenderTextureFormat format = Application.isMobilePlatform ? RenderTextureFormat.Default : RenderTextureFormat.DefaultHDR;
      float num2 = (float) ((double) Mathf.Log((float) num1, 2f) + (double) bloom.radius - 8.0);
      int num3 = (int) num2;
      int num4 = Mathf.Clamp(num3, 1, 16);
      float thresholdLinear = bloom.thresholdLinear;
      mat.SetFloat(BloomComponent.Uniforms._Threshold, thresholdLinear);
      float num5 = (float) ((double) thresholdLinear * (double) bloom.softKnee + 9.9999997473787516E-06);
      Vector3 vector3 = new Vector3(thresholdLinear - num5, num5 * 2f, 0.25f / num5);
      mat.SetVector(BloomComponent.Uniforms._Curve, (Vector4) vector3);
      mat.SetFloat(BloomComponent.Uniforms._PrefilterOffs, bloom.antiFlicker ? -0.5f : 0.0f);
      float x = 0.5f + num2 - (float) num3;
      mat.SetFloat(BloomComponent.Uniforms._SampleScale, x);
      if (bloom.antiFlicker)
        mat.EnableKeyword("ANTI_FLICKER");
      RenderTexture renderTexture1 = this.context.renderTextureFactory.Get(width, num1, format: format);
      Graphics.Blit((Texture) source, renderTexture1, mat, 0);
      RenderTexture source1 = renderTexture1;
      for (int index = 0; index < num4; ++index)
      {
        this.m_BlurBuffer1[index] = this.context.renderTextureFactory.Get(source1.width / 2, source1.height / 2, format: format);
        int pass = index == 0 ? 1 : 2;
        Graphics.Blit((Texture) source1, this.m_BlurBuffer1[index], mat, pass);
        source1 = this.m_BlurBuffer1[index];
      }
      for (int index = num4 - 2; index >= 0; --index)
      {
        RenderTexture renderTexture2 = this.m_BlurBuffer1[index];
        mat.SetTexture(BloomComponent.Uniforms._BaseTex, (Texture) renderTexture2);
        this.m_BlurBuffer2[index] = this.context.renderTextureFactory.Get(renderTexture2.width, renderTexture2.height, format: format);
        Graphics.Blit((Texture) source1, this.m_BlurBuffer2[index], mat, 3);
        source1 = this.m_BlurBuffer2[index];
      }
      RenderTexture renderTexture3 = source1;
      for (int index = 0; index < 16; ++index)
      {
        if ((Object) this.m_BlurBuffer1[index] != (Object) null)
          this.context.renderTextureFactory.Release(this.m_BlurBuffer1[index]);
        if ((Object) this.m_BlurBuffer2[index] != (Object) null && (Object) this.m_BlurBuffer2[index] != (Object) renderTexture3)
          this.context.renderTextureFactory.Release(this.m_BlurBuffer2[index]);
        this.m_BlurBuffer1[index] = (RenderTexture) null;
        this.m_BlurBuffer2[index] = (RenderTexture) null;
      }
      this.context.renderTextureFactory.Release(renderTexture1);
      uberMaterial.SetTexture(BloomComponent.Uniforms._BloomTex, (Texture) renderTexture3);
      uberMaterial.SetVector(BloomComponent.Uniforms._Bloom_Settings, (Vector4) new Vector2(x, bloom.intensity));
      if ((double) lensDirt.intensity > 0.0 && (Object) lensDirt.texture != (Object) null)
      {
        uberMaterial.SetTexture(BloomComponent.Uniforms._Bloom_DirtTex, lensDirt.texture);
        uberMaterial.SetFloat(BloomComponent.Uniforms._Bloom_DirtIntensity, lensDirt.intensity);
        uberMaterial.EnableKeyword("BLOOM_LENS_DIRT");
      }
      else
        uberMaterial.EnableKeyword("BLOOM");
    }

    private static class Uniforms
    {
      internal static readonly int _AutoExposure = Shader.PropertyToID(nameof (_AutoExposure));
      internal static readonly int _Threshold = Shader.PropertyToID(nameof (_Threshold));
      internal static readonly int _Curve = Shader.PropertyToID(nameof (_Curve));
      internal static readonly int _PrefilterOffs = Shader.PropertyToID(nameof (_PrefilterOffs));
      internal static readonly int _SampleScale = Shader.PropertyToID(nameof (_SampleScale));
      internal static readonly int _BaseTex = Shader.PropertyToID(nameof (_BaseTex));
      internal static readonly int _BloomTex = Shader.PropertyToID(nameof (_BloomTex));
      internal static readonly int _Bloom_Settings = Shader.PropertyToID(nameof (_Bloom_Settings));
      internal static readonly int _Bloom_DirtTex = Shader.PropertyToID(nameof (_Bloom_DirtTex));
      internal static readonly int _Bloom_DirtIntensity = Shader.PropertyToID(nameof (_Bloom_DirtIntensity));
    }
  }
}
