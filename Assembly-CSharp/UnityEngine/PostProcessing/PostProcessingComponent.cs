namespace UnityEngine.PostProcessing
{
	public abstract class PostProcessingComponent<T> : PostProcessingComponentBase where T : PostProcessingModel
	{
		public T model { get; internal set; }

		public virtual void Init(PostProcessingContext pcontext, T pmodel)
		{
			context = pcontext;
			model = pmodel;
		}

		public override PostProcessingModel GetModel()
		{
			return model;
		}
	}
}
