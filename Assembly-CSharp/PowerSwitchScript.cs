// Decompiled with JetBrains decompiler
// Type: PowerSwitchScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PowerSwitchScript : MonoBehaviour
{
  public DrinkingFountainScript DrinkingFountain;
  public PowerOutletScript PowerOutlet;
  public GameObject Electricity;
  public Light BathroomLight;
  public PromptScript Prompt;
  public AudioSource MyAudio;
  public AudioClip[] Flick;
  public bool Haunted;
  public bool On;

  private void Start()
  {
    if ((Object) this.BathroomLight != (Object) null)
      this.Prompt.Label[0].text = "     Turn Off";
    if (GameGlobals.Eighties || !this.Haunted)
      return;
    this.BathroomLight = (Light) null;
  }

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
      return;
    this.Prompt.Circle[0].fillAmount = 1f;
    this.On = !this.On;
    if ((Object) this.BathroomLight == (Object) null)
    {
      if (this.On)
      {
        this.Prompt.Label[0].text = "     Turn Off";
        this.MyAudio.clip = this.Flick[1];
      }
      else
      {
        this.Prompt.Label[0].text = "     Turn On";
        this.MyAudio.clip = this.Flick[0];
      }
    }
    else
    {
      if (this.On)
      {
        this.Prompt.Label[0].text = "     Turn On";
        this.MyAudio.clip = this.Flick[1];
      }
      else
      {
        this.Prompt.Label[0].text = "     Turn Off";
        this.MyAudio.clip = this.Flick[0];
      }
      this.BathroomLight.enabled = !this.BathroomLight.enabled;
    }
    this.CheckPuddle();
    this.MyAudio.Play();
  }

  public void CheckPuddle()
  {
    if (this.On)
    {
      if (!((Object) this.DrinkingFountain.Puddle != (Object) null) || !this.DrinkingFountain.Puddle.gameObject.activeInHierarchy || !this.PowerOutlet.SabotagedOutlet.activeInHierarchy)
        return;
      this.Electricity.SetActive(true);
    }
    else
      this.Electricity.SetActive(false);
  }
}
