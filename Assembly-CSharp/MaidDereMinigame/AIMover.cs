using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000590 RID: 1424
	public abstract class AIMover : MonoBehaviour
	{
		// Token: 0x0600242E RID: 9262
		public abstract ControlInput GetInput();

		// Token: 0x0600242F RID: 9263 RVA: 0x001FAAAC File Offset: 0x001F8CAC
		private void FixedUpdate()
		{
			ControlInput input = this.GetInput();
			base.transform.Translate(new Vector2(input.horizontal, 0f) * Time.fixedDeltaTime * this.moveSpeed);
		}

		// Token: 0x04004C1E RID: 19486
		protected float moveSpeed = 3f;
	}
}
