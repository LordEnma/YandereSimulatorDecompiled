using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A6 RID: 1446
	public class FlipBookPage : MonoBehaviour
	{
		// Token: 0x0600248C RID: 9356 RVA: 0x001FC353 File Offset: 0x001FA553
		private void Awake()
		{
			this.animator = base.GetComponent<Animator>();
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
		}

		// Token: 0x0600248D RID: 9357 RVA: 0x001FC36D File Offset: 0x001FA56D
		public void Transition(bool toOpen)
		{
			this.animator.SetTrigger(toOpen ? "OpenPage" : "ClosePage");
			if (this.objectToActivate != null)
			{
				this.objectToActivate.SetActive(false);
			}
		}

		// Token: 0x0600248E RID: 9358 RVA: 0x001FC3A3 File Offset: 0x001FA5A3
		public void SwitchSort()
		{
			this.spriteRenderer.sortingOrder = 10 - this.spriteRenderer.sortingOrder;
		}

		// Token: 0x0600248F RID: 9359 RVA: 0x001FC3BE File Offset: 0x001FA5BE
		public void ObjectActive(bool toActive = true)
		{
			if (this.objectToActivate != null)
			{
				this.objectToActivate.SetActive(toActive);
			}
		}

		// Token: 0x04004C7E RID: 19582
		[HideInInspector]
		public Animator animator;

		// Token: 0x04004C7F RID: 19583
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x04004C80 RID: 19584
		public GameObject objectToActivate;
	}
}
