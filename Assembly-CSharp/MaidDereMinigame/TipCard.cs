using System.Globalization;
using System.Threading;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	public class TipCard : MonoBehaviour
	{
		[Reorderable]
		public SpriteRenderers digits;

		public SpriteRenderer dollarSign;

		public void SetTip(float tip)
		{
			Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us");
			if (tip == 0f)
			{
				base.gameObject.SetActive(false);
			}
			string text = string.Format("{0:#.00}", tip).Replace(".", "");
			string text2 = "";
			for (int num = text.Length - 1; num >= 0; num--)
			{
				text2 += text[num];
			}
			for (int i = 0; i < text2.Length; i++)
			{
				int result = -1;
				if (int.TryParse(text2[i].ToString(), NumberStyles.Float, NumberFormatInfo.InvariantInfo, out result))
				{
					digits[i].sprite = GameController.Instance.numbers[result];
				}
				else
				{
					Debug.LogError("There was an issue while parsing the value in TipCard.SetTip");
				}
			}
			if (text2.Length <= 3)
			{
				digits[3].sprite = GameController.Instance.numbers[10];
				dollarSign.gameObject.SetActive(false);
			}
			if (text2.Length <= 4 && digits.Count > 4)
			{
				digits[4].sprite = GameController.Instance.numbers[10];
				dollarSign.gameObject.SetActive(false);
				if (text2.Length < 4)
				{
					digits[3].sprite = GameController.Instance.numbers[10];
					digits[4].gameObject.SetActive(false);
				}
			}
		}
	}
}
