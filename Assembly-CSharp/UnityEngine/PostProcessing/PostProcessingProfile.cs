using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000574 RID: 1396
	public class PostProcessingProfile : ScriptableObject
	{
		// Token: 0x04004AF6 RID: 19190
		public BuiltinDebugViewsModel debugViews = new BuiltinDebugViewsModel();

		// Token: 0x04004AF7 RID: 19191
		public FogModel fog = new FogModel();

		// Token: 0x04004AF8 RID: 19192
		public AntialiasingModel antialiasing = new AntialiasingModel();

		// Token: 0x04004AF9 RID: 19193
		public AmbientOcclusionModel ambientOcclusion = new AmbientOcclusionModel();

		// Token: 0x04004AFA RID: 19194
		public ScreenSpaceReflectionModel screenSpaceReflection = new ScreenSpaceReflectionModel();

		// Token: 0x04004AFB RID: 19195
		public DepthOfFieldModel depthOfField = new DepthOfFieldModel();

		// Token: 0x04004AFC RID: 19196
		public MotionBlurModel motionBlur = new MotionBlurModel();

		// Token: 0x04004AFD RID: 19197
		public EyeAdaptationModel eyeAdaptation = new EyeAdaptationModel();

		// Token: 0x04004AFE RID: 19198
		public BloomModel bloom = new BloomModel();

		// Token: 0x04004AFF RID: 19199
		public ColorGradingModel colorGrading = new ColorGradingModel();

		// Token: 0x04004B00 RID: 19200
		public UserLutModel userLut = new UserLutModel();

		// Token: 0x04004B01 RID: 19201
		public ChromaticAberrationModel chromaticAberration = new ChromaticAberrationModel();

		// Token: 0x04004B02 RID: 19202
		public GrainModel grain = new GrainModel();

		// Token: 0x04004B03 RID: 19203
		public VignetteModel vignette = new VignetteModel();

		// Token: 0x04004B04 RID: 19204
		public DitheringModel dithering = new DitheringModel();
	}
}
