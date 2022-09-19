// Decompiled with JetBrains decompiler
// Type: GiggleScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class GiggleScript : MonoBehaviour
{
  public GameObject EmptyGameObject;
  public GameObject Giggle;
  public StudentScript Student;
  public bool StudentIsBusy;
  public bool Distracted;
  public bool BangSnap;
  public int Frame;

  private void Start()
  {
    float num = (float) (500.0 * (2.0 - (double) SchoolGlobals.SchoolAtmosphere));
    this.transform.localScale = new Vector3(num, this.transform.localScale.y, num);
  }

  private void Update()
  {
    if (this.Frame > 0)
      Object.Destroy((Object) this.gameObject);
    ++this.Frame;
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.layer != 9 || this.Distracted)
      return;
    this.Student = other.gameObject.GetComponent<StudentScript>();
    if (!((Object) this.Student != (Object) null) || !this.Student.enabled || !((Object) this.Student.Giggle == (Object) null))
      return;
    if (this.Student.StudentManager.LockerRoomArea.bounds.Contains(this.transform.position) || this.Student.StudentManager.WestBathroomArea.bounds.Contains(this.transform.position) || this.Student.StudentManager.EastBathroomArea.bounds.Contains(this.transform.position) || this.Student.Club != ClubType.Delinquent && this.Student.StudentManager.IncineratorArea.bounds.Contains(this.transform.position) || this.Student.StudentManager.HeadmasterArea.bounds.Contains(this.transform.position))
    {
      Debug.Log((object) "Ignored because the giggle came from a bathroom/locker room.");
      if (this.Student.Yandere.NotificationManager.NotificationParent.childCount != 0)
        return;
      this.Student.Yandere.NotificationManager.CustomText = "Nobody will investigate a sound from there...";
      this.Student.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
    }
    else
    {
      if (this.Student.Clock.Period == 3 && this.Student.BusyAtLunch)
        this.StudentIsBusy = true;
      if ((this.Student.StudentID == 47 || this.Student.StudentID == 49) && this.Student.StudentManager.ConvoManager.Confirmed)
        this.StudentIsBusy = true;
      if (this.Student.StudentID == this.Student.StudentManager.RivalID || this.Student.StudentID == 1)
      {
        int currentAction = (int) this.Student.CurrentAction;
      }
      if (!this.Student.YandereVisible && !this.Student.Alarmed && !this.Student.Distracted && !this.Student.Wet && !this.Student.Slave && !this.Student.WitnessedMurder && !this.Student.WitnessedCorpse && !this.Student.Investigating && !this.Student.InEvent && !this.Student.Following && !this.Student.Confessing && !this.Student.Meeting && !this.Student.TurnOffRadio && !this.Student.Fleeing && !this.Student.Distracting && !this.Student.GoAway && !this.Student.FocusOnYandere && !this.StudentIsBusy && !this.Student.MyBento.Tampered && !this.Student.Headache && this.Student.Routine && this.Student.Indoors && !this.Student.VisitSenpaiDesk && this.Student.Actions[this.Student.Phase] != StudentActionType.Teaching && this.Student.Actions[this.Student.Phase] != StudentActionType.SitAndTakeNotes && this.Student.Actions[this.Student.Phase] != StudentActionType.Graffiti && this.Student.Actions[this.Student.Phase] != StudentActionType.Bully)
      {
        this.Student.CharacterAnimation.CrossFade(this.Student.IdleAnim);
        this.Giggle = Object.Instantiate<GameObject>(this.EmptyGameObject, new Vector3(this.transform.position.x, this.Student.transform.position.y, this.transform.position.z), Quaternion.identity);
        this.Student.Giggle = this.Giggle;
        ++this.Student.AnnoyedByGiggles;
        if ((Object) this.Student.Pathfinding != (Object) null && !this.Student.Nemesis)
        {
          if (this.Student.Drownable)
          {
            this.Student.Drownable = false;
            this.Student.StudentManager.UpdateMe(this.Student.StudentID);
          }
          if (this.Student.ChalkDust.isPlaying)
          {
            this.Student.ChalkDust.Stop();
            this.Student.Pushable = false;
            this.Student.StudentManager.UpdateMe(this.Student.StudentID);
          }
          this.Student.Pathfinding.canSearch = false;
          this.Student.Pathfinding.canMove = false;
          this.Student.InvestigationPhase = 0;
          this.Student.InvestigationTimer = 0.0f;
          this.Student.Investigating = true;
          this.Student.EatingSnack = false;
          this.Student.SpeechLines.Stop();
          this.Student.ChalkDust.Stop();
          this.Student.DiscCheck = true;
          this.Student.Routine = false;
          this.Student.CleanTimer = 0.0f;
          this.Student.ReadPhase = 0;
          this.Student.StopPairing();
          Debug.Log((object) (this.Student.Name + " just heard a giggle, so their ''DiskCheck'' was set to ''true''."));
          if (this.Student.SunbathePhase > 2)
            this.Student.SunbathePhase = 2;
          if (this.Student.Persona != PersonaType.PhoneAddict && !this.Student.Sleuthing)
            this.Student.SmartPhone.SetActive(false);
          else if (!this.Student.Phoneless)
            this.Student.SmartPhone.SetActive(true);
          this.Student.OccultBook.SetActive(false);
          this.Student.Pen.SetActive(false);
          if (!this.Student.Male)
          {
            this.Student.Cigarette.SetActive(false);
            this.Student.Lighter.SetActive(false);
          }
          bool flag1 = false;
          if (this.Student.Bento.activeInHierarchy && this.Student.StudentID > 1 && (Object) this.Student.Bento.transform.parent != (Object) null)
            flag1 = true;
          this.Student.EmptyHands();
          bool flag2 = false;
          if (this.Student.CurrentAction == StudentActionType.Sunbathe && this.Student.SunbathePhase > 2)
          {
            this.Student.SunbathePhase = 2;
            flag2 = true;
          }
          if ((this.Student.Persona == PersonaType.PhoneAddict && !this.Student.Phoneless && !flag2 || this.Student.Persona == PersonaType.Sleuth || this.Student.StudentID == 20) && !this.Student.Phoneless)
            this.Student.SmartPhone.SetActive(true);
          if (flag1)
          {
            GenericBentoScript component = this.Student.Bento.GetComponent<GenericBentoScript>();
            component.enabled = true;
            component.Prompt.enabled = true;
            this.Student.Bento.SetActive(true);
            this.Student.Bento.transform.parent = this.Student.transform;
            this.Student.Bento.transform.localPosition = !this.Student.Male ? new Vector3(0.0f, 0.461f, -0.075f) : new Vector3(0.0f, 0.4266666f, -0.075f);
            this.Student.Bento.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            this.Student.Bento.transform.parent = (Transform) null;
          }
          this.Student.Yandere.NotificationManager.CustomText = !this.BangSnap ? this.Student.Name + " heard a giggle." : this.Student.Name + " heard a sound.";
          this.Student.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
        }
        this.Distracted = true;
      }
      else
      {
        if (this.Student.InEvent)
        {
          this.Student.Yandere.NotificationManager.CustomText = this.Student.Name + " is in an event right now.";
          this.Student.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
        }
        this.Student.Yandere.NotificationManager.CustomText = !this.BangSnap ? this.Student.Name + " ignored a giggle." : this.Student.Name + " ignored a sound.";
        this.Student.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
      }
    }
  }
}
