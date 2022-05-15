using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A6 RID: 1446
	[RequireComponent(typeof(Camera))]
	public class CameraForcedAspect : MonoBehaviour
	{
		// Token: 0x060024A8 RID: 9384 RVA: 0x00202FA8 File Offset: 0x002011A8
		private void Awake()
		{
			this.cam = base.GetComponent<Camera>();
		}

		// Token: 0x060024A9 RID: 9385 RVA: 0x00202FB8 File Offset: 0x002011B8
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

		// Token: 0x04004D35 RID: 19765
		public Vector2 targetAspect = new Vector2(16f, 9f);

		// Token: 0x04004D36 RID: 19766
		private Camera cam;
	}
}
