using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005BC RID: 1468
	public class Meter : MonoBehaviour
	{
		// Token: 0x06002507 RID: 9479 RVA: 0x0020476C File Offset: 0x0020296C
		private void Awake()
		{
			this.startPos = this.fillBar.transform.localPosition.x;
		}

		// Token: 0x06002508 RID: 9480 RVA: 0x0020478C File Offset: 0x0020298C
		public void SetFill(float interpolater)
		{
			float num = Mathf.Lerp(this.emptyPos, this.startPos, interpolater);
			num = Mathf.Round(num * 50f) / 50f;
			this.fillBar.transform.localPosition = new Vector3(num, 0f, 0f);
		}

		// Token: 0x04004D9C RID: 19868
		public SpriteRenderer fillBar;

		// Token: 0x04004D9D RID: 19869
		public float emptyPos;

		// Token: 0x04004D9E RID: 19870
		private float startPos;
	}
}
