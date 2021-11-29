using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000588 RID: 1416
	public abstract class AIMover : MonoBehaviour
	{
		// Token: 0x060023EE RID: 9198
		public abstract ControlInput GetInput();

		// Token: 0x060023EF RID: 9199 RVA: 0x001F4EF0 File Offset: 0x001F30F0
		private void FixedUpdate()
		{
			ControlInput input = this.GetInput();
			base.transform.Translate(new Vector2(input.horizontal, 0f) * Time.fixedDeltaTime * this.moveSpeed);
		}

		// Token: 0x04004B71 RID: 19313
		protected float moveSpeed = 3f;
	}
}
