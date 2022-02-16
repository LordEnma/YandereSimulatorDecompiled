using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000558 RID: 1368
	public sealed class DitheringComponent : PostProcessingComponentRenderTexture<DitheringModel>
	{
		// Token: 0x170004F3 RID: 1267
		// (get) Token: 0x060022E5 RID: 8933 RVA: 0x001F1BFA File Offset: 0x001EFDFA
		public override bool active
		{
			get
			{
				return base.model.enabled && !this.context.interrupted;
			}
		}

		// Token: 0x060022E6 RID: 8934 RVA: 0x001F1C19 File Offset: 0x001EFE19
		public override void OnDisable()
		{
			this.noiseTextures = null;
		}

		// Token: 0x060022E7 RID: 8935 RVA: 0x001F1C24 File Offset: 0x001EFE24
		private void LoadNoiseTextures()
		{
			this.noiseTextures = new Texture2D[64];
			for (int i = 0; i < 64; i++)
			{
				this.noiseTextures[i] = Resources.Load<Texture2D>("Bluenoise64/LDR_LLL1_" + i.ToString());
			}
		}

		// Token: 0x060022E8 RID: 8936 RVA: 0x001F1C6C File Offset: 0x001EFE6C
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

		// Token: 0x04004AD9 RID: 19161
		private Texture2D[] noiseTextures;

		// Token: 0x04004ADA RID: 19162
		private int textureIndex;

		// Token: 0x04004ADB RID: 19163
		private const int k_TextureCount = 64;

		// Token: 0x02000697 RID: 1687
		private static class Uniforms
		{
			// Token: 0x04005048 RID: 20552
			internal static readonly int _DitheringTex = Shader.PropertyToID("_DitheringTex");

			// Token: 0x04005049 RID: 20553
			internal static readonly int _DitheringCoords = Shader.PropertyToID("_DitheringCoords");
		}
	}
}
