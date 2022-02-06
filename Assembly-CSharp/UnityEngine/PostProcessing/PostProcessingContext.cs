using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000575 RID: 1397
	public class PostProcessingContext
	{
		// Token: 0x17000513 RID: 1299
		// (get) Token: 0x06002383 RID: 9091 RVA: 0x001F462D File Offset: 0x001F282D
		// (set) Token: 0x06002384 RID: 9092 RVA: 0x001F4635 File Offset: 0x001F2835
		public bool interrupted { get; private set; }

		// Token: 0x06002385 RID: 9093 RVA: 0x001F463E File Offset: 0x001F283E
		public void Interrupt()
		{
			this.interrupted = true;
		}

		// Token: 0x06002386 RID: 9094 RVA: 0x001F4647 File Offset: 0x001F2847
		public PostProcessingContext Reset()
		{
			this.profile = null;
			this.camera = null;
			this.materialFactory = null;
			this.renderTextureFactory = null;
			this.interrupted = false;
			return this;
		}

		// Token: 0x17000514 RID: 1300
		// (get) Token: 0x06002387 RID: 9095 RVA: 0x001F466D File Offset: 0x001F286D
		public bool isGBufferAvailable
		{
			get
			{
				return this.camera.actualRenderingPath == RenderingPath.DeferredShading;
			}
		}

		// Token: 0x17000515 RID: 1301
		// (get) Token: 0x06002388 RID: 9096 RVA: 0x001F467D File Offset: 0x001F287D
		public bool isHdr
		{
			get
			{
				return this.camera.allowHDR;
			}
		}

		// Token: 0x17000516 RID: 1302
		// (get) Token: 0x06002389 RID: 9097 RVA: 0x001F468A File Offset: 0x001F288A
		public int width
		{
			get
			{
				return this.camera.pixelWidth;
			}
		}

		// Token: 0x17000517 RID: 1303
		// (get) Token: 0x0600238A RID: 9098 RVA: 0x001F4697 File Offset: 0x001F2897
		public int height
		{
			get
			{
				return this.camera.pixelHeight;
			}
		}

		// Token: 0x17000518 RID: 1304
		// (get) Token: 0x0600238B RID: 9099 RVA: 0x001F46A4 File Offset: 0x001F28A4
		public Rect viewport
		{
			get
			{
				return this.camera.rect;
			}
		}

		// Token: 0x04004B1F RID: 19231
		public PostProcessingProfile profile;

		// Token: 0x04004B20 RID: 19232
		public Camera camera;

		// Token: 0x04004B21 RID: 19233
		public MaterialFactory materialFactory;

		// Token: 0x04004B22 RID: 19234
		public RenderTextureFactory renderTextureFactory;
	}
}
