// Decompiled with JetBrains decompiler
// Type: NemesisScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

public class NemesisScript : MonoBehaviour
{
  public MissionModeScript MissionMode;
  public CosmeticScript Cosmetic;
  public StudentScript Student;
  public YandereScript Yandere;
  public AudioClip YandereDeath;
  public Texture NemesisUniform;
  public Texture NemesisFace;
  public Texture NemesisEyes;
  public GameObject BloodEffect;
  public GameObject NemesisHair;
  public GameObject Knife;
  public bool PutOnDisguise;
  public bool Aggressive;
  public bool Attacking;
  public bool Chasing;
  public bool InView;
  public bool Dying;
  public int EffectPhase;
  public int Difficulty;
  public int Frame;
  public int ID;
  public float OriginalYPosition;
  public float ScanTimer = 6f;

  private void Start()
  {
    foreach (GameObject gameObject in this.Cosmetic.FemaleHair)
    {
      if ((Object) gameObject != (Object) null)
        gameObject.SetActive(false);
    }
    foreach (GameObject gameObject in this.Cosmetic.TeacherHair)
    {
      if ((Object) gameObject != (Object) null)
        gameObject.SetActive(false);
    }
    foreach (GameObject femaleAccessory in this.Cosmetic.FemaleAccessories)
    {
      if ((Object) femaleAccessory != (Object) null)
        femaleAccessory.SetActive(false);
    }
    foreach (GameObject teacherAccessory in this.Cosmetic.TeacherAccessories)
    {
      if ((Object) teacherAccessory != (Object) null)
        teacherAccessory.SetActive(false);
    }
    foreach (GameObject clubAccessory in this.Cosmetic.ClubAccessories)
    {
      if ((Object) clubAccessory != (Object) null)
        clubAccessory.SetActive(false);
    }
    foreach (GameObject kerchief in this.Cosmetic.Kerchiefs)
    {
      if ((Object) kerchief != (Object) null)
        kerchief.SetActive(false);
    }
    foreach (GameObject catGift in this.Cosmetic.CatGifts)
    {
      if ((Object) catGift != (Object) null)
        catGift.SetActive(false);
    }
    foreach (GameObject ring in this.Cosmetic.Rings)
    {
      if ((Object) ring != (Object) null)
        ring.SetActive(false);
    }
    this.Difficulty = MissionModeGlobals.NemesisDifficulty;
    if (this.Difficulty == 0)
      this.Difficulty = 1;
    this.Student.StudentManager = GameObject.Find("StudentManager").GetComponent<StudentManagerScript>();
    this.Student.WitnessCamera = GameObject.Find("WitnessCamera").GetComponent<WitnessCameraScript>();
    this.Student.Police = GameObject.Find("Police").GetComponent<PoliceScript>();
    this.Student.JSON = GameObject.Find("JSON").GetComponent<JsonScript>();
    this.Student.CharacterAnimation = this.Student.Character.GetComponent<Animation>();
    this.Student.Ragdoll.Nemesis = true;
    this.Student.Yandere = this.Yandere;
    this.Student.IdleAnim = "f02_newIdle_00";
    this.Student.WalkAnim = "f02_newWalk_00";
    this.Student.ShoeRemoval.RightCasualShoe.gameObject.SetActive(false);
    this.Student.ShoeRemoval.LeftCasualShoe.gameObject.SetActive(false);
    if (this.Difficulty < 3)
    {
      this.Student.Character.GetComponent<Animation>()["f02_nemesisEyes_00"].layer = 2;
      this.Student.Character.GetComponent<Animation>().Play("f02_nemesisEyes_00");
      this.Cosmetic.MyRenderer.sharedMesh = this.Cosmetic.FemaleUniforms[5];
      this.Cosmetic.MyRenderer.materials[0].mainTexture = this.NemesisUniform;
      this.Cosmetic.MyRenderer.materials[1].mainTexture = this.NemesisUniform;
      this.Cosmetic.MyRenderer.materials[2].mainTexture = this.NemesisFace;
      this.Cosmetic.RightEyeRenderer.material.mainTexture = this.NemesisEyes;
      this.Cosmetic.LeftEyeRenderer.material.mainTexture = this.NemesisEyes;
      this.Student.FaceCollider.tag = "Nemesis";
      this.NemesisHair.SetActive(true);
    }
    else
    {
      this.NemesisHair.SetActive(false);
      this.PutOnDisguise = true;
    }
    this.Student.LowPoly.enabled = false;
    this.Student.DisableEffects();
    this.HideObjects();
    for (this.ID = 0; this.ID < this.Student.Ragdoll.AllRigidbodies.Length; ++this.ID)
    {
      this.Student.Ragdoll.AllRigidbodies[this.ID].isKinematic = true;
      this.Student.Ragdoll.AllColliders[this.ID].enabled = false;
    }
    this.Student.Ragdoll.AllColliders[10].enabled = true;
    this.Student.Prompt.HideButton[0] = true;
    this.Student.Prompt.HideButton[2] = true;
    Object.Destroy((Object) this.Student.MyRigidbody);
    this.transform.position = this.MissionMode.SpawnPoints[Random.Range(0, 4)].position;
    this.MissionMode.LastKnownPosition.position = new Vector3(0.0f, 0.0f, -36f);
    this.UpdateLKP();
    this.transform.parent = (Transform) null;
    this.Student.Name = "Nemesis";
    this.Aggressive = MissionModeGlobals.NemesisAggression;
  }

  private void Update()
  {
    if (this.Frame > 1)
    {
      this.Student.FaceCollider.enabled = true;
      if (this.PutOnDisguise)
      {
        Debug.Log((object) "Nemesis is supposed to be choosing a disguise right now.");
        bool flag = false;
        int index1 = 1;
        while ((((Object) this.Student.StudentManager.Students[index1] != (Object) null && this.Student.StudentManager.Students[index1].Male || index1 > 5 && index1 < 21 || index1 == 21 || index1 == 26 || index1 == 31 || index1 == 36 || index1 == 41 || index1 == 46 || index1 == 51 || index1 == 56 || index1 == 61 || index1 == 66 || index1 == 71 ? 1 : (index1 == this.MissionMode.TargetID ? 1 : 0)) | (flag ? 1 : 0)) != 0)
        {
          index1 = 86;
          if (this.MissionMode.MultiMission)
          {
            flag = false;
            for (int index2 = 1; index2 < 11; ++index2)
            {
              if (index1 == PlayerPrefs.GetInt("MissionModeTarget" + index2.ToString()))
                flag = true;
            }
          }
        }
        Debug.Log((object) ("Nemesis is replacing Student# " + index1.ToString() + " - " + this.Student.StudentManager.Students[index1].Name));
        this.Student.StudentManager.Students[index1].gameObject.SetActive(false);
        this.Student.StudentManager.Students[index1].Replaced = true;
        this.Cosmetic.StudentID = index1;
        this.Cosmetic.Start();
        if (this.Student.StudentManager.Students[index1].Club != ClubType.Council)
        {
          Debug.Log((object) "Not council member. Putting on black blazer.");
          this.Cosmetic.MyRenderer.materials[0].mainTexture = this.Cosmetic.FemaleUniformTextures[5];
          this.Cosmetic.MyRenderer.materials[1].mainTexture = this.Cosmetic.FemaleUniformTextures[5];
        }
        else
        {
          Debug.Log((object) "Council member. Attempting to put on white blazer.");
          this.Cosmetic.MyRenderer.materials[0].mainTexture = this.Cosmetic.FemaleUniformTextures[7];
          this.Cosmetic.MyRenderer.materials[1].mainTexture = this.Cosmetic.FemaleUniformTextures[7];
        }
        OutlineScript component1 = this.Cosmetic.FemaleHair[this.Cosmetic.Hairstyle].GetComponent<OutlineScript>();
        if ((Object) component1 != (Object) null)
        {
          component1.enabled = false;
        }
        else
        {
          OutlineScript component2 = this.Cosmetic.FemaleHairRenderers[this.Cosmetic.Hairstyle].GetComponent<OutlineScript>();
          if ((Object) component2 != (Object) null)
            component2.enabled = false;
        }
        this.Student.FaceCollider.tag = "Disguise";
        Debug.Log((object) ("As of now, Nemesis should have disguised herself as " + this.Student.StudentManager.Students[index1].Name));
        this.PutOnDisguise = false;
      }
    }
    ++this.Frame;
    if (!this.Dying)
    {
      if (!this.Attacking)
      {
        if (this.Yandere.Laughing && (double) Vector3.Distance(this.transform.position, this.Yandere.transform.position) < 10.0)
        {
          this.MissionMode.LastKnownPosition.position = this.Yandere.transform.position;
          this.UpdateLKP();
        }
        if (!this.Yandere.CanMove && !this.Yandere.Laughing)
        {
          if (this.Student.Pathfinding.canSearch)
          {
            this.Student.Character.GetComponent<Animation>().CrossFade("f02_idleShort_00");
            this.Student.Pathfinding.canSearch = false;
            this.Student.Pathfinding.canMove = false;
            this.Student.Pathfinding.speed = 0.0f;
          }
        }
        else
        {
          if (this.Yandere.Stance.Current != StanceType.Crouching && this.Yandere.Stance.Current != StanceType.Crawling && (double) Vector3.Distance(this.transform.position, this.Yandere.transform.position) < 10.0 && this.Yandere.Running)
          {
            this.MissionMode.LastKnownPosition.position = this.Yandere.transform.position;
            this.UpdateLKP();
          }
          if (!this.Student.Pathfinding.canSearch)
          {
            if (!this.Chasing)
            {
              this.Student.Character.GetComponent<Animation>().CrossFade(this.Student.WalkAnim);
              this.Student.Pathfinding.speed = 1f;
            }
            else
            {
              this.Student.Character.GetComponent<Animation>().CrossFade("f02_sithRun_00");
              this.Student.Pathfinding.speed = 5f;
            }
            this.Student.Pathfinding.canSearch = true;
            this.Student.Pathfinding.canMove = true;
          }
          this.InView = false;
          this.LookForYandere();
          if (!this.Chasing)
          {
            this.Student.Pathfinding.speed = Mathf.MoveTowards(this.Student.Pathfinding.speed, this.InView ? 2f : 1f, Time.deltaTime * 0.1f);
            this.Student.Character.GetComponent<Animation>()[this.Student.WalkAnim].speed = this.Student.Pathfinding.speed;
          }
          else
            this.Student.Pathfinding.speed = 5f;
          if ((double) Vector3.Distance(this.transform.position, this.Yandere.transform.position) < 1.0)
          {
            if (this.InView || this.Chasing)
            {
              this.Student.CharacterAnimation.CrossFade("f02_knifeLowSanityA_00");
              this.Yandere.CharacterAnimation.CrossFade("f02_knifeLowSanityB_00");
              AudioSource.PlayClipAtPoint(this.YandereDeath, this.transform.position);
              this.Student.Pathfinding.canSearch = false;
              this.Student.Pathfinding.canMove = false;
              this.Knife.SetActive(true);
              this.Attacking = true;
              this.OriginalYPosition = this.Yandere.transform.position.y;
              this.Yandere.StudentManager.YandereDying = true;
              this.Yandere.StudentManager.StopMoving();
              this.GetComponent<AudioSource>().Play();
              this.Yandere.YandereVision = false;
              this.Yandere.FollowHips = true;
              this.Yandere.Laughing = false;
              this.Yandere.CanMove = false;
              this.Yandere.EyeShrink = 0.5f;
              this.Yandere.StopAiming();
              this.Yandere.EmptyHands();
            }
          }
          else if ((double) Vector3.Distance(this.transform.position, this.MissionMode.LastKnownPosition.position) < 1.0)
          {
            this.Student.Character.GetComponent<Animation>().CrossFade("f02_nemesisScan_00");
            this.Student.Pathfinding.speed = 0.0f;
            this.ScanTimer += Time.deltaTime;
            if ((double) this.ScanTimer > 6.0)
            {
              Vector3 vector3 = new Vector3(0.0f, 0.0f, -2.5f);
              this.MissionMode.LastKnownPosition.position = this.MissionMode.LastKnownPosition.position == vector3 ? this.Yandere.transform.position : vector3;
              this.Chasing = false;
              this.UpdateLKP();
            }
          }
        }
        if (this.Difficulty != 1 && this.Difficulty != 3)
          return;
        if ((double) Vector3.Distance(this.transform.position, this.Yandere.transform.position) < 1.0)
        {
          if ((double) Mathf.Abs(Vector3.Angle(-this.transform.forward, this.Yandere.transform.position - this.transform.position)) > 45.0)
            this.Student.Prompt.HideButton[2] = true;
          else if (this.Yandere.Armed)
            this.Student.Prompt.HideButton[2] = false;
          if (!this.Yandere.Armed)
            this.Student.Prompt.HideButton[2] = true;
          if ((double) this.Student.Prompt.Circle[2].fillAmount >= 1.0)
            return;
          this.Yandere.TargetStudent = this.Student;
          this.Yandere.AttackManager.Stealth = true;
          this.Student.AttackReaction();
          this.Student.Pathfinding.canSearch = false;
          this.Student.Pathfinding.canMove = false;
          this.Student.Prompt.HideButton[2] = true;
          this.Dying = true;
        }
        else
          this.Student.Prompt.HideButton[2] = true;
      }
      else
      {
        this.SpecialEffect();
        this.Yandere.targetRotation = Quaternion.LookRotation(this.transform.position - this.Yandere.transform.position);
        this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.Yandere.targetRotation, Time.deltaTime * 10f);
        this.Yandere.MoveTowardsTarget(this.transform.position + this.transform.forward * 0.5f);
        this.Yandere.EyeShrink = 0.5f;
        this.Yandere.transform.position = new Vector3(this.Yandere.transform.position.x, this.OriginalYPosition, this.Yandere.transform.position.z);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(this.Yandere.transform.position - this.transform.position), Time.deltaTime * 10f);
        Animation component = this.Student.Character.GetComponent<Animation>();
        if ((double) component["f02_knifeLowSanityA_00"].time < (double) component["f02_knifeLowSanityA_00"].length)
          return;
        if (this.MissionMode.enabled)
        {
          this.MissionMode.GameOverID = 13;
          this.MissionMode.GameOver();
          this.MissionMode.Phase = 4;
          this.enabled = false;
        }
        else
          SceneManager.LoadScene("LoadingScene");
      }
    }
    else if (this.Student.Alive)
    {
      this.Student.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward * this.Yandere.AttackManager.Distance);
      this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(this.transform.position - new Vector3(this.Yandere.transform.position.x, this.transform.position.y, this.Yandere.transform.position.z)), Time.deltaTime * 10f);
    }
    else
      this.enabled = false;
  }

  private void LookForYandere()
  {
    this.Student.VisionDistance = 25f;
    if (!this.Student.CanSeeObject(this.Yandere.gameObject, this.Yandere.HeadPosition))
      return;
    this.MissionMode.LastKnownPosition.position = this.Yandere.transform.position;
    this.InView = true;
    this.UpdateLKP();
    if (!this.Aggressive)
      return;
    this.Chasing = true;
  }

  private void UpdateLKP()
  {
    if (!this.Chasing)
      this.Student.Character.GetComponent<Animation>().CrossFade(this.Student.WalkAnim);
    else
      this.Student.Character.GetComponent<Animation>().CrossFade("f02_sithRun_00");
    if ((double) this.Student.Pathfinding.speed == 0.0)
      this.Student.Pathfinding.speed = this.Chasing ? 5f : 1f;
    this.ScanTimer = 0.0f;
    this.InView = true;
  }

  private void SpecialEffect()
  {
    Animation component = this.Student.Character.GetComponent<Animation>();
    if (this.EffectPhase == 0)
    {
      if ((double) component["f02_knifeLowSanityA_00"].time <= 2.7666666507720947)
        return;
      Object.Instantiate<GameObject>(this.BloodEffect, this.Knife.transform.position + this.Knife.transform.forward * 0.1f, Quaternion.identity);
      ++this.EffectPhase;
    }
    else if (this.EffectPhase == 1)
    {
      if ((double) component["f02_knifeLowSanityA_00"].time <= 3.5333333015441895)
        return;
      Object.Instantiate<GameObject>(this.BloodEffect, this.Knife.transform.position + this.Knife.transform.forward * 0.1f, Quaternion.identity);
      ++this.EffectPhase;
    }
    else
    {
      if (this.EffectPhase != 2 || (double) component["f02_knifeLowSanityA_00"].time <= 4.1666665077209473)
        return;
      Object.Instantiate<GameObject>(this.BloodEffect, this.Knife.transform.position + this.Knife.transform.forward * 0.1f, Quaternion.identity);
      ++this.EffectPhase;
    }
  }

  private void HideObjects()
  {
    this.Student.Cosmetic.RightStockings[0].SetActive(false);
    this.Student.Cosmetic.LeftStockings[0].SetActive(false);
    this.Student.Cosmetic.RightWristband.SetActive(false);
    this.Student.Cosmetic.LeftWristband.SetActive(false);
    this.Student.FollowCountdown.gameObject.SetActive(false);
    this.Student.DramaticCamera.gameObject.SetActive(false);
    this.Student.VomitEmitter.gameObject.SetActive(false);
    this.Student.Countdown.gameObject.SetActive(false);
    this.Student.ScienceProps[0].SetActive(false);
    this.Student.Chopsticks[0].SetActive(false);
    this.Student.Chopsticks[1].SetActive(false);
    this.Student.Handkerchief.SetActive(false);
    this.Student.ChaseCamera.SetActive(false);
    this.Student.PepperSpray.SetActive(false);
    this.Student.WateringCan.SetActive(false);
    this.Student.OccultBook.SetActive(false);
    this.Student.Cigarette.SetActive(false);
    this.Student.EventBook.SetActive(false);
    this.Student.Handcuffs.SetActive(false);
    this.Student.CandyBar.SetActive(false);
    this.Student.Scrubber.SetActive(false);
    this.Student.Lighter.SetActive(false);
    this.Student.Octodog.SetActive(false);
    this.Student.Eraser.SetActive(false);
    this.Student.Bento.SetActive(false);
    this.Student.Pen.SetActive(false);
    this.Student.SpeechLines.Stop();
    this.Student.InstrumentBag[1].SetActive(false);
    this.Student.InstrumentBag[2].SetActive(false);
    this.Student.InstrumentBag[3].SetActive(false);
    this.Student.InstrumentBag[4].SetActive(false);
    this.Student.InstrumentBag[5].SetActive(false);
    this.Student.Instruments[1].SetActive(false);
    this.Student.Instruments[2].SetActive(false);
    this.Student.Instruments[3].SetActive(false);
    this.Student.Instruments[4].SetActive(false);
    this.Student.Instruments[5].SetActive(false);
    this.Student.Drumsticks[0].SetActive(false);
    this.Student.Drumsticks[1].SetActive(false);
    this.Student.Cosmetic.ThickBrows.SetActive(false);
    this.Student.RetroCamera.SetActive(false);
    this.Student.WeaponBag.SetActive(false);
    foreach (ParticleSystem splashEmitter in this.Student.SplashEmitters)
    {
      if ((Object) splashEmitter != (Object) null)
        splashEmitter.gameObject.SetActive(false);
    }
    foreach (GameObject scienceProp in this.Student.ScienceProps)
    {
      if ((Object) scienceProp != (Object) null)
        scienceProp.SetActive(false);
    }
    foreach (GameObject punkAccessory in this.Student.Cosmetic.PunkAccessories)
    {
      if ((Object) punkAccessory != (Object) null)
        punkAccessory.SetActive(false);
    }
    foreach (GameObject gameObject in this.Student.Fingerfood)
    {
      if ((Object) gameObject != (Object) null)
        gameObject.SetActive(false);
    }
  }
}
