using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000575 RID: 1397
	public class PostProcessingContext
	{
		// Token: 0x17000512 RID: 1298
		// (get) Token: 0x0600237E RID: 9086 RVA: 0x001F4111 File Offset: 0x001F2311
		// (set) Token: 0x0600237F RID: 9087 RVA: 0x001F4119 File Offset: 0x001F2319
		public bool interrupted { get; private set; }

		// Token: 0x06002380 RID: 9088 RVA: 0x001F4122 File Offset: 0x001F2322
		public void Interrupt()
		{
			this.interrupted = true;
		}

		// Token: 0x06002381 RID: 9089 RVA: 0x001F412B File Offset: 0x001F232B
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
		// (get) Token: 0x06002382 RID: 9090 RVA: 0x001F4151 File Offset: 0x001F2351
		public bool isGBufferAvailable
		{
			get
			{
				return this.camera.actualRenderingPath == RenderingPath.DeferredShading;
			}
		}

		// Token: 0x17000514 RID: 1300
		// (get) Token: 0x06002383 RID: 9091 RVA: 0x001F4161 File Offset: 0x001F2361
		public bool isHdr
		{
			get
			{
				return this.camera.allowHDR;
			}
		}

		// Token: 0x17000515 RID: 1301
		// (get) Token: 0x06002384 RID: 9092 RVA: 0x001F416E File Offset: 0x001F236E
		public int width
		{
			get
			{
				return this.camera.pixelWidth;
			}
		}

		// Token: 0x17000516 RID: 1302
		// (get) Token: 0x06002385 RID: 9093 RVA: 0x001F417B File Offset: 0x001F237B
		public int height
		{
			get
			{
				return this.camera.pixelHeight;
			}
		}

		// Token: 0x17000517 RID: 1303
		// (get) Token: 0x06002386 RID: 9094 RVA: 0x001F4188 File Offset: 0x001F2388
		public Rect viewport
		{
			get
			{
				return this.camera.rect;
			}
		}

		// Token: 0x04004B16 RID: 19222
		public PostProcessingProfile profile;

		// Token: 0x04004B17 RID: 19223
		public Camera camera;

		// Token: 0x04004B18 RID: 19224
		public MaterialFactory materialFactory;

		// Token: 0x04004B19 RID: 19225
		public RenderTextureFactory renderTextureFactory;
	}
}
