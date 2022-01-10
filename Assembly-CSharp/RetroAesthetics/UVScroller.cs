using System;
using UnityEngine;

namespace RetroAesthetics
{
	// Token: 0x02000548 RID: 1352
	public class UVScroller : MonoBehaviour
	{
		// Token: 0x06002284 RID: 8836 RVA: 0x001ED0AC File Offset: 0x001EB2AC
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

		// Token: 0x06002285 RID: 8837 RVA: 0x001ED120 File Offset: 0x001EB320
		private void Update()
		{
			this.offset += this.scrollSpeed * Time.deltaTime * (float)Application.targetFrameRate;
			this.target.SetTextureOffset(this.textureName, this.offset);
		}

		// Token: 0x04004A6B RID: 19051
		public Vector2 scrollSpeed = new Vector2(-1f, 0f);

		// Token: 0x04004A6C RID: 19052
		public string textureName = "_GridTex";

		// Token: 0x04004A6D RID: 19053
		private Material target;

		// Token: 0x04004A6E RID: 19054
		private Vector2 offset = Vector2.zero;
	}
}
