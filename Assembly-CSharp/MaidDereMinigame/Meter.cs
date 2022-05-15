using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005BC RID: 1468
	public class Meter : MonoBehaviour
	{
		// Token: 0x06002506 RID: 9478 RVA: 0x00204204 File Offset: 0x00202404
		private void Awake()
		{
			this.startPos = this.fillBar.transform.localPosition.x;
		}

		// Token: 0x06002507 RID: 9479 RVA: 0x00204224 File Offset: 0x00202424
		public void SetFill(float interpolater)
		{
			float num = Mathf.Lerp(this.emptyPos, this.startPos, interpolater);
			num = Mathf.Round(num * 50f) / 50f;
			this.fillBar.transform.localPosition = new Vector3(num, 0f, 0f);
		}

		// Token: 0x04004D93 RID: 19859
		public SpriteRenderer fillBar;

		// Token: 0x04004D94 RID: 19860
		public float emptyPos;

		// Token: 0x04004D95 RID: 19861
		private float startPos;
	}
}
