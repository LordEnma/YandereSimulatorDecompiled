namespace UnityEngine.PostProcessing
{
	public abstract class PostProcessingComponentRenderTexture<T> : PostProcessingComponent<T> where T : PostProcessingModel
	{
		public virtual void Prepare(Material material)
		{
		}
	}
}
