using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A4 RID: 1444
	public class FlipBook : MonoBehaviour
	{
		// Token: 0x1700052A RID: 1322
		// (get) Token: 0x0600247E RID: 9342 RVA: 0x001FB8D3 File Offset: 0x001F9AD3
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

		// Token: 0x0600247F RID: 9343 RVA: 0x001FB8F1 File Offset: 0x001F9AF1
		private void Awake()
		{
			base.StartCoroutine(this.OpenBook());
		}

		// Token: 0x06002480 RID: 9344 RVA: 0x001FB900 File Offset: 0x001F9B00
		private IEnumerator OpenBook()
		{
			yield return new WaitForSeconds(1f);
			this.FlipToPage(1);
			yield break;
		}

		// Token: 0x06002481 RID: 9345 RVA: 0x001FB90F File Offset: 0x001F9B0F
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

		// Token: 0x06002482 RID: 9346 RVA: 0x001FB93E File Offset: 0x001F9B3E
		public void StopInputs()
		{
			this.stopInputs = true;
		}

		// Token: 0x06002483 RID: 9347 RVA: 0x001FB947 File Offset: 0x001F9B47
		public void FlipToPage(int page)
		{
			SFXController.PlaySound(SFXController.Sounds.PageTurn);
			base.StartCoroutine(this.FlipToPageRoutine(page));
		}

		// Token: 0x06002484 RID: 9348 RVA: 0x001FB95D File Offset: 0x001F9B5D
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

		// Token: 0x04004C5C RID: 19548
		private static FlipBook instance;

		// Token: 0x04004C5D RID: 19549
		public List<FlipBookPage> flipBookPages;

		// Token: 0x04004C5E RID: 19550
		private int curPage;

		// Token: 0x04004C5F RID: 19551
		private bool canGoBack;

		// Token: 0x04004C60 RID: 19552
		private bool stopInputs;
	}
}
