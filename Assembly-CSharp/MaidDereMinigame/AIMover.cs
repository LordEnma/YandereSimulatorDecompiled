using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000594 RID: 1428
	public abstract class AIMover : MonoBehaviour
	{
		// Token: 0x06002446 RID: 9286
		public abstract ControlInput GetInput();

		// Token: 0x06002447 RID: 9287 RVA: 0x001FCA14 File Offset: 0x001FAC14
		private void FixedUpdate()
		{
			ControlInput input = this.GetInput();
			base.transform.Translate(new Vector2(input.horizontal, 0f) * Time.fixedDeltaTime * this.moveSpeed);
		}

		// Token: 0x04004C7D RID: 19581
		protected float moveSpeed = 3f;
	}
}
