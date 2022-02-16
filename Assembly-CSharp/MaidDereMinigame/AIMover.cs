using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200058E RID: 1422
	public abstract class AIMover : MonoBehaviour
	{
		// Token: 0x0600241F RID: 9247
		public abstract ControlInput GetInput();

		// Token: 0x06002420 RID: 9248 RVA: 0x001F94F4 File Offset: 0x001F76F4
		private void FixedUpdate()
		{
			ControlInput input = this.GetInput();
			base.transform.Translate(new Vector2(input.horizontal, 0f) * Time.fixedDeltaTime * this.moveSpeed);
		}

		// Token: 0x04004BF1 RID: 19441
		protected float moveSpeed = 3f;
	}
}
