// Decompiled with JetBrains decompiler
// Type: SnappedYandereScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

public class SnappedYandereScript : MonoBehaviour
{
  public CharacterController MyController;
  public CameraFilterPack_FX_Glitch1 Glitch1;
  public CameraFilterPack_FX_Glitch2 Glitch2;
  public CameraFilterPack_FX_Glitch3 Glitch3;
  public CameraFilterPack_Glitch_Mozaic Glitch4;
  public CameraFilterPack_NewGlitch1 Glitch5;
  public CameraFilterPack_NewGlitch2 Glitch6;
  public CameraFilterPack_NewGlitch3 Glitch7;
  public CameraFilterPack_NewGlitch4 Glitch8;
  public CameraFilterPack_NewGlitch5 Glitch9;
  public CameraFilterPack_NewGlitch6 Glitch10;
  public CameraFilterPack_NewGlitch7 Glitch11;
  public CameraFilterPack_TV_CompressionFX CompressionFX;
  public CameraFilterPack_TV_Distorted Distorted;
  public CameraFilterPack_Blur_Tilt_Shift TiltShift;
  public CameraFilterPack_Blur_Tilt_Shift_V TiltShiftV;
  public CameraFilterPack_Noise_TV Static;
  public StudentManagerScript StudentManager;
  public SnapStudentScript TargetStudent;
  public InputDeviceScript InputDevice;
  public GameObject StabBloodEffect;
  public GameObject BloodEffect;
  public GameObject NewDoIt;
  public WeaponScript Knife;
  public AudioListener MyListener;
  public Transform SnapAttackPivot;
  public Transform FinalSnapPOV;
  public Transform SuicidePOV;
  public Transform RightFoot;
  public Transform RightHand;
  public Transform LeftHand;
  public Transform Spine;
  public AudioSource StaticNoise;
  public AudioSource AttackAudio;
  public AudioSource SnapStatic;
  public AudioSource SnapVoice;
  public AudioSource Jukebox;
  public AudioSource MyAudio;
  public AudioSource Rumble;
  public AudioClip EndSNAP;
  public UILabel SNAPLabel;
  public Camera MainCamera;
  public Animation MyAnim;
  public AudioClip Buzz;
  public AudioClip[] Whispers;
  public AudioClip[] FemaleDeathScreams;
  public AudioClip[] MaleDeathScreams;
  public AudioClip[] AttackSFX;
  public GameObject DoIt;
  public UISprite SuicideSprite;
  public UILabel SuicidePrompt;
  public bool KillingSenpai;
  public bool Attacking;
  public bool CanMove;
  public bool SpeedUp;
  public bool Whisper;
  public bool Armed;
  public string IdleAnim;
  public string WalkAnim;
  public float ImpatienceLimit;
  public float GlitchTimeLimit;
  public float WhisperTimer;
  public float AttackTimer;
  public float GlitchTimer;
  public float ImpatienceTimer;
  public float ListenTimer;
  public float HurryTimer;
  public float AnimSpeed;
  public float Target;
  public float Speed;
  public int BloodSpawned;
  public int AttackPhase;
  public int Teleports;
  public int AttackID;
  public int VoiceID;
  public int Attacks;
  public int Taps;
  public string[] AttackAnims;
  public WeaponScript[] Weapons;
  public bool[] AttacksUsed;

  private void Start()
  {
    this.MyAnim[this.AttackAnims[1]].speed = 1.5f;
    this.MyAnim[this.AttackAnims[2]].speed = 1.5f;
    this.MyAnim[this.AttackAnims[3]].speed = 1.5f;
    this.MyAnim[this.AttackAnims[4]].speed = 1.5f;
    this.MyAnim[this.AttackAnims[5]].speed = 1.5f;
    if (ClubGlobals.GetClubClosed(ClubType.Cooking))
    {
      this.Weapons[0] = (WeaponScript) null;
      this.Weapons[5] = (WeaponScript) null;
    }
    if (ClubGlobals.GetClubClosed(ClubType.Art))
      this.Weapons[3] = (WeaponScript) null;
    if (!ClubGlobals.GetClubClosed(ClubType.Occult))
      return;
    this.Weapons[6] = (WeaponScript) null;
  }

  private void Update()
  {
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
    if (Input.GetKeyDown("=") && (double) Time.timeScale < 10.0)
      ++Time.timeScale;
    if (Input.GetKeyDown("-") && (double) Time.timeScale > 1.0)
      --Time.timeScale;
    if (this.Glitch1.enabled)
    {
      if (this.Attacking)
        this.GlitchTimer += Time.deltaTime * this.MyAnim[this.AttackAnims[this.AttackID]].speed;
      else
        this.GlitchTimer += Time.deltaTime;
      if ((double) this.GlitchTimer > (double) this.GlitchTimeLimit)
      {
        this.SetGlitches(false);
        if ((Object) this.MyAudio.clip != (Object) this.EndSNAP)
          this.MyAudio.Stop();
        if (this.Attacking)
        {
          this.SnapAttackPivot.position = this.TargetStudent.Student.Head.position;
          this.SnapAttackPivot.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
          this.MainCamera.transform.parent = this.SnapAttackPivot;
          this.MainCamera.transform.localPosition = new Vector3(0.0f, 0.0f, -1f);
          this.MainCamera.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
          this.SnapAttackPivot.localEulerAngles = new Vector3(Random.Range(-45f, 45f), Random.Range(0.0f, 360f), 0.0f);
          while ((double) this.MainCamera.transform.position.y < (double) this.transform.position.y + 0.10000000149011612)
            this.SnapAttackPivot.localEulerAngles = new Vector3(Random.Range(-45f, 45f), Random.Range(0.0f, 360f), 0.0f);
          this.MyAnim[this.AttackAnims[this.AttackID]].time = 0.0f;
          this.MyAnim.Play(this.AttackAnims[this.AttackID]);
          this.MyAnim[this.AttackAnims[this.AttackID]].time = 0.0f;
          this.MyAnim[this.AttackAnims[this.AttackID]].speed += 0.1f;
          this.TargetStudent.MyAnim[this.TargetStudent.AttackAnims[this.AttackID]].time = 0.0f;
          this.TargetStudent.MyAnim.Play(this.TargetStudent.AttackAnims[this.AttackID]);
          this.TargetStudent.MyAnim[this.TargetStudent.AttackAnims[this.AttackID]].time = 0.0f;
          this.TargetStudent.MyAnim[this.TargetStudent.AttackAnims[this.AttackID]].speed = this.MyAnim[this.AttackAnims[this.AttackID]].speed;
          if (this.TargetStudent.Student.Male)
          {
            this.MyAudio.clip = this.MaleDeathScreams[Random.Range(0, this.MaleDeathScreams.Length)];
            this.MyAudio.pitch = 1f;
            this.MyAudio.Play();
          }
          else
          {
            this.MyAudio.clip = this.FemaleDeathScreams[Random.Range(0, this.FemaleDeathScreams.Length)];
            this.MyAudio.pitch = 1f;
            this.MyAudio.Play();
          }
          this.AttackAudio.clip = this.AttackSFX[this.AttackID];
          this.AttackAudio.pitch = this.MyAnim[this.AttackAnims[this.AttackID]].speed;
          this.AttackAudio.Play();
        }
      }
    }
    if (!this.Armed)
    {
      foreach (WeaponScript weapon in this.Weapons)
      {
        if ((Object) weapon != (Object) null && weapon.gameObject.activeInHierarchy && (double) Vector3.Distance(this.transform.position, weapon.transform.position) < 1.5)
        {
          weapon.Prompt.Circle[3].fillAmount = 0.0f;
          this.SNAPLabel.text = "Kill him.";
          this.StaticNoise.volume = 0.0f;
          this.Static.Fade = 0.0f;
          this.HurryTimer = 0.0f;
          this.Knife = weapon;
          this.Armed = true;
        }
      }
    }
    else
      this.Knife.gameObject.SetActive(true);
    if (this.CanMove)
    {
      this.SNAPLabel.alpha = Mathf.MoveTowards(this.SNAPLabel.alpha, 1f, Time.deltaTime * 0.2f);
      this.HurryTimer += Time.deltaTime;
      if ((double) this.HurryTimer > 40.0 || (double) this.transform.position.y < -0.10000000149011612 || this.StudentManager.MaleLockerRoomArea.bounds.Contains(this.transform.position))
      {
        this.Teleport();
        this.HurryTimer = 0.0f;
        this.Static.Fade = 0.0f;
        this.StaticNoise.volume = 0.0f;
      }
      else if ((double) this.HurryTimer > 30.0)
      {
        this.StaticNoise.volume += Time.deltaTime * 0.1f;
        this.Static.Fade += Time.deltaTime * 0.1f;
      }
      this.UpdateMovement();
    }
    else if (this.Attacking)
    {
      this.SNAPLabel.alpha = 0.0f;
      if ((double) this.MyAnim[this.AttackAnims[this.AttackID]].speed == 0.0)
        this.MyAnim[this.AttackAnims[this.AttackID]].speed = 1f;
      if ((double) this.MyAnim[this.AttackAnims[this.AttackID]].time >= (double) this.MyAnim[this.AttackAnims[this.AttackID]].length)
      {
        if (this.Attacks < 5)
        {
          this.ChooseAttack();
        }
        else
        {
          this.MainCamera.transform.parent = this.transform;
          this.MainCamera.transform.localPosition = new Vector3(0.25f, 1.546664f, -0.5473595f);
          this.MainCamera.transform.localEulerAngles = new Vector3(15f, 0.0f, 0.0f);
          this.SetGlitches(true);
          this.GlitchTimeLimit = 0.5f;
          this.TargetStudent.Student.BecomeRagdoll();
          this.AttacksUsed[1] = false;
          this.AttacksUsed[2] = false;
          this.AttacksUsed[3] = false;
          this.AttacksUsed[4] = false;
          this.AttacksUsed[5] = false;
          this.Attacking = false;
          this.CanMove = true;
          this.Attacks = 0;
        }
      }
      else if (!this.Glitch1.enabled && this.BloodSpawned < 2)
      {
        if (this.AttackID == 1)
        {
          if (this.BloodSpawned == 0)
          {
            if ((double) this.MyAnim[this.AttackAnims[this.AttackID]].time > 0.25)
            {
              Object.Instantiate<GameObject>(this.BloodEffect, this.RightHand.position, Quaternion.identity);
              this.MyAudio.Stop();
              ++this.BloodSpawned;
            }
          }
          else if ((double) this.MyAnim[this.AttackAnims[this.AttackID]].time > 1.0)
          {
            Object.Instantiate<GameObject>(this.BloodEffect, this.LeftHand.position, Quaternion.identity);
            ++this.BloodSpawned;
          }
        }
        else if (this.AttackID == 2)
        {
          if ((double) this.MyAnim[this.AttackAnims[this.AttackID]].time > 1.0)
          {
            Object.Instantiate<GameObject>(this.BloodEffect, this.RightHand.position, Quaternion.identity);
            this.BloodSpawned += 2;
            this.MyAudio.Stop();
          }
        }
        else if (this.AttackID == 3)
        {
          if ((double) this.MyAnim[this.AttackAnims[this.AttackID]].time > 0.5)
          {
            Object.Instantiate<GameObject>(this.BloodEffect, this.RightHand.position, Quaternion.identity);
            this.BloodSpawned += 2;
            this.MyAudio.Stop();
          }
        }
        else if (this.AttackID == 4)
        {
          if ((double) this.MyAnim[this.AttackAnims[this.AttackID]].time > 0.5)
            this.MyAudio.Stop();
        }
        else if (this.AttackID == 5)
        {
          if (this.BloodSpawned == 0)
          {
            if ((double) this.MyAnim[this.AttackAnims[this.AttackID]].time > 0.25)
            {
              Object.Instantiate<GameObject>(this.BloodEffect, this.RightFoot.position, Quaternion.identity);
              this.MyAudio.Stop();
              ++this.BloodSpawned;
            }
          }
          else if ((double) this.MyAnim[this.AttackAnims[this.AttackID]].time > 0.89999997615814209)
          {
            Object.Instantiate<GameObject>(this.BloodEffect, this.RightFoot.position, Quaternion.identity);
            ++this.BloodSpawned;
          }
        }
      }
    }
    else if (this.KillingSenpai)
    {
      this.CompressionFX.Parasite = Mathf.MoveTowards(this.CompressionFX.Parasite, 0.0f, Time.deltaTime);
      this.Distorted.Distortion = Mathf.MoveTowards(this.Distorted.Distortion, 0.0f, Time.deltaTime);
      this.StaticNoise.volume -= Time.deltaTime * 0.5f;
      this.Static.Fade = Mathf.MoveTowards(this.Static.Fade, 0.0f, Time.deltaTime * 0.5f);
      this.Jukebox.volume -= Time.deltaTime * 0.5f;
      this.SnapStatic.volume -= (float) ((double) Time.deltaTime * 0.5 * 0.20000000298023224);
      this.SNAPLabel.alpha = Mathf.MoveTowards(this.SNAPLabel.alpha, 0.0f, Time.deltaTime * 0.5f);
      this.SnapVoice.volume -= Time.deltaTime;
      this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(this.TargetStudent.transform.position - this.transform.position), Time.deltaTime);
      this.transform.position = Vector3.MoveTowards(this.transform.position, this.TargetStudent.transform.position + this.TargetStudent.transform.forward * 1f, Time.deltaTime);
      this.Speed += Time.deltaTime;
      if (this.AttackPhase < 3)
      {
        this.MainCamera.transform.position = Vector3.Lerp(this.MainCamera.transform.position, this.FinalSnapPOV.position, (float) ((double) Time.deltaTime * (double) this.Speed * 0.33333000540733337));
        this.MainCamera.transform.rotation = Quaternion.Slerp(this.MainCamera.transform.rotation, this.FinalSnapPOV.rotation, (float) ((double) Time.deltaTime * (double) this.Speed * 0.33333000540733337));
      }
      else
      {
        this.MainCamera.transform.position = Vector3.Lerp(this.MainCamera.transform.position, this.SuicidePOV.position, (float) ((double) Time.deltaTime * (double) this.Speed * 0.10000000149011612));
        this.MainCamera.transform.rotation = Quaternion.Slerp(this.MainCamera.transform.rotation, this.SuicidePOV.rotation, (float) ((double) Time.deltaTime * (double) this.Speed * 0.10000000149011612));
        if (this.Whisper)
        {
          this.Rumble.volume = Mathf.MoveTowards(this.Rumble.volume, 0.5f, Time.deltaTime * 0.05f);
          this.WhisperTimer += Time.deltaTime;
          if ((double) this.WhisperTimer > 0.5)
          {
            this.WhisperTimer = 0.0f;
            AudioSource.PlayClipAtPoint(this.Whispers[Random.Range(1, this.Whispers.Length)], this.MainCamera.transform.position + new Vector3((float) (11.0 - 10.0 * (double) this.Rumble.volume * 2.0), (float) (11.0 - 10.0 * (double) this.Rumble.volume * 2.0), (float) (11.0 - 10.0 * (double) this.Rumble.volume * 2.0)));
            this.NewDoIt = Object.Instantiate<GameObject>(this.DoIt, this.SNAPLabel.parent.transform.position, Quaternion.identity);
            this.NewDoIt.transform.parent = this.SNAPLabel.parent.transform;
            this.NewDoIt.transform.localScale = new Vector3(1f, 1f, 1f);
            this.NewDoIt.transform.localPosition = new Vector3(Random.Range(-700f, 700f), Random.Range(-450f, 450f), 0.0f);
            this.NewDoIt.transform.localEulerAngles = new Vector3(Random.Range(-15f, 15f), Random.Range(-15f, 15f), Random.Range(-15f, 15f));
          }
        }
      }
      if (this.AttackPhase == 0)
      {
        if ((double) this.MyAnim["f02_snapKill_00"].time > (double) this.MyAnim["f02_snapKill_00"].length * 0.20000000298023224)
        {
          Object.Instantiate<GameObject>(this.BloodEffect, this.Knife.transform.position, Quaternion.identity);
          ++this.AttackPhase;
        }
      }
      else if (this.AttackPhase == 1)
      {
        if ((double) this.MyAnim["f02_snapKill_00"].time > (double) this.MyAnim["f02_snapKill_00"].length * 0.36000001430511475)
        {
          Object.Instantiate<GameObject>(this.BloodEffect, this.Knife.transform.position, Quaternion.identity);
          ++this.AttackPhase;
        }
      }
      else if (this.AttackPhase == 2)
      {
        if ((double) this.MyAnim["f02_snapKill_00"].time > 13.0)
        {
          this.MyAnim["f02_stareAtKnife_00"].layer = 100;
          this.MyAnim.Play("f02_stareAtKnife_00");
          this.MyAnim["f02_stareAtKnife_00"].weight = 0.0f;
          this.Whisper = true;
          this.Rumble.Play();
          this.Speed = 0.0f;
          ++this.AttackPhase;
        }
      }
      else if (this.AttackPhase == 3)
      {
        this.Knife.transform.localEulerAngles = Vector3.Lerp(this.Knife.transform.localEulerAngles, new Vector3(0.0f, 0.0f, 0.0f), Time.deltaTime * this.Speed);
        this.MyAnim["f02_stareAtKnife_00"].weight = Mathf.Lerp(this.MyAnim["f02_stareAtKnife_00"].weight, 1f, Time.deltaTime * this.Speed);
        if ((double) this.MyAnim["f02_stareAtKnife_00"].weight > 0.99900001287460327)
        {
          this.SuicidePrompt.alpha += Time.deltaTime;
          this.ImpatienceTimer += Time.deltaTime;
          if (Input.GetButtonDown("X") || (double) this.ImpatienceTimer > (double) this.ImpatienceLimit)
          {
            this.MyAnim["f02_suicide_00"].layer = 101;
            this.MyAnim.Play("f02_suicide_00");
            this.MyAnim["f02_suicide_00"].weight = 0.0f;
            this.MyAnim["f02_suicide_00"].time = 2f;
            this.MyAnim["f02_suicide_00"].speed = 0.0f;
            ++this.AttackPhase;
            if ((double) this.ImpatienceTimer > (double) this.ImpatienceLimit)
            {
              this.ImpatienceLimit = 2f;
              this.ImpatienceTimer = 0.0f;
            }
            ++this.Taps;
          }
        }
      }
      else if (this.AttackPhase == 4)
      {
        this.SuicidePrompt.alpha += Time.deltaTime;
        this.ImpatienceTimer += Time.deltaTime;
        if (Input.GetButtonDown("X") || (double) this.ImpatienceTimer > (double) this.ImpatienceLimit)
        {
          this.Target += 0.1f;
          this.SpeedUp = true;
          if ((double) this.ImpatienceTimer > (double) this.ImpatienceLimit)
          {
            this.ImpatienceLimit = 2f;
            this.ImpatienceTimer = 0.0f;
          }
          ++this.Taps;
        }
        if (this.SpeedUp)
        {
          this.AnimSpeed += Time.deltaTime;
          if ((double) this.AnimSpeed > 1.0)
            this.SpeedUp = false;
        }
        else
          this.AnimSpeed = Mathf.MoveTowards(this.AnimSpeed, 0.0f, Time.deltaTime);
        this.MyAnim["f02_suicide_00"].weight = Mathf.Lerp(this.MyAnim["f02_suicide_00"].weight, this.Target, this.AnimSpeed * Time.deltaTime);
        if ((double) this.MyAnim["f02_suicide_00"].weight >= 1.0)
        {
          this.SpeedUp = false;
          this.AnimSpeed = 0.0f;
          this.Target = 2f;
          ++this.AttackPhase;
        }
      }
      else if (this.AttackPhase == 5)
      {
        this.ImpatienceTimer += Time.deltaTime;
        if (Input.GetButtonDown("X") || (double) this.ImpatienceTimer > (double) this.ImpatienceLimit)
        {
          this.Target += 0.1f;
          this.SpeedUp = true;
          if ((double) this.ImpatienceTimer > (double) this.ImpatienceLimit)
          {
            this.ImpatienceLimit = 2f;
            this.ImpatienceTimer = 0.0f;
          }
          ++this.Taps;
        }
        if (this.SpeedUp)
        {
          this.AnimSpeed += Time.deltaTime;
          if ((double) this.AnimSpeed > 1.0)
            this.SpeedUp = false;
        }
        else
          this.AnimSpeed = Mathf.MoveTowards(this.AnimSpeed, 0.0f, Time.deltaTime);
        this.MyAnim["f02_suicide_00"].time = Mathf.Lerp(this.MyAnim["f02_suicide_00"].time, this.Target, this.AnimSpeed * Time.deltaTime);
        if ((double) this.MyAnim["f02_suicide_00"].time >= 3.6666600704193115)
        {
          this.MyAnim["f02_suicide_00"].speed = 1f;
          this.SuicidePrompt.alpha = 0.0f;
          this.Rumble.volume = 0.0f;
          Object.Destroy((Object) this.NewDoIt);
          this.Whisper = false;
          ++this.AttackPhase;
        }
      }
      else if (this.AttackPhase == 6)
      {
        if ((double) this.MyAnim["f02_suicide_00"].time >= (double) this.MyAnim["f02_suicide_00"].length * 0.35499998927116394)
        {
          Object.Instantiate<GameObject>(this.StabBloodEffect, this.Knife.transform.position, Quaternion.identity);
          ++this.AttackPhase;
        }
      }
      else if ((double) this.MyAnim["f02_suicide_00"].time >= (double) this.MyAnim["f02_suicide_00"].length * 0.47499999403953552)
      {
        this.MyListener.enabled = false;
        this.MainCamera.transform.parent = (Transform) null;
        this.MainCamera.transform.position = new Vector3(0.0f, 2025f, -11f);
        this.MainCamera.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        if ((double) this.MyAnim["f02_suicide_00"].time >= (double) this.MyAnim["f02_suicide_00"].length)
        {
          if (!GameGlobals.Debug)
          {
            PlayerPrefs.SetInt("SNAP", 1);
            PlayerPrefs.SetInt("a", 1);
          }
          SceneManager.LoadScene("LoadingScene");
        }
      }
    }
    if (this.InputDevice.Type == InputDeviceType.MouseAndKeyboard)
    {
      this.SuicidePrompt.text = "F";
      this.SuicideSprite.enabled = false;
    }
    else
    {
      this.SuicidePrompt.text = "";
      this.SuicideSprite.enabled = true;
    }
    if ((double) this.ListenTimer <= 0.0)
      return;
    this.ListenTimer = Mathf.MoveTowards(this.ListenTimer, 0.0f, Time.deltaTime);
  }

  private void UpdateMovement()
  {
    int num1 = (int) this.MyController.Move(Physics.gravity * Time.deltaTime);
    float axis1 = Input.GetAxis("Vertical");
    float axis2 = Input.GetAxis("Horizontal");
    Vector3 vector3_1 = this.transform.TransformDirection(Vector3.forward) with
    {
      y = 0.0f
    };
    vector3_1 = vector3_1.normalized;
    Vector3 vector3_2 = new Vector3(vector3_1.z, 0.0f, -vector3_1.x);
    Vector3 vector3_3 = axis2 * vector3_2 + axis1 * vector3_1;
    if ((double) Mathf.Abs(axis1) > 0.5 || (double) Mathf.Abs(axis2) > 0.5)
    {
      this.MyAnim[this.WalkAnim].speed = Mathf.Abs(axis1) + Mathf.Abs(axis2);
      if ((double) this.MyAnim[this.WalkAnim].speed > 1.0)
        this.MyAnim[this.WalkAnim].speed = 1f;
      this.MyAnim.CrossFade(this.WalkAnim);
      int num2 = (int) this.MyController.Move(vector3_3 * Time.deltaTime);
    }
    else
      this.MyAnim.CrossFade(this.IdleAnim);
    float num3 = Input.GetAxis("Mouse X") * (float) OptionGlobals.Sensitivity;
    if ((double) num3 != 0.0)
      this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y + num3 * 36f * Time.deltaTime, this.transform.eulerAngles.z);
    if (!Input.GetButtonDown("LB"))
      return;
    int num4 = (int) this.MyController.Move(vector3_3 * 4f);
    this.SetGlitches(true);
    this.GlitchTimeLimit = 0.1f;
  }

  private void MoveTowardsTarget(Vector3 target)
  {
    int num = (int) this.MyController.Move((target - this.transform.position) * (Time.deltaTime * 10f));
  }

  private void RotateTowardsTarget(Quaternion target) => this.transform.rotation = Quaternion.Slerp(this.transform.rotation, target, Time.deltaTime * 10f);

  private void SetGlitches(bool State)
  {
    this.GlitchTimer = 0.0f;
    this.Glitch1.enabled = State;
    this.Glitch2.enabled = State;
    this.Glitch4.enabled = State;
    this.Glitch5.enabled = State;
    this.Glitch6.enabled = State;
    this.Glitch7.enabled = State;
    this.Glitch10.enabled = State;
    this.Glitch11.enabled = State;
    if (!State)
      return;
    this.MyAudio.clip = this.Buzz;
    this.MyAudio.volume = 0.5f;
    this.MyAudio.pitch = Random.Range(0.5f, 2f);
    this.MyAudio.Play();
  }

  public void ChooseAttack()
  {
    this.BloodSpawned = 0;
    this.SetGlitches(true);
    this.GlitchTimeLimit = 0.5f;
    this.AttackID = Random.Range(1, 6);
    while (this.AttacksUsed[this.AttackID])
      this.AttackID = Random.Range(1, 6);
    this.AttacksUsed[this.AttackID] = true;
    ++this.Attacks;
    if (this.AttackID == 1)
    {
      this.TargetStudent.transform.position = this.transform.position + this.transform.forward * 0.0001f;
      this.TargetStudent.transform.LookAt(this.transform.position);
    }
    else if (this.AttackID == 2)
    {
      this.TargetStudent.transform.position = this.transform.position + this.transform.forward * 0.5f;
      this.TargetStudent.transform.LookAt(this.transform.position);
    }
    else if (this.AttackID == 3)
    {
      this.TargetStudent.transform.position = this.transform.position + this.transform.forward * 0.3f;
      this.TargetStudent.transform.LookAt(this.transform.position);
    }
    else if (this.AttackID == 4)
    {
      this.TargetStudent.transform.position = this.transform.position + this.transform.forward * 0.3f;
      this.TargetStudent.transform.rotation = this.transform.rotation;
    }
    else if (this.AttackID == 5)
    {
      this.TargetStudent.transform.position = this.transform.position + this.transform.forward * 0.66666f;
      this.TargetStudent.transform.rotation = this.transform.rotation;
    }
    Physics.SyncTransforms();
    this.MyAnim.Play(this.AttackAnims[this.AttackID]);
    this.MyAnim[this.AttackAnims[this.AttackID]].time = 0.0f;
    this.TargetStudent.MyAnim.Play(this.TargetStudent.AttackAnims[this.AttackID]);
    this.TargetStudent.MyAnim[this.TargetStudent.AttackAnims[this.AttackID]].time = 0.0f;
  }

  public void Teleport()
  {
    if (!this.Armed)
    {
      bool flag = false;
      while (!flag)
      {
        foreach (WeaponScript weapon in this.Weapons)
        {
          if ((Object) weapon != (Object) null)
          {
            this.SetGlitches(true);
            this.GlitchTimeLimit = 1f;
            this.transform.position = weapon.transform.position;
            flag = true;
          }
        }
      }
    }
    else
    {
      ++this.Teleports;
      this.SetGlitches(true);
      this.GlitchTimeLimit = 1f;
      if (this.Teleports == 1)
      {
        this.transform.position = this.StudentManager.Students[1].transform.position + this.StudentManager.Students[1].transform.forward * 2f;
        this.transform.LookAt(this.StudentManager.Students[1].transform.position);
      }
      else
      {
        this.transform.position = this.StudentManager.Students[1].transform.position + this.StudentManager.Students[1].transform.forward * 0.9f;
        this.transform.LookAt(this.StudentManager.Students[1].transform.position);
      }
    }
    Physics.SyncTransforms();
  }
}
