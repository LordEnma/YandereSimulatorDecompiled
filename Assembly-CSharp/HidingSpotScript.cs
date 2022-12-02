using UnityEngine;

public class HidingSpotScript : MonoBehaviour
{
	public PromptBarScript PromptBar;

	public PromptScript Prompt;

	public Transform Exit;

	public Transform Spot;

	public string AnimName;

	public bool Bench;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount != 0f)
		{
			return;
		}
		Prompt.Circle[0].fillAmount = 1f;
		if (!Prompt.Yandere.Chased && Prompt.Yandere.Chasers == 0 && Prompt.Yandere.Pursuer == null)
		{
			if (Bench)
			{
				Prompt.Yandere.MyController.radius = 0.1f;
			}
			else
			{
				Prompt.Yandere.MyController.center = new Vector3(Prompt.Yandere.MyController.center.x, 0.3f, Prompt.Yandere.MyController.center.z);
				Prompt.Yandere.MyController.radius = 0f;
				Prompt.Yandere.MyController.height = 0.5f;
			}
			Prompt.Yandere.HideAnim = AnimName;
			Prompt.Yandere.HidingSpot = Spot;
			Prompt.Yandere.ExitSpot = Exit;
			Prompt.Yandere.CanMove = false;
			Prompt.Yandere.Hiding = true;
			Prompt.Yandere.EmptyHands();
			PromptBar.ClearButtons();
			PromptBar.Label[1].text = "Stop";
			PromptBar.UpdateButtons();
			PromptBar.Show = true;
		}
	}
}
