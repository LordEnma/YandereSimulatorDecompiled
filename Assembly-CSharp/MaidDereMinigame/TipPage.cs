using System;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B4 RID: 1460
	public class TipPage : MonoBehaviour
	{
		// Token: 0x060024C7 RID: 9415 RVA: 0x001FD0D4 File Offset: 0x001FB2D4
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

		// Token: 0x060024C8 RID: 9416 RVA: 0x001FD190 File Offset: 0x001FB390
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

		// Token: 0x060024C9 RID: 9417 RVA: 0x001FD249 File Offset: 0x001FB449
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

		// Token: 0x04004CAF RID: 19631
		public TipCard wageCard;

		// Token: 0x04004CB0 RID: 19632
		public TipCard totalCard;

		// Token: 0x04004CB1 RID: 19633
		private List<TipCard> cards;

		// Token: 0x04004CB2 RID: 19634
		private bool stopInteraction;
	}
}
