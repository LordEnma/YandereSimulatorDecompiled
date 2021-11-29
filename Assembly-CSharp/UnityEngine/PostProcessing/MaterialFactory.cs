using System;
using System.Collections.Generic;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000575 RID: 1397
	public sealed class MaterialFactory : IDisposable
	{
		// Token: 0x06002374 RID: 9076 RVA: 0x001F0AED File Offset: 0x001EECED
		public MaterialFactory()
		{
			this.m_Materials = new Dictionary<string, Material>();
		}

		// Token: 0x06002375 RID: 9077 RVA: 0x001F0B00 File Offset: 0x001EED00
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

		// Token: 0x06002376 RID: 9078 RVA: 0x001F0B7C File Offset: 0x001EED7C
		public void Dispose()
		{
			foreach (KeyValuePair<string, Material> keyValuePair in this.m_Materials)
			{
				GraphicsUtils.Destroy(keyValuePair.Value);
			}
			this.m_Materials.Clear();
		}

		// Token: 0x04004AC4 RID: 19140
		private Dictionary<string, Material> m_Materials;
	}
}
