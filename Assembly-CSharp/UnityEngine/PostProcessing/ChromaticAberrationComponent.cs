// Decompiled with JetBrains decompiler
// Type: UnityEngine.PostProcessing.ChromaticAberrationComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

namespace UnityEngine.PostProcessing
{
  public sealed class ChromaticAberrationComponent : 
    PostProcessingComponentRenderTexture<ChromaticAberrationModel>
  {
    private Texture2D m_SpectrumLut;

    public override bool active => this.model.enabled && (double) this.model.settings.intensity > 0.0 && !this.context.interrupted;

    public override void OnDisable()
    {
      GraphicsUtils.Destroy((Object) this.m_SpectrumLut);
      this.m_SpectrumLut = (Texture2D) null;
    }

    public override void Prepare(Material uberMaterial)
    {
      ChromaticAberrationModel.Settings settings = this.model.settings;
      Texture2D texture2D1 = settings.spectralTexture;
      if ((Object) texture2D1 == (Object) null)
      {
        if ((Object) this.m_SpectrumLut == (Object) null)
        {
          Texture2D texture2D2 = new Texture2D(3, 1, TextureFormat.RGB24, false);
          texture2D2.name = "Chromatic Aberration Spectrum Lookup";
          texture2D2.filterMode = FilterMode.Bilinear;
          texture2D2.wrapMode = TextureWrapMode.Clamp;
          texture2D2.anisoLevel = 0;
          texture2D2.hideFlags = HideFlags.DontSave;
          this.m_SpectrumLut = texture2D2;
          this.m_SpectrumLut.SetPixels(new Color[3]
          {
            new Color(1f, 0.0f, 0.0f),
            new Color(0.0f, 1f, 0.0f),
            new Color(0.0f, 0.0f, 1f)
          });
          this.m_SpectrumLut.Apply();
        }
        texture2D1 = this.m_SpectrumLut;
      }
      uberMaterial.EnableKeyword("CHROMATIC_ABERRATION");
      uberMaterial.SetFloat(ChromaticAberrationComponent.Uniforms._ChromaticAberration_Amount, settings.intensity * 0.03f);
      uberMaterial.SetTexture(ChromaticAberrationComponent.Uniforms._ChromaticAberration_Spectrum, (Texture) texture2D1);
    }

    private static class Uniforms
    {
      internal static readonly int _ChromaticAberration_Amount = Shader.PropertyToID(nameof (_ChromaticAberration_Amount));
      internal static readonly int _ChromaticAberration_Spectrum = Shader.PropertyToID(nameof (_ChromaticAberration_Spectrum));
    }
  }
}
