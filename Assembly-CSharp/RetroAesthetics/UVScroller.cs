using System;
using UnityEngine;

namespace RetroAesthetics
{
	// Token: 0x0200054A RID: 1354
	public class UVScroller : MonoBehaviour
	{
		// Token: 0x06002296 RID: 8854 RVA: 0x001EEFEC File Offset: 0x001ED1EC
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

		// Token: 0x06002297 RID: 8855 RVA: 0x001EF060 File Offset: 0x001ED260
		private void Update()
		{
			this.offset += this.scrollSpeed * Time.deltaTime * (float)Application.targetFrameRate;
			this.target.SetTextureOffset(this.textureName, this.offset);
		}

		// Token: 0x04004A8F RID: 19087
		public Vector2 scrollSpeed = new Vector2(-1f, 0f);

		// Token: 0x04004A90 RID: 19088
		public string textureName = "_GridTex";

		// Token: 0x04004A91 RID: 19089
		private Material target;

		// Token: 0x04004A92 RID: 19090
		private Vector2 offset = Vector2.zero;
	}
}
