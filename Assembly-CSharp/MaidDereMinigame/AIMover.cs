using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200058F RID: 1423
	public abstract class AIMover : MonoBehaviour
	{
		// Token: 0x06002428 RID: 9256
		public abstract ControlInput GetInput();

		// Token: 0x06002429 RID: 9257 RVA: 0x001FA0D4 File Offset: 0x001F82D4
		private void FixedUpdate()
		{
			ControlInput input = this.GetInput();
			base.transform.Translate(new Vector2(input.horizontal, 0f) * Time.fixedDeltaTime * this.moveSpeed);
		}

		// Token: 0x04004C01 RID: 19457
		protected float moveSpeed = 3f;
	}
}
