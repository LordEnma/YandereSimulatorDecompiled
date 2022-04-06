using System;
using UnityEngine;

// Token: 0x020002CC RID: 716
public class FindStudentLockerScript : MonoBehaviour
{
	// Token: 0x060014AF RID: 5295 RVA: 0x000CB91C File Offset: 0x000C9B1C
	private void Update()
	{
		if (this.TargetedStudent == null)
		{
			if (this.Prompt.DistanceSqr < 5f)
			{
				this.TutorialWindow.ShowLockerMessage = true;
			}
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				this.Prompt.Circle[0].fillAmount = 1f;
				this.Prompt.Yandere.PauseScreen.StudentInfoMenu.FindingLocker = true;
				this.Prompt.Yandere.PauseScreen.StudentInfoMenu.gameObject.SetActive(true);
				this.Prompt.Yandere.PauseScreen.StudentInfoMenu.Column = 0;
				this.Prompt.Yandere.PauseScreen.StudentInfoMenu.Row = 0;
				this.Prompt.Yandere.PauseScreen.StudentInfoMenu.UpdateHighlight();
				this.Prompt.StartCoroutine(this.Prompt.Yandere.PauseScreen.StudentInfoMenu.UpdatePortraits());
				this.Prompt.Yandere.PauseScreen.MainMenu.SetActive(false);
				this.Prompt.Yandere.PauseScreen.Panel.enabled = true;
				this.Prompt.Yandere.PauseScreen.Sideways = true;
				this.Prompt.Yandere.PauseScreen.Show = true;
				Time.timeScale = 0.0001f;
				this.Prompt.Yandere.PromptBar.ClearButtons();
				this.Prompt.Yandere.PromptBar.Label[1].text = "Cancel";
				this.Prompt.Yandere.PromptBar.UpdateButtons();
				this.Prompt.Yandere.PromptBar.Show = true;
				return;
			}
		}
		else
		{
			if (!this.TargetedStudent.Alive || this.TargetedStudent.Alarmed)
			{
				this.RestorePrompt();
				return;
			}
			if (this.Phase == 1)
			{
				if (this.TargetedStudent.Meeting)
				{
					this.Phase++;
					return;
				}
			}
			else if (!this.TargetedStudent.Meeting)
			{
				this.RestorePrompt();
			}
		}
	}

	// Token: 0x060014B0 RID: 5296 RVA: 0x000CBB63 File Offset: 0x000C9D63
	private void RestorePrompt()
	{
		this.Prompt.Label[0].text = "     Find Student Locker";
		this.TargetedStudent = null;
		this.Prompt.enabled = true;
		this.Phase = 1;
	}

	// Token: 0x0400205F RID: 8287
	public TutorialWindowScript TutorialWindow;

	// Token: 0x04002060 RID: 8288
	public StudentScript TargetedStudent;

	// Token: 0x04002061 RID: 8289
	public PromptScript Prompt;

	// Token: 0x04002062 RID: 8290
	public int Phase = 1;
}
