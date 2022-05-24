using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059C RID: 1436
	public abstract class AIMover : MonoBehaviour
	{
		// Token: 0x0600247A RID: 9338
		public abstract ControlInput GetInput();

		// Token: 0x0600247B RID: 9339 RVA: 0x00202350 File Offset: 0x00200550
		private void FixedUpdate()
		{
			ControlInput input = this.GetInput();
			base.transform.Translate(new Vector2(input.horizontal, 0f) * Time.fixedDeltaTime * this.moveSpeed);
		}

		// Token: 0x04004D0B RID: 19723
		protected float moveSpeed = 3f;
	}
}
