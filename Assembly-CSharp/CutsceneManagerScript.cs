// Decompiled with JetBrains decompiler
// Type: CutsceneManagerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CutsceneManagerScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public CounselorScript Counselor;
  public PromptBarScript PromptBar;
  public EndOfDayScript EndOfDay;
  public PortalScript Portal;
  public UISprite Darkness;
  public UILabel Subtitle;
  public AudioClip[] Voice;
  public string[] Text;
  public int Scheme;
  public int Phase = 1;
  public int Line = 1;

  private void Update()
  {
    AudioSource component = this.GetComponent<AudioSource>();
    if (this.Phase == 1)
    {
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
      if ((double) this.Darkness.color.a != 1.0)
        return;
      if (this.Scheme == 5)
        ++this.Phase;
      else
        this.Phase = 4;
    }
    else if (this.Phase == 2)
    {
      this.Subtitle.text = this.Text[this.Line];
      component.clip = this.Voice[this.Line];
      component.Play();
      ++this.Phase;
    }
    else if (this.Phase == 3)
    {
      if (component.isPlaying && !Input.GetButtonDown("A"))
        return;
      if (this.Line < 2)
      {
        --this.Phase;
        ++this.Line;
      }
      else
      {
        this.Subtitle.text = string.Empty;
        ++this.Phase;
      }
    }
    else if (this.Phase == 4)
    {
      Debug.Log((object) "We're activating EndOfDay from CutsceneManager.");
      this.EndOfDay.gameObject.SetActive(true);
      this.EndOfDay.Phase = 14;
      this.Counselor.LecturePhase = this.Scheme != 5 ? 1 : 5;
      ++this.Phase;
    }
    else if (this.Phase == 6)
    {
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0.0f, Time.deltaTime));
      if ((double) this.Darkness.color.a != 0.0)
        return;
      ++this.Phase;
    }
    else
    {
      if (this.Phase != 7)
        return;
      if (this.Scheme == 5)
      {
        int num = (Object) this.StudentManager.Students[this.StudentManager.RivalID] != (Object) null ? 1 : 0;
      }
      this.PromptBar.ClearButtons();
      this.PromptBar.Show = false;
      this.Portal.Proceed = true;
      this.gameObject.SetActive(false);
      this.Scheme = 0;
    }
  }
}
