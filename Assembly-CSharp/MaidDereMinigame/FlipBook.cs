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
		// (get) Token: 0x0600246B RID: 9323 RVA: 0x001FA63B File Offset: 0x001F883B
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

		// Token: 0x0600246C RID: 9324 RVA: 0x001FA659 File Offset: 0x001F8859
		private void Awake()
		{
			base.StartCoroutine(this.OpenBook());
		}

		// Token: 0x0600246D RID: 9325 RVA: 0x001FA668 File Offset: 0x001F8868
		private IEnumerator OpenBook()
		{
			yield return new WaitForSeconds(1f);
			this.FlipToPage(1);
			yield break;
		}

		// Token: 0x0600246E RID: 9326 RVA: 0x001FA677 File Offset: 0x001F8877
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

		// Token: 0x0600246F RID: 9327 RVA: 0x001FA6A6 File Offset: 0x001F88A6
		public void StopInputs()
		{
			this.stopInputs = true;
		}

		// Token: 0x06002470 RID: 9328 RVA: 0x001FA6AF File Offset: 0x001F88AF
		public void FlipToPage(int page)
		{
			SFXController.PlaySound(SFXController.Sounds.PageTurn);
			base.StartCoroutine(this.FlipToPageRoutine(page));
		}

		// Token: 0x06002471 RID: 9329 RVA: 0x001FA6C5 File Offset: 0x001F88C5
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

		// Token: 0x04004C40 RID: 19520
		private static FlipBook instance;

		// Token: 0x04004C41 RID: 19521
		public List<FlipBookPage> flipBookPages;

		// Token: 0x04004C42 RID: 19522
		private int curPage;

		// Token: 0x04004C43 RID: 19523
		private bool canGoBack;

		// Token: 0x04004C44 RID: 19524
		private bool stopInputs;
	}
}
