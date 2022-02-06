using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AD RID: 1453
	public class Meter : MonoBehaviour
	{
		// Token: 0x060024A5 RID: 9381 RVA: 0x001FB348 File Offset: 0x001F9548
		private void Awake()
		{
			this.startPos = this.fillBar.transform.localPosition.x;
		}

		// Token: 0x060024A6 RID: 9382 RVA: 0x001FB368 File Offset: 0x001F9568
		public void SetFill(float interpolater)
		{
			float num = Mathf.Lerp(this.emptyPos, this.startPos, interpolater);
			num = Mathf.Round(num * 50f) / 50f;
			this.fillBar.transform.localPosition = new Vector3(num, 0f, 0f);
		}

		// Token: 0x04004C71 RID: 19569
		public SpriteRenderer fillBar;

		// Token: 0x04004C72 RID: 19570
		public float emptyPos;

		// Token: 0x04004C73 RID: 19571
		private float startPos;
	}
}
