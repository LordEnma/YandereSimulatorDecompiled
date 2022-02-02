using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AD RID: 1453
	public class Meter : MonoBehaviour
	{
		// Token: 0x060024A0 RID: 9376 RVA: 0x001FAE2C File Offset: 0x001F902C
		private void Awake()
		{
			this.startPos = this.fillBar.transform.localPosition.x;
		}

		// Token: 0x060024A1 RID: 9377 RVA: 0x001FAE4C File Offset: 0x001F904C
		public void SetFill(float interpolater)
		{
			float num = Mathf.Lerp(this.emptyPos, this.startPos, interpolater);
			num = Mathf.Round(num * 50f) / 50f;
			this.fillBar.transform.localPosition = new Vector3(num, 0f, 0f);
		}

		// Token: 0x04004C68 RID: 19560
		public SpriteRenderer fillBar;

		// Token: 0x04004C69 RID: 19561
		public float emptyPos;

		// Token: 0x04004C6A RID: 19562
		private float startPos;
	}
}
