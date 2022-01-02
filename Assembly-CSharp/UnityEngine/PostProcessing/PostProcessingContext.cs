using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000572 RID: 1394
	public class PostProcessingContext
	{
		// Token: 0x17000512 RID: 1298
		// (get) Token: 0x0600236D RID: 9069 RVA: 0x001F2201 File Offset: 0x001F0401
		// (set) Token: 0x0600236E RID: 9070 RVA: 0x001F2209 File Offset: 0x001F0409
		public bool interrupted { get; private set; }

		// Token: 0x0600236F RID: 9071 RVA: 0x001F2212 File Offset: 0x001F0412
		public void Interrupt()
		{
			this.interrupted = true;
		}

		// Token: 0x06002370 RID: 9072 RVA: 0x001F221B File Offset: 0x001F041B
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
		// (get) Token: 0x06002371 RID: 9073 RVA: 0x001F2241 File Offset: 0x001F0441
		public bool isGBufferAvailable
		{
			get
			{
				return this.camera.actualRenderingPath == RenderingPath.DeferredShading;
			}
		}

		// Token: 0x17000514 RID: 1300
		// (get) Token: 0x06002372 RID: 9074 RVA: 0x001F2251 File Offset: 0x001F0451
		public bool isHdr
		{
			get
			{
				return this.camera.allowHDR;
			}
		}

		// Token: 0x17000515 RID: 1301
		// (get) Token: 0x06002373 RID: 9075 RVA: 0x001F225E File Offset: 0x001F045E
		public int width
		{
			get
			{
				return this.camera.pixelWidth;
			}
		}

		// Token: 0x17000516 RID: 1302
		// (get) Token: 0x06002374 RID: 9076 RVA: 0x001F226B File Offset: 0x001F046B
		public int height
		{
			get
			{
				return this.camera.pixelHeight;
			}
		}

		// Token: 0x17000517 RID: 1303
		// (get) Token: 0x06002375 RID: 9077 RVA: 0x001F2278 File Offset: 0x001F0478
		public Rect viewport
		{
			get
			{
				return this.camera.rect;
			}
		}

		// Token: 0x04004AF0 RID: 19184
		public PostProcessingProfile profile;

		// Token: 0x04004AF1 RID: 19185
		public Camera camera;

		// Token: 0x04004AF2 RID: 19186
		public MaterialFactory materialFactory;

		// Token: 0x04004AF3 RID: 19187
		public RenderTextureFactory renderTextureFactory;
	}
}
