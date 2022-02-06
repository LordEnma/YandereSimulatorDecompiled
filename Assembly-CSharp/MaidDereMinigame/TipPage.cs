using System;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B1 RID: 1457
	public class TipPage : MonoBehaviour
	{
		// Token: 0x060024B1 RID: 9393 RVA: 0x001FB668 File Offset: 0x001F9868
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

		// Token: 0x060024B2 RID: 9394 RVA: 0x001FB724 File Offset: 0x001F9924
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

		// Token: 0x060024B3 RID: 9395 RVA: 0x001FB7DD File Offset: 0x001F99DD
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

		// Token: 0x04004C79 RID: 19577
		public TipCard wageCard;

		// Token: 0x04004C7A RID: 19578
		public TipCard totalCard;

		// Token: 0x04004C7B RID: 19579
		private List<TipCard> cards;

		// Token: 0x04004C7C RID: 19580
		private bool stopInteraction;
	}
}
