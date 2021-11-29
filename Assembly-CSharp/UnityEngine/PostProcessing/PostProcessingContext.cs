using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000570 RID: 1392
	public class PostProcessingContext
	{
		// Token: 0x17000511 RID: 1297
		// (get) Token: 0x06002359 RID: 9049 RVA: 0x001F04DD File Offset: 0x001EE6DD
		// (set) Token: 0x0600235A RID: 9050 RVA: 0x001F04E5 File Offset: 0x001EE6E5
		public bool interrupted { get; private set; }

		// Token: 0x0600235B RID: 9051 RVA: 0x001F04EE File Offset: 0x001EE6EE
		public void Interrupt()
		{
			this.interrupted = true;
		}

		// Token: 0x0600235C RID: 9052 RVA: 0x001F04F7 File Offset: 0x001EE6F7
		public PostProcessingContext Reset()
		{
			this.profile = null;
			this.camera = null;
			this.materialFactory = null;
			this.renderTextureFactory = null;
			this.interrupted = false;
			return this;
		}

		// Token: 0x17000512 RID: 1298
		// (get) Token: 0x0600235D RID: 9053 RVA: 0x001F051D File Offset: 0x001EE71D
		public bool isGBufferAvailable
		{
			get
			{
				return this.camera.actualRenderingPath == RenderingPath.DeferredShading;
			}
		}

		// Token: 0x17000513 RID: 1299
		// (get) Token: 0x0600235E RID: 9054 RVA: 0x001F052D File Offset: 0x001EE72D
		public bool isHdr
		{
			get
			{
				return this.camera.allowHDR;
			}
		}

		// Token: 0x17000514 RID: 1300
		// (get) Token: 0x0600235F RID: 9055 RVA: 0x001F053A File Offset: 0x001EE73A
		public int width
		{
			get
			{
				return this.camera.pixelWidth;
			}
		}

		// Token: 0x17000515 RID: 1301
		// (get) Token: 0x06002360 RID: 9056 RVA: 0x001F0547 File Offset: 0x001EE747
		public int height
		{
			get
			{
				return this.camera.pixelHeight;
			}
		}

		// Token: 0x17000516 RID: 1302
		// (get) Token: 0x06002361 RID: 9057 RVA: 0x001F0554 File Offset: 0x001EE754
		public Rect viewport
		{
			get
			{
				return this.camera.rect;
			}
		}

		// Token: 0x04004AA8 RID: 19112
		public PostProcessingProfile profile;

		// Token: 0x04004AA9 RID: 19113
		public Camera camera;

		// Token: 0x04004AAA RID: 19114
		public MaterialFactory materialFactory;

		// Token: 0x04004AAB RID: 19115
		public RenderTextureFactory renderTextureFactory;
	}
}
