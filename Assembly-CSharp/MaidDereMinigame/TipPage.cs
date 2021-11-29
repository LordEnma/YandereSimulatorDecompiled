using System;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AC RID: 1452
	public class TipPage : MonoBehaviour
	{
		// Token: 0x06002487 RID: 9351 RVA: 0x001F7518 File Offset: 0x001F5718
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

		// Token: 0x06002488 RID: 9352 RVA: 0x001F75D4 File Offset: 0x001F57D4
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

		// Token: 0x06002489 RID: 9353 RVA: 0x001F768D File Offset: 0x001F588D
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

		// Token: 0x04004C02 RID: 19458
		public TipCard wageCard;

		// Token: 0x04004C03 RID: 19459
		public TipCard totalCard;

		// Token: 0x04004C04 RID: 19460
		private List<TipCard> cards;

		// Token: 0x04004C05 RID: 19461
		private bool stopInteraction;
	}
}
