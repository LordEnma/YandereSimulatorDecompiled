using System;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005BE RID: 1470
	public class TipPage : MonoBehaviour
	{
		// Token: 0x060024FE RID: 9470 RVA: 0x00201838 File Offset: 0x001FFA38
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

		// Token: 0x060024FF RID: 9471 RVA: 0x002018F4 File Offset: 0x001FFAF4
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

		// Token: 0x06002500 RID: 9472 RVA: 0x002019AD File Offset: 0x001FFBAD
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

		// Token: 0x04004D56 RID: 19798
		public TipCard wageCard;

		// Token: 0x04004D57 RID: 19799
		public TipCard totalCard;

		// Token: 0x04004D58 RID: 19800
		private List<TipCard> cards;

		// Token: 0x04004D59 RID: 19801
		private bool stopInteraction;
	}
}
