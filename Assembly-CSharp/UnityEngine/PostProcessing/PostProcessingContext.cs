using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200057C RID: 1404
	public class PostProcessingContext
	{
		// Token: 0x17000515 RID: 1301
		// (get) Token: 0x060023B1 RID: 9137 RVA: 0x001F8001 File Offset: 0x001F6201
		// (set) Token: 0x060023B2 RID: 9138 RVA: 0x001F8009 File Offset: 0x001F6209
		public bool interrupted { get; private set; }

		// Token: 0x060023B3 RID: 9139 RVA: 0x001F8012 File Offset: 0x001F6212
		public void Interrupt()
		{
			this.interrupted = true;
		}

		// Token: 0x060023B4 RID: 9140 RVA: 0x001F801B File Offset: 0x001F621B
		public PostProcessingContext Reset()
		{
			this.profile = null;
			this.camera = null;
			this.materialFactory = null;
			this.renderTextureFactory = null;
			this.interrupted = false;
			return this;
		}

		// Token: 0x17000516 RID: 1302
		// (get) Token: 0x060023B5 RID: 9141 RVA: 0x001F8041 File Offset: 0x001F6241
		public bool isGBufferAvailable
		{
			get
			{
				return this.camera.actualRenderingPath == RenderingPath.DeferredShading;
			}
		}

		// Token: 0x17000517 RID: 1303
		// (get) Token: 0x060023B6 RID: 9142 RVA: 0x001F8051 File Offset: 0x001F6251
		public bool isHdr
		{
			get
			{
				return this.camera.allowHDR;
			}
		}

		// Token: 0x17000518 RID: 1304
		// (get) Token: 0x060023B7 RID: 9143 RVA: 0x001F805E File Offset: 0x001F625E
		public int width
		{
			get
			{
				return this.camera.pixelWidth;
			}
		}

		// Token: 0x17000519 RID: 1305
		// (get) Token: 0x060023B8 RID: 9144 RVA: 0x001F806B File Offset: 0x001F626B
		public int height
		{
			get
			{
				return this.camera.pixelHeight;
			}
		}

		// Token: 0x1700051A RID: 1306
		// (get) Token: 0x060023B9 RID: 9145 RVA: 0x001F8078 File Offset: 0x001F6278
		public Rect viewport
		{
			get
			{
				return this.camera.rect;
			}
		}

		// Token: 0x04004BB4 RID: 19380
		public PostProcessingProfile profile;

		// Token: 0x04004BB5 RID: 19381
		public Camera camera;

		// Token: 0x04004BB6 RID: 19382
		public MaterialFactory materialFactory;

		// Token: 0x04004BB7 RID: 19383
		public RenderTextureFactory renderTextureFactory;
	}
}
