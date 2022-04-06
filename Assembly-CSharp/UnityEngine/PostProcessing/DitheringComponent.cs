using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000564 RID: 1380
	public sealed class DitheringComponent : PostProcessingComponentRenderTexture<DitheringModel>
	{
		// Token: 0x170004F4 RID: 1268
		// (get) Token: 0x06002324 RID: 8996 RVA: 0x001F6EBA File Offset: 0x001F50BA
		public override bool active
		{
			get
			{
				return base.model.enabled && !this.context.interrupted;
			}
		}

		// Token: 0x06002325 RID: 8997 RVA: 0x001F6ED9 File Offset: 0x001F50D9
		public override void OnDisable()
		{
			this.noiseTextures = null;
		}

		// Token: 0x06002326 RID: 8998 RVA: 0x001F6EE4 File Offset: 0x001F50E4
		private void LoadNoiseTextures()
		{
			this.noiseTextures = new Texture2D[64];
			for (int i = 0; i < 64; i++)
			{
				this.noiseTextures[i] = Resources.Load<Texture2D>("Bluenoise64/LDR_LLL1_" + i.ToString());
			}
		}

		// Token: 0x06002327 RID: 8999 RVA: 0x001F6F2C File Offset: 0x001F512C
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

		// Token: 0x04004B9B RID: 19355
		private Texture2D[] noiseTextures;

		// Token: 0x04004B9C RID: 19356
		private int textureIndex;

		// Token: 0x04004B9D RID: 19357
		private const int k_TextureCount = 64;

		// Token: 0x020006A5 RID: 1701
		private static class Uniforms
		{
			// Token: 0x0400510F RID: 20751
			internal static readonly int _DitheringTex = Shader.PropertyToID("_DitheringTex");

			// Token: 0x04005110 RID: 20752
			internal static readonly int _DitheringCoords = Shader.PropertyToID("_DitheringCoords");
		}
	}
}
