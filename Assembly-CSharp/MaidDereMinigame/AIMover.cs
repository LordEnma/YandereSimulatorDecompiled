using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000599 RID: 1433
	public abstract class AIMover : MonoBehaviour
	{
		// Token: 0x06002456 RID: 9302
		public abstract ControlInput GetInput();

		// Token: 0x06002457 RID: 9303 RVA: 0x001FE284 File Offset: 0x001FC484
		private void FixedUpdate()
		{
			ControlInput input = this.GetInput();
			base.transform.Translate(new Vector2(input.horizontal, 0f) * Time.fixedDeltaTime * this.moveSpeed);
		}

		// Token: 0x04004CAF RID: 19631
		protected float moveSpeed = 3f;
	}
}
