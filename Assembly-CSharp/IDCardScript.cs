using UnityEngine;

public class IDCardScript : MonoBehaviour
{
	public PromptScript Prompt;

	public bool Fake;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Circle[0].fillAmount = 1f;
			Prompt.Yandere.StolenObject = base.gameObject;
			if (!Fake)
			{
				Prompt.Yandere.Inventory.IDCard = true;
				Prompt.Yandere.TheftTimer = 1f;
			}
			else
			{
				Prompt.Yandere.Inventory.FakeID = true;
			}
			Prompt.Hide();
			base.gameObject.SetActive(false);
		}
	}
}
