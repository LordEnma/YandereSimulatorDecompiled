using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000577 RID: 1399
	public class PostProcessingProfile : ScriptableObject
	{
		// Token: 0x04004B1C RID: 19228
		public BuiltinDebugViewsModel debugViews = new BuiltinDebugViewsModel();

		// Token: 0x04004B1D RID: 19229
		public FogModel fog = new FogModel();

		// Token: 0x04004B1E RID: 19230
		public AntialiasingModel antialiasing = new AntialiasingModel();

		// Token: 0x04004B1F RID: 19231
		public AmbientOcclusionModel ambientOcclusion = new AmbientOcclusionModel();

		// Token: 0x04004B20 RID: 19232
		public ScreenSpaceReflectionModel screenSpaceReflection = new ScreenSpaceReflectionModel();

		// Token: 0x04004B21 RID: 19233
		public DepthOfFieldModel depthOfField = new DepthOfFieldModel();

		// Token: 0x04004B22 RID: 19234
		public MotionBlurModel motionBlur = new MotionBlurModel();

		// Token: 0x04004B23 RID: 19235
		public EyeAdaptationModel eyeAdaptation = new EyeAdaptationModel();

		// Token: 0x04004B24 RID: 19236
		public BloomModel bloom = new BloomModel();

		// Token: 0x04004B25 RID: 19237
		public ColorGradingModel colorGrading = new ColorGradingModel();

		// Token: 0x04004B26 RID: 19238
		public UserLutModel userLut = new UserLutModel();

		// Token: 0x04004B27 RID: 19239
		public ChromaticAberrationModel chromaticAberration = new ChromaticAberrationModel();

		// Token: 0x04004B28 RID: 19240
		public GrainModel grain = new GrainModel();

		// Token: 0x04004B29 RID: 19241
		public VignetteModel vignette = new VignetteModel();

		// Token: 0x04004B2A RID: 19242
		public DitheringModel dithering = new DitheringModel();
	}
}
