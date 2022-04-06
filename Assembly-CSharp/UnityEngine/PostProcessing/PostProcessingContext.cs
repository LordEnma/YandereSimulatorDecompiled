using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000582 RID: 1410
	public class PostProcessingContext
	{
		// Token: 0x17000515 RID: 1301
		// (get) Token: 0x060023C9 RID: 9161 RVA: 0x001F9DA1 File Offset: 0x001F7FA1
		// (set) Token: 0x060023CA RID: 9162 RVA: 0x001F9DA9 File Offset: 0x001F7FA9
		public bool interrupted { get; private set; }

		// Token: 0x060023CB RID: 9163 RVA: 0x001F9DB2 File Offset: 0x001F7FB2
		public void Interrupt()
		{
			this.interrupted = true;
		}

		// Token: 0x060023CC RID: 9164 RVA: 0x001F9DBB File Offset: 0x001F7FBB
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
		// (get) Token: 0x060023CD RID: 9165 RVA: 0x001F9DE1 File Offset: 0x001F7FE1
		public bool isGBufferAvailable
		{
			get
			{
				return this.camera.actualRenderingPath == RenderingPath.DeferredShading;
			}
		}

		// Token: 0x17000517 RID: 1303
		// (get) Token: 0x060023CE RID: 9166 RVA: 0x001F9DF1 File Offset: 0x001F7FF1
		public bool isHdr
		{
			get
			{
				return this.camera.allowHDR;
			}
		}

		// Token: 0x17000518 RID: 1304
		// (get) Token: 0x060023CF RID: 9167 RVA: 0x001F9DFE File Offset: 0x001F7FFE
		public int width
		{
			get
			{
				return this.camera.pixelWidth;
			}
		}

		// Token: 0x17000519 RID: 1305
		// (get) Token: 0x060023D0 RID: 9168 RVA: 0x001F9E0B File Offset: 0x001F800B
		public int height
		{
			get
			{
				return this.camera.pixelHeight;
			}
		}

		// Token: 0x1700051A RID: 1306
		// (get) Token: 0x060023D1 RID: 9169 RVA: 0x001F9E18 File Offset: 0x001F8018
		public Rect viewport
		{
			get
			{
				return this.camera.rect;
			}
		}

		// Token: 0x04004BEA RID: 19434
		public PostProcessingProfile profile;

		// Token: 0x04004BEB RID: 19435
		public Camera camera;

		// Token: 0x04004BEC RID: 19436
		public MaterialFactory materialFactory;

		// Token: 0x04004BED RID: 19437
		public RenderTextureFactory renderTextureFactory;
	}
}
