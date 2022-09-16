// Decompiled with JetBrains decompiler
// Type: YandereShoverScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class YandereShoverScript : MonoBehaviour
{
  public YandereScript Yandere;
  public bool PreventNudity;

  private void OnTriggerStay(Collider other)
  {
    if (other.gameObject.layer == 13)
    {
      bool flag = false;
      if (this.PreventNudity)
      {
        if (this.Yandere.Schoolwear == 0)
        {
          flag = true;
          if (this.Yandere.NotificationManager.NotificationParent.childCount == 0)
          {
            this.Yandere.NotificationManager.CustomText = "Get dressed first!";
            this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
          }
        }
      }
      else
      {
        flag = true;
        if (this.Yandere.NotificationManager.NotificationParent.childCount == 0)
        {
          this.Yandere.NotificationManager.CustomText = "That's the boys' locker room!";
          this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
        }
      }
      if (flag)
      {
        if (this.Yandere.Aiming)
          this.Yandere.StopAiming();
        if (this.Yandere.Laughing)
          this.Yandere.StopLaughing();
        this.Yandere.transform.rotation = Quaternion.LookRotation(new Vector3(this.transform.position.x, this.Yandere.transform.position.y, this.transform.position.z) - this.Yandere.transform.position);
        this.Yandere.CharacterAnimation["f02_shoveA_01"].time = 0.0f;
        this.Yandere.CharacterAnimation.CrossFade("f02_shoveA_01");
        this.Yandere.YandereVision = false;
        this.Yandere.NearSenpai = false;
        this.Yandere.Degloving = false;
        this.Yandere.Flicking = false;
        this.Yandere.Punching = false;
        this.Yandere.CanMove = false;
        this.Yandere.Shoved = true;
        this.Yandere.EmptyHands();
        this.Yandere.GloveTimer = 0.0f;
        this.Yandere.h = 0.0f;
        this.Yandere.v = 0.0f;
        this.Yandere.ShoveSpeed = 2f;
      }
      if (!this.Yandere.Talking)
        return;
      this.Yandere.transform.position = new Vector3(14f, 0.0f, -12f);
    }
    else
    {
      if (other.gameObject.layer != 11 && other.gameObject.layer != 14)
        return;
      other.gameObject.transform.position += new Vector3(0.0f, 0.0f, -1f);
    }
  }
}
