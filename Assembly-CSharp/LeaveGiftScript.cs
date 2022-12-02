using UnityEngine;

public class LeaveGiftScript : MonoBehaviour
{
	public EndOfDayScript EndOfDay;

	public PromptScript Prompt;

	public GameObject Note;

	public GameObject Box;

	private void Start()
	{
		Note.SetActive(false);
		Box.SetActive(false);
		EndOfDay.SenpaiGifts = CollectibleGlobals.SenpaiGifts;
		if (EndOfDay.SenpaiGifts == 0)
		{
			Prompt.HideButton[1] = true;
		}
	}

	private void Update()
	{
		if (!Prompt.InView)
		{
			return;
		}
		if (Vector3.Distance(Prompt.Yandere.transform.position, Prompt.Yandere.Senpai.position) > 10f)
		{
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Prompt.HideButton[0] = true;
				Note.SetActive(true);
				CheckForDisable();
			}
			else if (Prompt.Circle[1].fillAmount == 0f)
			{
				Prompt.HideButton[1] = true;
				EndOfDay.SenpaiGifts--;
				Box.SetActive(true);
				CheckForDisable();
			}
		}
		else
		{
			Prompt.Hide();
		}
	}

	private void CheckForDisable()
	{
		if (Prompt.HideButton[0] && Prompt.HideButton[1])
		{
			Prompt.Hide();
			Prompt.enabled = false;
			base.enabled = false;
		}
	}
}
