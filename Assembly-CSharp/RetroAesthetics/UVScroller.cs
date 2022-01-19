using System;
using UnityEngine;

namespace RetroAesthetics
{
	// Token: 0x02000549 RID: 1353
	public class UVScroller : MonoBehaviour
	{
		// Token: 0x06002286 RID: 8838 RVA: 0x001EDD7C File Offset: 0x001EBF7C
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

		// Token: 0x06002287 RID: 8839 RVA: 0x001EDDF0 File Offset: 0x001EBFF0
		private void Update()
		{
			this.offset += this.scrollSpeed * Time.deltaTime * (float)Application.targetFrameRate;
			this.target.SetTextureOffset(this.textureName, this.offset);
		}

		// Token: 0x04004A72 RID: 19058
		public Vector2 scrollSpeed = new Vector2(-1f, 0f);

		// Token: 0x04004A73 RID: 19059
		public string textureName = "_GridTex";

		// Token: 0x04004A74 RID: 19060
		private Material target;

		// Token: 0x04004A75 RID: 19061
		private Vector2 offset = Vector2.zero;
	}
}
