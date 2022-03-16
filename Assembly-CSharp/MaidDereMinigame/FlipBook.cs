using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A9 RID: 1449
	public class FlipBook : MonoBehaviour
	{
		// Token: 0x1700052B RID: 1323
		// (get) Token: 0x0600249C RID: 9372 RVA: 0x001FE213 File Offset: 0x001FC413
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

		// Token: 0x0600249D RID: 9373 RVA: 0x001FE231 File Offset: 0x001FC431
		private void Awake()
		{
			base.StartCoroutine(this.OpenBook());
		}

		// Token: 0x0600249E RID: 9374 RVA: 0x001FE240 File Offset: 0x001FC440
		private IEnumerator OpenBook()
		{
			yield return new WaitForSeconds(1f);
			this.FlipToPage(1);
			yield break;
		}

		// Token: 0x0600249F RID: 9375 RVA: 0x001FE24F File Offset: 0x001FC44F
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

		// Token: 0x060024A0 RID: 9376 RVA: 0x001FE27E File Offset: 0x001FC47E
		public void StopInputs()
		{
			this.stopInputs = true;
		}

		// Token: 0x060024A1 RID: 9377 RVA: 0x001FE287 File Offset: 0x001FC487
		public void FlipToPage(int page)
		{
			SFXController.PlaySound(SFXController.Sounds.PageTurn);
			base.StartCoroutine(this.FlipToPageRoutine(page));
		}

		// Token: 0x060024A2 RID: 9378 RVA: 0x001FE29D File Offset: 0x001FC49D
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

		// Token: 0x04004CD8 RID: 19672
		private static FlipBook instance;

		// Token: 0x04004CD9 RID: 19673
		public List<FlipBookPage> flipBookPages;

		// Token: 0x04004CDA RID: 19674
		private int curPage;

		// Token: 0x04004CDB RID: 19675
		private bool canGoBack;

		// Token: 0x04004CDC RID: 19676
		private bool stopInputs;
	}
}
