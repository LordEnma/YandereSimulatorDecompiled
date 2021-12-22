using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059F RID: 1439
	public class FlipBook : MonoBehaviour
	{
		// Token: 0x17000527 RID: 1319
		// (get) Token: 0x06002455 RID: 9301 RVA: 0x001F7E23 File Offset: 0x001F6023
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

		// Token: 0x06002456 RID: 9302 RVA: 0x001F7E41 File Offset: 0x001F6041
		private void Awake()
		{
			base.StartCoroutine(this.OpenBook());
		}

		// Token: 0x06002457 RID: 9303 RVA: 0x001F7E50 File Offset: 0x001F6050
		private IEnumerator OpenBook()
		{
			yield return new WaitForSeconds(1f);
			this.FlipToPage(1);
			yield break;
		}

		// Token: 0x06002458 RID: 9304 RVA: 0x001F7E5F File Offset: 0x001F605F
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

		// Token: 0x06002459 RID: 9305 RVA: 0x001F7E8E File Offset: 0x001F608E
		public void StopInputs()
		{
			this.stopInputs = true;
		}

		// Token: 0x0600245A RID: 9306 RVA: 0x001F7E97 File Offset: 0x001F6097
		public void FlipToPage(int page)
		{
			SFXController.PlaySound(SFXController.Sounds.PageTurn);
			base.StartCoroutine(this.FlipToPageRoutine(page));
		}

		// Token: 0x0600245B RID: 9307 RVA: 0x001F7EAD File Offset: 0x001F60AD
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

		// Token: 0x04004C0B RID: 19467
		private static FlipBook instance;

		// Token: 0x04004C0C RID: 19468
		public List<FlipBookPage> flipBookPages;

		// Token: 0x04004C0D RID: 19469
		private int curPage;

		// Token: 0x04004C0E RID: 19470
		private bool canGoBack;

		// Token: 0x04004C0F RID: 19471
		private bool stopInputs;
	}
}
