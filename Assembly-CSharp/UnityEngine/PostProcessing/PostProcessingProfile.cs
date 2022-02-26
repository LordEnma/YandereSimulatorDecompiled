using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000579 RID: 1401
	public class PostProcessingProfile : ScriptableObject
	{
		// Token: 0x04004B3E RID: 19262
		public BuiltinDebugViewsModel debugViews = new BuiltinDebugViewsModel();

		// Token: 0x04004B3F RID: 19263
		public FogModel fog = new FogModel();

		// Token: 0x04004B40 RID: 19264
		public AntialiasingModel antialiasing = new AntialiasingModel();

		// Token: 0x04004B41 RID: 19265
		public AmbientOcclusionModel ambientOcclusion = new AmbientOcclusionModel();

		// Token: 0x04004B42 RID: 19266
		public ScreenSpaceReflectionModel screenSpaceReflection = new ScreenSpaceReflectionModel();

		// Token: 0x04004B43 RID: 19267
		public DepthOfFieldModel depthOfField = new DepthOfFieldModel();

		// Token: 0x04004B44 RID: 19268
		public MotionBlurModel motionBlur = new MotionBlurModel();

		// Token: 0x04004B45 RID: 19269
		public EyeAdaptationModel eyeAdaptation = new EyeAdaptationModel();

		// Token: 0x04004B46 RID: 19270
		public BloomModel bloom = new BloomModel();

		// Token: 0x04004B47 RID: 19271
		public ColorGradingModel colorGrading = new ColorGradingModel();

		// Token: 0x04004B48 RID: 19272
		public UserLutModel userLut = new UserLutModel();

		// Token: 0x04004B49 RID: 19273
		public ChromaticAberrationModel chromaticAberration = new ChromaticAberrationModel();

		// Token: 0x04004B4A RID: 19274
		public GrainModel grain = new GrainModel();

		// Token: 0x04004B4B RID: 19275
		public VignetteModel vignette = new VignetteModel();

		// Token: 0x04004B4C RID: 19276
		public DitheringModel dithering = new DitheringModel();
	}
}
