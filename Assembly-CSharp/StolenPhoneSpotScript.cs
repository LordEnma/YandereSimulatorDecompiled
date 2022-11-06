// Decompiled with JetBrains decompiler
// Type: StolenPhoneSpotScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class StolenPhoneSpotScript : MonoBehaviour
{
  public RivalPhoneScript RivalPhone;
  public PromptScript Prompt;
  public Transform PhoneSpot;

  private void Update()
  {
    if (this.Prompt.Yandere.Inventory.RivalPhone)
    {
      this.Prompt.enabled = true;
      if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
        return;
      this.Prompt.Circle[0].fillAmount = 1f;
      if ((Object) this.Prompt.Yandere.StudentManager.Students[this.RivalPhone.StudentID] != (Object) null && this.Prompt.Yandere.StudentManager.Students[this.RivalPhone.StudentID].Phoneless)
      {
        this.Prompt.Circle[0].fillAmount = 1f;
        this.Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
        if (!this.Prompt.Yandere.StudentManager.YandereVisible)
        {
          if (this.RivalPhone.StudentID == this.Prompt.Yandere.StudentManager.RivalID && SchemeGlobals.GetSchemeStage(1) == 6)
          {
            SchemeGlobals.SetSchemeStage(1, 7);
            this.Prompt.Yandere.PauseScreen.Schemes.UpdateInstructions();
          }
          this.Prompt.Yandere.SmartphoneRenderer.material.mainTexture = this.Prompt.Yandere.YanderePhoneTexture;
          this.Prompt.Yandere.Inventory.RivalPhone = false;
          this.Prompt.Yandere.RivalPhone = false;
          this.RivalPhone.StolenPhoneDropoff.Prompt.enabled = false;
          this.RivalPhone.StolenPhoneDropoff.Prompt.Hide();
          this.RivalPhone.transform.parent = (Transform) null;
          if ((Object) this.PhoneSpot == (Object) null)
            this.RivalPhone.transform.position = this.transform.position;
          else
            this.RivalPhone.transform.position = this.PhoneSpot.position;
          this.RivalPhone.transform.eulerAngles = this.transform.eulerAngles;
          this.RivalPhone.gameObject.SetActive(true);
          this.gameObject.SetActive(false);
        }
        else
        {
          this.Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
          this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
        }
      }
      else
      {
        this.Prompt.Yandere.NotificationManager.CustomText = "Wait a few more moments first...";
        this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
      }
    }
    else
    {
      if (!this.Prompt.enabled)
        return;
      this.Prompt.enabled = false;
      this.Prompt.Hide();
    }
  }
}
