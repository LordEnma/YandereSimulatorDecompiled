using System;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AE RID: 1454
	public class TipPage : MonoBehaviour
	{
		// Token: 0x0600249B RID: 9371 RVA: 0x001F923C File Offset: 0x001F743C
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

		// Token: 0x0600249C RID: 9372 RVA: 0x001F92F8 File Offset: 0x001F74F8
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

		// Token: 0x0600249D RID: 9373 RVA: 0x001F93B1 File Offset: 0x001F75B1
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

		// Token: 0x04004C4A RID: 19530
		public TipCard wageCard;

		// Token: 0x04004C4B RID: 19531
		public TipCard totalCard;

		// Token: 0x04004C4C RID: 19532
		private List<TipCard> cards;

		// Token: 0x04004C4D RID: 19533
		private bool stopInteraction;
	}
}
