using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000557 RID: 1367
	public sealed class DitheringComponent : PostProcessingComponentRenderTexture<DitheringModel>
	{
		// Token: 0x170004F1 RID: 1265
		// (get) Token: 0x060022DB RID: 8923 RVA: 0x001F1542 File Offset: 0x001EF742
		public override bool active
		{
			get
			{
				return base.model.enabled && !this.context.interrupted;
			}
		}

		// Token: 0x060022DC RID: 8924 RVA: 0x001F1561 File Offset: 0x001EF761
		public override void OnDisable()
		{
			this.noiseTextures = null;
		}

		// Token: 0x060022DD RID: 8925 RVA: 0x001F156C File Offset: 0x001EF76C
		private void LoadNoiseTextures()
		{
			this.noiseTextures = new Texture2D[64];
			for (int i = 0; i < 64; i++)
			{
				this.noiseTextures[i] = Resources.Load<Texture2D>("Bluenoise64/LDR_LLL1_" + i.ToString());
			}
		}

		// Token: 0x060022DE RID: 8926 RVA: 0x001F15B4 File Offset: 0x001EF7B4
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

		// Token: 0x04004ACD RID: 19149
		private Texture2D[] noiseTextures;

		// Token: 0x04004ACE RID: 19150
		private int textureIndex;

		// Token: 0x04004ACF RID: 19151
		private const int k_TextureCount = 64;

		// Token: 0x02000696 RID: 1686
		private static class Uniforms
		{
			// Token: 0x0400503C RID: 20540
			internal static readonly int _DitheringTex = Shader.PropertyToID("_DitheringTex");

			// Token: 0x0400503D RID: 20541
			internal static readonly int _DitheringCoords = Shader.PropertyToID("_DitheringCoords");
		}
	}
}
