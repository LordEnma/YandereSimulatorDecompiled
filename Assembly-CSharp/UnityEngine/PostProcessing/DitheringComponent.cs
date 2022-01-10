using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000556 RID: 1366
	public sealed class DitheringComponent : PostProcessingComponentRenderTexture<DitheringModel>
	{
		// Token: 0x170004F1 RID: 1265
		// (get) Token: 0x060022D3 RID: 8915 RVA: 0x001EFCBA File Offset: 0x001EDEBA
		public override bool active
		{
			get
			{
				return base.model.enabled && !this.context.interrupted;
			}
		}

		// Token: 0x060022D4 RID: 8916 RVA: 0x001EFCD9 File Offset: 0x001EDED9
		public override void OnDisable()
		{
			this.noiseTextures = null;
		}

		// Token: 0x060022D5 RID: 8917 RVA: 0x001EFCE4 File Offset: 0x001EDEE4
		private void LoadNoiseTextures()
		{
			this.noiseTextures = new Texture2D[64];
			for (int i = 0; i < 64; i++)
			{
				this.noiseTextures[i] = Resources.Load<Texture2D>("Bluenoise64/LDR_LLL1_" + i.ToString());
			}
		}

		// Token: 0x060022D6 RID: 8918 RVA: 0x001EFD2C File Offset: 0x001EDF2C
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

		// Token: 0x04004AB5 RID: 19125
		private Texture2D[] noiseTextures;

		// Token: 0x04004AB6 RID: 19126
		private int textureIndex;

		// Token: 0x04004AB7 RID: 19127
		private const int k_TextureCount = 64;

		// Token: 0x0200069B RID: 1691
		private static class Uniforms
		{
			// Token: 0x04005052 RID: 20562
			internal static readonly int _DitheringTex = Shader.PropertyToID("_DitheringTex");

			// Token: 0x04005053 RID: 20563
			internal static readonly int _DitheringCoords = Shader.PropertyToID("_DitheringCoords");
		}
	}
}
