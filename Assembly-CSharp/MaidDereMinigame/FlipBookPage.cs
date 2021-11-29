using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059E RID: 1438
	public class FlipBookPage : MonoBehaviour
	{
		// Token: 0x0600244C RID: 9292 RVA: 0x001F6797 File Offset: 0x001F4997
		private void Awake()
		{
			this.animator = base.GetComponent<Animator>();
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
		}

		// Token: 0x0600244D RID: 9293 RVA: 0x001F67B1 File Offset: 0x001F49B1
		public void Transition(bool toOpen)
		{
			this.animator.SetTrigger(toOpen ? "OpenPage" : "ClosePage");
			if (this.objectToActivate != null)
			{
				this.objectToActivate.SetActive(false);
			}
		}

		// Token: 0x0600244E RID: 9294 RVA: 0x001F67E7 File Offset: 0x001F49E7
		public void SwitchSort()
		{
			this.spriteRenderer.sortingOrder = 10 - this.spriteRenderer.sortingOrder;
		}

		// Token: 0x0600244F RID: 9295 RVA: 0x001F6802 File Offset: 0x001F4A02
		public void ObjectActive(bool toActive = true)
		{
			if (this.objectToActivate != null)
			{
				this.objectToActivate.SetActive(toActive);
			}
		}

		// Token: 0x04004BD1 RID: 19409
		[HideInInspector]
		public Animator animator;

		// Token: 0x04004BD2 RID: 19410
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x04004BD3 RID: 19411
		public GameObject objectToActivate;
	}
}
