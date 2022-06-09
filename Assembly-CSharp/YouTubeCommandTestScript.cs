// Decompiled with JetBrains decompiler
// Type: YouTubeCommandTestScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class YouTubeCommandTestScript : MonoBehaviour
{
  public YandereScript Yandere;
  public YouTubeChat Chat;
  public string RepKeyword;
  public string HairKeyword;
  public string InfoKeyword;
  public string CleanKeyword;
  public string CloakKeyword;
  public string MoneyKeyword;
  public string FriendKeyword;
  public string SanityKeyword;
  public string NemesisKeyword;
  public string AccessoryKeyword;
  public UISprite CountdownCircle;
  public string WeaponKeyword;
  public float CloakTimer;
  public bool[] Check;

  public void Update()
  {
    if (Input.GetMouseButtonDown(0) || (double) Input.GetAxis("RT") == 1.0)
      this.Chat.UpdateMessagesList(false);
    if ((double) this.CloakTimer > 0.0)
    {
      this.CloakTimer = Mathf.MoveTowards(this.CloakTimer, 0.0f, Time.deltaTime);
      if ((double) this.CloakTimer == 0.0)
      {
        this.Yandere.Invisible = false;
        this.Yandere.Decloak();
      }
    }
    if (this.Chat.isValidURL && this.Chat.TimeBased)
      this.CountdownCircle.fillAmount = (float) (1.0 - (double) this.Chat.Timer / 10.0);
    if (YouTubeChat.instance.NextInQueue() == null)
      return;
    string message = YouTubeChat.instance.NextInQueue().Message;
    if (message[0] != '!')
      return;
    if (this.Check[1] && message.Contains(this.RepKeyword))
    {
      ++this.Yandere.StudentManager.Reputation.PendingRep;
      this.Yandere.StudentManager.Reputation.UpdateRep();
      this.Yandere.StudentManager.Reputation.UpdatePendingRepLabel();
      this.Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " gave you +1 Rep!";
      this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
      YouTubeChat.instance.Dequeue();
    }
    else if (this.Check[2] && message.Contains(this.HairKeyword))
    {
      int int32 = Convert.ToInt32(message.Split(' ')[1]);
      if (int32 > -1 && int32 < this.Yandere.Hairstyles.Length)
      {
        this.Yandere.Hairstyle = int32;
        this.Yandere.UpdateHair();
        this.Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " gave you a new hairstyle!";
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
      }
      YouTubeChat.instance.Dequeue();
    }
    else if (this.Check[3] && message.Contains(this.InfoKeyword))
    {
      ++this.Yandere.Inventory.PantyShots;
      this.Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " gave you 1 Info Point!";
      this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
      YouTubeChat.instance.Dequeue();
    }
    else if (this.Check[4] && message.Contains(this.CleanKeyword))
    {
      Debug.Log((object) "Someone typed ''!clean''.");
      if ((double) this.Yandere.Bloodiness > 0.0)
      {
        Debug.Log((object) "Player was bloody at the time. Cleaning blood.");
        this.Yandere.Bloodiness = 0.0f;
        this.Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " cleaned your clothing!";
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
      }
      if (this.Yandere.RightFootprintSpawner.Bloodiness > 0)
        this.Yandere.RightFootprintSpawner.Bloodiness = 0;
      if (this.Yandere.LeftFootprintSpawner.Bloodiness > 0)
        this.Yandere.LeftFootprintSpawner.Bloodiness = 0;
      YouTubeChat.instance.Dequeue();
    }
    else if (this.Check[5] && message.Contains(this.CloakKeyword))
    {
      Debug.Log((object) "Someone typed ''!cloak''.");
      this.Yandere.Invisible = true;
      this.Yandere.Cloak();
      this.CloakTimer = 10f;
      this.Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " cloaked you for 10 seconds!";
      this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
      YouTubeChat.instance.Dequeue();
    }
    else if (this.Check[6] && message.Contains(this.MoneyKeyword))
    {
      ++this.Yandere.Inventory.Money;
      this.Yandere.Inventory.UpdateMoney();
      this.Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " gave you $1.00!";
      this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
      YouTubeChat.instance.Dequeue();
    }
    else if (this.Check[7] && message.Contains(this.FriendKeyword))
    {
      int int32 = Convert.ToInt32(message.Split(' ')[1]);
      if (int32 > 0 && int32 < 101 && (UnityEngine.Object) this.Yandere.StudentManager.Students[int32] != (UnityEngine.Object) null)
      {
        this.Yandere.StudentManager.Students[int32].Friend = true;
        StudentGlobals.SetStudentPhotographed(int32, true);
        this.Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " made you friends with Student #" + int32.ToString() + "!";
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
      }
      YouTubeChat.instance.Dequeue();
    }
    else if (this.Check[8] && message.Contains(this.SanityKeyword))
    {
      ++this.Yandere.Sanity;
      this.Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " restored 1% Sanity!";
      this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
      YouTubeChat.instance.Dequeue();
    }
    else if (this.Check[9] && message.Contains(this.NemesisKeyword))
    {
      if (!this.Yandere.PauseScreen.MissionMode.Nemesis.activeInHierarchy)
      {
        this.Yandere.PauseScreen.MissionMode.Nemesis.SetActive(true);
        this.Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " sent Nemesis after you!";
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
      }
      YouTubeChat.instance.Dequeue();
    }
    else
    {
      if (!this.Check[10] || !message.Contains(this.AccessoryKeyword))
        return;
      int int32 = Convert.ToInt32(message.Split(' ')[1]);
      if (int32 > -1 && int32 < this.Yandere.Accessories.Length)
      {
        this.Yandere.AccessoryID = int32;
        this.Yandere.UpdateAccessory();
        this.Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " gave you a new accessory!";
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
      }
      YouTubeChat.instance.Dequeue();
    }
  }
}
