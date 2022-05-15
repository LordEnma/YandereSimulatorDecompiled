using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B2 RID: 1458
	public class FlipBookPage : MonoBehaviour
	{
		// Token: 0x060024D7 RID: 9431 RVA: 0x002037A2 File Offset: 0x002019A2
		private void Awake()
		{
			this.animator = base.GetComponent<Animator>();
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
		}

		// Token: 0x060024D8 RID: 9432 RVA: 0x002037BC File Offset: 0x002019BC
		public void Transition(bool toOpen)
		{
			this.animator.SetTrigger(toOpen ? "OpenPage" : "ClosePage");
			if (this.objectToActivate != null)
			{
				this.objectToActivate.SetActive(false);
			}
		}

		// Token: 0x060024D9 RID: 9433 RVA: 0x002037F2 File Offset: 0x002019F2
		public void SwitchSort()
		{
			this.spriteRenderer.sortingOrder = 10 - this.spriteRenderer.sortingOrder;
		}

		// Token: 0x060024DA RID: 9434 RVA: 0x0020380D File Offset: 0x00201A0D
		public void ObjectActive(bool toActive = true)
		{
			if (this.objectToActivate != null)
			{
				this.objectToActivate.SetActive(toActive);
			}
		}

		// Token: 0x04004D6A RID: 19818
		[HideInInspector]
		public Animator animator;

		// Token: 0x04004D6B RID: 19819
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x04004D6C RID: 19820
		public GameObject objectToActivate;
	}
}
