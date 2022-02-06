using System;
using UnityEngine;

namespace RetroAesthetics
{
	// Token: 0x02000549 RID: 1353
	public class UVScroller : MonoBehaviour
	{
		// Token: 0x0600228F RID: 8847 RVA: 0x001EEB38 File Offset: 0x001ECD38
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

		// Token: 0x06002290 RID: 8848 RVA: 0x001EEBAC File Offset: 0x001ECDAC
		private void Update()
		{
			this.offset += this.scrollSpeed * Time.deltaTime * (float)Application.targetFrameRate;
			this.target.SetTextureOffset(this.textureName, this.offset);
		}

		// Token: 0x04004A86 RID: 19078
		public Vector2 scrollSpeed = new Vector2(-1f, 0f);

		// Token: 0x04004A87 RID: 19079
		public string textureName = "_GridTex";

		// Token: 0x04004A88 RID: 19080
		private Material target;

		// Token: 0x04004A89 RID: 19081
		private Vector2 offset = Vector2.zero;
	}
}
