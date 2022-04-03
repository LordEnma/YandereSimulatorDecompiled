using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AE RID: 1454
	public class FlipBook : MonoBehaviour
	{
		// Token: 0x1700052B RID: 1323
		// (get) Token: 0x060024AC RID: 9388 RVA: 0x001FFA83 File Offset: 0x001FDC83
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

		// Token: 0x060024AD RID: 9389 RVA: 0x001FFAA1 File Offset: 0x001FDCA1
		private void Awake()
		{
			base.StartCoroutine(this.OpenBook());
		}

		// Token: 0x060024AE RID: 9390 RVA: 0x001FFAB0 File Offset: 0x001FDCB0
		private IEnumerator OpenBook()
		{
			yield return new WaitForSeconds(1f);
			this.FlipToPage(1);
			yield break;
		}

		// Token: 0x060024AF RID: 9391 RVA: 0x001FFABF File Offset: 0x001FDCBF
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

		// Token: 0x060024B0 RID: 9392 RVA: 0x001FFAEE File Offset: 0x001FDCEE
		public void StopInputs()
		{
			this.stopInputs = true;
		}

		// Token: 0x060024B1 RID: 9393 RVA: 0x001FFAF7 File Offset: 0x001FDCF7
		public void FlipToPage(int page)
		{
			SFXController.PlaySound(SFXController.Sounds.PageTurn);
			base.StartCoroutine(this.FlipToPageRoutine(page));
		}

		// Token: 0x060024B2 RID: 9394 RVA: 0x001FFB0D File Offset: 0x001FDD0D
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

		// Token: 0x04004D0A RID: 19722
		private static FlipBook instance;

		// Token: 0x04004D0B RID: 19723
		public List<FlipBookPage> flipBookPages;

		// Token: 0x04004D0C RID: 19724
		private int curPage;

		// Token: 0x04004D0D RID: 19725
		private bool canGoBack;

		// Token: 0x04004D0E RID: 19726
		private bool stopInputs;
	}
}
