using System;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005C0 RID: 1472
	public class TipPage : MonoBehaviour
	{
		// Token: 0x06002512 RID: 9490 RVA: 0x00204524 File Offset: 0x00202724
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

		// Token: 0x06002513 RID: 9491 RVA: 0x002045E0 File Offset: 0x002027E0
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

		// Token: 0x06002514 RID: 9492 RVA: 0x00204699 File Offset: 0x00202899
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

		// Token: 0x04004D9B RID: 19867
		public TipCard wageCard;

		// Token: 0x04004D9C RID: 19868
		public TipCard totalCard;

		// Token: 0x04004D9D RID: 19869
		private List<TipCard> cards;

		// Token: 0x04004D9E RID: 19870
		private bool stopInteraction;
	}
}
