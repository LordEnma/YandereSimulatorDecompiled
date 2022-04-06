using System;
using UnityEngine;

namespace RetroAesthetics
{
	// Token: 0x02000556 RID: 1366
	public class UVScroller : MonoBehaviour
	{
		// Token: 0x060022D5 RID: 8917 RVA: 0x001F42AC File Offset: 0x001F24AC
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

		// Token: 0x060022D6 RID: 8918 RVA: 0x001F4320 File Offset: 0x001F2520
		private void Update()
		{
			this.offset += this.scrollSpeed * Time.deltaTime * (float)Application.targetFrameRate;
			this.target.SetTextureOffset(this.textureName, this.offset);
		}

		// Token: 0x04004B51 RID: 19281
		public Vector2 scrollSpeed = new Vector2(-1f, 0f);

		// Token: 0x04004B52 RID: 19282
		public string textureName = "_GridTex";

		// Token: 0x04004B53 RID: 19283
		private Material target;

		// Token: 0x04004B54 RID: 19284
		private Vector2 offset = Vector2.zero;
	}
}
