using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005BA RID: 1466
	public class Meter : MonoBehaviour
	{
		// Token: 0x060024EB RID: 9451 RVA: 0x00200ABC File Offset: 0x001FECBC
		private void Awake()
		{
			this.startPos = this.fillBar.transform.localPosition.x;
		}

		// Token: 0x060024EC RID: 9452 RVA: 0x00200ADC File Offset: 0x001FECDC
		public void SetFill(float interpolater)
		{
			float num = Mathf.Lerp(this.emptyPos, this.startPos, interpolater);
			num = Mathf.Round(num * 50f) / 50f;
			this.fillBar.transform.localPosition = new Vector3(num, 0f, 0f);
		}

		// Token: 0x04004D3C RID: 19772
		public SpriteRenderer fillBar;

		// Token: 0x04004D3D RID: 19773
		public float emptyPos;

		// Token: 0x04004D3E RID: 19774
		private float startPos;
	}
}
