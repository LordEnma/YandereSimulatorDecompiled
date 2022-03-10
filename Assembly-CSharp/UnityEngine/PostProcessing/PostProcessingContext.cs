using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000578 RID: 1400
	public class PostProcessingContext
	{
		// Token: 0x17000514 RID: 1300
		// (get) Token: 0x06002399 RID: 9113 RVA: 0x001F6099 File Offset: 0x001F4299
		// (set) Token: 0x0600239A RID: 9114 RVA: 0x001F60A1 File Offset: 0x001F42A1
		public bool interrupted { get; private set; }

		// Token: 0x0600239B RID: 9115 RVA: 0x001F60AA File Offset: 0x001F42AA
		public void Interrupt()
		{
			this.interrupted = true;
		}

		// Token: 0x0600239C RID: 9116 RVA: 0x001F60B3 File Offset: 0x001F42B3
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
		// (get) Token: 0x0600239D RID: 9117 RVA: 0x001F60D9 File Offset: 0x001F42D9
		public bool isGBufferAvailable
		{
			get
			{
				return this.camera.actualRenderingPath == RenderingPath.DeferredShading;
			}
		}

		// Token: 0x17000516 RID: 1302
		// (get) Token: 0x0600239E RID: 9118 RVA: 0x001F60E9 File Offset: 0x001F42E9
		public bool isHdr
		{
			get
			{
				return this.camera.allowHDR;
			}
		}

		// Token: 0x17000517 RID: 1303
		// (get) Token: 0x0600239F RID: 9119 RVA: 0x001F60F6 File Offset: 0x001F42F6
		public int width
		{
			get
			{
				return this.camera.pixelWidth;
			}
		}

		// Token: 0x17000518 RID: 1304
		// (get) Token: 0x060023A0 RID: 9120 RVA: 0x001F6103 File Offset: 0x001F4303
		public int height
		{
			get
			{
				return this.camera.pixelHeight;
			}
		}

		// Token: 0x17000519 RID: 1305
		// (get) Token: 0x060023A1 RID: 9121 RVA: 0x001F6110 File Offset: 0x001F4310
		public Rect viewport
		{
			get
			{
				return this.camera.rect;
			}
		}

		// Token: 0x04004B55 RID: 19285
		public PostProcessingProfile profile;

		// Token: 0x04004B56 RID: 19286
		public Camera camera;

		// Token: 0x04004B57 RID: 19287
		public MaterialFactory materialFactory;

		// Token: 0x04004B58 RID: 19288
		public RenderTextureFactory renderTextureFactory;
	}
}
