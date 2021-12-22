using System;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AE RID: 1454
	public class TipPage : MonoBehaviour
	{
		// Token: 0x06002498 RID: 9368 RVA: 0x001F8C4C File Offset: 0x001F6E4C
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

		// Token: 0x06002499 RID: 9369 RVA: 0x001F8D08 File Offset: 0x001F6F08
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

		// Token: 0x0600249A RID: 9370 RVA: 0x001F8DC1 File Offset: 0x001F6FC1
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

		// Token: 0x04004C41 RID: 19521
		public TipCard wageCard;

		// Token: 0x04004C42 RID: 19522
		public TipCard totalCard;

		// Token: 0x04004C43 RID: 19523
		private List<TipCard> cards;

		// Token: 0x04004C44 RID: 19524
		private bool stopInteraction;
	}
}
