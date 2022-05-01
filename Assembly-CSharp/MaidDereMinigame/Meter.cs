using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005BB RID: 1467
	public class Meter : MonoBehaviour
	{
		// Token: 0x060024FB RID: 9467 RVA: 0x00202AB8 File Offset: 0x00200CB8
		private void Awake()
		{
			this.startPos = this.fillBar.transform.localPosition.x;
		}

		// Token: 0x060024FC RID: 9468 RVA: 0x00202AD8 File Offset: 0x00200CD8
		public void SetFill(float interpolater)
		{
			float num = Mathf.Lerp(this.emptyPos, this.startPos, interpolater);
			num = Mathf.Round(num * 50f) / 50f;
			this.fillBar.transform.localPosition = new Vector3(num, 0f, 0f);
		}

		// Token: 0x04004D6C RID: 19820
		public SpriteRenderer fillBar;

		// Token: 0x04004D6D RID: 19821
		public float emptyPos;

		// Token: 0x04004D6E RID: 19822
		private float startPos;
	}
}
