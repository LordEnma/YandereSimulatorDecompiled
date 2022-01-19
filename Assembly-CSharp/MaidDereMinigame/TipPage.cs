using System;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B1 RID: 1457
	public class TipPage : MonoBehaviour
	{
		// Token: 0x060024A8 RID: 9384 RVA: 0x001FA8AC File Offset: 0x001F8AAC
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

		// Token: 0x060024A9 RID: 9385 RVA: 0x001FA968 File Offset: 0x001F8B68
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

		// Token: 0x060024AA RID: 9386 RVA: 0x001FAA21 File Offset: 0x001F8C21
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

		// Token: 0x04004C65 RID: 19557
		public TipCard wageCard;

		// Token: 0x04004C66 RID: 19558
		public TipCard totalCard;

		// Token: 0x04004C67 RID: 19559
		private List<TipCard> cards;

		// Token: 0x04004C68 RID: 19560
		private bool stopInteraction;
	}
}
