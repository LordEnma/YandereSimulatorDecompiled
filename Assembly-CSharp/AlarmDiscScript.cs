// Decompiled with JetBrains decompiler
// Type: AlarmDiscScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class AlarmDiscScript : MonoBehaviour
{
  public AudioClip[] LongFemaleScreams;
  public AudioClip[] LongMaleScreams;
  public AudioClip[] FemaleScreams;
  public AudioClip[] MaleScreams;
  public AudioClip[] DelinquentScreams;
  public StudentScript Originator;
  public RadioScript SourceRadio;
  public StudentScript Student;
  public bool FocusOnYandere;
  public bool StudentIsBusy;
  public bool Delinquent;
  public bool NoScream;
  public bool Shocking;
  public bool Persist;
  public bool Silent;
  public bool Radio;
  public bool Male;
  public bool Long;
  public float Hesitation = 1f;
  public int Frame;

  private void Start()
  {
    Vector3 localScale = this.transform.localScale;
    localScale.x *= 2f - SchoolGlobals.SchoolAtmosphere;
    localScale.z = localScale.x;
    this.transform.localScale = localScale;
  }

  private void Update()
  {
    if (this.Frame > 0)
      Object.Destroy((Object) this.gameObject);
    else if (!this.NoScream && !this.Silent)
    {
      if (!this.Long)
      {
        if ((Object) this.Originator != (Object) null)
          this.Male = this.Originator.Male;
        if (!this.Male)
          this.PlayClip(this.FemaleScreams[Random.Range(0, this.FemaleScreams.Length)], this.transform.position);
        else if (this.Delinquent)
          this.PlayClip(this.DelinquentScreams[Random.Range(0, this.DelinquentScreams.Length)], this.transform.position);
        else
          this.PlayClip(this.MaleScreams[Random.Range(0, this.MaleScreams.Length)], this.transform.position);
      }
      else if (!this.Male)
        this.PlayClip(this.LongFemaleScreams[Random.Range(0, this.LongFemaleScreams.Length)], this.transform.position);
      else
        this.PlayClip(this.LongMaleScreams[Random.Range(0, this.LongMaleScreams.Length)], this.transform.position);
    }
    ++this.Frame;
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.layer == 9)
    {
      this.Student = other.gameObject.GetComponent<StudentScript>();
      if ((Object) this.Student != (Object) null && this.Student.enabled && this.Student.DistractionSpot != new Vector3(this.transform.position.x, this.Student.transform.position.y, this.transform.position.z))
      {
        if (!this.Persist)
          Object.Destroy((Object) this.Student.Giggle);
        this.Student.InvestigationTimer = 0.0f;
        this.Student.InvestigationPhase = 0;
        this.Student.Investigating = false;
        this.Student.DiscCheck = false;
        ++this.Student.VisionDistance;
        this.Student.ChalkDust.Stop();
        this.Student.CleanTimer = 0.0f;
        if (!this.Radio)
        {
          if ((Object) this.Student != (Object) this.Originator)
          {
            if (this.Student.Clock.Period == 3 && this.Student.BusyAtLunch)
              this.StudentIsBusy = true;
            if ((this.Student.StudentID == 47 || this.Student.StudentID == 49) && this.Student.StudentManager.ConvoManager.Confirmed)
              this.StudentIsBusy = true;
            if (this.Student.StudentID == 7 && this.Student.Hurry)
              this.Student.Distracted = false;
            if (this.Student.StudentID == this.Student.StudentManager.RivalID || this.Student.StudentID == 1)
            {
              int currentAction = (int) this.Student.CurrentAction;
            }
            if (!this.Student.TurnOffRadio && this.Student.Alive && !this.Student.Blind && !this.Student.Pushed && !this.Student.Dying && !this.Student.Alarmed && !this.Student.Guarding && !this.Student.Wet && !this.Student.Slave && !this.Student.CheckingNote && !this.Student.WitnessedMurder && !this.Student.WitnessedCorpse && !this.Student.Emetic && !this.Student.Confessing && !this.StudentIsBusy && !this.Student.FocusOnYandere && !this.Student.Fleeing && !this.Student.Shoving && !this.Student.SentHome && this.Student.ClubActivityPhase < 16 && !this.Student.Vomiting && !this.Student.Lethal && !this.Student.Headache && !this.Student.Sedated && !this.Student.SenpaiWitnessingRivalDie && !this.Student.Hunted && !this.Student.Drowned && !this.Student.DramaticReaction && !this.Student.Yandere.Chased && !this.Student.ImmuneToLaughter && !this.Student.ListeningToReport || this.Student.Persona == PersonaType.Protective && (Object) this.Originator != (Object) null && this.Originator.StudentID == 11 && !this.Student.Hunted && !this.Student.Emetic && !this.Student.Headache)
            {
              int num = this.Student.Male ? 1 : 0;
              if (!this.Student.Struggling)
                this.Student.Character.GetComponent<Animation>().CrossFade(this.Student.LeanAnim);
              this.Student.DistractionSpot = !((Object) this.Originator != (Object) null) ? new Vector3(this.transform.position.x, this.Student.transform.position.y, this.transform.position.z) : (!this.Originator.WitnessedMurder ? (!((Object) this.Originator.Corpse == (Object) null) ? new Vector3(this.Originator.Corpse.transform.position.x, this.Student.transform.position.y, this.Originator.Corpse.transform.position.z) : new Vector3(this.transform.position.x, this.Student.transform.position.y, this.transform.position.z)) : new Vector3(this.transform.position.x, this.Student.Yandere.transform.position.y, this.transform.position.z));
              this.Student.DiscCheck = true;
              Debug.Log((object) (this.Student.Name + "'s ''DiskCheck'' was just set to ''true''."));
              if (this.Shocking)
                this.Student.Hesitation = 0.5f;
              this.Student.Alarm = 200f;
              if ((Object) this.Originator != (Object) null && this.Originator.Attacked)
                Debug.Log((object) (this.Originator.Name + " spawned an Alarm Disc because they were attacked."));
              if (this.Student.StudentID == 10 && (Object) this.Originator != (Object) null && this.Originator.StudentID == 11 && this.Originator.Attacked)
              {
                Debug.Log((object) "Raibaru just became aware that Yandere-chan committed murder.");
                this.Student.AwareOfMurder = true;
              }
              if (!this.NoScream)
              {
                Debug.Log((object) "This alarm disc had a scream attached to it.");
                this.Student.Giggle = (GameObject) null;
                this.InvestigateScream();
              }
              if (this.FocusOnYandere)
                this.Student.FocusOnYandere = true;
              if ((double) this.Hesitation != 1.0)
                this.Student.Hesitation = this.Hesitation;
              if (this.Student.Talking)
                this.Student.DialogueWheel.End();
            }
          }
        }
        else
        {
          if ((Object) this.Student.Giggle != (Object) null)
            this.Student.StopInvestigating();
          if (!this.Student.Nemesis && this.Student.Alive && !this.Student.Dying && !this.Student.Guarding && !this.Student.Alarmed && !this.Student.Wet && !this.Student.Slave && !this.Student.Headache && !this.Student.WitnessedMurder && !this.Student.WitnessedCorpse && !this.Student.Lethal && !this.Student.InEvent && !this.Student.Following && !this.Student.Distracting && !this.Student.GoAway && this.Student.Routine && !this.Student.CheckingNote && !this.Student.SentHome)
          {
            if ((Object) this.Student.CharacterAnimation != (Object) null)
            {
              ++this.Student.AnnoyedByRadio;
              if ((Object) this.SourceRadio.Victim == (Object) null)
              {
                if (this.Student.StudentManager.LockerRoomArea.bounds.Contains(this.transform.position) || this.Student.StudentManager.WestBathroomArea.bounds.Contains(this.transform.position) || this.Student.StudentManager.EastBathroomArea.bounds.Contains(this.transform.position) || this.Student.Club != ClubType.Delinquent && this.Student.StudentManager.IncineratorArea.bounds.Contains(this.transform.position) || this.Student.StudentManager.HeadmasterArea.bounds.Contains(this.transform.position) || this.Student.Rival && this.Student.Actions[this.Student.Phase] == StudentActionType.SitAndTakeNotes)
                {
                  if (this.Student.Yandere.NotificationManager.NotificationParent.childCount < 5)
                  {
                    this.Student.Yandere.NotificationManager.CustomText = this.Student.Name + " ignored a radio.";
                    if (this.Student.Yandere.NotificationManager.CustomText != this.Student.Yandere.NotificationManager.PreviousText)
                      this.Student.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
                  }
                }
                else
                {
                  Debug.Log((object) (this.Student.Name + " has just been alarmed by a radio!"));
                  this.Student.CharacterAnimation.CrossFade(this.Student.LeanAnim);
                  this.Student.Pathfinding.canSearch = false;
                  this.Student.Pathfinding.canMove = false;
                  this.Student.EatingSnack = false;
                  this.Student.Radio = this.SourceRadio;
                  this.Student.TurnOffRadio = true;
                  this.Student.Routine = false;
                  this.Student.GoAway = false;
                  bool flag1 = false;
                  if (this.Student.CurrentAction == StudentActionType.SitAndEatBento && this.Student.Bento.activeInHierarchy && this.Student.StudentID > 1)
                    flag1 = true;
                  this.Student.EmptyHands();
                  bool flag2 = false;
                  if (this.Student.CurrentAction == StudentActionType.Sunbathe && this.Student.SunbathePhase > 2)
                  {
                    this.Student.SunbathePhase = 2;
                    flag2 = true;
                  }
                  if (this.Student.Persona == PersonaType.PhoneAddict && !this.Student.Phoneless && !flag2 || this.Student.Persona == PersonaType.Sleuth || this.Student.StudentID == 20)
                    this.Student.SmartPhone.SetActive(true);
                  if (flag1)
                  {
                    if (!this.Student.MyBento.Tampered)
                    {
                      this.Student.MyBento.enabled = true;
                      this.Student.MyBento.Prompt.enabled = true;
                    }
                    this.Student.Bento.SetActive(true);
                    this.Student.Bento.transform.parent = this.Student.transform;
                    if (this.Student.Male)
                    {
                      this.Student.Bento.transform.localPosition = new Vector3(0.0f, 0.4266666f, -0.075f);
                    }
                    else
                    {
                      Debug.Log((object) "This female student was distracted by a giggle, so her bento has teleported.");
                      this.Student.Bento.transform.localPosition = new Vector3(0.0f, 0.461f, -0.075f);
                    }
                    this.Student.Bento.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
                    this.Student.Bento.transform.parent = (Transform) null;
                  }
                  this.Student.SpeechLines.Stop();
                  this.Student.ChalkDust.Stop();
                  this.Student.CleanTimer = 0.0f;
                  this.Student.RadioTimer = 0.0f;
                  this.Student.ReadPhase = 0;
                  this.SourceRadio.Victim = this.Student;
                  if (this.Student.StudentID == 97 && SchemeGlobals.GetSchemeStage(5) == 3)
                  {
                    SchemeGlobals.SetSchemeStage(5, 4);
                    this.Student.Yandere.PauseScreen.Schemes.UpdateInstructions();
                    this.enabled = false;
                  }
                  this.Student.Yandere.NotificationManager.CustomText = this.Student.Name + " hears the radio.";
                  this.Student.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
                }
              }
            }
          }
          else if (this.Student.Yandere.NotificationManager.NotificationParent.childCount < 5)
          {
            if (this.Student.Routine)
            {
              this.Student.Yandere.NotificationManager.CustomText = this.Student.Name + " is in an event right now!";
              this.Student.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
            }
            this.Student.Yandere.NotificationManager.CustomText = this.Student.Name + " ignored a radio.";
            if (this.Student.Yandere.NotificationManager.CustomText != this.Student.Yandere.NotificationManager.PreviousText)
              this.Student.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
          }
        }
      }
    }
    this.Student = (StudentScript) null;
  }

  private void PlayClip(AudioClip clip, Vector3 pos)
  {
    GameObject gameObject = new GameObject("TempAudio");
    gameObject.transform.position = pos;
    AudioSource audioSource = gameObject.AddComponent<AudioSource>();
    audioSource.clip = clip;
    audioSource.Play();
    Object.Destroy((Object) gameObject, clip.length);
    audioSource.rolloffMode = AudioRolloffMode.Linear;
    audioSource.minDistance = 5f;
    audioSource.maxDistance = 10f;
    audioSource.spatialBlend = 1f;
    audioSource.volume = 0.5f;
    if (!((Object) this.Student != (Object) null))
      return;
    this.Student.DeathScream = gameObject;
  }

  private void InvestigateScream()
  {
    Debug.Log((object) (this.Student.Name + " just heard a scream."));
    if (this.Student.Clock.Period == 3 && this.Student.BusyAtLunch)
      this.StudentIsBusy = true;
    if (!this.Student.YandereVisible && !this.Student.Distracted && !this.Student.Wet && !this.Student.Slave && !this.Student.WitnessedMurder && !this.Student.WitnessedCorpse && !this.Student.Headache && !this.Student.InEvent && !this.Student.Following && !this.Student.Confessing && !this.Student.Meeting && !this.Student.TurnOffRadio && !this.Student.Fleeing && !this.Student.Distracting && !this.Student.GoAway && !this.Student.FocusOnYandere && !this.StudentIsBusy && this.Student.Actions[this.Student.Phase] != StudentActionType.Teaching && this.Student.Actions[this.Student.Phase] != StudentActionType.SitAndTakeNotes && this.Student.Actions[this.Student.Phase] != StudentActionType.Graffiti && this.Student.Actions[this.Student.Phase] != StudentActionType.Bully)
    {
      Debug.Log((object) (this.Student.Name + " should be going to investigate that scream now."));
      this.Student.CharacterAnimation.CrossFade(this.Student.IdleAnim);
      this.Student.Giggle = Object.Instantiate<GameObject>(this.Student.EmptyGameObject, new Vector3(this.transform.position.x, this.Student.transform.position.y, this.transform.position.z), Quaternion.identity);
      if (!((Object) this.Student.Pathfinding != (Object) null) || this.Student.Nemesis)
        return;
      Debug.Log((object) (this.Student.Name + " just heard a scream, so their ''DiskCheck'' was set to ''true''."));
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
      this.Student.EmptyHands();
      this.Student.HeardScream = true;
    }
    else
      Debug.Log((object) ("For some reason, " + this.Student.Name + " decided to completely ignore a SCREAM."));
  }
}
