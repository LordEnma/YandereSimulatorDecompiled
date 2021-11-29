using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059D RID: 1437
	public class FlipBook : MonoBehaviour
	{
		// Token: 0x17000527 RID: 1319
		// (get) Token: 0x06002444 RID: 9284 RVA: 0x001F66EF File Offset: 0x001F48EF
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

		// Token: 0x06002445 RID: 9285 RVA: 0x001F670D File Offset: 0x001F490D
		private void Awake()
		{
			base.StartCoroutine(this.OpenBook());
		}

		// Token: 0x06002446 RID: 9286 RVA: 0x001F671C File Offset: 0x001F491C
		private IEnumerator OpenBook()
		{
			yield return new WaitForSeconds(1f);
			this.FlipToPage(1);
			yield break;
		}

		// Token: 0x06002447 RID: 9287 RVA: 0x001F672B File Offset: 0x001F492B
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

		// Token: 0x06002448 RID: 9288 RVA: 0x001F675A File Offset: 0x001F495A
		public void StopInputs()
		{
			this.stopInputs = true;
		}

		// Token: 0x06002449 RID: 9289 RVA: 0x001F6763 File Offset: 0x001F4963
		public void FlipToPage(int page)
		{
			SFXController.PlaySound(SFXController.Sounds.PageTurn);
			base.StartCoroutine(this.FlipToPageRoutine(page));
		}

		// Token: 0x0600244A RID: 9290 RVA: 0x001F6779 File Offset: 0x001F4979
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

		// Token: 0x04004BCC RID: 19404
		private static FlipBook instance;

		// Token: 0x04004BCD RID: 19405
		public List<FlipBookPage> flipBookPages;

		// Token: 0x04004BCE RID: 19406
		private int curPage;

		// Token: 0x04004BCF RID: 19407
		private bool canGoBack;

		// Token: 0x04004BD0 RID: 19408
		private bool stopInputs;
	}
}
