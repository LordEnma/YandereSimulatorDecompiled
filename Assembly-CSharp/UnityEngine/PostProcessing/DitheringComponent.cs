using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000557 RID: 1367
	public sealed class DitheringComponent : PostProcessingComponentRenderTexture<DitheringModel>
	{
		// Token: 0x170004F2 RID: 1266
		// (get) Token: 0x060022DE RID: 8926 RVA: 0x001F1746 File Offset: 0x001EF946
		public override bool active
		{
			get
			{
				return base.model.enabled && !this.context.interrupted;
			}
		}

		// Token: 0x060022DF RID: 8927 RVA: 0x001F1765 File Offset: 0x001EF965
		public override void OnDisable()
		{
			this.noiseTextures = null;
		}

		// Token: 0x060022E0 RID: 8928 RVA: 0x001F1770 File Offset: 0x001EF970
		private void LoadNoiseTextures()
		{
			this.noiseTextures = new Texture2D[64];
			for (int i = 0; i < 64; i++)
			{
				this.noiseTextures[i] = Resources.Load<Texture2D>("Bluenoise64/LDR_LLL1_" + i.ToString());
			}
		}

		// Token: 0x060022E1 RID: 8929 RVA: 0x001F17B8 File Offset: 0x001EF9B8
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

		// Token: 0x04004AD0 RID: 19152
		private Texture2D[] noiseTextures;

		// Token: 0x04004AD1 RID: 19153
		private int textureIndex;

		// Token: 0x04004AD2 RID: 19154
		private const int k_TextureCount = 64;

		// Token: 0x02000696 RID: 1686
		private static class Uniforms
		{
			// Token: 0x0400503F RID: 20543
			internal static readonly int _DitheringTex = Shader.PropertyToID("_DitheringTex");

			// Token: 0x04005040 RID: 20544
			internal static readonly int _DitheringCoords = Shader.PropertyToID("_DitheringCoords");
		}
	}
}
