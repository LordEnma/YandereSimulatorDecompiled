// Decompiled with JetBrains decompiler
// Type: DebugMenuScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugMenuScript : MonoBehaviour
{
  public FakeStudentSpawnerScript FakeStudentSpawner;
  public DelinquentManagerScript DelinquentManager;
  public StudentManagerScript StudentManager;
  public CameraEffectsScript CameraEffects;
  public WeaponManagerScript WeaponManager;
  public ReputationScript Reputation;
  public CounselorScript Counselor;
  public DebugConsole DebugConsole;
  public YandereScript Yandere;
  public BentoScript Bento;
  public ClockScript Clock;
  public PrayScript Turtle;
  public ZoomScript Zoom;
  public AstarPath Astar;
  public OsanaFridayBeforeClassEvent1Script OsanaEvent1;
  public OsanaFridayBeforeClassEvent2Script OsanaEvent2;
  public OsanaFridayLunchEventScript OsanaEvent3;
  public GameObject EasterEggWindow;
  public GameObject SacrificialArm;
  public GameObject DebugPoisons;
  public GameObject CircularSaw;
  public GameObject GreenScreen;
  public GameObject Knife;
  public Transform[] TeleportSpot;
  public Transform RooftopSpot;
  public Transform MidoriSpot;
  public Transform Lockers;
  public GameObject MissionModeWindow;
  public GameObject Window;
  public GameObject[] ElectrocutionKit;
  public bool WaitingForNumber;
  public bool TryNextFrame;
  public bool MissionMode;
  public bool NoDebug;
  public int KidnappedVictim = 11;
  public int RooftopStudent = 7;
  public int DebugInputs;
  public float Timer;
  public int ID;
  public Texture PantyCensorTexture;
  private int DebugInt;
  public GameObject Mop;

  private void Start()
  {
    this.transform.localPosition = new Vector3(this.transform.localPosition.x, 0.0f, this.transform.localPosition.z);
    this.MissionModeWindow.SetActive(false);
    this.Window.SetActive(false);
    this.MissionMode = true;
    this.NoDebug = true;
  }

  private void Update()
  {
    if (!this.MissionMode && !this.NoDebug)
    {
      if (!this.Yandere.InClass && !this.Yandere.Chased && this.Yandere.Chasers == 0 && this.Yandere.CanMove)
      {
        if (Input.GetKeyDown(KeyCode.Backslash) && (double) this.Yandere.transform.position.y < 100.0)
        {
          this.EasterEggWindow.SetActive(false);
          this.Window.SetActive(!this.Window.activeInHierarchy);
        }
      }
      else if (this.Window.activeInHierarchy)
        this.Window.SetActive(false);
      if (this.Window.activeInHierarchy)
      {
        if (Input.GetKeyDown(KeyCode.F1))
        {
          StudentGlobals.FemaleUniform = 1;
          StudentGlobals.MaleUniform = 1;
          SceneManager.LoadScene("LoadingScene");
        }
        else if (Input.GetKeyDown(KeyCode.F2))
        {
          StudentGlobals.FemaleUniform = 2;
          StudentGlobals.MaleUniform = 2;
          SceneManager.LoadScene("LoadingScene");
        }
        else if (Input.GetKeyDown(KeyCode.F3))
        {
          StudentGlobals.FemaleUniform = 3;
          StudentGlobals.MaleUniform = 3;
          SceneManager.LoadScene("LoadingScene");
        }
        else if (Input.GetKeyDown(KeyCode.F4))
        {
          StudentGlobals.FemaleUniform = 4;
          StudentGlobals.MaleUniform = 4;
          SceneManager.LoadScene("LoadingScene");
        }
        else if (Input.GetKeyDown(KeyCode.F5))
        {
          StudentGlobals.FemaleUniform = 5;
          StudentGlobals.MaleUniform = 5;
          SceneManager.LoadScene("LoadingScene");
        }
        else if (Input.GetKeyDown(KeyCode.F6))
        {
          StudentGlobals.FemaleUniform = 6;
          StudentGlobals.MaleUniform = 6;
          SceneManager.LoadScene("LoadingScene");
        }
        else if (Input.GetKeyDown(KeyCode.F7))
        {
          for (this.ID = 1; this.ID < 8; ++this.ID)
          {
            this.StudentManager.DrinkingFountains[this.ID].PowerSwitch.PowerOutlet.SabotagedOutlet.SetActive(true);
            this.StudentManager.DrinkingFountains[this.ID].Puddle.SetActive(true);
          }
          this.Window.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.F8))
        {
          GameGlobals.CensorBlood = !GameGlobals.CensorBlood;
          this.WeaponManager.ChangeBloodTexture();
          this.Yandere.Bloodiness += 0.0f;
          this.Window.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.F9))
        {
          GameGlobals.CensorKillingAnims = !GameGlobals.CensorKillingAnims;
          this.Yandere.AttackManager.Censor = !this.Yandere.AttackManager.Censor;
          this.Window.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.F10))
        {
          this.StudentManager.Students[21].Attempts = 101;
          this.StudentManager.Students[22].Attempts = 101;
          this.StudentManager.Students[23].Attempts = 101;
          this.StudentManager.Students[24].Attempts = 101;
          this.StudentManager.Students[25].Attempts = 101;
          this.Window.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.F11))
        {
          DatingGlobals.RivalSabotaged = 5;
          DateGlobals.Weekday = DayOfWeek.Friday;
          SceneManager.LoadScene("LoadingScene");
        }
        else if (!Input.GetKeyDown(KeyCode.F12))
        {
          if (Input.GetKeyDown(KeyCode.Alpha1))
          {
            DateGlobals.Weekday = DayOfWeek.Monday;
            SceneManager.LoadScene("LoadingScene");
          }
          else if (Input.GetKeyDown(KeyCode.Alpha2))
          {
            DateGlobals.Weekday = DayOfWeek.Tuesday;
            SceneManager.LoadScene("LoadingScene");
          }
          else if (Input.GetKeyDown(KeyCode.Alpha3))
          {
            DateGlobals.Weekday = DayOfWeek.Wednesday;
            SceneManager.LoadScene("LoadingScene");
          }
          else if (Input.GetKeyDown(KeyCode.Alpha4))
          {
            DateGlobals.Weekday = DayOfWeek.Thursday;
            SceneManager.LoadScene("LoadingScene");
          }
          else if (Input.GetKeyDown(KeyCode.Alpha5))
          {
            DateGlobals.Weekday = DayOfWeek.Friday;
            SceneManager.LoadScene("LoadingScene");
          }
          else if (Input.GetKeyDown(KeyCode.Alpha6))
          {
            this.Yandere.DebugTimer = 1f;
            this.Yandere.transform.position = this.TeleportSpot[1].position;
            if (this.Yandere.Followers > 0)
              this.Yandere.Follower.transform.position = this.Yandere.transform.position;
            Physics.SyncTransforms();
            this.Window.SetActive(false);
          }
          else if (Input.GetKeyDown(KeyCode.Alpha7))
          {
            this.Yandere.transform.position = this.TeleportSpot[2].position + new Vector3(0.75f, 0.0f, 0.0f);
            if (this.Yandere.Followers > 0)
              this.Yandere.Follower.transform.position = this.Yandere.transform.position;
            Physics.SyncTransforms();
            this.Window.SetActive(false);
          }
          else if (Input.GetKeyDown(KeyCode.Alpha8))
          {
            this.Yandere.transform.position = this.TeleportSpot[3].position;
            if (this.Yandere.Followers > 0)
              this.Yandere.Follower.transform.position = this.Yandere.transform.position;
            Physics.SyncTransforms();
            this.Window.SetActive(false);
          }
          else if (Input.GetKeyDown(KeyCode.Alpha9))
          {
            this.Yandere.transform.position = this.TeleportSpot[4].position;
            if (this.Yandere.Followers > 0)
              this.Yandere.Follower.transform.position = this.Yandere.transform.position;
            StudentScript student = this.StudentManager.Students[39];
            if ((UnityEngine.Object) student != (UnityEngine.Object) null)
            {
              student.ShoeRemoval.Start();
              student.ShoeRemoval.PutOnShoes();
              student.Phase = 2;
              student.ScheduleBlocks[2].action = "Stand";
              student.GetDestinations();
              student.CurrentDestination = this.MidoriSpot;
              student.Pathfinding.target = this.MidoriSpot;
              student.transform.position = this.MidoriSpot.position;
            }
            this.Window.SetActive(false);
            Physics.SyncTransforms();
          }
          else if (Input.GetKeyDown(KeyCode.Alpha0))
          {
            this.Yandere.transform.position = this.TeleportSpot[11].position;
            if (this.Yandere.Followers > 0)
              this.Yandere.Follower.transform.position = this.Yandere.transform.position;
            this.Window.SetActive(false);
            Physics.SyncTransforms();
          }
          else if (Input.GetKeyDown(KeyCode.A))
          {
            switch (SchoolAtmosphere.Type)
            {
              case SchoolAtmosphereType.High:
                SchoolGlobals.SchoolAtmosphere = 0.5f;
                break;
              case SchoolAtmosphereType.Medium:
                SchoolGlobals.SchoolAtmosphere = 0.0f;
                break;
              default:
                SchoolGlobals.SchoolAtmosphere = 1f;
                break;
            }
            SchoolGlobals.PreviousSchoolAtmosphere = SchoolGlobals.SchoolAtmosphere;
            SceneManager.LoadScene("LoadingScene");
          }
          else if (Input.GetKeyDown(KeyCode.C))
          {
            for (this.ID = 1; this.ID < 11; ++this.ID)
            {
              CollectibleGlobals.SetTapeCollected(this.ID, true);
              this.StudentManager.TapesCollected[this.ID] = true;
            }
            this.Window.SetActive(false);
          }
          else if (Input.GetKeyDown(KeyCode.D))
          {
            for (this.ID = 0; this.ID < 5; ++this.ID)
            {
              StudentScript student = this.StudentManager.Students[76 + this.ID];
              if ((UnityEngine.Object) student != (UnityEngine.Object) null)
              {
                if (student.Phase < 2)
                {
                  student.ShoeRemoval.Start();
                  student.ShoeRemoval.PutOnShoes();
                  student.Phase = 2;
                  student.CurrentDestination = student.Destinations[2];
                  student.Pathfinding.target = student.Destinations[2];
                }
                student.transform.position = student.Destinations[2].position;
              }
            }
            Physics.SyncTransforms();
            this.Window.SetActive(false);
            CounselorGlobals.CounselorTape = 1;
            CounselorGlobals.DelinquentPunishments = 5;
          }
          else if (Input.GetKeyDown(KeyCode.F))
          {
            this.GreenScreen.SetActive(true);
            this.Window.SetActive(false);
          }
          else if (Input.GetKeyDown(KeyCode.G))
          {
            StudentScript student = this.StudentManager.Students[this.RooftopStudent];
            if ((double) this.Clock.HourTime < 15.0)
            {
              PlayerGlobals.SetStudentFriend(this.RooftopStudent, true);
              this.StudentManager.Students[this.RooftopStudent].Friend = true;
              this.Yandere.transform.position = this.RooftopSpot.position + new Vector3(1f, 0.0f, 0.0f);
              this.WeaponManager.Weapons[6].transform.position = this.Yandere.transform.position + new Vector3(0.0f, 0.0f, 1.915f);
              if ((UnityEngine.Object) student != (UnityEngine.Object) null)
              {
                this.StudentManager.OsanaOfferHelp.UpdateLocation();
                this.StudentManager.OsanaOfferHelp.enabled = true;
                this.StudentManager.NoteWindow.MeetID = 9;
                if (!student.Indoors)
                {
                  if ((UnityEngine.Object) student.ShoeRemoval.Locker == (UnityEngine.Object) null)
                    student.ShoeRemoval.Start();
                  student.ShoeRemoval.PutOnShoes();
                }
                student.CharacterAnimation.Play(student.IdleAnim);
                student.transform.position = this.RooftopSpot.position;
                student.transform.rotation = this.RooftopSpot.rotation;
                student.Prompt.Label[0].text = "     Push";
                student.CurrentDestination = this.RooftopSpot;
                student.Pathfinding.target = this.RooftopSpot;
                student.Pathfinding.canSearch = false;
                student.Pathfinding.canMove = false;
                student.SpeechLines.Stop();
                student.Pushable = true;
                student.Routine = false;
                student.Meeting = true;
                student.MeetTime = 0.0f;
              }
              if ((double) this.Clock.HourTime < 7.09999990463257)
                this.Clock.PresentTime = 426f;
            }
            else
            {
              this.Clock.PresentTime = 960f;
              student.transform.position = this.Lockers.position;
            }
            Physics.SyncTransforms();
            this.Window.SetActive(false);
          }
          else if (Input.GetKeyDown(KeyCode.K))
          {
            StudentGlobals.Prisoner1 = this.KidnappedVictim;
            StudentGlobals.StudentSlave = this.KidnappedVictim;
            SceneManager.LoadScene("LoadingScene");
          }
          else if (Input.GetKeyDown(KeyCode.L))
          {
            DatingGlobals.Affection = 100f;
            DateGlobals.Weekday = DayOfWeek.Friday;
            SceneManager.LoadScene("LoadingScene");
          }
          else if (Input.GetKeyDown(KeyCode.M))
          {
            PlayerGlobals.Money = 100f;
            this.Yandere.Inventory.Money = 100f;
            this.Yandere.Inventory.UpdateMoney();
            this.Window.SetActive(false);
          }
          else if (Input.GetKeyDown(KeyCode.O))
          {
            this.Yandere.Inventory.RivalPhone = true;
            this.Window.SetActive(false);
          }
          else if (Input.GetKeyDown(KeyCode.P))
          {
            for (this.ID = 2; this.ID < 93; ++this.ID)
            {
              StudentScript student = this.StudentManager.Students[this.ID];
              if ((UnityEngine.Object) student != (UnityEngine.Object) null)
              {
                student.Patience = 999;
                student.Pestered = -999;
                student.Ignoring = false;
              }
            }
            this.Yandere.Inventory.PantyShots += 20;
            PlayerGlobals.PantyShots += 20;
            this.Window.SetActive(false);
          }
          else if (Input.GetKeyDown(KeyCode.Q))
          {
            this.Censor();
            this.Window.SetActive(false);
          }
          else if (Input.GetKeyDown(KeyCode.R))
          {
            Debug.Log((object) "Attempting to update reputation.");
            PlayerGlobals.Reputation = (double) PlayerGlobals.Reputation != -100.0 ? ((double) PlayerGlobals.Reputation != -66.6666564941406 ? ((double) PlayerGlobals.Reputation != 0.0 ? ((double) PlayerGlobals.Reputation != 66.6666564941406 ? ((double) PlayerGlobals.Reputation != 100.0 ? 0.0f : -100f) : 100f) : 66.66666f) : 0.0f) : -66.66666f;
            this.Reputation.PreviousRep = 999f;
            this.Reputation.PendingRep = PlayerGlobals.Reputation;
            this.Reputation.UpdateRep();
            this.Window.SetActive(false);
          }
          else if (Input.GetKeyDown(KeyCode.S))
          {
            this.Yandere.Class.PhysicalGrade = 5;
            this.Yandere.Class.Seduction = 5;
            this.StudentManager.Police.UpdateCorpses();
            for (this.ID = 1; this.ID < 101; ++this.ID)
            {
              StudentGlobals.SetStudentPhotographed(this.ID, true);
              if ((UnityEngine.Object) this.StudentManager.Students[this.ID] != (UnityEngine.Object) null)
                this.StudentManager.Students[this.ID].Friend = true;
            }
            this.Window.SetActive(false);
          }
          else if (Input.GetKeyDown(KeyCode.T))
          {
            this.Zoom.OverShoulder = !this.Zoom.OverShoulder;
            this.Window.SetActive(false);
          }
          else if (Input.GetKeyDown(KeyCode.U))
          {
            PlayerGlobals.SetStudentFriend(this.StudentManager.SuitorID, true);
            PlayerGlobals.SetStudentFriend(this.StudentManager.RivalID, true);
            this.StudentManager.Students[this.StudentManager.SuitorID].Friend = true;
            this.StudentManager.Students[this.StudentManager.RivalID].Friend = true;
            for (this.ID = 1; this.ID < 26; ++this.ID)
            {
              ConversationGlobals.SetTopicLearnedByStudent(this.ID, this.StudentManager.RivalID, true);
              ConversationGlobals.SetTopicDiscovered(this.ID, true);
            }
            this.Window.SetActive(false);
          }
          else if (Input.GetKeyDown(KeyCode.Z))
          {
            this.Yandere.Police.Invalid = true;
            if (Input.GetKey(KeyCode.LeftShift))
            {
              for (this.ID = 2; this.ID < 93; ++this.ID)
              {
                int num = (UnityEngine.Object) this.StudentManager.Students[this.ID] != (UnityEngine.Object) null ? 1 : 0;
              }
            }
            else
            {
              Debug.Log((object) "Killing all students now.");
              for (this.ID = 2; this.ID < 101; ++this.ID)
              {
                StudentScript student = this.StudentManager.Students[this.ID];
                if ((UnityEngine.Object) student != (UnityEngine.Object) null)
                {
                  student.SpawnAlarmDisc();
                  student.BecomeRagdoll();
                  student.DeathType = DeathType.EasterEgg;
                }
              }
            }
            this.Window.SetActive(false);
          }
          else if (Input.GetKeyDown(KeyCode.X))
          {
            TaskGlobals.SetTaskStatus(36, 3);
            SchoolGlobals.ReactedToGameLeader = false;
            SceneManager.LoadScene("LoadingScene");
          }
          else if (Input.GetKeyDown(KeyCode.Backspace))
          {
            Time.timeScale = 1f;
            this.Clock.PresentTime = 1079f;
            this.Clock.HourTime = this.Clock.PresentTime / 60f;
            this.Window.SetActive(false);
          }
          else if (Input.GetKeyDown(KeyCode.BackQuote))
          {
            bool debug = GameGlobals.Debug;
            int num = GameGlobals.Eighties ? 1 : 0;
            Globals.DeleteAll();
            GameGlobals.Debug = debug;
            GameGlobals.Eighties = num != 0;
            StudentGlobals.FemaleUniform = 6;
            StudentGlobals.MaleUniform = 6;
            for (int studentID = 1; studentID < 101; ++studentID)
              StudentGlobals.SetStudentPhotographed(studentID, true);
            SceneManager.LoadScene("LoadingScene");
          }
          else if (Input.GetKeyDown(KeyCode.Space))
          {
            this.Yandere.transform.position = this.TeleportSpot[5].position;
            if ((UnityEngine.Object) this.Yandere.Follower != (UnityEngine.Object) null)
              this.Yandere.Follower.transform.position = this.Yandere.transform.position;
            for (int index = 46; index < 51; ++index)
            {
              if ((UnityEngine.Object) this.StudentManager.Students[index] != (UnityEngine.Object) null)
              {
                this.StudentManager.Students[index].transform.position = this.TeleportSpot[5].position;
                if (!this.StudentManager.Students[index].Indoors)
                {
                  if ((UnityEngine.Object) this.StudentManager.Students[index].ShoeRemoval.Locker == (UnityEngine.Object) null)
                    this.StudentManager.Students[index].ShoeRemoval.Start();
                  this.StudentManager.Students[index].ShoeRemoval.PutOnShoes();
                }
              }
            }
            this.Clock.PresentTime = 1015f;
            this.Clock.HourTime = this.Clock.PresentTime / 60f;
            this.Window.SetActive(false);
            this.OsanaEvent1.enabled = false;
            this.OsanaEvent2.enabled = false;
            this.OsanaEvent3.enabled = false;
            Physics.SyncTransforms();
          }
          else if (Input.GetKeyDown(KeyCode.LeftAlt))
          {
            this.Turtle.SpawnWeapons();
            this.Yandere.transform.position = this.TeleportSpot[6].position;
            if ((UnityEngine.Object) this.Yandere.Follower != (UnityEngine.Object) null)
              this.Yandere.Follower.transform.position = this.Yandere.transform.position;
            this.Clock.PresentTime = 425f;
            this.Clock.HourTime = this.Clock.PresentTime / 60f;
            Physics.SyncTransforms();
            this.Window.SetActive(false);
          }
          else if (Input.GetKeyDown(KeyCode.LeftControl))
          {
            this.Yandere.transform.position = this.TeleportSpot[7].position;
            if ((UnityEngine.Object) this.Yandere.Follower != (UnityEngine.Object) null)
              this.Yandere.Follower.transform.position = this.Yandere.transform.position;
            Physics.SyncTransforms();
            this.Window.SetActive(false);
          }
          else if (Input.GetKeyDown(KeyCode.RightControl))
          {
            this.Yandere.transform.position = this.TeleportSpot[8].position;
            if ((UnityEngine.Object) this.Yandere.Follower != (UnityEngine.Object) null)
              this.Yandere.Follower.transform.position = this.Yandere.transform.position;
            Physics.SyncTransforms();
            this.Window.SetActive(false);
          }
          else if (Input.GetKeyDown(KeyCode.Equals))
          {
            this.Clock.PresentTime += 10f;
            this.Window.SetActive(false);
          }
          else if (!Input.GetKeyDown(KeyCode.Return))
          {
            if (Input.GetKeyDown(KeyCode.B))
            {
              this.Yandere.Inventory.Headset = true;
              this.StudentManager.LoveManager.SuitorProgress = 1;
              DatingGlobals.SuitorProgress = 1;
              PlayerGlobals.SetStudentFriend(6, true);
              PlayerGlobals.SetStudentFriend(11, true);
              this.StudentManager.Students[6].Friend = true;
              this.StudentManager.Students[11].Friend = true;
              for (int complimentID = 0; complimentID < 11; ++complimentID)
                DatingGlobals.SetComplimentGiven(complimentID, false);
              for (this.ID = 1; this.ID < 26; ++this.ID)
              {
                ConversationGlobals.SetTopicLearnedByStudent(this.ID, 11, true);
                ConversationGlobals.SetTopicDiscovered(this.ID, true);
              }
              StudentScript student1 = this.StudentManager.Students[11];
              if ((UnityEngine.Object) student1 != (UnityEngine.Object) null)
              {
                student1.ShoeRemoval.Start();
                student1.ShoeRemoval.PutOnShoes();
                student1.CanTalk = true;
                student1.Phase = 2;
                student1.Pestered = 0;
                student1.Patience = 999;
                student1.Ignoring = false;
                student1.CurrentDestination = student1.Destinations[2];
                student1.Pathfinding.target = student1.Destinations[2];
                student1.transform.position = student1.Destinations[2].position;
              }
              StudentScript student2 = this.StudentManager.Students[6];
              if ((UnityEngine.Object) student2 != (UnityEngine.Object) null)
              {
                student2.ShoeRemoval.Start();
                student2.ShoeRemoval.PutOnShoes();
                student2.Phase = 2;
                student2.Pestered = 0;
                student2.Patience = 999;
                student2.Ignoring = false;
                student2.CurrentDestination = student2.Destinations[2];
                student2.Pathfinding.target = student2.Destinations[2];
                student2.transform.position = student2.Destinations[2].position;
              }
              StudentScript student3 = this.StudentManager.Students[10];
              if ((UnityEngine.Object) student2 != (UnityEngine.Object) null)
                student2.transform.position = student1.transform.position;
              CollectibleGlobals.SetGiftPurchased(6, true);
              CollectibleGlobals.SetGiftPurchased(7, true);
              CollectibleGlobals.SetGiftPurchased(8, true);
              CollectibleGlobals.SetGiftPurchased(9, true);
              Physics.SyncTransforms();
              this.Window.SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.Pause))
            {
              this.Clock.StopTime = !this.Clock.StopTime;
              this.Window.SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
              ++DateGlobals.Week;
              SceneManager.LoadScene("LoadingScene");
            }
            else if (Input.GetKeyDown(KeyCode.H))
            {
              StudentGlobals.FragileSlave = 5;
              StudentGlobals.FragileTarget = 10;
              StudentGlobals.Prisoner1 = this.KidnappedVictim;
              StudentGlobals.StudentSlave = this.KidnappedVictim;
              SceneManager.LoadScene("LoadingScene");
            }
            else if (Input.GetKeyDown(KeyCode.I))
            {
              this.StudentManager.Students[3].BecomeRagdoll();
              this.WeaponManager.Weapons[1].Blood.enabled = true;
              this.WeaponManager.Weapons[1].FingerprintID = 2;
              this.WeaponManager.Weapons[1].Victims[3] = true;
              this.StudentManager.Students[5].BecomeRagdoll();
              this.WeaponManager.Weapons[2].Blood.enabled = true;
              this.WeaponManager.Weapons[2].FingerprintID = 4;
              this.WeaponManager.Weapons[2].Victims[5] = true;
            }
            else if (!Input.GetKeyDown(KeyCode.J) && !Input.GetKeyDown(KeyCode.V) && Input.GetKeyDown(KeyCode.N))
            {
              this.ElectrocutionKit[0].transform.position = this.Yandere.transform.position;
              this.ElectrocutionKit[1].transform.position = this.Yandere.transform.position;
              this.ElectrocutionKit[2].transform.position = this.Yandere.transform.position;
              this.ElectrocutionKit[3].transform.position = this.Yandere.transform.position;
              this.ElectrocutionKit[3].SetActive(true);
            }
          }
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
          DatingGlobals.SuitorProgress = 2;
          SceneManager.LoadScene("LoadingScene");
        }
        if (Input.GetKeyDown(KeyCode.CapsLock))
          this.StudentManager.LoveManager.ConfessToSuitor = true;
      }
      else
      {
        if (Input.GetKey(KeyCode.BackQuote))
        {
          this.Timer += Time.deltaTime;
          if ((double) this.Timer > 1.0)
          {
            for (this.ID = 0; this.ID < this.StudentManager.NPCsTotal; ++this.ID)
            {
              if (StudentGlobals.GetStudentDying(this.ID))
                StudentGlobals.SetStudentDying(this.ID, false);
            }
            SceneManager.LoadScene("LoadingScene");
          }
        }
        if (Input.GetKeyUp(KeyCode.BackQuote))
          this.Timer = 0.0f;
      }
      if (this.TryNextFrame)
        this.UpdateCensor();
    }
    else
      Input.GetKeyDown(KeyCode.Backslash);
    if (!this.WaitingForNumber)
      return;
    if (Input.GetKey("1"))
    {
      Debug.Log((object) "Going to class should trigger panty shot lecture.");
      if (!this.StudentManager.Eighties)
        SchemeGlobals.SetSchemeStage(1, 100);
      StudentGlobals.ExpelProgress = 0;
      this.Counselor.CutsceneManager.Scheme = 1;
      this.Counselor.LectureID = 1;
      this.WaitingForNumber = false;
    }
    else if (Input.GetKey("2"))
    {
      Debug.Log((object) "Going to class should trigger theft lecture.");
      if (!this.StudentManager.Eighties)
        SchemeGlobals.SetSchemeStage(2, 100);
      StudentGlobals.ExpelProgress = 1;
      this.Counselor.CutsceneManager.Scheme = 2;
      this.Counselor.LectureID = 2;
      this.WaitingForNumber = false;
    }
    else if (Input.GetKey("3"))
    {
      Debug.Log((object) "Going to class should trigger contraband lecture.");
      if (!this.StudentManager.Eighties)
        SchemeGlobals.SetSchemeStage(3, 100);
      StudentGlobals.ExpelProgress = 2;
      this.Counselor.CutsceneManager.Scheme = 3;
      this.Counselor.LectureID = 3;
      this.WaitingForNumber = false;
    }
    else if (Input.GetKey("4"))
    {
      Debug.Log((object) "Going to class should trigger Vandalism lecture.");
      if (!this.StudentManager.Eighties)
        SchemeGlobals.SetSchemeStage(4, 100);
      StudentGlobals.ExpelProgress = 3;
      this.Counselor.CutsceneManager.Scheme = 4;
      this.Counselor.LectureID = 4;
      this.WaitingForNumber = false;
    }
    else
    {
      if (!Input.GetKey("5"))
        return;
      Debug.Log((object) "Going to class at lunchtime should get your rival expelled!");
      if (!this.StudentManager.Eighties)
        SchemeGlobals.SetSchemeStage(5, 100);
      this.Counselor.RivalExpelProgress = 4;
      StudentGlobals.ExpelProgress = 4;
      this.Counselor.CutsceneManager.Scheme = 5;
      this.Counselor.LectureID = 5;
      this.WaitingForNumber = false;
    }
  }

  public void Censor()
  {
    if (GameGlobals.CensorPanties)
    {
      if (this.Yandere.Schoolwear == 1)
      {
        if (!this.Yandere.Sans && !this.Yandere.SithLord && !this.Yandere.BanchoActive)
        {
          if (!this.Yandere.FlameDemonic && !this.Yandere.TornadoHair.activeInHierarchy)
          {
            this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount1", 1f);
            this.Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount1", 1f);
            this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount", 1f);
            this.Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount", 1f);
            if ((UnityEngine.Object) this.Yandere.PantyAttacher.newRenderer != (UnityEngine.Object) null)
              this.Yandere.PantyAttacher.newRenderer.enabled = false;
          }
          else
          {
            Debug.Log((object) "This block of code activated a shadow.");
            this.Yandere.MyRenderer.materials[2].SetTexture("_OverlayTex", this.PantyCensorTexture);
            this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
            this.Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
            this.Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount", 1f);
          }
        }
        else
          this.Yandere.PantyAttacher.newRenderer.enabled = false;
      }
      if (this.Yandere.MiyukiCostume.activeInHierarchy || this.Yandere.Rain.activeInHierarchy)
      {
        this.Yandere.PantyAttacher.newRenderer.enabled = false;
        this.Yandere.MyRenderer.materials[1].SetTexture("_OverlayTex", this.PantyCensorTexture);
        this.Yandere.MyRenderer.materials[2].SetTexture("_OverlayTex", this.PantyCensorTexture);
        this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0.0f);
        this.Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount1", 1f);
        this.Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount1", 1f);
      }
      if (this.Yandere.NierCostume.activeInHierarchy || (UnityEngine.Object) this.Yandere.MyRenderer.sharedMesh == (UnityEngine.Object) this.Yandere.NudeMesh || (UnityEngine.Object) this.Yandere.MyRenderer.sharedMesh == (UnityEngine.Object) this.Yandere.SchoolSwimsuit || this.Yandere.WearingRaincoat)
        this.EasterEggCheck();
      this.StudentManager.CensorStudents();
    }
    else
    {
      Debug.Log((object) "The panty censor is turning OFF.");
      this.Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount1", 0.0f);
      this.Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
      this.Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount", 0.0f);
      if ((UnityEngine.Object) this.Yandere.MyRenderer.sharedMesh != (UnityEngine.Object) this.Yandere.NudeMesh && (UnityEngine.Object) this.Yandere.MyRenderer.sharedMesh != (UnityEngine.Object) this.Yandere.SchoolSwimsuit)
      {
        this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0.0f);
        this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
        this.Yandere.PantyAttacher.newRenderer.enabled = true;
        if ((UnityEngine.Object) this.Yandere.MyRenderer.sharedMesh == (UnityEngine.Object) this.Yandere.Uniforms[2])
        {
          Debug.Log((object) "Long-sleeved school uniform. Changing which variable get set to 0.");
          this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0.0f);
        }
        this.EasterEggCheck();
      }
      else
      {
        this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0.0f);
        this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
        this.Yandere.PantyAttacher.newRenderer.enabled = false;
        this.EasterEggCheck();
      }
      if (this.Yandere.MiyukiCostume.activeInHierarchy)
        this.Yandere.PantyAttacher.newRenderer.enabled = false;
      this.StudentManager.CensorStudents();
    }
  }

  public void EasterEggCheck()
  {
    Debug.Log((object) "Checking for easter eggs.");
    if (this.Yandere.BanchoActive || this.Yandere.Sans || (UnityEngine.Object) this.Yandere.RaincoatAttacher.newRenderer != (UnityEngine.Object) null && this.Yandere.RaincoatAttacher.newRenderer.enabled || this.Yandere.KLKSword.activeInHierarchy || this.Yandere.Gazing || this.Yandere.Ninja || this.Yandere.ClubAttire || this.Yandere.LifeNotebook.activeInHierarchy || this.Yandere.FalconHelmet.activeInHierarchy || this.Yandere.WearingRaincoat || (UnityEngine.Object) this.Yandere.MyRenderer.sharedMesh == (UnityEngine.Object) this.Yandere.NudeMesh || (UnityEngine.Object) this.Yandere.MyRenderer.sharedMesh == (UnityEngine.Object) this.Yandere.SchoolSwimsuit)
    {
      Debug.Log((object) "A pants-wearing easter egg is active, so we're going to disable all shadows and panties.");
      this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
      this.Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
      this.Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount", 0.0f);
      this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0.0f);
      this.Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount1", 0.0f);
      this.Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount1", 0.0f);
      this.Yandere.PantyAttacher.newRenderer.enabled = false;
    }
    if (this.Yandere.FlameDemonic || this.Yandere.TornadoHair.activeInHierarchy)
    {
      Debug.Log((object) "This other block of code activated a shadow.");
      this.Yandere.MyRenderer.materials[1].SetTexture("_OverlayTex", this.PantyCensorTexture);
      this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
      this.Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount", 1f);
      this.Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount", 0.0f);
      this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0.0f);
      this.Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount1", 0.0f);
      this.Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount1", 0.0f);
    }
    if (!this.Yandere.NierCostume.activeInHierarchy)
      return;
    Debug.Log((object) "Nier costume special case.");
    this.Yandere.PantyAttacher.newRenderer.enabled = false;
    SkinnedMeshRenderer newRenderer = this.Yandere.NierCostume.GetComponent<RiggedAccessoryAttacher>().newRenderer;
    if ((UnityEngine.Object) newRenderer == (UnityEngine.Object) null)
    {
      this.TryNextFrame = true;
    }
    else
    {
      this.TryNextFrame = false;
      if (GameGlobals.CensorPanties)
      {
        newRenderer.materials[0].SetFloat("_BlendAmount", 1f);
        newRenderer.materials[1].SetFloat("_BlendAmount", 1f);
        newRenderer.materials[2].SetFloat("_BlendAmount", 1f);
        newRenderer.materials[3].SetFloat("_BlendAmount", 1f);
      }
      else
      {
        newRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
        newRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
        newRenderer.materials[2].SetFloat("_BlendAmount", 0.0f);
        newRenderer.materials[3].SetFloat("_BlendAmount", 0.0f);
      }
    }
  }

  public void UpdateCensor()
  {
    this.Censor();
    this.Censor();
  }

  public void DebugTest()
  {
    if (this.DebugInt == 0)
    {
      StudentScript student = this.StudentManager.Students[39];
      student.ShoeRemoval.Start();
      student.ShoeRemoval.PutOnShoes();
      student.Phase = 2;
      student.ScheduleBlocks[2].action = "Stand";
      student.GetDestinations();
      student.CurrentDestination = this.MidoriSpot;
      student.Pathfinding.target = this.MidoriSpot;
      student.transform.position = this.Yandere.transform.position;
      Physics.SyncTransforms();
    }
    else if (this.DebugInt == 1)
    {
      this.Knife.transform.position = this.Yandere.transform.position + new Vector3(-1f, 1f, 0.0f);
      this.Knife.GetComponent<Rigidbody>().isKinematic = false;
      this.Knife.GetComponent<Rigidbody>().useGravity = true;
    }
    else if (this.DebugInt == 2)
    {
      this.Mop.transform.position = this.Yandere.transform.position + new Vector3(1f, 1f, 0.0f);
      this.Mop.GetComponent<Rigidbody>().isKinematic = false;
      this.Mop.GetComponent<Rigidbody>().useGravity = true;
    }
    ++this.DebugInt;
  }
}
