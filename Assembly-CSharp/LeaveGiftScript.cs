using UnityEngine;

public class LeaveGiftScript : MonoBehaviour
{
	public EndOfDayScript EndOfDay;

	public PromptScript Prompt;

	public GameObject Note;

	public GameObject Box;

	private void Start()
	{
		Note.SetActive(value: false);
		Box.SetActive(value: false);
		EndOfDay.SenpaiGifts = CollectibleGlobals.SenpaiGifts;
		if (EndOfDay.SenpaiGifts == 0)
		{
			Prompt.HideButton[1] = true;
		}
		else
		{
			Debug.Log("CollectibleGlobals.SenpaiGifts is: " + CollectibleGlobals.SenpaiGifts);
		}
		if (MissionModeGlobals.MissionMode)
		{
			Prompt.Hide();
			Prompt.enabled = false;
			base.enabled = false;
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
				Note.SetActive(value: true);
				CheckForDisable();
			}
			else if (Prompt.Circle[1].fillAmount == 0f)
			{
				Prompt.HideButton[1] = true;
				Box.SetActive(value: true);
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
