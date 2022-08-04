// Decompiled with JetBrains decompiler
// Type: PeekScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PeekScript : MonoBehaviour
{
  public InfoChanWindowScript InfoChanWindow;
  public PromptBarScript PromptBar;
  public SubtitleScript Subtitle;
  public JukeboxScript Jukebox;
  public PromptScript Prompt;
  public GameObject BlueLight;
  public GameObject PeekCamera;
  public bool Spoke;
  public float Timer;

  private void Start() => this.Prompt.Door = true;

  private void Update()
  {
    if ((double) Vector3.Distance(this.transform.position, this.Prompt.Yandere.transform.position) < 2.0)
      this.Prompt.Yandere.StudentManager.TutorialWindow.ShowInfoMessage = true;
    if (this.InfoChanWindow.Drop)
      this.Prompt.Circle[0].fillAmount = 1f;
    if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      this.Prompt.Circle[0].fillAmount = 1f;
      if (!this.Prompt.Yandere.Chased && this.Prompt.Yandere.Chasers == 0)
      {
        this.Prompt.Yandere.CanMove = false;
        this.PeekCamera.SetActive(true);
        this.BlueLight.SetActive(true);
        this.PromptBar.ClearButtons();
        this.PromptBar.Label[1].text = "Stop";
        this.PromptBar.UpdateButtons();
        this.PromptBar.Show = true;
      }
    }
    if (!this.PeekCamera.activeInHierarchy)
      return;
    this.Timer += Time.deltaTime;
    if ((double) this.Timer > 5.0 && !this.Spoke)
    {
      this.Subtitle.UpdateLabel(SubtitleType.InfoNotice, 0, 6.5f);
      this.Spoke = true;
      this.GetComponent<AudioSource>().Play();
    }
    if (!Input.GetButtonDown("B") && !this.Prompt.Yandere.Noticed && !this.Prompt.Yandere.Sprayed)
      return;
    if (!this.Prompt.Yandere.Noticed && !this.Prompt.Yandere.Sprayed)
      this.Prompt.Yandere.CanMove = true;
    this.PeekCamera.SetActive(false);
    this.BlueLight.SetActive(false);
    this.PromptBar.ClearButtons();
    this.PromptBar.Show = false;
    this.Timer = 0.0f;
  }
}
