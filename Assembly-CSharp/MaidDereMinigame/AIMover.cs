using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059C RID: 1436
	public abstract class AIMover : MonoBehaviour
	{
		// Token: 0x06002479 RID: 9337
		public abstract ControlInput GetInput();

		// Token: 0x0600247A RID: 9338 RVA: 0x00201DE8 File Offset: 0x001FFFE8
		private void FixedUpdate()
		{
			ControlInput input = this.GetInput();
			base.transform.Translate(new Vector2(input.horizontal, 0f) * Time.fixedDeltaTime * this.moveSpeed);
		}

		// Token: 0x04004D02 RID: 19714
		protected float moveSpeed = 3f;
	}
}
