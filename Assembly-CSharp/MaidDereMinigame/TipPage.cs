using System;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B8 RID: 1464
	public class TipPage : MonoBehaviour
	{
		// Token: 0x060024DF RID: 9439 RVA: 0x001FF03C File Offset: 0x001FD23C
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

		// Token: 0x060024E0 RID: 9440 RVA: 0x001FF0F8 File Offset: 0x001FD2F8
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

		// Token: 0x060024E1 RID: 9441 RVA: 0x001FF1B1 File Offset: 0x001FD3B1
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

		// Token: 0x04004D0E RID: 19726
		public TipCard wageCard;

		// Token: 0x04004D0F RID: 19727
		public TipCard totalCard;

		// Token: 0x04004D10 RID: 19728
		private List<TipCard> cards;

		// Token: 0x04004D11 RID: 19729
		private bool stopInteraction;
	}
}
