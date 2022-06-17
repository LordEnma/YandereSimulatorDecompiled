// Decompiled with JetBrains decompiler
// Type: PassTimeBookScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PassTimeBookScript : MonoBehaviour
{
  public YandereScript Yandere;
  public PromptScript Prompt;
  public UISprite Darkness;
  public bool TimeSkipping;
  public bool FadeOut;

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      this.Prompt.Circle[0].fillAmount = 1f;
      if (this.Yandere.Police.Show)
      {
        this.Yandere.NotificationManager.CustomText = "Not when police are coming!";
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
      }
      else if ((double) this.Yandere.StudentManager.Clock.HourTime < 15.5)
      {
        this.Yandere.NotificationManager.CustomText = "Only available after 3:30 PM";
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
      }
      else if ((double) this.Yandere.StudentManager.Clock.HourTime > 17.5)
      {
        this.Yandere.NotificationManager.CustomText = "Not available after 5:30 PM";
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
      }
      else if (this.Yandere.Armed || (double) this.Yandere.Bloodiness > 0.0 || (double) this.Yandere.Sanity < 33.3330001831055 || this.Yandere.Attacking || this.Yandere.Dragging || this.Yandere.Carrying || (Object) this.Yandere.PickUp != (Object) null || this.Yandere.Chased || this.Yandere.Chasers > 0 || (Object) this.Yandere.StudentManager.Reporter != (Object) null && !this.Yandere.Police.Show || this.Yandere.StudentManager.MurderTakingPlace)
      {
        this.DisplayErrorMessage();
      }
      else
      {
        this.Yandere.CharacterAnimation.CrossFade(this.Yandere.IdleAnim);
        this.Yandere.RPGCamera.enabled = false;
        this.Darkness.enabled = true;
        this.Yandere.CanMove = false;
        this.TimeSkipping = true;
        this.FadeOut = true;
      }
    }
    if (!this.TimeSkipping)
      return;
    if (this.FadeOut)
    {
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
      if ((double) this.Darkness.color.a <= 0.999989986419678)
        return;
      this.Yandere.StudentManager.Clock.PresentTime += 30f;
      this.Yandere.StudentManager.Clock.UpdateClock();
      this.FadeOut = false;
    }
    else
    {
      this.Darkness.alpha = Mathf.MoveTowards(this.Darkness.alpha, 0.0f, Time.deltaTime);
      Debug.Log((object) ("Darkness.color.a is: " + this.Darkness.color.a.ToString()));
      if ((double) this.Darkness.color.a >= 0.100000001490116)
        return;
      this.Darkness.alpha = 0.0f;
      if (PlayerGlobals.PantiesEquipped == 7)
      {
        this.Yandere.StudentManager.Reputation.Portal.Class.BonusPoints += 2;
        this.Yandere.NotificationManager.CustomText = "Gained 2 extra Study Points!";
      }
      else
      {
        ++this.Yandere.StudentManager.Reputation.Portal.Class.BonusPoints;
        this.Yandere.NotificationManager.CustomText = "Gained 1 extra Study Point!";
      }
      this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
      this.Yandere.RPGCamera.enabled = true;
      this.Darkness.enabled = false;
      this.Yandere.CanMove = true;
      this.TimeSkipping = false;
    }
  }

  public void DisplayErrorMessage()
  {
    if (this.Yandere.Armed)
      this.Yandere.NotificationManager.CustomText = "Carrying Weapon";
    else if ((double) this.Yandere.Bloodiness > 0.0)
      this.Yandere.NotificationManager.CustomText = "Bloody";
    else if ((double) this.Yandere.Sanity < 33.3330001831055)
      this.Yandere.NotificationManager.CustomText = "Visibly Insane";
    else if (this.Yandere.Attacking)
      this.Yandere.NotificationManager.CustomText = "In Combat";
    else if (this.Yandere.Dragging || this.Yandere.Carrying)
      this.Yandere.NotificationManager.CustomText = "Holding Corpse";
    else if ((Object) this.Yandere.PickUp != (Object) null)
      this.Yandere.NotificationManager.CustomText = "Carrying Item";
    else if (this.Yandere.Chased || this.Yandere.Chasers > 0)
      this.Yandere.NotificationManager.CustomText = "Chased";
    else if ((bool) (Object) this.Yandere.StudentManager.Reporter && !this.Yandere.Police.Show)
      this.Yandere.NotificationManager.CustomText = "Murder being reported";
    else if (this.Yandere.StudentManager.MurderTakingPlace)
      this.Yandere.NotificationManager.CustomText = "Murder taking place";
    this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
    this.Yandere.NotificationManager.CustomText = "Cannot pass time. Reason:";
    this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
  }
}
