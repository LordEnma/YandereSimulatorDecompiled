using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AA RID: 1450
	public class Meter : MonoBehaviour
	{
		// Token: 0x0600248F RID: 9359 RVA: 0x001F8F1C File Offset: 0x001F711C
		private void Awake()
		{
			this.startPos = this.fillBar.transform.localPosition.x;
		}

		// Token: 0x06002490 RID: 9360 RVA: 0x001F8F3C File Offset: 0x001F713C
		public void SetFill(float interpolater)
		{
			float num = Mathf.Lerp(this.emptyPos, this.startPos, interpolater);
			num = Mathf.Round(num * 50f) / 50f;
			this.fillBar.transform.localPosition = new Vector3(num, 0f, 0f);
		}

		// Token: 0x04004C42 RID: 19522
		public SpriteRenderer fillBar;

		// Token: 0x04004C43 RID: 19523
		public float emptyPos;

		// Token: 0x04004C44 RID: 19524
		private float startPos;
	}
}
