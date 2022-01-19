using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000557 RID: 1367
	public sealed class DitheringComponent : PostProcessingComponentRenderTexture<DitheringModel>
	{
		// Token: 0x170004F1 RID: 1265
		// (get) Token: 0x060022D5 RID: 8917 RVA: 0x001F098A File Offset: 0x001EEB8A
		public override bool active
		{
			get
			{
				return base.model.enabled && !this.context.interrupted;
			}
		}

		// Token: 0x060022D6 RID: 8918 RVA: 0x001F09A9 File Offset: 0x001EEBA9
		public override void OnDisable()
		{
			this.noiseTextures = null;
		}

		// Token: 0x060022D7 RID: 8919 RVA: 0x001F09B4 File Offset: 0x001EEBB4
		private void LoadNoiseTextures()
		{
			this.noiseTextures = new Texture2D[64];
			for (int i = 0; i < 64; i++)
			{
				this.noiseTextures[i] = Resources.Load<Texture2D>("Bluenoise64/LDR_LLL1_" + i.ToString());
			}
		}

		// Token: 0x060022D8 RID: 8920 RVA: 0x001F09FC File Offset: 0x001EEBFC
		public override void Prepare(Material uberMaterial)
		{
			int num = this.textureIndex + 1;
			this.textureIndex = num;
			if (num >= 64)
			{
				this.textureIndex = 0;
			}
			float value = Random.value;
			float value2 = Random.value;
			if (this.noiseTextures == null)
			{
				this.LoadNoiseTextures();
			}
			Texture2D texture2D = this.noiseTextures[this.textureIndex];
			uberMaterial.EnableKeyword("DITHERING");
			uberMaterial.SetTexture(DitheringComponent.Uniforms._DitheringTex, texture2D);
			uberMaterial.SetVector(DitheringComponent.Uniforms._DitheringCoords, new Vector4((float)this.context.width / (float)texture2D.width, (float)this.context.height / (float)texture2D.height, value, value2));
		}

		// Token: 0x04004ABC RID: 19132
		private Texture2D[] noiseTextures;

		// Token: 0x04004ABD RID: 19133
		private int textureIndex;

		// Token: 0x04004ABE RID: 19134
		private const int k_TextureCount = 64;

		// Token: 0x0200069C RID: 1692
		private static class Uniforms
		{
			// Token: 0x04005059 RID: 20569
			internal static readonly int _DitheringTex = Shader.PropertyToID("_DitheringTex");

			// Token: 0x0400505A RID: 20570
			internal static readonly int _DitheringCoords = Shader.PropertyToID("_DitheringCoords");
		}
	}
}
