// Decompiled with JetBrains decompiler
// Type: PowerOutletScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PowerOutletScript : MonoBehaviour
{
  public PromptScript Prompt;
  public PowerSwitchScript PowerSwitch;
  public GameObject PowerStrip;
  public GameObject PluggedOutlet;
  public GameObject SabotagedOutlet;
  public bool Sabotaged;

  private void Update()
  {
    if ((Object) this.PowerStrip == (Object) null)
    {
      if ((Object) this.Prompt.Yandere.PickUp != (Object) null)
      {
        this.Prompt.HideButton[0] = !this.Prompt.Yandere.PickUp.Electronic;
        if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
          return;
        this.Prompt.Circle[0].fillAmount = 1f;
        this.PowerStrip = this.Prompt.Yandere.PickUp.gameObject;
        this.Prompt.Yandere.EmptyHands();
        this.PowerStrip.transform.parent = this.transform;
        this.PowerStrip.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        this.PowerStrip.SetActive(false);
        this.PluggedOutlet.SetActive(true);
        this.Prompt.Label[0].text = "     Unplug";
      }
      else
        this.Prompt.HideButton[0] = true;
    }
    else
    {
      this.Prompt.HideButton[1] = !((Object) this.Prompt.Yandere.EquippedWeapon != (Object) null) || this.Prompt.Yandere.EquippedWeapon.WeaponID != 6;
      if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
      {
        this.Prompt.Circle[0].fillAmount = 1f;
        this.PluggedOutlet.SetActive(false);
        this.PowerStrip.transform.localPosition = new Vector3(0.074f, -0.01385f, 0.0295f);
        this.PowerStrip.transform.localEulerAngles = new Vector3(0.0f, -99f, 0.0f);
        this.PowerStrip.SetActive(true);
        this.PowerStrip = (GameObject) null;
        this.Prompt.HideButton[1] = true;
        this.Prompt.Label[0].text = "     Plug In";
      }
      if ((double) this.Prompt.Circle[1].fillAmount != 0.0)
        return;
      this.Prompt.Circle[1].fillAmount = 1f;
      if (this.PowerSwitch.On)
      {
        this.Prompt.Yandere.NotificationManager.CustomText = "Turn Lightswitch Off First!";
        this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
      }
      else
      {
        if (!this.Sabotaged)
        {
          this.Prompt.Yandere.SuspiciousActionTimer = 1f;
          this.SabotagedOutlet.SetActive(true);
          this.PluggedOutlet.SetActive(false);
          this.Prompt.Label[1].text = "     Repair";
          this.Prompt.HideButton[0] = true;
        }
        else
        {
          this.SabotagedOutlet.SetActive(false);
          this.PluggedOutlet.SetActive(true);
          this.Prompt.Label[1].text = "     Sabotage";
          this.Prompt.HideButton[0] = false;
        }
        this.Sabotaged = !this.Sabotaged;
        Debug.Log((object) ("''Sabotaged'' is now: " + this.Sabotaged.ToString()));
      }
    }
  }
}
