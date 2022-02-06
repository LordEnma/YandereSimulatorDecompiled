using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200058D RID: 1421
	public abstract class AIMover : MonoBehaviour
	{
		// Token: 0x06002418 RID: 9240
		public abstract ControlInput GetInput();

		// Token: 0x06002419 RID: 9241 RVA: 0x001F9040 File Offset: 0x001F7240
		private void FixedUpdate()
		{
			ControlInput input = this.GetInput();
			base.transform.Translate(new Vector2(input.horizontal, 0f) * Time.fixedDeltaTime * this.moveSpeed);
		}

		// Token: 0x04004BE8 RID: 19432
		protected float moveSpeed = 3f;
	}
}
