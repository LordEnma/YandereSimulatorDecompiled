using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B0 RID: 1456
	public class FlipBookPage : MonoBehaviour
	{
		// Token: 0x060024BC RID: 9404 RVA: 0x0020005B File Offset: 0x001FE25B
		private void Awake()
		{
			this.animator = base.GetComponent<Animator>();
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
		}

		// Token: 0x060024BD RID: 9405 RVA: 0x00200075 File Offset: 0x001FE275
		public void Transition(bool toOpen)
		{
			this.animator.SetTrigger(toOpen ? "OpenPage" : "ClosePage");
			if (this.objectToActivate != null)
			{
				this.objectToActivate.SetActive(false);
			}
		}

		// Token: 0x060024BE RID: 9406 RVA: 0x002000AB File Offset: 0x001FE2AB
		public void SwitchSort()
		{
			this.spriteRenderer.sortingOrder = 10 - this.spriteRenderer.sortingOrder;
		}

		// Token: 0x060024BF RID: 9407 RVA: 0x002000C6 File Offset: 0x001FE2C6
		public void ObjectActive(bool toActive = true)
		{
			if (this.objectToActivate != null)
			{
				this.objectToActivate.SetActive(toActive);
			}
		}

		// Token: 0x04004D13 RID: 19731
		[HideInInspector]
		public Animator animator;

		// Token: 0x04004D14 RID: 19732
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x04004D15 RID: 19733
		public GameObject objectToActivate;
	}
}
