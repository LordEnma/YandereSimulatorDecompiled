using System;
using UnityEngine;

namespace RetroAesthetics
{
	// Token: 0x02000555 RID: 1365
	public class UVScroller : MonoBehaviour
	{
		// Token: 0x060022CD RID: 8909 RVA: 0x001F3D7C File Offset: 0x001F1F7C
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

		// Token: 0x060022CE RID: 8910 RVA: 0x001F3DF0 File Offset: 0x001F1FF0
		private void Update()
		{
			this.offset += this.scrollSpeed * Time.deltaTime * (float)Application.targetFrameRate;
			this.target.SetTextureOffset(this.textureName, this.offset);
		}

		// Token: 0x04004B4D RID: 19277
		public Vector2 scrollSpeed = new Vector2(-1f, 0f);

		// Token: 0x04004B4E RID: 19278
		public string textureName = "_GridTex";

		// Token: 0x04004B4F RID: 19279
		private Material target;

		// Token: 0x04004B50 RID: 19280
		private Vector2 offset = Vector2.zero;
	}
}
