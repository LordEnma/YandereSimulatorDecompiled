using System;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005BE RID: 1470
	public class TipPage : MonoBehaviour
	{
		// Token: 0x060024F7 RID: 9463 RVA: 0x00200DDC File Offset: 0x001FEFDC
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

		// Token: 0x060024F8 RID: 9464 RVA: 0x00200E98 File Offset: 0x001FF098
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

		// Token: 0x060024F9 RID: 9465 RVA: 0x00200F51 File Offset: 0x001FF151
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

		// Token: 0x04004D44 RID: 19780
		public TipCard wageCard;

		// Token: 0x04004D45 RID: 19781
		public TipCard totalCard;

		// Token: 0x04004D46 RID: 19782
		private List<TipCard> cards;

		// Token: 0x04004D47 RID: 19783
		private bool stopInteraction;
	}
}
