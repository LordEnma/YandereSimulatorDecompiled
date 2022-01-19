using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000577 RID: 1399
	public class PostProcessingProfile : ScriptableObject
	{
		// Token: 0x04004B11 RID: 19217
		public BuiltinDebugViewsModel debugViews = new BuiltinDebugViewsModel();

		// Token: 0x04004B12 RID: 19218
		public FogModel fog = new FogModel();

		// Token: 0x04004B13 RID: 19219
		public AntialiasingModel antialiasing = new AntialiasingModel();

		// Token: 0x04004B14 RID: 19220
		public AmbientOcclusionModel ambientOcclusion = new AmbientOcclusionModel();

		// Token: 0x04004B15 RID: 19221
		public ScreenSpaceReflectionModel screenSpaceReflection = new ScreenSpaceReflectionModel();

		// Token: 0x04004B16 RID: 19222
		public DepthOfFieldModel depthOfField = new DepthOfFieldModel();

		// Token: 0x04004B17 RID: 19223
		public MotionBlurModel motionBlur = new MotionBlurModel();

		// Token: 0x04004B18 RID: 19224
		public EyeAdaptationModel eyeAdaptation = new EyeAdaptationModel();

		// Token: 0x04004B19 RID: 19225
		public BloomModel bloom = new BloomModel();

		// Token: 0x04004B1A RID: 19226
		public ColorGradingModel colorGrading = new ColorGradingModel();

		// Token: 0x04004B1B RID: 19227
		public UserLutModel userLut = new UserLutModel();

		// Token: 0x04004B1C RID: 19228
		public ChromaticAberrationModel chromaticAberration = new ChromaticAberrationModel();

		// Token: 0x04004B1D RID: 19229
		public GrainModel grain = new GrainModel();

		// Token: 0x04004B1E RID: 19230
		public VignetteModel vignette = new VignetteModel();

		// Token: 0x04004B1F RID: 19231
		public DitheringModel dithering = new DitheringModel();
	}
}
