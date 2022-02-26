using System;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B3 RID: 1459
	public class TipPage : MonoBehaviour
	{
		// Token: 0x060024C1 RID: 9409 RVA: 0x001FC6FC File Offset: 0x001FA8FC
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

		// Token: 0x060024C2 RID: 9410 RVA: 0x001FC7B8 File Offset: 0x001FA9B8
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

		// Token: 0x060024C3 RID: 9411 RVA: 0x001FC871 File Offset: 0x001FAA71
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

		// Token: 0x04004C92 RID: 19602
		public TipCard wageCard;

		// Token: 0x04004C93 RID: 19603
		public TipCard totalCard;

		// Token: 0x04004C94 RID: 19604
		private List<TipCard> cards;

		// Token: 0x04004C95 RID: 19605
		private bool stopInteraction;
	}
}
