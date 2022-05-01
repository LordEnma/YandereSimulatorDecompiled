using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B1 RID: 1457
	public class FlipBookPage : MonoBehaviour
	{
		// Token: 0x060024CC RID: 9420 RVA: 0x00202056 File Offset: 0x00200256
		private void Awake()
		{
			this.animator = base.GetComponent<Animator>();
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
		}

		// Token: 0x060024CD RID: 9421 RVA: 0x00202070 File Offset: 0x00200270
		public void Transition(bool toOpen)
		{
			this.animator.SetTrigger(toOpen ? "OpenPage" : "ClosePage");
			if (this.objectToActivate != null)
			{
				this.objectToActivate.SetActive(false);
			}
		}

		// Token: 0x060024CE RID: 9422 RVA: 0x002020A6 File Offset: 0x002002A6
		public void SwitchSort()
		{
			this.spriteRenderer.sortingOrder = 10 - this.spriteRenderer.sortingOrder;
		}

		// Token: 0x060024CF RID: 9423 RVA: 0x002020C1 File Offset: 0x002002C1
		public void ObjectActive(bool toActive = true)
		{
			if (this.objectToActivate != null)
			{
				this.objectToActivate.SetActive(toActive);
			}
		}

		// Token: 0x04004D43 RID: 19779
		[HideInInspector]
		public Animator animator;

		// Token: 0x04004D44 RID: 19780
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x04004D45 RID: 19781
		public GameObject objectToActivate;
	}
}
