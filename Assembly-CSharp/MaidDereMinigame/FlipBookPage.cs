using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A4 RID: 1444
	public class FlipBookPage : MonoBehaviour
	{
		// Token: 0x0600247D RID: 9341 RVA: 0x001FAD9B File Offset: 0x001F8F9B
		private void Awake()
		{
			this.animator = base.GetComponent<Animator>();
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
		}

		// Token: 0x0600247E RID: 9342 RVA: 0x001FADB5 File Offset: 0x001F8FB5
		public void Transition(bool toOpen)
		{
			this.animator.SetTrigger(toOpen ? "OpenPage" : "ClosePage");
			if (this.objectToActivate != null)
			{
				this.objectToActivate.SetActive(false);
			}
		}

		// Token: 0x0600247F RID: 9343 RVA: 0x001FADEB File Offset: 0x001F8FEB
		public void SwitchSort()
		{
			this.spriteRenderer.sortingOrder = 10 - this.spriteRenderer.sortingOrder;
		}

		// Token: 0x06002480 RID: 9344 RVA: 0x001FAE06 File Offset: 0x001F9006
		public void ObjectActive(bool toActive = true)
		{
			if (this.objectToActivate != null)
			{
				this.objectToActivate.SetActive(toActive);
			}
		}

		// Token: 0x04004C51 RID: 19537
		[HideInInspector]
		public Animator animator;

		// Token: 0x04004C52 RID: 19538
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x04004C53 RID: 19539
		public GameObject objectToActivate;
	}
}
