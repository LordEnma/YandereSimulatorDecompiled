using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000597 RID: 1431
	[RequireComponent(typeof(Camera))]
	public class CameraForcedAspect : MonoBehaviour
	{
		// Token: 0x06002442 RID: 9282 RVA: 0x001F9C94 File Offset: 0x001F7E94
		private void Awake()
		{
			this.cam = base.GetComponent<Camera>();
		}

		// Token: 0x06002443 RID: 9283 RVA: 0x001F9CA4 File Offset: 0x001F7EA4
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

		// Token: 0x04004C0F RID: 19471
		public Vector2 targetAspect = new Vector2(16f, 9f);

		// Token: 0x04004C10 RID: 19472
		private Camera cam;
	}
}
