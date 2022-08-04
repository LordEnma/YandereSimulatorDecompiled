// Decompiled with JetBrains decompiler
// Type: SinkScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SinkScript : MonoBehaviour
{
  public ParticleSystem WaterStream;
  public Transform WashPosition;
  public YandereScript Yandere;
  public PromptScript Prompt;
  public bool WashingDisabled;

  private void Start()
  {
    this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
    if (!GameGlobals.EightiesTutorial)
      return;
    this.WashingDisabled = true;
  }

  private void Update()
  {
    if ((Object) this.Yandere.PickUp != (Object) null)
    {
      this.Prompt.HideButton[0] = false;
      this.Prompt.HideButton[1] = true;
      if ((Object) this.Yandere.PickUp.Bucket != (Object) null)
      {
        if (this.Yandere.PickUp.Bucket.Dumbbells == 0)
        {
          this.Prompt.enabled = true;
          this.Prompt.Label[0].text = this.Yandere.PickUp.Bucket.Full ? "     Empty Bucket" : "     Fill Bucket";
        }
        else if (this.Prompt.enabled)
        {
          this.Prompt.Hide();
          this.Prompt.enabled = false;
        }
      }
      else if ((Object) this.Yandere.PickUp.BloodCleaner != (Object) null)
      {
        if ((double) this.Yandere.PickUp.BloodCleaner.Blood > 0.0)
        {
          this.Prompt.Label[0].text = "     Empty Robot";
          this.Prompt.enabled = true;
        }
        else
        {
          this.Prompt.Hide();
          this.Prompt.enabled = false;
        }
      }
      else if (this.Prompt.enabled)
      {
        this.Prompt.Hide();
        this.Prompt.enabled = false;
      }
    }
    else if (!this.WashingDisabled && this.Prompt.Yandere.Armed && this.Prompt.Yandere.EquippedWeapon.Blood.enabled)
    {
      if (this.Prompt.HideButton[1])
      {
        this.Prompt.Label[1].text = "     Wash Weapon";
        this.Prompt.HideButton[0] = true;
        this.Prompt.HideButton[1] = false;
        this.Prompt.enabled = true;
      }
    }
    else
    {
      this.Prompt.HideButton[0] = true;
      this.Prompt.HideButton[1] = true;
      if (this.Prompt.enabled)
      {
        this.Prompt.Hide();
        this.Prompt.enabled = false;
      }
    }
    if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      if ((Object) this.Yandere.PickUp.Bucket != (Object) null)
      {
        if (!this.Yandere.PickUp.Bucket.Full)
          this.Yandere.PickUp.Bucket.Fill();
        else
          this.Yandere.PickUp.Bucket.Empty();
        this.Prompt.Label[0].text = this.Yandere.PickUp.Bucket.Full ? "     Empty Bucket" : "     Fill Bucket";
      }
      else if ((Object) this.Yandere.PickUp.BloodCleaner != (Object) null)
      {
        this.Yandere.PickUp.BloodCleaner.Blood = 0.0f;
        this.Yandere.PickUp.BloodCleaner.Lens.SetActive(false);
      }
      this.Prompt.Circle[0].fillAmount = 1f;
    }
    if ((double) this.Prompt.Circle[1].fillAmount != 0.0)
      return;
    this.Prompt.Circle[1].fillAmount = 1f;
    this.Prompt.Yandere.CharacterAnimation.CrossFade("f02_cleaningWeapon_00");
    this.Prompt.Yandere.Target = this.WashPosition;
    this.Prompt.Yandere.CleaningWeapon = true;
    this.Prompt.Yandere.CanMove = false;
    this.WaterStream.Play();
  }
}
