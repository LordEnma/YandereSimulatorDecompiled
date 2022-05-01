using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059B RID: 1435
	public abstract class AIMover : MonoBehaviour
	{
		// Token: 0x0600246E RID: 9326
		public abstract ControlInput GetInput();

		// Token: 0x0600246F RID: 9327 RVA: 0x0020069C File Offset: 0x001FE89C
		private void FixedUpdate()
		{
			ControlInput input = this.GetInput();
			base.transform.Translate(new Vector2(input.horizontal, 0f) * Time.fixedDeltaTime * this.moveSpeed);
		}

		// Token: 0x04004CDB RID: 19675
		protected float moveSpeed = 3f;
	}
}
