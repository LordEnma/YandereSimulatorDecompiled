using System;
using UnityEngine;

namespace RetroAesthetics
{
	// Token: 0x02000549 RID: 1353
	public class UVScroller : MonoBehaviour
	{
		// Token: 0x0600228C RID: 8844 RVA: 0x001EE934 File Offset: 0x001ECB34
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

		// Token: 0x0600228D RID: 8845 RVA: 0x001EE9A8 File Offset: 0x001ECBA8
		private void Update()
		{
			this.offset += this.scrollSpeed * Time.deltaTime * (float)Application.targetFrameRate;
			this.target.SetTextureOffset(this.textureName, this.offset);
		}

		// Token: 0x04004A83 RID: 19075
		public Vector2 scrollSpeed = new Vector2(-1f, 0f);

		// Token: 0x04004A84 RID: 19076
		public string textureName = "_GridTex";

		// Token: 0x04004A85 RID: 19077
		private Material target;

		// Token: 0x04004A86 RID: 19078
		private Vector2 offset = Vector2.zero;
	}
}
