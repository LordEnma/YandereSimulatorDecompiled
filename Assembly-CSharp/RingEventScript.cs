// Decompiled with JetBrains decompiler
// Type: RingEventScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class RingEventScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public YandereScript Yandere;
  public ClockScript Clock;
  public StudentScript EventStudent;
  public UILabel EventSubtitle;
  public AudioClip[] EventClip;
  public string[] EventSpeech;
  public string[] EventAnim;
  public GameObject VoiceClip;
  public bool EventActive;
  public bool RingStolen;
  public bool EventOver;
  public float EventTime = 13.1f;
  public int EventStudentID = 2;
  public int AccessoryID = 3;
  public int EventPhase = 1;
  public Vector3 OriginalPosition;
  public Vector3 HoldingPosition;
  public Vector3 HoldingRotation;
  public float CurrentClipLength;
  public float Timer;
  public PromptScript RingPrompt;
  public Collider RingCollider;

  private void Start()
  {
    this.HoldingPosition = new Vector3(0.0075f, -0.0355f, 7f / 400f);
    this.HoldingRotation = new Vector3(15f, -70f, -135f);
    if (GameGlobals.RingStolen)
      this.gameObject.SetActive(false);
    if (!GameGlobals.Eighties)
      return;
    this.EventStudentID = 30;
    this.AccessoryID = 15;
  }

  private void Update()
  {
    if (!this.Clock.StopTime && !this.EventActive && (double) this.Clock.HourTime > (double) this.EventTime)
    {
      this.EventStudent = this.StudentManager.Students[this.EventStudentID];
      if ((Object) this.EventStudent != (Object) null && !this.EventStudent.Distracted && !this.EventStudent.Talking && !this.EventStudent.EatingSnack && this.EventStudent.CurrentAction == StudentActionType.SitAndEatBento)
      {
        if (!this.EventStudent.WitnessedMurder && !this.EventStudent.Bullied)
        {
          if (this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].activeInHierarchy)
          {
            this.RingPrompt = this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].GetComponent<PromptScript>();
            this.RingCollider = (Collider) this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].GetComponent<BoxCollider>();
            this.OriginalPosition = this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].transform.localPosition;
            this.EventStudent.CurrentDestination = this.EventStudent.Destinations[this.EventStudent.Phase];
            this.EventStudent.Pathfinding.target = this.EventStudent.Destinations[this.EventStudent.Phase];
            this.EventStudent.Obstacle.checkTime = 99f;
            this.EventStudent.InEvent = true;
            this.EventStudent.Private = true;
            this.EventActive = true;
            if (this.EventStudent.Following)
            {
              this.EventStudent.Pathfinding.canMove = true;
              this.EventStudent.Pathfinding.speed = 1f;
              this.EventStudent.Following = false;
              this.EventStudent.Routine = true;
              this.Yandere.Follower = (StudentScript) null;
              --this.Yandere.Followers;
              this.EventStudent.Subtitle.UpdateLabel(SubtitleType.StopFollowApology, 0, 3f);
              this.EventStudent.Prompt.Label[0].text = "     Talk";
            }
          }
          else
          {
            Debug.Log((object) "Disabling because the girl doesn't have her ring?");
            this.enabled = false;
          }
        }
        else
        {
          Debug.Log((object) "Disabling because the girl witnessed murder or was bullied?");
          this.enabled = false;
        }
      }
    }
    if (!this.EventActive)
      return;
    if ((double) this.EventStudent.DistanceToDestination < 0.5)
    {
      this.EventStudent.Pathfinding.canSearch = false;
      this.EventStudent.Pathfinding.canMove = false;
    }
    if (this.EventStudent.Alarmed && (double) this.Yandere.TheftTimer > 0.0)
    {
      Debug.Log((object) "Event ended because the owner of the ring witnessed the theft.");
      this.EventStudent.Yandere.NotificationManager.CustomText = "You failed to steal the ring.";
      this.EventStudent.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
      this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].transform.parent = this.EventStudent.LeftMiddleFinger;
      this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].transform.localPosition = this.OriginalPosition;
      this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
      this.RingCollider.gameObject.SetActive(true);
      this.RingCollider.enabled = false;
      this.RingPrompt.Hide();
      this.RingPrompt.enabled = false;
      this.RingPrompt.GetComponent<RingScript>().enabled = false;
      this.EventStudent.RingReact = true;
      this.Yandere.Inventory.Ring = false;
      this.EndEvent();
    }
    else if ((double) this.Clock.HourTime > (double) this.EventTime + 0.5 || this.EventStudent.WitnessedMurder || this.EventStudent.Splashed || this.EventStudent.Alarmed || this.EventStudent.Dying || !this.EventStudent.Alive)
      this.EndEvent();
    else if (!this.EventStudent.Pathfinding.canMove)
    {
      if (this.EventPhase == 1)
      {
        this.Timer += Time.deltaTime;
        this.EventStudent.CharacterAnimation.CrossFade(this.EventAnim[0]);
        ++this.EventPhase;
      }
      else if (this.EventPhase == 2)
      {
        this.Timer += Time.deltaTime;
        if ((double) this.Timer > (double) this.EventStudent.CharacterAnimation[this.EventAnim[0]].length)
        {
          this.EventStudent.CharacterAnimation.CrossFade(this.EventStudent.EatAnim);
          this.EventStudent.Bento.transform.localPosition = new Vector3(-0.025f, -0.105f, 0.0f);
          this.EventStudent.Bento.transform.localEulerAngles = new Vector3(0.0f, 165f, 82.5f);
          this.EventStudent.Chopsticks[0].SetActive(true);
          this.EventStudent.Chopsticks[1].SetActive(true);
          this.EventStudent.Bento.SetActive(true);
          this.EventStudent.Lid.SetActive(false);
          this.RingCollider.enabled = true;
          this.RingPrompt.enabled = true;
          this.RingPrompt.GetComponent<RingScript>().enabled = true;
          this.RingPrompt.GetComponent<RingScript>().RingEvent = this;
          ++this.EventPhase;
          this.Timer = 0.0f;
        }
        else if ((double) this.Timer > 4.0)
        {
          if ((Object) this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID] != (Object) null)
          {
            this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].transform.parent = (Transform) null;
            if (!this.StudentManager.Eighties)
            {
              this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].transform.position = new Vector3(-2.707666f, 12.4695f, -31.136f);
              this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].transform.eulerAngles = new Vector3(-20f, 180f, 0.0f);
            }
            else
            {
              this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].transform.position = new Vector3(4.946667f, 0.4768f, 18.65925f);
              this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].transform.eulerAngles = new Vector3(-22.5f, 180f, 0.0f);
            }
          }
        }
        else if ((double) this.Timer > 2.5)
        {
          this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].transform.parent = this.EventStudent.RightHand;
          this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].transform.localPosition = this.HoldingPosition;
          this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].transform.localEulerAngles = this.HoldingRotation;
        }
      }
      else if (this.EventPhase == 3)
      {
        if ((double) this.Clock.HourTime > 13.375)
        {
          this.EventStudent.Bento.SetActive(false);
          this.EventStudent.Chopsticks[0].SetActive(false);
          this.EventStudent.Chopsticks[1].SetActive(false);
          if ((Object) this.RingCollider != (Object) null)
            this.RingCollider.enabled = false;
          if ((Object) this.RingPrompt != (Object) null)
          {
            this.RingPrompt.Hide();
            this.RingPrompt.enabled = false;
          }
          RingScript component = this.RingPrompt.GetComponent<RingScript>();
          if ((Object) component != (Object) null)
            component.enabled = false;
          this.EventStudent.CharacterAnimation[this.EventAnim[0]].time = this.EventStudent.CharacterAnimation[this.EventAnim[0]].length;
          this.EventStudent.CharacterAnimation[this.EventAnim[0]].speed = -1f;
          if (!this.RingStolen)
            this.EventStudent.CharacterAnimation.CrossFade(this.EventAnim[0]);
          else
            this.EventStudent.CharacterAnimation.CrossFade(this.EventAnim[1]);
          ++this.EventPhase;
        }
      }
      else if (this.EventPhase == 4)
      {
        this.Timer += Time.deltaTime;
        if (!this.RingStolen && (Object) this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID] != (Object) null && this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].activeInHierarchy)
        {
          this.EventStudent.CharacterAnimation.CrossFade(this.EventAnim[0]);
          if ((double) this.Timer > 2.0)
          {
            this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].transform.parent = this.EventStudent.RightHand;
            this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].transform.localPosition = this.HoldingPosition;
            this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].transform.localEulerAngles = this.HoldingRotation;
          }
          if ((double) this.Timer > 3.0)
          {
            this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].transform.parent = this.EventStudent.LeftMiddleFinger;
            this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].transform.localPosition = this.OriginalPosition;
            this.RingCollider.enabled = false;
            this.RingPrompt.enabled = false;
            this.RingPrompt.Hide();
            this.RingPrompt.GetComponent<RingScript>().enabled = false;
          }
          if ((double) this.Timer > 6.0)
            this.EndEvent();
        }
        else
        {
          Debug.Log((object) "The ring was stolen.");
          this.EventStudent.CharacterAnimation.CrossFade(this.EventAnim[1]);
          if ((double) this.Timer > 1.5)
          {
            if ((double) Vector3.Distance(this.EventStudent.transform.position, this.Yandere.transform.position) < 10.0)
            {
              this.EventSubtitle.text = this.EventSpeech[0];
              AudioClipPlayer.Play(this.EventClip[0], this.EventStudent.transform.position + Vector3.up, 5f, 10f, out this.VoiceClip, out this.CurrentClipLength);
            }
            ++this.EventPhase;
          }
        }
      }
      else if (this.EventPhase == 5)
      {
        this.Timer += Time.deltaTime;
        if ((double) this.Timer > 9.5)
          this.EndEvent();
      }
      float num1 = Vector3.Distance(this.Yandere.transform.position, this.EventStudent.transform.position);
      if ((double) num1 >= 11.0)
        return;
      if ((double) num1 < 10.0)
      {
        float num2 = Mathf.Abs((float) (((double) num1 - 10.0) * 0.200000002980232));
        if ((double) num2 < 0.0)
          num2 = 0.0f;
        if ((double) num2 > 1.0)
          num2 = 1f;
        this.EventSubtitle.transform.localScale = new Vector3(num2, num2, num2);
      }
      else
        this.EventSubtitle.transform.localScale = Vector3.zero;
    }
    else
      this.EventStudent.CharacterAnimation.CrossFade(this.EventStudent.WalkAnim);
  }

  private void EndEvent()
  {
    if (!this.EventOver)
    {
      if ((Object) this.VoiceClip != (Object) null)
        Object.Destroy((Object) this.VoiceClip);
      this.EventStudent.CurrentDestination = this.EventStudent.Destinations[this.EventStudent.Phase];
      this.EventStudent.Pathfinding.target = this.EventStudent.Destinations[this.EventStudent.Phase];
      this.EventStudent.Obstacle.checkTime = 1f;
      if (!this.EventStudent.Dying)
        this.EventStudent.Prompt.enabled = true;
      this.EventStudent.Pathfinding.speed = 1f;
      this.EventStudent.TargetDistance = 0.5f;
      this.EventStudent.InEvent = false;
      this.EventStudent.Private = false;
      this.EventSubtitle.text = string.Empty;
      this.StudentManager.UpdateStudents();
    }
    this.EventActive = false;
    this.enabled = false;
  }

  public void ReturnRing()
  {
    if (!((Object) this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID] != (Object) null))
      return;
    this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].transform.parent = this.EventStudent.LeftMiddleFinger;
    this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].transform.localPosition = this.OriginalPosition;
    this.RingCollider.enabled = false;
    this.RingPrompt.Hide();
    this.RingPrompt.enabled = false;
    this.RingPrompt.GetComponent<RingScript>().enabled = false;
  }
}
