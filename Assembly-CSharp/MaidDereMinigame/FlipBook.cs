using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A5 RID: 1445
	public class FlipBook : MonoBehaviour
	{
		// Token: 0x1700052A RID: 1322
		// (get) Token: 0x06002484 RID: 9348 RVA: 0x001FC2AB File Offset: 0x001FA4AB
		public static FlipBook Instance
		{
			get
			{
				if (FlipBook.instance == null)
				{
					FlipBook.instance = UnityEngine.Object.FindObjectOfType<FlipBook>();
				}
				return FlipBook.instance;
			}
		}

		// Token: 0x06002485 RID: 9349 RVA: 0x001FC2C9 File Offset: 0x001FA4C9
		private void Awake()
		{
			base.StartCoroutine(this.OpenBook());
		}

		// Token: 0x06002486 RID: 9350 RVA: 0x001FC2D8 File Offset: 0x001FA4D8
		private IEnumerator OpenBook()
		{
			yield return new WaitForSeconds(1f);
			this.FlipToPage(1);
			yield break;
		}

		// Token: 0x06002487 RID: 9351 RVA: 0x001FC2E7 File Offset: 0x001FA4E7
		private void Update()
		{
			if (this.stopInputs)
			{
				return;
			}
			if (this.curPage > 1 && Input.GetButtonDown("B") && this.canGoBack)
			{
				this.FlipToPage(1);
			}
		}

		// Token: 0x06002488 RID: 9352 RVA: 0x001FC316 File Offset: 0x001FA516
		public void StopInputs()
		{
			this.stopInputs = true;
		}

		// Token: 0x06002489 RID: 9353 RVA: 0x001FC31F File Offset: 0x001FA51F
		public void FlipToPage(int page)
		{
			SFXController.PlaySound(SFXController.Sounds.PageTurn);
			base.StartCoroutine(this.FlipToPageRoutine(page));
		}

		// Token: 0x0600248A RID: 9354 RVA: 0x001FC335 File Offset: 0x001FA535
		private IEnumerator FlipToPageRoutine(int page)
		{
			bool flag = this.curPage < page;
			this.canGoBack = false;
			if (flag)
			{
				while (this.curPage < page)
				{
					List<FlipBookPage> list = this.flipBookPages;
					int num = this.curPage;
					this.curPage = num + 1;
					list[num].Transition(flag);
				}
				yield return new WaitForSeconds(0.4f);
				this.flipBookPages[this.curPage].ObjectActive(true);
			}
			else
			{
				this.flipBookPages[this.curPage].ObjectActive(false);
				while (this.curPage > page)
				{
					List<FlipBookPage> list2 = this.flipBookPages;
					int num = this.curPage - 1;
					this.curPage = num;
					list2[num].Transition(flag);
				}
				yield return new WaitForSeconds(0.6f);
				this.flipBookPages[this.curPage].ObjectActive(true);
			}
			this.canGoBack = true;
			yield break;
		}

		// Token: 0x04004C79 RID: 19577
		private static FlipBook instance;

		// Token: 0x04004C7A RID: 19578
		public List<FlipBookPage> flipBookPages;

		// Token: 0x04004C7B RID: 19579
		private int curPage;

		// Token: 0x04004C7C RID: 19580
		private bool canGoBack;

		// Token: 0x04004C7D RID: 19581
		private bool stopInputs;
	}
}
