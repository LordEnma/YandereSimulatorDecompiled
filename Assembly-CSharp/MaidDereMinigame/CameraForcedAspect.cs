using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A5 RID: 1445
	[RequireComponent(typeof(Camera))]
	public class CameraForcedAspect : MonoBehaviour
	{
		// Token: 0x0600249D RID: 9373 RVA: 0x0020185C File Offset: 0x001FFA5C
		private void Awake()
		{
			this.cam = base.GetComponent<Camera>();
		}

		// Token: 0x0600249E RID: 9374 RVA: 0x0020186C File Offset: 0x001FFA6C
		private void Start()
		{
			float num = this.targetAspect.x / this.targetAspect.y;
			float num2 = (float)Screen.width / (float)Screen.height / num;
			if (num2 < 1f)
			{
				Rect rect = this.cam.rect;
				rect.width = 1f;
				rect.height = num2;
				rect.x = 0f;
				rect.y = (1f - num2) / 2f;
				this.cam.rect = rect;
				return;
			}
			Rect rect2 = this.cam.rect;
			float num3 = 1f / num2;
			rect2.width = num3;
			rect2.height = 1f;
			rect2.x = (1f - num3) / 2f;
			rect2.y = 0f;
			this.cam.rect = rect2;
		}

		// Token: 0x04004D0E RID: 19726
		public Vector2 targetAspect = new Vector2(16f, 9f);

		// Token: 0x04004D0F RID: 19727
		private Camera cam;
	}
}
