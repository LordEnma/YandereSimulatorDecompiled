using System;
using UnityEngine;

namespace RetroAesthetics
{
	// Token: 0x0200054C RID: 1356
	public class UVScroller : MonoBehaviour
	{
		// Token: 0x060022A5 RID: 8869 RVA: 0x001F05A4 File Offset: 0x001EE7A4
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

		// Token: 0x060022A6 RID: 8870 RVA: 0x001F0618 File Offset: 0x001EE818
		private void Update()
		{
			this.offset += this.scrollSpeed * Time.deltaTime * (float)Application.targetFrameRate;
			this.target.SetTextureOffset(this.textureName, this.offset);
		}

		// Token: 0x04004ABC RID: 19132
		public Vector2 scrollSpeed = new Vector2(-1f, 0f);

		// Token: 0x04004ABD RID: 19133
		public string textureName = "_GridTex";

		// Token: 0x04004ABE RID: 19134
		private Material target;

		// Token: 0x04004ABF RID: 19135
		private Vector2 offset = Vector2.zero;
	}
}
