using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059A RID: 1434
	public abstract class AIMover : MonoBehaviour
	{
		// Token: 0x06002465 RID: 9317
		public abstract ControlInput GetInput();

		// Token: 0x06002466 RID: 9318 RVA: 0x001FF210 File Offset: 0x001FD410
		private void FixedUpdate()
		{
			ControlInput input = this.GetInput();
			base.transform.Translate(new Vector2(input.horizontal, 0f) * Time.fixedDeltaTime * this.moveSpeed);
		}

		// Token: 0x04004CC5 RID: 19653
		protected float moveSpeed = 3f;
	}
}
