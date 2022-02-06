using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A3 RID: 1443
	public class FlipBookPage : MonoBehaviour
	{
		// Token: 0x06002476 RID: 9334 RVA: 0x001FA8E7 File Offset: 0x001F8AE7
		private void Awake()
		{
			this.animator = base.GetComponent<Animator>();
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
		}

		// Token: 0x06002477 RID: 9335 RVA: 0x001FA901 File Offset: 0x001F8B01
		public void Transition(bool toOpen)
		{
			this.animator.SetTrigger(toOpen ? "OpenPage" : "ClosePage");
			if (this.objectToActivate != null)
			{
				this.objectToActivate.SetActive(false);
			}
		}

		// Token: 0x06002478 RID: 9336 RVA: 0x001FA937 File Offset: 0x001F8B37
		public void SwitchSort()
		{
			this.spriteRenderer.sortingOrder = 10 - this.spriteRenderer.sortingOrder;
		}

		// Token: 0x06002479 RID: 9337 RVA: 0x001FA952 File Offset: 0x001F8B52
		public void ObjectActive(bool toActive = true)
		{
			if (this.objectToActivate != null)
			{
				this.objectToActivate.SetActive(toActive);
			}
		}

		// Token: 0x04004C48 RID: 19528
		[HideInInspector]
		public Animator animator;

		// Token: 0x04004C49 RID: 19529
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x04004C4A RID: 19530
		public GameObject objectToActivate;
	}
}
