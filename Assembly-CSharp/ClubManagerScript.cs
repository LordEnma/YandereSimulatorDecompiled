// Decompiled with JetBrains decompiler
// Type: ClubManagerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ClubManagerScript : MonoBehaviour
{
  public EmergencyShowerScript EmergencyShower;
  public ShoulderCameraScript ShoulderCamera;
  public StudentManagerScript StudentManager;
  public ComputerGamesScript ComputerGames;
  public BloodCleanerScript BloodCleaner;
  public RefrigeratorScript Refrigerator;
  public ClubWindowScript ClubWindow;
  public TypewriterScript Typewriter;
  public ContainerScript Container;
  public PromptBarScript PromptBar;
  public TranqCaseScript TranqCase;
  public FeedListScript FeedList;
  public YandereScript Yandere;
  public RPG_Camera MainCamera;
  public PickUpScript Candle;
  public DoorScript ShedDoor;
  public PoliceScript Police;
  public GloveScript Gloves;
  public UISprite Darkness;
  public WoodChipperScript[] AcidVats;
  public AudioSource MyAudio;
  public GameObject Viewfinder;
  public GameObject Reputation;
  public GameObject Heartrate;
  public GameObject Watermark;
  public GameObject Padlock;
  public GameObject Ritual;
  public GameObject Clock;
  public GameObject Cake;
  public Transform[] EightiesClubPatrolPoints;
  public Transform[] ClubPatrolPoints;
  public Transform[] ClubVantages;
  public AudioClip[] MotivationalQuotes;
  public GameObject[] EightiesClubPosters;
  public GameObject[] ClubPosters;
  public GameObject[] GameScreens;
  public MaskScript[] Masks;
  public GameObject[] Cultists;
  public Transform[] Club1ActivitySpots;
  public Transform[] Club4ActivitySpots;
  public Transform[] Club6ActivitySpots;
  public Transform Club7ActivitySpot;
  public Transform[] Club8ActivitySpots;
  public Transform[] Club10ActivitySpots;
  public int[] Club1Students;
  public int[] Club2Students;
  public int[] Club3Students;
  public int[] Club4Students;
  public int[] Club5Students;
  public int[] Club6Students;
  public int[] Club7Students;
  public int[] Club8Students;
  public int[] Club9Students;
  public int[] Club10Students;
  public int[] Club11Students;
  public int[] Club14Students;
  public int[] Club15Students;
  public bool LeaderAshamed;
  public bool ClubEffect;
  public AudioClip OccultAmbience;
  public int ActivitiesAttended;
  public int ClubPhase;
  public int Phase = 1;
  public ClubType Club;
  public int ID;
  public float TimeLimit;
  public float Timer;
  public ClubType[] ClubArray;
  public bool[] ClubsKickedFrom;
  public bool[] QuitClub;
  public bool LeaderMissing;
  public bool LeaderDead;
  public int ClubMembers;
  public int[] Club1IDs;
  public int[] Club2IDs;
  public int[] Club3IDs;
  public int[] Club4IDs;
  public int[] Club5IDs;
  public int[] Club6IDs;
  public int[] Club7IDs;
  public int[] Club8IDs;
  public int[] Club9IDs;
  public int[] Club10IDs;
  public int[] Club11IDs;
  public int[] Club14IDs;
  public int[] Club15IDs;
  public int[] ClubIDs;
  public bool LeaderGrudge;
  public bool ClubGrudge;

  private void Start()
  {
    this.LearnKickedClubs();
    this.ActivitiesAttended = ClubGlobals.ActivitiesAttended;
    this.MyAudio = this.GetComponent<AudioSource>();
    this.ClubWindow.ActivityWindow.localScale = Vector3.zero;
    this.ClubWindow.ActivityWindow.gameObject.SetActive(false);
    int num = 0;
    this.ID = 1;
    if (GameGlobals.Eighties)
    {
      this.ClubPatrolPoints = this.EightiesClubPatrolPoints;
      this.ClubPosters = this.EightiesClubPosters;
    }
    for (; this.ID < this.ClubArray.Length; ++this.ID)
    {
      if (ClubGlobals.GetClubClosed(this.ClubArray[this.ID]))
      {
        Debug.Log((object) ("The game recognizes that Club #" + this.ID.ToString() + ", the " + this.ClubArray[this.ID].ToString() + " Club, should be closed!"));
        this.ClubPosters[this.ID].SetActive(false);
        if (this.ClubArray[this.ID] == ClubType.Gardening)
          this.ClubPatrolPoints[this.ID].transform.position = new Vector3(-36f, this.ClubPatrolPoints[this.ID].transform.position.y, this.ClubPatrolPoints[this.ID].transform.position.z);
        else if (this.ClubArray[this.ID] == ClubType.Gaming)
          this.ClubPatrolPoints[this.ID].transform.position = new Vector3(20f, this.ClubPatrolPoints[this.ID].transform.position.y, this.ClubPatrolPoints[this.ID].transform.position.z);
        else if (this.ClubArray[this.ID] != ClubType.Sports)
          this.ClubPatrolPoints[this.ID].transform.position = new Vector3(this.ClubPatrolPoints[this.ID].transform.position.x, this.ClubPatrolPoints[this.ID].transform.position.y, 20f);
        ++num;
      }
      if (ClubGlobals.GetQuitClub(this.ClubArray[this.ID]))
        this.QuitClub[this.ID] = true;
    }
    if (num > 10)
      this.StudentManager.NoClubMeeting = true;
    if (ClubGlobals.GetClubClosed(this.ClubArray[2]))
    {
      this.StudentManager.HidingSpots.List[56] = this.StudentManager.Hangouts.List[56];
      this.StudentManager.HidingSpots.List[57] = this.StudentManager.Hangouts.List[57];
      this.StudentManager.HidingSpots.List[58] = this.StudentManager.Hangouts.List[58];
      this.StudentManager.HidingSpots.List[59] = this.StudentManager.Hangouts.List[59];
      this.StudentManager.HidingSpots.List[60] = this.StudentManager.Hangouts.List[60];
      this.StudentManager.SleuthPhase = 3;
    }
    this.ID = 0;
    this.EmergencyShower.Prompt.enabled = false;
    this.EmergencyShower.Prompt.Hide();
    this.AcidVats[1].Prompt.enabled = false;
    this.AcidVats[1].Prompt.Hide();
    this.AcidVats[2].Prompt.enabled = false;
    this.AcidVats[2].Prompt.Hide();
  }

  private void Update()
  {
    if (this.Club == ClubType.None)
      return;
    if (this.Phase == 1)
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0.0f, Time.deltaTime));
    if ((double) this.Darkness.color.a == 0.0)
    {
      if (this.Phase == 1)
      {
        this.PromptBar.ClearButtons();
        this.PromptBar.Label[0].text = "Continue";
        this.PromptBar.UpdateButtons();
        this.PromptBar.Show = true;
        this.ClubWindow.PerformingActivity = true;
        this.ClubWindow.ActivityWindow.gameObject.SetActive(true);
        this.ClubWindow.ActivityLabel.text = this.ClubWindow.ActivityDescs[(int) this.Club];
        this.StudentManager.Portal.GetComponent<PortalScript>().EndFinalEvents();
        ++this.ActivitiesAttended;
        Debug.Log((object) ("Incremending ActivitiesAttended. That number is now " + this.ActivitiesAttended.ToString()));
        ++this.Phase;
      }
      else if (this.Phase == 2)
      {
        if ((double) this.ClubWindow.ActivityWindow.localScale.x > 0.89999997615814209)
        {
          if (this.Club == ClubType.MartialArts)
          {
            if (this.ClubPhase == 0)
            {
              this.MyAudio.clip = this.MotivationalQuotes[Random.Range(0, this.MotivationalQuotes.Length)];
              this.MyAudio.Play();
              this.ClubEffect = true;
              ++this.ClubPhase;
              this.TimeLimit = this.MyAudio.clip.length;
            }
            else if (this.ClubPhase == 1)
            {
              this.Timer += Time.deltaTime;
              if ((double) this.Timer > (double) this.TimeLimit)
              {
                for (this.ID = 0; this.ID < this.Club6Students.Length; ++this.ID)
                {
                  if ((Object) this.StudentManager.Students[this.ID] != (Object) null && !this.StudentManager.Students[this.ID].Tranquil)
                    this.StudentManager.Students[this.Club6Students[this.ID]].GetComponent<AudioSource>().volume = 1f;
                }
                ++this.ClubPhase;
              }
            }
          }
          if (Input.GetButtonDown("A"))
          {
            this.ClubWindow.PerformingActivity = false;
            this.PromptBar.Show = false;
            ++this.Phase;
          }
        }
      }
      else if ((double) this.ClubWindow.ActivityWindow.localScale.x < 0.10000000149011612)
      {
        this.StudentManager.Reputation.UpdateRep();
        this.Police.Darkness.enabled = true;
        this.Police.ClubActivity = false;
        this.Police.FadeOut = true;
      }
    }
    if (this.Club != ClubType.Occult)
      return;
    this.MyAudio.volume = 1f - this.Darkness.color.a;
  }

  public void ClubActivity()
  {
    this.Yandere.CameraEffects.UpdateDOF(2f);
    this.StudentManager.StopMoving();
    this.ShoulderCamera.enabled = false;
    this.MainCamera.enabled = false;
    this.MainCamera.transform.position = this.ClubVantages[(int) this.Club].position;
    this.MainCamera.transform.rotation = this.ClubVantages[(int) this.Club].rotation;
    if (this.Club != ClubType.LightMusic)
      this.StudentManager.PracticeMusic.gameObject.SetActive(false);
    if (this.Club == ClubType.Cooking)
    {
      this.Cake.SetActive(true);
      for (this.ID = 0; this.ID < this.Club1Students.Length; ++this.ID)
      {
        StudentScript student = this.StudentManager.Students[this.Club1Students[this.ID]];
        if ((Object) student != (Object) null && !student.Tranquil && student.Alive)
        {
          student.transform.position = this.Club1ActivitySpots[this.ID].position;
          student.transform.rotation = this.Club1ActivitySpots[this.ID].rotation;
          student.CharacterAnimation[student.SocialSitAnim].layer = 99;
          student.CharacterAnimation.Play(student.SocialSitAnim);
          student.CharacterAnimation[student.SocialSitAnim].weight = 1f;
          student.SmartPhone.SetActive(false);
          student.SpeechLines.Play();
          student.ClubActivity = true;
          student.Talking = false;
          student.Routine = false;
          student.GetComponent<AudioSource>().volume = 0.1f;
        }
      }
      this.Yandere.Talking = false;
      this.Yandere.CanMove = false;
      this.Yandere.ClubActivity = true;
      this.Yandere.CharacterAnimation.Play("f02_sit_00");
      this.Yandere.transform.position = this.Club1ActivitySpots[6].position;
      this.Yandere.transform.rotation = this.Club1ActivitySpots[6].rotation;
    }
    else if (this.Club == ClubType.Drama)
    {
      for (this.ID = 0; this.ID < this.Club2Students.Length; ++this.ID)
      {
        this.StudentManager.DramaPhase = 1;
        this.StudentManager.UpdateDrama();
        StudentScript student = this.StudentManager.Students[this.Club2Students[this.ID]];
        if ((Object) student != (Object) null && !student.Tranquil && student.Alive)
        {
          if (!this.StudentManager.MemorialScene.gameObject.activeInHierarchy)
          {
            student.transform.position = student.CurrentDestination.position;
            student.transform.rotation = student.CurrentDestination.rotation;
          }
          else
            student.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
          student.ClubActivity = true;
          student.Talking = false;
          student.Routine = true;
          student.GetComponent<AudioSource>().volume = 0.1f;
        }
      }
      this.Yandere.Talking = false;
      this.Yandere.CanMove = false;
      this.Yandere.ClubActivity = true;
      if (!this.StudentManager.MemorialScene.gameObject.activeInHierarchy)
      {
        this.Yandere.transform.position = new Vector3(42f, 1.3775f, 72f);
        this.Yandere.transform.eulerAngles = new Vector3(0.0f, -90f, 0.0f);
      }
    }
    else if (this.Club == ClubType.Occult)
    {
      for (this.ID = 0; this.ID < this.Club3Students.Length; ++this.ID)
      {
        StudentScript student = this.StudentManager.Students[this.Club3Students[this.ID]];
        if ((Object) student != (Object) null && !student.Tranquil)
          student.gameObject.SetActive(false);
      }
      this.MainCamera.GetComponent<AudioListener>().enabled = true;
      AudioSource component = this.GetComponent<AudioSource>();
      component.clip = this.OccultAmbience;
      component.loop = true;
      component.volume = 0.0f;
      component.Play();
      this.Yandere.gameObject.SetActive(false);
      this.Ritual.SetActive(true);
      this.CheckClub(ClubType.Occult);
      foreach (GameObject cultist in this.Cultists)
      {
        if ((Object) cultist != (Object) null)
          cultist.SetActive(false);
      }
      for (; this.ClubMembers > 0; --this.ClubMembers)
        this.Cultists[this.ClubMembers].SetActive(true);
      this.CheckClub(ClubType.Occult);
    }
    else if (this.Club == ClubType.Art)
    {
      for (this.ID = 0; this.ID < this.Club4Students.Length; ++this.ID)
      {
        StudentScript student = this.StudentManager.Students[this.Club4Students[this.ID]];
        if ((Object) student != (Object) null && !student.Tranquil && student.Alive)
        {
          student.transform.position = this.Club4ActivitySpots[this.ID].position;
          student.transform.rotation = this.Club4ActivitySpots[this.ID].rotation;
          student.ClubActivity = true;
          student.SpeechLines.Stop();
          student.Talking = false;
          student.Routine = true;
          if (!student.ClubAttire)
            student.ChangeClubwear();
        }
      }
      this.Yandere.Talking = false;
      this.Yandere.CanMove = false;
      this.Yandere.ClubActivity = true;
      this.Yandere.transform.position = this.Club4ActivitySpots[5].position;
      this.Yandere.transform.rotation = this.Club4ActivitySpots[5].rotation;
      if (!this.Yandere.ClubAttire)
        this.Yandere.ChangeClubwear();
    }
    else if (this.Club == ClubType.LightMusic)
    {
      for (this.ID = 0; this.ID < this.Club5Students.Length; ++this.ID)
      {
        StudentScript student = this.StudentManager.Students[this.Club5Students[this.ID]];
        if ((Object) student != (Object) null && !student.Tranquil && student.Alive)
        {
          student.transform.position = student.CurrentDestination.position;
          student.transform.rotation = student.CurrentDestination.rotation;
          student.ClubActivity = false;
          student.Talking = false;
          student.Routine = true;
          student.Stop = false;
        }
      }
    }
    else if (this.Club == ClubType.MartialArts)
    {
      for (this.ID = 0; this.ID < this.Club6Students.Length; ++this.ID)
      {
        StudentScript student = this.StudentManager.Students[this.Club6Students[this.ID]];
        if ((Object) student != (Object) null && !student.Tranquil && student.Alive)
        {
          student.transform.position = this.Club6ActivitySpots[this.ID].position;
          student.transform.rotation = this.Club6ActivitySpots[this.ID].rotation;
          student.ClubActivity = true;
          student.GetComponent<AudioSource>().volume = 0.1f;
          if (!student.ClubAttire)
            student.ChangeClubwear();
        }
      }
      this.Yandere.CanMove = false;
      this.Yandere.ClubActivity = true;
      this.Yandere.transform.position = this.Club6ActivitySpots[5].position;
      this.Yandere.transform.rotation = this.Club6ActivitySpots[5].rotation;
      if (!this.Yandere.ClubAttire)
        this.Yandere.ChangeClubwear();
    }
    else if (this.Club == ClubType.Photography)
    {
      for (this.ID = 0; this.ID < this.Club7Students.Length; ++this.ID)
      {
        StudentScript student = this.StudentManager.Students[this.Club7Students[this.ID]];
        if ((Object) student != (Object) null && !student.Tranquil && student.Alive)
        {
          student.transform.position = this.StudentManager.Clubs.List[student.StudentID].position;
          student.transform.rotation = this.StudentManager.Clubs.List[student.StudentID].rotation;
          student.CharacterAnimation[student.SocialSitAnim].weight = 1f;
          student.SmartPhone.SetActive(false);
          student.ClubActivity = true;
          student.SpeechLines.Play();
          student.Talking = false;
          student.Routine = true;
          student.Hearts.Stop();
        }
      }
      this.Yandere.CanMove = false;
      this.Yandere.Talking = false;
      this.Yandere.ClubActivity = true;
      this.Yandere.transform.position = this.Club7ActivitySpot.position;
      this.Yandere.transform.rotation = this.Club7ActivitySpot.rotation;
      if (!this.Yandere.ClubAttire)
        this.Yandere.ChangeClubwear();
      this.Yandere.CharacterAnimation.CrossFade(this.Yandere.IdleAnim);
    }
    else if (this.Club == ClubType.Science)
    {
      for (this.ID = 0; this.ID < this.Club8Students.Length; ++this.ID)
      {
        StudentScript student = this.StudentManager.Students[this.Club8Students[this.ID]];
        if ((Object) student != (Object) null && !student.Tranquil && student.Alive)
        {
          student.transform.position = this.Club8ActivitySpots[this.ID].position;
          student.transform.rotation = this.Club8ActivitySpots[this.ID].rotation;
          student.ClubActivity = true;
          student.Talking = false;
          student.Routine = true;
          if (!student.ClubAttire)
            student.ChangeClubwear();
        }
      }
      this.Yandere.Talking = false;
      this.Yandere.CanMove = false;
      this.Yandere.ClubActivity = true;
      if (!this.Yandere.ClubAttire)
        this.Yandere.ChangeClubwear();
    }
    else if (this.Club == ClubType.Sports)
    {
      for (this.ID = 0; this.ID < this.Club9Students.Length; ++this.ID)
      {
        StudentScript student = this.StudentManager.Students[this.Club9Students[this.ID]];
        if ((Object) student != (Object) null && !student.Tranquil && student.Alive)
        {
          student.transform.position = student.CurrentDestination.position;
          student.transform.rotation = student.CurrentDestination.rotation;
          student.ClubActivity = true;
          student.Talking = false;
          student.Routine = true;
        }
      }
      this.Yandere.Talking = false;
      this.Yandere.CanMove = false;
      this.Yandere.ClubActivity = true;
      this.Yandere.Schoolwear = 2;
      this.Yandere.ChangeSchoolwear();
    }
    else if (this.Club == ClubType.Gardening)
    {
      for (this.ID = 0; this.ID < this.Club10Students.Length; ++this.ID)
      {
        StudentScript student = this.StudentManager.Students[this.Club10Students[this.ID]];
        if ((Object) student != (Object) null && !student.Tranquil && student.Alive)
        {
          student.transform.position = student.CurrentDestination.position;
          student.transform.rotation = student.CurrentDestination.rotation;
          student.ClubActivity = true;
          student.Talking = false;
          student.Routine = true;
          student.GetComponent<AudioSource>().volume = 0.1f;
        }
      }
      this.Yandere.Talking = false;
      this.Yandere.CanMove = false;
      this.Yandere.ClubActivity = true;
      if (!this.Yandere.ClubAttire)
        this.Yandere.ChangeClubwear();
    }
    else if (this.Club == ClubType.Gaming)
    {
      for (this.ID = 0; this.ID < this.Club11Students.Length; ++this.ID)
      {
        StudentScript student = this.StudentManager.Students[this.Club11Students[this.ID]];
        if ((Object) student != (Object) null && !student.Tranquil && student.Alive)
        {
          student.transform.position = student.CurrentDestination.position;
          student.transform.rotation = student.CurrentDestination.rotation;
          student.ClubManager.GameScreens[this.ID].SetActive(true);
          student.SmartPhone.SetActive(false);
          student.ClubActivity = true;
          student.Talking = false;
          student.Routine = false;
          student.GetComponent<AudioSource>().volume = 0.1f;
        }
      }
      this.Yandere.Talking = false;
      this.Yandere.CanMove = false;
      this.Yandere.ClubActivity = true;
      this.GameScreens[6].SetActive(true);
      this.Yandere.transform.position = this.StudentManager.ComputerGames.Chairs[1].transform.position;
      this.Yandere.transform.rotation = this.StudentManager.ComputerGames.Chairs[1].transform.rotation;
    }
    else if (this.Club == ClubType.Delinquent)
    {
      Debug.Log((object) "Calling the Delinquent 'club activity'.");
      this.Yandere.gameObject.SetActive(false);
      for (this.ID = 0; this.ID < this.Club14Students.Length; ++this.ID)
      {
        StudentScript student = this.StudentManager.Students[this.Club14Students[this.ID]];
        if ((Object) student != (Object) null && student.Alive)
        {
          Debug.Log((object) ("Telling a delinquent #" + student.StudentID.ToString() + " to leave school."));
          student.Pathfinding.target = this.StudentManager.Exit;
          student.CurrentDestination = this.StudentManager.Exit;
          student.Pathfinding.canSearch = true;
          student.Pathfinding.canMove = true;
          student.Pathfinding.speed = 1f;
          student.DistanceToDestination = 100f;
          student.Talking = false;
          student.Stop = false;
        }
      }
    }
    else if (this.Club == ClubType.Newspaper)
    {
      for (this.ID = 0; this.ID < this.Club15Students.Length; ++this.ID)
      {
        StudentScript student = this.StudentManager.Students[this.Club15Students[this.ID]];
        if ((Object) student != (Object) null && !student.Tranquil && student.Alive)
        {
          student.transform.position = this.StudentManager.Clubs.List[student.StudentID].position;
          student.transform.rotation = this.StudentManager.Clubs.List[student.StudentID].rotation;
          student.ClubActivity = true;
          student.Talking = false;
          student.Routine = true;
        }
      }
      this.Yandere.Talking = false;
      this.Yandere.CanMove = false;
      this.Yandere.ClubActivity = true;
      if (!this.Yandere.ClubAttire)
        this.Yandere.ChangeClubwear();
    }
    this.Clock.SetActive(false);
    this.Reputation.SetActive(false);
    this.Heartrate.SetActive(false);
    this.Watermark.SetActive(false);
  }

  public void CheckClub(ClubType Check)
  {
    switch (Check)
    {
      case ClubType.Cooking:
        this.ClubIDs = this.Club1IDs;
        break;
      case ClubType.Drama:
        this.ClubIDs = this.Club2IDs;
        break;
      case ClubType.Occult:
        this.ClubIDs = this.Club3IDs;
        break;
      case ClubType.Art:
        this.ClubIDs = this.Club4IDs;
        break;
      case ClubType.LightMusic:
        this.ClubIDs = this.Club5IDs;
        break;
      case ClubType.MartialArts:
        this.ClubIDs = this.Club6IDs;
        break;
      case ClubType.Photography:
        this.ClubIDs = this.Club7IDs;
        break;
      case ClubType.Science:
        this.ClubIDs = this.Club8IDs;
        break;
      case ClubType.Sports:
        this.ClubIDs = this.Club9IDs;
        break;
      case ClubType.Gardening:
        this.ClubIDs = this.Club10IDs;
        break;
      case ClubType.Gaming:
        this.ClubIDs = this.Club11IDs;
        if (this.StudentManager.Eighties)
          return;
        break;
      case ClubType.Newspaper:
        this.ClubIDs = this.Club15IDs;
        break;
    }
    this.LeaderMissing = false;
    this.LeaderDead = false;
    this.ClubMembers = 0;
    for (this.ID = 1; this.ID < this.ClubIDs.Length; ++this.ID)
    {
      if (!StudentGlobals.GetStudentDead(this.ClubIDs[this.ID]) && !StudentGlobals.GetStudentDying(this.ClubIDs[this.ID]) && !StudentGlobals.GetStudentKidnapped(this.ClubIDs[this.ID]) && !StudentGlobals.GetStudentArrested(this.ClubIDs[this.ID]) && !StudentGlobals.GetStudentExpelled(this.ClubIDs[this.ID]) && StudentGlobals.GetStudentReputation(this.ClubIDs[this.ID]) > -100)
        ++this.ClubMembers;
    }
    if (this.TranqCase.VictimClubType == Check)
      --this.ClubMembers;
    if (Check == ClubType.LightMusic && this.ClubMembers < 5)
      this.LeaderAshamed = true;
    if (this.Yandere.Club == Check)
      ++this.ClubMembers;
    int studentID = 0;
    switch (Check)
    {
      case ClubType.Cooking:
        studentID = 21;
        break;
      case ClubType.Drama:
        studentID = 26;
        break;
      case ClubType.Occult:
        studentID = 31;
        break;
      case ClubType.Art:
        studentID = 41;
        break;
      case ClubType.LightMusic:
        studentID = 51;
        break;
      case ClubType.MartialArts:
        studentID = 46;
        break;
      case ClubType.Photography:
        studentID = 56;
        break;
      case ClubType.Science:
        studentID = 61;
        break;
      case ClubType.Sports:
        studentID = 66;
        break;
      case ClubType.Gardening:
        studentID = 71;
        break;
      case ClubType.Gaming:
      case ClubType.Newspaper:
        studentID = 36;
        break;
    }
    if (StudentGlobals.GetStudentDead(studentID) || StudentGlobals.GetStudentDying(studentID) || StudentGlobals.GetStudentArrested(studentID) || StudentGlobals.GetStudentReputation(studentID) <= -100 || (Object) this.StudentManager.Students[studentID] != (Object) null && !this.StudentManager.Students[studentID].Alive && !this.StudentManager.Students[studentID].Ragdoll.Disposed)
    {
      Debug.Log((object) "A club leader is dead!");
      this.LeaderDead = true;
    }
    if (StudentGlobals.GetStudentMissing(studentID) || StudentGlobals.GetStudentKidnapped(studentID) || this.TranqCase.VictimID == studentID || (Object) this.StudentManager.Students[studentID] != (Object) null && !this.StudentManager.Students[studentID].Alive && this.StudentManager.Students[studentID].Ragdoll.Disposed)
    {
      Debug.Log((object) "A club leader is missing!");
      this.LeaderMissing = true;
    }
    if (this.LeaderDead || this.LeaderMissing || Check != ClubType.LightMusic || (double) StudentGlobals.GetStudentReputation(51) >= -33.33333)
      return;
    this.LeaderAshamed = true;
  }

  public void CheckGrudge(ClubType Check)
  {
    Debug.Log((object) ("Checking " + Check.ToString() + " Club for a grudge..."));
    switch (Check)
    {
      case ClubType.Cooking:
        this.ClubIDs = this.Club1IDs;
        break;
      case ClubType.Drama:
        this.ClubIDs = this.Club2IDs;
        break;
      case ClubType.Occult:
        this.ClubIDs = this.Club3IDs;
        break;
      case ClubType.Art:
        this.ClubIDs = this.Club4IDs;
        break;
      case ClubType.LightMusic:
        this.ClubIDs = this.Club5IDs;
        break;
      case ClubType.MartialArts:
        this.ClubIDs = this.Club6IDs;
        break;
      case ClubType.Photography:
        this.ClubIDs = this.Club7IDs;
        break;
      case ClubType.Science:
        this.ClubIDs = this.Club8IDs;
        break;
      case ClubType.Sports:
        this.ClubIDs = this.Club9IDs;
        break;
      case ClubType.Gardening:
        this.ClubIDs = this.Club10IDs;
        break;
      case ClubType.Gaming:
        this.ClubIDs = this.Club11IDs;
        break;
      case ClubType.Delinquent:
        this.ClubIDs = this.Club14IDs;
        break;
      case ClubType.Newspaper:
        this.ClubIDs = this.Club15IDs;
        break;
    }
    this.LeaderGrudge = false;
    this.ClubGrudge = false;
    for (this.ID = 1; this.ID < this.ClubIDs.Length; ++this.ID)
    {
      if ((Object) this.StudentManager.Students[this.ClubIDs[this.ID]] != (Object) null && StudentGlobals.GetStudentGrudge(this.ClubIDs[this.ID]))
        this.ClubGrudge = true;
    }
    switch (Check)
    {
      case ClubType.Cooking:
        if (!this.StudentManager.Students[21].Grudge)
          break;
        this.LeaderGrudge = true;
        break;
      case ClubType.Drama:
        if (!this.StudentManager.Students[26].Grudge)
          break;
        this.LeaderGrudge = true;
        break;
      case ClubType.Occult:
        if (!this.StudentManager.Students[31].Grudge)
          break;
        this.LeaderGrudge = true;
        break;
      case ClubType.Art:
        if (!this.StudentManager.Students[41].Grudge)
          break;
        this.LeaderGrudge = true;
        break;
      case ClubType.LightMusic:
        if (!this.StudentManager.Students[51].Grudge)
          break;
        this.LeaderGrudge = true;
        break;
      case ClubType.MartialArts:
        if (!this.StudentManager.Students[46].Grudge)
          break;
        this.LeaderGrudge = true;
        break;
      case ClubType.Photography:
        if (!this.StudentManager.Students[56].Grudge)
          break;
        this.LeaderGrudge = true;
        break;
      case ClubType.Science:
        if (!this.StudentManager.Students[61].Grudge)
          break;
        this.LeaderGrudge = true;
        break;
      case ClubType.Sports:
        if (!this.StudentManager.Students[66].Grudge)
          break;
        this.LeaderGrudge = true;
        break;
      case ClubType.Gardening:
        if (!this.StudentManager.Students[71].Grudge)
          break;
        this.LeaderGrudge = true;
        break;
      case ClubType.Gaming:
      case ClubType.Newspaper:
        if (!this.StudentManager.Students[36].Grudge)
          break;
        this.LeaderGrudge = true;
        break;
      case ClubType.Delinquent:
        if (!this.StudentManager.Students[76].Grudge)
          break;
        this.LeaderGrudge = true;
        break;
    }
  }

  public void ActivateClubBenefit()
  {
    this.Yandere.WeaponManager.UpdateAllWeapons();
    if (this.Yandere.Club == ClubType.Cooking)
    {
      this.FeedList.enabled = true;
      this.FeedList.Prompt.enabled = true;
      this.FeedList.Prompt.Hide();
      if (this.Refrigerator.CookingEvent.EventActive)
        return;
      this.Refrigerator.enabled = true;
      this.Refrigerator.Prompt.enabled = true;
    }
    else if (this.Yandere.Club == ClubType.Drama)
    {
      for (this.ID = 1; this.ID < this.Masks.Length; ++this.ID)
      {
        this.Masks[this.ID].enabled = true;
        this.Masks[this.ID].Prompt.enabled = true;
      }
      this.Gloves.enabled = true;
      this.Gloves.Prompt.enabled = true;
    }
    else if (this.Yandere.Club == ClubType.Occult)
    {
      this.StudentManager.UpdatePerception();
      this.Yandere.Numbness -= 0.5f;
      this.Candle.Suspicious = false;
    }
    else if (this.Yandere.Club == ClubType.Art)
      this.StudentManager.UpdateBooths();
    else if (this.Yandere.Club == ClubType.LightMusic)
    {
      this.Container.enabled = true;
      this.Container.Prompt.enabled = true;
    }
    else if (this.Yandere.Club == ClubType.MartialArts)
      this.StudentManager.UpdateBooths();
    else if (this.Yandere.Club == ClubType.Photography)
    {
      if (!this.StudentManager.Eighties)
        return;
      this.Viewfinder.SetActive(true);
    }
    else if (this.Yandere.Club == ClubType.Science)
    {
      this.EmergencyShower.Prompt.enabled = true;
      this.BloodCleaner.Prompt.enabled = true;
      this.AcidVats[1].Prompt.enabled = true;
      this.AcidVats[2].Prompt.enabled = true;
      this.StudentManager.UpdateBooths();
    }
    else if (this.Yandere.Club == ClubType.Sports)
    {
      ++this.Yandere.RunSpeed;
      if (!this.Yandere.Armed)
        return;
      this.Yandere.EquippedWeapon.SuspicionCheck();
    }
    else if (this.Yandere.Club == ClubType.Gardening)
    {
      this.ShedDoor.Prompt.Label[0].text = "     Open";
      this.Padlock.SetActive(false);
      this.ShedDoor.Locked = false;
      if (!this.Yandere.Armed)
        return;
      this.Yandere.EquippedWeapon.SuspicionCheck();
    }
    else if (this.Yandere.Club == ClubType.Gaming)
    {
      this.ComputerGames.EnableGames();
    }
    else
    {
      if (this.Yandere.Club != ClubType.Newspaper)
        return;
      this.Typewriter.Prompt.enabled = true;
      this.Typewriter.enabled = true;
    }
  }

  public void DeactivateClubBenefit()
  {
    if (this.Yandere.Club == ClubType.Cooking)
    {
      this.FeedList.enabled = false;
      this.FeedList.Prompt.enabled = false;
      this.Refrigerator.enabled = false;
      this.Refrigerator.Prompt.Hide();
      this.Refrigerator.Prompt.enabled = false;
    }
    else if (this.Yandere.Club == ClubType.Drama)
    {
      for (this.ID = 1; this.ID < this.Masks.Length; ++this.ID)
      {
        if ((Object) this.Masks[this.ID] != (Object) null)
        {
          this.Masks[this.ID].enabled = false;
          this.Masks[this.ID].Prompt.Hide();
          this.Masks[this.ID].Prompt.enabled = false;
        }
      }
      this.Gloves.enabled = false;
      this.Gloves.Prompt.Hide();
      this.Gloves.Prompt.enabled = false;
    }
    else if (this.Yandere.Club == ClubType.Occult)
    {
      this.Yandere.Club = ClubType.None;
      this.StudentManager.UpdatePerception();
      this.Yandere.Numbness += 0.5f;
      this.Candle.Suspicious = true;
    }
    else
    {
      if (this.Yandere.Club == ClubType.Art)
        return;
      if (this.Yandere.Club == ClubType.LightMusic)
      {
        this.Container.enabled = false;
        this.Container.Prompt.Hide();
        this.Container.Prompt.enabled = false;
      }
      else
      {
        if (this.Yandere.Club == ClubType.MartialArts)
          return;
        if (this.Yandere.Club == ClubType.Photography)
        {
          if (!this.StudentManager.Eighties)
            return;
          this.Viewfinder.SetActive(false);
        }
        else if (this.Yandere.Club == ClubType.Science)
        {
          this.EmergencyShower.Prompt.enabled = false;
          this.AcidVats[1].Prompt.enabled = false;
          this.AcidVats[2].Prompt.enabled = false;
          this.BloodCleaner.enabled = false;
          this.BloodCleaner.Prompt.Hide();
          this.BloodCleaner.Prompt.enabled = false;
        }
        else if (this.Yandere.Club == ClubType.Sports)
        {
          --this.Yandere.RunSpeed;
          if (!this.Yandere.Armed)
            return;
          this.Yandere.Club = ClubType.None;
          this.Yandere.EquippedWeapon.SuspicionCheck();
        }
        else if (this.Yandere.Club == ClubType.Gardening)
        {
          if (!this.Yandere.Inventory.ShedKey)
          {
            this.ShedDoor.Prompt.Label[0].text = "     Locked";
            this.Padlock.SetActive(true);
            this.ShedDoor.Locked = true;
            this.ShedDoor.CloseDoor();
          }
          if (!this.Yandere.Armed)
            return;
          this.Yandere.Club = ClubType.None;
          this.Yandere.EquippedWeapon.SuspicionCheck();
        }
        else if (this.Yandere.Club == ClubType.Gaming)
        {
          this.ComputerGames.DeactivateAllBenefits();
          this.ComputerGames.DisableGames();
        }
        else
        {
          if (this.Yandere.Club != ClubType.Newspaper)
            return;
          this.Typewriter.Prompt.enabled = false;
          this.Typewriter.enabled = false;
          this.Typewriter.Prompt.Hide();
        }
      }
    }
  }

  public void UpdateMasks()
  {
    bool flag = (Object) this.Yandere.Mask != (Object) null;
    for (this.ID = 1; this.ID < this.Masks.Length; ++this.ID)
      this.Masks[this.ID].Prompt.HideButton[0] = flag;
  }

  public void UpdateQuitClubs()
  {
    for (this.ID = 1; this.ID < this.ClubArray.Length; ++this.ID)
    {
      if (this.QuitClub[this.ID])
      {
        Debug.Log((object) "Because we quit a club, ActivitiesAttended is now being set to 0.");
        ClubGlobals.SetQuitClub(this.ClubArray[this.ID], true);
        this.ActivitiesAttended = 0;
      }
    }
  }

  public void LearnKickedClubs()
  {
    for (this.ID = 1; this.ID < this.ClubArray.Length; ++this.ID)
    {
      if (ClubGlobals.GetClubKicked(this.ClubArray[this.ID]))
      {
        Debug.Log((object) "Because we were kicked from a club, ClubManager.ClubsKickedFrom is being updated.");
        this.ClubsKickedFrom[this.ID] = true;
      }
    }
  }

  public void UpdateKickedClubs()
  {
    for (this.ID = 1; this.ID < this.ClubArray.Length; ++this.ID)
    {
      if (this.ClubsKickedFrom[this.ID])
      {
        Debug.Log((object) "Because we were kicked from a club, ClubGlobals.SetClubKicked is being updated.");
        ClubGlobals.SetClubKicked(this.ClubArray[this.ID], true);
      }
    }
  }
}
