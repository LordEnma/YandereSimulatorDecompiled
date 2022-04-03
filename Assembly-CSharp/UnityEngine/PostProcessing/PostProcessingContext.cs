using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000581 RID: 1409
	public class PostProcessingContext
	{
		// Token: 0x17000515 RID: 1301
		// (get) Token: 0x060023C1 RID: 9153 RVA: 0x001F9871 File Offset: 0x001F7A71
		// (set) Token: 0x060023C2 RID: 9154 RVA: 0x001F9879 File Offset: 0x001F7A79
		public bool interrupted { get; private set; }

		// Token: 0x060023C3 RID: 9155 RVA: 0x001F9882 File Offset: 0x001F7A82
		public void Interrupt()
		{
			this.interrupted = true;
		}

		// Token: 0x060023C4 RID: 9156 RVA: 0x001F988B File Offset: 0x001F7A8B
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
		// (get) Token: 0x060023C5 RID: 9157 RVA: 0x001F98B1 File Offset: 0x001F7AB1
		public bool isGBufferAvailable
		{
			get
			{
				return this.camera.actualRenderingPath == RenderingPath.DeferredShading;
			}
		}

		// Token: 0x17000517 RID: 1303
		// (get) Token: 0x060023C6 RID: 9158 RVA: 0x001F98C1 File Offset: 0x001F7AC1
		public bool isHdr
		{
			get
			{
				return this.camera.allowHDR;
			}
		}

		// Token: 0x17000518 RID: 1304
		// (get) Token: 0x060023C7 RID: 9159 RVA: 0x001F98CE File Offset: 0x001F7ACE
		public int width
		{
			get
			{
				return this.camera.pixelWidth;
			}
		}

		// Token: 0x17000519 RID: 1305
		// (get) Token: 0x060023C8 RID: 9160 RVA: 0x001F98DB File Offset: 0x001F7ADB
		public int height
		{
			get
			{
				return this.camera.pixelHeight;
			}
		}

		// Token: 0x1700051A RID: 1306
		// (get) Token: 0x060023C9 RID: 9161 RVA: 0x001F98E8 File Offset: 0x001F7AE8
		public Rect viewport
		{
			get
			{
				return this.camera.rect;
			}
		}

		// Token: 0x04004BE6 RID: 19430
		public PostProcessingProfile profile;

		// Token: 0x04004BE7 RID: 19431
		public Camera camera;

		// Token: 0x04004BE8 RID: 19432
		public MaterialFactory materialFactory;

		// Token: 0x04004BE9 RID: 19433
		public RenderTextureFactory renderTextureFactory;
	}
}
