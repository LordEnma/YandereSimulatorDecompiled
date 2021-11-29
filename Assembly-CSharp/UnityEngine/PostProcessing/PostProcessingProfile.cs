using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000572 RID: 1394
	public class PostProcessingProfile : ScriptableObject
	{
		// Token: 0x04004AAE RID: 19118
		public BuiltinDebugViewsModel debugViews = new BuiltinDebugViewsModel();

		// Token: 0x04004AAF RID: 19119
		public FogModel fog = new FogModel();

		// Token: 0x04004AB0 RID: 19120
		public AntialiasingModel antialiasing = new AntialiasingModel();

		// Token: 0x04004AB1 RID: 19121
		public AmbientOcclusionModel ambientOcclusion = new AmbientOcclusionModel();

		// Token: 0x04004AB2 RID: 19122
		public ScreenSpaceReflectionModel screenSpaceReflection = new ScreenSpaceReflectionModel();

		// Token: 0x04004AB3 RID: 19123
		public DepthOfFieldModel depthOfField = new DepthOfFieldModel();

		// Token: 0x04004AB4 RID: 19124
		public MotionBlurModel motionBlur = new MotionBlurModel();

		// Token: 0x04004AB5 RID: 19125
		public EyeAdaptationModel eyeAdaptation = new EyeAdaptationModel();

		// Token: 0x04004AB6 RID: 19126
		public BloomModel bloom = new BloomModel();

		// Token: 0x04004AB7 RID: 19127
		public ColorGradingModel colorGrading = new ColorGradingModel();

		// Token: 0x04004AB8 RID: 19128
		public UserLutModel userLut = new UserLutModel();

		// Token: 0x04004AB9 RID: 19129
		public ChromaticAberrationModel chromaticAberration = new ChromaticAberrationModel();

		// Token: 0x04004ABA RID: 19130
		public GrainModel grain = new GrainModel();

		// Token: 0x04004ABB RID: 19131
		public VignetteModel vignette = new VignetteModel();

		// Token: 0x04004ABC RID: 19132
		public DitheringModel dithering = new DitheringModel();
	}
}
