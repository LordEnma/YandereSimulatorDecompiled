using UnityEngine;

public class FindStudentLockerScript : MonoBehaviour
{
	public TutorialWindowScript TutorialWindow;

	public StudentScript TargetedStudent;

	public PromptScript Prompt;

	public int Phase = 1;

	private void Update()
	{
		if (TargetedStudent == null)
		{
			if (Prompt.DistanceSqr < 5f)
			{
				TutorialWindow.ShowLockerMessage = true;
			}
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Prompt.Circle[0].fillAmount = 1f;
				Prompt.Yandere.PauseScreen.StudentInfoMenu.FindingLocker = true;
				Prompt.Yandere.PauseScreen.StudentInfoMenu.gameObject.SetActive(true);
				Prompt.Yandere.PauseScreen.StudentInfoMenu.Column = 0;
				Prompt.Yandere.PauseScreen.StudentInfoMenu.Row = 0;
				Prompt.Yandere.PauseScreen.StudentInfoMenu.UpdateHighlight();
				Prompt.StartCoroutine(Prompt.Yandere.PauseScreen.StudentInfoMenu.UpdatePortraits());
				Prompt.Yandere.PauseScreen.MainMenu.SetActive(false);
				Prompt.Yandere.PauseScreen.Panel.enabled = true;
				Prompt.Yandere.PauseScreen.Sideways = true;
				Prompt.Yandere.PauseScreen.Show = true;
				Time.timeScale = 0.0001f;
				Prompt.Yandere.PromptBar.ClearButtons();
				Prompt.Yandere.PromptBar.Label[1].text = "Cancel";
				Prompt.Yandere.PromptBar.UpdateButtons();
				Prompt.Yandere.PromptBar.Show = true;
			}
		}
		else if (!TargetedStudent.Alive || TargetedStudent.Alarmed)
		{
			RestorePrompt();
		}
		else if (Phase == 1)
		{
			if (TargetedStudent.Meeting)
			{
				Phase++;
			}
		}
		else if (!TargetedStudent.Meeting)
		{
			RestorePrompt();
		}
	}

	private void RestorePrompt()
	{
		Prompt.Label[0].text = "     Find Student Locker";
		TargetedStudent = null;
		Prompt.enabled = true;
		Phase = 1;
	}
}
