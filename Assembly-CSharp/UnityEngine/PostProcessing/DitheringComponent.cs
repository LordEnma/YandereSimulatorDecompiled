using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000566 RID: 1382
	public sealed class DitheringComponent : PostProcessingComponentRenderTexture<DitheringModel>
	{
		// Token: 0x170004F6 RID: 1270
		// (get) Token: 0x06002340 RID: 9024 RVA: 0x001FAA56 File Offset: 0x001F8C56
		public override bool active
		{
			get
			{
				return base.model.enabled && !this.context.interrupted;
			}
		}

		// Token: 0x06002341 RID: 9025 RVA: 0x001FAA75 File Offset: 0x001F8C75
		public override void OnDisable()
		{
			this.noiseTextures = null;
		}

		// Token: 0x06002342 RID: 9026 RVA: 0x001FAA80 File Offset: 0x001F8C80
		private void LoadNoiseTextures()
		{
			this.noiseTextures = new Texture2D[64];
			for (int i = 0; i < 64; i++)
			{
				this.noiseTextures[i] = Resources.Load<Texture2D>("Bluenoise64/LDR_LLL1_" + i.ToString());
			}
		}

		// Token: 0x06002343 RID: 9027 RVA: 0x001FAAC8 File Offset: 0x001F8CC8
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

		// Token: 0x04004BF3 RID: 19443
		private Texture2D[] noiseTextures;

		// Token: 0x04004BF4 RID: 19444
		private int textureIndex;

		// Token: 0x04004BF5 RID: 19445
		private const int k_TextureCount = 64;

		// Token: 0x020006A7 RID: 1703
		private static class Uniforms
		{
			// Token: 0x0400516F RID: 20847
			internal static readonly int _DitheringTex = Shader.PropertyToID("_DitheringTex");

			// Token: 0x04005170 RID: 20848
			internal static readonly int _DitheringCoords = Shader.PropertyToID("_DitheringCoords");
		}
	}
}
