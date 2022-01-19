using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A2 RID: 1442
	public class FlipBook : MonoBehaviour
	{
		// Token: 0x17000528 RID: 1320
		// (get) Token: 0x06002465 RID: 9317 RVA: 0x001F9A83 File Offset: 0x001F7C83
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

		// Token: 0x06002466 RID: 9318 RVA: 0x001F9AA1 File Offset: 0x001F7CA1
		private void Awake()
		{
			base.StartCoroutine(this.OpenBook());
		}

		// Token: 0x06002467 RID: 9319 RVA: 0x001F9AB0 File Offset: 0x001F7CB0
		private IEnumerator OpenBook()
		{
			yield return new WaitForSeconds(1f);
			this.FlipToPage(1);
			yield break;
		}

		// Token: 0x06002468 RID: 9320 RVA: 0x001F9ABF File Offset: 0x001F7CBF
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

		// Token: 0x06002469 RID: 9321 RVA: 0x001F9AEE File Offset: 0x001F7CEE
		public void StopInputs()
		{
			this.stopInputs = true;
		}

		// Token: 0x0600246A RID: 9322 RVA: 0x001F9AF7 File Offset: 0x001F7CF7
		public void FlipToPage(int page)
		{
			SFXController.PlaySound(SFXController.Sounds.PageTurn);
			base.StartCoroutine(this.FlipToPageRoutine(page));
		}

		// Token: 0x0600246B RID: 9323 RVA: 0x001F9B0D File Offset: 0x001F7D0D
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

		// Token: 0x04004C2F RID: 19503
		private static FlipBook instance;

		// Token: 0x04004C30 RID: 19504
		public List<FlipBookPage> flipBookPages;

		// Token: 0x04004C31 RID: 19505
		private int curPage;

		// Token: 0x04004C32 RID: 19506
		private bool canGoBack;

		// Token: 0x04004C33 RID: 19507
		private bool stopInputs;
	}
}
