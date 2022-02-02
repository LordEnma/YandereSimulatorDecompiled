using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A3 RID: 1443
	public class FlipBookPage : MonoBehaviour
	{
		// Token: 0x06002471 RID: 9329 RVA: 0x001FA3CB File Offset: 0x001F85CB
		private void Awake()
		{
			this.animator = base.GetComponent<Animator>();
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
		}

		// Token: 0x06002472 RID: 9330 RVA: 0x001FA3E5 File Offset: 0x001F85E5
		public void Transition(bool toOpen)
		{
			this.animator.SetTrigger(toOpen ? "OpenPage" : "ClosePage");
			if (this.objectToActivate != null)
			{
				this.objectToActivate.SetActive(false);
			}
		}

		// Token: 0x06002473 RID: 9331 RVA: 0x001FA41B File Offset: 0x001F861B
		public void SwitchSort()
		{
			this.spriteRenderer.sortingOrder = 10 - this.spriteRenderer.sortingOrder;
		}

		// Token: 0x06002474 RID: 9332 RVA: 0x001FA436 File Offset: 0x001F8636
		public void ObjectActive(bool toActive = true)
		{
			if (this.objectToActivate != null)
			{
				this.objectToActivate.SetActive(toActive);
			}
		}

		// Token: 0x04004C3F RID: 19519
		[HideInInspector]
		public Animator animator;

		// Token: 0x04004C40 RID: 19520
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x04004C41 RID: 19521
		public GameObject objectToActivate;
	}
}
