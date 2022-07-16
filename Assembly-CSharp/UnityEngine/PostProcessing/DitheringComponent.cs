// Decompiled with JetBrains decompiler
// Type: UnityEngine.PostProcessing.DitheringComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

namespace UnityEngine.PostProcessing
{
  public sealed class DitheringComponent : PostProcessingComponentRenderTexture<DitheringModel>
  {
    private Texture2D[] noiseTextures;
    private int textureIndex;
    private const int k_TextureCount = 64;

    public override bool active => this.model.enabled && !this.context.interrupted;

    public override void OnDisable() => this.noiseTextures = (Texture2D[]) null;

    private void LoadNoiseTextures()
    {
      this.noiseTextures = new Texture2D[64];
      for (int index = 0; index < 64; ++index)
        this.noiseTextures[index] = Resources.Load<Texture2D>("Bluenoise64/LDR_LLL1_" + index.ToString());
    }

    public override void Prepare(Material uberMaterial)
    {
      if (++this.textureIndex >= 64)
        this.textureIndex = 0;
      float z = Random.value;
      float w = Random.value;
      if (this.noiseTextures == null)
        this.LoadNoiseTextures();
      Texture2D noiseTexture = this.noiseTextures[this.textureIndex];
      uberMaterial.EnableKeyword("DITHERING");
      uberMaterial.SetTexture(DitheringComponent.Uniforms._DitheringTex, (Texture) noiseTexture);
      uberMaterial.SetVector(DitheringComponent.Uniforms._DitheringCoords, new Vector4((float) this.context.width / (float) noiseTexture.width, (float) this.context.height / (float) noiseTexture.height, z, w));
    }

    private static class Uniforms
    {
      internal static readonly int _DitheringTex = Shader.PropertyToID(nameof (_DitheringTex));
      internal static readonly int _DitheringCoords = Shader.PropertyToID(nameof (_DitheringCoords));
    }
  }
}
