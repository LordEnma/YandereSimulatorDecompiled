using System;
using System.Globalization;
using System.Threading;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B0 RID: 1456
	public class TipCard : MonoBehaviour
	{
		// Token: 0x060024B5 RID: 9397 RVA: 0x001FB950 File Offset: 0x001F9B50
		public void SetTip(float tip)
		{
			Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us");
			if (tip == 0f)
			{
				base.gameObject.SetActive(false);
			}
			string text = string.Format("{0:#.00}", tip).Replace(".", "");
			string text2 = "";
			for (int i = text.Length - 1; i >= 0; i--)
			{
				text2 += text[i].ToString();
			}
			for (int j = 0; j < text2.Length; j++)
			{
				int index = -1;
				if (int.TryParse(text2[j].ToString(), NumberStyles.Float, NumberFormatInfo.InvariantInfo, out index))
				{
					this.digits[j].sprite = GameController.Instance.numbers[index];
				}
				else
				{
					Debug.LogError("There was an issue while parsing the value in TipCard.SetTip");
				}
			}
			if (text2.Length <= 3)
			{
				this.digits[3].sprite = GameController.Instance.numbers[10];
				this.dollarSign.gameObject.SetActive(false);
			}
			if (text2.Length <= 4 && this.digits.Count > 4)
			{
				this.digits[4].sprite = GameController.Instance.numbers[10];
				this.dollarSign.gameObject.SetActive(false);
				if (text2.Length < 4)
				{
					this.digits[3].sprite = GameController.Instance.numbers[10];
					this.digits[4].gameObject.SetActive(false);
				}
			}
		}

		// Token: 0x04004C80 RID: 19584
		[Reorderable]
		public SpriteRenderers digits;

		// Token: 0x04004C81 RID: 19585
		public SpriteRenderer dollarSign;
	}
}
