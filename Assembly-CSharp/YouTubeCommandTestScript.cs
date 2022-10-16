// Decompiled with JetBrains decompiler
// Type: YouTubeCommandTestScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class YouTubeCommandTestScript : MonoBehaviour
{
  public InfoChanWindowScript InfoChanWindow;
  public YandereShoeLockerScript ShoeLocker;
  public YandereScript Yandere;
  public YouTubeChat Chat;
  public string RepKeyword;
  public string CleanKeyword;
  public string MoneyKeyword;
  public string SanityKeyword;
  public string FriendKeyword;
  public string DelayKeyword;
  public string InfoKeyword;
  public string CloakKeyword;
  public string StudyKeyword;
  public string DropKeyword;
  public string GossipKeyword;
  public string BloodKeyword;
  public string RobKeyword;
  public string InsaneKeyword;
  public string GrudgeKeyword;
  public string CopsKeyword;
  public string NemesisKeyword;
  public string AggroKeyword;
  public string GuiseKeyword;
  public string OopsKeyword;
  public string BustKeyword;
  public string HairKeyword;
  public string PantyKeyword;
  public string PersonaKeyword;
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
    if (!((UnityEngine.Object) YouTubeChat.instance != (UnityEngine.Object) null) || YouTubeChat.instance.NextInQueue() == null)
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
    else if (this.Check[2] && message.Contains(this.CleanKeyword))
    {
      Debug.Log((object) "Someone typed ''!clean''.");
      if ((double) this.Yandere.Bloodiness > 0.0)
      {
        Debug.Log((object) "Player was bloody at the time. Cleaning blood.");
        this.Yandere.Bloodiness = 0.0f;
        if (this.Yandere.Schoolwear != 2)
        {
          if (this.Yandere.CurrentUniformOrigin == 1)
            ++this.Yandere.StudentManager.OriginalUniforms;
          else
            ++this.Yandere.StudentManager.NewUniforms;
          --this.Yandere.Police.BloodyClothing;
        }
        this.Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " cleaned your clothing!";
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
      }
      if (this.Yandere.RightFootprintSpawner.Bloodiness > 0)
        this.Yandere.RightFootprintSpawner.Bloodiness = 0;
      if (this.Yandere.LeftFootprintSpawner.Bloodiness > 0)
        this.Yandere.LeftFootprintSpawner.Bloodiness = 0;
      YouTubeChat.instance.Dequeue();
    }
    else if (this.Check[3] && message.Contains(this.MoneyKeyword))
    {
      ++this.Yandere.Inventory.Money;
      this.Yandere.Inventory.UpdateMoney();
      this.Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " gave you $1.00!";
      this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
      YouTubeChat.instance.Dequeue();
    }
    else if (this.Check[4] && message.Contains(this.SanityKeyword))
    {
      ++this.Yandere.Sanity;
      this.Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " restored 1% Sanity!";
      this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
      YouTubeChat.instance.Dequeue();
    }
    else
    {
      if (this.Check[5])
      {
        if (message.Contains(this.FriendKeyword))
        {
          try
          {
            int int32 = Convert.ToInt32(message.Split(' ')[1]);
            if (int32 > 0)
            {
              if (int32 < 101)
              {
                if ((UnityEngine.Object) this.Yandere.StudentManager.Students[int32] != (UnityEngine.Object) null)
                {
                  this.Yandere.StudentManager.Students[int32].Friend = true;
                  this.Yandere.StudentManager.Students[int32].Grudge = false;
                  this.Yandere.StudentManager.StudentPhotographed[int32] = true;
                  this.Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " made you friends with Student #" + int32.ToString() + "!";
                  this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
                }
              }
            }
          }
          catch
          {
          }
          YouTubeChat.instance.Dequeue();
          return;
        }
      }
      if (this.Check[6] && message.Contains(this.DelayKeyword))
      {
        if (!this.Yandere.Police.Delayed)
        {
          this.Yandere.Police.Timer += 300f;
          this.Yandere.Police.Delayed = true;
          this.Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " delayed the police!";
          this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
        }
        YouTubeChat.instance.Dequeue();
      }
      else if (this.Check[7] && message.Contains(this.InfoKeyword))
      {
        ++this.Yandere.Inventory.PantyShots;
        this.Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " gave you 1 Info Point!";
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
        YouTubeChat.instance.Dequeue();
      }
      else if (this.Check[8] && message.Contains(this.CloakKeyword))
      {
        Debug.Log((object) "Someone typed ''!cloak''.");
        Debug.Log((object) "Attempting to disable ShoeLocker...");
        this.ShoeLocker.enabled = false;
        Debug.Log((object) "Attempting to turn the girl invisible...");
        this.Yandere.Invisible = true;
        this.Yandere.Cloak();
        this.CloakTimer = 10f;
        Debug.Log((object) "Attempting to spawn a notification...");
        this.Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " cloaked you for 10 seconds!";
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
        Debug.Log((object) "Attempting to remove this message from the deqeue...");
        YouTubeChat.instance.Dequeue();
        Debug.Log((object) "We made it!");
      }
      else if (this.Check[9] && message.Contains(this.StudyKeyword))
      {
        ++this.Yandere.Class.BonusPoints;
        this.Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " gave you 1 Study Point!";
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
        YouTubeChat.instance.Dequeue();
      }
      else
      {
        if (this.Check[10])
        {
          if (message.Contains(this.DropKeyword))
          {
            try
            {
              int int32 = Convert.ToInt32(message.Split(' ')[1]);
              if (int32 > -1)
              {
                if (int32 < this.InfoChanWindow.Drops.Length)
                {
                  ++this.InfoChanWindow.Orders;
                  this.InfoChanWindow.ItemsToDrop[this.InfoChanWindow.Orders] = int32;
                  this.InfoChanWindow.DropObject();
                  this.Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " ordered a Drop from Info-chan!";
                  this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
                }
              }
            }
            catch
            {
            }
            YouTubeChat.instance.Dequeue();
            return;
          }
        }
        if (this.Check[11] && message.Contains(this.GossipKeyword))
        {
          --this.Yandere.StudentManager.Reputation.PendingRep;
          this.Yandere.StudentManager.Reputation.UpdateRep();
          this.Yandere.StudentManager.Reputation.UpdatePendingRepLabel();
          this.Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " damaged your rep!";
          this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
          YouTubeChat.instance.Dequeue();
        }
        else if (this.Check[12] && message.Contains(this.BloodKeyword))
        {
          this.Yandere.Bloodiness += 20f;
          this.Yandere.StainWeapon();
          this.Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " splashed blood on you!";
          this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
          YouTubeChat.instance.Dequeue();
        }
        else if (this.Check[13] && message.Contains(this.RobKeyword))
        {
          --this.Yandere.Inventory.Money;
          if ((double) this.Yandere.Inventory.Money < 0.0)
            this.Yandere.Inventory.Money = 0.0f;
          this.Yandere.Inventory.UpdateMoney();
          this.Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " stole $1.00 from you!";
          this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
          YouTubeChat.instance.Dequeue();
        }
        else if (this.Check[14] && message.Contains(this.InsaneKeyword))
        {
          --this.Yandere.Sanity;
          this.Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " reduced your Sanity!";
          this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
          YouTubeChat.instance.Dequeue();
        }
        else
        {
          if (this.Check[15])
          {
            if (message.Contains(this.GrudgeKeyword))
            {
              try
              {
                int int32 = Convert.ToInt32(message.Split(' ')[1]);
                if (int32 > 0)
                {
                  if (int32 < 101)
                  {
                    if ((UnityEngine.Object) this.Yandere.StudentManager.Students[int32] != (UnityEngine.Object) null)
                    {
                      this.Yandere.StudentManager.Students[int32].Friend = false;
                      this.Yandere.StudentManager.Students[int32].Grudge = true;
                      this.Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " made you enemies with Student #" + int32.ToString() + "!";
                      this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
                    }
                  }
                }
              }
              catch
              {
              }
              YouTubeChat.instance.Dequeue();
              return;
            }
          }
          if (this.Check[16] && message.Contains(this.CopsKeyword))
          {
            this.Yandere.Police.Show = true;
            this.Yandere.Police.Called = true;
            this.Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " called the cops!";
            this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
            YouTubeChat.instance.Dequeue();
          }
          else if (this.Check[17] && message.Contains(this.NemesisKeyword))
          {
            if (!this.Yandere.PauseScreen.MissionMode.Nemesis.activeInHierarchy)
            {
              this.Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " sent Nemesis after you!";
              this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
            }
            YouTubeChat.instance.Dequeue();
          }
          else if (this.Check[18] && message.Contains(this.AggroKeyword))
          {
            if (this.Yandere.PauseScreen.MissionMode.Nemesis.activeInHierarchy)
            {
              this.Yandere.PauseScreen.MissionMode.Nemesis.GetComponent<NemesisScript>().Aggressive = true;
              this.Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " made Nemesis aggressive!";
              this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
            }
            YouTubeChat.instance.Dequeue();
          }
          else if (this.Check[19] && message.Contains(this.GuiseKeyword))
          {
            if (this.Yandere.PauseScreen.MissionMode.Nemesis.activeInHierarchy)
            {
              this.Yandere.PauseScreen.MissionMode.Nemesis.GetComponent<NemesisScript>().PutOnDisguise = true;
              this.Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " gave Nemesis a disguise!";
              this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
            }
            YouTubeChat.instance.Dequeue();
          }
          else if (this.Check[20] && message.Contains(this.OopsKeyword))
          {
            if (this.Yandere.Armed || this.Yandere.Carrying || this.Yandere.HeavyWeight || (UnityEngine.Object) this.Yandere.PickUp != (UnityEngine.Object) null || this.Yandere.Dragging)
            {
              this.Yandere.EmptyHands();
              this.Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " made you drop it";
              this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
            }
            YouTubeChat.instance.Dequeue();
          }
          else
          {
            if (this.Check[21])
            {
              if (message.Contains(this.BustKeyword))
              {
                try
                {
                  int int32 = Convert.ToInt32(message.Split(' ')[1]);
                  if (int32 > -1)
                  {
                    if (int32 < 15)
                    {
                      this.Yandere.BreastSize = (float) (0.5 + (double) int32 * 0.10000000149011612);
                      this.Yandere.RightBreast.localScale = new Vector3(this.Yandere.BreastSize, this.Yandere.BreastSize, this.Yandere.BreastSize);
                      this.Yandere.LeftBreast.localScale = new Vector3(this.Yandere.BreastSize, this.Yandere.BreastSize, this.Yandere.BreastSize);
                      this.Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " changed your bust size!";
                      this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
                    }
                  }
                }
                catch
                {
                }
                YouTubeChat.instance.Dequeue();
                return;
              }
            }
            if (this.Check[22])
            {
              if (message.Contains(this.HairKeyword))
              {
                try
                {
                  int int32 = Convert.ToInt32(message.Split(' ')[1]);
                  if (int32 > -1)
                  {
                    if (int32 < this.Yandere.Hairstyles.Length)
                    {
                      this.Yandere.Hairstyle = int32;
                      this.Yandere.UpdateHair();
                      this.Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " gave you a new hairstyle!";
                      this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
                    }
                  }
                }
                catch
                {
                }
                YouTubeChat.instance.Dequeue();
                return;
              }
            }
            if (this.Check[23])
            {
              if (message.Contains(this.PantyKeyword))
              {
                try
                {
                  int int32 = Convert.ToInt32(message.Split(' ')[1]);
                  if (int32 > 0)
                  {
                    if (int32 < 12)
                    {
                      PlayerGlobals.PantiesEquipped = int32;
                      this.Yandere.PantyAttacher.PantyID = int32;
                      this.Yandere.PantyAttacher.UpdatePanties();
                      this.Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " changed your panties!";
                      this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
                    }
                  }
                }
                catch
                {
                }
                YouTubeChat.instance.Dequeue();
                return;
              }
            }
            if (this.Check[24])
            {
              if (message.Contains(this.PersonaKeyword))
              {
                try
                {
                  int int32 = Convert.ToInt32(message.Split(' ')[1]);
                  if (int32 > 0)
                  {
                    if (int32 < 12)
                    {
                      this.Yandere.PersonaID = int32;
                      this.Yandere.StudentManager.Mirror.UpdatePersona();
                    }
                  }
                }
                catch
                {
                }
                YouTubeChat.instance.Dequeue();
                return;
              }
            }
            if (this.Check[25])
            {
              if (message.Contains(this.AccessoryKeyword))
              {
                try
                {
                  int int32 = Convert.ToInt32(message.Split(' ')[1]);
                  if (int32 > -1)
                  {
                    if (int32 < this.Yandere.Accessories.Length)
                    {
                      this.Yandere.AccessoryID = int32;
                      this.Yandere.UpdateAccessory();
                      this.Yandere.NotificationManager.CustomText = YouTubeChat.instance.NextInQueue().Author + " gave you a new accessory!";
                      this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
                    }
                  }
                }
                catch
                {
                }
                YouTubeChat.instance.Dequeue();
                return;
              }
            }
            YouTubeChat.instance.Dequeue();
          }
        }
      }
    }
  }
}
