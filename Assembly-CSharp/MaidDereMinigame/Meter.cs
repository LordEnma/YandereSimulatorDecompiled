using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AE RID: 1454
	public class Meter : MonoBehaviour
	{
		// Token: 0x060024AC RID: 9388 RVA: 0x001FB7FC File Offset: 0x001F99FC
		private void Awake()
		{
			this.startPos = this.fillBar.transform.localPosition.x;
		}

		// Token: 0x060024AD RID: 9389 RVA: 0x001FB81C File Offset: 0x001F9A1C
		public void SetFill(float interpolater)
		{
			float num = Mathf.Lerp(this.emptyPos, this.startPos, interpolater);
			num = Mathf.Round(num * 50f) / 50f;
			this.fillBar.transform.localPosition = new Vector3(num, 0f, 0f);
		}

		// Token: 0x04004C7A RID: 19578
		public SpriteRenderer fillBar;

		// Token: 0x04004C7B RID: 19579
		public float emptyPos;

		// Token: 0x04004C7C RID: 19580
		private float startPos;
	}
}
