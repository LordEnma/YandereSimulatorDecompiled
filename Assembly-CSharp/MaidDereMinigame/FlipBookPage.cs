using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B2 RID: 1458
	public class FlipBookPage : MonoBehaviour
	{
		// Token: 0x060024D8 RID: 9432 RVA: 0x00203D0A File Offset: 0x00201F0A
		private void Awake()
		{
			this.animator = base.GetComponent<Animator>();
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
		}

		// Token: 0x060024D9 RID: 9433 RVA: 0x00203D24 File Offset: 0x00201F24
		public void Transition(bool toOpen)
		{
			this.animator.SetTrigger(toOpen ? "OpenPage" : "ClosePage");
			if (this.objectToActivate != null)
			{
				this.objectToActivate.SetActive(false);
			}
		}

		// Token: 0x060024DA RID: 9434 RVA: 0x00203D5A File Offset: 0x00201F5A
		public void SwitchSort()
		{
			this.spriteRenderer.sortingOrder = 10 - this.spriteRenderer.sortingOrder;
		}

		// Token: 0x060024DB RID: 9435 RVA: 0x00203D75 File Offset: 0x00201F75
		public void ObjectActive(bool toActive = true)
		{
			if (this.objectToActivate != null)
			{
				this.objectToActivate.SetActive(toActive);
			}
		}

		// Token: 0x04004D73 RID: 19827
		[HideInInspector]
		public Animator animator;

		// Token: 0x04004D74 RID: 19828
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x04004D75 RID: 19829
		public GameObject objectToActivate;
	}
}
