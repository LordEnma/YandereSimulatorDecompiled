using System;
using System.Collections.Generic;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200057B RID: 1403
	public sealed class RenderTextureFactory : IDisposable
	{
		// Token: 0x0600239C RID: 9116 RVA: 0x001F47F3 File Offset: 0x001F29F3
		public RenderTextureFactory()
		{
			this.m_TemporaryRTs = new HashSet<RenderTexture>();
		}

		// Token: 0x0600239D RID: 9117 RVA: 0x001F4808 File Offset: 0x001F2A08
		public RenderTexture Get(RenderTexture baseRenderTexture)
		{
			return this.Get(baseRenderTexture.width, baseRenderTexture.height, baseRenderTexture.depth, baseRenderTexture.format, baseRenderTexture.sRGB ? RenderTextureReadWrite.sRGB : RenderTextureReadWrite.Linear, baseRenderTexture.filterMode, baseRenderTexture.wrapMode, "FactoryTempTexture");
		}

		// Token: 0x0600239E RID: 9118 RVA: 0x001F4850 File Offset: 0x001F2A50
		public RenderTexture Get(int width, int height, int depthBuffer = 0, RenderTextureFormat format = RenderTextureFormat.ARGBHalf, RenderTextureReadWrite rw = RenderTextureReadWrite.Default, FilterMode filterMode = FilterMode.Bilinear, TextureWrapMode wrapMode = TextureWrapMode.Clamp, string name = "FactoryTempTexture")
		{
			RenderTexture temporary = RenderTexture.GetTemporary(width, height, depthBuffer, format, rw);
			temporary.filterMode = filterMode;
			temporary.wrapMode = wrapMode;
			temporary.name = name;
			this.m_TemporaryRTs.Add(temporary);
			return temporary;
		}

		// Token: 0x0600239F RID: 9119 RVA: 0x001F4890 File Offset: 0x001F2A90
		public void Release(RenderTexture rt)
		{
			if (rt == null)
			{
				return;
			}
			if (!this.m_TemporaryRTs.Contains(rt))
			{
				throw new ArgumentException(string.Format("Attempting to remove a RenderTexture that was not allocated: {0}", rt));
			}
			this.m_TemporaryRTs.Remove(rt);
			RenderTexture.ReleaseTemporary(rt);
		}

		// Token: 0x060023A0 RID: 9120 RVA: 0x001F48D0 File Offset: 0x001F2AD0
		public void ReleaseAll()
		{
			foreach (RenderTexture temp in this.m_TemporaryRTs)
			{
				RenderTexture.ReleaseTemporary(temp);
			}
			this.m_TemporaryRTs.Clear();
		}

		// Token: 0x060023A1 RID: 9121 RVA: 0x001F490B File Offset: 0x001F2B0B
		public void Dispose()
		{
			this.ReleaseAll();
		}

		// Token: 0x04004B33 RID: 19251
		private HashSet<RenderTexture> m_TemporaryRTs;
	}
}
