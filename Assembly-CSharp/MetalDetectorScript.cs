// Decompiled with JetBrains decompiler
// Type: MetalDetectorScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MetalDetectorScript : MonoBehaviour
{
  public MissionModeScript MissionMode;
  public YandereScript Yandere;
  public PromptScript Prompt;
  public ParticleSystem PepperSprayEffect;
  public AudioSource MyAudio;
  public AudioClip PepperSprayNoVoice;
  public AudioClip PepperSpraySFX;
  public AudioClip Alarm;
  public Collider MyCollider;
  public float SprayTimer;
  public bool Spraying;

  private void Start() => this.MyAudio = this.GetComponent<AudioSource>();

  private void Update()
  {
    if (this.Yandere.Armed)
    {
      if (this.Yandere.EquippedWeapon.WeaponID == 6)
      {
        this.Prompt.enabled = true;
        if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
        {
          this.MyAudio.Play();
          this.MyCollider.enabled = false;
          this.Prompt.Hide();
          this.Prompt.enabled = false;
          this.enabled = false;
        }
      }
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
    if (this.Spraying)
    {
      this.SprayTimer += Time.deltaTime;
      if ((double) this.SprayTimer > 0.66666)
      {
        if (this.Yandere.Armed)
          this.Yandere.EquippedWeapon.Drop();
        this.Yandere.EmptyHands();
        this.PepperSprayEffect.Play();
        this.Spraying = false;
      }
    }
    this.MyAudio.volume -= Time.deltaTime * 0.01f;
  }

  private void OnTriggerStay(Collider other)
  {
    if (other.gameObject.layer == 9)
    {
      StudentScript component = other.gameObject.GetComponent<StudentScript>();
      if ((Object) component != (Object) null && (component.FragileSlave || component.Slave && component.MyWeapon.Metal) && !this.MyAudio.isPlaying)
      {
        this.MyAudio.clip = this.Alarm;
        this.MyAudio.Play();
        this.MyAudio.volume = 0.1f;
        AudioSource.PlayClipAtPoint(this.PepperSprayNoVoice, this.transform.position);
        this.PepperSprayEffect.transform.position = new Vector3(this.transform.position.x, component.transform.position.y + 1.8f, component.transform.position.z);
        this.PepperSprayEffect.Play();
      }
    }
    if (!this.Yandere.enabled)
      return;
    bool flag = false;
    if (this.MissionMode.GameOverID != 0 || other.gameObject.layer != 13)
      return;
    for (int index = 1; index < 4; ++index)
    {
      WeaponScript weaponScript = this.Yandere.Weapon[index];
      flag = ((flag ? 1 : 0) | (!((Object) weaponScript != (Object) null) ? 0 : (weaponScript.Metal ? 1 : 0))) != 0;
      if (!flag)
      {
        if ((Object) this.Yandere.Container != (Object) null && (Object) this.Yandere.Container.Weapon != (Object) null)
          flag = this.Yandere.Container.Weapon.Metal;
        if ((Object) this.Yandere.PickUp != (Object) null)
        {
          if ((Object) this.Yandere.PickUp.TrashCan != (Object) null && this.Yandere.PickUp.TrashCan.Weapon)
            flag = this.Yandere.PickUp.TrashCan.Item.GetComponent<WeaponScript>().Metal;
          if ((Object) this.Yandere.PickUp.StuckBoxCutter != (Object) null)
          {
            WeaponScript stuckBoxCutter = this.Yandere.PickUp.StuckBoxCutter;
            flag = true;
          }
        }
      }
    }
    if (!flag || this.Yandere.Inventory.IDCard)
      return;
    if (this.MissionMode.enabled)
    {
      this.MissionMode.GameOverID = 16;
      this.MissionMode.GameOver();
      this.MissionMode.Phase = 4;
      this.enabled = false;
    }
    else
    {
      if (this.Yandere.Sprayed)
        return;
      this.MyAudio.clip = this.Alarm;
      this.MyAudio.loop = true;
      this.MyAudio.Play();
      this.MyAudio.volume = 0.1f;
      AudioSource.PlayClipAtPoint(this.PepperSpraySFX, this.transform.position);
      if (this.Yandere.Aiming)
        this.Yandere.StopAiming();
      this.PepperSprayEffect.transform.position = new Vector3(this.transform.position.x, this.Yandere.transform.position.y + 1.8f, this.Yandere.transform.position.z);
      this.Spraying = true;
      this.Yandere.CharacterAnimation.CrossFade("f02_sprayed_00");
      this.Yandere.FollowHips = true;
      this.Yandere.Punching = false;
      this.Yandere.CanMove = false;
      this.Yandere.Sprayed = true;
      this.Yandere.StudentManager.YandereDying = true;
      this.Yandere.StudentManager.StopMoving();
      this.Yandere.Blur.Size = 1f;
      this.Yandere.Jukebox.Volume = 0.0f;
      Time.timeScale = 1f;
    }
  }
}
