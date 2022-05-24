using System;
using UnityEngine;

namespace RetroAesthetics
{
	// Token: 0x02000558 RID: 1368
	public class UVScroller : MonoBehaviour
	{
		// Token: 0x060022F1 RID: 8945 RVA: 0x001F7E48 File Offset: 0x001F6048
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

		// Token: 0x060022F2 RID: 8946 RVA: 0x001F7EBC File Offset: 0x001F60BC
		private void Update()
		{
			this.offset += this.scrollSpeed * Time.deltaTime * (float)Application.targetFrameRate;
			this.target.SetTextureOffset(this.textureName, this.offset);
		}

		// Token: 0x04004BA9 RID: 19369
		public Vector2 scrollSpeed = new Vector2(-1f, 0f);

		// Token: 0x04004BAA RID: 19370
		public string textureName = "_GridTex";

		// Token: 0x04004BAB RID: 19371
		private Material target;

		// Token: 0x04004BAC RID: 19372
		private Vector2 offset = Vector2.zero;
	}
}
