using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000575 RID: 1397
	public class PostProcessingContext
	{
		// Token: 0x17000512 RID: 1298
		// (get) Token: 0x0600237A RID: 9082 RVA: 0x001F3871 File Offset: 0x001F1A71
		// (set) Token: 0x0600237B RID: 9083 RVA: 0x001F3879 File Offset: 0x001F1A79
		public bool interrupted { get; private set; }

		// Token: 0x0600237C RID: 9084 RVA: 0x001F3882 File Offset: 0x001F1A82
		public void Interrupt()
		{
			this.interrupted = true;
		}

		// Token: 0x0600237D RID: 9085 RVA: 0x001F388B File Offset: 0x001F1A8B
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
		// (get) Token: 0x0600237E RID: 9086 RVA: 0x001F38B1 File Offset: 0x001F1AB1
		public bool isGBufferAvailable
		{
			get
			{
				return this.camera.actualRenderingPath == RenderingPath.DeferredShading;
			}
		}

		// Token: 0x17000514 RID: 1300
		// (get) Token: 0x0600237F RID: 9087 RVA: 0x001F38C1 File Offset: 0x001F1AC1
		public bool isHdr
		{
			get
			{
				return this.camera.allowHDR;
			}
		}

		// Token: 0x17000515 RID: 1301
		// (get) Token: 0x06002380 RID: 9088 RVA: 0x001F38CE File Offset: 0x001F1ACE
		public int width
		{
			get
			{
				return this.camera.pixelWidth;
			}
		}

		// Token: 0x17000516 RID: 1302
		// (get) Token: 0x06002381 RID: 9089 RVA: 0x001F38DB File Offset: 0x001F1ADB
		public int height
		{
			get
			{
				return this.camera.pixelHeight;
			}
		}

		// Token: 0x17000517 RID: 1303
		// (get) Token: 0x06002382 RID: 9090 RVA: 0x001F38E8 File Offset: 0x001F1AE8
		public Rect viewport
		{
			get
			{
				return this.camera.rect;
			}
		}

		// Token: 0x04004B0B RID: 19211
		public PostProcessingProfile profile;

		// Token: 0x04004B0C RID: 19212
		public Camera camera;

		// Token: 0x04004B0D RID: 19213
		public MaterialFactory materialFactory;

		// Token: 0x04004B0E RID: 19214
		public RenderTextureFactory renderTextureFactory;
	}
}
