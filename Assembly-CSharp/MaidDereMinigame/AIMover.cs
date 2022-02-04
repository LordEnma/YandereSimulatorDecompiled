using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200058D RID: 1421
	public abstract class AIMover : MonoBehaviour
	{
		// Token: 0x06002415 RID: 9237
		public abstract ControlInput GetInput();

		// Token: 0x06002416 RID: 9238 RVA: 0x001F8E3C File Offset: 0x001F703C
		private void FixedUpdate()
		{
			ControlInput input = this.GetInput();
			base.transform.Translate(new Vector2(input.horizontal, 0f) * Time.fixedDeltaTime * this.moveSpeed);
		}

		// Token: 0x04004BE5 RID: 19429
		protected float moveSpeed = 3f;
	}
}
