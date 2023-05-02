using UnityEngine;

public class TypewriterScript : MonoBehaviour
{
	public PromptScript Prompt;

	public GameObject Window;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Circle[0].fillAmount = 1f;
			Prompt.Yandere.RPGCamera.enabled = false;
			Prompt.Yandere.CanMove = false;
			Time.timeScale = 0.0001f;
			Window.SetActive(value: true);
		}
		if (Window.activeInHierarchy)
		{
			if (Input.GetButtonDown(InputNames.Xbox_A))
			{
				Prompt.Yandere.Police.EndOfDay.ArticleID = 1;
				CloseWindow();
				Disable();
			}
			else if (Input.GetButtonDown(InputNames.Xbox_X))
			{
				Prompt.Yandere.Police.EndOfDay.ArticleID = 2;
				CloseWindow();
				Disable();
			}
			else if (Input.GetButtonDown(InputNames.Xbox_Y))
			{
				Prompt.Yandere.Police.EndOfDay.ArticleID = 3;
				CloseWindow();
				Disable();
			}
			else if (Input.GetButtonDown(InputNames.Xbox_B))
			{
				CloseWindow();
			}
		}
	}

	private void CloseWindow()
	{
		Prompt.Yandere.RPGCamera.enabled = true;
		Prompt.Yandere.CanMove = true;
		Window.SetActive(value: false);
		Time.timeScale = 1f;
	}

	private void Disable()
	{
		Prompt.enabled = false;
		base.enabled = false;
		Prompt.Hide();
	}
}
