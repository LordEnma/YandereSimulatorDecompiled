using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200055B RID: 1371
	public sealed class VignetteComponent : PostProcessingComponentRenderTexture<VignetteModel>
	{
		// Token: 0x170004FC RID: 1276
		// (get) Token: 0x060022F1 RID: 8945 RVA: 0x001EF3EA File Offset: 0x001ED5EA
		public override bool active
		{
			get
			{
				return base.model.enabled && !this.context.interrupted;
			}
		}

		// Token: 0x060022F2 RID: 8946 RVA: 0x001EF40C File Offset: 0x001ED60C
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

		// Token: 0x020006A3 RID: 1699
		private static class Uniforms
		{
			// Token: 0x0400505B RID: 20571
			internal static readonly int _Vignette_Color = Shader.PropertyToID("_Vignette_Color");

			// Token: 0x0400505C RID: 20572
			internal static readonly int _Vignette_Center = Shader.PropertyToID("_Vignette_Center");

			// Token: 0x0400505D RID: 20573
			internal static readonly int _Vignette_Settings = Shader.PropertyToID("_Vignette_Settings");

			// Token: 0x0400505E RID: 20574
			internal static readonly int _Vignette_Mask = Shader.PropertyToID("_Vignette_Mask");

			// Token: 0x0400505F RID: 20575
			internal static readonly int _Vignette_Opacity = Shader.PropertyToID("_Vignette_Opacity");
		}
	}
}
