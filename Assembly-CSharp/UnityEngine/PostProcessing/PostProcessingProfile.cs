using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000586 RID: 1414
	public class PostProcessingProfile : ScriptableObject
	{
		// Token: 0x04004C48 RID: 19528
		public BuiltinDebugViewsModel debugViews = new BuiltinDebugViewsModel();

		// Token: 0x04004C49 RID: 19529
		public FogModel fog = new FogModel();

		// Token: 0x04004C4A RID: 19530
		public AntialiasingModel antialiasing = new AntialiasingModel();

		// Token: 0x04004C4B RID: 19531
		public AmbientOcclusionModel ambientOcclusion = new AmbientOcclusionModel();

		// Token: 0x04004C4C RID: 19532
		public ScreenSpaceReflectionModel screenSpaceReflection = new ScreenSpaceReflectionModel();

		// Token: 0x04004C4D RID: 19533
		public DepthOfFieldModel depthOfField = new DepthOfFieldModel();

		// Token: 0x04004C4E RID: 19534
		public MotionBlurModel motionBlur = new MotionBlurModel();

		// Token: 0x04004C4F RID: 19535
		public EyeAdaptationModel eyeAdaptation = new EyeAdaptationModel();

		// Token: 0x04004C50 RID: 19536
		public BloomModel bloom = new BloomModel();

		// Token: 0x04004C51 RID: 19537
		public ColorGradingModel colorGrading = new ColorGradingModel();

		// Token: 0x04004C52 RID: 19538
		public UserLutModel userLut = new UserLutModel();

		// Token: 0x04004C53 RID: 19539
		public ChromaticAberrationModel chromaticAberration = new ChromaticAberrationModel();

		// Token: 0x04004C54 RID: 19540
		public GrainModel grain = new GrainModel();

		// Token: 0x04004C55 RID: 19541
		public VignetteModel vignette = new VignetteModel();

		// Token: 0x04004C56 RID: 19542
		public DitheringModel dithering = new DitheringModel();
	}
}
