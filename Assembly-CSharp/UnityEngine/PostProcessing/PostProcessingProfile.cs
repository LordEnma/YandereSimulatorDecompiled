using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000574 RID: 1396
	public class PostProcessingProfile : ScriptableObject
	{
		// Token: 0x04004AED RID: 19181
		public BuiltinDebugViewsModel debugViews = new BuiltinDebugViewsModel();

		// Token: 0x04004AEE RID: 19182
		public FogModel fog = new FogModel();

		// Token: 0x04004AEF RID: 19183
		public AntialiasingModel antialiasing = new AntialiasingModel();

		// Token: 0x04004AF0 RID: 19184
		public AmbientOcclusionModel ambientOcclusion = new AmbientOcclusionModel();

		// Token: 0x04004AF1 RID: 19185
		public ScreenSpaceReflectionModel screenSpaceReflection = new ScreenSpaceReflectionModel();

		// Token: 0x04004AF2 RID: 19186
		public DepthOfFieldModel depthOfField = new DepthOfFieldModel();

		// Token: 0x04004AF3 RID: 19187
		public MotionBlurModel motionBlur = new MotionBlurModel();

		// Token: 0x04004AF4 RID: 19188
		public EyeAdaptationModel eyeAdaptation = new EyeAdaptationModel();

		// Token: 0x04004AF5 RID: 19189
		public BloomModel bloom = new BloomModel();

		// Token: 0x04004AF6 RID: 19190
		public ColorGradingModel colorGrading = new ColorGradingModel();

		// Token: 0x04004AF7 RID: 19191
		public UserLutModel userLut = new UserLutModel();

		// Token: 0x04004AF8 RID: 19192
		public ChromaticAberrationModel chromaticAberration = new ChromaticAberrationModel();

		// Token: 0x04004AF9 RID: 19193
		public GrainModel grain = new GrainModel();

		// Token: 0x04004AFA RID: 19194
		public VignetteModel vignette = new VignetteModel();

		// Token: 0x04004AFB RID: 19195
		public DitheringModel dithering = new DitheringModel();
	}
}
