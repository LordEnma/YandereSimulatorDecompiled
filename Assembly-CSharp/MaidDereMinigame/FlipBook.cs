using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A3 RID: 1443
	public class FlipBook : MonoBehaviour
	{
		// Token: 0x1700052A RID: 1322
		// (get) Token: 0x06002475 RID: 9333 RVA: 0x001FACF3 File Offset: 0x001F8EF3
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

		// Token: 0x06002476 RID: 9334 RVA: 0x001FAD11 File Offset: 0x001F8F11
		private void Awake()
		{
			base.StartCoroutine(this.OpenBook());
		}

		// Token: 0x06002477 RID: 9335 RVA: 0x001FAD20 File Offset: 0x001F8F20
		private IEnumerator OpenBook()
		{
			yield return new WaitForSeconds(1f);
			this.FlipToPage(1);
			yield break;
		}

		// Token: 0x06002478 RID: 9336 RVA: 0x001FAD2F File Offset: 0x001F8F2F
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

		// Token: 0x06002479 RID: 9337 RVA: 0x001FAD5E File Offset: 0x001F8F5E
		public void StopInputs()
		{
			this.stopInputs = true;
		}

		// Token: 0x0600247A RID: 9338 RVA: 0x001FAD67 File Offset: 0x001F8F67
		public void FlipToPage(int page)
		{
			SFXController.PlaySound(SFXController.Sounds.PageTurn);
			base.StartCoroutine(this.FlipToPageRoutine(page));
		}

		// Token: 0x0600247B RID: 9339 RVA: 0x001FAD7D File Offset: 0x001F8F7D
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

		// Token: 0x04004C4C RID: 19532
		private static FlipBook instance;

		// Token: 0x04004C4D RID: 19533
		public List<FlipBookPage> flipBookPages;

		// Token: 0x04004C4E RID: 19534
		private int curPage;

		// Token: 0x04004C4F RID: 19535
		private bool canGoBack;

		// Token: 0x04004C50 RID: 19536
		private bool stopInputs;
	}
}
