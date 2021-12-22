using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000572 RID: 1394
	public class PostProcessingContext
	{
		// Token: 0x17000511 RID: 1297
		// (get) Token: 0x0600236A RID: 9066 RVA: 0x001F1C11 File Offset: 0x001EFE11
		// (set) Token: 0x0600236B RID: 9067 RVA: 0x001F1C19 File Offset: 0x001EFE19
		public bool interrupted { get; private set; }

		// Token: 0x0600236C RID: 9068 RVA: 0x001F1C22 File Offset: 0x001EFE22
		public void Interrupt()
		{
			this.interrupted = true;
		}

		// Token: 0x0600236D RID: 9069 RVA: 0x001F1C2B File Offset: 0x001EFE2B
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
		// (get) Token: 0x0600236E RID: 9070 RVA: 0x001F1C51 File Offset: 0x001EFE51
		public bool isGBufferAvailable
		{
			get
			{
				return this.camera.actualRenderingPath == RenderingPath.DeferredShading;
			}
		}

		// Token: 0x17000513 RID: 1299
		// (get) Token: 0x0600236F RID: 9071 RVA: 0x001F1C61 File Offset: 0x001EFE61
		public bool isHdr
		{
			get
			{
				return this.camera.allowHDR;
			}
		}

		// Token: 0x17000514 RID: 1300
		// (get) Token: 0x06002370 RID: 9072 RVA: 0x001F1C6E File Offset: 0x001EFE6E
		public int width
		{
			get
			{
				return this.camera.pixelWidth;
			}
		}

		// Token: 0x17000515 RID: 1301
		// (get) Token: 0x06002371 RID: 9073 RVA: 0x001F1C7B File Offset: 0x001EFE7B
		public int height
		{
			get
			{
				return this.camera.pixelHeight;
			}
		}

		// Token: 0x17000516 RID: 1302
		// (get) Token: 0x06002372 RID: 9074 RVA: 0x001F1C88 File Offset: 0x001EFE88
		public Rect viewport
		{
			get
			{
				return this.camera.rect;
			}
		}

		// Token: 0x04004AE7 RID: 19175
		public PostProcessingProfile profile;

		// Token: 0x04004AE8 RID: 19176
		public Camera camera;

		// Token: 0x04004AE9 RID: 19177
		public MaterialFactory materialFactory;

		// Token: 0x04004AEA RID: 19178
		public RenderTextureFactory renderTextureFactory;
	}
}
