namespace UnityEngine.PostProcessing
{
	public abstract class PostProcessingComponentBase
	{
		public PostProcessingContext context;

		public abstract bool active { get; }

		public virtual DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.None;
		}

		public virtual void OnEnable()
		{
		}

		public virtual void OnDisable()
		{
		}

		public abstract PostProcessingModel GetModel();
	}
}
