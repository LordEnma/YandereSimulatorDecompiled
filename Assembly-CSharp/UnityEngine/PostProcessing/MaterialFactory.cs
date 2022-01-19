using System;
using System.Collections.Generic;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200057A RID: 1402
	public sealed class MaterialFactory : IDisposable
	{
		// Token: 0x06002395 RID: 9109 RVA: 0x001F3E81 File Offset: 0x001F2081
		public MaterialFactory()
		{
			this.m_Materials = new Dictionary<string, Material>();
		}

		// Token: 0x06002396 RID: 9110 RVA: 0x001F3E94 File Offset: 0x001F2094
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

		// Token: 0x06002397 RID: 9111 RVA: 0x001F3F10 File Offset: 0x001F2110
		public void Dispose()
		{
			foreach (KeyValuePair<string, Material> keyValuePair in this.m_Materials)
			{
				GraphicsUtils.Destroy(keyValuePair.Value);
			}
			this.m_Materials.Clear();
		}

		// Token: 0x04004B27 RID: 19239
		private Dictionary<string, Material> m_Materials;
	}
}
