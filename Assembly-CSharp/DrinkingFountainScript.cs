// Decompiled with JetBrains decompiler
// Type: DrinkingFountainScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class DrinkingFountainScript : MonoBehaviour
{
  public PowerSwitchScript PowerSwitch;
  public ParticleSystem WaterStream;
  public ParticleSystem WaterBlast;
  public Transform DrinkPosition;
  public GameObject WaterCollider;
  public GameObject Puddle;
  public GameObject Leak;
  public PromptScript Prompt;
  public AudioSource MyAudio;
  public bool Sabotagable;
  public bool Sabotaged;
  public bool Occupied;

  private void Update()
  {
    if ((Object) this.Prompt.Yandere.EquippedWeapon != (Object) null)
    {
      if (this.Prompt.Yandere.EquippedWeapon.Blood.enabled)
      {
        this.Prompt.HideButton[0] = false;
        this.Prompt.enabled = true;
      }
      else
        this.Prompt.HideButton[0] = true;
      if (!this.Leak.activeInHierarchy)
      {
        if (this.Prompt.Yandere.EquippedWeapon.WeaponID == 24)
        {
          this.Prompt.HideButton[1] = false;
          this.Prompt.HideButton[2] = !this.Sabotagable || this.Sabotaged;
          this.Prompt.enabled = true;
        }
        else
        {
          this.Prompt.HideButton[1] = true;
          this.Prompt.HideButton[2] = true;
        }
      }
      if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
      {
        this.Prompt.Circle[0].fillAmount = 1f;
        this.Prompt.Yandere.CharacterAnimation.CrossFade("f02_cleaningWeapon_00");
        this.Prompt.Yandere.Target = this.DrinkPosition;
        this.Prompt.Yandere.CleaningWeapon = true;
        this.Prompt.Yandere.CanMove = false;
        this.WaterStream.Play();
      }
      if ((double) this.Prompt.Circle[1].fillAmount == 0.0)
      {
        this.Prompt.HideButton[1] = true;
        this.Puddle.SetActive(true);
        this.Leak.SetActive(true);
        this.MyAudio.Play();
        this.PowerSwitch.CheckPuddle();
      }
      if ((double) this.Prompt.Circle[2].fillAmount != 0.0)
        return;
      this.Prompt.HideButton[2] = true;
      this.Sabotaged = true;
      this.MyAudio.Play();
    }
    else
    {
      if (!this.Prompt.enabled)
        return;
      this.Prompt.Hide();
      this.Prompt.enabled = false;
    }
  }
}
