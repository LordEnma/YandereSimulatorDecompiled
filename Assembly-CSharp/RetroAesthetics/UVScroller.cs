using System;
using UnityEngine;

namespace RetroAesthetics
{
	// Token: 0x02000556 RID: 1366
	public class UVScroller : MonoBehaviour
	{
		// Token: 0x060022DC RID: 8924 RVA: 0x001F4D08 File Offset: 0x001F2F08
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

		// Token: 0x060022DD RID: 8925 RVA: 0x001F4D7C File Offset: 0x001F2F7C
		private void Update()
		{
			this.offset += this.scrollSpeed * Time.deltaTime * (float)Application.targetFrameRate;
			this.target.SetTextureOffset(this.textureName, this.offset);
		}

		// Token: 0x04004B63 RID: 19299
		public Vector2 scrollSpeed = new Vector2(-1f, 0f);

		// Token: 0x04004B64 RID: 19300
		public string textureName = "_GridTex";

		// Token: 0x04004B65 RID: 19301
		private Material target;

		// Token: 0x04004B66 RID: 19302
		private Vector2 offset = Vector2.zero;
	}
}
