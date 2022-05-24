using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000584 RID: 1412
	public class PostProcessingContext
	{
		// Token: 0x17000517 RID: 1303
		// (get) Token: 0x060023E5 RID: 9189 RVA: 0x001FD93D File Offset: 0x001FBB3D
		// (set) Token: 0x060023E6 RID: 9190 RVA: 0x001FD945 File Offset: 0x001FBB45
		public bool interrupted { get; private set; }

		// Token: 0x060023E7 RID: 9191 RVA: 0x001FD94E File Offset: 0x001FBB4E
		public void Interrupt()
		{
			this.interrupted = true;
		}

		// Token: 0x060023E8 RID: 9192 RVA: 0x001FD957 File Offset: 0x001FBB57
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
		// (get) Token: 0x060023E9 RID: 9193 RVA: 0x001FD97D File Offset: 0x001FBB7D
		public bool isGBufferAvailable
		{
			get
			{
				return this.camera.actualRenderingPath == RenderingPath.DeferredShading;
			}
		}

		// Token: 0x17000519 RID: 1305
		// (get) Token: 0x060023EA RID: 9194 RVA: 0x001FD98D File Offset: 0x001FBB8D
		public bool isHdr
		{
			get
			{
				return this.camera.allowHDR;
			}
		}

		// Token: 0x1700051A RID: 1306
		// (get) Token: 0x060023EB RID: 9195 RVA: 0x001FD99A File Offset: 0x001FBB9A
		public int width
		{
			get
			{
				return this.camera.pixelWidth;
			}
		}

		// Token: 0x1700051B RID: 1307
		// (get) Token: 0x060023EC RID: 9196 RVA: 0x001FD9A7 File Offset: 0x001FBBA7
		public int height
		{
			get
			{
				return this.camera.pixelHeight;
			}
		}

		// Token: 0x1700051C RID: 1308
		// (get) Token: 0x060023ED RID: 9197 RVA: 0x001FD9B4 File Offset: 0x001FBBB4
		public Rect viewport
		{
			get
			{
				return this.camera.rect;
			}
		}

		// Token: 0x04004C42 RID: 19522
		public PostProcessingProfile profile;

		// Token: 0x04004C43 RID: 19523
		public Camera camera;

		// Token: 0x04004C44 RID: 19524
		public MaterialFactory materialFactory;

		// Token: 0x04004C45 RID: 19525
		public RenderTextureFactory renderTextureFactory;
	}
}
