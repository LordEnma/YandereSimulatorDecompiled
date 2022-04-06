using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059A RID: 1434
	public abstract class AIMover : MonoBehaviour
	{
		// Token: 0x0600245E RID: 9310
		public abstract ControlInput GetInput();

		// Token: 0x0600245F RID: 9311 RVA: 0x001FE7B4 File Offset: 0x001FC9B4
		private void FixedUpdate()
		{
			ControlInput input = this.GetInput();
			base.transform.Translate(new Vector2(input.horizontal, 0f) * Time.fixedDeltaTime * this.moveSpeed);
		}

		// Token: 0x04004CB3 RID: 19635
		protected float moveSpeed = 3f;
	}
}
