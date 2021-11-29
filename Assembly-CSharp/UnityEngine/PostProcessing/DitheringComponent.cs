using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000552 RID: 1362
	public sealed class DitheringComponent : PostProcessingComponentRenderTexture<DitheringModel>
	{
		// Token: 0x170004F0 RID: 1264
		// (get) Token: 0x060022B4 RID: 8884 RVA: 0x001ED5F6 File Offset: 0x001EB7F6
		public override bool active
		{
			get
			{
				return base.model.enabled && !this.context.interrupted;
			}
		}

		// Token: 0x060022B5 RID: 8885 RVA: 0x001ED615 File Offset: 0x001EB815
		public override void OnDisable()
		{
			this.noiseTextures = null;
		}

		// Token: 0x060022B6 RID: 8886 RVA: 0x001ED620 File Offset: 0x001EB820
		private void LoadNoiseTextures()
		{
			this.noiseTextures = new Texture2D[64];
			for (int i = 0; i < 64; i++)
			{
				this.noiseTextures[i] = Resources.Load<Texture2D>("Bluenoise64/LDR_LLL1_" + i.ToString());
			}
		}

		// Token: 0x060022B7 RID: 8887 RVA: 0x001ED668 File Offset: 0x001EB868
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

		// Token: 0x04004A59 RID: 19033
		private Texture2D[] noiseTextures;

		// Token: 0x04004A5A RID: 19034
		private int textureIndex;

		// Token: 0x04004A5B RID: 19035
		private const int k_TextureCount = 64;

		// Token: 0x02000696 RID: 1686
		private static class Uniforms
		{
			// Token: 0x04004FEA RID: 20458
			internal static readonly int _DitheringTex = Shader.PropertyToID("_DitheringTex");

			// Token: 0x04004FEB RID: 20459
			internal static readonly int _DitheringCoords = Shader.PropertyToID("_DitheringCoords");
		}
	}
}
