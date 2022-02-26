using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AF RID: 1455
	public class Meter : MonoBehaviour
	{
		// Token: 0x060024B5 RID: 9397 RVA: 0x001FC3DC File Offset: 0x001FA5DC
		private void Awake()
		{
			this.startPos = this.fillBar.transform.localPosition.x;
		}

		// Token: 0x060024B6 RID: 9398 RVA: 0x001FC3FC File Offset: 0x001FA5FC
		public void SetFill(float interpolater)
		{
			float num = Mathf.Lerp(this.emptyPos, this.startPos, interpolater);
			num = Mathf.Round(num * 50f) / 50f;
			this.fillBar.transform.localPosition = new Vector3(num, 0f, 0f);
		}

		// Token: 0x04004C8A RID: 19594
		public SpriteRenderer fillBar;

		// Token: 0x04004C8B RID: 19595
		public float emptyPos;

		// Token: 0x04004C8C RID: 19596
		private float startPos;
	}
}
