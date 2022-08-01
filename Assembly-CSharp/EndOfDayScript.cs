// Decompiled with JetBrains decompiler
// Type: EndOfDayScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfDayScript : MonoBehaviour
{
  public RemovableItemManagerScript RemovableItemManager;
  public SecuritySystemScript SecuritySystem;
  public StudentManagerScript StudentManager;
  public WeaponManagerScript WeaponManager;
  public ClubManagerScript ClubManager;
  public HeartbrokenScript Heartbroken;
  public IncineratorScript Incinerator;
  public LoveManagerScript LoveManager;
  public RummageSpotScript RummageSpot;
  public VoidGoddessScript VoidGoddess;
  public WoodChipperScript WoodChipper;
  public ReputationScript Reputation;
  public DumpsterLidScript Dumpster;
  public CounselorScript Counselor;
  public WeaponScript MurderWeapon;
  public TranqCaseScript TranqCase;
  public AudioListener MyListener;
  public YandereScript Yandere;
  public RagdollScript Corpse;
  public StudentScript Senpai;
  public StudentScript Patsy;
  public PoliceScript Police;
  public Transform EODCamera;
  public StudentScript Rival;
  public ClassScript Class;
  public ClockScript Clock;
  public JsonScript JSON;
  public GardenHoleScript[] GardenHoles;
  public StudentScript[] WitnessList;
  public Animation[] CopAnimation;
  public GameObject MainCamera;
  public UISprite EndOfDayDarkness;
  public UILabel Label;
  public bool RivalDismemberedAndIncinerated;
  public bool RivalBuried;
  public bool CurrentMurderWeaponKilledRival;
  public bool LearnedAboutPhotographer;
  public bool InvolvementNotSuspected;
  public bool ExplosiveDeviceUsed;
  public bool PreviouslyActivated;
  public bool LearnedOsanaInfo1;
  public bool LearnedOsanaInfo2;
  public bool GoToSuicideScene;
  public bool RivalArrested;
  public bool PoliceArrived;
  public bool RaibaruLoner;
  public bool StopMourning;
  public bool ClubClosed;
  public bool ClubKicked;
  public bool ErectFence;
  public bool PoolEvent;
  public bool GameOver;
  public bool Darken;
  public float DistanceToMoveForward;
  public int ClothingWithRedPaint;
  public int ShrineItemsCollected;
  public int WeaponWitnessed;
  public int BloodWitnessed;
  public int FragileTarget;
  public int EyeWitnesses;
  public int NewFriends;
  public int ClubLimit;
  public int DeadPerps;
  public int Arrests;
  public int Corpses;
  public int Victims;
  public int Weapons;
  public int Phase = 1;
  public int MatchmakingGifts;
  public int SenpaiGifts;
  public int ArticleID;
  public int WeaponID;
  public int ArrestID;
  public int ClubID;
  public int ID;
  public string[] ClubNames;
  public int[] VictimArray;
  public ClubType[] ClubArray;
  private SaveFile saveFile;
  public GameObject TextWindow;
  public GameObject Cops;
  public GameObject SearchingCop;
  public GameObject MurderScene;
  public GameObject ShruggingCops;
  public GameObject TabletCop;
  public GameObject SecuritySystemScene;
  public GameObject OpenTranqCase;
  public GameObject ClosedTranqCase;
  public GameObject GaudyRing;
  public GameObject AnswerSheet;
  public GameObject Fence;
  public GameObject SCP;
  public GameObject Headmaster;
  public GameObject ArrestingCops;
  public GameObject Mask;
  public GameObject EyeWitnessScene;
  public GameObject ScaredCops;
  public GameObject EightiesGaudyRing;
  public StudentScript KidnappedVictim;
  public Renderer TabletPortrait;
  public Transform CardboardBox;
  public RivalEliminationType RivalEliminationMethod;
  public Vector3 YandereInitialPosition;
  public Quaternion YandereInitialRotation;
  public bool[] StudentsToArrest;
  public string Protagonist = "Ayano";
  public string RivalName = "";
  public string[] EightiesRivalNames;
  public string[] RivalNames;
  public AudioClip EightiesBGM;
  public string[] VtuberNames;
  public bool WeaponsChecked;

  public void Start()
  {
    Debug.Log((object) "The End-of-Day GameObject has just fired its Start() function.");
    this.VoidGoddess.Start();
    GameGlobals.PoliceYesterday = false;
    this.YandereInitialPosition = this.Yandere.transform.position;
    this.YandereInitialRotation = this.Yandere.transform.rotation;
    if (GameGlobals.SenpaiMourning)
      this.StopMourning = true;
    this.Yandere.MainCamera.gameObject.SetActive(false);
    this.EndOfDayDarkness.color = new Color(this.EndOfDayDarkness.color.r, this.EndOfDayDarkness.color.g, this.EndOfDayDarkness.color.b, 1f);
    this.PreviouslyActivated = true;
    this.GetComponent<AudioSource>().volume = 0.0f;
    this.Clock.enabled = false;
    this.Clock.MainLight.color = new Color(1f, 1f, 1f, 1f);
    RenderSettings.ambientLight = new Color(0.75f, 0.75f, 0.75f, 1f);
    RenderSettings.skybox.SetColor("_Tint", new Color(0.5f, 0.5f, 0.5f));
    this.UpdateScene();
    this.CopAnimation[5]["idleShort_00"].speed = UnityEngine.Random.Range(0.9f, 1.1f);
    this.CopAnimation[6]["idleShort_00"].speed = UnityEngine.Random.Range(0.9f, 1.1f);
    this.CopAnimation[7]["idleShort_00"].speed = UnityEngine.Random.Range(0.9f, 1.1f);
    Time.timeScale = 1f;
    for (int index = 1; index < 6; ++index)
    {
      this.Yandere.CharacterAnimation[this.Yandere.CreepyIdles[index]].weight = 0.0f;
      this.Yandere.CharacterAnimation[this.Yandere.CreepyWalks[index]].weight = 0.0f;
    }
    for (int index = 1; index < this.StudentManager.AllBuckets.Length; ++index)
    {
      if ((UnityEngine.Object) this.StudentManager.AllBuckets[index] != (UnityEngine.Object) null && (double) this.StudentManager.AllBuckets[index].Bloodiness > 50.0)
        this.StudentManager.AllBuckets[index].transform.parent = this.Police.BloodParent;
    }
    this.ClothingWithRedPaint += this.Incinerator.ClothingWithRedPaint;
    foreach (Component component1 in this.Police.BloodParent)
    {
      PickUpScript component2 = component1.gameObject.GetComponent<PickUpScript>();
      if ((UnityEngine.Object) component2 != (UnityEngine.Object) null && component2.RedPaint)
        ++this.ClothingWithRedPaint;
    }
    int num = 0;
    if (this.Police.Corpses > 1)
    {
      foreach (RagdollScript corpse in this.Police.CorpseList)
      {
        if ((UnityEngine.Object) corpse != (UnityEngine.Object) null && (corpse.MurderSuicide || corpse.Student.MurderedByStudent))
          ++num;
      }
    }
    if (num > 1)
      this.Police.MurderSuicideScene = true;
    this.ClubLimit = this.ClubArray.Length;
    if (!GameGlobals.Eighties)
    {
      --this.ClubLimit;
    }
    else
    {
      this.GetComponent<AudioSource>().clip = this.EightiesBGM;
      this.GetComponent<AudioSource>().Play();
    }
    if (!this.Counselor.Lecturing)
    {
      this.EODCamera.localPosition = new Vector3(1f, 1.8f, -2.5f);
      this.EODCamera.localEulerAngles = new Vector3(22.5f, -22.5f, 0.0f);
      this.TextWindow.SetActive(true);
    }
    if (this.Yandere.VtuberID <= 0)
      return;
    this.Protagonist = this.VtuberNames[this.Yandere.VtuberID];
  }

  private void Update()
  {
    this.Yandere.UpdateSlouch();
    if (Input.GetKeyDown("space"))
    {
      this.EndOfDayDarkness.color = new Color(0.0f, 0.0f, 0.0f, 1f);
      this.Darken = true;
    }
    if ((double) this.EndOfDayDarkness.color.a < 1.0 / 1000.0 && Input.GetButtonDown("A"))
      this.Darken = true;
    if (this.Darken)
    {
      this.EndOfDayDarkness.color = new Color(this.EndOfDayDarkness.color.r, this.EndOfDayDarkness.color.g, this.EndOfDayDarkness.color.b, Mathf.MoveTowards(this.EndOfDayDarkness.color.a, 1f, Time.deltaTime * 2f));
      if ((double) this.EndOfDayDarkness.color.a > 0.999000012874603)
      {
        if ((UnityEngine.Object) this.Senpai == (UnityEngine.Object) null && (UnityEngine.Object) this.StudentManager.Students[1] != (UnityEngine.Object) null)
        {
          this.Senpai = this.StudentManager.Students[1];
          this.Senpai.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
          this.Senpai.CharacterAnimation.enabled = true;
        }
        if ((UnityEngine.Object) this.Senpai != (UnityEngine.Object) null)
          this.Senpai.gameObject.SetActive(false);
        if ((UnityEngine.Object) this.Rival == (UnityEngine.Object) null && (UnityEngine.Object) this.StudentManager.Students[this.StudentManager.RivalID] != (UnityEngine.Object) null)
        {
          this.Rival = this.StudentManager.Students[this.StudentManager.RivalID];
          this.Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
          this.Rival.CharacterAnimation.enabled = true;
        }
        if ((UnityEngine.Object) this.Rival != (UnityEngine.Object) null)
          this.Rival.gameObject.SetActive(false);
        this.Yandere.transform.parent = (Transform) null;
        this.Yandere.transform.position = new Vector3(0.0f, 0.0f, -75f);
        this.EODCamera.localPosition = new Vector3(1f, 1.8f, -2.5f);
        this.EODCamera.localEulerAngles = new Vector3(22.5f, -22.5f, 0.0f);
        if ((UnityEngine.Object) this.KidnappedVictim != (UnityEngine.Object) null)
          this.KidnappedVictim.gameObject.SetActive(false);
        if ((UnityEngine.Object) this.StudentManager.Students[this.StudentManager.SuitorID] != (UnityEngine.Object) null)
          this.StudentManager.Students[this.StudentManager.SuitorID].gameObject.SetActive(false);
        this.CardboardBox.parent = (Transform) null;
        this.Yandere.LifeNotePen.SetActive(false);
        this.SearchingCop.SetActive(false);
        this.MurderScene.SetActive(false);
        this.Cops.SetActive(false);
        this.TabletCop.SetActive(false);
        this.ShruggingCops.SetActive(false);
        this.SecuritySystemScene.SetActive(false);
        this.OpenTranqCase.SetActive(false);
        this.ClosedTranqCase.SetActive(false);
        this.GaudyRing.SetActive(false);
        this.AnswerSheet.SetActive(false);
        this.Fence.SetActive(false);
        this.SCP.SetActive(false);
        this.Headmaster.SetActive(false);
        this.ArrestingCops.SetActive(false);
        this.Mask.SetActive(false);
        this.EyeWitnessScene.SetActive(false);
        this.ScaredCops.SetActive(false);
        this.EightiesGaudyRing.SetActive(false);
        if ((UnityEngine.Object) this.WitnessList[1] != (UnityEngine.Object) null)
          this.WitnessList[1].gameObject.SetActive(false);
        if ((UnityEngine.Object) this.WitnessList[2] != (UnityEngine.Object) null)
          this.WitnessList[2].gameObject.SetActive(false);
        if ((UnityEngine.Object) this.WitnessList[3] != (UnityEngine.Object) null)
          this.WitnessList[3].gameObject.SetActive(false);
        if ((UnityEngine.Object) this.WitnessList[4] != (UnityEngine.Object) null)
          this.WitnessList[4].gameObject.SetActive(false);
        if ((UnityEngine.Object) this.WitnessList[5] != (UnityEngine.Object) null)
          this.WitnessList[5].gameObject.SetActive(false);
        if ((UnityEngine.Object) this.Patsy != (UnityEngine.Object) null)
          this.Patsy.gameObject.SetActive(false);
        if (!this.GameOver)
        {
          this.Darken = false;
          this.UpdateScene();
        }
        else
        {
          this.Heartbroken.transform.parent.transform.parent = (Transform) null;
          this.Heartbroken.transform.parent.gameObject.SetActive(true);
          this.Heartbroken.Cursor.HeartbrokenCamera.depth = 6f;
          if (this.Police.Deaths + PlayerGlobals.Kills > 50)
          {
            this.Heartbroken.Noticed = true;
          }
          else
          {
            this.Heartbroken.Noticed = false;
            this.Heartbroken.Arrested = true;
          }
          this.MainCamera.SetActive(false);
          this.gameObject.SetActive(false);
          Time.timeScale = 1f;
        }
        if (this.RivalName == "")
        {
          if (this.StudentManager.Eighties)
          {
            this.Protagonist = "Ryoba";
            this.RivalName = this.EightiesRivalNames[DateGlobals.Week];
          }
          else
            this.RivalName = this.RivalNames[DateGlobals.Week];
        }
        if (this.Yandere.VtuberID > 0)
          this.Protagonist = this.VtuberNames[this.Yandere.VtuberID];
      }
    }
    else
      this.EndOfDayDarkness.color = new Color(this.EndOfDayDarkness.color.r, this.EndOfDayDarkness.color.g, this.EndOfDayDarkness.color.b, Mathf.MoveTowards(this.EndOfDayDarkness.color.a, 0.0f, Time.deltaTime * 2f));
    AudioSource component = this.GetComponent<AudioSource>();
    component.volume = Mathf.MoveTowards(component.volume, 1f, Time.deltaTime * 2f);
    if ((UnityEngine.Object) this.WitnessList[2] != (UnityEngine.Object) null)
      this.WitnessList[2].CharacterAnimation.Play(this.WitnessList[2].IdleAnim);
    if ((UnityEngine.Object) this.WitnessList[3] != (UnityEngine.Object) null)
      this.WitnessList[3].CharacterAnimation.Play(this.WitnessList[3].IdleAnim);
    if ((UnityEngine.Object) this.WitnessList[4] != (UnityEngine.Object) null)
      this.WitnessList[4].CharacterAnimation.Play(this.WitnessList[4].IdleAnim);
    if ((UnityEngine.Object) this.WitnessList[5] != (UnityEngine.Object) null)
      this.WitnessList[5].CharacterAnimation.Play(this.WitnessList[5].IdleAnim);
    if (this.Phase != 17)
      return;
    this.EODCamera.position = this.ClubManager.ClubVantages[this.ClubID].position;
    this.EODCamera.eulerAngles = this.ClubManager.ClubVantages[this.ClubID].eulerAngles;
    this.EODCamera.Translate(Vector3.forward * 0.0f, Space.Self);
  }

  public void UpdateScene()
  {
    this.Label.color = new Color(0.0f, 0.0f, 0.0f, 1f);
    if (!this.PoliceArrived)
      return;
    this.MyListener.enabled = false;
    if (this.Phase != 14)
    {
      for (int index = 0; index < this.Yandere.Weapon.Length; ++index)
      {
        if ((UnityEngine.Object) this.Yandere.Weapon[index] != (UnityEngine.Object) null && this.Yandere.Weapon[index].Bloody)
          this.Yandere.Weapon[index].Drop();
      }
      if (!this.WeaponsChecked)
      {
        Debug.Log((object) "We're counting the number of bloody weapons at school right now...");
        this.WeaponManager.CheckWeapons();
        this.WeaponsChecked = true;
        Debug.Log((object) (this.WeaponManager.MurderWeapons.ToString() + " bloody weapons were found."));
      }
    }
    for (this.ID = 0; this.ID < this.WeaponManager.Weapons.Length; ++this.ID)
    {
      if ((UnityEngine.Object) this.WeaponManager.Weapons[this.ID] != (UnityEngine.Object) null)
        this.WeaponManager.Weapons[this.ID].gameObject.SetActive(false);
    }
    if (Input.GetKeyDown(KeyCode.Backspace))
      this.Finish();
    if (this.Phase == 1)
    {
      Time.timeScale = 1f;
      GameGlobals.PoliceYesterday = true;
      this.CopAnimation[1]["walk_00"].speed = UnityEngine.Random.Range(0.9f, 1.1f);
      this.CopAnimation[2]["walk_00"].speed = UnityEngine.Random.Range(0.9f, 1.1f);
      this.CopAnimation[3]["walk_00"].speed = UnityEngine.Random.Range(0.9f, 1.1f);
      this.Counselor.LectureID = 0;
      this.Cops.SetActive(true);
      bool flag = false;
      if (this.Yandere.Egg && !flag)
      {
        this.Label.text = "The police arrive at school.";
        this.Phase = 999;
      }
      else if (this.Police.PoisonScene)
      {
        this.Label.text = "The police and the paramedics arrive at school.";
        this.Phase = 103;
      }
      else if (this.Police.DrownVictims == 1)
      {
        this.Label.text = "The police arrive at school.";
        this.Phase = 104;
      }
      else if (this.Police.ElectroScene)
      {
        this.Label.text = "The police arrive at school.";
        this.Phase = 105;
      }
      else if (this.Police.MurderSuicideScene)
      {
        this.Label.text = "The police arrive at school, and discover what appears to be the scene of a murder-suicide.";
        ++this.Phase;
      }
      else
      {
        this.Label.text = "The police arrive at school.";
        if (this.Police.SuicideScene)
          this.Phase = 102;
        else
          ++this.Phase;
      }
    }
    else if (this.Phase == 2)
    {
      if (this.Police.Corpses == 0)
      {
        Debug.Log((object) "Zero corpses were present at school.");
        if (!this.Police.PoisonScene && !this.Police.SuicideScene)
        {
          if (this.Police.LimbParent.childCount > 0 || this.Police.GarbageParent.childCount > 0)
          {
            this.Label.text = this.Police.LimbParent.childCount + this.Police.GarbageParent.childCount != 1 ? "The police find multiple severed body parts at school." : "The police find a severed body part at school.";
            this.MurderScene.SetActive(true);
          }
          else
          {
            this.SearchingCop.SetActive(true);
            this.Label.text = this.Police.BloodParent.childCount - this.ClothingWithRedPaint <= 0 ? (this.ClothingWithRedPaint != 0 ? "The police find clothing that is stained with red paint, but are unable to locate any actual blood stains, and cannot locate any corpses, either." : "The police are unable to locate any corpses on school grounds.") : "The police find mysterious blood stains, but are unable to locate any corpses on school grounds.";
          }
          ++this.Phase;
        }
        else
        {
          this.SearchingCop.SetActive(true);
          this.Label.text = "The police are unable to locate any other corpses on school grounds.";
          ++this.Phase;
        }
      }
      else
      {
        Debug.Log((object) "Corpses were present at school.");
        this.MurderScene.SetActive(true);
        List<string> stringList = new List<string>();
        foreach (RagdollScript corpse in this.Police.CorpseList)
        {
          if ((UnityEngine.Object) corpse != (UnityEngine.Object) null && !corpse.Disposed)
          {
            if (corpse.Student.StudentID == this.StudentManager.RivalID)
            {
              Debug.Log((object) "The rival died, and now the game is determining exactly how she died.");
              this.RivalEliminationMethod = RivalEliminationType.Murdered;
              if (corpse.Student.Electrified || corpse.Student.Electrocuted || corpse.Student.DeathType == DeathType.Burning || corpse.Student.DeathType == DeathType.Weight || corpse.Student.DeathType == DeathType.Drowning || corpse.Student.DeathType == DeathType.Poison || corpse.Student.DeathType == DeathType.Explosion)
                this.RivalEliminationMethod = RivalEliminationType.Accident;
              if (corpse.Student.DeathType == DeathType.Burning)
              {
                GameGlobals.SpecificEliminationID = 5;
                if (!GameGlobals.Debug)
                  PlayerPrefs.SetInt("Burn", 1);
              }
              else if (corpse.Student.DeathType == DeathType.Electrocution)
              {
                Debug.Log((object) "The game should now be informing the Content Checklist that the player has performed an electrocution.");
                GameGlobals.SpecificEliminationID = 8;
                if (!GameGlobals.Debug)
                  PlayerPrefs.SetInt("Electrocute", 1);
              }
              else if (corpse.Student.DeathType == DeathType.Weight)
              {
                GameGlobals.SpecificEliminationID = 6;
                if (!GameGlobals.Debug)
                  PlayerPrefs.SetInt("Crush", 1);
              }
              else if (corpse.Student.DeathType == DeathType.Drowning)
              {
                Debug.Log((object) "The rival drowned.");
                if (this.PoolEvent)
                {
                  Debug.Log((object) "The player eliminated the rival during a pool event.");
                  GameGlobals.SpecificEliminationID = 16;
                  if (!GameGlobals.Debug)
                    PlayerPrefs.SetInt("Pool", 1);
                }
                else
                {
                  Debug.Log((object) "The player did not eliminate the rival during a pool event.");
                  GameGlobals.SpecificEliminationID = 7;
                  if (!GameGlobals.Debug)
                    PlayerPrefs.SetInt("Drown", 1);
                }
              }
              else if (corpse.Decapitated)
              {
                GameGlobals.SpecificEliminationID = 10;
                if (!GameGlobals.Debug)
                  PlayerPrefs.SetInt("Fan", 1);
              }
              else if (corpse.Student.DeathType == DeathType.Poison)
              {
                GameGlobals.SpecificEliminationID = 15;
                if (!GameGlobals.Debug)
                  PlayerPrefs.SetInt("Poison", 1);
              }
              else if (corpse.Student.DeathType == DeathType.Falling)
              {
                GameGlobals.SpecificEliminationID = 17;
                if (!GameGlobals.Debug)
                  PlayerPrefs.SetInt("Push", 1);
              }
              else if (corpse.Student.Hunted)
              {
                GameGlobals.SpecificEliminationID = 14;
                if (!GameGlobals.Debug)
                {
                  if (corpse.Student.MurderedByFragile)
                    PlayerPrefs.SetInt("DrivenToMurder", 1);
                  else
                    PlayerPrefs.SetInt("MurderSuicide", 1);
                }
                Debug.Log((object) "The game knows that the rival died as part of a murder-suicide.");
              }
              else if (corpse.Student.DeathType == DeathType.Weapon)
              {
                Debug.Log((object) "The game believes that the rival died from a ''Weapon''.");
                GameGlobals.SpecificEliminationID = 1;
                if (!GameGlobals.Debug)
                  PlayerPrefs.SetInt("Attack", 1);
              }
              else if (corpse.Student.DeathType == DeathType.Explosion)
              {
                Debug.Log((object) "The game knows that the rival died from an explosion.");
                GameGlobals.SpecificEliminationID = 20;
                if (!GameGlobals.Debug)
                  PlayerPrefs.SetInt("Attack", 1);
              }
              else
                Debug.Log((object) "We know that the rival died, but we didn't get any noteworthy information about her death...");
            }
            else if (corpse.Student.StudentID > 10 && corpse.Student.StudentID < DateGlobals.Week + 10)
            {
              Debug.Log((object) "A previous rival's corpse has been discovered.");
              this.SetFormerRivalDeath(corpse.Student.StudentID - 10, corpse.Student);
            }
            this.VictimArray[this.Corpses] = corpse.Student.StudentID;
            stringList.Add(corpse.Student.Name);
            ++this.Corpses;
          }
        }
        stringList.Sort();
        string str = "The police discover the corpse" + (stringList.Count == 1 ? string.Empty : "s") + " of ";
        if (stringList.Count == 1)
          this.Label.text = str + stringList[0] + ".";
        else if (stringList.Count == 2)
          this.Label.text = str + stringList[0] + " and " + stringList[1] + ".";
        else if (stringList.Count < 6)
        {
          this.Label.text = "The police discover multiple corpses on school grounds.";
          StringBuilder stringBuilder = new StringBuilder();
          for (int index = 0; index < stringList.Count - 1; ++index)
            stringBuilder.Append(stringList[index] + ", ");
          stringBuilder.Append("and " + stringList[stringList.Count - 1] + ".");
          this.Label.text = str + stringBuilder.ToString();
        }
        else
          this.Label.text = "The police discover more than five corpses on school grounds.";
        ++this.Phase;
      }
    }
    else if (this.Phase == 3)
    {
      if (this.WeaponManager.MurderWeapons == 0)
      {
        this.ShruggingCops.SetActive(true);
        if (this.Weapons == 0)
        {
          this.Label.text = "The police are unable to locate any murder weapons.";
          this.Phase += 2;
        }
        else
        {
          this.Phase += 2;
          this.UpdateScene();
        }
      }
      else
      {
        this.MurderWeapon = (WeaponScript) null;
        for (this.ID = 0; this.ID < this.WeaponManager.Weapons.Length; ++this.ID)
        {
          if ((UnityEngine.Object) this.MurderWeapon == (UnityEngine.Object) null)
          {
            WeaponScript weapon = this.WeaponManager.Weapons[this.ID];
            if ((UnityEngine.Object) weapon != (UnityEngine.Object) null && weapon.Blood.enabled)
            {
              if (!weapon.AlreadyExamined)
              {
                --this.WeaponManager.MurderWeapons;
                weapon.gameObject.SetActive(true);
                weapon.AlreadyExamined = true;
                this.MurderWeapon = weapon;
                this.WeaponID = this.ID;
              }
              else
                weapon.gameObject.SetActive(false);
            }
          }
        }
        List<string> stringList = new List<string>();
        this.CurrentMurderWeaponKilledRival = false;
        for (this.ID = 0; this.ID < this.MurderWeapon.Victims.Length; ++this.ID)
        {
          if (this.MurderWeapon.Victims[this.ID])
          {
            stringList.Add(this.JSON.Students[this.ID].Name);
            if (this.MurderWeapon.Victims[this.StudentManager.RivalID])
              this.CurrentMurderWeaponKilledRival = true;
          }
        }
        stringList.Sort();
        this.Victims = stringList.Count;
        string name = this.MurderWeapon.Name;
        string str = "The police discover " + (name[name.Length - 1] != 's' ? "a " + name.ToLower() + " that is" : name.ToLower() + " that are") + " stained with the blood of ";
        if (stringList.Count == 1)
          this.Label.text = str + stringList[0] + ".";
        else if (stringList.Count == 2)
        {
          this.Label.text = str + stringList[0] + " and " + stringList[1] + ".";
        }
        else
        {
          StringBuilder stringBuilder = new StringBuilder();
          for (int index = 0; index < stringList.Count - 1; ++index)
            stringBuilder.Append(stringList[index] + ", ");
          stringBuilder.Append("and " + stringList[stringList.Count - 1] + ".");
          this.Label.text = str + stringBuilder.ToString();
        }
        ++this.Weapons;
        ++this.Phase;
        this.MurderWeapon.transform.parent = this.transform;
        this.MurderWeapon.transform.localPosition = new Vector3(0.6f, 1.4f, -1.5f);
        this.MurderWeapon.transform.localEulerAngles = new Vector3(-45f, 90f, -90f);
        this.MurderWeapon.MyRigidbody.useGravity = false;
        this.MurderWeapon.Rotate = true;
      }
    }
    else if (this.Phase == 4)
    {
      if (this.MurderWeapon.FingerprintID == 0)
      {
        this.ShruggingCops.SetActive(true);
        this.Label.text = "The police find no fingerprints on the weapon.";
        this.Phase = 3;
      }
      else if (this.MurderWeapon.FingerprintID == 100)
      {
        this.TeleportYandere();
        this.Yandere.CharacterAnimation.Play("f02_disappointed_00");
        if (this.Yandere.StudentManager.Eighties)
          this.Yandere.LoseGentleEyes();
        this.Label.text = "The police find " + this.Protagonist + "'s fingerprints on the weapon.";
        this.Phase = 100;
      }
      else
      {
        int fingerprintId = this.WeaponManager.Weapons[this.WeaponID].FingerprintID;
        this.TabletCop.SetActive(true);
        this.CopAnimation[4]["scienceTablet_00"].speed = 0.0f;
        this.TabletPortrait.material.mainTexture = this.VoidGoddess.Portraits[fingerprintId].mainTexture;
        this.Label.text = "The police find the fingerprints of " + this.JSON.Students[fingerprintId].Name + " on the weapon.";
        this.Phase = 101;
      }
    }
    else if (this.Phase == 5)
    {
      if (this.Police.PhotoEvidence > 0)
      {
        this.TeleportYandere();
        this.Yandere.CharacterAnimation.Play("f02_disappointed_00");
        if (this.Yandere.StudentManager.Eighties)
          this.Yandere.LoseGentleEyes();
        this.ShruggingCops.SetActive(false);
        this.Label.text = "The police find a smartphone with photographic evidence of " + this.Protagonist + " committing a crime.";
        this.Phase = 100;
      }
      else
      {
        ++this.Phase;
        this.UpdateScene();
      }
    }
    else if (this.Phase == 6)
    {
      if (SchoolGlobals.HighSecurity)
      {
        this.SecuritySystemScene.SetActive(true);
        if (!this.SecuritySystem.Evidence)
        {
          this.Label.text = "The police investigate the security camera recordings, but cannot find anything incriminating in the footage.";
          ++this.Phase;
        }
        else if (!this.SecuritySystem.Masked)
        {
          this.Label.text = "The police investigate the security camera recordings, and find incriminating footage of " + this.Protagonist + ".";
          this.Phase = 100;
        }
        else
        {
          this.Label.text = "The police investigate the security camera recordings, and find footage of a suspicious masked person.";
          this.Police.MaskReported = true;
          ++this.Phase;
        }
      }
      else
      {
        ++this.Phase;
        this.UpdateScene();
      }
    }
    else if (this.Phase == 7)
    {
      for (this.ID = 1; this.ID < this.StudentManager.Students.Length; ++this.ID)
      {
        if ((UnityEngine.Object) this.StudentManager.Students[this.ID] != (UnityEngine.Object) null && this.StudentManager.Students[this.ID].WitnessedMurder && this.StudentManager.Students[this.ID].Alive && this.StudentManager.Students[this.ID].Persona != PersonaType.Coward && this.StudentManager.Students[this.ID].Persona != PersonaType.Spiteful && this.StudentManager.Students[this.ID].Persona != PersonaType.Evil && this.StudentManager.Students[this.ID].Club != ClubType.Delinquent && !this.StudentManager.Students[this.ID].SawMask)
        {
          ++this.EyeWitnesses;
          this.WitnessList[this.EyeWitnesses] = this.StudentManager.Students[this.ID];
        }
      }
      if (this.EyeWitnesses > 0)
      {
        this.DisableThings(this.WitnessList[1]);
        this.DisableThings(this.WitnessList[2]);
        this.DisableThings(this.WitnessList[3]);
        this.DisableThings(this.WitnessList[4]);
        this.DisableThings(this.WitnessList[5]);
        this.WitnessList[1].transform.localPosition = Vector3.zero;
        if ((UnityEngine.Object) this.WitnessList[2] != (UnityEngine.Object) null)
          this.WitnessList[2].transform.localPosition = new Vector3(-1f, 0.0f, -0.5f);
        if ((UnityEngine.Object) this.WitnessList[3] != (UnityEngine.Object) null)
          this.WitnessList[3].transform.localPosition = new Vector3(1f, 0.0f, -0.5f);
        if ((UnityEngine.Object) this.WitnessList[4] != (UnityEngine.Object) null)
          this.WitnessList[4].transform.localPosition = new Vector3(-2f, 0.0f, -1f);
        if ((UnityEngine.Object) this.WitnessList[5] != (UnityEngine.Object) null)
          this.WitnessList[5].transform.localPosition = new Vector3(1.5f, 0.0f, -1f);
        if (this.WitnessList[1].Male)
          this.WitnessList[1].CharacterAnimation.Play("carefreeTalk_02");
        else
          this.WitnessList[1].CharacterAnimation.Play("f02_carefreeTalk_02");
        this.EyeWitnessScene.SetActive(true);
        if (this.EyeWitnesses == 1)
        {
          this.Label.text = "One student accuses " + this.Protagonist + " of murder, but nobody else can corroborate that students' claims, so the police are unable to develop reasonable justification to arrest " + this.Protagonist + ".";
          ++this.Phase;
        }
        else if (this.EyeWitnesses < 5)
        {
          this.Label.text = "Several students accuse " + this.Protagonist + " of murder, but there are not enough witnesses to provide the police with reasonable justification to arrest her.";
          ++this.Phase;
        }
        else
        {
          this.Label.text = "Numerous students accuse " + this.Protagonist + " of murder, providing the police with enough justification to arrest her.";
          this.Phase = 100;
        }
      }
      else
      {
        ++this.Phase;
        this.UpdateScene();
      }
    }
    else if (this.Phase == 8)
    {
      this.ShruggingCops.SetActive(false);
      if ((double) this.Yandere.Sanity > 33.3333282470703)
      {
        if ((double) this.Yandere.Bloodiness > 0.0 && !this.Yandere.RedPaint || this.Yandere.Gloved && this.Yandere.Gloves.Blood.enabled)
        {
          if (this.Arrests == 0)
          {
            this.TeleportYandere();
            this.Yandere.CharacterAnimation.Play("f02_disappointed_00");
            if (this.Yandere.StudentManager.Eighties)
              this.Yandere.LoseGentleEyes();
            this.Label.text = "The police notice that " + this.Protagonist + "'s clothing is bloody. They confirm that the blood is not hers. " + this.Protagonist + " is unable to convince the police that she did not commit murder.";
            this.Phase = 100;
          }
          else
          {
            this.TeleportYandere();
            this.Yandere.CharacterAnimation["YandereConfessionRejected"].time = 4f;
            this.Yandere.CharacterAnimation.Play("YandereConfessionRejected");
            this.Label.text = "The police notice that " + this.Protagonist + "'s clothing is bloody. They confirm that the blood is not hers. " + this.Protagonist + " is able to convince the police that she was splashed with blood while witnessing a murder.";
            if (!this.TranqCase.Occupied)
              this.Phase += 2;
            else
              ++this.Phase;
          }
        }
        else if (this.Police.BloodyClothing - this.ClothingWithRedPaint > 0)
        {
          this.TeleportYandere();
          this.Yandere.CharacterAnimation.Play("f02_disappointed_00");
          if (this.Yandere.StudentManager.Eighties)
            this.Yandere.LoseGentleEyes();
          this.Label.text = "The police find bloody clothing that has traces of " + this.Protagonist + "'s DNA. " + this.Protagonist + " is unable to convince the police that she did not commit murder.";
          this.Phase = 100;
        }
        else
        {
          this.TeleportYandere();
          this.Yandere.CharacterAnimation["YandereConfessionRejected"].time = 4f;
          this.Yandere.CharacterAnimation.Play("YandereConfessionRejected");
          this.Label.text = "The police question all students in the school, including " + this.Protagonist + ". The police are unable to link " + this.Protagonist + " to any crimes.";
          if (!this.TranqCase.Occupied)
            this.Phase += 2;
          else if (this.TranqCase.VictimID == this.ArrestID)
            this.Phase += 2;
          else
            ++this.Phase;
          if (!this.Yandere.StudentManager.Eighties)
            return;
          this.Yandere.LoseGentleEyes();
        }
      }
      else
      {
        this.TeleportYandere();
        this.Yandere.CharacterAnimation.Play("f02_disappointed_00");
        if (this.Yandere.StudentManager.Eighties)
          this.Yandere.LoseGentleEyes();
        if ((double) this.Yandere.Bloodiness == 0.0)
        {
          this.Label.text = "The police question " + this.Protagonist + ", who exhibits extremely unusual behavior. The police decide to investigate " + this.Protagonist + " further, and eventually learn of her crimes.";
          this.Phase = 100;
        }
        else
        {
          this.Label.text = "The police notice that " + this.Protagonist + " is covered in blood and exhibiting extremely unusual behavior. The police decide to investigate " + this.Protagonist + " further, and eventually learn of her crimes.";
          this.Phase = 100;
        }
      }
    }
    else if (this.Phase == 9)
    {
      this.KidnappedVictim = this.StudentManager.Students[this.TranqCase.VictimID];
      this.KidnappedVictim.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
      this.KidnappedVictim.CharacterAnimation.enabled = true;
      this.KidnappedVictim.gameObject.SetActive(true);
      this.KidnappedVictim.Ragdoll.Zs.SetActive(false);
      this.KidnappedVictim.transform.parent = this.transform;
      this.KidnappedVictim.transform.localPosition = new Vector3(0.0f, 0.145f, 0.0f);
      this.KidnappedVictim.transform.localEulerAngles = new Vector3(0.0f, 90f, 0.0f);
      this.KidnappedVictim.CharacterAnimation.Play("f02_sit_06");
      this.KidnappedVictim.WhiteQuestionMark.SetActive(true);
      this.KidnappedVictim.Cosmetic.FemaleHair[this.KidnappedVictim.Cosmetic.Hairstyle].SetActive(true);
      this.OpenTranqCase.SetActive(true);
      this.Label.text = "The police discover " + this.JSON.Students[this.TranqCase.VictimID].Name + " inside of a musical instrument case. However, she is unable to recall how she got inside of the case. The police are unable to determine what happened.";
      StudentGlobals.SetStudentKidnapped(this.TranqCase.VictimID, false);
      StudentGlobals.SetStudentMissing(this.TranqCase.VictimID, false);
      if (this.TranqCase.VictimID == this.StudentManager.RivalID)
        this.StudentManager.RivalEliminated = false;
      this.TranqCase.VictimClubType = ClubType.None;
      this.TranqCase.VictimID = 0;
      this.TranqCase.Occupied = false;
      ++this.Phase;
    }
    else if (this.Phase == 10)
    {
      if (this.Police.MaskReported)
      {
        this.Mask.SetActive(true);
        GameGlobals.MasksBanned = true;
        this.Label.text = !this.SecuritySystem.Masked ? "Witnesses state that the killer was wearing a mask. As a result, the police are unable to gather meaningful information about the murderer. To prevent this from ever happening again, the Headmaster decides to ban all masks from the school from this day forward." : "In security camera footage, the killer was wearing a mask. As a result, the police are unable to gather meaningful information about the murderer. To prevent this from ever happening again, the Headmaster decides to ban all masks from the school from this day forward.";
        this.Police.MaskReported = false;
        ++this.Phase;
      }
      else
      {
        ++this.Phase;
        this.UpdateScene();
      }
    }
    else if (this.Phase == 11)
    {
      this.Cops.transform.eulerAngles = new Vector3(0.0f, 180f, 0.0f);
      this.Cops.SetActive(true);
      this.Label.text = this.Arrests != 0 ? (this.Arrests != 1 ? "The police believe that they have arrested the perpetrators of the crimes. The police investigation ends, and students are free to leave." : "The police believe that they have arrested the perpetrator of the crime. The police investigation ends, and students are free to leave.") : (this.DeadPerps != 0 ? (!this.Police.MurderSuicideScene ? "The police believe that they know the identity of the killer, but they cannot locate the suspect at school. The police leave to search for the person that they believe is the killer. The police investigation ends, and students are free to leave." : "The police conclude that a murder-suicide took place, but are unable to take any further action. The police investigation ends, and students are free to leave.") : "The police do not have enough evidence to perform an arrest. The police investigation ends, and students are free to leave.");
      if (this.StudentManager.RivalEliminated || this.RivalEliminationMethod != RivalEliminationType.None)
        ++this.Phase;
      else if (DateGlobals.Weekday == DayOfWeek.Friday)
        this.Phase = 24;
      else
        this.Phase += 2;
    }
    else if (this.Phase == 12)
    {
      this.Senpai.enabled = false;
      this.Senpai.transform.parent = this.transform;
      this.Senpai.gameObject.SetActive(true);
      this.Senpai.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
      this.Senpai.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
      this.Senpai.EmptyHands();
      Physics.SyncTransforms();
      string str = "";
      if (this.Yandere.Egg && this.RivalEliminationMethod == RivalEliminationType.None)
        this.RivalEliminationMethod = RivalEliminationType.Murdered;
      if (this.RivalEliminationMethod == RivalEliminationType.None)
        this.Label.text = "Your Senpai feels a growing sense of concern that the school may not be safe.";
      else if (this.RivalEliminationMethod == RivalEliminationType.Murdered || this.RivalEliminationMethod == RivalEliminationType.MurderedWitnessed || this.RivalEliminationMethod == RivalEliminationType.Accident || this.RivalEliminationMethod == RivalEliminationType.SuicideFake)
      {
        if (!this.StudentManager.Eighties)
        {
          this.Senpai.CharacterAnimation.Play("kneelCry_00");
          if (DateGlobals.Weekday != DayOfWeek.Friday)
          {
            str = "Senpai will stay home from school for one day to mourn her death.";
            GameGlobals.SenpaiMourning = true;
          }
          this.Label.text = "Senpai is absolutely devastated by the death of his childhood friend. His mental stability has been greatly affected." + str;
        }
        else
        {
          this.Senpai.CharacterAnimation.Play(this.Senpai.BulliedIdleAnim);
          this.Label.text = "Senpai is deeply saddened by the death of his friend.";
        }
      }
      else
      {
        this.Senpai.transform.localEulerAngles = new Vector3(0.0f, 180f, 0.0f);
        if (this.RivalEliminationMethod == RivalEliminationType.Arrested)
        {
          this.Senpai.CharacterAnimation["refuse_02"].speed = 0.5f;
          this.Senpai.CharacterAnimation.Play("refuse_02");
          this.Label.text = "Senpai is disgusted to learn that " + this.RivalName + " would actually commit murder. He is deeply disappointed in her.";
        }
        else if (this.RivalEliminationMethod == RivalEliminationType.Befriended || this.RivalEliminationMethod == RivalEliminationType.Matchmade)
        {
          this.Senpai.CharacterAnimation.Play(this.Senpai.BulliedIdleAnim);
          this.Label.text = "Senpai notices that " + this.RivalName + " is distancing herself from him. He feels a little sad about it, but he accepts it.";
        }
        else if (this.RivalEliminationMethod == RivalEliminationType.Expelled)
        {
          this.Senpai.CharacterAnimation.Play("surprisedPose_00");
          this.Label.text = "Senpai is shocked to learn that " + this.RivalName + " has been expelled. He is deeply disappointed in her.";
        }
        else if (this.RivalEliminationMethod == RivalEliminationType.Ruined)
        {
          this.Senpai.CharacterAnimation["refuse_02"].speed = 0.5f;
          this.Senpai.CharacterAnimation.Play("refuse_02");
          this.Label.text = "Senpai is disturbed by the rumors circulating about " + this.RivalName + ". He is deeply disappointed in her.";
        }
        else if (this.RivalEliminationMethod == RivalEliminationType.Rejected)
        {
          this.Senpai.CharacterAnimation.Play(this.Senpai.BulliedIdleAnim);
          this.Label.text = "Senpai feels guilty for turning down " + this.RivalName + "'s feelings, but also he knows that he cannot take back what has been said.";
        }
        else if (this.RivalEliminationMethod == RivalEliminationType.Vanished)
        {
          this.Senpai.CharacterAnimation.Play(this.Senpai.BulliedIdleAnim);
          this.Label.text = "Senpai is concerned about the sudden disappearance of " + this.RivalName + ". His mental stability has been slightly affected.";
        }
      }
      ++this.Phase;
    }
    else if (this.Phase == 13)
    {
      this.Senpai.enabled = false;
      this.Senpai.transform.parent = this.transform;
      this.Senpai.gameObject.SetActive(true);
      this.Senpai.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
      this.Senpai.transform.localEulerAngles = new Vector3(0.0f, 180f, 0.0f);
      this.Senpai.EmptyHands();
      if (this.StudentManager.RivalEliminated)
        this.Senpai.CharacterAnimation.Play(this.Senpai.BulliedWalkAnim);
      else
        this.Senpai.CharacterAnimation.Play(this.Senpai.WalkAnim);
      this.Yandere.LookAt.enabled = true;
      this.Yandere.MyController.enabled = false;
      this.Yandere.transform.parent = this.transform;
      this.Yandere.transform.localPosition = new Vector3(2.5f, 0.0f, 2.5f);
      this.Yandere.transform.localEulerAngles = new Vector3(0.0f, 180f, 0.0f);
      this.Yandere.CharacterAnimation.Play(this.Yandere.WalkAnim);
      this.Label.text = this.Protagonist + " stalks Senpai until he has returned home, and then returns to her own home.";
      if (GameGlobals.SenpaiMourning)
      {
        this.Senpai.gameObject.SetActive(false);
        this.Yandere.LookAt.enabled = false;
        this.Yandere.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        this.Yandere.transform.localEulerAngles = new Vector3(0.0f, 180f, 0.0f);
        this.Label.text = this.Protagonist + " returns home, thinking of Senpai every step of the way.";
      }
      Physics.SyncTransforms();
      ++this.Phase;
    }
    else if (this.Phase == 14)
    {
      Debug.Log((object) "We're currently in the End-of-Day sequence, checking to see if the Counselor has to lecture anyone.");
      if (!StudentGlobals.GetStudentDying(this.StudentManager.RivalID) && !StudentGlobals.GetStudentDead(this.StudentManager.RivalID) && !StudentGlobals.GetStudentArrested(this.StudentManager.RivalID))
      {
        Debug.Log((object) "The current rival is not dying, dead, or arrested.");
        if (this.Counselor.LectureID > 0)
        {
          this.Yandere.gameObject.SetActive(false);
          for (int DisableID = 1; DisableID < 101; ++DisableID)
            this.StudentManager.DisableStudent(DisableID);
          this.EODCamera.position = new Vector3(-18.5f, 1f, 6.5f);
          this.EODCamera.eulerAngles = new Vector3(0.0f, -45f, 0.0f);
          this.EODCamera.Translate(this.EODCamera.transform.forward * 0.3f);
          this.Counselor.Lecturing = true;
          this.enabled = false;
          Debug.Log((object) "The counselor is going to lecture somebody! Exiting End-of-Day sequence.");
        }
        else
        {
          ++this.Phase;
          this.UpdateScene();
        }
      }
      else
      {
        ++this.Phase;
        this.UpdateScene();
      }
    }
    else if (this.Phase == 15)
    {
      this.EODCamera.localPosition = new Vector3(1f, 1.8f, -2.5f);
      this.EODCamera.localEulerAngles = new Vector3(22.5f, -22.5f, 0.0f);
      this.TextWindow.SetActive(true);
      if (this.Counselor.MustReturnStolenRing)
      {
        if (!this.StudentManager.Eighties)
          this.GaudyRing.SetActive(true);
        else
          this.EightiesGaudyRing.SetActive(true);
        if (!this.StudentManager.Eighties)
        {
          this.Label.text = "The guidance counselor returns Sakyu's stolen ring to her. Sakyu decides to stop bringing the ring to school.";
          GameGlobals.RingStolen = true;
        }
        else
          this.Label.text = "The guidance counselor returns Himeko's stolen ring to her. Having her ring stolen does not affect Himeko's decision to wear expensive jewelry at school every day.";
        this.Counselor.MustReturnStolenRing = false;
      }
      else if (SchemeGlobals.GetSchemeStage(2) == 3)
      {
        this.GaudyRing.SetActive(true);
        this.Label.text = StudentGlobals.GetStudentDying(this.StudentManager.RivalID) || StudentGlobals.GetStudentDead(this.StudentManager.RivalID) || StudentGlobals.GetStudentArrested(this.StudentManager.RivalID) ? "Sakyu Basu will never recover her stolen ring." : this.RivalName + " discovers a ring inside of her book bag. She returns the ring to its owner.";
        SchemeGlobals.SetSchemeStage(2, 100);
        GameGlobals.RingStolen = true;
      }
      else
      {
        ++this.Phase;
        this.UpdateScene();
      }
    }
    else if (this.Phase == 16)
    {
      if (this.Police.Deaths + PlayerGlobals.Kills > 50)
      {
        this.EODCamera.position = new Vector3(-6f, 0.15f, -49f);
        this.EODCamera.eulerAngles = new Vector3(-22.5f, 22.5f, 0.0f);
        this.Label.text = "More than half of the school's population is dead. For the safety of the remaining students, the headmaster of Akademi makes the decision to shut down the school. Senpai enrolls in a school far away. " + this.Protagonist + " will not be able to follow him, and another girl will steal his heart. " + this.Protagonist + " has permanently lost her chance to be with Senpai.";
        this.Heartbroken.NoSnap = true;
        this.GameOver = true;
      }
      else
      {
        ++this.Phase;
        this.UpdateScene();
      }
    }
    else if (this.Phase == 17)
    {
      this.ClubLimit = this.ClubArray.Length;
      if (!GameGlobals.Eighties)
        --this.ClubLimit;
      this.ClubClosed = false;
      this.ClubKicked = false;
      this.DistanceToMoveForward = 1.2f;
      if (this.ClubID < this.ClubLimit)
      {
        if (this.StudentManager.Eighties && this.ClubID == 11)
          ++this.ClubID;
        if (!ClubGlobals.GetClubClosed(this.ClubArray[this.ClubID]))
        {
          this.ClubManager.CheckClub(this.ClubArray[this.ClubID]);
          if (this.ClubManager.ClubMembers < 5)
          {
            this.EODCamera.position = this.ClubManager.ClubVantages[this.ClubID].position;
            this.EODCamera.eulerAngles = this.ClubManager.ClubVantages[this.ClubID].eulerAngles;
            this.EODCamera.Translate(Vector3.forward * this.DistanceToMoveForward, Space.Self);
            ClubGlobals.SetClubClosed(this.ClubArray[this.ClubID], true);
            this.Label.text = this.ClubID == 11 ? (this.ClubManager.ClubMembers <= 0 ? "The Gaming Club no longer exists." : "The Gaming Club makes the decision to disband.") : "The " + this.ClubNames[this.ClubID].ToString() + " no longer has enough members to remain operational. The school forces the club to disband.";
            this.ClubClosed = true;
            if (this.Yandere.Club == this.ClubArray[this.ClubID])
              this.Yandere.Club = ClubType.None;
          }
          if (this.ClubManager.LeaderMissing)
          {
            this.EODCamera.position = this.ClubManager.ClubVantages[this.ClubID].position;
            this.EODCamera.eulerAngles = this.ClubManager.ClubVantages[this.ClubID].eulerAngles;
            this.EODCamera.Translate(Vector3.forward * this.DistanceToMoveForward, Space.Self);
            ClubGlobals.SetClubClosed(this.ClubArray[this.ClubID], true);
            this.Label.text = "The leader of the " + this.ClubNames[this.ClubID].ToString() + " has gone missing. The " + this.ClubNames[this.ClubID].ToString() + " cannot operate without its leader. The club disbands.";
            this.ClubClosed = true;
            if (this.Yandere.Club == this.ClubArray[this.ClubID])
              this.Yandere.Club = ClubType.None;
          }
          else if (this.ClubManager.LeaderDead)
          {
            this.EODCamera.position = this.ClubManager.ClubVantages[this.ClubID].position;
            this.EODCamera.eulerAngles = this.ClubManager.ClubVantages[this.ClubID].eulerAngles;
            this.EODCamera.Translate(Vector3.forward * this.DistanceToMoveForward, Space.Self);
            ClubGlobals.SetClubClosed(this.ClubArray[this.ClubID], true);
            this.Label.text = "The leader of the " + this.ClubNames[this.ClubID].ToString() + " is gone. The " + this.ClubNames[this.ClubID].ToString() + " cannot operate without its leader. The club disbands.";
            this.ClubClosed = true;
            if (this.Yandere.Club == this.ClubArray[this.ClubID])
              this.Yandere.Club = ClubType.None;
          }
          else if (this.ClubManager.LeaderAshamed)
          {
            this.EODCamera.position = this.ClubManager.ClubVantages[this.ClubID].position;
            this.EODCamera.eulerAngles = this.ClubManager.ClubVantages[this.ClubID].eulerAngles;
            this.EODCamera.Translate(Vector3.forward * this.DistanceToMoveForward, Space.Self);
            ClubGlobals.SetClubClosed(this.ClubArray[this.ClubID], true);
            this.Label.text = "The leader of the " + this.ClubNames[this.ClubID].ToString() + " has unexpectedly disbanded the club without explanation.";
            this.ClubClosed = true;
            this.ClubManager.LeaderAshamed = false;
            if (this.Yandere.Club == this.ClubArray[this.ClubID])
              this.Yandere.Club = ClubType.None;
          }
        }
        if (!ClubGlobals.GetClubClosed(this.ClubArray[this.ClubID]) && !ClubGlobals.GetClubKicked(this.ClubArray[this.ClubID]) && this.Yandere.Club == this.ClubArray[this.ClubID])
        {
          this.ClubManager.CheckGrudge(this.ClubArray[this.ClubID]);
          if (this.ClubManager.LeaderGrudge)
          {
            this.EODCamera.position = this.ClubManager.ClubVantages[this.ClubID].position;
            this.EODCamera.eulerAngles = this.ClubManager.ClubVantages[this.ClubID].eulerAngles;
            this.EODCamera.Translate(Vector3.forward * this.DistanceToMoveForward, Space.Self);
            this.Label.text = this.Protagonist + " receives a message from the president of the " + this.ClubNames[this.ClubID].ToString() + ". " + this.Protagonist + " is no longer a member of the " + this.ClubNames[this.ClubID].ToString() + ", and is not welcome in the " + this.ClubNames[this.ClubID].ToString() + " room.";
            ClubGlobals.SetClubKicked(this.ClubArray[this.ClubID], true);
            this.Yandere.Club = ClubType.None;
            this.ClubKicked = true;
          }
          else if (this.ClubManager.ClubGrudge)
          {
            this.EODCamera.position = this.ClubManager.ClubVantages[this.ClubID].position;
            this.EODCamera.eulerAngles = this.ClubManager.ClubVantages[this.ClubID].eulerAngles;
            this.EODCamera.Translate(Vector3.forward * this.DistanceToMoveForward, Space.Self);
            this.Label.text = this.Protagonist + " receives a message from the president of the " + this.ClubNames[this.ClubID].ToString() + ". There is someone in the " + this.ClubNames[this.ClubID].ToString() + " who hates and fears " + this.Protagonist + ". " + this.Protagonist + " is no longer a member of the " + this.ClubNames[this.ClubID].ToString() + ", and is not welcome in the " + this.ClubNames[this.ClubID].ToString() + " room.";
            ClubGlobals.SetClubKicked(this.ClubArray[this.ClubID], true);
            this.Yandere.Club = ClubType.None;
            this.ClubKicked = true;
          }
        }
        if (!this.ClubClosed && !this.ClubKicked)
        {
          ++this.ClubID;
          this.UpdateScene();
        }
        this.ClubManager.LeaderAshamed = false;
      }
      else
      {
        ++this.Phase;
        this.UpdateScene();
      }
    }
    else if (this.Phase == 18)
    {
      if (this.TranqCase.Occupied)
      {
        this.ClosedTranqCase.SetActive(true);
        this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 1f);
        if (this.StudentManager.Eighties)
          this.Protagonist = "Ryoba";
        this.Label.text = this.Protagonist + " waits until midnight, sneaks into school, and returns to the musical instrument case that contains her unconscious victim. She pushes the case back to her house and ties the victim to a chair in her basement.";
        if (this.TranqCase.VictimID == this.StudentManager.RivalID)
        {
          this.RivalEliminationMethod = RivalEliminationType.Vanished;
          GameGlobals.SpecificEliminationID = 12;
          if (!GameGlobals.Debug)
            PlayerPrefs.SetInt("Kidnap", 1);
        }
        ++this.Phase;
      }
      else
      {
        ++this.Phase;
        this.UpdateScene();
      }
    }
    else if (this.Phase == 19)
    {
      if (this.ErectFence)
      {
        this.Fence.SetActive(true);
        this.Label.text = "To prevent any other students from falling off of the school rooftop, the school erects a fence around the roof.";
        SchoolGlobals.RoofFence = true;
        this.ErectFence = false;
      }
      else
      {
        ++this.Phase;
        this.UpdateScene();
      }
    }
    else if (this.Phase == 20)
    {
      if (!SchoolGlobals.HighSecurity && this.Police.CouncilDeath)
      {
        if (!this.StudentManager.Eighties)
        {
          this.SCP.SetActive(true);
          this.Label.text = "The student council president has ordered the implementation of heightened security precautions. Security cameras and metal detectors are now present at school.";
        }
        else
        {
          this.Headmaster.SetActive(true);
          this.Label.text = "The headmaster has ordered the implementation of heightened security precautions. Security cameras and metal detectors are now present at school.";
        }
        this.Police.CouncilDeath = false;
      }
      else
      {
        ++this.Phase;
        this.UpdateScene();
      }
    }
    else if (this.Phase == 21)
    {
      this.Rival = this.StudentManager.Students[this.StudentManager.RivalID];
      if (this.ArticleID == 2)
      {
        this.StudentManager.StudentReps[this.StudentManager.RivalID] -= (float) (20.0 * (1.0 + (double) this.Class.LanguageGrade * 0.200000002980232));
        StudentGlobals.SetStudentReputation(this.StudentManager.RivalID, Mathf.RoundToInt(this.StudentManager.StudentReps[this.StudentManager.RivalID]));
      }
      if ((UnityEngine.Object) this.Rival != (UnityEngine.Object) null && this.Rival.Alive && (double) this.StudentManager.StudentReps[this.StudentManager.RivalID] <= -100.0)
      {
        Debug.Log((object) "The rival is not null, the rival is alive, and the rival's reputation is below -100.");
        this.Rival.gameObject.SetActive(true);
        this.Rival.transform.parent = this.transform;
        this.Rival.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        this.Rival.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        this.Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
        this.Rival.CharacterAnimation.Play(this.Rival.BulliedWalkAnim);
        this.Rival.CharacterAnimation.enabled = true;
        this.RivalName = !this.StudentManager.Eighties ? this.RivalNames[DateGlobals.Week] : this.EightiesRivalNames[DateGlobals.Week];
        this.Label.text = this.RivalName + " cannot endure the bullying and harassment that she is being subjected to due to her damaged reputation. She chooses to withdraw from Akademi and never return.";
        this.RivalEliminationMethod = RivalEliminationType.Ruined;
        this.StudentManager.RivalEliminated = true;
        GameGlobals.SpecificEliminationID = 4;
        if ((double) this.StudentManager.StudentReps[this.StudentManager.RivalID] <= -150.0)
        {
          this.Label.text = this.RivalName + " is absolutely devastated by the unbearable bullying and harassment that she is being subjected to. She silently returns to her home, planning something drastic...";
          this.Rival.CharacterAnimation.Play(this.Rival.BulliedIdleAnim);
          this.RivalEliminationMethod = RivalEliminationType.SuicideBully;
          this.GoToSuicideScene = true;
          this.StudentManager.Students[this.StudentManager.RivalID].Hearts.Stop();
          GameGlobals.SpecificEliminationID = 19;
          if (!GameGlobals.Debug)
            PlayerPrefs.SetInt("Suicide", 1);
        }
        else
        {
          Debug.Log((object) "Informing the Content Checklist.");
          if (!GameGlobals.Debug)
            PlayerPrefs.SetInt("Bully", 1);
        }
        ++this.Phase;
      }
      else
      {
        ++this.Phase;
        this.UpdateScene();
      }
    }
    else if (this.Phase == 22)
    {
      if (this.Yandere.Club != ClubType.None && DateGlobals.Weekday == DayOfWeek.Friday && this.ClubManager.ActivitiesAttended == 0)
      {
        this.TeleportYandere();
        this.Yandere.CharacterAnimation.Play("f02_disappointed_00");
        if (this.Yandere.StudentManager.Eighties)
          this.Yandere.LoseGentleEyes();
        if (this.StudentManager.Eighties)
          this.Protagonist = "Ryoba";
        this.Label.text = this.Protagonist + " did not participate in any activities with her club this week. She been kicked out of the club.";
        ClubGlobals.SetClubKicked(this.Yandere.Club, true);
        ClubGlobals.Club = ClubType.None;
        this.Yandere.Club = ClubType.None;
      }
      else
      {
        ++this.Phase;
        this.UpdateScene();
      }
    }
    else if (this.Phase == 23)
      this.Finish();
    else if (this.Phase == 24)
    {
      if (!this.LoveManager.ConfessToSuitor && this.StudentManager.Students[this.StudentManager.SuitorID].Alive)
      {
        this.Senpai.enabled = false;
        this.Senpai.Pathfinding.enabled = false;
        this.Senpai.transform.parent = this.transform;
        this.Senpai.gameObject.SetActive(true);
        this.Senpai.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        this.Senpai.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        this.Senpai.EmptyHands();
        this.Senpai.MyController.enabled = false;
        this.Senpai.CharacterAnimation.enabled = true;
        this.Senpai.CharacterAnimation.CrossFade(this.Senpai.IdleAnim);
        this.Rival.enabled = false;
        this.Rival.Pathfinding.enabled = false;
        this.Rival.transform.parent = this.transform;
        this.Rival.gameObject.SetActive(true);
        this.Rival.transform.localPosition = new Vector3(0.0f, 0.0f, 1f);
        this.Rival.transform.localEulerAngles = new Vector3(0.0f, 180f, 0.0f);
        this.Rival.EmptyHands();
        this.Rival.MyController.enabled = false;
        this.Rival.CharacterAnimation.enabled = true;
        this.Rival.CharacterAnimation.CrossFade(this.Rival.IdleAnim);
        this.Rival.CharacterAnimation["f02_shy_00"].weight = 1f;
        this.Rival.CharacterAnimation.Play("f02_shy_00");
        this.Label.text = "After the police investigation ends, " + this.RivalName + " asks Senpai to speak with her under the cherry tree behind the school.";
        ++this.Phase;
      }
      else
      {
        StudentScript student = this.StudentManager.Students[this.StudentManager.SuitorID];
        student.enabled = false;
        student.Pathfinding.enabled = false;
        student.transform.parent = this.transform;
        student.gameObject.SetActive(true);
        student.transform.localPosition = new Vector3(-0.4f, 0.0f, 0.0f);
        student.transform.localEulerAngles = new Vector3(0.0f, 90f, 0.0f);
        student.EmptyHands();
        student.MyController.enabled = false;
        student.CharacterAnimation.enabled = true;
        student.CharacterAnimation.Play("holdHandsLoop_00");
        ParticleSystem.EmissionModule emission = student.Hearts.emission with
        {
          enabled = true
        };
        student.Hearts.Play();
        this.Rival.enabled = false;
        this.Rival.Pathfinding.enabled = false;
        this.Rival.transform.parent = this.transform;
        this.Rival.gameObject.SetActive(true);
        this.Rival.transform.localPosition = new Vector3(0.4f, 0.0f, 0.0f);
        this.Rival.transform.localEulerAngles = new Vector3(0.0f, -90f, 0.0f);
        this.Rival.EmptyHands();
        this.Rival.MyController.enabled = false;
        this.Rival.CharacterAnimation.enabled = true;
        this.Rival.CharacterAnimation.CrossFade(this.Rival.IdleAnim);
        this.Rival.CharacterAnimation["f02_shy_00"].weight = 1f;
        this.Rival.CharacterAnimation.Play("f02_holdHandsLoop_00");
        emission = this.Rival.Hearts.emission with
        {
          enabled = true
        };
        this.Rival.Hearts.Play();
        this.RivalEliminationMethod = RivalEliminationType.Matchmade;
        this.Label.text = "After the police investigation ends, " + this.RivalName + " confesses to a boy that she has fallen in love with. She will no longer attempt to pursue a relationship with " + this.Protagonist + "'s Senpai.";
        this.Phase = 12;
      }
    }
    else if (this.Phase == 25)
    {
      for (int DisableID = 1; DisableID < 101; ++DisableID)
        this.StudentManager.DisableStudent(DisableID);
      this.LoveManager.Suitor = this.Senpai;
      this.LoveManager.Rival = this.Rival;
      this.LoveManager.Rival.CharacterAnimation["f02_shy_00"].weight = 0.0f;
      this.LoveManager.Suitor.gameObject.SetActive(true);
      this.LoveManager.Rival.gameObject.SetActive(true);
      this.Yandere.gameObject.SetActive(true);
      this.LoveManager.Suitor.transform.parent = (Transform) null;
      this.LoveManager.Rival.transform.parent = (Transform) null;
      this.Yandere.gameObject.transform.parent = (Transform) null;
      this.LoveManager.BeginConfession();
      this.Clock.NightLighting();
      this.Clock.enabled = false;
      this.gameObject.SetActive(false);
    }
    else if (this.Phase == 100)
    {
      this.Yandere.MyController.enabled = false;
      this.Yandere.transform.parent = this.transform;
      this.Yandere.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
      this.Yandere.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
      this.Yandere.CharacterAnimation.Play("f02_handcuffs_00");
      this.Yandere.Handcuffs.SetActive(true);
      this.ArrestingCops.SetActive(true);
      Physics.SyncTransforms();
      this.Label.text = this.Protagonist + " is arrested by the police. She will never have Senpai.";
      this.GameOver = true;
      this.Heartbroken.Arrested = true;
      this.Heartbroken.NoSnap = true;
    }
    else if (this.Phase == 101)
    {
      int fingerprintId = this.WeaponManager.Weapons[this.WeaponID].FingerprintID;
      StudentScript student = this.StudentManager.Students[fingerprintId];
      if (student.Alive)
      {
        this.Patsy = this.StudentManager.Students[fingerprintId];
        this.Patsy.gameObject.SetActive(true);
        this.Patsy.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
        this.Patsy.CharacterAnimation.enabled = true;
        if ((UnityEngine.Object) this.Patsy.WeaponBag != (UnityEngine.Object) null)
          this.Patsy.WeaponBag.SetActive(false);
        this.Patsy.EmptyHands();
        this.Patsy.SpeechLines.Stop();
        this.Patsy.Handcuffs.SetActive(true);
        this.Patsy.gameObject.SetActive(true);
        this.Patsy.Ragdoll.Zs.SetActive(false);
        this.Patsy.SmartPhone.SetActive(false);
        this.Patsy.MyController.enabled = false;
        this.Patsy.transform.parent = this.transform;
        this.Patsy.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        this.Patsy.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        this.Patsy.ShoeRemoval.enabled = false;
        if (this.StudentManager.Students[fingerprintId].Male)
          this.StudentManager.Students[fingerprintId].CharacterAnimation.Play("handcuffs_00");
        else
          this.StudentManager.Students[fingerprintId].CharacterAnimation.Play("f02_handcuffs_00");
        this.ArrestingCops.SetActive(true);
        if (!student.Tranquil)
        {
          this.Label.text = this.JSON.Students[fingerprintId].Name + " is arrested by the police.";
          this.StudentsToArrest[fingerprintId] = true;
          ++this.Arrests;
        }
        else
        {
          this.Label.text = this.JSON.Students[fingerprintId].Name + " is found asleep inside of a musical instrument case. The police assume that she hid herself inside of the box after committing murder, and arrest her.";
          this.StudentsToArrest[fingerprintId] = true;
          this.ArrestID = fingerprintId;
          this.TranqCase.Occupied = false;
          ++this.Arrests;
        }
        if (this.Patsy.StudentID == this.StudentManager.RivalID)
        {
          this.StudentManager.RivalEliminated = true;
          this.RivalArrested = true;
        }
      }
      else
      {
        this.ShruggingCops.SetActive(true);
        if (student.Ragdoll.Disposed)
        {
          this.Label.text = this.JSON.Students[fingerprintId].Name + " is missing. The police cannot perform an arrest.";
          ++this.DeadPerps;
        }
        else
        {
          bool flag = false;
          for (this.ID = 0; this.ID < this.VictimArray.Length; ++this.ID)
          {
            if (this.VictimArray[this.ID] == fingerprintId && !student.MurderSuicide)
              flag = true;
          }
          if (!flag)
          {
            this.Label.text = this.JSON.Students[fingerprintId].Name + " is dead. The police cannot perform an arrest.";
            ++this.DeadPerps;
          }
          else
            this.Label.text = this.JSON.Students[fingerprintId].Name + "'s fingerprints are on the same weapon that killed them. The police cannot solve this mystery.";
        }
      }
      if (this.CurrentMurderWeaponKilledRival)
      {
        Debug.Log((object) "The police believe that they know who killed the rival. ''Details'' for this rival should be set to ''14'' - ''Ryoba's involvement not suspected.''");
        this.InvolvementNotSuspected = true;
      }
      this.Phase = 3;
    }
    else if (this.Phase == 102)
    {
      int num = (bool) (UnityEngine.Object) this.StudentManager.Students[this.Police.SuicideID] ? 1 : 0;
      if (!this.StudentManager.Students[this.Police.SuicideID].Ragdoll.Disposed)
      {
        this.MurderScene.SetActive(true);
        this.Label.text = !this.Police.SuicideNote ? "The police inspect the corpse of a student who appears to have fallen to their death from the school rooftop. The police treat the incident as a murder case, and search the school for any other victims." : "The police inspect the corpse of a student who appears to have fallen to their death from the school rooftop. The police find a suicide note, and conclude that the deceased student probably took their own life. However, they still search the school for clues and evidence.";
        if (this.Police.SuicideID == this.StudentManager.RivalID)
          this.RivalEliminationMethod = RivalEliminationType.SuicideFake;
        this.ErectFence = true;
      }
      else
      {
        this.ShruggingCops.SetActive(true);
        this.Label.text = "The police attempt to determine whether or not a student fell to their death from the school rooftop. The police are unable to reach a conclusion.";
      }
      for (this.ID = 0; this.ID < this.Police.CorpseList.Length; ++this.ID)
      {
        RagdollScript corpse = this.Police.CorpseList[this.ID];
        if ((UnityEngine.Object) corpse != (UnityEngine.Object) null && corpse.Suicide)
        {
          ++this.Police.SuicideVictims;
          if (this.Police.Corpses > 0)
            --this.Police.Corpses;
        }
      }
      this.Phase = 2;
    }
    else if (this.Phase == 103)
    {
      this.MurderScene.SetActive(true);
      this.Label.text = "The paramedics attempt to resuscitate the poisoned student, but they are unable to revive her. The police treat the incident as a murder case, and search the school for any other victims.";
      for (this.ID = 0; this.ID < this.Police.CorpseList.Length; ++this.ID)
      {
        RagdollScript corpse = this.Police.CorpseList[this.ID];
        if ((UnityEngine.Object) corpse != (UnityEngine.Object) null && corpse.Poisoned)
        {
          if (this.Police.Corpses > 0)
            --this.Police.Corpses;
        }
      }
      if (this.Corpse.StudentID == this.StudentManager.RivalID)
      {
        GameGlobals.SpecificEliminationID = 15;
        if (!GameGlobals.Debug)
          PlayerPrefs.SetInt("Poison", 1);
      }
      this.Phase = 2;
    }
    else if (this.Phase == 104)
    {
      this.MurderScene.SetActive(true);
      this.Label.text = "The police determine that " + this.Police.DrownedStudentName + " died from drowning. The police treat the death as a possible murder, and search the school for any other victims.";
      for (this.ID = 0; this.ID < this.Police.CorpseList.Length; ++this.ID)
      {
        RagdollScript corpse = this.Police.CorpseList[this.ID];
        if ((UnityEngine.Object) corpse != (UnityEngine.Object) null)
        {
          if (corpse.Student.StudentID == this.StudentManager.RivalID)
          {
            Debug.Log((object) "The player drowned the rival.");
            if (this.RivalEliminationMethod == RivalEliminationType.None)
              this.RivalEliminationMethod = RivalEliminationType.Murdered;
            GameGlobals.SpecificEliminationID = 7;
            if (!GameGlobals.Debug)
              PlayerPrefs.SetInt("Drown", 1);
          }
          if (corpse.Drowned)
          {
            if (this.Police.Corpses > 0)
              --this.Police.Corpses;
          }
        }
      }
      this.Phase = 2;
    }
    else if (this.Phase == 105)
    {
      this.MurderScene.SetActive(true);
      this.Label.text = "The police determine that " + this.Police.ElectrocutedStudentName + " died from being electrocuted. The police treat the death as a possible murder, and search the school for any other victims.";
      for (this.ID = 0; this.ID < this.Police.CorpseList.Length; ++this.ID)
      {
        RagdollScript corpse = this.Police.CorpseList[this.ID];
        if ((UnityEngine.Object) corpse != (UnityEngine.Object) null && corpse.Electrocuted)
        {
          if (corpse.Student.StudentID == this.StudentManager.RivalID)
          {
            Debug.Log((object) "The game should now be informing the Content Checklist that the player has performed an electrocution.");
            if (!GameGlobals.Debug)
              PlayerPrefs.SetInt("Electrocute", 1);
          }
          if (this.Police.Corpses > 0)
            --this.Police.Corpses;
        }
      }
      this.Phase = 2;
    }
    else
    {
      if (this.Phase != 999)
        return;
      this.ScaredCops.SetActive(true);
      this.Yandere.MyController.enabled = false;
      this.Yandere.transform.parent = this.transform;
      this.Yandere.transform.localPosition = new Vector3(0.0f, 0.0f, -1f);
      this.Yandere.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
      Physics.SyncTransforms();
      this.Label.text = "The police witness actual evidence of the supernatural, are absolutely horrified, and run for their lives.";
      if (this.StudentManager.RivalEliminated)
        this.Phase = 12;
      else
        this.Phase = 13;
    }
  }

  private void TeleportYandere()
  {
    this.Yandere.MyController.enabled = false;
    this.Yandere.transform.parent = this.transform;
    this.Yandere.transform.localPosition = new Vector3(0.75f, 0.33333f, -1.9f);
    this.Yandere.transform.localEulerAngles = new Vector3(-22.5f, 157.5f, 0.0f);
    Physics.SyncTransforms();
  }

  private void Finish()
  {
    Debug.Log((object) "We have reached the end of the End-of-Day sequence.");
    if (this.RivalArrested)
      this.RivalEliminationMethod = RivalEliminationType.Arrested;
    if (this.RivalEliminationMethod == RivalEliminationType.Murdered)
    {
      Debug.Log((object) "The rival was attacked with a weapon.");
      GameGlobals.RivalEliminationID = 1;
      GameGlobals.NonlethalElimination = false;
      if (this.StudentManager.Students[1].SenpaiWitnessingRivalDie)
        GameGlobals.RivalEliminationID = 2;
      if (this.InvolvementNotSuspected)
      {
        Debug.Log((object) "The police found someone's fingerprints on the murder weapon, so Ryoba is not a suspect.");
        GameGlobals.RivalEliminationID = 14;
      }
    }
    else if (this.RivalEliminationMethod == RivalEliminationType.Arrested)
    {
      Debug.Log((object) "The rival was arrested.");
      GameGlobals.RivalEliminationID = 3;
      GameGlobals.NonlethalElimination = true;
      GameGlobals.SpecificEliminationID = 11;
      if (!GameGlobals.Debug)
        PlayerPrefs.SetInt("Frame", 1);
      StudentGlobals.SetStudentArrested(this.StudentManager.RivalID, true);
    }
    else if (this.RivalEliminationMethod == RivalEliminationType.Expelled)
    {
      Debug.Log((object) "The rival was expelled.");
      StudentGlobals.SetStudentExpelled(this.StudentManager.RivalID, true);
      GameGlobals.RivalEliminationID = 5;
      GameGlobals.NonlethalElimination = true;
      GameGlobals.SpecificEliminationID = 9;
      if (!GameGlobals.Debug)
        PlayerPrefs.SetInt("Expel", 1);
    }
    else if (this.RivalEliminationMethod == RivalEliminationType.Matchmade)
    {
      Debug.Log((object) "The rival was matchmade.");
      GameGlobals.RivalEliminationID = 6;
      GameGlobals.NonlethalElimination = true;
      GameGlobals.SpecificEliminationID = 13;
      if (!GameGlobals.Debug)
        PlayerPrefs.SetInt("Matchmake", 1);
    }
    else if (this.RivalEliminationMethod == RivalEliminationType.Rejected)
    {
      Debug.Log((object) "The rival was rejected by Senpai.");
      GameGlobals.RivalEliminationID = 7;
      GameGlobals.NonlethalElimination = true;
      GameGlobals.SpecificEliminationID = 18;
      if (!GameGlobals.Debug)
        PlayerPrefs.SetInt("Reject", 1);
    }
    else if (this.RivalEliminationMethod == RivalEliminationType.Ruined)
    {
      Debug.Log((object) "The rival's reputation has been ruined.");
      GameGlobals.RivalEliminationID = 8;
      GameGlobals.NonlethalElimination = true;
      if (!GameGlobals.Debug)
        PlayerPrefs.SetInt("Bully", 1);
    }
    else if (this.RivalEliminationMethod == RivalEliminationType.SuicideBully)
    {
      Debug.Log((object) "The rival was bullied into suicide.");
      GameGlobals.RivalEliminationID = 9;
      GameGlobals.NonlethalElimination = false;
    }
    else if (this.RivalEliminationMethod == RivalEliminationType.SuicideFake)
    {
      Debug.Log((object) "The rival was pushed off the school rooftop, and the player made her death look like an accident.");
      GameGlobals.RivalEliminationID = 10;
      GameGlobals.NonlethalElimination = false;
      GameGlobals.SpecificEliminationID = 17;
      if (!GameGlobals.Debug)
        PlayerPrefs.SetInt("Push", 1);
    }
    else if (this.RivalEliminationMethod == RivalEliminationType.Vanished || this.RivalDismemberedAndIncinerated || this.RivalBuried)
    {
      Debug.Log((object) "The rival ''mysteriously disappeared''.");
      GameGlobals.RivalEliminationID = 11;
      GameGlobals.NonlethalElimination = false;
      this.CheckForNatureOfDeath();
      if (this.TranqCase.VictimID == this.StudentManager.RivalID)
        GameGlobals.NonlethalElimination = true;
    }
    else if (this.RivalEliminationMethod == RivalEliminationType.Accident)
    {
      Debug.Log((object) "The rival was killed in a ''mysterious accident''.");
      GameGlobals.RivalEliminationID = 12;
      GameGlobals.NonlethalElimination = false;
    }
    if (GameGlobals.RivalEliminationID == 0 && (UnityEngine.Object) this.StudentManager.Students[this.StudentManager.RivalID] != (UnityEngine.Object) null && !this.StudentManager.Students[this.StudentManager.RivalID].Alive)
    {
      Debug.Log((object) "RivalEliminationID was 0, but the rival is dead. Bug?");
      if (this.StudentManager.Students[this.StudentManager.RivalID].Ragdoll.Hidden || !this.PoliceArrived)
      {
        Debug.Log((object) "The rival ''mysteriously disappeared''.");
        GameGlobals.RivalEliminationID = 11;
        GameGlobals.NonlethalElimination = false;
      }
      this.CheckForNatureOfDeath();
    }
    PlayerGlobals.Reputation = this.Reputation.Reputation;
    ClubGlobals.Club = this.Yandere.Club;
    StudentGlobals.MemorialStudents = 0;
    HomeGlobals.Night = true;
    this.Police.KillStudents();
    DateGlobals.PassDays = !this.Police.Suspended ? 1 : this.Police.SuspensionLength;
    if ((UnityEngine.Object) this.StudentManager.Students[StudentGlobals.StudentSlave] != (UnityEngine.Object) null && this.StudentManager.Students[StudentGlobals.StudentSlave].Ragdoll.enabled)
    {
      StudentGlobals.StudentSlave = 0;
      --StudentGlobals.Prisoners;
      switch (StudentGlobals.PrisonerChosen)
      {
        case 1:
          StudentGlobals.Prisoner1 = 0;
          break;
        case 2:
          StudentGlobals.Prisoner2 = 0;
          break;
        case 3:
          StudentGlobals.Prisoner3 = 0;
          break;
        case 4:
          StudentGlobals.Prisoner4 = 0;
          break;
        case 5:
          StudentGlobals.Prisoner5 = 0;
          break;
        case 6:
          StudentGlobals.Prisoner6 = 0;
          break;
        case 7:
          StudentGlobals.Prisoner7 = 0;
          break;
        case 8:
          StudentGlobals.Prisoner8 = 0;
          break;
        case 9:
          StudentGlobals.Prisoner9 = 0;
          break;
        case 10:
          StudentGlobals.Prisoner10 = 0;
          break;
      }
    }
    for (int elimID = 1; elimID < 11; ++elimID)
    {
      if (this.StudentManager.RivalKilledSelf[elimID])
      {
        GameGlobals.SetRivalEliminations(elimID, 10);
        GameGlobals.SetSpecificEliminations(elimID, 19);
      }
    }
    bool flag = DateGlobals.Weekday != DayOfWeek.Friday && this.StudentManager.SabotageProgress > this.StudentManager.InitialSabotageProgress;
    if (!this.TranqCase.Occupied)
    {
      if (this.GoToSuicideScene)
        SceneManager.LoadScene("SuicideScene");
      else if (flag)
        SceneManager.LoadScene("RivalRejectionProgressScene");
      else if (!this.StudentManager.Eighties && DateGlobals.Week > 1)
        SceneManager.LoadScene("WeekLimitScene");
      else
        SceneManager.LoadScene("HomeScene");
    }
    else
    {
      ++StudentGlobals.Prisoners;
      switch (StudentGlobals.Prisoners)
      {
        case 1:
          StudentGlobals.Prisoner1 = this.TranqCase.VictimID;
          break;
        case 2:
          StudentGlobals.Prisoner2 = this.TranqCase.VictimID;
          break;
        case 3:
          StudentGlobals.Prisoner3 = this.TranqCase.VictimID;
          break;
        case 4:
          StudentGlobals.Prisoner4 = this.TranqCase.VictimID;
          break;
        case 5:
          StudentGlobals.Prisoner5 = this.TranqCase.VictimID;
          break;
        case 6:
          StudentGlobals.Prisoner6 = this.TranqCase.VictimID;
          break;
        case 7:
          StudentGlobals.Prisoner7 = this.TranqCase.VictimID;
          break;
        case 8:
          StudentGlobals.Prisoner8 = this.TranqCase.VictimID;
          break;
        case 9:
          StudentGlobals.Prisoner9 = this.TranqCase.VictimID;
          break;
        case 10:
          StudentGlobals.Prisoner10 = this.TranqCase.VictimID;
          break;
      }
      StudentGlobals.SetStudentKidnapped(this.TranqCase.VictimID, true);
      StudentGlobals.SetStudentSanity(this.TranqCase.VictimID, 100);
      if (flag)
      {
        GameGlobals.JustKidnapped = true;
        SceneManager.LoadScene("RivalRejectionProgressScene");
      }
      else
        SceneManager.LoadScene("CalendarScene");
    }
    if (this.Dumpster.StudentToGoMissing > 0)
      this.Dumpster.SetVictimMissing();
    for (this.ID = 0; this.ID < this.GardenHoles.Length; ++this.ID)
      this.GardenHoles[this.ID].EndOfDayCheck();
    for (this.ID = 1; this.ID < this.Yandere.Inventory.ShrineCollectibles.Length; ++this.ID)
    {
      if (this.Yandere.Inventory.ShrineCollectibles[this.ID])
        PlayerGlobals.SetShrineCollectible(this.ID, true);
    }
    this.Incinerator.SetVictimsMissing();
    this.WoodChipper.SetVictimsMissing();
    if (this.FragileTarget > 0)
    {
      StudentGlobals.FragileTarget = this.FragileTarget;
      StudentGlobals.FragileSlave = 5;
    }
    if (this.StudentManager.ReactedToGameLeader)
      SchoolGlobals.ReactedToGameLeader = true;
    if (TaskGlobals.GetTaskStatus(46) == 1)
      TaskGlobals.SetTaskStatus(46, 0);
    if ((UnityEngine.Object) this.StudentManager.Students[46] != (UnityEngine.Object) null && this.StudentManager.Students[46].TaskPhase == 5)
    {
      TaskGlobals.SetTaskStatus(46, 3);
      PlayerGlobals.SetStudentFriend(46, true);
      ++this.NewFriends;
    }
    if (this.NewFriends > 0)
      PlayerGlobals.Friends += this.NewFriends;
    if (this.Yandere.Alerts > 0)
      PlayerGlobals.Alerts += this.Yandere.Alerts;
    if (this.Arrests > 0)
    {
      Debug.Log((object) "Increasing Atmosphere by 10% because a culprit was arrested.");
      SchoolGlobals.SchoolAtmosphere += (float) this.Arrests * 0.1f;
    }
    if (this.Counselor.ExpelledDelinquents)
      SchoolGlobals.SchoolAtmosphere += 0.25f;
    if (this.Yandere.Inventory.FakeID)
      PlayerGlobals.FakeID = true;
    if (this.RaibaruLoner)
      PlayerGlobals.RaibaruLoner = true;
    if (this.StopMourning)
      GameGlobals.SenpaiMourning = false;
    if (this.StudentManager.EmbarassingSecret)
    {
      SchemeGlobals.SetServicePurchased(4, true);
      SchemeGlobals.EmbarassingSecret = true;
    }
    EventGlobals.LearnedAboutPhotographer = this.LearnedAboutPhotographer;
    EventGlobals.OsanaEvent1 = this.LearnedOsanaInfo1;
    EventGlobals.OsanaEvent2 = this.LearnedOsanaInfo2;
    CollectibleGlobals.MatchmakingGifts = this.MatchmakingGifts;
    CollectibleGlobals.SenpaiGifts = this.SenpaiGifts;
    PlayerGlobals.PantyShots = this.Yandere.Inventory.PantyShots;
    PlayerGlobals.Money = this.Yandere.Inventory.Money;
    ClassGlobals.Biology = this.Class.Biology;
    ClassGlobals.Chemistry = this.Class.Chemistry;
    ClassGlobals.Language = this.Class.Language;
    ClassGlobals.Physical = this.Class.Physical;
    ClassGlobals.Psychology = this.Class.Psychology;
    ClassGlobals.BiologyGrade = this.Class.BiologyGrade;
    ClassGlobals.ChemistryGrade = this.Class.ChemistryGrade;
    ClassGlobals.LanguageGrade = this.Class.LanguageGrade;
    ClassGlobals.PhysicalGrade = this.Class.PhysicalGrade;
    ClassGlobals.PsychologyGrade = this.Class.PsychologyGrade;
    PlayerGlobals.Headset = this.Yandere.Inventory.Headset;
    PlayerGlobals.DirectionalMic = this.Yandere.Inventory.DirectionalMic;
    this.WeaponManager.TrackDumpedWeapons();
    this.StudentManager.CommunalLocker.RivalPhone.StolenPhoneDropoff.SetPhonesHacked();
    this.Yandere.PauseScreen.FavorMenu.ServicesMenu.SaveServicesPurchased();
    this.StudentManager.LoveManager.SaveSuitorInstructions();
    this.StudentManager.TaskManager.SaveTaskStatuses();
    this.StudentManager.SaveCollectibles();
    this.StudentManager.SavePantyshots();
    this.StudentManager.SaveReps();
    if (this.StudentManager.DatingMinigame.DataNeedsSaving)
      this.StudentManager.DatingMinigame.SaveTopicsAndCompliments();
    if (this.StudentManager.DatingMinigame.GiftStatusNeedsSaving)
      this.StudentManager.DatingMinigame.SaveGiftStatus();
    if (this.StudentManager.DialogueWheel.AdviceWindow.DataNeedsSaving)
      this.StudentManager.DialogueWheel.AdviceWindow.SaveTopicsAndCompliments();
    if (this.StudentManager.DialogueWheel.AdviceWindow.GiftDataNeedsSaving)
      this.StudentManager.DialogueWheel.AdviceWindow.SaveGiftStatus();
    if (SchemeGlobals.GetSchemeStage(6) == 8)
    {
      SchemeGlobals.SetSchemeStage(6, 9);
      this.Yandere.PauseScreen.Schemes.UpdateInstructions();
    }
    this.Yandere.CameraEffects.UpdateBloom(1f);
    this.Yandere.CameraEffects.UpdateBloomKnee(0.5f);
    this.Yandere.CameraEffects.UpdateBloomRadius(4f);
    DatingGlobals.RivalSabotaged = this.StudentManager.SabotageProgress;
    PlayerGlobals.PersonaID = this.Yandere.PersonaID;
    PlayerGlobals.CorpsesDiscovered += this.Police.Corpses;
    ClassGlobals.BonusStudyPoints = this.Class.StudyPoints + this.Class.BonusPoints;
    HomeGlobals.LateForSchool = false;
    PlayerGlobals.ShrineItems += this.ShrineItemsCollected;
    this.Counselor.SaveExcusesUsed();
    this.Counselor.ExpelStudents();
    this.Counselor.SaveCounselorData();
    StudentGlobals.ExpelProgress = this.Counselor.RivalExpelProgress;
    CounselorGlobals.ReportedAlcohol = this.Counselor.ReportedAlcohol;
    CounselorGlobals.ReportedCigarettes = this.Counselor.ReportedCigarettes;
    CounselorGlobals.ReportedCondoms = this.Counselor.ReportedCondoms;
    CounselorGlobals.ReportedTheft = this.Counselor.ReportedTheft;
    CounselorGlobals.ReportedCheating = this.Counselor.ReportedCheating;
    for (int ID = 1; ID < this.WeaponManager.BroughtWeapons.Length; ++ID)
    {
      if ((UnityEngine.Object) this.WeaponManager.BroughtWeapons[ID] == (UnityEngine.Object) null)
        PlayerGlobals.SetCannotBringItem(ID, true);
    }
    if (this.Yandere.Inventory.ArrivedWithRatPoison && this.Yandere.Inventory.EmeticPoisons == 0)
      PlayerGlobals.SetCannotBringItem(4, true);
    if (this.Yandere.Inventory.ArrivedWithSake && !this.Yandere.Inventory.Sake)
      PlayerGlobals.SetCannotBringItem(5, true);
    if (this.Yandere.Inventory.ArrivedWithCigs && !this.Yandere.Inventory.Cigs)
      PlayerGlobals.SetCannotBringItem(6, true);
    if (this.Yandere.Inventory.ArrivedWithCondoms && !this.Yandere.Inventory.Condoms)
      PlayerGlobals.SetCannotBringItem(7, true);
    if (this.Yandere.Inventory.ArrivedWithSedative && this.Yandere.Inventory.SedativePoisons == 0)
    {
      PlayerGlobals.SetCannotBringItem(9, true);
      PlayerGlobals.BoughtSedative = false;
    }
    if (this.Yandere.Inventory.ArrivedWithPoison && this.Yandere.Inventory.LethalPoisons == 0)
    {
      Debug.Log((object) "The player arrived with lethal poison. The player doesn't have lethal poison anymore.");
      PlayerGlobals.SetCannotBringItem(11, true);
      PlayerGlobals.BoughtPoison = false;
    }
    if (this.Yandere.Inventory.LethalPoisons > 0)
    {
      Debug.Log((object) "The player is bringing some poison home from school.");
      PlayerGlobals.BoughtPoison = true;
    }
    if (this.Yandere.Inventory.SedativePoisons > 0)
      PlayerGlobals.BoughtSedative = true;
    if (this.Yandere.Inventory.LockPick)
      PlayerGlobals.BoughtLockpick = true;
    if (this.Counselor.ReportedNarcotics)
      PlayerGlobals.BoughtNarcotics = false;
    if (this.ExplosiveDeviceUsed)
      PlayerGlobals.BoughtExplosive = false;
    if (this.Yandere.Inventory.Cigs)
      PlayerGlobals.SetCannotBringItem(6, false);
    if (this.Yandere.Inventory.Sake)
      PlayerGlobals.SetCannotBringItem(5, false);
    if (this.Yandere.Inventory.EmeticPoisons > 0)
      PlayerGlobals.SetCannotBringItem(4, false);
    if (this.Yandere.Inventory.SedativePoisons > 0)
    {
      PlayerGlobals.BoughtSedative = true;
      PlayerGlobals.SetCannotBringItem(9, false);
    }
    if (this.ArticleID == 1)
      PlayerGlobals.Reputation += (float) (20.0 * (1.0 + (double) ClassGlobals.LanguageGrade * 0.200000002980232));
    else if (this.ArticleID == 3)
      SchoolGlobals.SchoolAtmosphere += (float) (20.0 * (1.0 + (double) ClassGlobals.LanguageGrade * 0.200000002980232));
    if (GameGlobals.PoliceYesterday)
      ++PlayerGlobals.PoliceVisits;
    PlayerGlobals.BloodWitnessed += this.BloodWitnessed;
    PlayerGlobals.WeaponWitnessed += this.WeaponWitnessed;
    this.ClubManager.UpdateQuitClubs();
    StudentGlobals.UpdateRivalReputation = false;
    ClubGlobals.ActivitiesAttended = this.ClubManager.ActivitiesAttended;
    this.ArrestStudents();
    this.SaveTopicsLearned();
    this.RemovableItemManager.RemoveItems();
    this.Yandere.CameraEffects.UpdateVignette(0.0f);
  }

  private void DisableThings(StudentScript TargetStudent)
  {
    if (!((UnityEngine.Object) TargetStudent != (UnityEngine.Object) null))
      return;
    TargetStudent.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
    TargetStudent.CharacterAnimation.enabled = true;
    TargetStudent.CharacterAnimation.Play(TargetStudent.IdleAnim);
    TargetStudent.EmptyHands();
    TargetStudent.SpeechLines.Stop();
    TargetStudent.Ragdoll.Zs.SetActive(false);
    TargetStudent.SmartPhone.SetActive(false);
    TargetStudent.MyController.enabled = false;
    TargetStudent.ShoeRemoval.enabled = false;
    TargetStudent.enabled = false;
    TargetStudent.gameObject.SetActive(true);
    TargetStudent.transform.parent = this.transform;
    TargetStudent.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
  }

  private void CheckForNatureOfDeath()
  {
    if (!((UnityEngine.Object) this.StudentManager.Students[this.StudentManager.RivalID] != (UnityEngine.Object) null))
      return;
    RagdollScript ragdoll = this.StudentManager.Students[this.StudentManager.RivalID].Ragdoll;
    if (ragdoll.Student.DeathType == DeathType.Burning)
    {
      GameGlobals.SpecificEliminationID = 5;
      if (!GameGlobals.Debug)
        PlayerPrefs.SetInt("Burn", 1);
      Debug.Log((object) "The game knows that she was burned, though.");
    }
    else if (ragdoll.Student.DeathType == DeathType.Electrocution)
    {
      GameGlobals.SpecificEliminationID = 8;
      if (!GameGlobals.Debug)
        PlayerPrefs.SetInt("Electrocute", 1);
      Debug.Log((object) "The game knows that she was electrocuted, though.");
      Debug.Log((object) "The game should now be informing the Content Checklist that the player has performed an electrocution.");
    }
    else if (ragdoll.Student.DeathType == DeathType.Weight)
    {
      GameGlobals.SpecificEliminationID = 6;
      if (!GameGlobals.Debug)
        PlayerPrefs.SetInt("Crush", 1);
      Debug.Log((object) "The game knows that she was crushed, though.");
    }
    else if (ragdoll.Student.DeathType == DeathType.Drowning)
    {
      if (this.PoolEvent)
      {
        Debug.Log((object) "The player eliminated the rival during a pool event.");
        GameGlobals.SpecificEliminationID = 16;
        if (GameGlobals.Debug)
          return;
        PlayerPrefs.SetInt("Pool", 1);
      }
      else
      {
        Debug.Log((object) "The game knows that she drowned, though.");
        GameGlobals.SpecificEliminationID = 7;
        if (GameGlobals.Debug)
          return;
        PlayerPrefs.SetInt("Drown", 1);
      }
    }
    else if (ragdoll.Decapitated)
    {
      GameGlobals.SpecificEliminationID = 10;
      if (!GameGlobals.Debug)
        PlayerPrefs.SetInt("Fan", 1);
      Debug.Log((object) "The game knows that she was decapitated, though.");
    }
    else if (ragdoll.Student.DeathType == DeathType.Poison)
    {
      GameGlobals.SpecificEliminationID = 15;
      if (!GameGlobals.Debug)
        PlayerPrefs.SetInt("Poison", 1);
      Debug.Log((object) "The game knows that she was poisoned, though.");
    }
    else if (ragdoll.Student.DeathType == DeathType.Falling)
    {
      GameGlobals.SpecificEliminationID = 17;
      if (!GameGlobals.Debug)
        PlayerPrefs.SetInt("Push", 1);
      Debug.Log((object) "The game knows that she was pushed, though.");
    }
    else if (ragdoll.Student.Hunted)
    {
      GameGlobals.SpecificEliminationID = 14;
      if (!GameGlobals.Debug)
      {
        if (ragdoll.Student.MurderedByFragile)
          PlayerPrefs.SetInt("DrivenToMurder", 1);
        else
          PlayerPrefs.SetInt("MurderSuicide", 1);
      }
      Debug.Log((object) "The game knows that the rival died as part of a murder-suicide, though.");
    }
    else if (ragdoll.Student.DeathType == DeathType.Weapon)
    {
      GameGlobals.SpecificEliminationID = 1;
      if (!GameGlobals.Debug)
        PlayerPrefs.SetInt("Attack", 1);
      Debug.Log((object) "The game knows that she was attacked, though.");
    }
    else
    {
      if (ragdoll.Student.DeathType != DeathType.Explosion)
        return;
      GameGlobals.SpecificEliminationID = 20;
      Debug.Log((object) "The game knows that she was blown up, though.");
    }
  }

  public void SetFormerRivalDeath(int RivalID, StudentScript Rival)
  {
    Debug.Log((object) ("The elimination information for Rival #" + RivalID.ToString() + " is now being updated."));
    if (Rival.DeathType == DeathType.Burning)
      GameGlobals.SetSpecificEliminations(RivalID, 5);
    else if (Rival.DeathType == DeathType.Electrocution)
      GameGlobals.SetSpecificEliminations(RivalID, 8);
    else if (Rival.DeathType == DeathType.Weight)
      GameGlobals.SetSpecificEliminations(RivalID, 6);
    else if (Rival.DeathType == DeathType.Drowning)
    {
      if (this.PoolEvent)
        GameGlobals.SetSpecificEliminations(RivalID, 16);
      else
        GameGlobals.SetSpecificEliminations(RivalID, 7);
    }
    else if (Rival.Ragdoll.Decapitated)
      GameGlobals.SetSpecificEliminations(RivalID, 10);
    else if (Rival.DeathType == DeathType.Poison)
      GameGlobals.SetSpecificEliminations(RivalID, 15);
    else if (Rival.DeathType == DeathType.Falling)
      GameGlobals.SetSpecificEliminations(RivalID, 17);
    else if (Rival.Hunted)
      GameGlobals.SetSpecificEliminations(RivalID, 14);
    else if (Rival.DeathType == DeathType.Weapon)
      GameGlobals.SetSpecificEliminations(RivalID, 1);
    GameGlobals.SetRivalEliminations(RivalID, 14);
  }

  public void ArrestStudents()
  {
    for (int studentID = 1; studentID < 101; ++studentID)
    {
      if (this.StudentsToArrest[studentID])
        StudentGlobals.SetStudentArrested(studentID, true);
    }
  }

  public void SaveTopicsLearned()
  {
    for (int index1 = 1; index1 < 101; ++index1)
    {
      for (int index2 = 1; index2 < 26; ++index2)
        ConversationGlobals.SetTopicLearnedByStudent(index2, index1, this.StudentManager.GetTopicLearnedByStudent(index2, index1));
    }
  }
}
