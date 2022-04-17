using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000564 RID: 1380
	public sealed class DitheringComponent : PostProcessingComponentRenderTexture<DitheringModel>
	{
		// Token: 0x170004F5 RID: 1269
		// (get) Token: 0x0600232B RID: 9003 RVA: 0x001F7916 File Offset: 0x001F5B16
		public override bool active
		{
			get
			{
				return base.model.enabled && !this.context.interrupted;
			}
		}

		// Token: 0x0600232C RID: 9004 RVA: 0x001F7935 File Offset: 0x001F5B35
		public override void OnDisable()
		{
			this.noiseTextures = null;
		}

		// Token: 0x0600232D RID: 9005 RVA: 0x001F7940 File Offset: 0x001F5B40
		private void LoadNoiseTextures()
		{
			this.noiseTextures = new Texture2D[64];
			for (int i = 0; i < 64; i++)
			{
				this.noiseTextures[i] = Resources.Load<Texture2D>("Bluenoise64/LDR_LLL1_" + i.ToString());
			}
		}

		// Token: 0x0600232E RID: 9006 RVA: 0x001F7988 File Offset: 0x001F5B88
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

		// Token: 0x04004BAD RID: 19373
		private Texture2D[] noiseTextures;

		// Token: 0x04004BAE RID: 19374
		private int textureIndex;

		// Token: 0x04004BAF RID: 19375
		private const int k_TextureCount = 64;

		// Token: 0x020006A5 RID: 1701
		private static class Uniforms
		{
			// Token: 0x04005121 RID: 20769
			internal static readonly int _DitheringTex = Shader.PropertyToID("_DitheringTex");

			// Token: 0x04005122 RID: 20770
			internal static readonly int _DitheringCoords = Shader.PropertyToID("_DitheringCoords");
		}
	}
}
