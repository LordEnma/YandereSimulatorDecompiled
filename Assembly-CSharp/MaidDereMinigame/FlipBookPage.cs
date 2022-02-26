using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A5 RID: 1445
	public class FlipBookPage : MonoBehaviour
	{
		// Token: 0x06002486 RID: 9350 RVA: 0x001FB97B File Offset: 0x001F9B7B
		private void Awake()
		{
			this.animator = base.GetComponent<Animator>();
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
		}

		// Token: 0x06002487 RID: 9351 RVA: 0x001FB995 File Offset: 0x001F9B95
		public void Transition(bool toOpen)
		{
			this.animator.SetTrigger(toOpen ? "OpenPage" : "ClosePage");
			if (this.objectToActivate != null)
			{
				this.objectToActivate.SetActive(false);
			}
		}

		// Token: 0x06002488 RID: 9352 RVA: 0x001FB9CB File Offset: 0x001F9BCB
		public void SwitchSort()
		{
			this.spriteRenderer.sortingOrder = 10 - this.spriteRenderer.sortingOrder;
		}

		// Token: 0x06002489 RID: 9353 RVA: 0x001FB9E6 File Offset: 0x001F9BE6
		public void ObjectActive(bool toActive = true)
		{
			if (this.objectToActivate != null)
			{
				this.objectToActivate.SetActive(toActive);
			}
		}

		// Token: 0x04004C61 RID: 19553
		[HideInInspector]
		public Animator animator;

		// Token: 0x04004C62 RID: 19554
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x04004C63 RID: 19555
		public GameObject objectToActivate;
	}
}
