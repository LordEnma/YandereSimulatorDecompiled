// Decompiled with JetBrains decompiler
// Type: PickpocketMinigameScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PickpocketMinigameScript : MonoBehaviour
{
  public Transform PickpocketSpot;
  public UISprite[] ButtonPrompts;
  public UISprite Circle;
  public UISprite BG;
  public YandereScript Yandere;
  public string CurrentButton = string.Empty;
  public bool NotNurse;
  public bool Sabotage;
  public bool Failure;
  public bool Success;
  public bool Show;
  public int StartingAlerts;
  public int ButtonID;
  public int Progress;
  public int ID;
  public float Timer;

  private void Start()
  {
    this.transform.localScale = Vector3.zero;
    this.ButtonPrompts[1].enabled = false;
    this.ButtonPrompts[2].enabled = false;
    this.ButtonPrompts[3].enabled = false;
    this.ButtonPrompts[4].enabled = false;
    this.ButtonPrompts[1].alpha = 0.0f;
    this.ButtonPrompts[2].alpha = 0.0f;
    this.ButtonPrompts[3].alpha = 0.0f;
    this.ButtonPrompts[4].alpha = 0.0f;
    this.Circle.enabled = false;
    this.BG.enabled = false;
  }

  private void Update()
  {
    if (this.Show)
    {
      if ((Object) this.PickpocketSpot != (Object) null)
      {
        this.Yandere.MoveTowardsTarget(this.PickpocketSpot.position);
        this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.PickpocketSpot.rotation, Time.deltaTime * 10f);
      }
      this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 1.0)
      {
        if (this.ButtonID == 0 && this.Yandere.Alerts == this.StartingAlerts)
        {
          this.ChooseButton();
          this.Timer = 0.0f;
        }
        else
        {
          this.Yandere.Caught = true;
          this.Failure = true;
          this.End();
        }
      }
      else
      {
        if (this.ButtonID <= 0)
          return;
        this.Circle.fillAmount = (float) (1.0 - (double) this.Timer / 1.0);
        if (Input.GetButtonDown("A") && this.CurrentButton != "A" || Input.GetButtonDown("B") && this.CurrentButton != "B" || Input.GetButtonDown("X") && this.CurrentButton != "X" || Input.GetButtonDown("Y") && this.CurrentButton != "Y")
        {
          this.Yandere.Caught = true;
          this.Failure = true;
          this.End();
        }
        else
        {
          if (!Input.GetButtonDown(this.CurrentButton))
            return;
          this.ButtonPrompts[this.ButtonID].enabled = false;
          this.ButtonPrompts[this.ButtonID].alpha = 0.0f;
          this.Circle.enabled = false;
          this.BG.enabled = false;
          this.ButtonID = 0;
          this.Timer = 0.0f;
          ++this.Progress;
          if (this.Progress != 5)
            return;
          if (this.Sabotage)
          {
            this.Yandere.NotificationManager.CustomText = "Sabotage Success";
            this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
          }
          else
          {
            this.Yandere.NotificationManager.CustomText = "Pickpocket Success";
            this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
          }
          this.Yandere.Pickpocketing = false;
          this.Yandere.CanMove = true;
          this.Success = true;
          this.End();
        }
      }
    }
    else
    {
      if ((double) this.transform.localScale.x <= 0.100000001490116)
        return;
      this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      if ((double) this.transform.localScale.x >= 0.100000001490116)
        return;
      this.transform.localScale = Vector3.zero;
    }
  }

  private void ChooseButton()
  {
    this.ButtonPrompts[1].enabled = false;
    this.ButtonPrompts[2].enabled = false;
    this.ButtonPrompts[3].enabled = false;
    this.ButtonPrompts[4].enabled = false;
    this.ButtonPrompts[1].alpha = 0.0f;
    this.ButtonPrompts[2].alpha = 0.0f;
    this.ButtonPrompts[3].alpha = 0.0f;
    this.ButtonPrompts[4].alpha = 0.0f;
    int buttonId = this.ButtonID;
    while (this.ButtonID == buttonId)
      this.ButtonID = Random.Range(1, 5);
    if (this.ButtonID == 1)
      this.CurrentButton = "A";
    else if (this.ButtonID == 2)
      this.CurrentButton = "B";
    else if (this.ButtonID == 3)
      this.CurrentButton = "X";
    else if (this.ButtonID == 4)
      this.CurrentButton = "Y";
    this.ButtonPrompts[this.ButtonID].enabled = true;
    this.ButtonPrompts[this.ButtonID].alpha = 1f;
    this.Circle.enabled = true;
    this.BG.enabled = true;
  }

  public void End()
  {
    Debug.Log((object) "Ending minigame.");
    this.ButtonPrompts[1].enabled = false;
    this.ButtonPrompts[2].enabled = false;
    this.ButtonPrompts[3].enabled = false;
    this.ButtonPrompts[4].enabled = false;
    this.ButtonPrompts[1].alpha = 0.0f;
    this.ButtonPrompts[2].alpha = 0.0f;
    this.ButtonPrompts[3].alpha = 0.0f;
    this.ButtonPrompts[4].alpha = 0.0f;
    this.Circle.enabled = false;
    this.BG.enabled = false;
    this.Yandere.CharacterAnimation.CrossFade("f02_readyToFight_00");
    this.Progress = 0;
    this.ButtonID = 0;
    this.Show = false;
    this.Timer = 0.0f;
  }
}
