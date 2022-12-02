namespace UnityEngine.PostProcessing
{
	public sealed class DitheringComponent : PostProcessingComponentRenderTexture<DitheringModel>
	{
		private static class Uniforms
		{
			internal static readonly int _DitheringTex = Shader.PropertyToID("_DitheringTex");

			internal static readonly int _DitheringCoords = Shader.PropertyToID("_DitheringCoords");
		}

		private Texture2D[] noiseTextures;

		private int textureIndex;

		private const int k_TextureCount = 64;

		public override bool active
		{
			get
			{
				if (base.model.enabled)
				{
					return !context.interrupted;
				}
				return false;
			}
		}

		public override void OnDisable()
		{
			noiseTextures = null;
		}

		private void LoadNoiseTextures()
		{
			noiseTextures = new Texture2D[64];
			for (int i = 0; i < 64; i++)
			{
				noiseTextures[i] = Resources.Load<Texture2D>("Bluenoise64/LDR_LLL1_" + i);
			}
		}

		public override void Prepare(Material uberMaterial)
		{
			if (++textureIndex >= 64)
			{
				textureIndex = 0;
			}
			float value = Random.value;
			float value2 = Random.value;
			if (noiseTextures == null)
			{
				LoadNoiseTextures();
			}
			Texture2D texture2D = noiseTextures[textureIndex];
			uberMaterial.EnableKeyword("DITHERING");
			uberMaterial.SetTexture(Uniforms._DitheringTex, texture2D);
			uberMaterial.SetVector(Uniforms._DitheringCoords, new Vector4((float)context.width / (float)texture2D.width, (float)context.height / (float)texture2D.height, value, value2));
		}
	}
}
