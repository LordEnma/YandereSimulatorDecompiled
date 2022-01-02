using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A0 RID: 1440
	public class FlipBookPage : MonoBehaviour
	{
		// Token: 0x06002460 RID: 9312 RVA: 0x001F84BB File Offset: 0x001F66BB
		private void Awake()
		{
			this.animator = base.GetComponent<Animator>();
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
		}

		// Token: 0x06002461 RID: 9313 RVA: 0x001F84D5 File Offset: 0x001F66D5
		public void Transition(bool toOpen)
		{
			this.animator.SetTrigger(toOpen ? "OpenPage" : "ClosePage");
			if (this.objectToActivate != null)
			{
				this.objectToActivate.SetActive(false);
			}
		}

		// Token: 0x06002462 RID: 9314 RVA: 0x001F850B File Offset: 0x001F670B
		public void SwitchSort()
		{
			this.spriteRenderer.sortingOrder = 10 - this.spriteRenderer.sortingOrder;
		}

		// Token: 0x06002463 RID: 9315 RVA: 0x001F8526 File Offset: 0x001F6726
		public void ObjectActive(bool toActive = true)
		{
			if (this.objectToActivate != null)
			{
				this.objectToActivate.SetActive(toActive);
			}
		}

		// Token: 0x04004C19 RID: 19481
		[HideInInspector]
		public Animator animator;

		// Token: 0x04004C1A RID: 19482
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x04004C1B RID: 19483
		public GameObject objectToActivate;
	}
}
