using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AC RID: 1452
	public class Meter : MonoBehaviour
	{
		// Token: 0x0600249A RID: 9370 RVA: 0x001F98BC File Offset: 0x001F7ABC
		private void Awake()
		{
			this.startPos = this.fillBar.transform.localPosition.x;
		}

		// Token: 0x0600249B RID: 9371 RVA: 0x001F98DC File Offset: 0x001F7ADC
		public void SetFill(float interpolater)
		{
			float num = Mathf.Lerp(this.emptyPos, this.startPos, interpolater);
			num = Mathf.Round(num * 50f) / 50f;
			this.fillBar.transform.localPosition = new Vector3(num, 0f, 0f);
		}

		// Token: 0x04004C56 RID: 19542
		public SpriteRenderer fillBar;

		// Token: 0x04004C57 RID: 19543
		public float emptyPos;

		// Token: 0x04004C58 RID: 19544
		private float startPos;
	}
}
