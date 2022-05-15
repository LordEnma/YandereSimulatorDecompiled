using System;
using UnityEngine;

namespace RetroAesthetics
{
	// Token: 0x02000558 RID: 1368
	public class UVScroller : MonoBehaviour
	{
		// Token: 0x060022F0 RID: 8944 RVA: 0x001F78E0 File Offset: 0x001F5AE0
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

		// Token: 0x060022F1 RID: 8945 RVA: 0x001F7954 File Offset: 0x001F5B54
		private void Update()
		{
			this.offset += this.scrollSpeed * Time.deltaTime * (float)Application.targetFrameRate;
			this.target.SetTextureOffset(this.textureName, this.offset);
		}

		// Token: 0x04004BA0 RID: 19360
		public Vector2 scrollSpeed = new Vector2(-1f, 0f);

		// Token: 0x04004BA1 RID: 19361
		public string textureName = "_GridTex";

		// Token: 0x04004BA2 RID: 19362
		private Material target;

		// Token: 0x04004BA3 RID: 19363
		private Vector2 offset = Vector2.zero;
	}
}
