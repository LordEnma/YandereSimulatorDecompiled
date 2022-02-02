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
		// (get) Token: 0x06002469 RID: 9321 RVA: 0x001FA323 File Offset: 0x001F8523
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

		// Token: 0x0600246A RID: 9322 RVA: 0x001FA341 File Offset: 0x001F8541
		private void Awake()
		{
			base.StartCoroutine(this.OpenBook());
		}

		// Token: 0x0600246B RID: 9323 RVA: 0x001FA350 File Offset: 0x001F8550
		private IEnumerator OpenBook()
		{
			yield return new WaitForSeconds(1f);
			this.FlipToPage(1);
			yield break;
		}

		// Token: 0x0600246C RID: 9324 RVA: 0x001FA35F File Offset: 0x001F855F
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

		// Token: 0x0600246D RID: 9325 RVA: 0x001FA38E File Offset: 0x001F858E
		public void StopInputs()
		{
			this.stopInputs = true;
		}

		// Token: 0x0600246E RID: 9326 RVA: 0x001FA397 File Offset: 0x001F8597
		public void FlipToPage(int page)
		{
			SFXController.PlaySound(SFXController.Sounds.PageTurn);
			base.StartCoroutine(this.FlipToPageRoutine(page));
		}

		// Token: 0x0600246F RID: 9327 RVA: 0x001FA3AD File Offset: 0x001F85AD
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

		// Token: 0x04004C3A RID: 19514
		private static FlipBook instance;

		// Token: 0x04004C3B RID: 19515
		public List<FlipBookPage> flipBookPages;

		// Token: 0x04004C3C RID: 19516
		private int curPage;

		// Token: 0x04004C3D RID: 19517
		private bool canGoBack;

		// Token: 0x04004C3E RID: 19518
		private bool stopInputs;
	}
}
