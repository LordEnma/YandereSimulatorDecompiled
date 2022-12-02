namespace UnityEngine.PostProcessing
{
	public sealed class ChromaticAberrationComponent : PostProcessingComponentRenderTexture<ChromaticAberrationModel>
	{
		private static class Uniforms
		{
			internal static readonly int _ChromaticAberration_Amount = Shader.PropertyToID("_ChromaticAberration_Amount");

			internal static readonly int _ChromaticAberration_Spectrum = Shader.PropertyToID("_ChromaticAberration_Spectrum");
		}

		private Texture2D m_SpectrumLut;

		public override bool active
		{
			get
			{
				if (base.model.enabled && base.model.settings.intensity > 0f)
				{
					return !context.interrupted;
				}
				return false;
			}
		}

		public override void OnDisable()
		{
			GraphicsUtils.Destroy(m_SpectrumLut);
			m_SpectrumLut = null;
		}

		public override void Prepare(Material uberMaterial)
		{
			ChromaticAberrationModel.Settings settings = base.model.settings;
			Texture2D texture2D = settings.spectralTexture;
			if (texture2D == null)
			{
				if (m_SpectrumLut == null)
				{
					m_SpectrumLut = new Texture2D(3, 1, TextureFormat.RGB24, false)
					{
						name = "Chromatic Aberration Spectrum Lookup",
						filterMode = FilterMode.Bilinear,
						wrapMode = TextureWrapMode.Clamp,
						anisoLevel = 0,
						hideFlags = HideFlags.DontSave
					};
					Color[] pixels = new Color[3]
					{
						new Color(1f, 0f, 0f),
						new Color(0f, 1f, 0f),
						new Color(0f, 0f, 1f)
					};
					m_SpectrumLut.SetPixels(pixels);
					m_SpectrumLut.Apply();
				}
				texture2D = m_SpectrumLut;
			}
			uberMaterial.EnableKeyword("CHROMATIC_ABERRATION");
			uberMaterial.SetFloat(Uniforms._ChromaticAberration_Amount, settings.intensity * 0.03f);
			uberMaterial.SetTexture(Uniforms._ChromaticAberration_Spectrum, texture2D);
		}
	}
}
