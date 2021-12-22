using System;
using UnityEngine;

namespace RetroAesthetics
{
	// Token: 0x02000546 RID: 1350
	public class UVScroller : MonoBehaviour
	{
		// Token: 0x06002276 RID: 8822 RVA: 0x001EC11C File Offset: 0x001EA31C
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

		// Token: 0x06002277 RID: 8823 RVA: 0x001EC190 File Offset: 0x001EA390
		private void Update()
		{
			this.offset += this.scrollSpeed * Time.deltaTime * (float)Application.targetFrameRate;
			this.target.SetTextureOffset(this.textureName, this.offset);
		}

		// Token: 0x04004A4E RID: 19022
		public Vector2 scrollSpeed = new Vector2(-1f, 0f);

		// Token: 0x04004A4F RID: 19023
		public string textureName = "_GridTex";

		// Token: 0x04004A50 RID: 19024
		private Material target;

		// Token: 0x04004A51 RID: 19025
		private Vector2 offset = Vector2.zero;
	}
}
