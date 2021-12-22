using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200058A RID: 1418
	public abstract class AIMover : MonoBehaviour
	{
		// Token: 0x060023FF RID: 9215
		public abstract ControlInput GetInput();

		// Token: 0x06002400 RID: 9216 RVA: 0x001F6624 File Offset: 0x001F4824
		private void FixedUpdate()
		{
			ControlInput input = this.GetInput();
			base.transform.Translate(new Vector2(input.horizontal, 0f) * Time.fixedDeltaTime * this.moveSpeed);
		}

		// Token: 0x04004BB0 RID: 19376
		protected float moveSpeed = 3f;
	}
}
