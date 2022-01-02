using System;
using System.Globalization;
using System.Threading;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AC RID: 1452
	public class TipCard : MonoBehaviour
	{
		// Token: 0x06002498 RID: 9368 RVA: 0x001F9070 File Offset: 0x001F7270
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

		// Token: 0x04004C48 RID: 19528
		[Reorderable]
		public SpriteRenderers digits;

		// Token: 0x04004C49 RID: 19529
		public SpriteRenderer dollarSign;
	}
}
