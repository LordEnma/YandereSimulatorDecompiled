// Decompiled with JetBrains decompiler
// Type: FindStudentLockerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class FindStudentLockerScript : MonoBehaviour
{
  public TutorialWindowScript TutorialWindow;
  public StudentScript TargetedStudent;
  public PromptScript Prompt;
  public int Phase = 1;

  private void Update()
  {
    if ((Object) this.TargetedStudent == (Object) null)
    {
      if ((double) this.Prompt.DistanceSqr < 5.0)
        this.TutorialWindow.ShowLockerMessage = true;
      if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
        return;
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
    }
    else if (!this.TargetedStudent.Alive || this.TargetedStudent.Alarmed)
      this.RestorePrompt();
    else if (this.Phase == 1)
    {
      if (!this.TargetedStudent.Meeting)
        return;
      ++this.Phase;
    }
    else
    {
      if (this.TargetedStudent.Meeting)
        return;
      this.RestorePrompt();
    }
  }

  private void RestorePrompt()
  {
    this.Prompt.Label[0].text = "     Find Student Locker";
    this.TargetedStudent = (StudentScript) null;
    this.Prompt.enabled = true;
    this.Phase = 1;
  }
}
