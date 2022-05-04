using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B1 RID: 1457
	public class FlipBookPage : MonoBehaviour
	{
		// Token: 0x060024CD RID: 9421 RVA: 0x00202152 File Offset: 0x00200352
		private void Awake()
		{
			this.animator = base.GetComponent<Animator>();
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
		}

		// Token: 0x060024CE RID: 9422 RVA: 0x0020216C File Offset: 0x0020036C
		public void Transition(bool toOpen)
		{
			this.animator.SetTrigger(toOpen ? "OpenPage" : "ClosePage");
			if (this.objectToActivate != null)
			{
				this.objectToActivate.SetActive(false);
			}
		}

		// Token: 0x060024CF RID: 9423 RVA: 0x002021A2 File Offset: 0x002003A2
		public void SwitchSort()
		{
			this.spriteRenderer.sortingOrder = 10 - this.spriteRenderer.sortingOrder;
		}

		// Token: 0x060024D0 RID: 9424 RVA: 0x002021BD File Offset: 0x002003BD
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
