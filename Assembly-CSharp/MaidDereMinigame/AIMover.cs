using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200058D RID: 1421
	public abstract class AIMover : MonoBehaviour
	{
		// Token: 0x0600240F RID: 9231
		public abstract ControlInput GetInput();

		// Token: 0x06002410 RID: 9232 RVA: 0x001F8284 File Offset: 0x001F6484
		private void FixedUpdate()
		{
			ControlInput input = this.GetInput();
			base.transform.Translate(new Vector2(input.horizontal, 0f) * Time.fixedDeltaTime * this.moveSpeed);
		}

		// Token: 0x04004BD4 RID: 19412
		protected float moveSpeed = 3f;
	}
}
