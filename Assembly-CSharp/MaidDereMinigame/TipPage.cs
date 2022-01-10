using System;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B0 RID: 1456
	public class TipPage : MonoBehaviour
	{
		// Token: 0x060024A6 RID: 9382 RVA: 0x001F9BDC File Offset: 0x001F7DDC
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

		// Token: 0x060024A7 RID: 9383 RVA: 0x001F9C98 File Offset: 0x001F7E98
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

		// Token: 0x060024A8 RID: 9384 RVA: 0x001F9D51 File Offset: 0x001F7F51
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

		// Token: 0x04004C5E RID: 19550
		public TipCard wageCard;

		// Token: 0x04004C5F RID: 19551
		public TipCard totalCard;

		// Token: 0x04004C60 RID: 19552
		private List<TipCard> cards;

		// Token: 0x04004C61 RID: 19553
		private bool stopInteraction;
	}
}
