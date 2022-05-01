using System;
using UnityEngine;

namespace RetroAesthetics
{
	// Token: 0x02000557 RID: 1367
	public class UVScroller : MonoBehaviour
	{
		// Token: 0x060022E5 RID: 8933 RVA: 0x001F6194 File Offset: 0x001F4394
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

		// Token: 0x060022E6 RID: 8934 RVA: 0x001F6208 File Offset: 0x001F4408
		private void Update()
		{
			this.offset += this.scrollSpeed * Time.deltaTime * (float)Application.targetFrameRate;
			this.target.SetTextureOffset(this.textureName, this.offset);
		}

		// Token: 0x04004B79 RID: 19321
		public Vector2 scrollSpeed = new Vector2(-1f, 0f);

		// Token: 0x04004B7A RID: 19322
		public string textureName = "_GridTex";

		// Token: 0x04004B7B RID: 19323
		private Material target;

		// Token: 0x04004B7C RID: 19324
		private Vector2 offset = Vector2.zero;
	}
}
