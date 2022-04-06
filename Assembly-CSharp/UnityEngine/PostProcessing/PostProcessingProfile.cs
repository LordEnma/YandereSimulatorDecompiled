using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000584 RID: 1412
	public class PostProcessingProfile : ScriptableObject
	{
		// Token: 0x04004BF0 RID: 19440
		public BuiltinDebugViewsModel debugViews = new BuiltinDebugViewsModel();

		// Token: 0x04004BF1 RID: 19441
		public FogModel fog = new FogModel();

		// Token: 0x04004BF2 RID: 19442
		public AntialiasingModel antialiasing = new AntialiasingModel();

		// Token: 0x04004BF3 RID: 19443
		public AmbientOcclusionModel ambientOcclusion = new AmbientOcclusionModel();

		// Token: 0x04004BF4 RID: 19444
		public ScreenSpaceReflectionModel screenSpaceReflection = new ScreenSpaceReflectionModel();

		// Token: 0x04004BF5 RID: 19445
		public DepthOfFieldModel depthOfField = new DepthOfFieldModel();

		// Token: 0x04004BF6 RID: 19446
		public MotionBlurModel motionBlur = new MotionBlurModel();

		// Token: 0x04004BF7 RID: 19447
		public EyeAdaptationModel eyeAdaptation = new EyeAdaptationModel();

		// Token: 0x04004BF8 RID: 19448
		public BloomModel bloom = new BloomModel();

		// Token: 0x04004BF9 RID: 19449
		public ColorGradingModel colorGrading = new ColorGradingModel();

		// Token: 0x04004BFA RID: 19450
		public UserLutModel userLut = new UserLutModel();

		// Token: 0x04004BFB RID: 19451
		public ChromaticAberrationModel chromaticAberration = new ChromaticAberrationModel();

		// Token: 0x04004BFC RID: 19452
		public GrainModel grain = new GrainModel();

		// Token: 0x04004BFD RID: 19453
		public VignetteModel vignette = new VignetteModel();

		// Token: 0x04004BFE RID: 19454
		public DitheringModel dithering = new DitheringModel();
	}
}
