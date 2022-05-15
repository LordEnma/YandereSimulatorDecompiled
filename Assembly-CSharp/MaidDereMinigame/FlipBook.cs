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
		// (get) Token: 0x060024CF RID: 9423 RVA: 0x00203637 File Offset: 0x00201837
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

		// Token: 0x060024D0 RID: 9424 RVA: 0x00203655 File Offset: 0x00201855
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

		// Token: 0x060024D1 RID: 9425 RVA: 0x0020368B File Offset: 0x0020188B
		private IEnumerator OpenBook()
		{
			yield return new WaitForSeconds(1f);
			this.FlipToPage(1);
			yield break;
		}

		// Token: 0x060024D2 RID: 9426 RVA: 0x0020369C File Offset: 0x0020189C
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

		// Token: 0x060024D3 RID: 9427 RVA: 0x00203765 File Offset: 0x00201965
		public void StopInputs()
		{
			this.stopInputs = true;
		}

		// Token: 0x060024D4 RID: 9428 RVA: 0x0020376E File Offset: 0x0020196E
		public void FlipToPage(int page)
		{
			SFXController.PlaySound(SFXController.Sounds.PageTurn);
			base.StartCoroutine(this.FlipToPageRoutine(page));
		}

		// Token: 0x060024D5 RID: 9429 RVA: 0x00203784 File Offset: 0x00201984
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

		// Token: 0x04004D60 RID: 19808
		public SpriteRenderer Cover;

		// Token: 0x04004D61 RID: 19809
		public SpriteRenderer Ryoba;

		// Token: 0x04004D62 RID: 19810
		public Sprite[] CoverSprites;

		// Token: 0x04004D63 RID: 19811
		public Sprite[] RyobaSprites;

		// Token: 0x04004D64 RID: 19812
		private static FlipBook instance;

		// Token: 0x04004D65 RID: 19813
		public List<FlipBookPage> flipBookPages;

		// Token: 0x04004D66 RID: 19814
		private int curPage;

		// Token: 0x04004D67 RID: 19815
		private bool canGoBack;

		// Token: 0x04004D68 RID: 19816
		private bool stopInputs;

		// Token: 0x04004D69 RID: 19817
		private bool UpdateRyobaSprite;
	}
}
