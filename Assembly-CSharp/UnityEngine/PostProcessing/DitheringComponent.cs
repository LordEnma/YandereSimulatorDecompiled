using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000557 RID: 1367
	public sealed class DitheringComponent : PostProcessingComponentRenderTexture<DitheringModel>
	{
		// Token: 0x170004F1 RID: 1265
		// (get) Token: 0x060022D9 RID: 8921 RVA: 0x001F122A File Offset: 0x001EF42A
		public override bool active
		{
			get
			{
				return base.model.enabled && !this.context.interrupted;
			}
		}

		// Token: 0x060022DA RID: 8922 RVA: 0x001F1249 File Offset: 0x001EF449
		public override void OnDisable()
		{
			this.noiseTextures = null;
		}

		// Token: 0x060022DB RID: 8923 RVA: 0x001F1254 File Offset: 0x001EF454
		private void LoadNoiseTextures()
		{
			this.noiseTextures = new Texture2D[64];
			for (int i = 0; i < 64; i++)
			{
				this.noiseTextures[i] = Resources.Load<Texture2D>("Bluenoise64/LDR_LLL1_" + i.ToString());
			}
		}

		// Token: 0x060022DC RID: 8924 RVA: 0x001F129C File Offset: 0x001EF49C
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

		// Token: 0x04004AC7 RID: 19143
		private Texture2D[] noiseTextures;

		// Token: 0x04004AC8 RID: 19144
		private int textureIndex;

		// Token: 0x04004AC9 RID: 19145
		private const int k_TextureCount = 64;

		// Token: 0x02000696 RID: 1686
		private static class Uniforms
		{
			// Token: 0x04005036 RID: 20534
			internal static readonly int _DitheringTex = Shader.PropertyToID("_DitheringTex");

			// Token: 0x04005037 RID: 20535
			internal static readonly int _DitheringCoords = Shader.PropertyToID("_DitheringCoords");
		}
	}
}
