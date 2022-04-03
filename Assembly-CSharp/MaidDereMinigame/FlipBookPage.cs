using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AF RID: 1455
	public class FlipBookPage : MonoBehaviour
	{
		// Token: 0x060024B4 RID: 9396 RVA: 0x001FFB2B File Offset: 0x001FDD2B
		private void Awake()
		{
			this.animator = base.GetComponent<Animator>();
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
		}

		// Token: 0x060024B5 RID: 9397 RVA: 0x001FFB45 File Offset: 0x001FDD45
		public void Transition(bool toOpen)
		{
			this.animator.SetTrigger(toOpen ? "OpenPage" : "ClosePage");
			if (this.objectToActivate != null)
			{
				this.objectToActivate.SetActive(false);
			}
		}

		// Token: 0x060024B6 RID: 9398 RVA: 0x001FFB7B File Offset: 0x001FDD7B
		public void SwitchSort()
		{
			this.spriteRenderer.sortingOrder = 10 - this.spriteRenderer.sortingOrder;
		}

		// Token: 0x060024B7 RID: 9399 RVA: 0x001FFB96 File Offset: 0x001FDD96
		public void ObjectActive(bool toActive = true)
		{
			if (this.objectToActivate != null)
			{
				this.objectToActivate.SetActive(toActive);
			}
		}

		// Token: 0x04004D0F RID: 19727
		[HideInInspector]
		public Animator animator;

		// Token: 0x04004D10 RID: 19728
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x04004D11 RID: 19729
		public GameObject objectToActivate;
	}
}
