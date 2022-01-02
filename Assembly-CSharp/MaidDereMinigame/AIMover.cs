using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200058A RID: 1418
	public abstract class AIMover : MonoBehaviour
	{
		// Token: 0x06002402 RID: 9218
		public abstract ControlInput GetInput();

		// Token: 0x06002403 RID: 9219 RVA: 0x001F6C14 File Offset: 0x001F4E14
		private void FixedUpdate()
		{
			ControlInput input = this.GetInput();
			base.transform.Translate(new Vector2(input.horizontal, 0f) * Time.fixedDeltaTime * this.moveSpeed);
		}

		// Token: 0x04004BB9 RID: 19385
		protected float moveSpeed = 3f;
	}
}
