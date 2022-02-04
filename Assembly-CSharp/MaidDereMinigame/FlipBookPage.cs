using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A3 RID: 1443
	public class FlipBookPage : MonoBehaviour
	{
		// Token: 0x06002473 RID: 9331 RVA: 0x001FA6E3 File Offset: 0x001F88E3
		private void Awake()
		{
			this.animator = base.GetComponent<Animator>();
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
		}

		// Token: 0x06002474 RID: 9332 RVA: 0x001FA6FD File Offset: 0x001F88FD
		public void Transition(bool toOpen)
		{
			this.animator.SetTrigger(toOpen ? "OpenPage" : "ClosePage");
			if (this.objectToActivate != null)
			{
				this.objectToActivate.SetActive(false);
			}
		}

		// Token: 0x06002475 RID: 9333 RVA: 0x001FA733 File Offset: 0x001F8933
		public void SwitchSort()
		{
			this.spriteRenderer.sortingOrder = 10 - this.spriteRenderer.sortingOrder;
		}

		// Token: 0x06002476 RID: 9334 RVA: 0x001FA74E File Offset: 0x001F894E
		public void ObjectActive(bool toActive = true)
		{
			if (this.objectToActivate != null)
			{
				this.objectToActivate.SetActive(toActive);
			}
		}

		// Token: 0x04004C45 RID: 19525
		[HideInInspector]
		public Animator animator;

		// Token: 0x04004C46 RID: 19526
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x04004C47 RID: 19527
		public GameObject objectToActivate;
	}
}
