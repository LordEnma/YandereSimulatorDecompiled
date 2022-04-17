using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005BA RID: 1466
	public class Meter : MonoBehaviour
	{
		// Token: 0x060024F2 RID: 9458 RVA: 0x00201518 File Offset: 0x001FF718
		private void Awake()
		{
			this.startPos = this.fillBar.transform.localPosition.x;
		}

		// Token: 0x060024F3 RID: 9459 RVA: 0x00201538 File Offset: 0x001FF738
		public void SetFill(float interpolater)
		{
			float num = Mathf.Lerp(this.emptyPos, this.startPos, interpolater);
			num = Mathf.Round(num * 50f) / 50f;
			this.fillBar.transform.localPosition = new Vector3(num, 0f, 0f);
		}

		// Token: 0x04004D4E RID: 19790
		public SpriteRenderer fillBar;

		// Token: 0x04004D4F RID: 19791
		public float emptyPos;

		// Token: 0x04004D50 RID: 19792
		private float startPos;
	}
}
