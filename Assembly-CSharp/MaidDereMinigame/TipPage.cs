using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	public class TipPage : MonoBehaviour
	{
		public TipCard wageCard;

		public TipCard totalCard;

		private List<TipCard> cards;

		private bool stopInteraction;

		public void Init()
		{
			cards = new List<TipCard>();
			foreach (Transform item in base.transform.GetChild(0))
			{
				foreach (Transform item2 in item)
				{
					cards.Add(item2.GetComponent<TipCard>());
				}
			}
			base.gameObject.SetActive(value: false);
		}

		public void DisplayTips(List<float> tips)
		{
			if (tips == null)
			{
				tips = new List<float>();
			}
			base.gameObject.SetActive(value: true);
			float num = 0f;
			for (int i = 0; i < cards.Count; i++)
			{
				if (tips.Count > i)
				{
					cards[i].SetTip(tips[i]);
					num += tips[i];
				}
				else
				{
					cards[i].SetTip(0f);
				}
			}
			float basePay = GameController.Instance.activeDifficultyVariables.basePay;
			GameController.Instance.totalPayout = num + basePay;
			wageCard.SetTip(basePay);
			totalCard.SetTip(num + basePay);
		}

		private void Update()
		{
			if (!stopInteraction && Input.GetButtonDown("A"))
			{
				GameController.GoToExitScene();
				stopInteraction = true;
			}
		}
	}
}
