// Decompiled with JetBrains decompiler
// Type: CounselorDoorScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CounselorDoorScript : MonoBehaviour
{
  public CounselorScript Counselor;
  public PromptScript Prompt;
  public UISprite Darkness;
  public bool FadeOut;
  public bool FadeIn;
  public bool Exit;

  private void Start()
  {
  }

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      this.Prompt.Circle[0].fillAmount = 1f;
      bool flag = false;
      for (int index = 1; index < this.Counselor.StudentManager.Students.Length; ++index)
      {
        StudentScript student = this.Counselor.StudentManager.Students[index];
        if ((Object) student != (Object) null && student.Hunting)
        {
          this.Prompt.Yandere.NotificationManager.CustomText = "A murder is taking place!";
          this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
          flag = true;
        }
      }
      if (!flag && !this.Prompt.Yandere.Chased && this.Prompt.Yandere.Chasers == 0 && !this.FadeIn && (double) this.Prompt.Yandere.Bloodiness == 0.0 && (double) this.Prompt.Yandere.Sanity > 66.666656494140625 && !this.Prompt.Yandere.Carrying && !this.Prompt.Yandere.Dragging)
      {
        if (!this.Counselor.Busy)
        {
          this.Prompt.Yandere.CharacterAnimation.CrossFade(this.Prompt.Yandere.IdleAnim);
          this.Prompt.Yandere.Police.Darkness.enabled = true;
          this.Prompt.Yandere.CanMove = false;
          this.FadeOut = true;
        }
        else
        {
          this.Counselor.CounselorSubtitle.text = this.Counselor.CounselorBusyText;
          this.Counselor.MyAudio.clip = this.Counselor.CounselorBusyClip;
          this.Counselor.MyAudio.Play();
        }
      }
    }
    if (this.FadeOut)
    {
      this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
      if ((double) this.Darkness.color.a == 1.0)
      {
        if (!this.Exit)
        {
          this.Prompt.Yandere.CharacterAnimation.Play("f02_sit_00");
          this.Prompt.Yandere.transform.position = new Vector3(-27.51f, 0.0f, 12f);
          this.Prompt.Yandere.transform.localEulerAngles = new Vector3(0.0f, -90f, 0.0f);
          this.Counselor.Talk();
          this.FadeOut = false;
          this.FadeIn = true;
        }
        else
        {
          if (this.Counselor.Yandere.VtuberID > 0)
            this.Counselor.Yandere.VtuberFace();
          else if (this.Counselor.Eighties)
            this.Counselor.Yandere.RestoreGentleEyes();
          this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, 2f);
          this.Counselor.Quit();
          this.FadeOut = false;
          this.FadeIn = true;
          this.Exit = false;
        }
      }
    }
    if (!this.FadeIn)
      return;
    this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, Mathf.MoveTowards(this.Darkness.color.a, 0.0f, Time.deltaTime));
    if ((double) this.Darkness.color.a != 0.0)
      return;
    this.FadeIn = false;
  }
}
