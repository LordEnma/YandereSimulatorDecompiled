using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A3 RID: 1443
	public class FlipBookPage : MonoBehaviour
	{
		// Token: 0x0600246D RID: 9325 RVA: 0x001F9B2B File Offset: 0x001F7D2B
		private void Awake()
		{
			this.animator = base.GetComponent<Animator>();
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
		}

		// Token: 0x0600246E RID: 9326 RVA: 0x001F9B45 File Offset: 0x001F7D45
		public void Transition(bool toOpen)
		{
			this.animator.SetTrigger(toOpen ? "OpenPage" : "ClosePage");
			if (this.objectToActivate != null)
			{
				this.objectToActivate.SetActive(false);
			}
		}

		// Token: 0x0600246F RID: 9327 RVA: 0x001F9B7B File Offset: 0x001F7D7B
		public void SwitchSort()
		{
			this.spriteRenderer.sortingOrder = 10 - this.spriteRenderer.sortingOrder;
		}

		// Token: 0x06002470 RID: 9328 RVA: 0x001F9B96 File Offset: 0x001F7D96
		public void ObjectActive(bool toActive = true)
		{
			if (this.objectToActivate != null)
			{
				this.objectToActivate.SetActive(toActive);
			}
		}

		// Token: 0x04004C34 RID: 19508
		[HideInInspector]
		public Animator animator;

		// Token: 0x04004C35 RID: 19509
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x04004C36 RID: 19510
		public GameObject objectToActivate;
	}
}
