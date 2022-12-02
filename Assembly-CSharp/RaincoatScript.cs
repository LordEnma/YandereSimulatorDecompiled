using UnityEngine;

public class RaincoatScript : MonoBehaviour
{
	public PromptScript Prompt;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Circle[0].fillAmount = 1f;
			if (Prompt.Yandere.Invisible)
			{
				Prompt.Yandere.WearRaincoat();
				Object.Destroy(base.gameObject);
			}
		}
	}
}
