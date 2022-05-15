using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000584 RID: 1412
	public class PostProcessingContext
	{
		// Token: 0x17000517 RID: 1303
		// (get) Token: 0x060023E4 RID: 9188 RVA: 0x001FD3D5 File Offset: 0x001FB5D5
		// (set) Token: 0x060023E5 RID: 9189 RVA: 0x001FD3DD File Offset: 0x001FB5DD
		public bool interrupted { get; private set; }

		// Token: 0x060023E6 RID: 9190 RVA: 0x001FD3E6 File Offset: 0x001FB5E6
		public void Interrupt()
		{
			this.interrupted = true;
		}

		// Token: 0x060023E7 RID: 9191 RVA: 0x001FD3EF File Offset: 0x001FB5EF
		public PostProcessingContext Reset()
		{
			this.profile = null;
			this.camera = null;
			this.materialFactory = null;
			this.renderTextureFactory = null;
			this.interrupted = false;
			return this;
		}

		// Token: 0x17000518 RID: 1304
		// (get) Token: 0x060023E8 RID: 9192 RVA: 0x001FD415 File Offset: 0x001FB615
		public bool isGBufferAvailable
		{
			get
			{
				return this.camera.actualRenderingPath == RenderingPath.DeferredShading;
			}
		}

		// Token: 0x17000519 RID: 1305
		// (get) Token: 0x060023E9 RID: 9193 RVA: 0x001FD425 File Offset: 0x001FB625
		public bool isHdr
		{
			get
			{
				return this.camera.allowHDR;
			}
		}

		// Token: 0x1700051A RID: 1306
		// (get) Token: 0x060023EA RID: 9194 RVA: 0x001FD432 File Offset: 0x001FB632
		public int width
		{
			get
			{
				return this.camera.pixelWidth;
			}
		}

		// Token: 0x1700051B RID: 1307
		// (get) Token: 0x060023EB RID: 9195 RVA: 0x001FD43F File Offset: 0x001FB63F
		public int height
		{
			get
			{
				return this.camera.pixelHeight;
			}
		}

		// Token: 0x1700051C RID: 1308
		// (get) Token: 0x060023EC RID: 9196 RVA: 0x001FD44C File Offset: 0x001FB64C
		public Rect viewport
		{
			get
			{
				return this.camera.rect;
			}
		}

		// Token: 0x04004C39 RID: 19513
		public PostProcessingProfile profile;

		// Token: 0x04004C3A RID: 19514
		public Camera camera;

		// Token: 0x04004C3B RID: 19515
		public MaterialFactory materialFactory;

		// Token: 0x04004C3C RID: 19516
		public RenderTextureFactory renderTextureFactory;
	}
}
