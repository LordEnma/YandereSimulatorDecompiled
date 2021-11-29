using System;
using UnityEngine;

namespace RetroAesthetics
{
	// Token: 0x02000544 RID: 1348
	public class UVScroller : MonoBehaviour
	{
		// Token: 0x06002265 RID: 8805 RVA: 0x001EA9E8 File Offset: 0x001E8BE8
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

		// Token: 0x06002266 RID: 8806 RVA: 0x001EAA5C File Offset: 0x001E8C5C
		private void Update()
		{
			this.offset += this.scrollSpeed * Time.deltaTime * (float)Application.targetFrameRate;
			this.target.SetTextureOffset(this.textureName, this.offset);
		}

		// Token: 0x04004A0F RID: 18959
		public Vector2 scrollSpeed = new Vector2(-1f, 0f);

		// Token: 0x04004A10 RID: 18960
		public string textureName = "_GridTex";

		// Token: 0x04004A11 RID: 18961
		private Material target;

		// Token: 0x04004A12 RID: 18962
		private Vector2 offset = Vector2.zero;
	}
}
