using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A0 RID: 1440
	public class FlipBookPage : MonoBehaviour
	{
		// Token: 0x0600245D RID: 9309 RVA: 0x001F7ECB File Offset: 0x001F60CB
		private void Awake()
		{
			this.animator = base.GetComponent<Animator>();
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
		}

		// Token: 0x0600245E RID: 9310 RVA: 0x001F7EE5 File Offset: 0x001F60E5
		public void Transition(bool toOpen)
		{
			this.animator.SetTrigger(toOpen ? "OpenPage" : "ClosePage");
			if (this.objectToActivate != null)
			{
				this.objectToActivate.SetActive(false);
			}
		}

		// Token: 0x0600245F RID: 9311 RVA: 0x001F7F1B File Offset: 0x001F611B
		public void SwitchSort()
		{
			this.spriteRenderer.sortingOrder = 10 - this.spriteRenderer.sortingOrder;
		}

		// Token: 0x06002460 RID: 9312 RVA: 0x001F7F36 File Offset: 0x001F6136
		public void ObjectActive(bool toActive = true)
		{
			if (this.objectToActivate != null)
			{
				this.objectToActivate.SetActive(toActive);
			}
		}

		// Token: 0x04004C10 RID: 19472
		[HideInInspector]
		public Animator animator;

		// Token: 0x04004C11 RID: 19473
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x04004C12 RID: 19474
		public GameObject objectToActivate;
	}
}
