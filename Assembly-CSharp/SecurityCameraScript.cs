// Decompiled with JetBrains decompiler
// Type: SecurityCameraScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SecurityCameraScript : MonoBehaviour
{
  public SecuritySystemScript SecuritySystem;
  public MissionModeScript MissionMode;
  public YandereScript Yandere;
  public float Rotation;
  public int Direction = 1;

  private void Update()
  {
    this.Rotation += (float) this.Direction * 36f * Time.deltaTime;
    this.transform.parent.localEulerAngles = new Vector3(this.transform.parent.localEulerAngles.x, this.Rotation, this.transform.parent.localEulerAngles.z);
    if (this.Direction > 0)
    {
      if ((double) this.Rotation <= 86.5)
        return;
      this.Direction = -1;
    }
    else
    {
      if ((double) this.Rotation >= -86.5)
        return;
      this.Direction = 1;
    }
  }

  private void OnTriggerStay(Collider other)
  {
    if (this.MissionMode.GameOverID != 0)
      return;
    if (other.gameObject.layer == 13)
    {
      if ((!this.Yandere.Armed || !this.Yandere.EquippedWeapon.Suspicious) && ((double) this.Yandere.Bloodiness <= 0.0 || this.Yandere.RedPaint) && (double) this.Yandere.Sanity >= 33.333000183105469 && !this.Yandere.Attacking && !this.Yandere.Struggling && !this.Yandere.Dragging && !this.Yandere.Lewd && !this.Yandere.Dragging && !this.Yandere.Carrying && (!this.Yandere.Laughing || (double) this.Yandere.LaughIntensity <= 15.0) && (!((Object) this.Yandere.PickUp != (Object) null) || !this.Yandere.PickUp.Clothing || !this.Yandere.PickUp.Evidence || this.Yandere.PickUp.RedPaint))
        return;
      if ((Object) this.Yandere.Mask == (Object) null)
      {
        if (this.MissionMode.enabled)
        {
          this.MissionMode.GameOverID = 15;
          this.MissionMode.GameOver();
          this.MissionMode.Phase = 4;
          this.enabled = false;
        }
        else
        {
          if (this.SecuritySystem.Evidence)
            return;
          this.Yandere.NotificationManager.DisplayNotification(NotificationType.Evidence);
          this.SecuritySystem.Evidence = true;
          this.SecuritySystem.Masked = false;
        }
      }
      else
      {
        if (this.SecuritySystem.Masked)
          return;
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Evidence);
        this.SecuritySystem.Evidence = true;
        this.SecuritySystem.Masked = true;
      }
    }
    else
    {
      if (other.gameObject.layer != 11 || !this.MissionMode.enabled)
        return;
      this.MissionMode.GameOverID = 15;
      this.MissionMode.GameOver();
      this.MissionMode.Phase = 4;
      this.enabled = false;
    }
  }
}
