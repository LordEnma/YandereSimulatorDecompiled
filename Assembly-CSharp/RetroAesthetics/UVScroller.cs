using System;
using UnityEngine;

namespace RetroAesthetics
{
	// Token: 0x0200054B RID: 1355
	public class UVScroller : MonoBehaviour
	{
		// Token: 0x0600229F RID: 8863 RVA: 0x001EFBCC File Offset: 0x001EDDCC
		private void Start()
		{
			Renderer component = base.GetComponent<Renderer>();
			if (component == null || component.material == null)
			{
				base.enabled = false;
				return;
			}
			this.target = component.material;
			if (!this.target.HasProperty(this.textureName))
			{
				Debug.LogWarning("Texture name '" + this.textureName + "' not found in material.");
				base.enabled = false;
				return;
			}
		}

		// Token: 0x060022A0 RID: 8864 RVA: 0x001EFC40 File Offset: 0x001EDE40
		private void Update()
		{
			this.offset += this.scrollSpeed * Time.deltaTime * (float)Application.targetFrameRate;
			this.target.SetTextureOffset(this.textureName, this.offset);
		}

		// Token: 0x04004A9F RID: 19103
		public Vector2 scrollSpeed = new Vector2(-1f, 0f);

		// Token: 0x04004AA0 RID: 19104
		public string textureName = "_GridTex";

		// Token: 0x04004AA1 RID: 19105
		private Material target;

		// Token: 0x04004AA2 RID: 19106
		private Vector2 offset = Vector2.zero;
	}
}
