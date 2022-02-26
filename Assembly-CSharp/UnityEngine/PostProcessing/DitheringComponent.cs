using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000559 RID: 1369
	public sealed class DitheringComponent : PostProcessingComponentRenderTexture<DitheringModel>
	{
		// Token: 0x170004F3 RID: 1267
		// (get) Token: 0x060022EE RID: 8942 RVA: 0x001F27DA File Offset: 0x001F09DA
		public override bool active
		{
			get
			{
				return base.model.enabled && !this.context.interrupted;
			}
		}

		// Token: 0x060022EF RID: 8943 RVA: 0x001F27F9 File Offset: 0x001F09F9
		public override void OnDisable()
		{
			this.noiseTextures = null;
		}

		// Token: 0x060022F0 RID: 8944 RVA: 0x001F2804 File Offset: 0x001F0A04
		private void LoadNoiseTextures()
		{
			this.noiseTextures = new Texture2D[64];
			for (int i = 0; i < 64; i++)
			{
				this.noiseTextures[i] = Resources.Load<Texture2D>("Bluenoise64/LDR_LLL1_" + i.ToString());
			}
		}

		// Token: 0x060022F1 RID: 8945 RVA: 0x001F284C File Offset: 0x001F0A4C
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

		// Token: 0x04004AE9 RID: 19177
		private Texture2D[] noiseTextures;

		// Token: 0x04004AEA RID: 19178
		private int textureIndex;

		// Token: 0x04004AEB RID: 19179
		private const int k_TextureCount = 64;

		// Token: 0x0200069A RID: 1690
		private static class Uniforms
		{
			// Token: 0x0400505D RID: 20573
			internal static readonly int _DitheringTex = Shader.PropertyToID("_DitheringTex");

			// Token: 0x0400505E RID: 20574
			internal static readonly int _DitheringCoords = Shader.PropertyToID("_DitheringCoords");
		}
	}
}
