using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AF RID: 1455
	public class FlipBook : MonoBehaviour
	{
		// Token: 0x1700052C RID: 1324
		// (get) Token: 0x060024BB RID: 9403 RVA: 0x00200A0F File Offset: 0x001FEC0F
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

		// Token: 0x060024BC RID: 9404 RVA: 0x00200A2D File Offset: 0x001FEC2D
		private void Awake()
		{
			base.StartCoroutine(this.OpenBook());
		}

		// Token: 0x060024BD RID: 9405 RVA: 0x00200A3C File Offset: 0x001FEC3C
		private IEnumerator OpenBook()
		{
			yield return new WaitForSeconds(1f);
			this.FlipToPage(1);
			yield break;
		}

		// Token: 0x060024BE RID: 9406 RVA: 0x00200A4B File Offset: 0x001FEC4B
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

		// Token: 0x060024BF RID: 9407 RVA: 0x00200A7A File Offset: 0x001FEC7A
		public void StopInputs()
		{
			this.stopInputs = true;
		}

		// Token: 0x060024C0 RID: 9408 RVA: 0x00200A83 File Offset: 0x001FEC83
		public void FlipToPage(int page)
		{
			SFXController.PlaySound(SFXController.Sounds.PageTurn);
			base.StartCoroutine(this.FlipToPageRoutine(page));
		}

		// Token: 0x060024C1 RID: 9409 RVA: 0x00200A99 File Offset: 0x001FEC99
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

		// Token: 0x04004D20 RID: 19744
		private static FlipBook instance;

		// Token: 0x04004D21 RID: 19745
		public List<FlipBookPage> flipBookPages;

		// Token: 0x04004D22 RID: 19746
		private int curPage;

		// Token: 0x04004D23 RID: 19747
		private bool canGoBack;

		// Token: 0x04004D24 RID: 19748
		private bool stopInputs;
	}
}
