// Decompiled with JetBrains decompiler
// Type: CombatMinigameScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CombatMinigameScript : MonoBehaviour
{
  public UISprite[] ButtonPrompts;
  public UISprite Circle;
  public UISprite BG;
  public GameObject HitEffect;
  public PracticeWindowScript PracticeWindow;
  public StudentScript Delinquent;
  public YandereScript Yandere;
  public Transform CombatTarget;
  public Transform MainCamera;
  public Transform Midpoint;
  public Vector3 CameraTarget;
  public Vector3 CameraStart;
  public Vector3 StartPoint;
  public UITexture RedVignette;
  public UILabel Label;
  public string CurrentButton;
  public float SlowdownFactor;
  public float ShakeFactor;
  public float Difficulty;
  public float StartTime;
  public float Strength;
  public float Shake;
  public float Timer;
  public bool ExitSchoolWhenDone;
  public bool KnockedOut;
  public bool Practice;
  public bool Success;
  public bool Zoom;
  public string StopFightingAnim;
  public string Prefix;
  public int ButtonID;
  public int Strike;
  public int Phase;
  public int Path;
  public AudioSource MyVocals;
  public AudioSource MyAudio;
  public AudioClip[] CombatSFX;
  public AudioClip[] Vocals;

  private void Start()
  {
    this.RedVignette.color = new Color(1f, 1f, 1f, 0.0f);
    this.ButtonPrompts[1].enabled = false;
    this.ButtonPrompts[2].enabled = false;
    this.ButtonPrompts[3].enabled = false;
    this.ButtonPrompts[4].enabled = false;
    this.ButtonPrompts[1].alpha = 0.0f;
    this.ButtonPrompts[2].alpha = 0.0f;
    this.ButtonPrompts[3].alpha = 0.0f;
    this.ButtonPrompts[4].alpha = 0.0f;
    this.Circle.enabled = false;
    this.BG.enabled = false;
  }

  public void StartCombat()
  {
    this.StartPoint = this.MainCamera.transform.position;
    this.Midpoint.transform.position = this.MainCamera.transform.position + this.MainCamera.transform.forward;
    this.MainCamera.transform.parent = this.CombatTarget;
    this.Yandere.RPGCamera.enabled = false;
    this.Zoom = true;
    this.Prefix = !this.Delinquent.Male ? "Female_" : "";
    if (!this.Practice)
    {
      this.Difficulty = 1f;
    }
    else
    {
      this.Delinquent.MyWeapon.GetComponent<Rigidbody>().isKinematic = true;
      this.Delinquent.MyWeapon.GetComponent<Rigidbody>().useGravity = false;
    }
  }

  private void Update()
  {
    if (this.Zoom)
    {
      this.MainCamera.transform.localPosition = Vector3.Lerp(this.MainCamera.transform.localPosition, new Vector3(1.5f, 0.25f, -0.5f), Time.deltaTime * 2f);
      this.RedVignette.color = (Color) Vector4.Lerp((Vector4) this.RedVignette.color, (Vector4) new Color(1f, 1f, 1f, (float) (1.0 - (double) this.Yandere.Health * 1.0 / 10.0)), Time.deltaTime);
      if ((double) this.Timer < 1.0)
        this.Delinquent.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward);
      this.Timer += Time.deltaTime;
      this.AdjustMidpoint();
      if ((double) this.Timer > 1.5)
      {
        Debug.Log((object) (this.name + " is being instructed to perform the first combat animation of the combat minigame."));
        this.Delinquent.CharacterAnimation.CrossFade(this.Prefix + "Delinquent_CombatA");
        this.Yandere.CharacterAnimation.CrossFade("Yandere_CombatA");
        this.CameraStart = this.MainCamera.localPosition;
        this.Label.text = "State: A";
        this.Zoom = false;
        this.Timer = 0.0f;
        this.Phase = 1;
        this.Path = 1;
        this.MyAudio.clip = this.CombatSFX[this.Phase];
        this.MyAudio.Play();
        this.MyVocals.clip = this.Vocals[this.Phase];
        this.MyVocals.Play();
      }
    }
    if (this.Phase > 0)
    {
      this.MainCamera.position += new Vector3(this.Shake * Random.Range(-1f, 1f), this.Shake * Random.Range(-1f, 1f), this.Shake * Random.Range(-1f, 1f));
      this.Shake = Mathf.Lerp(this.Shake, 0.0f, Time.deltaTime * 10f);
      this.AdjustMidpoint();
    }
    if (this.ButtonID > 0)
    {
      this.Timer += Time.deltaTime;
      this.Circle.fillAmount = (float) (1.0 - (double) this.Timer / 0.33333000540733337);
      if (Input.GetButtonDown("A") && this.CurrentButton != "A" || Input.GetButtonDown("B") && this.CurrentButton != "B" || Input.GetButtonDown("X") && this.CurrentButton != "X" || Input.GetButtonDown("Y") && this.CurrentButton != "Y")
      {
        Time.timeScale = 1f;
        this.MyVocals.pitch = 1f;
        this.MyAudio.pitch = 1f;
        this.DisablePrompts();
        ++this.Phase;
      }
      else if (Input.GetButtonDown(this.CurrentButton))
        this.Success = true;
    }
    if (this.Path == 1)
    {
      if (!this.Delinquent.CharacterAnimation.IsPlaying(this.Prefix + "Delinquent_CombatA"))
      {
        this.Delinquent.CharacterAnimation.CrossFade(this.Prefix + "Delinquent_CombatA");
        this.Delinquent.CharacterAnimation[this.Prefix + "Delinquent_CombatA"].time = this.Yandere.CharacterAnimation["Yandere_CombatA"].time;
      }
      this.MainCamera.localPosition = Vector3.Lerp(this.MainCamera.localPosition, this.CameraStart, Time.deltaTime);
      if (this.Phase == 1)
      {
        if ((double) this.Yandere.CharacterAnimation["Yandere_CombatA"].time <= 1.0)
          return;
        this.StartTime = this.Yandere.CharacterAnimation["Yandere_CombatA"].time - 1f;
        this.ChooseButton();
        this.Slowdown();
        ++this.Phase;
      }
      else if (this.Phase == 2)
      {
        if ((double) this.Yandere.CharacterAnimation["Yandere_CombatA"].time > 1.3333300352096558)
        {
          Time.timeScale = 1f;
          this.MyVocals.pitch = 1f;
          this.MyAudio.pitch = 1f;
          this.DisablePrompts();
          ++this.Phase;
        }
        else
        {
          if (!this.Success)
            return;
          this.Delinquent.CharacterAnimation[this.Prefix + "Delinquent_CombatB"].time = this.Delinquent.CharacterAnimation[this.Prefix + "Delinquent_CombatA"].time;
          this.Yandere.CharacterAnimation["Yandere_CombatB"].time = this.Yandere.CharacterAnimation["Yandere_CombatA"].time;
          this.Delinquent.CharacterAnimation.Play(this.Prefix + "Delinquent_CombatB");
          this.Yandere.CharacterAnimation.Play("Yandere_CombatB");
          this.Label.text = "State: B";
          Time.timeScale = 1f;
          this.MyAudio.pitch = 1f;
          this.DisablePrompts();
          this.Strike = 0;
          this.Path = 2;
          ++this.Phase;
          this.MyAudio.clip = this.CombatSFX[this.Path];
          this.MyAudio.time = this.Yandere.CharacterAnimation["Yandere_CombatB"].time;
          this.MyAudio.Play();
          this.MyVocals.clip = this.Vocals[this.Path];
          this.MyVocals.time = this.Yandere.CharacterAnimation["Yandere_CombatB"].time + 0.5f;
          this.MyVocals.Play();
        }
      }
      else
      {
        if (this.Phase != 3)
          return;
        if (this.Strike < 1)
        {
          if ((double) this.Yandere.CharacterAnimation["Yandere_CombatA"].time > 1.666659951210022)
          {
            Object.Instantiate<GameObject>(this.HitEffect, this.Yandere.LeftArmRoll.position, Quaternion.identity);
            this.Shake += this.ShakeFactor;
            ++this.Strike;
            --this.Yandere.Health;
            this.RedVignette.color = new Color(1f, 1f, 1f, (float) (1.0 - (double) this.Yandere.Health * 1.0 / 10.0));
          }
        }
        else if (this.Strike < 2 && (double) this.Yandere.CharacterAnimation["Yandere_CombatA"].time > 2.5)
        {
          Object.Instantiate<GameObject>(this.HitEffect, this.Yandere.RightArmRoll.position, Quaternion.identity);
          this.Shake += this.ShakeFactor;
          ++this.Strike;
          --this.Yandere.Health;
          if (this.Yandere.Health < 0)
            this.Yandere.Health = 0;
          this.RedVignette.color = new Color(1f, 1f, 1f, (float) (1.0 - (double) this.Yandere.Health * 1.0 / 10.0));
          if (!this.Practice)
            this.Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount1", (float) (1.0 - (double) this.Yandere.Health * 1.0 / 10.0));
          if (this.Yandere.Health < 1)
          {
            if (!this.Delinquent.WitnessedMurder && !this.Delinquent.WitnessedCorpse)
            {
              this.Delinquent.CharacterAnimation[this.Prefix + "Delinquent_CombatF"].time = this.Delinquent.CharacterAnimation[this.Prefix + "Delinquent_CombatA"].time;
              this.Yandere.CharacterAnimation["Yandere_CombatF"].time = this.Yandere.CharacterAnimation["Yandere_CombatA"].time;
              this.Delinquent.CharacterAnimation.CrossFade(this.Prefix + "Delinquent_CombatF");
              this.Yandere.CharacterAnimation.CrossFade("Yandere_CombatF");
              this.Shake += this.ShakeFactor;
              this.Label.text = "State: F";
              Time.timeScale = 1f;
              this.MyVocals.pitch = 1f;
              this.MyAudio.pitch = 1f;
              this.DisablePrompts();
              this.Timer = 0.0f;
              this.Path = 6;
              ++this.Phase;
              this.MyAudio.clip = this.CombatSFX[this.Path];
              this.MyAudio.time = this.Yandere.CharacterAnimation["Yandere_CombatF"].time;
              this.MyAudio.Play();
              this.MyVocals.clip = this.Vocals[this.Path];
              this.MyVocals.time = this.Yandere.CharacterAnimation["Yandere_CombatF"].time;
              this.MyVocals.Play();
            }
            else
            {
              this.Delinquent.CharacterAnimation[this.Prefix + "Delinquent_CombatE"].time = this.Delinquent.CharacterAnimation[this.Prefix + "Delinquent_CombatA"].time;
              this.Yandere.CharacterAnimation["Yandere_CombatE"].time = this.Yandere.CharacterAnimation["Yandere_CombatA"].time;
              this.Delinquent.CharacterAnimation.CrossFade(this.Prefix + "Delinquent_CombatE");
              this.Yandere.CharacterAnimation.CrossFade("Yandere_CombatE");
              this.CameraTarget = this.MainCamera.position + new Vector3(0.0f, 1f, 0.0f);
              this.MainCamera.parent = (Transform) null;
              this.Shake += this.ShakeFactor;
              this.KnockedOut = true;
              this.Label.text = "State: E";
              Time.timeScale = 1f;
              this.MyVocals.pitch = 1f;
              this.MyAudio.pitch = 1f;
              this.DisablePrompts();
              this.Timer = 0.0f;
              this.Path = 5;
              ++this.Phase;
              this.MyAudio.clip = this.CombatSFX[this.Path];
              this.MyAudio.time = this.Yandere.CharacterAnimation["Yandere_CombatE"].time;
              this.MyAudio.Play();
              this.MyVocals.clip = this.Vocals[this.Path];
              this.MyVocals.time = this.Yandere.CharacterAnimation["Yandere_CombatE"].time;
              this.MyVocals.Play();
            }
          }
        }
        if ((double) this.Yandere.CharacterAnimation["Yandere_CombatA"].time <= (double) this.Yandere.CharacterAnimation["Yandere_CombatA"].length)
          return;
        this.Delinquent.CharacterAnimation[this.Prefix + "Delinquent_CombatA"].time = 0.0f;
        this.Yandere.CharacterAnimation["Yandere_CombatA"].time = 0.0f;
        this.Label.text = "State: A";
        this.Strike = 0;
        this.Phase = 1;
        this.MyAudio.clip = this.CombatSFX[this.Path];
        this.MyAudio.time = this.Yandere.CharacterAnimation["Yandere_CombatA"].time;
        this.MyAudio.Play();
        this.MyVocals.clip = this.Vocals[this.Path];
        this.MyVocals.time = this.Yandere.CharacterAnimation["Yandere_CombatA"].time;
        this.MyVocals.Play();
      }
    }
    else if (this.Path == 2)
    {
      if (this.Phase == 3)
      {
        if ((double) this.Yandere.CharacterAnimation["Yandere_CombatB"].time <= 1.8333330154418945)
          return;
        this.StartTime = this.Yandere.CharacterAnimation["Yandere_CombatB"].time - 1.833333f;
        this.ChooseButton();
        this.Slowdown();
        ++this.Phase;
      }
      else if (this.Phase == 4)
      {
        if ((double) this.Yandere.CharacterAnimation["Yandere_CombatB"].time > 2.1666660308837891)
        {
          Time.timeScale = 1f;
          this.MyVocals.pitch = 1f;
          this.MyAudio.pitch = 1f;
          this.DisablePrompts();
          ++this.Phase;
        }
        else
        {
          if (!this.Success)
            return;
          this.Delinquent.CharacterAnimation[this.Prefix + "Delinquent_CombatC"].time = this.Delinquent.CharacterAnimation[this.Prefix + "Delinquent_CombatB"].time;
          this.Yandere.CharacterAnimation["Yandere_CombatC"].time = this.Yandere.CharacterAnimation["Yandere_CombatB"].time;
          this.Delinquent.CharacterAnimation.Play(this.Prefix + "Delinquent_CombatC");
          this.Yandere.CharacterAnimation.Play("Yandere_CombatC");
          this.Label.text = "State: C";
          Time.timeScale = 1f;
          this.MyVocals.pitch = 1f;
          this.MyAudio.pitch = 1f;
          this.DisablePrompts();
          this.Strike = 0;
          this.Path = 3;
          ++this.Phase;
          this.MyAudio.clip = this.CombatSFX[this.Path];
          this.MyAudio.time = this.Yandere.CharacterAnimation["Yandere_CombatC"].time;
          this.MyAudio.Play();
          this.MyVocals.clip = this.Vocals[this.Path];
          this.MyVocals.time = this.Yandere.CharacterAnimation["Yandere_CombatC"].time;
          this.MyVocals.Play();
        }
      }
      else
      {
        if (this.Phase != 5)
          return;
        if (this.Strike < 1 && (double) this.Yandere.CharacterAnimation["Yandere_CombatB"].time > 2.6666600704193115)
        {
          Object.Instantiate<GameObject>(this.HitEffect, this.Delinquent.LeftHand.position, Quaternion.identity);
          this.Shake += this.ShakeFactor;
          ++this.Strike;
        }
        if ((double) this.Yandere.CharacterAnimation["Yandere_CombatB"].time <= (double) this.Yandere.CharacterAnimation["Yandere_CombatB"].length)
          return;
        this.Delinquent.CharacterAnimation.CrossFade(this.Prefix + "Delinquent_CombatA");
        this.Yandere.CharacterAnimation.CrossFade("Yandere_CombatA");
        this.Label.text = "State: A";
        this.Strike = 0;
        this.Phase = 1;
        this.Path = 1;
        this.MyAudio.clip = this.CombatSFX[this.Path];
        this.MyAudio.time = this.Yandere.CharacterAnimation["Yandere_CombatA"].time;
        this.MyAudio.Play();
        this.MyVocals.clip = this.Vocals[this.Path];
        this.MyVocals.time = this.Yandere.CharacterAnimation["Yandere_CombatA"].time;
        this.MyVocals.Play();
      }
    }
    else if (this.Path == 3)
    {
      if (this.Phase == 5)
      {
        if (this.Strike < 1 && (double) this.Yandere.CharacterAnimation["Yandere_CombatC"].time > 2.5)
        {
          Object.Instantiate<GameObject>(this.HitEffect, this.Yandere.RightHand.position, Quaternion.identity);
          this.Shake += this.ShakeFactor;
          ++this.Strike;
        }
        if ((double) this.Yandere.CharacterAnimation["Yandere_CombatC"].time <= 3.1666660308837891)
          return;
        this.StartTime = this.Yandere.CharacterAnimation["Yandere_CombatC"].time - 3.166666f;
        this.ChooseButton();
        this.Slowdown();
        ++this.Phase;
      }
      else if (this.Phase == 6)
      {
        if ((double) this.Yandere.CharacterAnimation["Yandere_CombatC"].time > 3.5)
        {
          this.DisablePrompts();
          Time.timeScale = 1f;
          this.MyVocals.pitch = 1f;
          this.MyAudio.pitch = 1f;
          ++this.Phase;
        }
        else
        {
          if (!this.Success)
            return;
          this.Delinquent.CharacterAnimation[this.Prefix + "Delinquent_CombatD"].time = this.Delinquent.CharacterAnimation[this.Prefix + "Delinquent_CombatC"].time;
          this.Yandere.CharacterAnimation["Yandere_CombatD"].time = this.Yandere.CharacterAnimation["Yandere_CombatC"].time;
          this.Delinquent.CharacterAnimation.Play(this.Prefix + "Delinquent_CombatD");
          this.Yandere.CharacterAnimation.Play("Yandere_CombatD");
          this.Label.text = "State: D";
          Time.timeScale = 1f;
          this.MyVocals.pitch = 1f;
          this.MyAudio.pitch = 1f;
          this.DisablePrompts();
          this.Strike = 0;
          this.Path = 4;
          ++this.Phase;
          this.MyAudio.clip = this.CombatSFX[this.Path];
          this.MyAudio.time = this.Yandere.CharacterAnimation["Yandere_CombatD"].time;
          this.MyAudio.Play();
          this.MyVocals.clip = this.Vocals[this.Path];
          this.MyVocals.time = this.Yandere.CharacterAnimation["Yandere_CombatD"].time;
          this.MyVocals.Play();
        }
      }
      else
      {
        if (this.Phase != 7 || (double) this.Yandere.CharacterAnimation["Yandere_CombatC"].time <= (double) this.Yandere.CharacterAnimation["Yandere_CombatC"].length)
          return;
        this.Delinquent.CharacterAnimation.CrossFade(this.Prefix + "Delinquent_CombatA");
        this.Yandere.CharacterAnimation.CrossFade("Yandere_CombatA");
        this.Label.text = "State: A";
        this.Strike = 0;
        this.Phase = 1;
        this.Path = 1;
        this.MyAudio.clip = this.CombatSFX[this.Path];
        this.MyAudio.time = this.Yandere.CharacterAnimation["Yandere_CombatA"].time;
        this.MyAudio.Play();
        this.MyVocals.clip = this.Vocals[this.Path];
        this.MyVocals.time = this.Yandere.CharacterAnimation["Yandere_CombatA"].time;
        this.MyVocals.Play();
      }
    }
    else if (this.Path == 4)
    {
      if (this.Phase != 7)
        return;
      if (this.Strike < 1)
      {
        if ((double) this.Yandere.CharacterAnimation["Yandere_CombatD"].time > 4.0)
        {
          Object.Instantiate<GameObject>(this.HitEffect, this.Yandere.RightKnee.position, Quaternion.identity);
          this.Delinquent.MyWeapon.transform.parent = (Transform) null;
          this.Delinquent.MyWeapon.MyCollider.enabled = true;
          this.Delinquent.MyWeapon.MyCollider.isTrigger = false;
          this.Delinquent.MyWeapon.Prompt.enabled = true;
          this.Delinquent.IgnoreBlood = true;
          Rigidbody component = this.Delinquent.MyWeapon.GetComponent<Rigidbody>();
          component.constraints = RigidbodyConstraints.None;
          component.isKinematic = false;
          component.useGravity = true;
          if (!this.Practice)
          {
            this.Delinquent.MyWeapon.DelinquentOwned = false;
            this.Delinquent.MyWeapon = (WeaponScript) null;
          }
          else
          {
            this.Delinquent.MyWeapon.Prompt.Hide();
            this.Delinquent.MyWeapon.Prompt.enabled = false;
          }
          this.Shake += this.ShakeFactor;
          ++this.Strike;
        }
      }
      else if ((double) this.Yandere.CharacterAnimation["Yandere_CombatD"].time > 5.5)
      {
        this.MainCamera.transform.parent = (Transform) null;
        this.Strength += Time.deltaTime;
        this.MainCamera.transform.position = Vector3.Lerp(this.MainCamera.transform.position, this.StartPoint, Time.deltaTime * this.Strength);
        this.RedVignette.color = (Color) Vector4.Lerp((Vector4) this.RedVignette.color, new Vector4(1f, 0.0f, 0.0f, 0.0f), Time.deltaTime * this.Strength);
        this.Zoom = false;
      }
      if ((double) this.Yandere.CharacterAnimation["Yandere_CombatD"].time <= (double) this.Yandere.CharacterAnimation["Yandere_CombatD"].length)
        return;
      Debug.Log((object) "Player won.");
      this.Delinquent.WillChase = false;
      if (this.Delinquent.WitnessedMurder || this.Delinquent.WitnessedCorpse)
        this.ExitSchoolWhenDone = true;
      if (!this.Practice)
      {
        this.Yandere.Subtitle.UpdateLabel(SubtitleType.DelinquentSurrender, 0, 5f);
        this.Delinquent.Persona = PersonaType.Loner;
      }
      if (!this.Practice)
      {
        Debug.Log((object) "Deciding what to do now that the minigame is over.");
        if (this.Delinquent.FoundEnemyCorpse)
          this.ExitSchoolWhenDone = true;
        if (this.Delinquent.WitnessedCorpse || this.Delinquent.WitnessedMurder || this.ExitSchoolWhenDone)
        {
          Debug.Log((object) "The delinquent will now run for the exit.");
          for (int index = 1; index < this.Delinquent.ScheduleBlocks.Length; ++index)
          {
            ScheduleBlock scheduleBlock = this.Delinquent.ScheduleBlocks[index];
            scheduleBlock.destination = "Exit";
            scheduleBlock.action = "Exit";
          }
        }
        else
        {
          Debug.Log((object) "This delinquent will now go sulk.");
          ScheduleBlock scheduleBlock1 = this.Delinquent.ScheduleBlocks[2];
          scheduleBlock1.destination = "Sulk";
          scheduleBlock1.action = "Sulk";
          ScheduleBlock scheduleBlock2 = this.Delinquent.ScheduleBlocks[4];
          scheduleBlock2.destination = "Sulk";
          scheduleBlock2.action = "Sulk";
          ScheduleBlock scheduleBlock3 = this.Delinquent.ScheduleBlocks[6];
          scheduleBlock3.destination = "Sulk";
          scheduleBlock3.action = "Sulk";
          ScheduleBlock scheduleBlock4 = this.Delinquent.ScheduleBlocks[7];
          scheduleBlock4.destination = "Sulk";
          scheduleBlock4.action = "Sulk";
        }
        this.ExitSchoolWhenDone = false;
        if (this.Delinquent.Phase == 0)
          ++this.Delinquent.Phase;
        this.Delinquent.GetDestinations();
        this.Delinquent.CurrentDestination = this.Delinquent.Destinations[this.Delinquent.Phase];
        this.Delinquent.Pathfinding.target = this.Delinquent.Destinations[this.Delinquent.Phase];
        if ((Object) this.Delinquent.CurrentDestination == (Object) null)
        {
          Debug.Log((object) "Manually setting Delinquent's destination to locker, to fix a saving/loading bug.");
          this.Delinquent.CurrentDestination = this.Delinquent.Destinations[1];
          this.Delinquent.Pathfinding.target = this.Delinquent.Destinations[1];
        }
        if (this.Delinquent.Male)
        {
          this.Delinquent.IdleAnim = "idleInjured_00";
          this.Delinquent.WalkAnim = "walkInjured_00";
        }
        else
        {
          this.Delinquent.IdleAnim = "f02_delinquentIdleInjured_00";
          this.Delinquent.WalkAnim = "f02_delinquentWalkInjured_00";
        }
        this.Delinquent.OriginalIdleAnim = this.Delinquent.IdleAnim;
        this.Delinquent.OriginalWalkAnim = this.Delinquent.WalkAnim;
        this.Delinquent.LeanAnim = this.Delinquent.IdleAnim;
        this.Delinquent.CharacterAnimation.CrossFade(this.Delinquent.IdleAnim);
        this.Delinquent.Threatened = true;
        this.Delinquent.Alarmed = true;
        this.Delinquent.Injured = true;
        this.Delinquent.Strength = 0;
        ++this.Delinquent.Defeats;
      }
      else
      {
        this.PracticeWindow.DefeatedSho = true;
        this.PracticeWindow.StudentManager.TaskManager.UpdateTaskStatus();
        this.Delinquent.Threatened = false;
        this.Delinquent.Alarmed = false;
        this.PracticeWindow.Finish();
        this.Yandere.Health = 10;
        this.Practice = false;
      }
      this.Delinquent.Fighting = false;
      this.Delinquent.enabled = true;
      this.Delinquent.Distracted = false;
      this.Delinquent.Shoving = false;
      this.Delinquent.Paired = false;
      this.Delinquent = (StudentScript) null;
      this.ReleaseYandere();
      this.ResetValues();
      this.Yandere.StudentManager.UpdateStudents();
    }
    else if (this.Path == 5)
    {
      if (this.Phase != 4)
        return;
      this.MainCamera.position = Vector3.Lerp(this.MainCamera.position, this.CameraTarget, Time.deltaTime);
      if ((double) this.Yandere.CharacterAnimation["Yandere_CombatE"].time <= (double) this.Yandere.CharacterAnimation["Yandere_CombatE"].length)
        return;
      this.Timer += Time.deltaTime;
      if ((double) this.Timer <= 1.0)
        return;
      this.Yandere.ShoulderCamera.HeartbrokenCamera.SetActive(true);
      this.Yandere.ShoulderCamera.enabled = false;
      this.Yandere.RPGCamera.enabled = false;
      this.Yandere.Jukebox.GameOver();
      this.Yandere.enabled = false;
      this.Yandere.EmptyHands();
      this.Yandere.Lost = true;
      ++this.Phase;
    }
    else if (this.Path == 6)
    {
      if (this.Phase != 4)
        return;
      if ((double) this.Yandere.CharacterAnimation["Yandere_CombatF"].time > 6.3333301544189453)
      {
        this.MainCamera.transform.parent = (Transform) null;
        this.Strength += Time.deltaTime;
        this.MainCamera.transform.position = Vector3.Lerp(this.MainCamera.transform.position, this.StartPoint, Time.deltaTime * this.Strength);
        this.RedVignette.color = (Color) Vector4.Lerp((Vector4) this.RedVignette.color, new Vector4(1f, 0.0f, 0.0f, 0.0f), Time.deltaTime * this.Strength);
        this.Zoom = false;
      }
      if ((double) this.Delinquent.CharacterAnimation[this.Prefix + "Delinquent_CombatF"].time > 7.8333301544189453)
      {
        this.Delinquent.MyWeapon.transform.parent = this.Delinquent.WeaponBagParent;
        this.Delinquent.MyWeapon.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        this.Delinquent.MyWeapon.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
      }
      if ((double) this.Yandere.CharacterAnimation["Yandere_CombatF"].time <= (double) this.Yandere.CharacterAnimation["Yandere_CombatF"].length)
        return;
      if (!this.Practice)
      {
        this.Yandere.Subtitle.UpdateLabel(SubtitleType.DelinquentWin, 0, 5f);
        this.Yandere.IdleAnim = "f02_idleInjured_00";
        this.Yandere.WalkAnim = "f02_walkInjured_00";
        this.Yandere.OriginalIdleAnim = this.Yandere.IdleAnim;
        this.Yandere.OriginalWalkAnim = this.Yandere.WalkAnim;
        this.Yandere.StudentManager.Rest.Prompt.enabled = true;
      }
      else
      {
        this.PracticeWindow.Finish();
        this.Yandere.Health = 10;
        this.Practice = false;
      }
      this.Yandere.CharacterAnimation.CrossFade(this.Yandere.IdleAnim);
      this.Yandere.DelinquentFighting = false;
      this.Yandere.RPGCamera.enabled = true;
      this.Yandere.CannotRecover = false;
      this.Yandere.CanMove = true;
      this.Yandere.Chased = false;
      this.Delinquent.Threatened = false;
      this.Delinquent.Fighting = false;
      this.Delinquent.Injured = false;
      this.Delinquent.Alarmed = false;
      this.Delinquent.Routine = true;
      this.Delinquent.enabled = true;
      this.Delinquent.Distracted = false;
      this.Delinquent.Shoving = false;
      this.Delinquent.Paired = false;
      this.Delinquent.Patience = 5;
      this.ResetValues();
      this.Yandere.StudentManager.UpdateStudents();
    }
    else
    {
      if (this.Path != 7)
        return;
      if ((double) this.Yandere.CharacterAnimation["f02_stopFighting_00"].time > 1.0)
      {
        this.MainCamera.transform.parent = (Transform) null;
        this.Strength += Time.deltaTime;
        this.MainCamera.transform.position = Vector3.Lerp(this.MainCamera.transform.position, this.StartPoint, Time.deltaTime * this.Strength);
        this.RedVignette.color = (Color) Vector4.Lerp((Vector4) this.RedVignette.color, new Vector4(1f, 0.0f, 0.0f, 0.0f), Time.deltaTime * this.Strength);
        this.Zoom = false;
      }
      if ((double) this.Delinquent.CharacterAnimation[this.StopFightingAnim].time > 3.8333299160003662)
      {
        this.Delinquent.MyWeapon.transform.parent = this.Delinquent.WeaponBagParent;
        this.Delinquent.MyWeapon.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        this.Delinquent.MyWeapon.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
      }
      if ((double) this.Yandere.CharacterAnimation["f02_stopFighting_00"].time <= (double) this.Yandere.CharacterAnimation["f02_stopFighting_00"].length)
        return;
      if (this.Delinquent.Phase == 0)
        ++this.Delinquent.Phase;
      this.Delinquent.GetDestinations();
      this.Delinquent.CurrentDestination = this.Delinquent.Destinations[this.Delinquent.Phase];
      this.Delinquent.Pathfinding.target = this.Delinquent.Destinations[this.Delinquent.Phase];
      if ((Object) this.Delinquent.CurrentDestination == (Object) null)
      {
        Debug.Log((object) "Manually setting Delinquent's destination to locker, to fix a saving/loading bug.");
        this.Delinquent.CurrentDestination = this.Delinquent.Destinations[1];
        this.Delinquent.Pathfinding.target = this.Delinquent.Destinations[1];
      }
      this.ReleaseYandere();
      this.Delinquent.Threatened = false;
      this.Delinquent.Fighting = false;
      this.Delinquent.Alarmed = false;
      this.Delinquent.enabled = true;
      this.Delinquent.Distracted = false;
      this.Delinquent.Shoving = false;
      this.Delinquent.Paired = false;
      this.Delinquent.Routine = true;
      this.Delinquent.Patience = 5;
      this.Delinquent = (StudentScript) null;
      this.DisablePrompts();
      this.ResetValues();
      this.Yandere.StudentManager.UpdateStudents();
    }
  }

  private void Slowdown()
  {
    Time.timeScale = this.SlowdownFactor * this.Difficulty;
    this.MyVocals.pitch = this.SlowdownFactor * this.Difficulty;
    this.MyAudio.pitch = this.SlowdownFactor * this.Difficulty;
  }

  private void ChooseButton()
  {
    this.ButtonPrompts[1].enabled = false;
    this.ButtonPrompts[2].enabled = false;
    this.ButtonPrompts[3].enabled = false;
    this.ButtonPrompts[4].enabled = false;
    this.ButtonPrompts[1].alpha = 0.0f;
    this.ButtonPrompts[2].alpha = 0.0f;
    this.ButtonPrompts[3].alpha = 0.0f;
    this.ButtonPrompts[4].alpha = 0.0f;
    int buttonId = this.ButtonID;
    while (this.ButtonID == buttonId)
      this.ButtonID = Random.Range(1, 5);
    if (this.ButtonID == 1)
      this.CurrentButton = "A";
    else if (this.ButtonID == 2)
      this.CurrentButton = "B";
    else if (this.ButtonID == 3)
      this.CurrentButton = "X";
    else if (this.ButtonID == 4)
      this.CurrentButton = "Y";
    this.ButtonPrompts[this.ButtonID].enabled = true;
    this.ButtonPrompts[this.ButtonID].alpha = 1f;
    this.Circle.enabled = true;
    this.BG.enabled = true;
    this.Timer = this.StartTime;
  }

  public void DisablePrompts()
  {
    this.ButtonPrompts[1].enabled = false;
    this.ButtonPrompts[2].enabled = false;
    this.ButtonPrompts[3].enabled = false;
    this.ButtonPrompts[4].enabled = false;
    this.ButtonPrompts[1].alpha = 0.0f;
    this.ButtonPrompts[2].alpha = 0.0f;
    this.ButtonPrompts[3].alpha = 0.0f;
    this.ButtonPrompts[4].alpha = 0.0f;
    this.Circle.fillAmount = 1f;
    this.Circle.enabled = false;
    this.BG.enabled = false;
    this.Success = false;
    this.ButtonID = 0;
  }

  private void AdjustMidpoint()
  {
    if ((double) this.Strength == 0.0)
    {
      if (!this.KnockedOut)
      {
        this.Midpoint.position = (this.Delinquent.Hips.position - this.Yandere.Hips.position) * 0.5f + this.Yandere.Hips.position;
        this.Midpoint.position += new Vector3(0.0f, 0.25f, 0.0f);
      }
      else
        this.Midpoint.position = Vector3.Lerp(this.Midpoint.position, this.Yandere.Hips.position + new Vector3(0.0f, 0.5f, 0.0f), Time.deltaTime);
    }
    else
      this.Midpoint.position = Vector3.Lerp(this.Midpoint.position, this.Yandere.RPGCamera.cameraPivot.position, Time.deltaTime * this.Strength);
    this.MainCamera.LookAt(this.Midpoint.position);
  }

  public void Stop()
  {
    if (!((Object) this.Delinquent != (Object) null))
      return;
    this.Delinquent.CharacterAnimation.CrossFade("delinquentCombatIdle_00");
    this.ResetValues();
    this.enabled = false;
  }

  public void ResetValues()
  {
    this.Label.text = "State: A";
    this.Strength = 0.0f;
    this.Strike = 0;
    this.Phase = 0;
    this.Path = 0;
    this.MyAudio.clip = this.CombatSFX[this.Path];
    this.MyAudio.time = 0.0f;
    this.MyAudio.Stop();
    this.MyVocals.clip = this.Vocals[this.Path];
    this.MyVocals.time = 0.0f;
    this.MyVocals.Stop();
    this.Delinquent = (StudentScript) null;
  }

  public void ReleaseYandere()
  {
    Debug.Log((object) "Yandere-chan has been released from combat.");
    this.Yandere.CharacterAnimation.CrossFade(this.Yandere.IdleAnim);
    this.Yandere.DelinquentFighting = false;
    this.Yandere.RPGCamera.enabled = true;
    this.Yandere.CannotRecover = false;
    this.Yandere.CanMove = true;
    this.Yandere.Chased = false;
  }
}
