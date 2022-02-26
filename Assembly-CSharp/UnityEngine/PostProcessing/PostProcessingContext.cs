using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000577 RID: 1399
	public class PostProcessingContext
	{
		// Token: 0x17000514 RID: 1300
		// (get) Token: 0x06002393 RID: 9107 RVA: 0x001F56C1 File Offset: 0x001F38C1
		// (set) Token: 0x06002394 RID: 9108 RVA: 0x001F56C9 File Offset: 0x001F38C9
		public bool interrupted { get; private set; }

		// Token: 0x06002395 RID: 9109 RVA: 0x001F56D2 File Offset: 0x001F38D2
		public void Interrupt()
		{
			this.interrupted = true;
		}

		// Token: 0x06002396 RID: 9110 RVA: 0x001F56DB File Offset: 0x001F38DB
		public PostProcessingContext Reset()
		{
			this.profile = null;
			this.camera = null;
			this.materialFactory = null;
			this.renderTextureFactory = null;
			this.interrupted = false;
			return this;
		}

		// Token: 0x17000515 RID: 1301
		// (get) Token: 0x06002397 RID: 9111 RVA: 0x001F5701 File Offset: 0x001F3901
		public bool isGBufferAvailable
		{
			get
			{
				return this.camera.actualRenderingPath == RenderingPath.DeferredShading;
			}
		}

		// Token: 0x17000516 RID: 1302
		// (get) Token: 0x06002398 RID: 9112 RVA: 0x001F5711 File Offset: 0x001F3911
		public bool isHdr
		{
			get
			{
				return this.camera.allowHDR;
			}
		}

		// Token: 0x17000517 RID: 1303
		// (get) Token: 0x06002399 RID: 9113 RVA: 0x001F571E File Offset: 0x001F391E
		public int width
		{
			get
			{
				return this.camera.pixelWidth;
			}
		}

		// Token: 0x17000518 RID: 1304
		// (get) Token: 0x0600239A RID: 9114 RVA: 0x001F572B File Offset: 0x001F392B
		public int height
		{
			get
			{
				return this.camera.pixelHeight;
			}
		}

		// Token: 0x17000519 RID: 1305
		// (get) Token: 0x0600239B RID: 9115 RVA: 0x001F5738 File Offset: 0x001F3938
		public Rect viewport
		{
			get
			{
				return this.camera.rect;
			}
		}

		// Token: 0x04004B38 RID: 19256
		public PostProcessingProfile profile;

		// Token: 0x04004B39 RID: 19257
		public Camera camera;

		// Token: 0x04004B3A RID: 19258
		public MaterialFactory materialFactory;

		// Token: 0x04004B3B RID: 19259
		public RenderTextureFactory renderTextureFactory;
	}
}
