// Decompiled with JetBrains decompiler
// Type: PickpocketScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PickpocketScript : MonoBehaviour
{
  public PickpocketMinigameScript PickpocketMinigame;
  public StudentScript Student;
  public PromptScript Prompt;
  public UIPanel PickpocketPanel;
  public UISprite TimeBar;
  public Transform PickpocketSpot;
  public GameObject AlarmDisc;
  public GameObject Key;
  public float Timer;
  public int ID = 1;
  public bool NotNurse;
  public bool Test;

  private void Start()
  {
    if (this.Student.StudentID != 71)
    {
      this.Prompt.transform.parent.gameObject.SetActive(false);
      this.enabled = false;
    }
    else
    {
      this.PickpocketMinigame = this.Student.StudentManager.PickpocketMinigame;
      if (this.Student.StudentID == this.Student.StudentManager.NurseID)
        this.ID = 2;
      else if (ClubGlobals.GetClubClosed(this.Student.OriginalClub))
      {
        this.Prompt.transform.parent.gameObject.SetActive(false);
        this.enabled = false;
      }
      else
      {
        this.Prompt.Label[3].text = "     Steal Shed Key";
        this.NotNurse = true;
      }
    }
  }

  private void Update()
  {
    if ((Object) this.Prompt.transform.parent != (Object) null)
    {
      if (this.Student.Routine)
      {
        if ((double) this.Student.DistanceToDestination > 0.5)
        {
          if (this.Prompt.enabled)
          {
            this.Prompt.Hide();
            this.Prompt.enabled = false;
            this.PickpocketPanel.enabled = false;
          }
          if (this.Student.Yandere.Pickpocketing && this.PickpocketMinigame.ID == this.ID)
          {
            this.Prompt.Yandere.Caught = true;
            this.PickpocketMinigame.End();
            this.Punish();
          }
        }
        else
        {
          this.PickpocketPanel.enabled = true;
          if ((Object) this.Student.Yandere.PickUp == (Object) null && (Object) this.Student.Yandere.Pursuer == (Object) null)
          {
            this.Prompt.enabled = true;
          }
          else
          {
            this.Prompt.enabled = false;
            this.Prompt.Hide();
          }
          if ((Object) this.TimeBar != (Object) null)
          {
            this.Timer += Time.deltaTime * this.Student.CharacterAnimation[this.Student.PatrolAnim].speed;
            this.TimeBar.fillAmount = (float) (1.0 - (double) this.Timer / (double) this.Student.CharacterAnimation[this.Student.PatrolAnim].length);
            if ((double) this.Timer > (double) this.Student.CharacterAnimation[this.Student.PatrolAnim].length)
            {
              if (this.Student.Yandere.Pickpocketing && this.PickpocketMinigame.ID == this.ID)
              {
                this.Prompt.Yandere.Caught = true;
                this.PickpocketMinigame.End();
                this.Punish();
              }
              this.Timer = 0.0f;
            }
          }
        }
      }
      else if (this.Prompt.enabled)
      {
        this.Prompt.Hide();
        this.Prompt.enabled = false;
        this.PickpocketPanel.enabled = false;
        if (this.Student.Yandere.Pickpocketing && this.PickpocketMinigame.ID == this.ID)
        {
          this.Prompt.Yandere.Caught = true;
          this.PickpocketMinigame.End();
          this.Punish();
        }
      }
      if ((double) this.Prompt.Circle[3].fillAmount == 0.0)
      {
        this.Prompt.Circle[3].fillAmount = 1f;
        if (!this.Prompt.Yandere.Chased && this.Prompt.Yandere.Chasers == 0)
        {
          this.PickpocketMinigame.StartingAlerts = this.Prompt.Yandere.Alerts;
          this.PickpocketMinigame.PickpocketSpot = this.PickpocketSpot;
          this.PickpocketMinigame.NotNurse = this.NotNurse;
          this.PickpocketMinigame.Show = true;
          this.PickpocketMinigame.ID = this.ID;
          this.Student.Yandere.CharacterAnimation.CrossFade("f02_pickpocketing_00");
          this.Student.Yandere.Pickpocketing = true;
          this.Student.Yandere.EmptyHands();
          this.Student.Yandere.CanMove = false;
        }
      }
      if ((Object) this.PickpocketMinigame != (Object) null && this.PickpocketMinigame.ID == this.ID)
      {
        if (this.PickpocketMinigame.Success)
        {
          this.PickpocketMinigame.Success = false;
          this.PickpocketMinigame.ID = 0;
          this.Succeed();
          this.PickpocketPanel.enabled = false;
          this.Prompt.enabled = false;
          this.Prompt.Hide();
          this.Key.SetActive(false);
          this.enabled = false;
        }
        if (this.PickpocketMinigame.Failure)
        {
          this.PickpocketMinigame.Failure = false;
          this.PickpocketMinigame.ID = 0;
          this.Punish();
        }
      }
      if (this.Student.Alive)
        return;
      this.transform.position = new Vector3(this.Student.transform.position.x, this.Student.transform.position.y + 1f, this.Student.transform.position.z);
      this.Prompt.gameObject.GetComponent<BoxCollider>().isTrigger = false;
      this.Prompt.gameObject.GetComponent<Rigidbody>().isKinematic = false;
      this.Prompt.gameObject.GetComponent<Rigidbody>().useGravity = true;
      this.Prompt.enabled = true;
      this.transform.parent = (Transform) null;
    }
    else
    {
      if ((double) this.Prompt.Circle[3].fillAmount != 0.0)
        return;
      this.Succeed();
      this.Prompt.Hide();
      this.PickpocketPanel.enabled = false;
      this.Prompt.enabled = false;
      this.Prompt.Hide();
      this.Key.SetActive(false);
      this.enabled = false;
      this.gameObject.SetActive(false);
    }
  }

  private void Punish()
  {
    Debug.Log((object) "Punishing Yandere-chan for pickpocketing.");
    Object.Instantiate<GameObject>(this.AlarmDisc, this.Student.Yandere.transform.position + Vector3.up, Quaternion.identity).GetComponent<AlarmDiscScript>().NoScream = true;
    if (!this.NotNurse && !this.Prompt.Yandere.Egg)
    {
      Debug.Log((object) "A faculty member saw pickpocketing.");
      this.Student.Witnessed = StudentWitnessType.Theft;
      this.Student.SenpaiNoticed();
      this.Student.CameraEffects.MurderWitnessed();
      this.Student.Concern = 5;
    }
    else
    {
      this.Student.Witnessed = StudentWitnessType.Pickpocketing;
      this.Student.CameraEffects.Alarm();
      this.Student.Alarm += 200f;
    }
    this.Timer = 0.0f;
    this.Prompt.Hide();
    this.Prompt.enabled = false;
    this.PickpocketPanel.enabled = false;
    this.Student.CharacterAnimation[this.Student.PatrolAnim].time = 0.0f;
    this.Student.PatrolTimer = 0.0f;
  }

  private void Succeed()
  {
    if (this.ID == 1)
    {
      this.Student.StudentManager.ShedDoor.Prompt.Label[0].text = "     Open";
      this.Student.StudentManager.ShedDoor.Locked = false;
      this.Student.ClubManager.Padlock.SetActive(false);
      this.Student.Yandere.Inventory.ShedKey = true;
    }
    else
    {
      this.Student.StudentManager.CabinetDoor.Prompt.Label[0].text = "     Open";
      this.Student.StudentManager.CabinetDoor.Locked = false;
      this.Student.Yandere.Inventory.CabinetKey = true;
    }
    this.Student.Yandere.NotificationManager.CustomText = "Got the key!";
    this.Student.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
  }
}
