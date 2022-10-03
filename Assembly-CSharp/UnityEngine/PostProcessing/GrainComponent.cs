// Decompiled with JetBrains decompiler
// Type: UnityEngine.PostProcessing.GrainComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

namespace UnityEngine.PostProcessing
{
  public sealed class GrainComponent : PostProcessingComponentRenderTexture<GrainModel>
  {
    private RenderTexture m_GrainLookupRT;

    public override bool active => this.model.enabled && (double) this.model.settings.intensity > 0.0 && SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.ARGBHalf) && !this.context.interrupted;

    public override void OnDisable()
    {
      GraphicsUtils.Destroy((Object) this.m_GrainLookupRT);
      this.m_GrainLookupRT = (RenderTexture) null;
    }

    public override void Prepare(Material uberMaterial)
    {
      GrainModel.Settings settings = this.model.settings;
      uberMaterial.EnableKeyword("GRAIN");
      float realtimeSinceStartup = Time.realtimeSinceStartup;
      float z = Random.value;
      float w = Random.value;
      if ((Object) this.m_GrainLookupRT == (Object) null || !this.m_GrainLookupRT.IsCreated())
      {
        GraphicsUtils.Destroy((Object) this.m_GrainLookupRT);
        RenderTexture renderTexture = new RenderTexture(192, 192, 0, RenderTextureFormat.ARGBHalf);
        renderTexture.filterMode = FilterMode.Bilinear;
        renderTexture.wrapMode = TextureWrapMode.Repeat;
        renderTexture.anisoLevel = 0;
        renderTexture.name = "Grain Lookup Texture";
        this.m_GrainLookupRT = renderTexture;
        this.m_GrainLookupRT.Create();
      }
      Material mat = this.context.materialFactory.Get("Hidden/Post FX/Grain Generator");
      mat.SetFloat(GrainComponent.Uniforms._Phase, realtimeSinceStartup / 20f);
      Graphics.Blit((Texture) null, this.m_GrainLookupRT, mat, settings.colored ? 1 : 0);
      uberMaterial.SetTexture(GrainComponent.Uniforms._GrainTex, (Texture) this.m_GrainLookupRT);
      uberMaterial.SetVector(GrainComponent.Uniforms._Grain_Params1, (Vector4) new Vector2(settings.luminanceContribution, settings.intensity * 20f));
      uberMaterial.SetVector(GrainComponent.Uniforms._Grain_Params2, new Vector4((float) this.context.width / (float) this.m_GrainLookupRT.width / settings.size, (float) this.context.height / (float) this.m_GrainLookupRT.height / settings.size, z, w));
    }

    private static class Uniforms
    {
      internal static readonly int _Grain_Params1 = Shader.PropertyToID(nameof (_Grain_Params1));
      internal static readonly int _Grain_Params2 = Shader.PropertyToID(nameof (_Grain_Params2));
      internal static readonly int _GrainTex = Shader.PropertyToID(nameof (_GrainTex));
      internal static readonly int _Phase = Shader.PropertyToID(nameof (_Phase));
    }
  }
}
