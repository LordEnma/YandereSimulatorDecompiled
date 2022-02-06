using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A2 RID: 1442
	public class FlipBook : MonoBehaviour
	{
		// Token: 0x17000529 RID: 1321
		// (get) Token: 0x0600246E RID: 9326 RVA: 0x001FA83F File Offset: 0x001F8A3F
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

		// Token: 0x0600246F RID: 9327 RVA: 0x001FA85D File Offset: 0x001F8A5D
		private void Awake()
		{
			base.StartCoroutine(this.OpenBook());
		}

		// Token: 0x06002470 RID: 9328 RVA: 0x001FA86C File Offset: 0x001F8A6C
		private IEnumerator OpenBook()
		{
			yield return new WaitForSeconds(1f);
			this.FlipToPage(1);
			yield break;
		}

		// Token: 0x06002471 RID: 9329 RVA: 0x001FA87B File Offset: 0x001F8A7B
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

		// Token: 0x06002472 RID: 9330 RVA: 0x001FA8AA File Offset: 0x001F8AAA
		public void StopInputs()
		{
			this.stopInputs = true;
		}

		// Token: 0x06002473 RID: 9331 RVA: 0x001FA8B3 File Offset: 0x001F8AB3
		public void FlipToPage(int page)
		{
			SFXController.PlaySound(SFXController.Sounds.PageTurn);
			base.StartCoroutine(this.FlipToPageRoutine(page));
		}

		// Token: 0x06002474 RID: 9332 RVA: 0x001FA8C9 File Offset: 0x001F8AC9
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

		// Token: 0x04004C43 RID: 19523
		private static FlipBook instance;

		// Token: 0x04004C44 RID: 19524
		public List<FlipBookPage> flipBookPages;

		// Token: 0x04004C45 RID: 19525
		private int curPage;

		// Token: 0x04004C46 RID: 19526
		private bool canGoBack;

		// Token: 0x04004C47 RID: 19527
		private bool stopInputs;
	}
}
