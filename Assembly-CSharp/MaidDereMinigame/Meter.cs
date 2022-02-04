using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AD RID: 1453
	public class Meter : MonoBehaviour
	{
		// Token: 0x060024A2 RID: 9378 RVA: 0x001FB144 File Offset: 0x001F9344
		private void Awake()
		{
			this.startPos = this.fillBar.transform.localPosition.x;
		}

		// Token: 0x060024A3 RID: 9379 RVA: 0x001FB164 File Offset: 0x001F9364
		public void SetFill(float interpolater)
		{
			float num = Mathf.Lerp(this.emptyPos, this.startPos, interpolater);
			num = Mathf.Round(num * 50f) / 50f;
			this.fillBar.transform.localPosition = new Vector3(num, 0f, 0f);
		}

		// Token: 0x04004C6E RID: 19566
		public SpriteRenderer fillBar;

		// Token: 0x04004C6F RID: 19567
		public float emptyPos;

		// Token: 0x04004C70 RID: 19568
		private float startPos;
	}
}
