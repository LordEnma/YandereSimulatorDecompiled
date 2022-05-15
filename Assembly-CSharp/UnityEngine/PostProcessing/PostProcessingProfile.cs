using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000586 RID: 1414
	public class PostProcessingProfile : ScriptableObject
	{
		// Token: 0x04004C3F RID: 19519
		public BuiltinDebugViewsModel debugViews = new BuiltinDebugViewsModel();

		// Token: 0x04004C40 RID: 19520
		public FogModel fog = new FogModel();

		// Token: 0x04004C41 RID: 19521
		public AntialiasingModel antialiasing = new AntialiasingModel();

		// Token: 0x04004C42 RID: 19522
		public AmbientOcclusionModel ambientOcclusion = new AmbientOcclusionModel();

		// Token: 0x04004C43 RID: 19523
		public ScreenSpaceReflectionModel screenSpaceReflection = new ScreenSpaceReflectionModel();

		// Token: 0x04004C44 RID: 19524
		public DepthOfFieldModel depthOfField = new DepthOfFieldModel();

		// Token: 0x04004C45 RID: 19525
		public MotionBlurModel motionBlur = new MotionBlurModel();

		// Token: 0x04004C46 RID: 19526
		public EyeAdaptationModel eyeAdaptation = new EyeAdaptationModel();

		// Token: 0x04004C47 RID: 19527
		public BloomModel bloom = new BloomModel();

		// Token: 0x04004C48 RID: 19528
		public ColorGradingModel colorGrading = new ColorGradingModel();

		// Token: 0x04004C49 RID: 19529
		public UserLutModel userLut = new UserLutModel();

		// Token: 0x04004C4A RID: 19530
		public ChromaticAberrationModel chromaticAberration = new ChromaticAberrationModel();

		// Token: 0x04004C4B RID: 19531
		public GrainModel grain = new GrainModel();

		// Token: 0x04004C4C RID: 19532
		public VignetteModel vignette = new VignetteModel();

		// Token: 0x04004C4D RID: 19533
		public DitheringModel dithering = new DitheringModel();
	}
}
