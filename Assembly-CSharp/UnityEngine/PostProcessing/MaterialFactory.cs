using System;
using System.Collections.Generic;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000577 RID: 1399
	public sealed class MaterialFactory : IDisposable
	{
		// Token: 0x06002388 RID: 9096 RVA: 0x001F2811 File Offset: 0x001F0A11
		public MaterialFactory()
		{
			this.m_Materials = new Dictionary<string, Material>();
		}

		// Token: 0x06002389 RID: 9097 RVA: 0x001F2824 File Offset: 0x001F0A24
		public Material Get(string shaderName)
		{
			Material material;
			if (!this.m_Materials.TryGetValue(shaderName, out material))
			{
				Shader shader = Shader.Find(shaderName);
				if (shader == null)
				{
					throw new ArgumentException(string.Format("Shader not found ({0})", shaderName));
				}
				material = new Material(shader)
				{
					name = string.Format("PostFX - {0}", shaderName.Substring(shaderName.LastIndexOf("/") + 1)),
					hideFlags = HideFlags.DontSave
				};
				this.m_Materials.Add(shaderName, material);
			}
			return material;
		}

		// Token: 0x0600238A RID: 9098 RVA: 0x001F28A0 File Offset: 0x001F0AA0
		public void Dispose()
		{
			foreach (KeyValuePair<string, Material> keyValuePair in this.m_Materials)
			{
				GraphicsUtils.Destroy(keyValuePair.Value);
			}
			this.m_Materials.Clear();
		}

		// Token: 0x04004B0C RID: 19212
		private Dictionary<string, Material> m_Materials;
	}
}
