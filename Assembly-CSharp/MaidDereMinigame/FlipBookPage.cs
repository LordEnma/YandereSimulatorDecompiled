using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A2 RID: 1442
	public class FlipBookPage : MonoBehaviour
	{
		// Token: 0x0600246B RID: 9323 RVA: 0x001F8E5B File Offset: 0x001F705B
		private void Awake()
		{
			this.animator = base.GetComponent<Animator>();
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
		}

		// Token: 0x0600246C RID: 9324 RVA: 0x001F8E75 File Offset: 0x001F7075
		public void Transition(bool toOpen)
		{
			this.animator.SetTrigger(toOpen ? "OpenPage" : "ClosePage");
			if (this.objectToActivate != null)
			{
				this.objectToActivate.SetActive(false);
			}
		}

		// Token: 0x0600246D RID: 9325 RVA: 0x001F8EAB File Offset: 0x001F70AB
		public void SwitchSort()
		{
			this.spriteRenderer.sortingOrder = 10 - this.spriteRenderer.sortingOrder;
		}

		// Token: 0x0600246E RID: 9326 RVA: 0x001F8EC6 File Offset: 0x001F70C6
		public void ObjectActive(bool toActive = true)
		{
			if (this.objectToActivate != null)
			{
				this.objectToActivate.SetActive(toActive);
			}
		}

		// Token: 0x04004C2D RID: 19501
		[HideInInspector]
		public Animator animator;

		// Token: 0x04004C2E RID: 19502
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x04004C2F RID: 19503
		public GameObject objectToActivate;
	}
}
