// Decompiled with JetBrains decompiler
// Type: BeatEmUpEnemyScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class BeatEmUpEnemyScript : MonoBehaviour
{
  public CharacterController MyController;
  public BeatEmUpScript Player;
  public GameObject StraightSpecialWarning;
  public GameObject StraightSpecialHitbox;
  public GameObject ArcSpecialWarning;
  public GameObject ArcSpecialHitbox;
  public GameObject EyeTwinkle;
  public GameObject MyRenderer;
  public GameObject HitEffect;
  public GameObject BeltCoat;
  public GameObject Warning;
  public GameObject Hitbox;
  public Renderer WeaponBagRenderer;
  public Renderer HairRenderer;
  public Transform WeaponParent;
  public Transform RightHand;
  public Animation MyAnimation;
  public GameObject[] Weapons;
  public AudioSource MyAudio;
  public AudioClip HitSFX;
  public AudioClip Whoosh;
  public AudioClip[] HitReact;
  public AudioClip[] Defeat;
  public float MaxKnockBackSpeed;
  public float KnockBackSpeed;
  public float MaxSpeed;
  public float Speed;
  public string KnockedDownAnim;
  public string KnockedDownLoop;
  public string DefeatAnim;
  public string DefeatLoop;
  public string StraightSpecialAnim;
  public string ArcSpecialAnimA;
  public string ArcSpecialAnimB;
  public string HitReactAnim;
  public string AttackAnim;
  public string IdleAnim;
  public string WalkAnim;
  public string Name;
  public bool StraightSpecial;
  public bool HitboxSpawned;
  public bool HitReacting;
  public bool KnockedDown;
  public bool ArcSpecial;
  public bool Attacking;
  public bool Defeated;
  public float SpecialTimer;
  public float AttackTimer;
  public float AnimSpeed;
  public float MaxHealth;
  public float Health;
  public int Difficulty = 1;
  public int MyWeapon = 1;
  public int EnemyID = 1;

  public void DisableWeapon()
  {
    for (int index = 1; index < this.Weapons.Length; ++index)
      this.Weapons[index].SetActive(false);
  }

  public void Start()
  {
    Physics.IgnoreLayerCollision(9, 9);
    this.Difficulty = GameGlobals.BeatEmUpDifficulty;
    this.MaxHealth += (float) (this.Difficulty * 25);
    this.MyAnimation[this.WalkAnim].speed = this.AnimSpeed;
    this.Weapons[this.MyWeapon].SetActive(true);
    this.Health = this.MaxHealth;
    if (!GameGlobals.Eighties)
      return;
    this.HairRenderer.material.color = new Color(0.2f, 0.2f, 0.2f, 1f);
    this.Name = "Rival Gang Member #" + this.EnemyID.ToString();
    this.WeaponBagRenderer.enabled = false;
    this.MyRenderer.SetActive(false);
    this.BeltCoat.SetActive(true);
  }

  private void Update()
  {
    if (!this.StraightSpecial && !this.ArcSpecial)
      this.transform.LookAt(this.Player.transform.position);
    if (this.Player.Defeated)
    {
      this.MyAnimation.CrossFade(this.IdleAnim);
      if (!((Object) this.Warning != (Object) null))
        return;
      Object.Destroy((Object) this.Warning);
    }
    else if (this.HitReacting)
    {
      if ((double) this.MyAnimation[this.HitReactAnim].time < (double) this.MyAnimation[this.HitReactAnim].length)
        return;
      this.MyAnimation.CrossFade(this.IdleAnim);
      this.HitReacting = false;
    }
    else if (this.Attacking)
    {
      if ((double) this.MyAnimation[this.AttackAnim].time >= (double) this.MyAnimation[this.AttackAnim].length)
      {
        this.MyAnimation.CrossFade(this.IdleAnim);
        this.Attacking = false;
      }
      else
      {
        if (this.HitboxSpawned || (double) this.MyAnimation[this.AttackAnim].time < (double) this.MyAnimation[this.AttackAnim].length * 0.44999998807907104)
          return;
        Object.Instantiate<GameObject>(this.Hitbox, this.transform.position + this.transform.forward * 0.67f + new Vector3(0.0f, 1f, 0.0f), this.transform.rotation);
        this.HitboxSpawned = true;
      }
    }
    else if (this.StraightSpecial)
    {
      if ((double) this.MyAnimation[this.StraightSpecialAnim].time >= (double) this.MyAnimation[this.StraightSpecialAnim].length * 0.89999997615814209)
      {
        this.StraightSpecialHitbox.SetActive(false);
        this.EyeTwinkle.SetActive(false);
        this.StraightSpecial = false;
        this.HitboxSpawned = false;
        Object.Destroy((Object) this.Warning);
      }
      else if (!this.HitboxSpawned)
      {
        if ((double) this.MyAnimation[this.StraightSpecialAnim].time < (double) this.MyAnimation[this.StraightSpecialAnim].length * 0.38999998569488525)
          return;
        this.StraightSpecialHitbox.SetActive(true);
        this.HitboxSpawned = true;
        this.Speed = this.MaxSpeed;
      }
      else
      {
        int num = (int) this.MyController.Move(this.transform.forward * this.Speed * Time.deltaTime);
        this.Speed = Mathf.MoveTowards(this.Speed, 0.0f, Time.deltaTime * this.MaxSpeed);
        if ((double) this.Speed >= 1.0)
          return;
        this.StraightSpecialHitbox.SetActive(false);
      }
    }
    else if (this.ArcSpecial)
    {
      if ((double) Vector3.Distance(this.transform.position, this.Player.transform.position) > 1.0)
      {
        int num = (int) this.MyController.Move(this.transform.forward * this.Speed * Time.deltaTime);
      }
      this.Speed = Mathf.MoveTowards(this.Speed, 0.0f, Time.deltaTime * this.MaxSpeed);
      if ((double) this.Speed > 0.0)
        this.transform.LookAt(this.Player.transform.position);
      if ((double) this.MyAnimation[this.ArcSpecialAnimA].time >= (double) this.MyAnimation[this.ArcSpecialAnimA].length)
        this.MyAnimation.CrossFade(this.ArcSpecialAnimB);
      else if ((double) this.MyAnimation[this.ArcSpecialAnimA].time >= (double) this.MyAnimation[this.ArcSpecialAnimA].length * 0.34999999403953552)
      {
        this.Weapons[this.MyWeapon].transform.parent = this.RightHand;
        this.Weapons[this.MyWeapon].transform.localPosition = Vector3.zero;
        this.Weapons[this.MyWeapon].transform.localEulerAngles = Vector3.zero;
      }
      if ((double) this.MyAnimation[this.ArcSpecialAnimB].time >= (double) this.MyAnimation[this.ArcSpecialAnimB].length * 0.89999997615814209)
      {
        this.Weapons[this.MyWeapon].transform.parent = this.WeaponParent;
        this.Weapons[this.MyWeapon].transform.localPosition = Vector3.zero;
        this.Weapons[this.MyWeapon].transform.localEulerAngles = Vector3.zero;
        this.EyeTwinkle.SetActive(false);
        this.HitboxSpawned = false;
        this.ArcSpecial = false;
        Object.Destroy((Object) this.Warning);
      }
      else if (!this.HitboxSpawned)
      {
        if ((double) this.MyAnimation[this.ArcSpecialAnimB].time < (double) this.MyAnimation[this.ArcSpecialAnimB].length * 0.34000000357627869)
          return;
        this.ArcSpecialHitbox.SetActive(true);
        this.HitboxSpawned = true;
      }
      else
      {
        if ((double) this.MyAnimation[this.ArcSpecialAnimB].time < (double) this.MyAnimation[this.ArcSpecialAnimB].length * 0.43999999761581421)
          return;
        this.ArcSpecialHitbox.SetActive(false);
      }
    }
    else if (this.Defeated)
    {
      if (this.KnockedDown)
      {
        this.KnockBackSpeed = this.MaxKnockBackSpeed * (float) (1.0 - (double) this.MyAnimation[this.KnockedDownAnim].time / (double) this.MyAnimation[this.KnockedDownAnim].length);
        int num = (int) this.MyController.Move(this.transform.forward * this.KnockBackSpeed * -1f * Time.deltaTime);
        if ((double) this.MyAnimation[this.KnockedDownAnim].time < (double) this.MyAnimation[this.KnockedDownAnim].length)
          return;
        this.MyAnimation.CrossFade(this.KnockedDownLoop);
        this.MyController.enabled = false;
        this.enabled = false;
      }
      else
      {
        if ((double) this.MyAnimation[this.DefeatAnim].time < (double) this.MyAnimation[this.DefeatAnim].length)
          return;
        this.MyAnimation.CrossFade(this.DefeatLoop);
        this.enabled = false;
      }
    }
    else
    {
      if ((double) Vector3.Distance(this.transform.position, this.Player.transform.position) < 5.0)
      {
        this.SpecialTimer += Time.deltaTime;
        if ((double) this.SpecialTimer > 5.0)
        {
          this.SpecialTimer = 0.0f;
          switch (Random.RandomRange(0, 3))
          {
            case 1:
              this.Warning = Object.Instantiate<GameObject>(this.StraightSpecialWarning, this.transform.position, this.transform.rotation);
              this.MyAnimation.CrossFade(this.StraightSpecialAnim);
              this.EyeTwinkle.SetActive(true);
              this.StraightSpecial = true;
              break;
            case 2:
              this.Warning = Object.Instantiate<GameObject>(this.ArcSpecialWarning, this.transform.position, this.transform.rotation);
              this.Warning.transform.parent = this.transform;
              this.MyAnimation.CrossFade(this.ArcSpecialAnimA);
              this.EyeTwinkle.SetActive(true);
              this.ArcSpecial = true;
              this.Speed = 5f;
              break;
          }
        }
      }
      if (this.StraightSpecial || this.ArcSpecial)
        return;
      if ((Object) this.Player.Enemy == (Object) this)
      {
        if ((double) Vector3.Distance(this.transform.position, this.Player.transform.position) > 1.0)
        {
          int num = (int) this.MyController.Move(this.transform.forward * Time.deltaTime);
          this.MyAnimation.CrossFade(this.WalkAnim);
        }
        else
        {
          this.MyAnimation.CrossFade(this.IdleAnim);
          this.AttackTimer += Time.deltaTime;
          if ((double) this.AttackTimer <= 0.5)
            return;
          this.MyAnimation.CrossFade(this.AttackAnim);
          this.MyAudio.clip = this.Whoosh;
          this.MyAudio.Play();
          this.HitboxSpawned = false;
          this.Attacking = true;
          this.AttackTimer = 0.0f;
        }
      }
      else
      {
        this.MyAnimation.CrossFade(this.WalkAnim);
        if ((double) Vector3.Distance(this.transform.position, this.Player.transform.position) > 2.5)
        {
          int num1 = (int) this.MyController.Move(this.transform.forward * Time.deltaTime);
        }
        else
        {
          int num2 = (int) this.MyController.Move(this.transform.right * -1f * Time.deltaTime);
        }
      }
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    if ((double) this.Health <= 0.0 || other.gameObject.layer != 18)
      return;
    BeatEmUpHitboxScript component = other.gameObject.GetComponent<BeatEmUpHitboxScript>();
    if (component.Enemy)
      return;
    if (!component.Super)
    {
      this.Player.SuperMeter += 5f;
      if ((double) this.Player.SuperMeter > (double) this.Player.MaxSuper)
        this.Player.SuperMeter = this.Player.MaxSuper;
      if ((double) this.Player.SuperMeter >= 100.0)
        this.Player.SuperButton.alpha = 1f;
      this.Player.SuperLabel.text = this.Player.SuperMeter.ToString() + " / " + this.Player.MaxSuper.ToString();
      this.Player.SuperBar.transform.localScale = new Vector3(this.Player.SuperMeter / this.Player.MaxSuper, 1f, 1f);
    }
    this.MyAudio.clip = this.HitSFX;
    this.MyAudio.pitch = Random.Range(0.9f, 1.1f);
    this.MyAudio.Play();
    this.transform.localScale = new Vector3(this.transform.localScale.x * -1f, 1f, 1f);
    if (component.Heavy)
      Object.Instantiate<GameObject>(this.HitEffect, this.Player.RightFoot.position, Quaternion.identity);
    else if (component.AttackID == 1 || component.AttackID == 3 || component.AttackID == 5)
      Object.Instantiate<GameObject>(this.HitEffect, this.Player.LeftHand.position, Quaternion.identity);
    else
      Object.Instantiate<GameObject>(this.HitEffect, this.Player.RightHand.position, Quaternion.identity);
    this.Health -= component.Damage;
    if ((double) this.Health <= 0.0)
    {
      AudioSource.PlayClipAtPoint(this.Defeat[Random.Range(1, this.Defeat.Length)], this.Player.MainCamera.transform.position);
      this.StraightSpecialHitbox.SetActive(false);
      this.ArcSpecialHitbox.SetActive(false);
      if ((Object) this.Warning != (Object) null)
        Object.Destroy((Object) this.Warning);
      this.StraightSpecial = false;
      this.HitReacting = false;
      this.ArcSpecial = false;
      this.Defeated = true;
      this.Health = 0.0f;
      if (component.AttackID == 14)
      {
        this.MyAnimation.CrossFade(this.KnockedDownAnim);
        this.KnockedDown = true;
      }
      else
      {
        this.MyAnimation.CrossFade(this.DefeatAnim);
        this.MyController.enabled = false;
      }
      this.Player.VictoryCheck();
      if (!this.Player.Super)
        return;
      this.Player.GetNearestEnemy();
      this.Player.transform.LookAt(this.Player.Ring.position);
    }
    else
    {
      AudioSource.PlayClipAtPoint(this.HitReact[Random.Range(1, this.HitReact.Length)], this.Player.MainCamera.transform.position);
      if (this.StraightSpecial || this.ArcSpecial)
        return;
      this.MyAnimation[this.HitReactAnim].time = 0.0f;
      this.MyAnimation.CrossFade(this.HitReactAnim);
      this.HitReacting = true;
      this.Attacking = false;
      this.AttackTimer = 0.0f;
    }
  }
}
