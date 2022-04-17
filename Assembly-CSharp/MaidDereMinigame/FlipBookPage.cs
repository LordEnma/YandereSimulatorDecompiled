using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B0 RID: 1456
	public class FlipBookPage : MonoBehaviour
	{
		// Token: 0x060024C3 RID: 9411 RVA: 0x00200AB7 File Offset: 0x001FECB7
		private void Awake()
		{
			this.animator = base.GetComponent<Animator>();
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
		}

		// Token: 0x060024C4 RID: 9412 RVA: 0x00200AD1 File Offset: 0x001FECD1
		public void Transition(bool toOpen)
		{
			this.animator.SetTrigger(toOpen ? "OpenPage" : "ClosePage");
			if (this.objectToActivate != null)
			{
				this.objectToActivate.SetActive(false);
			}
		}

		// Token: 0x060024C5 RID: 9413 RVA: 0x00200B07 File Offset: 0x001FED07
		public void SwitchSort()
		{
			this.spriteRenderer.sortingOrder = 10 - this.spriteRenderer.sortingOrder;
		}

		// Token: 0x060024C6 RID: 9414 RVA: 0x00200B22 File Offset: 0x001FED22
		public void ObjectActive(bool toActive = true)
		{
			if (this.objectToActivate != null)
			{
				this.objectToActivate.SetActive(toActive);
			}
		}

		// Token: 0x04004D25 RID: 19749
		[HideInInspector]
		public Animator animator;

		// Token: 0x04004D26 RID: 19750
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x04004D27 RID: 19751
		public GameObject objectToActivate;
	}
}
