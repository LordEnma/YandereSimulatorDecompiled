using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000565 RID: 1381
	public sealed class DitheringComponent : PostProcessingComponentRenderTexture<DitheringModel>
	{
		// Token: 0x170004F5 RID: 1269
		// (get) Token: 0x06002335 RID: 9013 RVA: 0x001F8E9E File Offset: 0x001F709E
		public override bool active
		{
			get
			{
				return base.model.enabled && !this.context.interrupted;
			}
		}

		// Token: 0x06002336 RID: 9014 RVA: 0x001F8EBD File Offset: 0x001F70BD
		public override void OnDisable()
		{
			this.noiseTextures = null;
		}

		// Token: 0x06002337 RID: 9015 RVA: 0x001F8EC8 File Offset: 0x001F70C8
		private void LoadNoiseTextures()
		{
			this.noiseTextures = new Texture2D[64];
			for (int i = 0; i < 64; i++)
			{
				this.noiseTextures[i] = Resources.Load<Texture2D>("Bluenoise64/LDR_LLL1_" + i.ToString());
			}
		}

		// Token: 0x06002338 RID: 9016 RVA: 0x001F8F10 File Offset: 0x001F7110
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

		// Token: 0x04004BC3 RID: 19395
		private Texture2D[] noiseTextures;

		// Token: 0x04004BC4 RID: 19396
		private int textureIndex;

		// Token: 0x04004BC5 RID: 19397
		private const int k_TextureCount = 64;

		// Token: 0x020006A6 RID: 1702
		private static class Uniforms
		{
			// Token: 0x0400513F RID: 20799
			internal static readonly int _DitheringTex = Shader.PropertyToID("_DitheringTex");

			// Token: 0x04005140 RID: 20800
			internal static readonly int _DitheringCoords = Shader.PropertyToID("_DitheringCoords");
		}
	}
}
