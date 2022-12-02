using UnityEngine;

public class MoneyWadScript : MonoBehaviour
{
	public PromptScript Prompt;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount != 0f)
		{
			return;
		}
		Prompt.Yandere.Inventory.Money += 20f;
		Prompt.Yandere.Inventory.UpdateMoney();
		if (Prompt.Yandere.Inventory.Money > 1000f)
		{
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("RichGirl", 1);
			}
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("a", 1);
			}
		}
		Object.Destroy(base.gameObject);
	}
}
