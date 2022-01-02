using System;
using UnityEngine;

namespace RetroAesthetics
{
	// Token: 0x02000546 RID: 1350
	public class UVScroller : MonoBehaviour
	{
		// Token: 0x06002279 RID: 8825 RVA: 0x001EC70C File Offset: 0x001EA90C
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

		// Token: 0x0600227A RID: 8826 RVA: 0x001EC780 File Offset: 0x001EA980
		private void Update()
		{
			this.offset += this.scrollSpeed * Time.deltaTime * (float)Application.targetFrameRate;
			this.target.SetTextureOffset(this.textureName, this.offset);
		}

		// Token: 0x04004A57 RID: 19031
		public Vector2 scrollSpeed = new Vector2(-1f, 0f);

		// Token: 0x04004A58 RID: 19032
		public string textureName = "_GridTex";

		// Token: 0x04004A59 RID: 19033
		private Material target;

		// Token: 0x04004A5A RID: 19034
		private Vector2 offset = Vector2.zero;
	}
}
