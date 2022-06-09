// Decompiled with JetBrains decompiler
// Type: SkullScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SkullScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public VoidGoddessScript VoidGoddess;
  public JukeboxScript Jukebox;
  public YandereScript Yandere;
  public PromptScript Prompt;
  public ClockScript Clock;
  public AudioSource MyAudio;
  public AudioClip FlameDemonVoice;
  public AudioClip FlameActivation;
  public GameObject HeartbeatCamera;
  public GameObject RitualKnife;
  public GameObject EmptyDemon;
  public GameObject DebugMenu;
  public GameObject DarkAura;
  public GameObject Hell;
  public GameObject FPS;
  public GameObject HUD;
  public Vector3 OriginalPosition;
  public Vector3 OriginalRotation;
  public UISprite Darkness;
  public float FlameTimer;
  public float Timer;
  public bool MissionMode;

  private void Start()
  {
    this.OriginalPosition = this.RitualKnife.transform.position;
    this.OriginalRotation = this.RitualKnife.transform.eulerAngles;
    this.MissionMode = MissionModeGlobals.MissionMode;
    this.MyAudio = this.GetComponent<AudioSource>();
    if (GameGlobals.Debug)
      return;
    this.Prompt.Hide();
    this.Prompt.enabled = false;
    this.enabled = false;
  }

  private void Update()
  {
    if (this.Yandere.Armed)
    {
      if (this.Yandere.EquippedWeapon.WeaponID == 8)
        this.Prompt.enabled = true;
      else if (this.Prompt.enabled)
      {
        this.Prompt.Hide();
        this.Prompt.enabled = false;
      }
    }
    else if (this.Prompt.enabled)
    {
      this.Prompt.Hide();
      this.Prompt.enabled = false;
    }
    if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      this.Prompt.Circle[0].fillAmount = 1f;
      if (!this.Yandere.Chased && this.Yandere.Chasers == 0)
      {
        this.VoidGoddess.Follow = false;
        this.Yandere.EquippedWeapon.Drop();
        this.Yandere.EquippedWeapon = (WeaponScript) null;
        this.Yandere.Unequip();
        this.Yandere.DropTimer[this.Yandere.Equipped] = 0.0f;
        this.RitualKnife.transform.position = this.OriginalPosition;
        this.RitualKnife.transform.eulerAngles = this.OriginalRotation;
        this.RitualKnife.GetComponent<Rigidbody>().useGravity = false;
        if (!this.MissionMode)
        {
          if (this.RitualKnife.GetComponent<WeaponScript>().Heated && !this.RitualKnife.GetComponent<WeaponScript>().Flaming)
          {
            this.MyAudio.clip = this.FlameDemonVoice;
            this.MyAudio.Play();
            this.FlameTimer = 10f;
            this.RitualKnife.GetComponent<WeaponScript>().Prompt.Hide();
            this.RitualKnife.GetComponent<WeaponScript>().Prompt.enabled = false;
          }
          else if (this.RitualKnife.GetComponent<WeaponScript>().Blood.enabled)
          {
            this.DebugMenu.SetActive(false);
            this.Yandere.Character.GetComponent<Animation>().CrossFade(this.Yandere.IdleAnim);
            this.Yandere.CanMove = false;
            Object.Instantiate<GameObject>(this.DarkAura, this.Yandere.transform.position + Vector3.up * 0.81f, Quaternion.identity);
            this.Timer += Time.deltaTime;
            this.Clock.StopTime = true;
            if ((Object) this.StudentManager.Students[21] == (Object) null || (Object) this.StudentManager.Students[26] == (Object) null || (Object) this.StudentManager.Students[31] == (Object) null || (Object) this.StudentManager.Students[36] == (Object) null || (Object) this.StudentManager.Students[41] == (Object) null || (Object) this.StudentManager.Students[46] == (Object) null || (Object) this.StudentManager.Students[51] == (Object) null || (Object) this.StudentManager.Students[56] == (Object) null || (Object) this.StudentManager.Students[61] == (Object) null || (Object) this.StudentManager.Students[66] == (Object) null || (Object) this.StudentManager.Students[71] == (Object) null)
              this.EmptyDemon.SetActive(false);
            else if (!this.StudentManager.Students[21].Alive || !this.StudentManager.Students[26].Alive || !this.StudentManager.Students[31].Alive || !this.StudentManager.Students[36].Alive || !this.StudentManager.Students[41].Alive || !this.StudentManager.Students[46].Alive || !this.StudentManager.Students[51].Alive || !this.StudentManager.Students[56].Alive || !this.StudentManager.Students[61].Alive || !this.StudentManager.Students[66].Alive || !this.StudentManager.Students[71].Alive)
              this.EmptyDemon.SetActive(false);
            if (this.StudentManager.EmptyDemon)
              this.EmptyDemon.SetActive(false);
          }
        }
      }
    }
    if ((double) this.FlameTimer > 0.0)
    {
      this.FlameTimer = Mathf.MoveTowards(this.FlameTimer, 0.0f, Time.deltaTime);
      if ((double) this.FlameTimer == 0.0)
      {
        this.RitualKnife.GetComponent<WeaponScript>().FireEffect.gameObject.SetActive(true);
        this.RitualKnife.GetComponent<WeaponScript>().Prompt.enabled = true;
        this.RitualKnife.GetComponent<WeaponScript>().FireEffect.Play();
        this.RitualKnife.GetComponent<WeaponScript>().FireAudio.Play();
        this.RitualKnife.GetComponent<WeaponScript>().Flaming = true;
        this.Prompt.enabled = true;
        this.Prompt.Yandere.Police.Invalid = true;
        if ((Object) this.Prompt.Yandere.StudentManager.Students[10] != (Object) null)
          this.Prompt.Yandere.StudentManager.Students[10].Strength = 0;
        this.MyAudio.clip = this.FlameActivation;
        this.MyAudio.Play();
      }
    }
    if ((double) this.Timer > 0.0)
    {
      if ((double) this.Yandere.transform.position.y < 1000.0)
      {
        this.Timer += Time.deltaTime;
        if ((double) this.Timer > 4.0)
        {
          this.Darkness.enabled = true;
          this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
          if ((double) this.Darkness.color.a == 1.0)
          {
            this.Yandere.transform.position = new Vector3(0.0f, 2000f, 0.0f);
            this.Yandere.Character.SetActive(true);
            this.Yandere.SetAnimationLayers();
            this.HeartbeatCamera.SetActive(false);
            this.FPS.SetActive(false);
            this.HUD.SetActive(false);
            this.Hell.SetActive(true);
          }
        }
        else if ((double) this.Timer > 1.0)
          this.Yandere.Character.SetActive(false);
      }
      else
      {
        this.Jukebox.Volume = Mathf.MoveTowards(this.Jukebox.Volume, 0.0f, Time.deltaTime * 0.5f);
        if ((double) this.Jukebox.Volume == 0.0)
        {
          this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0.0f, Time.deltaTime));
          if ((double) this.Darkness.color.a == 0.0)
          {
            this.Yandere.CanMove = true;
            this.Timer = 0.0f;
          }
        }
      }
    }
    if (!this.Yandere.Egg)
      return;
    this.Prompt.Hide();
    this.Prompt.enabled = false;
    this.enabled = false;
  }
}
