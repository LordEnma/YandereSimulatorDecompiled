// Decompiled with JetBrains decompiler
// Type: NoteLockerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class NoteLockerScript : MonoBehaviour
{
  public FindStudentLockerScript FindStudentLocker;
  public StudentManagerScript StudentManager;
  public NoteWindowScript NoteWindow;
  public PromptBarScript PromptBar;
  public StudentScript Student;
  public YandereScript Yandere;
  public ListScript MeetSpots;
  public PromptScript Prompt;
  public GameObject NewBall;
  public GameObject NewNote;
  public GameObject Locker;
  public GameObject Ball;
  public GameObject Note;
  public AudioClip NoteSuccess;
  public AudioClip NoteFail;
  public AudioClip NoteFind;
  public bool CheckingNote;
  public bool CanLeaveNote = true;
  public bool SpawnedNote;
  public bool Informed;
  public bool NoteLeft;
  public bool Success;
  public float MeetTime;
  public float Timer;
  public int LockerOwner;
  public int StudentID;
  public int MeetID;
  public int Phase = 1;

  private void Update()
  {
    if ((Object) this.Student != (Object) null)
    {
      Vector3 b = new Vector3(this.transform.position.x, this.Student.transform.position.y, this.transform.position.z);
      if (this.Prompt.enabled)
      {
        if ((double) Vector3.Distance(this.Student.transform.position, b) < 1.0 || this.Yandere.Armed)
        {
          this.Prompt.Hide();
          this.Prompt.enabled = false;
        }
      }
      else if (this.CanLeaveNote && (double) Vector3.Distance(this.Student.transform.position, b) > 1.0 && !this.Yandere.Armed)
        this.Prompt.enabled = true;
    }
    else
      this.Student = this.StudentManager.Students[this.LockerOwner];
    if ((Object) this.Prompt != (Object) null && (double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      this.Prompt.Circle[0].fillAmount = 1f;
      this.NoteWindow.NoteLocker = this;
      this.Yandere.Blur.enabled = true;
      this.NoteWindow.gameObject.SetActive(true);
      this.Yandere.CanMove = false;
      this.NoteWindow.Show = true;
      this.Yandere.HUD.alpha = 0.0f;
      this.PromptBar.Show = true;
      Time.timeScale = 0.0001f;
      this.PromptBar.Label[0].text = "Confirm";
      this.PromptBar.Label[1].text = "Cancel";
      this.PromptBar.Label[4].text = "Select";
      this.PromptBar.UpdateButtons();
    }
    if (!this.NoteLeft)
      return;
    if ((Object) this.Student != (Object) null)
    {
      if (this.Student.Routine && this.Student.Phase < 3 || this.Student.Routine && this.Student.Phase == 8 || this.Student.SentToLocker)
      {
        if ((double) Vector3.Distance(this.transform.position, this.Student.transform.position) < 1.5 && !this.Student.InEvent)
        {
          this.Student.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
          if (!this.Success)
            this.Student.CharacterAnimation.CrossFade(this.Student.TossNoteAnim);
          else
            this.Student.CharacterAnimation.CrossFade(this.Student.KeepNoteAnim);
          this.Student.Pathfinding.canSearch = false;
          this.Student.Pathfinding.canMove = false;
          this.Student.CheckingNote = true;
          this.Student.Routine = false;
          this.Student.InEvent = true;
          this.CheckingNote = true;
        }
      }
      else if (!this.Student.CheckingNote && this.Student.InEvent && !this.Informed && this.Student.Rival && (double) Vector3.Distance(this.transform.position, this.Student.transform.position) < 1.5)
      {
        this.Prompt.Yandere.NotificationManager.CustomText = "Tell her about the note when she's not busy.";
        this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
        this.Prompt.Yandere.NotificationManager.CustomText = "Something else is on her mind right now.";
        this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
        this.Prompt.Yandere.NotificationManager.CustomText = "She didn't notice the note in her locker.";
        this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
        this.Informed = true;
      }
    }
    if (!this.CheckingNote)
      return;
    if ((double) this.Timer == 0.0)
    {
      int num = (Object) this.Student.Follower != (Object) null ? 1 : 0;
      this.Phase = 1;
    }
    this.Timer += Time.deltaTime;
    this.Student.MoveTowardsTarget(this.Student.MyLocker.position);
    this.Student.transform.rotation = Quaternion.Slerp(this.Student.transform.rotation, this.Student.MyLocker.rotation, 10f * Time.deltaTime);
    if ((Object) this.Student != (Object) null)
    {
      if ((double) this.Student.CharacterAnimation[this.Student.TossNoteAnim].time >= (double) this.Student.CharacterAnimation[this.Student.TossNoteAnim].length)
        this.Finish();
      if ((double) this.Student.CharacterAnimation[this.Student.KeepNoteAnim].time >= (double) this.Student.CharacterAnimation[this.Student.KeepNoteAnim].length)
      {
        this.StudentManager.MeetStudentID = this.StudentID;
        this.StudentManager.MeetTime = this.MeetTime;
        this.StudentManager.MeetID = this.MeetID;
        this.DetermineSchedule();
        this.Finish();
      }
      if (this.Student.Attacked)
        this.ReleaseStudent();
    }
    if ((double) this.Timer > 3.5 && !this.SpawnedNote)
    {
      this.NewNote = Object.Instantiate<GameObject>(this.Note, this.transform.position, Quaternion.identity);
      this.NewNote.transform.parent = this.Student.LeftHand;
      this.NewNote.transform.localPosition = !this.Student.Male ? new Vector3(-0.06f, -0.01f, 0.0f) : new Vector3(-0.133333f, -0.03f, 0.0133333f);
      this.NewNote.transform.localEulerAngles = new Vector3(-75f, -90f, 180f);
      this.NewNote.transform.localScale = new Vector3(0.1f, 0.2f, 1f);
      this.SpawnedNote = true;
    }
    if (!this.Success)
    {
      if ((double) this.Timer > 10.0 && (Object) this.NewNote != (Object) null)
      {
        if ((double) this.NewNote.transform.localScale.z > 0.10000000149011612)
          this.NewNote.transform.localScale = Vector3.MoveTowards(this.NewNote.transform.localScale, Vector3.zero, Time.deltaTime * 2f);
        else
          Object.Destroy((Object) this.NewNote);
      }
      if ((double) this.Timer > 12.25 && (Object) this.NewBall == (Object) null)
      {
        this.NewBall = Object.Instantiate<GameObject>(this.Ball, this.Student.LeftHand.position, Quaternion.identity);
        Rigidbody component = this.NewBall.GetComponent<Rigidbody>();
        component.AddRelativeForce(this.Student.transform.forward * -100f);
        component.AddRelativeForce(Vector3.up * 100f);
        ++this.Phase;
      }
    }
    else if ((double) this.Timer > 12.5 && (Object) this.NewNote != (Object) null)
    {
      if ((double) this.NewNote.transform.localScale.z > 0.10000000149011612)
        this.NewNote.transform.localScale = Vector3.MoveTowards(this.NewNote.transform.localScale, Vector3.zero, Time.deltaTime * 2f);
      else
        Object.Destroy((Object) this.NewNote);
    }
    if (this.Phase == 1)
    {
      if ((double) this.Timer <= 2.3333332538604736)
        return;
      if (!this.Student.Male)
      {
        this.Yandere.Subtitle.Speaker = this.Student;
        this.Yandere.Subtitle.UpdateLabel(SubtitleType.NoteReaction, 1, 3f);
      }
      else
      {
        this.Yandere.Subtitle.Speaker = this.Student;
        this.Yandere.Subtitle.UpdateLabel(SubtitleType.NoteReactionMale, 1, 3f);
      }
      ++this.Phase;
    }
    else
    {
      if (this.Phase != 2)
        return;
      if (!this.Success)
      {
        if ((double) this.Timer <= 9.6666669845581055)
          return;
        if (!this.Student.Male)
        {
          this.Yandere.Subtitle.Speaker = this.Student;
          this.Yandere.Subtitle.UpdateLabel(SubtitleType.NoteReaction, 2, 3f);
        }
        else
        {
          this.Yandere.Subtitle.Speaker = this.Student;
          this.Yandere.Subtitle.UpdateLabel(SubtitleType.NoteReactionMale, 2, 3f);
        }
        ++this.Phase;
      }
      else
      {
        if ((double) this.Timer <= 10.166666984558105)
          return;
        if (!this.Student.Male)
        {
          this.Yandere.Subtitle.Speaker = this.Student;
          this.Yandere.Subtitle.UpdateLabel(SubtitleType.NoteReaction, 3, 3f);
        }
        else
        {
          this.Yandere.Subtitle.Speaker = this.Student;
          this.Yandere.Subtitle.UpdateLabel(SubtitleType.NoteReactionMale, 3, 3f);
        }
        ++this.Phase;
      }
    }
  }

  public void Finish()
  {
    if ((Object) this.NewNote != (Object) null)
      Object.Destroy((Object) this.NewNote);
    if (this.Success)
    {
      if ((double) this.Student.Clock.HourTime > (double) this.Student.MeetTime)
      {
        this.Student.CurrentDestination = this.Student.MeetSpot;
        this.Student.Pathfinding.target = this.Student.MeetSpot;
        this.Student.Meeting = true;
        this.Student.MeetTime = 0.0f;
        if (this.Student.Rival)
          this.StudentManager.UpdateInfatuatedTargetDistances();
      }
      else
      {
        this.Student.CurrentDestination = this.Student.Destinations[this.Student.Phase];
        this.Student.Pathfinding.target = this.Student.Destinations[this.Student.Phase];
      }
      this.Student.Pathfinding.canSearch = true;
      this.Student.Pathfinding.canMove = true;
      this.Student.Pathfinding.speed = 1f;
    }
    else
    {
      Debug.Log((object) (this.Student.Name + " has rejected the note, and is being told to travel to the destination of their current phase."));
      this.Student.CurrentDestination = this.Student.Destinations[this.Student.Phase];
      this.Student.Pathfinding.target = this.Student.Destinations[this.Student.Phase];
      this.FindStudentLocker.Prompt.Label[0].text = "     Find Student Locker";
      this.FindStudentLocker.TargetedStudent = (StudentScript) null;
      this.FindStudentLocker.Prompt.enabled = true;
      this.FindStudentLocker.Phase = 1;
      this.Student.CanTalk = true;
    }
    Animation component = this.Student.Character.GetComponent<Animation>();
    component.cullingType = AnimationCullingType.BasedOnRenderers;
    component.CrossFade(this.Student.IdleAnim);
    this.Student.DistanceToDestination = 100f;
    this.Student.CheckingNote = false;
    this.Student.SentToLocker = false;
    this.Student.InEvent = false;
    this.Student.Routine = true;
    this.CheckingNote = false;
    this.NoteLeft = false;
    ++this.Phase;
    this.NewBall = (GameObject) null;
    this.Timer = 0.0f;
    int num = (Object) this.Student.Follower != (Object) null ? 1 : 0;
  }

  public void ReleaseStudent()
  {
    if ((Object) this.NewNote != (Object) null)
      Object.Destroy((Object) this.NewNote);
    this.CheckingNote = false;
    this.NoteLeft = false;
    ++this.Phase;
    this.NewBall = (GameObject) null;
    this.Timer = 0.0f;
    int num = (Object) this.Student.Follower != (Object) null ? 1 : 0;
  }

  public void DetermineSchedule()
  {
    Debug.Log((object) ("At the time of DetermineSchedule() being called, StudentID was: " + this.StudentID.ToString() + " and MeetID was: " + this.MeetID.ToString()));
    if ((Object) this.Student == (Object) null)
      this.Student = this.StudentManager.Students[this.StudentID];
    if ((Object) this.Student != (Object) null)
    {
      this.Student.MeetSpot = this.MeetSpots.List[this.MeetID];
      this.Student.MeetTime = this.MeetTime;
    }
    else
      Debug.Log((object) "''Student'' was null, somehow...");
  }
}
