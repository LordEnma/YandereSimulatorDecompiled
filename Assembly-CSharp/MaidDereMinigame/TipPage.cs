using System;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005BF RID: 1471
	public class TipPage : MonoBehaviour
	{
		// Token: 0x06002508 RID: 9480 RVA: 0x00202ED4 File Offset: 0x002010D4
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

		// Token: 0x06002509 RID: 9481 RVA: 0x00202F90 File Offset: 0x00201190
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

		// Token: 0x0600250A RID: 9482 RVA: 0x00203049 File Offset: 0x00201249
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

		// Token: 0x04004D74 RID: 19828
		public TipCard wageCard;

		// Token: 0x04004D75 RID: 19829
		public TipCard totalCard;

		// Token: 0x04004D76 RID: 19830
		private List<TipCard> cards;

		// Token: 0x04004D77 RID: 19831
		private bool stopInteraction;
	}
}
