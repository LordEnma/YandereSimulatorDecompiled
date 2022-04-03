using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000563 RID: 1379
	public sealed class DitheringComponent : PostProcessingComponentRenderTexture<DitheringModel>
	{
		// Token: 0x170004F4 RID: 1268
		// (get) Token: 0x0600231C RID: 8988 RVA: 0x001F698A File Offset: 0x001F4B8A
		public override bool active
		{
			get
			{
				return base.model.enabled && !this.context.interrupted;
			}
		}

		// Token: 0x0600231D RID: 8989 RVA: 0x001F69A9 File Offset: 0x001F4BA9
		public override void OnDisable()
		{
			this.noiseTextures = null;
		}

		// Token: 0x0600231E RID: 8990 RVA: 0x001F69B4 File Offset: 0x001F4BB4
		private void LoadNoiseTextures()
		{
			this.noiseTextures = new Texture2D[64];
			for (int i = 0; i < 64; i++)
			{
				this.noiseTextures[i] = Resources.Load<Texture2D>("Bluenoise64/LDR_LLL1_" + i.ToString());
			}
		}

		// Token: 0x0600231F RID: 8991 RVA: 0x001F69FC File Offset: 0x001F4BFC
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

		// Token: 0x04004B97 RID: 19351
		private Texture2D[] noiseTextures;

		// Token: 0x04004B98 RID: 19352
		private int textureIndex;

		// Token: 0x04004B99 RID: 19353
		private const int k_TextureCount = 64;

		// Token: 0x020006A4 RID: 1700
		private static class Uniforms
		{
			// Token: 0x0400510B RID: 20747
			internal static readonly int _DitheringTex = Shader.PropertyToID("_DitheringTex");

			// Token: 0x0400510C RID: 20748
			internal static readonly int _DitheringCoords = Shader.PropertyToID("_DitheringCoords");
		}
	}
}
