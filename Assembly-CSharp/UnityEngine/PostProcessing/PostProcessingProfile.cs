namespace UnityEngine.PostProcessing
{
	public class PostProcessingProfile : ScriptableObject
	{
		public BuiltinDebugViewsModel debugViews = new BuiltinDebugViewsModel();

		public FogModel fog = new FogModel();

		public AntialiasingModel antialiasing = new AntialiasingModel();

		public AmbientOcclusionModel ambientOcclusion = new AmbientOcclusionModel();

		public ScreenSpaceReflectionModel screenSpaceReflection = new ScreenSpaceReflectionModel();

		public DepthOfFieldModel depthOfField = new DepthOfFieldModel();

		public MotionBlurModel motionBlur = new MotionBlurModel();

		public EyeAdaptationModel eyeAdaptation = new EyeAdaptationModel();

		public BloomModel bloom = new BloomModel();

		public ColorGradingModel colorGrading = new ColorGradingModel();

		public UserLutModel userLut = new UserLutModel();

		public ChromaticAberrationModel chromaticAberration = new ChromaticAberrationModel();

		public GrainModel grain = new GrainModel();

		public VignetteModel vignette = new VignetteModel();

		public DitheringModel dithering = new DitheringModel();
	}
}
