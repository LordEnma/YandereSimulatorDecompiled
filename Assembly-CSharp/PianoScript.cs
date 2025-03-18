using UnityEngine;

public class PianoScript : MonoBehaviour
{
	public TaskTapePlayerScript TapePlayer;

	public PromptScript Prompt;

	public AudioSource[] Notes;

	public int ID;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount < 1f && Prompt.Circle[0].fillAmount > 0f)
		{
			Prompt.Circle[0].fillAmount = 0f;
			Notes[ID].Play();
			ID++;
			if (TapePlayer != null && TapePlayer.gameObject.activeInHierarchy)
			{
				TapePlayer.NotesRecorded++;
				TapePlayer.MelodyCheck();
			}
			if (ID == Notes.Length)
			{
				ID = 0;
			}
		}
	}
}
