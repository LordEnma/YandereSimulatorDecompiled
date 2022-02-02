using System;
using UnityEngine;

namespace RetroAesthetics
{
	// Token: 0x02000549 RID: 1353
	public class UVScroller : MonoBehaviour
	{
		// Token: 0x0600228A RID: 8842 RVA: 0x001EE61C File Offset: 0x001EC81C
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

		// Token: 0x0600228B RID: 8843 RVA: 0x001EE690 File Offset: 0x001EC890
		private void Update()
		{
			this.offset += this.scrollSpeed * Time.deltaTime * (float)Application.targetFrameRate;
			this.target.SetTextureOffset(this.textureName, this.offset);
		}

		// Token: 0x04004A7D RID: 19069
		public Vector2 scrollSpeed = new Vector2(-1f, 0f);

		// Token: 0x04004A7E RID: 19070
		public string textureName = "_GridTex";

		// Token: 0x04004A7F RID: 19071
		private Material target;

		// Token: 0x04004A80 RID: 19072
		private Vector2 offset = Vector2.zero;
	}
}
