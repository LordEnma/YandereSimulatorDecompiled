using System;
using System.Collections.Generic;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200057A RID: 1402
	public sealed class MaterialFactory : IDisposable
	{
		// Token: 0x06002399 RID: 9113 RVA: 0x001F4721 File Offset: 0x001F2921
		public MaterialFactory()
		{
			this.m_Materials = new Dictionary<string, Material>();
		}

		// Token: 0x0600239A RID: 9114 RVA: 0x001F4734 File Offset: 0x001F2934
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

		// Token: 0x0600239B RID: 9115 RVA: 0x001F47B0 File Offset: 0x001F29B0
		public void Dispose()
		{
			foreach (KeyValuePair<string, Material> keyValuePair in this.m_Materials)
			{
				GraphicsUtils.Destroy(keyValuePair.Value);
			}
			this.m_Materials.Clear();
		}

		// Token: 0x04004B32 RID: 19250
		private Dictionary<string, Material> m_Materials;
	}
}
