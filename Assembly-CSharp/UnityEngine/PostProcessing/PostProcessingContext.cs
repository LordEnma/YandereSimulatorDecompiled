using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000574 RID: 1396
	public class PostProcessingContext
	{
		// Token: 0x17000512 RID: 1298
		// (get) Token: 0x06002378 RID: 9080 RVA: 0x001F2BA1 File Offset: 0x001F0DA1
		// (set) Token: 0x06002379 RID: 9081 RVA: 0x001F2BA9 File Offset: 0x001F0DA9
		public bool interrupted { get; private set; }

		// Token: 0x0600237A RID: 9082 RVA: 0x001F2BB2 File Offset: 0x001F0DB2
		public void Interrupt()
		{
			this.interrupted = true;
		}

		// Token: 0x0600237B RID: 9083 RVA: 0x001F2BBB File Offset: 0x001F0DBB
		public PostProcessingContext Reset()
		{
			this.profile = null;
			this.camera = null;
			this.materialFactory = null;
			this.renderTextureFactory = null;
			this.interrupted = false;
			return this;
		}

		// Token: 0x17000513 RID: 1299
		// (get) Token: 0x0600237C RID: 9084 RVA: 0x001F2BE1 File Offset: 0x001F0DE1
		public bool isGBufferAvailable
		{
			get
			{
				return this.camera.actualRenderingPath == RenderingPath.DeferredShading;
			}
		}

		// Token: 0x17000514 RID: 1300
		// (get) Token: 0x0600237D RID: 9085 RVA: 0x001F2BF1 File Offset: 0x001F0DF1
		public bool isHdr
		{
			get
			{
				return this.camera.allowHDR;
			}
		}

		// Token: 0x17000515 RID: 1301
		// (get) Token: 0x0600237E RID: 9086 RVA: 0x001F2BFE File Offset: 0x001F0DFE
		public int width
		{
			get
			{
				return this.camera.pixelWidth;
			}
		}

		// Token: 0x17000516 RID: 1302
		// (get) Token: 0x0600237F RID: 9087 RVA: 0x001F2C0B File Offset: 0x001F0E0B
		public int height
		{
			get
			{
				return this.camera.pixelHeight;
			}
		}

		// Token: 0x17000517 RID: 1303
		// (get) Token: 0x06002380 RID: 9088 RVA: 0x001F2C18 File Offset: 0x001F0E18
		public Rect viewport
		{
			get
			{
				return this.camera.rect;
			}
		}

		// Token: 0x04004B04 RID: 19204
		public PostProcessingProfile profile;

		// Token: 0x04004B05 RID: 19205
		public Camera camera;

		// Token: 0x04004B06 RID: 19206
		public MaterialFactory materialFactory;

		// Token: 0x04004B07 RID: 19207
		public RenderTextureFactory renderTextureFactory;
	}
}
