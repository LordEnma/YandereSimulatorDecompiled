using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059F RID: 1439
	public class FlipBook : MonoBehaviour
	{
		// Token: 0x17000528 RID: 1320
		// (get) Token: 0x06002458 RID: 9304 RVA: 0x001F8413 File Offset: 0x001F6613
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

		// Token: 0x06002459 RID: 9305 RVA: 0x001F8431 File Offset: 0x001F6631
		private void Awake()
		{
			base.StartCoroutine(this.OpenBook());
		}

		// Token: 0x0600245A RID: 9306 RVA: 0x001F8440 File Offset: 0x001F6640
		private IEnumerator OpenBook()
		{
			yield return new WaitForSeconds(1f);
			this.FlipToPage(1);
			yield break;
		}

		// Token: 0x0600245B RID: 9307 RVA: 0x001F844F File Offset: 0x001F664F
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

		// Token: 0x0600245C RID: 9308 RVA: 0x001F847E File Offset: 0x001F667E
		public void StopInputs()
		{
			this.stopInputs = true;
		}

		// Token: 0x0600245D RID: 9309 RVA: 0x001F8487 File Offset: 0x001F6687
		public void FlipToPage(int page)
		{
			SFXController.PlaySound(SFXController.Sounds.PageTurn);
			base.StartCoroutine(this.FlipToPageRoutine(page));
		}

		// Token: 0x0600245E RID: 9310 RVA: 0x001F849D File Offset: 0x001F669D
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

		// Token: 0x04004C14 RID: 19476
		private static FlipBook instance;

		// Token: 0x04004C15 RID: 19477
		public List<FlipBookPage> flipBookPages;

		// Token: 0x04004C16 RID: 19478
		private int curPage;

		// Token: 0x04004C17 RID: 19479
		private bool canGoBack;

		// Token: 0x04004C18 RID: 19480
		private bool stopInputs;
	}
}
