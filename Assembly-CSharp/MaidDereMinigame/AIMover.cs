using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200058C RID: 1420
	public abstract class AIMover : MonoBehaviour
	{
		// Token: 0x0600240D RID: 9229
		public abstract ControlInput GetInput();

		// Token: 0x0600240E RID: 9230 RVA: 0x001F75B4 File Offset: 0x001F57B4
		private void FixedUpdate()
		{
			ControlInput input = this.GetInput();
			base.transform.Translate(new Vector2(input.horizontal, 0f) * Time.fixedDeltaTime * this.moveSpeed);
		}

		// Token: 0x04004BCD RID: 19405
		protected float moveSpeed = 3f;
	}
}
