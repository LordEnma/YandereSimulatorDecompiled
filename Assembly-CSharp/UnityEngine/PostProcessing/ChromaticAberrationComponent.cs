using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200054F RID: 1359
	public sealed class ChromaticAberrationComponent : PostProcessingComponentRenderTexture<ChromaticAberrationModel>
	{
		// Token: 0x170004ED RID: 1261
		// (get) Token: 0x06002290 RID: 8848 RVA: 0x001EC294 File Offset: 0x001EA494
		public override bool active
		{
			get
			{
				return base.model.enabled && base.model.settings.intensity > 0f && !this.context.interrupted;
			}
		}

		// Token: 0x06002291 RID: 8849 RVA: 0x001EC2CA File Offset: 0x001EA4CA
		public override void OnDisable()
		{
			GraphicsUtils.Destroy(this.m_SpectrumLut);
			this.m_SpectrumLut = null;
		}

		// Token: 0x06002292 RID: 8850 RVA: 0x001EC2E0 File Offset: 0x001EA4E0
		public override void Prepare(Material uberMaterial)
		{
			ChromaticAberrationModel.Settings settings = base.model.settings;
			Texture2D texture2D = settings.spectralTexture;
			if (texture2D == null)
			{
				if (this.m_SpectrumLut == null)
				{
					this.m_SpectrumLut = new Texture2D(3, 1, TextureFormat.RGB24, false)
					{
						name = "Chromatic Aberration Spectrum Lookup",
						filterMode = FilterMode.Bilinear,
						wrapMode = TextureWrapMode.Clamp,
						anisoLevel = 0,
						hideFlags = HideFlags.DontSave
					};
					Color[] pixels = new Color[]
					{
						new Color(1f, 0f, 0f),
						new Color(0f, 1f, 0f),
						new Color(0f, 0f, 1f)
					};
					this.m_SpectrumLut.SetPixels(pixels);
					this.m_SpectrumLut.Apply();
				}
				texture2D = this.m_SpectrumLut;
			}
			uberMaterial.EnableKeyword("CHROMATIC_ABERRATION");
			uberMaterial.SetFloat(ChromaticAberrationComponent.Uniforms._ChromaticAberration_Amount, settings.intensity * 0.03f);
			uberMaterial.SetTexture(ChromaticAberrationComponent.Uniforms._ChromaticAberration_Spectrum, texture2D);
		}

		// Token: 0x04004A50 RID: 19024
		private Texture2D m_SpectrumLut;

		// Token: 0x02000693 RID: 1683
		private static class Uniforms
		{
			// Token: 0x04004FC9 RID: 20425
			internal static readonly int _ChromaticAberration_Amount = Shader.PropertyToID("_ChromaticAberration_Amount");

			// Token: 0x04004FCA RID: 20426
			internal static readonly int _ChromaticAberration_Spectrum = Shader.PropertyToID("_ChromaticAberration_Spectrum");
		}
	}
}
