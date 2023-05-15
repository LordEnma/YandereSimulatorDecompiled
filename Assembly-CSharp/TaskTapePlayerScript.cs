using UnityEngine;

public class TaskTapePlayerScript : MonoBehaviour
{
	public TapePlayerScript TapePlayer;

	public GameObject TapePlayerObject;

	public PromptScript Prompt;

	public int NotesRecorded;

	private void Start()
	{
		if (!GameGlobals.Eighties)
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
			TapePlayerObject.SetActive(value: true);
			Prompt.HideButton[0] = true;
		}
		if (Prompt.Circle[1].fillAmount == 0f)
		{
			TapePlayer.MelodyRecording = true;
			TapePlayerObject.SetActive(value: false);
			Prompt.Hide();
			Prompt.enabled = false;
		}
	}

	public void MelodyCheck()
	{
		if (NotesRecorded > 28)
		{
			Prompt.HideButton[1] = false;
		}
	}
}
