using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A1 RID: 1441
	public class FlipBook : MonoBehaviour
	{
		// Token: 0x17000528 RID: 1320
		// (get) Token: 0x06002463 RID: 9315 RVA: 0x001F8DB3 File Offset: 0x001F6FB3
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

		// Token: 0x06002464 RID: 9316 RVA: 0x001F8DD1 File Offset: 0x001F6FD1
		private void Awake()
		{
			base.StartCoroutine(this.OpenBook());
		}

		// Token: 0x06002465 RID: 9317 RVA: 0x001F8DE0 File Offset: 0x001F6FE0
		private IEnumerator OpenBook()
		{
			yield return new WaitForSeconds(1f);
			this.FlipToPage(1);
			yield break;
		}

		// Token: 0x06002466 RID: 9318 RVA: 0x001F8DEF File Offset: 0x001F6FEF
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

		// Token: 0x06002467 RID: 9319 RVA: 0x001F8E1E File Offset: 0x001F701E
		public void StopInputs()
		{
			this.stopInputs = true;
		}

		// Token: 0x06002468 RID: 9320 RVA: 0x001F8E27 File Offset: 0x001F7027
		public void FlipToPage(int page)
		{
			SFXController.PlaySound(SFXController.Sounds.PageTurn);
			base.StartCoroutine(this.FlipToPageRoutine(page));
		}

		// Token: 0x06002469 RID: 9321 RVA: 0x001F8E3D File Offset: 0x001F703D
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

		// Token: 0x04004C28 RID: 19496
		private static FlipBook instance;

		// Token: 0x04004C29 RID: 19497
		public List<FlipBookPage> flipBookPages;

		// Token: 0x04004C2A RID: 19498
		private int curPage;

		// Token: 0x04004C2B RID: 19499
		private bool canGoBack;

		// Token: 0x04004C2C RID: 19500
		private bool stopInputs;
	}
}
