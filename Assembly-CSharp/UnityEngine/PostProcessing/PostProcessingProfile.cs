using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200057E RID: 1406
	public class PostProcessingProfile : ScriptableObject
	{
		// Token: 0x04004BBA RID: 19386
		public BuiltinDebugViewsModel debugViews = new BuiltinDebugViewsModel();

		// Token: 0x04004BBB RID: 19387
		public FogModel fog = new FogModel();

		// Token: 0x04004BBC RID: 19388
		public AntialiasingModel antialiasing = new AntialiasingModel();

		// Token: 0x04004BBD RID: 19389
		public AmbientOcclusionModel ambientOcclusion = new AmbientOcclusionModel();

		// Token: 0x04004BBE RID: 19390
		public ScreenSpaceReflectionModel screenSpaceReflection = new ScreenSpaceReflectionModel();

		// Token: 0x04004BBF RID: 19391
		public DepthOfFieldModel depthOfField = new DepthOfFieldModel();

		// Token: 0x04004BC0 RID: 19392
		public MotionBlurModel motionBlur = new MotionBlurModel();

		// Token: 0x04004BC1 RID: 19393
		public EyeAdaptationModel eyeAdaptation = new EyeAdaptationModel();

		// Token: 0x04004BC2 RID: 19394
		public BloomModel bloom = new BloomModel();

		// Token: 0x04004BC3 RID: 19395
		public ColorGradingModel colorGrading = new ColorGradingModel();

		// Token: 0x04004BC4 RID: 19396
		public UserLutModel userLut = new UserLutModel();

		// Token: 0x04004BC5 RID: 19397
		public ChromaticAberrationModel chromaticAberration = new ChromaticAberrationModel();

		// Token: 0x04004BC6 RID: 19398
		public GrainModel grain = new GrainModel();

		// Token: 0x04004BC7 RID: 19399
		public VignetteModel vignette = new VignetteModel();

		// Token: 0x04004BC8 RID: 19400
		public DitheringModel dithering = new DitheringModel();
	}
}
