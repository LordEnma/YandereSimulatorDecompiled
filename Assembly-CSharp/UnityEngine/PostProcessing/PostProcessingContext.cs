using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000582 RID: 1410
	public class PostProcessingContext
	{
		// Token: 0x17000516 RID: 1302
		// (get) Token: 0x060023D0 RID: 9168 RVA: 0x001FA7FD File Offset: 0x001F89FD
		// (set) Token: 0x060023D1 RID: 9169 RVA: 0x001FA805 File Offset: 0x001F8A05
		public bool interrupted { get; private set; }

		// Token: 0x060023D2 RID: 9170 RVA: 0x001FA80E File Offset: 0x001F8A0E
		public void Interrupt()
		{
			this.interrupted = true;
		}

		// Token: 0x060023D3 RID: 9171 RVA: 0x001FA817 File Offset: 0x001F8A17
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
		// (get) Token: 0x060023D4 RID: 9172 RVA: 0x001FA83D File Offset: 0x001F8A3D
		public bool isGBufferAvailable
		{
			get
			{
				return this.camera.actualRenderingPath == RenderingPath.DeferredShading;
			}
		}

		// Token: 0x17000518 RID: 1304
		// (get) Token: 0x060023D5 RID: 9173 RVA: 0x001FA84D File Offset: 0x001F8A4D
		public bool isHdr
		{
			get
			{
				return this.camera.allowHDR;
			}
		}

		// Token: 0x17000519 RID: 1305
		// (get) Token: 0x060023D6 RID: 9174 RVA: 0x001FA85A File Offset: 0x001F8A5A
		public int width
		{
			get
			{
				return this.camera.pixelWidth;
			}
		}

		// Token: 0x1700051A RID: 1306
		// (get) Token: 0x060023D7 RID: 9175 RVA: 0x001FA867 File Offset: 0x001F8A67
		public int height
		{
			get
			{
				return this.camera.pixelHeight;
			}
		}

		// Token: 0x1700051B RID: 1307
		// (get) Token: 0x060023D8 RID: 9176 RVA: 0x001FA874 File Offset: 0x001F8A74
		public Rect viewport
		{
			get
			{
				return this.camera.rect;
			}
		}

		// Token: 0x04004BFC RID: 19452
		public PostProcessingProfile profile;

		// Token: 0x04004BFD RID: 19453
		public Camera camera;

		// Token: 0x04004BFE RID: 19454
		public MaterialFactory materialFactory;

		// Token: 0x04004BFF RID: 19455
		public RenderTextureFactory renderTextureFactory;
	}
}
