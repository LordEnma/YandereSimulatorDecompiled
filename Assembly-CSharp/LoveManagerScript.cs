// Decompiled with JetBrains decompiler
// Type: LoveManagerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class LoveManagerScript : MonoBehaviour
{
  public ConfessionManagerScript ConfessionManager;
  public AppearanceWindowScript AppearanceWindow;
  public ConfessionSceneScript ConfessionScene;
  public StudentManagerScript StudentManager;
  public YandereScript Yandere;
  public ClockScript Clock;
  public StudentScript Follower;
  public StudentScript Suitor;
  public StudentScript Rival;
  public Transform FriendWaitSpot;
  public Transform[] Targets;
  public Transform MythHill;
  public int SuitorProgress;
  public int TotalTargets;
  public int Phase = 1;
  public int ID;
  public int SuitorID = 28;
  public int RivalID = 30;
  public float AngleLimit;
  public bool WaitingToConfess;
  public bool ConfessToSuitor;
  public bool HoldingHands;
  public bool RivalWaiting;
  public bool LeftNote;
  public bool Courted;
  public bool CustomSuitorBlack;
  public bool CustomSuitorTan;
  public bool CustomSuitor;
  public int CustomSuitorAccessory;
  public int CustomSuitorEyewear;
  public int CustomSuitorJewelry;
  public int CustomSuitorHair;

  private void Start()
  {
    int week = DateGlobals.Week;
    if (week > 10)
    {
      this.gameObject.SetActive(false);
    }
    else
    {
      this.SuitorProgress = DatingGlobals.SuitorProgress;
      this.CustomSuitorAccessory = StudentGlobals.CustomSuitorAccessory;
      this.CustomSuitorEyewear = StudentGlobals.CustomSuitorEyewear;
      this.CustomSuitorJewelry = StudentGlobals.CustomSuitorJewelry;
      this.CustomSuitorBlack = StudentGlobals.CustomSuitorBlack;
      this.CustomSuitorHair = StudentGlobals.CustomSuitorHair;
      this.CustomSuitorTan = StudentGlobals.CustomSuitorTan;
      this.CustomSuitor = StudentGlobals.CustomSuitor;
      if (GameGlobals.Eighties)
      {
        this.SuitorID = this.StudentManager.SuitorIDs[week];
        this.RivalID = 10 + week;
        if ((double) DatingGlobals.Affection < (double) (week * 10))
          return;
        this.ConfessToSuitor = true;
      }
      else
      {
        this.SuitorID = 6;
        this.RivalID = 11;
        if ((double) DatingGlobals.Affection != 100.0)
          return;
        this.ConfessToSuitor = true;
      }
    }
  }

  private void LateUpdate()
  {
    if ((Object) this.Yandere.Follower != (Object) null && this.Yandere.Follower.StudentID == this.StudentManager.RivalID)
    {
      this.Follower = this.Yandere.Follower;
      for (this.ID = 0; this.ID < this.TotalTargets; ++this.ID)
      {
        Transform target = this.Targets[this.ID];
        if ((Object) target != (Object) null && (double) this.Follower.transform.position.y > (double) target.position.y - 2.0 && (double) this.Follower.transform.position.y < (double) target.position.y + 2.0 && (double) Vector3.Distance(this.Follower.transform.position, new Vector3(target.position.x, this.Follower.transform.position.y, target.position.z)) < 2.5)
        {
          if ((double) Mathf.Abs(Vector3.Angle(this.Follower.transform.forward, this.Follower.transform.position - new Vector3(target.position.x, this.Follower.transform.position.y, target.position.z))) > (double) this.AngleLimit)
          {
            if (!this.Follower.Gush)
            {
              this.Follower.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", 1f);
              this.Follower.GushTarget = target;
              ParticleSystem.EmissionModule emission = this.Follower.Hearts.emission with
              {
                enabled = true,
                rateOverTime = (ParticleSystem.MinMaxCurve) 5f
              };
              this.Follower.Hearts.Play();
              this.Follower.Gush = true;
            }
          }
          else
          {
            this.Follower.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", 0.0f);
            this.Follower.Hearts.emission.enabled = false;
            this.Follower.Gush = false;
          }
        }
      }
    }
    if (this.LeftNote)
    {
      if ((Object) this.Rival == (Object) null)
        this.Rival = this.StudentManager.Students[this.RivalID];
      if ((Object) this.Suitor == (Object) null)
        this.Suitor = !this.ConfessToSuitor ? this.StudentManager.Students[1] : this.StudentManager.Students[this.SuitorID];
      if ((Object) this.Rival != (Object) null && (Object) this.Suitor != (Object) null && this.Rival.Alive && this.Suitor.Alive && !this.Rival.Dying && !this.Suitor.Dying && this.Rival.ConfessPhase == 5 && this.Suitor.ConfessPhase == 3)
      {
        this.WaitingToConfess = true;
        float num = Vector3.Distance(this.Yandere.transform.position, this.MythHill.position);
        if (this.WaitingToConfess && !this.Yandere.Chased && this.Yandere.Chasers == 0 && !this.Yandere.Noticed && (double) num > 10.0 && (double) num < 25.0)
          this.BeginConfession();
      }
    }
    if (!this.HoldingHands)
      return;
    if ((Object) this.Rival == (Object) null)
      this.Rival = this.StudentManager.Students[this.RivalID];
    if ((Object) this.Suitor == (Object) null)
      this.Suitor = this.StudentManager.Students[this.SuitorID];
    int num1 = (int) this.Rival.MyController.Move(this.transform.forward * Time.deltaTime);
    this.Suitor.transform.position = new Vector3(this.Rival.transform.position.x - 0.5f, this.Rival.transform.position.y, this.Rival.transform.position.z);
    if ((double) this.Rival.transform.position.z <= -50.0)
      return;
    this.Suitor.MyController.radius = 0.12f;
    this.Suitor.enabled = true;
    this.Suitor.Cosmetic.MyRenderer.materials[this.Suitor.Cosmetic.FaceID].SetFloat("_BlendAmount", 0.0f);
    this.Suitor.Hearts.emission.enabled = false;
    this.Rival.MyController.radius = 0.12f;
    this.Rival.enabled = true;
    this.Rival.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", 0.0f);
    this.Rival.Hearts.emission.enabled = false;
    this.Suitor.HoldingHands = false;
    this.Rival.HoldingHands = false;
    this.HoldingHands = false;
  }

  public void CoupleCheck()
  {
    if (this.SuitorProgress != 2)
      return;
    this.Rival = this.StudentManager.Students[this.RivalID];
    this.Suitor = this.StudentManager.Students[this.SuitorID];
    if (!((Object) this.Rival != (Object) null) || !((Object) this.Suitor != (Object) null))
      return;
    this.Suitor.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
    this.Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
    this.Suitor.CharacterAnimation.enabled = true;
    this.Rival.CharacterAnimation.enabled = true;
    this.Suitor.CharacterAnimation.Play("walkHands_00");
    this.Suitor.transform.eulerAngles = Vector3.zero;
    this.Suitor.transform.position = new Vector3(-0.25f, 0.0f, -90f);
    this.Suitor.Pathfinding.canSearch = false;
    this.Suitor.Pathfinding.canMove = false;
    this.Suitor.MyController.radius = 0.0f;
    this.Suitor.enabled = false;
    this.Rival.CharacterAnimation.Play("f02_walkHands_00");
    this.Rival.transform.eulerAngles = Vector3.zero;
    this.Rival.transform.position = new Vector3(0.25f, 0.0f, -90f);
    this.Rival.Pathfinding.canSearch = false;
    this.Rival.Pathfinding.canMove = false;
    this.Rival.MyController.radius = 0.0f;
    this.Rival.enabled = false;
    Physics.SyncTransforms();
    this.Suitor.Cosmetic.MyRenderer.materials[this.Suitor.Cosmetic.FaceID].SetFloat("_BlendAmount", 1f);
    ParticleSystem.EmissionModule emission1 = this.Suitor.Hearts.emission with
    {
      enabled = true,
      rateOverTime = (ParticleSystem.MinMaxCurve) 5f
    };
    this.Suitor.Hearts.Play();
    this.Rival.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", 1f);
    ParticleSystem.EmissionModule emission2 = this.Rival.Hearts.emission with
    {
      enabled = true,
      rateOverTime = (ParticleSystem.MinMaxCurve) 5f
    };
    this.Rival.Hearts.Play();
    this.Suitor.HoldingHands = true;
    this.Rival.HoldingHands = true;
    this.Suitor.PartnerID = this.RivalID;
    this.Rival.PartnerID = this.SuitorID;
    this.HoldingHands = true;
    Debug.Log((object) "Students are now holding hands.");
  }

  public void BeginConfession()
  {
    Debug.Log((object) "Confession is being told to begin.");
    Time.timeScale = 1f;
    this.Suitor.EmptyHands();
    this.Rival.EmptyHands();
    if (this.Yandere.Aiming)
      this.Yandere.StopAiming();
    if (this.Yandere.YandereVision)
    {
      this.Yandere.ResetYandereEffects();
      this.Yandere.YandereVision = false;
    }
    this.Yandere.CharacterAnimation.CrossFade(this.Yandere.IdleAnim);
    this.Yandere.RPGCamera.enabled = false;
    this.Yandere.CanMove = false;
    this.StudentManager.DisableEveryone();
    this.Suitor.gameObject.SetActive(true);
    this.Rival.gameObject.SetActive(true);
    this.Suitor.enabled = false;
    this.Rival.enabled = false;
    if (!this.ConfessToSuitor)
    {
      this.ConfessionManager.Senpai = this.StudentManager.Students[1].CharacterAnimation;
      this.ConfessionManager.gameObject.SetActive(true);
    }
    else
      this.ConfessionScene.enabled = true;
    this.Clock.Police.gameObject.SetActive(false);
    this.WaitingToConfess = false;
    this.Clock.StopTime = true;
    this.LeftNote = false;
  }

  public void SaveSuitorInstructions()
  {
    StudentGlobals.CustomSuitorAccessory = this.CustomSuitorAccessory;
    StudentGlobals.CustomSuitorEyewear = this.CustomSuitorEyewear;
    StudentGlobals.CustomSuitorJewelry = this.CustomSuitorJewelry;
    StudentGlobals.CustomSuitorBlack = this.CustomSuitorBlack;
    StudentGlobals.CustomSuitorHair = this.CustomSuitorHair;
    StudentGlobals.CustomSuitorTan = this.CustomSuitorTan;
    StudentGlobals.CustomSuitor = this.CustomSuitor;
    DatingGlobals.SetSuitorCheck(1, this.AppearanceWindow.Checks[1].enabled);
    DatingGlobals.SetSuitorCheck(2, this.AppearanceWindow.Checks[2].enabled);
    DatingGlobals.SetSuitorCheck(3, this.AppearanceWindow.Checks[3].enabled);
    DatingGlobals.SetSuitorCheck(4, this.AppearanceWindow.Checks[4].enabled);
    DatingGlobals.SetSuitorCheck(5, this.AppearanceWindow.Checks[5].enabled);
    DatingGlobals.SetSuitorCheck(6, this.AppearanceWindow.Checks[6].enabled);
    DatingGlobals.SetSuitorCheck(7, this.AppearanceWindow.Checks[7].enabled);
    DatingGlobals.SetSuitorCheck(8, this.AppearanceWindow.Checks[8].enabled);
    DatingGlobals.SetSuitorCheck(9, this.AppearanceWindow.Checks[9].enabled);
  }
}
