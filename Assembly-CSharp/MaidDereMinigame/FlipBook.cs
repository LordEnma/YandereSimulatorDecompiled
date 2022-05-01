using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B0 RID: 1456
	public class FlipBook : MonoBehaviour
	{
		// Token: 0x1700052C RID: 1324
		// (get) Token: 0x060024C4 RID: 9412 RVA: 0x00201EEB File Offset: 0x002000EB
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

		// Token: 0x060024C5 RID: 9413 RVA: 0x00201F09 File Offset: 0x00200109
		private void Awake()
		{
			base.StartCoroutine(this.OpenBook());
			if (GameGlobals.Eighties)
			{
				this.Ryoba.enabled = true;
				this.UpdateRyobaSprite = true;
				return;
			}
			this.Ryoba.enabled = false;
		}

		// Token: 0x060024C6 RID: 9414 RVA: 0x00201F3F File Offset: 0x0020013F
		private IEnumerator OpenBook()
		{
			yield return new WaitForSeconds(1f);
			this.FlipToPage(1);
			yield break;
		}

		// Token: 0x060024C7 RID: 9415 RVA: 0x00201F50 File Offset: 0x00200150
		private void Update()
		{
			if (this.UpdateRyobaSprite)
			{
				if (this.Cover.sprite == this.CoverSprites[1])
				{
					this.Ryoba.sprite = this.RyobaSprites[1];
				}
				else if (this.Cover.sprite == this.CoverSprites[2])
				{
					this.Ryoba.sprite = this.RyobaSprites[2];
				}
				else if (this.Cover.sprite == this.CoverSprites[3])
				{
					this.Ryoba.enabled = false;
				}
			}
			if (this.stopInputs)
			{
				return;
			}
			if (this.curPage > 1 && Input.GetButtonDown("B") && this.canGoBack)
			{
				this.FlipToPage(1);
			}
		}

		// Token: 0x060024C8 RID: 9416 RVA: 0x00202019 File Offset: 0x00200219
		public void StopInputs()
		{
			this.stopInputs = true;
		}

		// Token: 0x060024C9 RID: 9417 RVA: 0x00202022 File Offset: 0x00200222
		public void FlipToPage(int page)
		{
			SFXController.PlaySound(SFXController.Sounds.PageTurn);
			base.StartCoroutine(this.FlipToPageRoutine(page));
		}

		// Token: 0x060024CA RID: 9418 RVA: 0x00202038 File Offset: 0x00200238
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

		// Token: 0x04004D39 RID: 19769
		public SpriteRenderer Cover;

		// Token: 0x04004D3A RID: 19770
		public SpriteRenderer Ryoba;

		// Token: 0x04004D3B RID: 19771
		public Sprite[] CoverSprites;

		// Token: 0x04004D3C RID: 19772
		public Sprite[] RyobaSprites;

		// Token: 0x04004D3D RID: 19773
		private static FlipBook instance;

		// Token: 0x04004D3E RID: 19774
		public List<FlipBookPage> flipBookPages;

		// Token: 0x04004D3F RID: 19775
		private int curPage;

		// Token: 0x04004D40 RID: 19776
		private bool canGoBack;

		// Token: 0x04004D41 RID: 19777
		private bool stopInputs;

		// Token: 0x04004D42 RID: 19778
		private bool UpdateRyobaSprite;
	}
}
