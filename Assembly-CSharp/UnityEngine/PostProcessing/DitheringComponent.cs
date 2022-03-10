using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200055A RID: 1370
	public sealed class DitheringComponent : PostProcessingComponentRenderTexture<DitheringModel>
	{
		// Token: 0x170004F3 RID: 1267
		// (get) Token: 0x060022F4 RID: 8948 RVA: 0x001F31B2 File Offset: 0x001F13B2
		public override bool active
		{
			get
			{
				return base.model.enabled && !this.context.interrupted;
			}
		}

		// Token: 0x060022F5 RID: 8949 RVA: 0x001F31D1 File Offset: 0x001F13D1
		public override void OnDisable()
		{
			this.noiseTextures = null;
		}

		// Token: 0x060022F6 RID: 8950 RVA: 0x001F31DC File Offset: 0x001F13DC
		private void LoadNoiseTextures()
		{
			this.noiseTextures = new Texture2D[64];
			for (int i = 0; i < 64; i++)
			{
				this.noiseTextures[i] = Resources.Load<Texture2D>("Bluenoise64/LDR_LLL1_" + i.ToString());
			}
		}

		// Token: 0x060022F7 RID: 8951 RVA: 0x001F3224 File Offset: 0x001F1424
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

		// Token: 0x04004B06 RID: 19206
		private Texture2D[] noiseTextures;

		// Token: 0x04004B07 RID: 19207
		private int textureIndex;

		// Token: 0x04004B08 RID: 19208
		private const int k_TextureCount = 64;

		// Token: 0x0200069B RID: 1691
		private static class Uniforms
		{
			// Token: 0x0400507A RID: 20602
			internal static readonly int _DitheringTex = Shader.PropertyToID("_DitheringTex");

			// Token: 0x0400507B RID: 20603
			internal static readonly int _DitheringCoords = Shader.PropertyToID("_DitheringCoords");
		}
	}
}
