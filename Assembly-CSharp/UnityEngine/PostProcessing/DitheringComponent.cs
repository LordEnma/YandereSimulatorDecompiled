using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000554 RID: 1364
	public sealed class DitheringComponent : PostProcessingComponentRenderTexture<DitheringModel>
	{
		// Token: 0x170004F0 RID: 1264
		// (get) Token: 0x060022C5 RID: 8901 RVA: 0x001EED2A File Offset: 0x001ECF2A
		public override bool active
		{
			get
			{
				return base.model.enabled && !this.context.interrupted;
			}
		}

		// Token: 0x060022C6 RID: 8902 RVA: 0x001EED49 File Offset: 0x001ECF49
		public override void OnDisable()
		{
			this.noiseTextures = null;
		}

		// Token: 0x060022C7 RID: 8903 RVA: 0x001EED54 File Offset: 0x001ECF54
		private void LoadNoiseTextures()
		{
			this.noiseTextures = new Texture2D[64];
			for (int i = 0; i < 64; i++)
			{
				this.noiseTextures[i] = Resources.Load<Texture2D>("Bluenoise64/LDR_LLL1_" + i.ToString());
			}
		}

		// Token: 0x060022C8 RID: 8904 RVA: 0x001EED9C File Offset: 0x001ECF9C
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

		// Token: 0x04004A98 RID: 19096
		private Texture2D[] noiseTextures;

		// Token: 0x04004A99 RID: 19097
		private int textureIndex;

		// Token: 0x04004A9A RID: 19098
		private const int k_TextureCount = 64;

		// Token: 0x02000699 RID: 1689
		private static class Uniforms
		{
			// Token: 0x04005035 RID: 20533
			internal static readonly int _DitheringTex = Shader.PropertyToID("_DitheringTex");

			// Token: 0x04005036 RID: 20534
			internal static readonly int _DitheringCoords = Shader.PropertyToID("_DitheringCoords");
		}
	}
}
