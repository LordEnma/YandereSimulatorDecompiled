using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000578 RID: 1400
	public class PostProcessingProfile : ScriptableObject
	{
		// Token: 0x04004B2E RID: 19246
		public BuiltinDebugViewsModel debugViews = new BuiltinDebugViewsModel();

		// Token: 0x04004B2F RID: 19247
		public FogModel fog = new FogModel();

		// Token: 0x04004B30 RID: 19248
		public AntialiasingModel antialiasing = new AntialiasingModel();

		// Token: 0x04004B31 RID: 19249
		public AmbientOcclusionModel ambientOcclusion = new AmbientOcclusionModel();

		// Token: 0x04004B32 RID: 19250
		public ScreenSpaceReflectionModel screenSpaceReflection = new ScreenSpaceReflectionModel();

		// Token: 0x04004B33 RID: 19251
		public DepthOfFieldModel depthOfField = new DepthOfFieldModel();

		// Token: 0x04004B34 RID: 19252
		public MotionBlurModel motionBlur = new MotionBlurModel();

		// Token: 0x04004B35 RID: 19253
		public EyeAdaptationModel eyeAdaptation = new EyeAdaptationModel();

		// Token: 0x04004B36 RID: 19254
		public BloomModel bloom = new BloomModel();

		// Token: 0x04004B37 RID: 19255
		public ColorGradingModel colorGrading = new ColorGradingModel();

		// Token: 0x04004B38 RID: 19256
		public UserLutModel userLut = new UserLutModel();

		// Token: 0x04004B39 RID: 19257
		public ChromaticAberrationModel chromaticAberration = new ChromaticAberrationModel();

		// Token: 0x04004B3A RID: 19258
		public GrainModel grain = new GrainModel();

		// Token: 0x04004B3B RID: 19259
		public VignetteModel vignette = new VignetteModel();

		// Token: 0x04004B3C RID: 19260
		public DitheringModel dithering = new DitheringModel();
	}
}
