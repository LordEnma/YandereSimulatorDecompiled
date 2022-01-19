using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AD RID: 1453
	public class Meter : MonoBehaviour
	{
		// Token: 0x0600249C RID: 9372 RVA: 0x001FA58C File Offset: 0x001F878C
		private void Awake()
		{
			this.startPos = this.fillBar.transform.localPosition.x;
		}

		// Token: 0x0600249D RID: 9373 RVA: 0x001FA5AC File Offset: 0x001F87AC
		public void SetFill(float interpolater)
		{
			float num = Mathf.Lerp(this.emptyPos, this.startPos, interpolater);
			num = Mathf.Round(num * 50f) / 50f;
			this.fillBar.transform.localPosition = new Vector3(num, 0f, 0f);
		}

		// Token: 0x04004C5D RID: 19549
		public SpriteRenderer fillBar;

		// Token: 0x04004C5E RID: 19550
		public float emptyPos;

		// Token: 0x04004C5F RID: 19551
		private float startPos;
	}
}
