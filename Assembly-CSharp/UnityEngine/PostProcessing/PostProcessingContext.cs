namespace UnityEngine.PostProcessing
{
	public class PostProcessingContext
	{
		public PostProcessingProfile profile;

		public Camera camera;

		public MaterialFactory materialFactory;

		public RenderTextureFactory renderTextureFactory;

		public bool interrupted { get; private set; }

		public bool isGBufferAvailable => camera.actualRenderingPath == RenderingPath.DeferredShading;

		public bool isHdr => camera.allowHDR;

		public int width => camera.pixelWidth;

		public int height => camera.pixelHeight;

		public Rect viewport => camera.rect;

		public void Interrupt()
		{
			interrupted = true;
		}

		public PostProcessingContext Reset()
		{
			profile = null;
			camera = null;
			materialFactory = null;
			renderTextureFactory = null;
			interrupted = false;
			return this;
		}
	}
}
