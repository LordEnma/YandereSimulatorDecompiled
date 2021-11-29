using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000555 RID: 1365
	public sealed class FxaaComponent : PostProcessingComponentRenderTexture<AntialiasingModel>
	{
		// Token: 0x170004F3 RID: 1267
		// (get) Token: 0x060022C7 RID: 8903 RVA: 0x001EDE0E File Offset: 0x001EC00E
		public override bool active
		{
			get
			{
				return base.model.enabled && base.model.settings.method == AntialiasingModel.Method.Fxaa && !this.context.interrupted;
			}
		}

		// Token: 0x060022C8 RID: 8904 RVA: 0x001EDE40 File Offset: 0x001EC040
		public void Render(RenderTexture source, RenderTexture destination)
		{
			AntialiasingModel.FxaaSettings fxaaSettings = base.model.settings.fxaaSettings;
			Material material = this.context.materialFactory.Get("Hidden/Post FX/FXAA");
			AntialiasingModel.FxaaQualitySettings fxaaQualitySettings = AntialiasingModel.FxaaQualitySettings.presets[(int)fxaaSettings.preset];
			AntialiasingModel.FxaaConsoleSettings fxaaConsoleSettings = AntialiasingModel.FxaaConsoleSettings.presets[(int)fxaaSettings.preset];
			material.SetVector(FxaaComponent.Uniforms._QualitySettings, new Vector3(fxaaQualitySettings.subpixelAliasingRemovalAmount, fxaaQualitySettings.edgeDetectionThreshold, fxaaQualitySettings.minimumRequiredLuminance));
			material.SetVector(FxaaComponent.Uniforms._ConsoleSettings, new Vector4(fxaaConsoleSettings.subpixelSpreadAmount, fxaaConsoleSettings.edgeSharpnessAmount, fxaaConsoleSettings.edgeDetectionThreshold, fxaaConsoleSettings.minimumRequiredLuminance));
			Graphics.Blit(source, destination, material, 0);
		}

		// Token: 0x02000699 RID: 1689
		private static class Uniforms
		{
			// Token: 0x04004FF7 RID: 20471
			internal static readonly int _QualitySettings = Shader.PropertyToID("_QualitySettings");

			// Token: 0x04004FF8 RID: 20472
			internal static readonly int _ConsoleSettings = Shader.PropertyToID("_ConsoleSettings");
		}
	}
}
