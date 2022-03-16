using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B4 RID: 1460
	public class Meter : MonoBehaviour
	{
		// Token: 0x060024D3 RID: 9427 RVA: 0x001FED1C File Offset: 0x001FCF1C
		private void Awake()
		{
			this.startPos = this.fillBar.transform.localPosition.x;
		}

		// Token: 0x060024D4 RID: 9428 RVA: 0x001FED3C File Offset: 0x001FCF3C
		public void SetFill(float interpolater)
		{
			float num = Mathf.Lerp(this.emptyPos, this.startPos, interpolater);
			num = Mathf.Round(num * 50f) / 50f;
			this.fillBar.transform.localPosition = new Vector3(num, 0f, 0f);
		}

		// Token: 0x04004D06 RID: 19718
		public SpriteRenderer fillBar;

		// Token: 0x04004D07 RID: 19719
		public float emptyPos;

		// Token: 0x04004D08 RID: 19720
		private float startPos;
	}
}
