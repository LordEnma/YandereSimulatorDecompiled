using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000554 RID: 1364
	public sealed class DitheringComponent : PostProcessingComponentRenderTexture<DitheringModel>
	{
		// Token: 0x170004F1 RID: 1265
		// (get) Token: 0x060022C8 RID: 8904 RVA: 0x001EF31A File Offset: 0x001ED51A
		public override bool active
		{
			get
			{
				return base.model.enabled && !this.context.interrupted;
			}
		}

		// Token: 0x060022C9 RID: 8905 RVA: 0x001EF339 File Offset: 0x001ED539
		public override void OnDisable()
		{
			this.noiseTextures = null;
		}

		// Token: 0x060022CA RID: 8906 RVA: 0x001EF344 File Offset: 0x001ED544
		private void LoadNoiseTextures()
		{
			this.noiseTextures = new Texture2D[64];
			for (int i = 0; i < 64; i++)
			{
				this.noiseTextures[i] = Resources.Load<Texture2D>("Bluenoise64/LDR_LLL1_" + i.ToString());
			}
		}

		// Token: 0x060022CB RID: 8907 RVA: 0x001EF38C File Offset: 0x001ED58C
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

		// Token: 0x04004AA1 RID: 19105
		private Texture2D[] noiseTextures;

		// Token: 0x04004AA2 RID: 19106
		private int textureIndex;

		// Token: 0x04004AA3 RID: 19107
		private const int k_TextureCount = 64;

		// Token: 0x02000699 RID: 1689
		private static class Uniforms
		{
			// Token: 0x0400503E RID: 20542
			internal static readonly int _DitheringTex = Shader.PropertyToID("_DitheringTex");

			// Token: 0x0400503F RID: 20543
			internal static readonly int _DitheringCoords = Shader.PropertyToID("_DitheringCoords");
		}
	}
}
