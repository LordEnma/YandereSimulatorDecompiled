// Decompiled with JetBrains decompiler
// Type: PowerSwitchScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PowerSwitchScript : MonoBehaviour
{
  public DrinkingFountainScript DrinkingFountain;
  public PowerOutletScript PowerOutlet;
  public GameObject PuddleDetector;
  public GameObject Electricity;
  public GameObject NewPuddle;
  public Light BathroomLight;
  public PromptScript Prompt;
  public AudioSource MyAudio;
  public AudioClip[] Flick;
  public bool Haunted;
  public bool On;
  public GameObject NewPuddleDetector;

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
        this.Prompt.Label[0].text = "     Turn Off";
        this.MyAudio.clip = this.Flick[1];
      }
      else
      {
        this.Prompt.Label[0].text = "     Turn On";
        this.MyAudio.clip = this.Flick[0];
      }
      this.BathroomLight.enabled = !this.BathroomLight.enabled;
    }
    this.CheckPuddle();
    this.MyAudio.Play();
  }

  public void CheckPuddle()
  {
    Debug.Log((object) ("The lightswitch is currently: " + this.On.ToString()));
    if (this.On)
    {
      this.NewPuddleDetector = Object.Instantiate<GameObject>(this.PuddleDetector, this.PowerOutlet.SabotagedOutlet.transform.position, Quaternion.identity);
      this.NewPuddleDetector.transform.parent = this.PowerOutlet.SabotagedOutlet.transform;
      this.NewPuddleDetector.transform.localPosition = new Vector3(0.08555f, 0.0f, 0.03445f);
      this.NewPuddleDetector.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
      this.NewPuddleDetector.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
      this.NewPuddleDetector.GetComponent<PuddleDetectorScript>().PowerSwitch = this;
      if (!((Object) this.DrinkingFountain.Puddle != (Object) null) || !this.DrinkingFountain.Puddle.gameObject.activeInHierarchy || !this.PowerOutlet.SabotagedOutlet.activeInHierarchy)
        return;
      this.Electricity.transform.position = this.DrinkingFountain.Puddle.transform.position;
      this.Electricity.SetActive(true);
    }
    else
      this.Electricity.SetActive(false);
  }
}
