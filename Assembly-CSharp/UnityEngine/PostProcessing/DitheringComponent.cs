using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000566 RID: 1382
	public sealed class DitheringComponent : PostProcessingComponentRenderTexture<DitheringModel>
	{
		// Token: 0x170004F6 RID: 1270
		// (get) Token: 0x0600233F RID: 9023 RVA: 0x001FA4EE File Offset: 0x001F86EE
		public override bool active
		{
			get
			{
				return base.model.enabled && !this.context.interrupted;
			}
		}

		// Token: 0x06002340 RID: 9024 RVA: 0x001FA50D File Offset: 0x001F870D
		public override void OnDisable()
		{
			this.noiseTextures = null;
		}

		// Token: 0x06002341 RID: 9025 RVA: 0x001FA518 File Offset: 0x001F8718
		private void LoadNoiseTextures()
		{
			this.noiseTextures = new Texture2D[64];
			for (int i = 0; i < 64; i++)
			{
				this.noiseTextures[i] = Resources.Load<Texture2D>("Bluenoise64/LDR_LLL1_" + i.ToString());
			}
		}

		// Token: 0x06002342 RID: 9026 RVA: 0x001FA560 File Offset: 0x001F8760
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

		// Token: 0x04004BEA RID: 19434
		private Texture2D[] noiseTextures;

		// Token: 0x04004BEB RID: 19435
		private int textureIndex;

		// Token: 0x04004BEC RID: 19436
		private const int k_TextureCount = 64;

		// Token: 0x020006A7 RID: 1703
		private static class Uniforms
		{
			// Token: 0x04005166 RID: 20838
			internal static readonly int _DitheringTex = Shader.PropertyToID("_DitheringTex");

			// Token: 0x04005167 RID: 20839
			internal static readonly int _DitheringCoords = Shader.PropertyToID("_DitheringCoords");
		}
	}
}
