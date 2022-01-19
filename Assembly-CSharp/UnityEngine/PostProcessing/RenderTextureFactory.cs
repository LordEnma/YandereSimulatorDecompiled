using System;
using System.Collections.Generic;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200057B RID: 1403
	public sealed class RenderTextureFactory : IDisposable
	{
		// Token: 0x06002398 RID: 9112 RVA: 0x001F3F53 File Offset: 0x001F2153
		public RenderTextureFactory()
		{
			this.m_TemporaryRTs = new HashSet<RenderTexture>();
		}

		// Token: 0x06002399 RID: 9113 RVA: 0x001F3F68 File Offset: 0x001F2168
		public RenderTexture Get(RenderTexture baseRenderTexture)
		{
			return this.Get(baseRenderTexture.width, baseRenderTexture.height, baseRenderTexture.depth, baseRenderTexture.format, baseRenderTexture.sRGB ? RenderTextureReadWrite.sRGB : RenderTextureReadWrite.Linear, baseRenderTexture.filterMode, baseRenderTexture.wrapMode, "FactoryTempTexture");
		}

		// Token: 0x0600239A RID: 9114 RVA: 0x001F3FB0 File Offset: 0x001F21B0
		public RenderTexture Get(int width, int height, int depthBuffer = 0, RenderTextureFormat format = RenderTextureFormat.ARGBHalf, RenderTextureReadWrite rw = RenderTextureReadWrite.Default, FilterMode filterMode = FilterMode.Bilinear, TextureWrapMode wrapMode = TextureWrapMode.Clamp, string name = "FactoryTempTexture")
		{
			RenderTexture temporary = RenderTexture.GetTemporary(width, height, depthBuffer, format, rw);
			temporary.filterMode = filterMode;
			temporary.wrapMode = wrapMode;
			temporary.name = name;
			this.m_TemporaryRTs.Add(temporary);
			return temporary;
		}

		// Token: 0x0600239B RID: 9115 RVA: 0x001F3FF0 File Offset: 0x001F21F0
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

		// Token: 0x0600239C RID: 9116 RVA: 0x001F4030 File Offset: 0x001F2230
		public void ReleaseAll()
		{
			foreach (RenderTexture temp in this.m_TemporaryRTs)
			{
				RenderTexture.ReleaseTemporary(temp);
			}
			this.m_TemporaryRTs.Clear();
		}

		// Token: 0x0600239D RID: 9117 RVA: 0x001F406B File Offset: 0x001F226B
		public void Dispose()
		{
			this.ReleaseAll();
		}

		// Token: 0x04004B28 RID: 19240
		private HashSet<RenderTexture> m_TemporaryRTs;
	}
}
