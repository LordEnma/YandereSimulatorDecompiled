using System;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B2 RID: 1458
	public class TipPage : MonoBehaviour
	{
		// Token: 0x060024B8 RID: 9400 RVA: 0x001FBB1C File Offset: 0x001F9D1C
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

		// Token: 0x060024B9 RID: 9401 RVA: 0x001FBBD8 File Offset: 0x001F9DD8
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

		// Token: 0x060024BA RID: 9402 RVA: 0x001FBC91 File Offset: 0x001F9E91
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

		// Token: 0x04004C82 RID: 19586
		public TipCard wageCard;

		// Token: 0x04004C83 RID: 19587
		public TipCard totalCard;

		// Token: 0x04004C84 RID: 19588
		private List<TipCard> cards;

		// Token: 0x04004C85 RID: 19589
		private bool stopInteraction;
	}
}
