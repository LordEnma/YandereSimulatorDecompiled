using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000585 RID: 1413
	public class PostProcessingProfile : ScriptableObject
	{
		// Token: 0x04004C18 RID: 19480
		public BuiltinDebugViewsModel debugViews = new BuiltinDebugViewsModel();

		// Token: 0x04004C19 RID: 19481
		public FogModel fog = new FogModel();

		// Token: 0x04004C1A RID: 19482
		public AntialiasingModel antialiasing = new AntialiasingModel();

		// Token: 0x04004C1B RID: 19483
		public AmbientOcclusionModel ambientOcclusion = new AmbientOcclusionModel();

		// Token: 0x04004C1C RID: 19484
		public ScreenSpaceReflectionModel screenSpaceReflection = new ScreenSpaceReflectionModel();

		// Token: 0x04004C1D RID: 19485
		public DepthOfFieldModel depthOfField = new DepthOfFieldModel();

		// Token: 0x04004C1E RID: 19486
		public MotionBlurModel motionBlur = new MotionBlurModel();

		// Token: 0x04004C1F RID: 19487
		public EyeAdaptationModel eyeAdaptation = new EyeAdaptationModel();

		// Token: 0x04004C20 RID: 19488
		public BloomModel bloom = new BloomModel();

		// Token: 0x04004C21 RID: 19489
		public ColorGradingModel colorGrading = new ColorGradingModel();

		// Token: 0x04004C22 RID: 19490
		public UserLutModel userLut = new UserLutModel();

		// Token: 0x04004C23 RID: 19491
		public ChromaticAberrationModel chromaticAberration = new ChromaticAberrationModel();

		// Token: 0x04004C24 RID: 19492
		public GrainModel grain = new GrainModel();

		// Token: 0x04004C25 RID: 19493
		public VignetteModel vignette = new VignetteModel();

		// Token: 0x04004C26 RID: 19494
		public DitheringModel dithering = new DitheringModel();
	}
}
