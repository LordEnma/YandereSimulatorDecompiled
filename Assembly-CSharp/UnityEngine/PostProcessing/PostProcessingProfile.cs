using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000576 RID: 1398
	public class PostProcessingProfile : ScriptableObject
	{
		// Token: 0x04004B0A RID: 19210
		public BuiltinDebugViewsModel debugViews = new BuiltinDebugViewsModel();

		// Token: 0x04004B0B RID: 19211
		public FogModel fog = new FogModel();

		// Token: 0x04004B0C RID: 19212
		public AntialiasingModel antialiasing = new AntialiasingModel();

		// Token: 0x04004B0D RID: 19213
		public AmbientOcclusionModel ambientOcclusion = new AmbientOcclusionModel();

		// Token: 0x04004B0E RID: 19214
		public ScreenSpaceReflectionModel screenSpaceReflection = new ScreenSpaceReflectionModel();

		// Token: 0x04004B0F RID: 19215
		public DepthOfFieldModel depthOfField = new DepthOfFieldModel();

		// Token: 0x04004B10 RID: 19216
		public MotionBlurModel motionBlur = new MotionBlurModel();

		// Token: 0x04004B11 RID: 19217
		public EyeAdaptationModel eyeAdaptation = new EyeAdaptationModel();

		// Token: 0x04004B12 RID: 19218
		public BloomModel bloom = new BloomModel();

		// Token: 0x04004B13 RID: 19219
		public ColorGradingModel colorGrading = new ColorGradingModel();

		// Token: 0x04004B14 RID: 19220
		public UserLutModel userLut = new UserLutModel();

		// Token: 0x04004B15 RID: 19221
		public ChromaticAberrationModel chromaticAberration = new ChromaticAberrationModel();

		// Token: 0x04004B16 RID: 19222
		public GrainModel grain = new GrainModel();

		// Token: 0x04004B17 RID: 19223
		public VignetteModel vignette = new VignetteModel();

		// Token: 0x04004B18 RID: 19224
		public DitheringModel dithering = new DitheringModel();
	}
}
