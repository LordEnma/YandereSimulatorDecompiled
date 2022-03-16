using System;
using UnityEngine;

namespace RetroAesthetics
{
	// Token: 0x02000550 RID: 1360
	public class UVScroller : MonoBehaviour
	{
		// Token: 0x060022BD RID: 8893 RVA: 0x001F250C File Offset: 0x001F070C
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

		// Token: 0x060022BE RID: 8894 RVA: 0x001F2580 File Offset: 0x001F0780
		private void Update()
		{
			this.offset += this.scrollSpeed * Time.deltaTime * (float)Application.targetFrameRate;
			this.target.SetTextureOffset(this.textureName, this.offset);
		}

		// Token: 0x04004B1B RID: 19227
		public Vector2 scrollSpeed = new Vector2(-1f, 0f);

		// Token: 0x04004B1C RID: 19228
		public string textureName = "_GridTex";

		// Token: 0x04004B1D RID: 19229
		private Material target;

		// Token: 0x04004B1E RID: 19230
		private Vector2 offset = Vector2.zero;
	}
}
