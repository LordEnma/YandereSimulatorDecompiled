using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000576 RID: 1398
	public class PostProcessingContext
	{
		// Token: 0x17000514 RID: 1300
		// (get) Token: 0x0600238A RID: 9098 RVA: 0x001F4AE1 File Offset: 0x001F2CE1
		// (set) Token: 0x0600238B RID: 9099 RVA: 0x001F4AE9 File Offset: 0x001F2CE9
		public bool interrupted { get; private set; }

		// Token: 0x0600238C RID: 9100 RVA: 0x001F4AF2 File Offset: 0x001F2CF2
		public void Interrupt()
		{
			this.interrupted = true;
		}

		// Token: 0x0600238D RID: 9101 RVA: 0x001F4AFB File Offset: 0x001F2CFB
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
		// (get) Token: 0x0600238E RID: 9102 RVA: 0x001F4B21 File Offset: 0x001F2D21
		public bool isGBufferAvailable
		{
			get
			{
				return this.camera.actualRenderingPath == RenderingPath.DeferredShading;
			}
		}

		// Token: 0x17000516 RID: 1302
		// (get) Token: 0x0600238F RID: 9103 RVA: 0x001F4B31 File Offset: 0x001F2D31
		public bool isHdr
		{
			get
			{
				return this.camera.allowHDR;
			}
		}

		// Token: 0x17000517 RID: 1303
		// (get) Token: 0x06002390 RID: 9104 RVA: 0x001F4B3E File Offset: 0x001F2D3E
		public int width
		{
			get
			{
				return this.camera.pixelWidth;
			}
		}

		// Token: 0x17000518 RID: 1304
		// (get) Token: 0x06002391 RID: 9105 RVA: 0x001F4B4B File Offset: 0x001F2D4B
		public int height
		{
			get
			{
				return this.camera.pixelHeight;
			}
		}

		// Token: 0x17000519 RID: 1305
		// (get) Token: 0x06002392 RID: 9106 RVA: 0x001F4B58 File Offset: 0x001F2D58
		public Rect viewport
		{
			get
			{
				return this.camera.rect;
			}
		}

		// Token: 0x04004B28 RID: 19240
		public PostProcessingProfile profile;

		// Token: 0x04004B29 RID: 19241
		public Camera camera;

		// Token: 0x04004B2A RID: 19242
		public MaterialFactory materialFactory;

		// Token: 0x04004B2B RID: 19243
		public RenderTextureFactory renderTextureFactory;
	}
}
