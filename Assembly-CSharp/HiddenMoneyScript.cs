using System.Globalization;
using UnityEngine;

public class HiddenMoneyScript : MonoBehaviour
{
	public PromptScript Prompt;

	public UILabel MoneyLabel;

	public int ID;

	private void Start()
	{
		if (GameGlobals.GetHiddenMoney(ID) == 1)
		{
			Prompt.Hide();
			Prompt.enabled = false;
			base.gameObject.SetActive(value: false);
		}
	}

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			GameGlobals.SetHiddenMoney(ID, 1);
			PlayerGlobals.Money += 100f;
			MoneyLabel.text = "$" + PlayerGlobals.Money.ToString("F2", NumberFormatInfo.InvariantInfo);
			Prompt.Hide();
			Prompt.enabled = false;
			base.gameObject.SetActive(value: false);
		}
	}
}
