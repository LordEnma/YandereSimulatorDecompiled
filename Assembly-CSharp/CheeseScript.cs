using UnityEngine;

public class CheeseScript : MonoBehaviour
{
	public GameObject GlowingEye;

	public PromptScript Prompt;

	public UILabel Subtitle;

	public float Timer;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Subtitle.text = "Knowing the mouse might one day leave its hole and get the cheese...It fills you with determination.";
			Prompt.Hide();
			Prompt.enabled = false;
			GlowingEye.SetActive(value: true);
			Timer = 5f;
		}
		if (Timer > 0f)
		{
			Timer -= Time.deltaTime;
			if (Timer <= 0f)
			{
				Prompt.enabled = true;
				Subtitle.text = string.Empty;
			}
		}
	}
}
