using System;
using UnityEngine;

// Token: 0x020002C8 RID: 712
public class FindStudentLockerScript : MonoBehaviour
{
	// Token: 0x06001492 RID: 5266 RVA: 0x000C9BD8 File Offset: 0x000C7DD8
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

	// Token: 0x06001493 RID: 5267 RVA: 0x000C9E1F File Offset: 0x000C801F
	private void RestorePrompt()
	{
		this.Prompt.Label[0].text = "     Find Student Locker";
		this.TargetedStudent = null;
		this.Prompt.enabled = true;
		this.Phase = 1;
	}

	// Token: 0x0400201B RID: 8219
	public TutorialWindowScript TutorialWindow;

	// Token: 0x0400201C RID: 8220
	public StudentScript TargetedStudent;

	// Token: 0x0400201D RID: 8221
	public PromptScript Prompt;

	// Token: 0x0400201E RID: 8222
	public int Phase = 1;
}
