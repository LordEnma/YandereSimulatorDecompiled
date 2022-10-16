// Decompiled with JetBrains decompiler
// Type: GenericPromptScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class GenericPromptScript : MonoBehaviour
{
  public GenericPromptScript NextPrompt;
  public StudentScript CrushedStudent;
  public GenericRivalEventScript Event;
  public GameObject CrushCollider;
  public GameObject Effect;
  public GameObject[] Object;
  public Transform ObjectToRotate;
  public Transform PlayerSpot;
  public PromptScript Prompt;
  public AudioSource MyAudio;
  public Mesh NewMesh;
  public bool PerformingAction;
  public bool SpawnedEffect;
  public float TargetRotation = 90f;
  public float Rotation;
  public float Speed;
  public int ID;

  private void Update()
  {
    if (this.ID == 1)
    {
      if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
      {
        this.Prompt.Circle[0].fillAmount = 1f;
        this.Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
        if (!this.Prompt.Yandere.StudentManager.YandereVisible)
        {
          bool flag = false;
          if (this.Prompt.Yandere.Inventory.EmeticPoisons > 0)
          {
            --this.Prompt.Yandere.Inventory.EmeticPoisons;
            flag = true;
          }
          else
          {
            this.Prompt.Yandere.NotificationManager.CustomText = "You don't have the required item!";
            this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
          }
          if (flag)
          {
            this.Prompt.Yandere.StudentManager.Students[1].MyBento.Tampered = true;
            this.Prompt.Yandere.StudentManager.Students[1].MyBento.Emetic = true;
            this.SabotageAndDisable();
          }
        }
        else
        {
          this.Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
          this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
        }
      }
    }
    else if (this.ID == 2)
    {
      if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
      {
        this.Prompt.Circle[0].fillAmount = 1f;
        this.Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
        if (!this.Prompt.Yandere.StudentManager.YandereVisible)
        {
          this.SabotageAndDisable();
        }
        else
        {
          this.Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
          this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
        }
      }
    }
    else if (this.ID == 3)
    {
      if ((double) this.Prompt.Circle[0].fillAmount == 0.0 || (double) this.Prompt.Circle[1].fillAmount == 0.0 || (double) this.Prompt.Circle[2].fillAmount == 0.0 || (double) this.Prompt.Circle[3].fillAmount == 0.0)
      {
        this.Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
        if (!this.Prompt.Yandere.StudentManager.YandereVisible)
        {
          if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
          {
            if (this.Prompt.Yandere.Inventory.Sake)
            {
              this.Prompt.Yandere.Inventory.Sake = false;
              this.SabotageAndDisable();
            }
            else
            {
              this.Prompt.Yandere.NotificationManager.CustomText = "You don't have the required item!";
              this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
            }
          }
          if ((double) this.Prompt.Circle[1].fillAmount == 0.0)
          {
            if (this.Prompt.Yandere.Inventory.Condoms)
            {
              this.Prompt.Yandere.Inventory.Condoms = false;
              this.SabotageAndDisable();
            }
            else
            {
              this.Prompt.Yandere.NotificationManager.CustomText = "You don't have the required item!";
              this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
            }
          }
          if ((double) this.Prompt.Circle[2].fillAmount == 0.0)
          {
            if (this.Prompt.Yandere.Inventory.Cigs)
            {
              this.Prompt.Yandere.Inventory.Cigs = false;
              this.SabotageAndDisable();
            }
            else
            {
              this.Prompt.Yandere.NotificationManager.CustomText = "You don't have the required item!";
              this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
            }
          }
          if ((double) this.Prompt.Circle[3].fillAmount == 0.0)
          {
            if (this.Prompt.Yandere.Inventory.Narcotics)
            {
              this.Prompt.Yandere.Inventory.Narcotics = false;
              this.SabotageAndDisable();
            }
            else
            {
              this.Prompt.Yandere.NotificationManager.CustomText = "You don't have the required item!";
              this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
            }
          }
        }
        else
        {
          this.Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
          this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
        }
        this.Prompt.Circle[0].fillAmount = 1f;
        this.Prompt.Circle[1].fillAmount = 1f;
        this.Prompt.Circle[2].fillAmount = 1f;
        this.Prompt.Circle[3].fillAmount = 1f;
      }
    }
    else if (this.ID == 4)
    {
      if ((UnityEngine.Object) this.Prompt.Yandere.PickUp != (UnityEngine.Object) null && (bool) (UnityEngine.Object) this.Prompt.Yandere.PickUp.Bucket && this.Prompt.Yandere.PickUp.Bucket.Gasoline || (UnityEngine.Object) this.Prompt.Yandere.PickUp != (UnityEngine.Object) null && this.Prompt.Yandere.PickUp.JerryCan)
      {
        this.Prompt.enabled = true;
        if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
        {
          this.Prompt.Circle[0].fillAmount = 1f;
          this.Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
          if (!this.Prompt.Yandere.StudentManager.YandereVisible)
          {
            this.Prompt.Yandere.StudentManager.GasInWateringCan = true;
            this.MyAudio.Play();
            this.Prompt.enabled = false;
            this.Prompt.Hide();
            this.enabled = false;
          }
          else
          {
            this.Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
            this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
          }
        }
      }
      else if (this.Prompt.enabled)
      {
        this.Prompt.enabled = false;
        this.Prompt.Hide();
      }
    }
    else if (this.ID == 5)
    {
      if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
      {
        this.Prompt.Circle[0].fillAmount = 1f;
        if (this.Prompt.Yandere.Class.PhysicalGrade + this.Prompt.Yandere.Class.PhysicalBonus > 0)
        {
          this.Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
          if (!this.Prompt.Yandere.StudentManager.YandereVisible)
          {
            this.Prompt.Yandere.CharacterAnimation.CrossFade("f02_dumpsterPull_00");
            this.Prompt.Yandere.CanMove = false;
            this.PerformingAction = true;
          }
          else
          {
            this.Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
            this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
          }
        }
        else
        {
          this.Prompt.Yandere.NotificationManager.CustomText = "You're not strong enough to move this!";
          this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
        }
      }
    }
    else if (this.ID == 6)
    {
      if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
      {
        this.Prompt.Circle[0].fillAmount = 1f;
        this.Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
        if (!this.Prompt.Yandere.StudentManager.YandereVisible)
        {
          if ((double) Vector3.Distance(this.Prompt.Yandere.transform.position, this.Prompt.Yandere.Senpai.position) < 5.0)
          {
            this.Prompt.Yandere.NotificationManager.CustomText = "Not with him nearby...";
            this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
          }
          else
          {
            this.Prompt.Yandere.Sanity -= (PlayerGlobals.PantiesEquipped == 10 ? 10f : 20f) * this.Prompt.Yandere.Numbness;
            this.Prompt.Yandere.CharacterAnimation.CrossFade("f02_bookcasePush_00");
            this.Prompt.Yandere.transform.position = this.PlayerSpot.position;
            this.Prompt.Yandere.transform.rotation = this.PlayerSpot.rotation;
            this.Prompt.Yandere.CanMove = false;
            this.PerformingAction = true;
          }
        }
        else
        {
          this.Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
          this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
        }
      }
    }
    else if (this.ID == 7)
    {
      if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
      {
        this.Prompt.Circle[0].fillAmount = 1f;
        StudentScript student = this.Prompt.Yandere.StudentManager.Students[15];
        if ((UnityEngine.Object) student != (UnityEngine.Object) null && student.CurrentAction == StudentActionType.Sunbathe && student.SunbathePhase == 3)
        {
          if (student.Blind)
          {
            this.Prompt.Yandere.Sanity -= (PlayerGlobals.PantiesEquipped == 10 ? 10f : 20f) * this.Prompt.Yandere.Numbness;
            student.transform.parent = this.transform.parent;
            student.transform.localPosition = new Vector3(1.374146f, 7f / 400f, 0.05f);
            this.Prompt.Yandere.MurderousActionTimer = 1f;
            this.PerformingAction = true;
            student.enabled = false;
          }
          else
          {
            this.Prompt.Yandere.NotificationManager.CustomText = "It won't work. She's not asleep.";
            this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
          }
        }
        else
        {
          this.Prompt.Yandere.NotificationManager.CustomText = "Nobody is in this chair.";
          this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
        }
      }
    }
    else if (this.ID == 8)
    {
      if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
      {
        this.Prompt.Circle[0].fillAmount = 1f;
        if ((UnityEngine.Object) this.Prompt.Yandere.PickUp != (UnityEngine.Object) null && this.Prompt.Yandere.PickUp.Electronic)
        {
          PickUpScript pickUp = this.Prompt.Yandere.PickUp;
          this.Prompt.Yandere.EmptyHands();
          pickUp.gameObject.SetActive(false);
          pickUp.Prompt.enabled = false;
          pickUp.Prompt.Hide();
          this.Object[1].SetActive(true);
          this.Prompt.enabled = false;
          this.Prompt.Hide();
          this.enabled = false;
        }
        else
        {
          this.Prompt.Yandere.NotificationManager.CustomText = "You're not holding a power strip.";
          this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
        }
      }
    }
    else if (this.ID == 9)
    {
      if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
      {
        this.Prompt.Circle[0].fillAmount = 1f;
        if ((UnityEngine.Object) this.Prompt.Yandere.EquippedWeapon != (UnityEngine.Object) null && this.Prompt.Yandere.EquippedWeapon.WeaponID == 6)
        {
          if (!this.Prompt.Yandere.StudentManager.YandereVisible)
          {
            this.gameObject.SetActive(false);
            this.Object[1].SetActive(false);
            this.Object[2].SetActive(true);
            this.Prompt.enabled = false;
            this.Prompt.Hide();
            this.enabled = false;
          }
          else
          {
            this.Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
            this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
          }
        }
        else
        {
          this.Prompt.Yandere.NotificationManager.CustomText = "You're not holding a screwdriver.";
          this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
        }
      }
    }
    else if (this.ID == 10)
    {
      if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
      {
        this.Prompt.Circle[0].fillAmount = 1f;
        if ((UnityEngine.Object) this.Prompt.Yandere.PickUp != (UnityEngine.Object) null && (bool) (UnityEngine.Object) this.Prompt.Yandere.PickUp.Bucket && this.Prompt.Yandere.PickUp.Bucket.Full)
        {
          this.Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
          if (!this.Prompt.Yandere.StudentManager.YandereVisible)
          {
            this.Object[1].SetActive(true);
            this.Prompt.Yandere.PickUp.Bucket.Empty();
          }
          else
          {
            this.Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
            this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
          }
        }
        else
        {
          this.Prompt.Yandere.NotificationManager.CustomText = "You're not holding a bucket of water.";
          this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
        }
      }
    }
    else if (this.ID == 11 && (double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      this.Prompt.Circle[0].fillAmount = 1f;
      if (this.Object[1].activeInHierarchy && this.Object[2].activeInHierarchy)
        this.Effect.SetActive(!this.Effect.activeInHierarchy);
    }
    if (!this.PerformingAction)
      return;
    if (this.ID == 5)
    {
      this.Rotation = Mathf.MoveTowards(this.Rotation, -90f, Time.deltaTime * 36f);
      this.ObjectToRotate.localEulerAngles = new Vector3(0.0f, this.Rotation, 0.0f);
      this.Prompt.Yandere.transform.position = this.PlayerSpot.position;
      this.Prompt.Yandere.transform.rotation = this.PlayerSpot.rotation;
      if ((double) this.Rotation != -90.0)
        return;
      this.NextPrompt.gameObject.SetActive(true);
      this.Prompt.Yandere.CanMove = true;
      this.Prompt.enabled = false;
      this.Prompt.Hide();
      this.enabled = false;
      this.PerformingAction = false;
    }
    else if (this.ID == 6)
    {
      if ((double) this.Prompt.Yandere.CharacterAnimation["f02_bookcasePush_00"].time <= 0.5)
        return;
      this.ObjectToRotate.transform.localPosition = Vector3.MoveTowards(this.ObjectToRotate.transform.localPosition, new Vector3(-0.169f, 0.17f, -0.94f), Time.deltaTime);
      if ((UnityEngine.Object) this.CrushedStudent != (UnityEngine.Object) null && !this.CrushedStudent.Alive && this.CrushedStudent.DeathType == DeathType.Weight)
      {
        if (!this.CrushedStudent.Male)
          this.CrushedStudent.CharacterAnimation.Play("f02_crushed_00");
        else
          this.CrushedStudent.CharacterAnimation.Play("crushed_00");
      }
      this.Rotation = Mathf.MoveTowards(this.Rotation, this.TargetRotation, Time.deltaTime * 360f);
      this.ObjectToRotate.localEulerAngles = new Vector3(this.Rotation, -90f, 0.0f);
      this.CrushCollider.SetActive(true);
      if ((double) this.Rotation != (double) this.TargetRotation)
        return;
      this.MyAudio.Play();
      this.CrushCollider.SetActive(false);
      this.Prompt.Yandere.CanMove = true;
      this.Prompt.enabled = false;
      this.Prompt.Hide();
      this.enabled = false;
      this.PerformingAction = false;
      this.Object[0].SetActive(true);
      if (!((UnityEngine.Object) this.Prompt.Yandere.StudentManager.Students[13] != (UnityEngine.Object) null) || !this.Prompt.Yandere.StudentManager.Students[13].Alive)
        return;
      Debug.Log((object) "Updating the bookish girl's routine.");
      StudentScript student = this.Prompt.Yandere.StudentManager.Students[13];
      ScheduleBlock scheduleBlock1 = student.ScheduleBlocks[2];
      scheduleBlock1.destination = "Hangout";
      scheduleBlock1.action = "Read";
      ScheduleBlock scheduleBlock2 = student.ScheduleBlocks[7];
      scheduleBlock2.destination = "Hangout";
      scheduleBlock2.action = "Read";
      student.GetDestinations();
      student.Pathfinding.target = student.Destinations[student.Phase];
      student.CurrentDestination = student.Destinations[student.Phase];
    }
    else
    {
      if (this.ID != 7)
        return;
      this.Rotation = Mathf.MoveTowards(this.Rotation, this.TargetRotation, Time.deltaTime * 360f);
      this.transform.parent.localEulerAngles = new Vector3(0.0f, 0.0f, this.Rotation);
      this.transform.parent.localPosition = Vector3.MoveTowards(this.transform.parent.localPosition, new Vector3(6f, 3.75f, 3f), Time.deltaTime);
      if ((double) this.Rotation != (double) this.TargetRotation)
        return;
      if (!this.SpawnedEffect)
      {
        UnityEngine.Object.Instantiate<GameObject>(this.Effect, this.transform.position, Quaternion.identity).transform.eulerAngles = new Vector3(-90f, 0.0f, 0.0f);
        this.Prompt.Yandere.StudentManager.Students[15].transform.parent = this.transform;
        this.SpawnedEffect = true;
      }
      this.transform.position -= new Vector3(0.0f, Time.deltaTime, 0.0f);
      if ((double) this.transform.localPosition.y <= 3.1537001132965088)
        return;
      StudentScript student = this.Prompt.Yandere.StudentManager.Students[15];
      student.Drowned = true;
      student.BecomeRagdoll();
      student.Ragdoll.Zs.SetActive(false);
      student.Ragdoll.DestroyRigidbodies();
      student.DeathType = DeathType.Drowning;
      student.CharacterAnimation.enabled = true;
      student.CharacterAnimation.Play("f02_sunbatheSleep_00");
      this.PerformingAction = false;
      this.Prompt.enabled = false;
      this.Prompt.Hide();
      this.enabled = false;
    }
  }

  public void SabotageAndDisable()
  {
    this.Event.Sabotage();
    this.Prompt.enabled = false;
    this.Prompt.Hide();
    this.enabled = false;
  }
}
