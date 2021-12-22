using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AA RID: 1450
	public class Meter : MonoBehaviour
	{
		// Token: 0x0600248C RID: 9356 RVA: 0x001F892C File Offset: 0x001F6B2C
		private void Awake()
		{
			this.startPos = this.fillBar.transform.localPosition.x;
		}

		// Token: 0x0600248D RID: 9357 RVA: 0x001F894C File Offset: 0x001F6B4C
		public void SetFill(float interpolater)
		{
			float num = Mathf.Lerp(this.emptyPos, this.startPos, interpolater);
			num = Mathf.Round(num * 50f) / 50f;
			this.fillBar.transform.localPosition = new Vector3(num, 0f, 0f);
		}

		// Token: 0x04004C39 RID: 19513
		public SpriteRenderer fillBar;

		// Token: 0x04004C3A RID: 19514
		public float emptyPos;

		// Token: 0x04004C3B RID: 19515
		private float startPos;
	}
}
