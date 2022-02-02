using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200058D RID: 1421
	public abstract class AIMover : MonoBehaviour
	{
		// Token: 0x06002413 RID: 9235
		public abstract ControlInput GetInput();

		// Token: 0x06002414 RID: 9236 RVA: 0x001F8B24 File Offset: 0x001F6D24
		private void FixedUpdate()
		{
			ControlInput input = this.GetInput();
			base.transform.Translate(new Vector2(input.horizontal, 0f) * Time.fixedDeltaTime * this.moveSpeed);
		}

		// Token: 0x04004BDF RID: 19423
		protected float moveSpeed = 3f;
	}
}
