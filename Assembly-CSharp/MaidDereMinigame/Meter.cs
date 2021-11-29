using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A8 RID: 1448
	public class Meter : MonoBehaviour
	{
		// Token: 0x0600247B RID: 9339 RVA: 0x001F71F8 File Offset: 0x001F53F8
		private void Awake()
		{
			this.startPos = this.fillBar.transform.localPosition.x;
		}

		// Token: 0x0600247C RID: 9340 RVA: 0x001F7218 File Offset: 0x001F5418
		public void SetFill(float interpolater)
		{
			float num = Mathf.Lerp(this.emptyPos, this.startPos, interpolater);
			num = Mathf.Round(num * 50f) / 50f;
			this.fillBar.transform.localPosition = new Vector3(num, 0f, 0f);
		}

		// Token: 0x04004BFA RID: 19450
		public SpriteRenderer fillBar;

		// Token: 0x04004BFB RID: 19451
		public float emptyPos;

		// Token: 0x04004BFC RID: 19452
		private float startPos;
	}
}
