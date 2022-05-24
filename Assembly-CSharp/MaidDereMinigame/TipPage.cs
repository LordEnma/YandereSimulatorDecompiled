using System;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005C0 RID: 1472
	public class TipPage : MonoBehaviour
	{
		// Token: 0x06002513 RID: 9491 RVA: 0x00204A8C File Offset: 0x00202C8C
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

		// Token: 0x06002514 RID: 9492 RVA: 0x00204B48 File Offset: 0x00202D48
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

		// Token: 0x06002515 RID: 9493 RVA: 0x00204C01 File Offset: 0x00202E01
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

		// Token: 0x04004DA4 RID: 19876
		public TipCard wageCard;

		// Token: 0x04004DA5 RID: 19877
		public TipCard totalCard;

		// Token: 0x04004DA6 RID: 19878
		private List<TipCard> cards;

		// Token: 0x04004DA7 RID: 19879
		private bool stopInteraction;
	}
}
