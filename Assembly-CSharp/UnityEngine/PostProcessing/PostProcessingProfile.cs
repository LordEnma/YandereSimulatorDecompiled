using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200057A RID: 1402
	public class PostProcessingProfile : ScriptableObject
	{
		// Token: 0x04004B5B RID: 19291
		public BuiltinDebugViewsModel debugViews = new BuiltinDebugViewsModel();

		// Token: 0x04004B5C RID: 19292
		public FogModel fog = new FogModel();

		// Token: 0x04004B5D RID: 19293
		public AntialiasingModel antialiasing = new AntialiasingModel();

		// Token: 0x04004B5E RID: 19294
		public AmbientOcclusionModel ambientOcclusion = new AmbientOcclusionModel();

		// Token: 0x04004B5F RID: 19295
		public ScreenSpaceReflectionModel screenSpaceReflection = new ScreenSpaceReflectionModel();

		// Token: 0x04004B60 RID: 19296
		public DepthOfFieldModel depthOfField = new DepthOfFieldModel();

		// Token: 0x04004B61 RID: 19297
		public MotionBlurModel motionBlur = new MotionBlurModel();

		// Token: 0x04004B62 RID: 19298
		public EyeAdaptationModel eyeAdaptation = new EyeAdaptationModel();

		// Token: 0x04004B63 RID: 19299
		public BloomModel bloom = new BloomModel();

		// Token: 0x04004B64 RID: 19300
		public ColorGradingModel colorGrading = new ColorGradingModel();

		// Token: 0x04004B65 RID: 19301
		public UserLutModel userLut = new UserLutModel();

		// Token: 0x04004B66 RID: 19302
		public ChromaticAberrationModel chromaticAberration = new ChromaticAberrationModel();

		// Token: 0x04004B67 RID: 19303
		public GrainModel grain = new GrainModel();

		// Token: 0x04004B68 RID: 19304
		public VignetteModel vignette = new VignetteModel();

		// Token: 0x04004B69 RID: 19305
		public DitheringModel dithering = new DitheringModel();
	}
}
