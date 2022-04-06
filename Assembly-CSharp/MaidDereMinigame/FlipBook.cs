using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AF RID: 1455
	public class FlipBook : MonoBehaviour
	{
		// Token: 0x1700052B RID: 1323
		// (get) Token: 0x060024B4 RID: 9396 RVA: 0x001FFFB3 File Offset: 0x001FE1B3
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

		// Token: 0x060024B5 RID: 9397 RVA: 0x001FFFD1 File Offset: 0x001FE1D1
		private void Awake()
		{
			base.StartCoroutine(this.OpenBook());
		}

		// Token: 0x060024B6 RID: 9398 RVA: 0x001FFFE0 File Offset: 0x001FE1E0
		private IEnumerator OpenBook()
		{
			yield return new WaitForSeconds(1f);
			this.FlipToPage(1);
			yield break;
		}

		// Token: 0x060024B7 RID: 9399 RVA: 0x001FFFEF File Offset: 0x001FE1EF
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

		// Token: 0x060024B8 RID: 9400 RVA: 0x0020001E File Offset: 0x001FE21E
		public void StopInputs()
		{
			this.stopInputs = true;
		}

		// Token: 0x060024B9 RID: 9401 RVA: 0x00200027 File Offset: 0x001FE227
		public void FlipToPage(int page)
		{
			SFXController.PlaySound(SFXController.Sounds.PageTurn);
			base.StartCoroutine(this.FlipToPageRoutine(page));
		}

		// Token: 0x060024BA RID: 9402 RVA: 0x0020003D File Offset: 0x001FE23D
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

		// Token: 0x04004D0E RID: 19726
		private static FlipBook instance;

		// Token: 0x04004D0F RID: 19727
		public List<FlipBookPage> flipBookPages;

		// Token: 0x04004D10 RID: 19728
		private int curPage;

		// Token: 0x04004D11 RID: 19729
		private bool canGoBack;

		// Token: 0x04004D12 RID: 19730
		private bool stopInputs;
	}
}
