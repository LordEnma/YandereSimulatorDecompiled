using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B9 RID: 1465
	public class Meter : MonoBehaviour
	{
		// Token: 0x060024E3 RID: 9443 RVA: 0x0020058C File Offset: 0x001FE78C
		private void Awake()
		{
			this.startPos = this.fillBar.transform.localPosition.x;
		}

		// Token: 0x060024E4 RID: 9444 RVA: 0x002005AC File Offset: 0x001FE7AC
		public void SetFill(float interpolater)
		{
			float num = Mathf.Lerp(this.emptyPos, this.startPos, interpolater);
			num = Mathf.Round(num * 50f) / 50f;
			this.fillBar.transform.localPosition = new Vector3(num, 0f, 0f);
		}

		// Token: 0x04004D38 RID: 19768
		public SpriteRenderer fillBar;

		// Token: 0x04004D39 RID: 19769
		public float emptyPos;

		// Token: 0x04004D3A RID: 19770
		private float startPos;
	}
}
