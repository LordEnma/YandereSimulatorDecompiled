using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000577 RID: 1399
	public class PostProcessingProfile : ScriptableObject
	{
		// Token: 0x04004B25 RID: 19237
		public BuiltinDebugViewsModel debugViews = new BuiltinDebugViewsModel();

		// Token: 0x04004B26 RID: 19238
		public FogModel fog = new FogModel();

		// Token: 0x04004B27 RID: 19239
		public AntialiasingModel antialiasing = new AntialiasingModel();

		// Token: 0x04004B28 RID: 19240
		public AmbientOcclusionModel ambientOcclusion = new AmbientOcclusionModel();

		// Token: 0x04004B29 RID: 19241
		public ScreenSpaceReflectionModel screenSpaceReflection = new ScreenSpaceReflectionModel();

		// Token: 0x04004B2A RID: 19242
		public DepthOfFieldModel depthOfField = new DepthOfFieldModel();

		// Token: 0x04004B2B RID: 19243
		public MotionBlurModel motionBlur = new MotionBlurModel();

		// Token: 0x04004B2C RID: 19244
		public EyeAdaptationModel eyeAdaptation = new EyeAdaptationModel();

		// Token: 0x04004B2D RID: 19245
		public BloomModel bloom = new BloomModel();

		// Token: 0x04004B2E RID: 19246
		public ColorGradingModel colorGrading = new ColorGradingModel();

		// Token: 0x04004B2F RID: 19247
		public UserLutModel userLut = new UserLutModel();

		// Token: 0x04004B30 RID: 19248
		public ChromaticAberrationModel chromaticAberration = new ChromaticAberrationModel();

		// Token: 0x04004B31 RID: 19249
		public GrainModel grain = new GrainModel();

		// Token: 0x04004B32 RID: 19250
		public VignetteModel vignette = new VignetteModel();

		// Token: 0x04004B33 RID: 19251
		public DitheringModel dithering = new DitheringModel();
	}
}
