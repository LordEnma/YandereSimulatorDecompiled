using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000583 RID: 1411
	public class PostProcessingContext
	{
		// Token: 0x17000516 RID: 1302
		// (get) Token: 0x060023D9 RID: 9177 RVA: 0x001FBC89 File Offset: 0x001F9E89
		// (set) Token: 0x060023DA RID: 9178 RVA: 0x001FBC91 File Offset: 0x001F9E91
		public bool interrupted { get; private set; }

		// Token: 0x060023DB RID: 9179 RVA: 0x001FBC9A File Offset: 0x001F9E9A
		public void Interrupt()
		{
			this.interrupted = true;
		}

		// Token: 0x060023DC RID: 9180 RVA: 0x001FBCA3 File Offset: 0x001F9EA3
		public PostProcessingContext Reset()
		{
			this.profile = null;
			this.camera = null;
			this.materialFactory = null;
			this.renderTextureFactory = null;
			this.interrupted = false;
			return this;
		}

		// Token: 0x17000517 RID: 1303
		// (get) Token: 0x060023DD RID: 9181 RVA: 0x001FBCC9 File Offset: 0x001F9EC9
		public bool isGBufferAvailable
		{
			get
			{
				return this.camera.actualRenderingPath == RenderingPath.DeferredShading;
			}
		}

		// Token: 0x17000518 RID: 1304
		// (get) Token: 0x060023DE RID: 9182 RVA: 0x001FBCD9 File Offset: 0x001F9ED9
		public bool isHdr
		{
			get
			{
				return this.camera.allowHDR;
			}
		}

		// Token: 0x17000519 RID: 1305
		// (get) Token: 0x060023DF RID: 9183 RVA: 0x001FBCE6 File Offset: 0x001F9EE6
		public int width
		{
			get
			{
				return this.camera.pixelWidth;
			}
		}

		// Token: 0x1700051A RID: 1306
		// (get) Token: 0x060023E0 RID: 9184 RVA: 0x001FBCF3 File Offset: 0x001F9EF3
		public int height
		{
			get
			{
				return this.camera.pixelHeight;
			}
		}

		// Token: 0x1700051B RID: 1307
		// (get) Token: 0x060023E1 RID: 9185 RVA: 0x001FBD00 File Offset: 0x001F9F00
		public Rect viewport
		{
			get
			{
				return this.camera.rect;
			}
		}

		// Token: 0x04004C12 RID: 19474
		public PostProcessingProfile profile;

		// Token: 0x04004C13 RID: 19475
		public Camera camera;

		// Token: 0x04004C14 RID: 19476
		public MaterialFactory materialFactory;

		// Token: 0x04004C15 RID: 19477
		public RenderTextureFactory renderTextureFactory;
	}
}
