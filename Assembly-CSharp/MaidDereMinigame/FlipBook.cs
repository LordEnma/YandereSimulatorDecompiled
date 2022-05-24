using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B1 RID: 1457
	public class FlipBook : MonoBehaviour
	{
		// Token: 0x1700052D RID: 1325
		// (get) Token: 0x060024D0 RID: 9424 RVA: 0x00203B9F File Offset: 0x00201D9F
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

		// Token: 0x060024D1 RID: 9425 RVA: 0x00203BBD File Offset: 0x00201DBD
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

		// Token: 0x060024D2 RID: 9426 RVA: 0x00203BF3 File Offset: 0x00201DF3
		private IEnumerator OpenBook()
		{
			yield return new WaitForSeconds(1f);
			this.FlipToPage(1);
			yield break;
		}

		// Token: 0x060024D3 RID: 9427 RVA: 0x00203C04 File Offset: 0x00201E04
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

		// Token: 0x060024D4 RID: 9428 RVA: 0x00203CCD File Offset: 0x00201ECD
		public void StopInputs()
		{
			this.stopInputs = true;
		}

		// Token: 0x060024D5 RID: 9429 RVA: 0x00203CD6 File Offset: 0x00201ED6
		public void FlipToPage(int page)
		{
			SFXController.PlaySound(SFXController.Sounds.PageTurn);
			base.StartCoroutine(this.FlipToPageRoutine(page));
		}

		// Token: 0x060024D6 RID: 9430 RVA: 0x00203CEC File Offset: 0x00201EEC
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

		// Token: 0x04004D69 RID: 19817
		public SpriteRenderer Cover;

		// Token: 0x04004D6A RID: 19818
		public SpriteRenderer Ryoba;

		// Token: 0x04004D6B RID: 19819
		public Sprite[] CoverSprites;

		// Token: 0x04004D6C RID: 19820
		public Sprite[] RyobaSprites;

		// Token: 0x04004D6D RID: 19821
		private static FlipBook instance;

		// Token: 0x04004D6E RID: 19822
		public List<FlipBookPage> flipBookPages;

		// Token: 0x04004D6F RID: 19823
		private int curPage;

		// Token: 0x04004D70 RID: 19824
		private bool canGoBack;

		// Token: 0x04004D71 RID: 19825
		private bool stopInputs;

		// Token: 0x04004D72 RID: 19826
		private bool UpdateRyobaSprite;
	}
}
