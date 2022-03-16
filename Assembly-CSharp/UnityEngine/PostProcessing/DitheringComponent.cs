using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200055E RID: 1374
	public sealed class DitheringComponent : PostProcessingComponentRenderTexture<DitheringModel>
	{
		// Token: 0x170004F4 RID: 1268
		// (get) Token: 0x0600230C RID: 8972 RVA: 0x001F511A File Offset: 0x001F331A
		public override bool active
		{
			get
			{
				return base.model.enabled && !this.context.interrupted;
			}
		}

		// Token: 0x0600230D RID: 8973 RVA: 0x001F5139 File Offset: 0x001F3339
		public override void OnDisable()
		{
			this.noiseTextures = null;
		}

		// Token: 0x0600230E RID: 8974 RVA: 0x001F5144 File Offset: 0x001F3344
		private void LoadNoiseTextures()
		{
			this.noiseTextures = new Texture2D[64];
			for (int i = 0; i < 64; i++)
			{
				this.noiseTextures[i] = Resources.Load<Texture2D>("Bluenoise64/LDR_LLL1_" + i.ToString());
			}
		}

		// Token: 0x0600230F RID: 8975 RVA: 0x001F518C File Offset: 0x001F338C
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

		// Token: 0x04004B65 RID: 19301
		private Texture2D[] noiseTextures;

		// Token: 0x04004B66 RID: 19302
		private int textureIndex;

		// Token: 0x04004B67 RID: 19303
		private const int k_TextureCount = 64;

		// Token: 0x0200069F RID: 1695
		private static class Uniforms
		{
			// Token: 0x040050D9 RID: 20697
			internal static readonly int _DitheringTex = Shader.PropertyToID("_DitheringTex");

			// Token: 0x040050DA RID: 20698
			internal static readonly int _DitheringCoords = Shader.PropertyToID("_DitheringCoords");
		}
	}
}
