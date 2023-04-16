using UnityEngine;

public class ClothScript : MonoBehaviour
{
	public PromptScript Prompt;

	public void Start()
	{
		if (!GameGlobals.Eighties)
		{
			Prompt.enabled = false;
			Prompt.Hide();
			base.enabled = false;
		}
	}

	private void Update()
	{
		if (Prompt.Yandere.Inventory.ItemsRequested[3] > Prompt.Yandere.Inventory.Cloth)
		{
			Prompt.enabled = true;
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Prompt.Circle[0].fillAmount = 1f;
				Prompt.Yandere.Inventory.Cloth++;
			}
		}
		else if (Prompt.enabled)
		{
			Prompt.enabled = false;
			Prompt.Hide();
		}
	}
}
