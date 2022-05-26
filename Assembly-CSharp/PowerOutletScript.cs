// Decompiled with JetBrains decompiler
// Type: PowerOutletScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
        if (this.Prompt.Yandere.PickUp.Electronic)
          this.Prompt.enabled = true;
        else if (this.Prompt.enabled)
        {
          this.Prompt.Hide();
          this.Prompt.enabled = false;
        }
        if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
          return;
        this.Prompt.Circle[0].fillAmount = 1f;
        this.PowerStrip = this.Prompt.Yandere.PickUp.gameObject;
        this.Prompt.Yandere.EmptyHands();
        this.PowerStrip.transform.parent = this.transform;
        this.PowerStrip.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        this.PowerStrip.SetActive(false);
        this.PluggedOutlet.SetActive(true);
        this.Prompt.HideButton[0] = true;
      }
      else
      {
        if (!this.Prompt.enabled)
          return;
        this.Prompt.Hide();
        this.Prompt.enabled = false;
      }
    }
    else if ((Object) this.Prompt.Yandere.EquippedWeapon != (Object) null)
    {
      if (this.Prompt.Yandere.EquippedWeapon.WeaponID == 6)
      {
        this.Prompt.HideButton[1] = false;
        this.Prompt.enabled = true;
      }
      else if (this.Prompt.enabled)
      {
        this.Prompt.Hide();
        this.Prompt.enabled = false;
      }
      if ((double) this.Prompt.Circle[1].fillAmount != 0.0)
        return;
      this.Prompt.Circle[1].fillAmount = 1f;
      this.SabotagedOutlet.SetActive(true);
      this.PluggedOutlet.SetActive(false);
      this.PowerSwitch.CheckPuddle();
      this.Prompt.Hide();
      this.Prompt.enabled = false;
      this.enabled = false;
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
