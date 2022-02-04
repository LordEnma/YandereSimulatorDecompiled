using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000575 RID: 1397
	public class PostProcessingContext
	{
		// Token: 0x17000512 RID: 1298
		// (get) Token: 0x06002380 RID: 9088 RVA: 0x001F4429 File Offset: 0x001F2629
		// (set) Token: 0x06002381 RID: 9089 RVA: 0x001F4431 File Offset: 0x001F2631
		public bool interrupted { get; private set; }

		// Token: 0x06002382 RID: 9090 RVA: 0x001F443A File Offset: 0x001F263A
		public void Interrupt()
		{
			this.interrupted = true;
		}

		// Token: 0x06002383 RID: 9091 RVA: 0x001F4443 File Offset: 0x001F2643
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
		// (get) Token: 0x06002384 RID: 9092 RVA: 0x001F4469 File Offset: 0x001F2669
		public bool isGBufferAvailable
		{
			get
			{
				return this.camera.actualRenderingPath == RenderingPath.DeferredShading;
			}
		}

		// Token: 0x17000514 RID: 1300
		// (get) Token: 0x06002385 RID: 9093 RVA: 0x001F4479 File Offset: 0x001F2679
		public bool isHdr
		{
			get
			{
				return this.camera.allowHDR;
			}
		}

		// Token: 0x17000515 RID: 1301
		// (get) Token: 0x06002386 RID: 9094 RVA: 0x001F4486 File Offset: 0x001F2686
		public int width
		{
			get
			{
				return this.camera.pixelWidth;
			}
		}

		// Token: 0x17000516 RID: 1302
		// (get) Token: 0x06002387 RID: 9095 RVA: 0x001F4493 File Offset: 0x001F2693
		public int height
		{
			get
			{
				return this.camera.pixelHeight;
			}
		}

		// Token: 0x17000517 RID: 1303
		// (get) Token: 0x06002388 RID: 9096 RVA: 0x001F44A0 File Offset: 0x001F26A0
		public Rect viewport
		{
			get
			{
				return this.camera.rect;
			}
		}

		// Token: 0x04004B1C RID: 19228
		public PostProcessingProfile profile;

		// Token: 0x04004B1D RID: 19229
		public Camera camera;

		// Token: 0x04004B1E RID: 19230
		public MaterialFactory materialFactory;

		// Token: 0x04004B1F RID: 19231
		public RenderTextureFactory renderTextureFactory;
	}
}
