using System;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B1 RID: 1457
	public class TipPage : MonoBehaviour
	{
		// Token: 0x060024AC RID: 9388 RVA: 0x001FB14C File Offset: 0x001F934C
		public void Init()
		{
			this.cards = new List<TipCard>();
			foreach (object obj in base.transform.GetChild(0))
			{
				foreach (object obj2 in ((Transform)obj))
				{
					Transform transform = (Transform)obj2;
					this.cards.Add(transform.GetComponent<TipCard>());
				}
			}
			base.gameObject.SetActive(false);
		}

		// Token: 0x060024AD RID: 9389 RVA: 0x001FB208 File Offset: 0x001F9408
		public void DisplayTips(List<float> tips)
		{
			if (tips == null)
			{
				tips = new List<float>();
			}
			base.gameObject.SetActive(true);
			float num = 0f;
			for (int i = 0; i < this.cards.Count; i++)
			{
				if (tips.Count > i)
				{
					this.cards[i].SetTip(tips[i]);
					num += tips[i];
				}
				else
				{
					this.cards[i].SetTip(0f);
				}
			}
			float basePay = GameController.Instance.activeDifficultyVariables.basePay;
			GameController.Instance.totalPayout = num + basePay;
			this.wageCard.SetTip(basePay);
			this.totalCard.SetTip(num + basePay);
		}

		// Token: 0x060024AE RID: 9390 RVA: 0x001FB2C1 File Offset: 0x001F94C1
		private void Update()
		{
			if (this.stopInteraction)
			{
				return;
			}
			if (Input.GetButtonDown("A"))
			{
				GameController.GoToExitScene(true);
				this.stopInteraction = true;
			}
		}

		// Token: 0x04004C70 RID: 19568
		public TipCard wageCard;

		// Token: 0x04004C71 RID: 19569
		public TipCard totalCard;

		// Token: 0x04004C72 RID: 19570
		private List<TipCard> cards;

		// Token: 0x04004C73 RID: 19571
		private bool stopInteraction;
	}
}
