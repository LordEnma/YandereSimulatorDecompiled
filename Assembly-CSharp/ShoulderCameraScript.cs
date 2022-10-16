// Decompiled with JetBrains decompiler
// Type: ShoulderCameraScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ShoulderCameraScript : MonoBehaviour
{
  public PauseScreenScript PauseScreen;
  public CounselorScript Counselor;
  public YandereScript Yandere;
  public RPG_Camera RPGCamera;
  public PortalScript Portal;
  public GameObject HeartbrokenCamera;
  public GameObject HUD;
  public Transform Smartphone;
  public Transform Teacher;
  public Transform ShoulderFocus;
  public Transform ShoulderPOV;
  public Transform EightiesSpineFollower;
  public Transform EightiesCameraFocus;
  public Transform EightiesCameraPOV;
  public Transform CameraFocus;
  public Transform CameraPOV;
  public Transform NoticedFocus;
  public Transform NoticedPOV;
  public Transform StruggleFocus;
  public Transform StrugglePOV;
  public Transform Focus;
  public Vector3 LastPosition;
  public Vector3 TeacherLossFocus;
  public Vector3 TeacherLossPOV;
  public Vector3 LossFocus;
  public Vector3 LossPOV;
  public bool GoingToCounselor;
  public bool ObstacleCounter;
  public bool AimingCamera;
  public bool OverShoulder;
  public bool Summoning;
  public bool LookDown;
  public bool Scolding;
  public bool Struggle;
  public bool Counter;
  public bool Noticed;
  public bool Spoken;
  public bool Skip;
  public AudioClip StruggleLose;
  public AudioClip Slam;
  public float NoticedHeight;
  public float NoticedTimer;
  public float NoticedSpeed;
  public float ReturnSpeed = 10f;
  public float StruggleDOF = 2f;
  public float Height;
  public float Shake;
  public float PullBackTimer;
  public float Timer;
  public int NoticedLimit;
  public int Phase;

  private void LateUpdate()
  {
    if (this.PauseScreen.Show)
      return;
    if (this.OverShoulder)
    {
      if (this.RPGCamera.enabled)
      {
        this.ShoulderFocus.position = this.RPGCamera.cameraPivot.position;
        this.LastPosition = this.transform.position;
        this.RPGCamera.enabled = false;
      }
      if (this.Yandere.TargetStudent.Counselor)
        this.transform.position = Vector3.Lerp(this.transform.position, this.ShoulderPOV.position + new Vector3(0.0f, -0.49f, 0.0f), Time.deltaTime * 10f);
      else
        this.transform.position = Vector3.Lerp(this.transform.position, this.ShoulderPOV.position, Time.deltaTime * 10f);
      this.ShoulderFocus.position = Vector3.Lerp(this.ShoulderFocus.position, this.Yandere.TargetStudent.transform.position + Vector3.up * this.Height, Time.deltaTime * 10f);
      this.transform.LookAt(this.ShoulderFocus);
    }
    else if (this.AimingCamera)
    {
      if (!this.Yandere.StudentManager.Eighties)
      {
        this.transform.position = this.CameraPOV.position;
        this.transform.LookAt(this.CameraFocus);
      }
      else
      {
        this.EightiesSpineFollower.localEulerAngles = new Vector3(this.Yandere.Spine[3].localEulerAngles.x, 0.0f, 0.0f);
        this.EightiesSpineFollower.transform.position = new Vector3(this.Yandere.transform.position.x, this.Yandere.Spine[3].position.y, this.Yandere.transform.position.z);
        if (this.Yandere.Stance.Current == StanceType.Standing)
        {
          this.transform.position = this.EightiesCameraPOV.position;
          this.transform.LookAt(this.EightiesCameraFocus);
        }
        else if (this.Yandere.Stance.Current == StanceType.Crouching)
        {
          this.transform.position = new Vector3(this.Yandere.transform.position.x, this.Yandere.transform.position.y + 1f, this.Yandere.transform.position.z);
        }
        else
        {
          if (this.Yandere.Stance.Current != StanceType.Crawling)
            return;
          this.transform.position = new Vector3(this.Yandere.transform.position.x, this.Yandere.transform.position.y + 0.5f, this.Yandere.transform.position.z);
        }
      }
    }
    else if (this.Noticed)
    {
      if (this.Yandere.Drown)
        return;
      if ((double) this.NoticedTimer == 0.0)
      {
        this.Yandere.CameraEffects.UpdateDOF(1f);
        this.GetComponent<Camera>().cullingMask &= -8193;
        StudentScript component = this.Yandere.Senpai.GetComponent<StudentScript>();
        if (component.Teacher)
        {
          this.GoingToCounselor = true;
          this.NoticedHeight = 1.6f;
          this.NoticedLimit = 6;
        }
        if (component.Club == ClubType.Council)
        {
          this.GoingToCounselor = true;
          this.NoticedHeight = 1.375f;
          this.NoticedLimit = 6;
        }
        else if (component.Witnessed == StudentWitnessType.Stalking)
        {
          this.NoticedHeight = 1.481275f;
          this.NoticedLimit = 7;
        }
        else
        {
          this.NoticedHeight = 1.375f;
          this.NoticedLimit = 6;
        }
        this.NoticedPOV.position = this.Yandere.Senpai.position + this.Yandere.Senpai.forward + Vector3.up * this.NoticedHeight;
        this.NoticedPOV.LookAt(this.Yandere.Senpai.position + Vector3.up * this.NoticedHeight);
        this.NoticedFocus.position = this.transform.position + this.transform.forward;
        this.NoticedSpeed = 10f;
      }
      this.NoticedTimer += Time.deltaTime;
      if (this.Phase == 1)
      {
        if (Input.GetButtonDown("A") && !this.Yandere.Attacking)
        {
          this.Yandere.transform.rotation = Quaternion.LookRotation(this.Yandere.Senpai.position - this.Yandere.transform.position);
          this.NoticedTimer += 10f;
        }
        this.NoticedFocus.position = Vector3.Lerp(this.NoticedFocus.position, this.Yandere.Senpai.position + Vector3.up * this.NoticedHeight, Time.deltaTime * 10f);
        this.NoticedPOV.Translate(Vector3.forward * Time.deltaTime * -0.075f);
        if ((double) this.NoticedTimer > 1.0 && !this.Spoken && !this.Yandere.Senpai.GetComponent<StudentScript>().Teacher)
        {
          this.Yandere.Senpai.GetComponent<StudentScript>().DetermineSenpaiReaction();
          this.Spoken = true;
        }
        if ((double) this.NoticedTimer > (double) this.NoticedLimit || this.Skip)
        {
          this.Yandere.Senpai.GetComponent<StudentScript>().Character.SetActive(false);
          this.GetComponent<Camera>().cullingMask |= 8192;
          this.NoticedPOV.position = this.Yandere.transform.position + this.Yandere.transform.forward + Vector3.up * 1.375f;
          this.NoticedPOV.LookAt(this.Yandere.transform.position + Vector3.up * 1.375f);
          this.NoticedFocus.position = this.Yandere.transform.position + Vector3.up * 1.375f;
          this.transform.position = this.NoticedPOV.position;
          this.NoticedTimer = (float) this.NoticedLimit;
          this.Phase = 2;
          if (this.GoingToCounselor)
          {
            this.Yandere.CharacterAnimation.CrossFade("f02_disappointed_00");
          }
          else
          {
            this.Yandere.CharacterAnimation["f02_sadEyebrows_00"].weight = 1f;
            this.Yandere.CharacterAnimation.CrossFade("f02_whimper_00");
            this.Yandere.Subtitle.UpdateLabel(SubtitleType.YandereWhimper, 1, 3.5f);
            Debug.Log((object) "Yandere-chan shoulder be whimpering now.");
            if (this.Yandere.StudentManager.Eighties)
              this.Yandere.LoseGentleEyes();
            this.Yandere.CameraEffects.UpdateDOF(1f);
          }
        }
      }
      else if (this.Phase == 2)
      {
        if (Input.GetButtonDown("A"))
          this.NoticedTimer += 10f;
        if (!this.GoingToCounselor)
          this.Yandere.EyeShrink = Mathf.MoveTowards(this.Yandere.EyeShrink, 0.5f, Time.deltaTime * 0.125f);
        this.NoticedPOV.Translate(Vector3.forward * Time.deltaTime * 0.075f);
        this.Yandere.CameraEffects.UpdateDOF(0.75f);
        if (this.GoingToCounselor)
        {
          this.Yandere.CharacterAnimation.CrossFade("f02_disappointed_00");
        }
        else
        {
          this.Yandere.CharacterAnimation.CrossFade("f02_whimper_00");
          if ((double) this.Yandere.CharacterAnimation["f02_whimper_00"].time > 3.5)
            this.Yandere.CharacterAnimation["f02_whimper_00"].speed -= Time.deltaTime;
        }
        if ((double) this.NoticedTimer > (double) (this.NoticedLimit + 4))
        {
          if (!this.GoingToCounselor)
          {
            this.NoticedPOV.Translate(Vector3.back * 2f);
            this.NoticedPOV.transform.position = new Vector3(this.NoticedPOV.transform.position.x, this.Yandere.transform.position.y + 1f, this.NoticedPOV.transform.position.z);
            this.NoticedSpeed = 1f;
            this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_down_22");
            this.HeartbrokenCamera.SetActive(true);
            this.Yandere.Police.Invalid = true;
            this.Yandere.Collapse = true;
            this.Phase = 3;
          }
          else
          {
            this.Yandere.Police.Darkness.enabled = true;
            this.Yandere.HUD.enabled = true;
            this.Yandere.HUD.alpha = 1f;
            if ((double) this.Yandere.Police.Timer == 300.0 && this.Yandere.Police.Corpses - this.Yandere.Police.HiddenCorpses <= 0)
              this.HUD.SetActive(false);
            this.Phase = 4;
          }
        }
      }
      else if (this.Phase == 3)
        this.NoticedFocus.transform.position = new Vector3(this.NoticedFocus.transform.position.x, Mathf.Lerp(this.NoticedFocus.transform.position.y, this.Yandere.transform.position.y + 1f, Time.deltaTime), this.NoticedFocus.transform.position.z);
      else if (this.Phase == 4)
      {
        UISprite darkness = this.Yandere.Police.Darkness;
        darkness.color = darkness.color + new Color(0.0f, 0.0f, 0.0f, Time.deltaTime);
        this.NoticedPOV.Translate(Vector3.forward * Time.deltaTime * 0.075f);
        if ((double) this.Yandere.Police.Darkness.color.a >= 1.0)
        {
          Debug.Log((object) ("As of this exact moment, the game believes that there are " + this.Yandere.Police.BloodyWeapons.ToString() + " bloody weapons on school grounds."));
          if ((double) this.Yandere.Police.Timer != 300.0 || this.Yandere.Police.Corpses - this.Yandere.Police.HiddenCorpses > 0 || this.Yandere.Police.BloodyWeapons > 0)
          {
            Debug.Log((object) "Ending day instead of going to counselor.");
            this.HUD.SetActive(true);
            this.Portal.EndDay();
            this.enabled = false;
          }
          else
          {
            Debug.Log((object) "This part of the code, specifically, is now sending Yandere-chan to the counselor.");
            if ((Object) this.Yandere.Mask != (Object) null)
              this.Yandere.Mask.Drop();
            this.Yandere.StudentManager.PreventAlarm();
            this.Yandere.Subtitle.gameObject.SetActive(false);
            this.Counselor.InfirmaryCabinetDoor.Prompt.Label[0].text = "     Locked";
            this.Counselor.InfirmaryCabinetDoor.Prompt.HideButton[2] = true;
            this.Counselor.InfirmaryCabinetDoor.Locked = true;
            this.Counselor.InfirmaryCabinetDoor.Open = false;
            this.Counselor.InfirmaryCabinetDoor.Timer = 0.0f;
            this.Counselor.InfirmaryCabinetDoor.UpdateLabel();
            this.Counselor.Crime = this.Yandere.Senpai.GetComponent<StudentScript>().Witnessed;
            this.Counselor.MyAnimation.Play("CounselorArmsCrossed");
            this.Counselor.Laptop.SetActive(false);
            this.Counselor.Interrogating = true;
            this.Counselor.LookAtPlayer = true;
            this.Counselor.Stern = true;
            this.Counselor.Timer = 0.0f;
            this.Counselor.transform.position = new Vector3(-28.93333f, 0.0f, 12f);
            this.Counselor.RedPen.SetActive(false);
            this.transform.Translate(Vector3.forward * -1f);
            this.Yandere.Senpai.GetComponent<StudentScript>().Character.SetActive(true);
            this.Yandere.transform.localEulerAngles = new Vector3(0.0f, -90f, 0.0f);
            this.Yandere.transform.position = new Vector3(-27.51f, 0.0f, 12f);
            this.Yandere.Police.Darkness.color = new Color(0.0f, 0.0f, 0.0f, 1f);
            this.Yandere.CharacterAnimation.Play("f02_sit_00");
            this.Yandere.Noticed = false;
            this.Yandere.Sanity = 100f;
            Physics.SyncTransforms();
            this.GoingToCounselor = false;
            this.enabled = false;
            this.NoticedTimer = 0.0f;
            this.Phase = 1;
          }
        }
      }
      if (this.Phase >= 5)
        return;
      this.transform.position = Vector3.Lerp(this.transform.position, this.NoticedPOV.position, Time.deltaTime * this.NoticedSpeed);
      this.transform.LookAt(this.NoticedFocus);
    }
    else if (this.Scolding)
    {
      if ((double) this.Timer == 0.0)
      {
        this.NoticedHeight = 1.6f;
        this.NoticedPOV.position = this.Teacher.position + this.Teacher.forward + Vector3.up * this.NoticedHeight;
        this.NoticedPOV.LookAt(this.Teacher.position + Vector3.up * this.NoticedHeight);
        this.NoticedFocus.position = this.Teacher.position + Vector3.up * this.NoticedHeight;
        this.NoticedSpeed = 10f;
      }
      this.transform.position = Vector3.Lerp(this.transform.position, this.NoticedPOV.position, Time.deltaTime * this.NoticedSpeed);
      this.transform.LookAt(this.NoticedFocus);
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 6.0)
      {
        this.Portal.ClassDarkness.enabled = true;
        this.Portal.Transition = true;
        this.Portal.FadeOut = true;
      }
      if ((double) this.Timer <= 7.0)
        return;
      this.Scolding = false;
      this.Timer = 0.0f;
    }
    else if (this.Counter)
    {
      if ((double) this.Timer == 0.0)
      {
        this.StruggleFocus.position = this.transform.position + this.transform.forward;
        this.StrugglePOV.position = this.transform.position;
      }
      this.transform.position = Vector3.Lerp(this.transform.position, this.StrugglePOV.position, Time.deltaTime * 10f);
      this.transform.LookAt(this.StruggleFocus);
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 0.5 && this.Phase < 2)
      {
        this.Yandere.CameraEffects.MurderWitnessed();
        this.Yandere.Jukebox.GameOver();
        ++this.Phase;
      }
      if ((double) this.Timer > 1.3999999761581421 && this.Phase < 3)
      {
        this.Yandere.Subtitle.UpdateLabel(SubtitleType.TeacherAttackReaction, 1, 4f);
        ++this.Phase;
      }
      if ((double) this.Timer > 6.0 && this.Yandere.Armed)
        this.Yandere.EquippedWeapon.Drop();
      if ((double) this.Timer > 6.6666598320007324 && this.Phase < 4)
      {
        this.GetComponent<AudioSource>().PlayOneShot(this.Slam);
        ++this.Phase;
      }
      if ((double) this.Timer > 10.0 && this.Phase < 5)
      {
        this.HeartbrokenCamera.SetActive(true);
        ++this.Phase;
      }
      if ((double) this.Timer < 5.0)
      {
        this.StruggleFocus.localPosition = Vector3.Lerp(this.StruggleFocus.localPosition, new Vector3(0.0f, 1.4f, 0.7f), Time.deltaTime);
        this.StrugglePOV.localPosition = Vector3.Lerp(this.StrugglePOV.localPosition, new Vector3(0.5f, 1.4f, 0.3f), Time.deltaTime);
      }
      else if ((double) this.Timer < 10.0)
      {
        this.PullBackTimer = (double) this.Timer >= 6.5 ? Mathf.MoveTowards(this.PullBackTimer, 0.0f, Time.deltaTime * 0.428571433f) : Mathf.MoveTowards(this.PullBackTimer, 1.5f, Time.deltaTime);
        this.transform.Translate(Vector3.back * Time.deltaTime * 10f * this.PullBackTimer);
        this.StruggleFocus.localPosition = Vector3.Lerp(this.StruggleFocus.localPosition, new Vector3(0.0f, 0.3f, -0.766666f), Time.deltaTime);
        this.StrugglePOV.localPosition = Vector3.Lerp(this.StrugglePOV.localPosition, new Vector3(0.75f, 0.3f, -0.966666f), Time.deltaTime);
      }
      else
      {
        this.StruggleFocus.localPosition = Vector3.Lerp(this.StruggleFocus.localPosition, new Vector3(0.0f, 0.3f, -0.766666f), Time.deltaTime);
        this.StrugglePOV.localPosition = Vector3.Lerp(this.StrugglePOV.localPosition, new Vector3(0.75f, 0.3f, -0.966666f), Time.deltaTime);
      }
    }
    else if (this.ObstacleCounter)
    {
      this.StruggleFocus.position += new Vector3(this.Shake * Random.Range(-1f, 1f), this.Shake * Random.Range(-0.5f, 0.5f), this.Shake * Random.Range(-1f, 1f));
      this.Shake = Mathf.Lerp(this.Shake, 0.0f, Time.deltaTime * 5f);
      if (this.Yandere.Armed)
        this.Yandere.EquippedWeapon.transform.localEulerAngles = new Vector3(0.0f, 180f, 0.0f);
      if ((double) this.Timer == 0.0)
      {
        this.StruggleFocus.position = this.transform.position + this.transform.forward;
        this.StrugglePOV.position = this.transform.position;
      }
      this.transform.position = Vector3.Lerp(this.transform.position, this.StrugglePOV.position, Time.deltaTime * 10f);
      this.transform.LookAt(this.StruggleFocus);
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 0.5 && this.Phase < 2)
      {
        this.Yandere.CameraEffects.MurderWitnessed();
        this.Yandere.Jukebox.GameOver();
        ++this.Phase;
      }
      if ((double) this.Timer > 7.5999999046325684 && this.Phase < 3)
      {
        if (this.Yandere.Armed)
          this.Yandere.EquippedWeapon.Drop();
        this.Shake += 0.2f;
        ++this.Phase;
      }
      if ((double) this.Timer > 10.0 && this.Phase < 4)
      {
        this.Shake += 0.2f;
        ++this.Phase;
      }
      if ((double) this.Timer > 12.0 && this.Phase < 5)
      {
        this.HeartbrokenCamera.GetComponent<Camera>().cullingMask |= 512;
        this.HeartbrokenCamera.SetActive(true);
        ++this.Phase;
      }
      if ((double) this.Timer < 6.0)
      {
        this.StruggleFocus.localPosition = Vector3.Lerp(this.StruggleFocus.localPosition, new Vector3(-0.166666f, 1.2f, 0.82f), Time.deltaTime);
        this.StrugglePOV.localPosition = Vector3.Lerp(this.StrugglePOV.localPosition, new Vector3(0.66666f, 1.2f, 0.82f), Time.deltaTime);
        this.StruggleDOF = Mathf.MoveTowards(this.StruggleDOF, 0.66666f, Time.deltaTime);
      }
      else if ((double) this.Timer < 8.5)
      {
        this.StruggleFocus.localPosition = Vector3.Lerp(this.StruggleFocus.localPosition, new Vector3(-0.166666f, 1.2f, 0.82f), Time.deltaTime);
        this.StrugglePOV.localPosition = Vector3.Lerp(this.StrugglePOV.localPosition, new Vector3(2f, 1.2f, 0.82f), Time.deltaTime);
        this.StruggleDOF = Mathf.MoveTowards(this.StruggleDOF, 1f, Time.deltaTime);
      }
      else if ((double) this.Timer < 12.0)
      {
        this.StruggleFocus.localPosition = Vector3.Lerp(this.StruggleFocus.localPosition, new Vector3(-0.85f, 0.5f, 1.75f), Time.deltaTime * 2f);
        this.StrugglePOV.localPosition = Vector3.Lerp(this.StrugglePOV.localPosition, new Vector3(-0.85f, 0.5f, 3f), Time.deltaTime * 2f);
      }
      else
      {
        this.StruggleFocus.localPosition = Vector3.Lerp(this.StruggleFocus.localPosition, new Vector3(-0.85f, 1.1f, 1.75f), Time.deltaTime * 2f);
        this.StrugglePOV.localPosition = Vector3.Lerp(this.StrugglePOV.localPosition, new Vector3(-0.85f, 1f, 4f), Time.deltaTime * 2f);
      }
      if (this.HeartbrokenCamera.activeInHierarchy)
        return;
      this.Yandere.CameraEffects.UpdateDOF(this.StruggleDOF);
    }
    else if (this.Struggle)
    {
      this.transform.position = Vector3.Lerp(this.transform.position, this.StrugglePOV.position, Time.deltaTime * 10f);
      this.transform.LookAt(this.StruggleFocus);
      if (!this.Yandere.Lost)
        return;
      this.StruggleFocus.localPosition = Vector3.MoveTowards(this.StruggleFocus.localPosition, this.LossFocus, Time.deltaTime);
      this.StrugglePOV.localPosition = Vector3.MoveTowards(this.StrugglePOV.localPosition, this.LossPOV, Time.deltaTime);
      if ((double) this.Timer == 0.0)
      {
        AudioSource component = this.GetComponent<AudioSource>();
        component.clip = this.StruggleLose;
        component.Play();
      }
      this.Timer += Time.deltaTime;
      if ((double) this.Timer < 3.0)
      {
        this.transform.Translate(Vector3.back * (float) ((double) Time.deltaTime * 10.0 * (double) this.Timer * (3.0 - (double) this.Timer)));
      }
      else
      {
        if (this.HeartbrokenCamera.activeInHierarchy)
          return;
        this.HeartbrokenCamera.SetActive(true);
        this.Yandere.Jukebox.GameOver();
        this.enabled = false;
      }
    }
    else if (this.Yandere.Attacked)
    {
      this.Focus.transform.parent = (Transform) null;
      this.Focus.transform.position = Vector3.Lerp(this.Focus.transform.position, this.Yandere.Hips.position, Time.deltaTime);
      this.transform.LookAt(this.Focus);
    }
    else if (this.LookDown)
    {
      this.Timer += Time.deltaTime;
      if ((double) this.Timer < 5.0)
      {
        this.transform.position = Vector3.Lerp(this.transform.position, this.Yandere.Hips.position + Vector3.up * 3f + Vector3.right * 0.1f, Time.deltaTime * this.Timer);
        this.Focus.transform.parent = (Transform) null;
        this.Focus.transform.position = Vector3.Lerp(this.Focus.transform.position, this.Yandere.Hips.position, Time.deltaTime * this.Timer);
        this.transform.LookAt(this.Focus);
      }
      else
      {
        if (this.HeartbrokenCamera.activeInHierarchy)
          return;
        this.HeartbrokenCamera.SetActive(true);
        this.Yandere.Jukebox.GameOver();
        this.enabled = false;
      }
    }
    else if (this.Summoning)
    {
      if (this.Phase == 1)
      {
        this.NoticedPOV.position = this.Yandere.transform.position + this.Yandere.transform.forward * 1.7f + this.Yandere.transform.right * 0.15f + Vector3.up * 1.375f;
        this.NoticedFocus.position = this.transform.position + this.transform.forward;
        this.NoticedSpeed = 10f;
        ++this.Phase;
      }
      else if (this.Phase == 2)
      {
        this.NoticedPOV.Translate(this.NoticedPOV.forward * (Time.deltaTime * -0.1f));
        this.NoticedFocus.position = Vector3.Lerp(this.NoticedFocus.position, this.Yandere.transform.position + this.Yandere.transform.right * 0.15f + Vector3.up * 1.375f, Time.deltaTime * 10f);
        this.Timer += Time.deltaTime;
        if ((double) this.Timer > 2.0)
        {
          this.Yandere.Stand.Spawn();
          this.NoticedPOV.position = this.Yandere.transform.position + this.Yandere.transform.forward * 2f + Vector3.up * 2.4f;
          this.Timer = 0.0f;
          ++this.Phase;
        }
      }
      else if (this.Phase == 3)
      {
        this.NoticedPOV.Translate(this.NoticedPOV.forward * (Time.deltaTime * -0.1f));
        this.NoticedFocus.position = this.Yandere.transform.position + Vector3.up * 2.4f;
        this.Yandere.Stand.Stand.SetActive(true);
        this.Timer += Time.deltaTime;
        if ((double) this.Timer > 5.0)
          ++this.Phase;
      }
      else if (this.Phase == 4)
      {
        this.Yandere.Stand.transform.localPosition = new Vector3(this.Yandere.Stand.transform.localPosition.x, 0.0f, this.Yandere.Stand.transform.localPosition.z);
        this.Yandere.Jukebox.PlayJojo();
        this.Yandere.Talking = true;
        this.Summoning = false;
        this.Timer = 0.0f;
        this.Phase = 1;
      }
      this.transform.position = Vector3.Lerp(this.transform.position, this.NoticedPOV.position, Time.deltaTime * this.NoticedSpeed);
      this.transform.LookAt(this.NoticedFocus);
    }
    else
    {
      if (!this.Yandere.Talking && !this.Yandere.Won || this.RPGCamera.enabled)
        return;
      this.Timer += Time.deltaTime;
      if ((double) this.Timer < 0.5)
      {
        this.transform.position = Vector3.Lerp(this.transform.position, this.LastPosition, Time.deltaTime * this.ReturnSpeed);
        if (this.Yandere.Talking)
        {
          this.ShoulderFocus.position = Vector3.Lerp(this.ShoulderFocus.position, this.RPGCamera.cameraPivot.position, Time.deltaTime * this.ReturnSpeed);
          this.transform.LookAt(this.ShoulderFocus);
        }
        else
        {
          this.StruggleFocus.position = Vector3.Lerp(this.StruggleFocus.position, this.RPGCamera.cameraPivot.position, Time.deltaTime * this.ReturnSpeed);
          this.transform.LookAt(this.StruggleFocus);
        }
      }
      else
      {
        this.RPGCamera.enabled = true;
        this.Yandere.MyController.enabled = true;
        this.Yandere.Talking = false;
        if (!this.Yandere.Sprayed)
          this.Yandere.CanMove = true;
        this.Yandere.Pursuer = (StudentScript) null;
        this.Yandere.Chased = false;
        this.Yandere.Won = false;
        this.Timer = 0.0f;
      }
    }
  }

  public void YandereNo()
  {
    AudioSource component = this.GetComponent<AudioSource>();
    component.clip = this.StruggleLose;
    component.Play();
  }

  public void GameOver()
  {
    this.NoticedPOV.parent = this.Yandere.transform;
    this.NoticedFocus.parent = this.Yandere.transform;
    this.NoticedFocus.localPosition = new Vector3(0.0f, 1f, 0.0f);
    this.NoticedPOV.localPosition = new Vector3(0.0f, 1f, 2f);
    this.NoticedPOV.LookAt(this.NoticedFocus.position);
    this.Yandere.CharacterAnimation.CrossFade("f02_down_22");
    this.Yandere.HeartCamera.gameObject.SetActive(false);
    this.HeartbrokenCamera.SetActive(true);
    this.Yandere.RPGCamera.enabled = false;
    this.Yandere.Collapse = true;
    this.Yandere.HUD.alpha = 0.0f;
    this.Yandere.StudentManager.Students[1].Pathfinding.canSearch = false;
    this.Yandere.StudentManager.Students[1].Pathfinding.canMove = false;
    this.Yandere.StudentManager.Students[1].Fleeing = false;
  }
}
