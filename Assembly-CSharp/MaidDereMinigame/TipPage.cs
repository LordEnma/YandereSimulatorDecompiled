using System;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005BD RID: 1469
	public class TipPage : MonoBehaviour
	{
		// Token: 0x060024EF RID: 9455 RVA: 0x002008AC File Offset: 0x001FEAAC
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

		// Token: 0x060024F0 RID: 9456 RVA: 0x00200968 File Offset: 0x001FEB68
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

		// Token: 0x060024F1 RID: 9457 RVA: 0x00200A21 File Offset: 0x001FEC21
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

		// Token: 0x04004D40 RID: 19776
		public TipCard wageCard;

		// Token: 0x04004D41 RID: 19777
		public TipCard totalCard;

		// Token: 0x04004D42 RID: 19778
		private List<TipCard> cards;

		// Token: 0x04004D43 RID: 19779
		private bool stopInteraction;
	}
}
