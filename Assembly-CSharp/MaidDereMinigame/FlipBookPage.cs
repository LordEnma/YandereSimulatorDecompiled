using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AA RID: 1450
	public class FlipBookPage : MonoBehaviour
	{
		// Token: 0x060024A4 RID: 9380 RVA: 0x001FE2BB File Offset: 0x001FC4BB
		private void Awake()
		{
			this.animator = base.GetComponent<Animator>();
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
		}

		// Token: 0x060024A5 RID: 9381 RVA: 0x001FE2D5 File Offset: 0x001FC4D5
		public void Transition(bool toOpen)
		{
			this.animator.SetTrigger(toOpen ? "OpenPage" : "ClosePage");
			if (this.objectToActivate != null)
			{
				this.objectToActivate.SetActive(false);
			}
		}

		// Token: 0x060024A6 RID: 9382 RVA: 0x001FE30B File Offset: 0x001FC50B
		public void SwitchSort()
		{
			this.spriteRenderer.sortingOrder = 10 - this.spriteRenderer.sortingOrder;
		}

		// Token: 0x060024A7 RID: 9383 RVA: 0x001FE326 File Offset: 0x001FC526
		public void ObjectActive(bool toActive = true)
		{
			if (this.objectToActivate != null)
			{
				this.objectToActivate.SetActive(toActive);
			}
		}

		// Token: 0x04004CDD RID: 19677
		[HideInInspector]
		public Animator animator;

		// Token: 0x04004CDE RID: 19678
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x04004CDF RID: 19679
		public GameObject objectToActivate;
	}
}
