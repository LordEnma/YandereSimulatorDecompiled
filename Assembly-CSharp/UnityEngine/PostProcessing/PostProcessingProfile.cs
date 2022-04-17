using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000584 RID: 1412
	public class PostProcessingProfile : ScriptableObject
	{
		// Token: 0x04004C02 RID: 19458
		public BuiltinDebugViewsModel debugViews = new BuiltinDebugViewsModel();

		// Token: 0x04004C03 RID: 19459
		public FogModel fog = new FogModel();

		// Token: 0x04004C04 RID: 19460
		public AntialiasingModel antialiasing = new AntialiasingModel();

		// Token: 0x04004C05 RID: 19461
		public AmbientOcclusionModel ambientOcclusion = new AmbientOcclusionModel();

		// Token: 0x04004C06 RID: 19462
		public ScreenSpaceReflectionModel screenSpaceReflection = new ScreenSpaceReflectionModel();

		// Token: 0x04004C07 RID: 19463
		public DepthOfFieldModel depthOfField = new DepthOfFieldModel();

		// Token: 0x04004C08 RID: 19464
		public MotionBlurModel motionBlur = new MotionBlurModel();

		// Token: 0x04004C09 RID: 19465
		public EyeAdaptationModel eyeAdaptation = new EyeAdaptationModel();

		// Token: 0x04004C0A RID: 19466
		public BloomModel bloom = new BloomModel();

		// Token: 0x04004C0B RID: 19467
		public ColorGradingModel colorGrading = new ColorGradingModel();

		// Token: 0x04004C0C RID: 19468
		public UserLutModel userLut = new UserLutModel();

		// Token: 0x04004C0D RID: 19469
		public ChromaticAberrationModel chromaticAberration = new ChromaticAberrationModel();

		// Token: 0x04004C0E RID: 19470
		public GrainModel grain = new GrainModel();

		// Token: 0x04004C0F RID: 19471
		public VignetteModel vignette = new VignetteModel();

		// Token: 0x04004C10 RID: 19472
		public DitheringModel dithering = new DitheringModel();
	}
}
