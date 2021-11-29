using System;
using System.Collections.Generic;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000576 RID: 1398
	public sealed class RenderTextureFactory : IDisposable
	{
		// Token: 0x06002377 RID: 9079 RVA: 0x001F0BBF File Offset: 0x001EEDBF
		public RenderTextureFactory()
		{
			this.m_TemporaryRTs = new HashSet<RenderTexture>();
		}

		// Token: 0x06002378 RID: 9080 RVA: 0x001F0BD4 File Offset: 0x001EEDD4
		public RenderTexture Get(RenderTexture baseRenderTexture)
		{
			return this.Get(baseRenderTexture.width, baseRenderTexture.height, baseRenderTexture.depth, baseRenderTexture.format, baseRenderTexture.sRGB ? RenderTextureReadWrite.sRGB : RenderTextureReadWrite.Linear, baseRenderTexture.filterMode, baseRenderTexture.wrapMode, "FactoryTempTexture");
		}

		// Token: 0x06002379 RID: 9081 RVA: 0x001F0C1C File Offset: 0x001EEE1C
		public RenderTexture Get(int width, int height, int depthBuffer = 0, RenderTextureFormat format = RenderTextureFormat.ARGBHalf, RenderTextureReadWrite rw = RenderTextureReadWrite.Default, FilterMode filterMode = FilterMode.Bilinear, TextureWrapMode wrapMode = TextureWrapMode.Clamp, string name = "FactoryTempTexture")
		{
			RenderTexture temporary = RenderTexture.GetTemporary(width, height, depthBuffer, format, rw);
			temporary.filterMode = filterMode;
			temporary.wrapMode = wrapMode;
			temporary.name = name;
			this.m_TemporaryRTs.Add(temporary);
			return temporary;
		}

		// Token: 0x0600237A RID: 9082 RVA: 0x001F0C5C File Offset: 0x001EEE5C
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

		// Token: 0x0600237B RID: 9083 RVA: 0x001F0C9C File Offset: 0x001EEE9C
		public void ReleaseAll()
		{
			foreach (RenderTexture temp in this.m_TemporaryRTs)
			{
				RenderTexture.ReleaseTemporary(temp);
			}
			this.m_TemporaryRTs.Clear();
		}

		// Token: 0x0600237C RID: 9084 RVA: 0x001F0CD7 File Offset: 0x001EEED7
		public void Dispose()
		{
			this.ReleaseAll();
		}

		// Token: 0x04004AC5 RID: 19141
		private HashSet<RenderTexture> m_TemporaryRTs;
	}
}
