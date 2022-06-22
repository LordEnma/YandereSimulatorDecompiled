// Decompiled with JetBrains decompiler
// Type: HomeVideoCameraScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class HomeVideoCameraScript : MonoBehaviour
{
  public HomePrisonerChanScript HomePrisonerChan;
  public HomeDarknessScript HomeDarkness;
  public HomePrisonerScript HomePrisoner;
  public HomeYandereScript HomeYandere;
  public HomeCameraScript HomeCamera;
  public PromptScript Prompt;
  public UILabel Subtitle;
  public bool AudioPlayed;
  public bool TextSet;
  public float Timer;

  private void Update()
  {
    if (!this.TextSet && !HomeGlobals.Night)
      this.Prompt.Label[0].text = "     Only Available At Night";
    if (!HomeGlobals.Night)
      this.Prompt.Circle[0].fillAmount = 1f;
    if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      this.HomeCamera.Destination = this.HomeCamera.Destinations[11];
      this.HomeCamera.Target = this.HomeCamera.Targets[11];
      this.HomeCamera.ID = 11;
      this.HomePrisonerChan.LookAhead = true;
      this.HomeYandere.CanMove = false;
      this.HomeYandere.gameObject.SetActive(false);
    }
    if (this.HomeCamera.ID != 11 || this.HomePrisoner.Bantering)
      return;
    this.Timer += Time.deltaTime;
    AudioSource component = this.GetComponent<AudioSource>();
    if ((double) this.Timer > 2.0 && !this.AudioPlayed)
    {
      this.Subtitle.text = "...daddy...please...help...I'm scared...I don't wanna die...";
      this.AudioPlayed = true;
      component.Play();
    }
    if ((double) this.Timer > 2.0 + (double) component.clip.length)
      this.Subtitle.text = string.Empty;
    if ((double) this.Timer <= 3.0 + (double) component.clip.length)
      return;
    this.HomeDarkness.FadeSlow = true;
    this.HomeDarkness.FadeOut = true;
  }
}
