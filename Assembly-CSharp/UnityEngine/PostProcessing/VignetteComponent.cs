using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200055D RID: 1373
	public sealed class VignetteComponent : PostProcessingComponentRenderTexture<VignetteModel>
	{
		// Token: 0x170004FD RID: 1277
		// (get) Token: 0x06002305 RID: 8965 RVA: 0x001F110E File Offset: 0x001EF30E
		public override bool active
		{
			get
			{
				return base.model.enabled && !this.context.interrupted;
			}
		}

		// Token: 0x06002306 RID: 8966 RVA: 0x001F1130 File Offset: 0x001EF330
		public override void Prepare(Material uberMaterial)
		{
			VignetteModel.Settings settings = base.model.settings;
			uberMaterial.SetColor(VignetteComponent.Uniforms._Vignette_Color, settings.color);
			if (settings.mode == VignetteModel.Mode.Classic)
			{
				uberMaterial.SetVector(VignetteComponent.Uniforms._Vignette_Center, settings.center);
				uberMaterial.EnableKeyword("VIGNETTE_CLASSIC");
				float z = (1f - settings.roundness) * 6f + settings.roundness;
				uberMaterial.SetVector(VignetteComponent.Uniforms._Vignette_Settings, new Vector4(settings.intensity * 3f, settings.smoothness * 5f, z, settings.rounded ? 1f : 0f));
				return;
			}
			if (settings.mode == VignetteModel.Mode.Masked && settings.mask != null && settings.opacity > 0f)
			{
				uberMaterial.EnableKeyword("VIGNETTE_MASKED");
				uberMaterial.SetTexture(VignetteComponent.Uniforms._Vignette_Mask, settings.mask);
				uberMaterial.SetFloat(VignetteComponent.Uniforms._Vignette_Opacity, settings.opacity);
			}
		}

		// Token: 0x020006A6 RID: 1702
		private static class Uniforms
		{
			// Token: 0x040050AF RID: 20655
			internal static readonly int _Vignette_Color = Shader.PropertyToID("_Vignette_Color");

			// Token: 0x040050B0 RID: 20656
			internal static readonly int _Vignette_Center = Shader.PropertyToID("_Vignette_Center");

			// Token: 0x040050B1 RID: 20657
			internal static readonly int _Vignette_Settings = Shader.PropertyToID("_Vignette_Settings");

			// Token: 0x040050B2 RID: 20658
			internal static readonly int _Vignette_Mask = Shader.PropertyToID("_Vignette_Mask");

			// Token: 0x040050B3 RID: 20659
			internal static readonly int _Vignette_Opacity = Shader.PropertyToID("_Vignette_Opacity");
		}
	}
}
