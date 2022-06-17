// Decompiled with JetBrains decompiler
// Type: AttackManagerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class AttackManagerScript : MonoBehaviour
{
  public GameObject BloodEffect;
  private GameObject OriginalBloodEffect;
  private GameObject Victim;
  private YandereScript Yandere;
  private string VictimAnimName = string.Empty;
  private string AnimName = string.Empty;
  public bool PingPong;
  public bool Stealth;
  public bool Censor;
  public bool Loop;
  public int EffectPhase;
  public int LoopPhase;
  public float AttackTimer;
  public float Distance;
  public float Timer;
  public float LoopStart;
  public float LoopEnd;
  public Animation YandereAnim;
  public Animation VictimAnim;
  public RaycastHit hit;
  public Transform RaycastOrigin;

  private void Awake() => this.Yandere = this.GetComponent<YandereScript>();

  private void Start()
  {
    this.Censor = GameGlobals.CensorKillingAnims;
    this.OriginalBloodEffect = this.BloodEffect;
  }

  public bool IsAttacking() => (Object) this.Victim != (Object) null;

  private float GetReachDistance(WeaponType weaponType, SanityType sanityType)
  {
    switch (weaponType)
    {
      case WeaponType.Knife:
        if (this.Stealth)
          return 0.75f;
        if (sanityType == SanityType.High)
          return 1f;
        return sanityType == SanityType.Medium ? 0.75f : 0.5f;
      case WeaponType.Katana:
        return !this.Stealth ? 1f : 0.5f;
      case WeaponType.Bat:
        if (this.Stealth)
          return 0.5f;
        if (sanityType == SanityType.High)
          return 0.75f;
        return 1f;
      case WeaponType.Saw:
        return !this.Stealth ? 1f : 0.7f;
      case WeaponType.Syringe:
        return 0.5f;
      case WeaponType.Weight:
        if (this.Stealth || sanityType == SanityType.High)
          return 0.75f;
        return 0.75f;
      case WeaponType.Garrote:
        return 0.5f;
      default:
        Debug.LogError((object) ("Weapon type \"" + weaponType.ToString() + "\" not implemented."));
        return 0.0f;
    }
  }

  public void Attack(GameObject victim, WeaponScript weapon)
  {
    this.Victim = victim;
    this.Yandere.TargetStudent.FocusOnYandere = false;
    this.Yandere.FollowHips = true;
    this.AttackTimer = 0.0f;
    this.EffectPhase = 0;
    this.Yandere.Sanity = Mathf.Clamp(this.Yandere.Sanity, 0.0f, 100f);
    SanityType sanityType = this.Yandere.SanityType;
    string sanityString = this.Yandere.GetSanityString(sanityType);
    string str1 = weapon.GetTypePrefix();
    string str2 = this.Yandere.TargetStudent.Male ? string.Empty : "f02_";
    if (!this.Stealth)
    {
      this.VictimAnimName = str2 + str1 + sanityString + "SanityB_00";
      if (weapon.WeaponID == 23)
        str1 = "extin";
      this.AnimName = "f02_" + str1 + sanityString + "SanityA_00";
      Debug.Log((object) ("VictimAnimName is: " + this.VictimAnimName));
    }
    else
    {
      this.VictimAnimName = str2 + str1 + "StealthB_00";
      if (weapon.WeaponID == 23)
        str1 = "extin";
      this.AnimName = "f02_" + str1 + "StealthA_00";
    }
    this.YandereAnim = this.Yandere.CharacterAnimation;
    this.YandereAnim[this.AnimName].time = 0.0f;
    this.YandereAnim.CrossFade(this.AnimName);
    this.VictimAnim = this.Yandere.TargetStudent.CharacterAnimation;
    this.VictimAnim[this.VictimAnimName].time = 0.0f;
    this.VictimAnim.CrossFade(this.VictimAnimName);
    weapon.MyAudio.clip = weapon.GetClip(this.Yandere.Sanity / 100f, this.Stealth);
    weapon.MyAudio.time = 0.0f;
    weapon.MyAudio.Play();
    if (weapon.Type == WeaponType.Knife)
      weapon.Flip = true;
    this.Distance = this.GetReachDistance(weapon.Type, sanityType);
  }

  private void Update()
  {
    if (!this.IsAttacking())
      return;
    this.CheckForWalls();
    this.VictimAnim.CrossFade(this.VictimAnimName);
    if (this.Censor)
    {
      if ((double) this.AttackTimer == 0.0)
      {
        this.Yandere.Blur.enabled = true;
        this.Yandere.Blur.Size = 1f;
      }
      this.Yandere.Blur.Size = (double) this.AttackTimer >= (double) this.YandereAnim[this.AnimName].length - 0.5 ? Mathf.MoveTowards(this.Yandere.Blur.Size, 1f, Time.deltaTime * 32f) : Mathf.MoveTowards(this.Yandere.Blur.Size, 16f, Time.deltaTime * 10f);
    }
    WeaponScript equippedWeapon = this.Yandere.EquippedWeapon;
    SanityType sanityType = this.Yandere.SanityType;
    this.AttackTimer += Time.deltaTime;
    if (this.Yandere.TargetStudent.StudentID == this.Yandere.StudentManager.RivalID && !this.Yandere.CanTranq && !this.Yandere.StudentManager.DisableRivalDeathSloMo)
    {
      Time.timeScale = (double) this.AttackTimer >= 1.5 ? Mathf.MoveTowards(Time.timeScale, 1f, Time.unscaledDeltaTime * 2f) : Mathf.MoveTowards(Time.timeScale, 0.1f, Time.unscaledDeltaTime * 0.5f);
      equippedWeapon.MyAudio.pitch = Time.timeScale;
    }
    this.SpecialEffect(equippedWeapon, sanityType);
    if (sanityType == SanityType.Low)
      this.LoopCheck(equippedWeapon);
    this.SpecialEffect(equippedWeapon, sanityType);
    if ((double) this.YandereAnim[this.AnimName].time > (double) this.YandereAnim[this.AnimName].length - 0.333333343267441)
    {
      this.YandereAnim.CrossFade("f02_idle_00");
      equippedWeapon.Flip = false;
    }
    if ((double) this.AttackTimer <= (double) this.YandereAnim[this.AnimName].length)
      return;
    if ((Object) this.Yandere.TargetStudent == (Object) this.Yandere.StudentManager.Reporter)
      this.Yandere.StudentManager.Reporter = (StudentScript) null;
    if (!this.Yandere.CanTranq)
    {
      this.Yandere.TargetStudent.DeathType = DeathType.Weapon;
    }
    else
    {
      this.Yandere.StudentManager.UpdateAllBentos();
      this.Yandere.TargetStudent.Tranquil = true;
      this.Yandere.NoStainGloves = true;
      this.Yandere.CanTranq = false;
      this.Yandere.StainWeapon();
      this.Yandere.Follower = (StudentScript) null;
      --this.Yandere.Followers;
      equippedWeapon.Type = WeaponType.Knife;
    }
    this.Yandere.TargetStudent.DeathCause = equippedWeapon.WeaponID;
    this.Yandere.TargetStudent.BecomeRagdoll();
    this.Yandere.Sanity -= (PlayerGlobals.PantiesEquipped == 10 ? 10f : 20f) * this.Yandere.Numbness;
    this.Yandere.Attacking = false;
    this.Yandere.FollowHips = false;
    this.Yandere.HipCollider.enabled = false;
    bool flag = false;
    if (this.Yandere.EquippedWeapon.Type == WeaponType.Bat)
      flag = true;
    if (!flag)
      this.Yandere.EquippedWeapon.Evidence = true;
    this.Victim = (GameObject) null;
    this.VictimAnimName = (string) null;
    this.AnimName = (string) null;
    this.Stealth = false;
    this.EffectPhase = 0;
    this.AttackTimer = 0.0f;
    this.Timer = 0.0f;
    this.CheckForSpecialCase(equippedWeapon);
    this.Yandere.Blur.enabled = false;
    this.Yandere.Blur.Size = 1f;
    if (equippedWeapon.Blunt)
    {
      this.Yandere.TargetStudent.Ragdoll.NeckSnapped = true;
      this.Yandere.TargetStudent.NeckSnapped = true;
    }
    if (!this.Yandere.Noticed)
    {
      this.Yandere.EquippedWeapon.MurderWeapon = true;
      this.Yandere.CanMove = true;
    }
    else
      equippedWeapon.Drop();
    equippedWeapon.MyAudio.pitch = 1f;
    Time.timeScale = 1f;
  }

  private void SpecialEffect(WeaponScript weapon, SanityType sanityType)
  {
    this.BloodEffect = this.OriginalBloodEffect;
    if (weapon.WeaponID == 14)
      this.BloodEffect = weapon.HeartBurst;
    if (weapon.Type == WeaponType.Knife)
    {
      if (!this.Stealth)
      {
        switch (sanityType)
        {
          case SanityType.High:
            if (this.EffectPhase != 0 || (double) this.YandereAnim[this.AnimName].time <= 1.08333337306976)
              break;
            this.Yandere.Bloodiness += 20f;
            this.Yandere.StainWeapon();
            Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
            ++this.EffectPhase;
            break;
          case SanityType.Medium:
            if (this.EffectPhase == 0)
            {
              if ((double) this.YandereAnim[this.AnimName].time <= 2.16666674613953)
                break;
              this.Yandere.Bloodiness += 20f;
              this.Yandere.StainWeapon();
              Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
              ++this.EffectPhase;
              break;
            }
            if (this.EffectPhase != 1 || (double) this.YandereAnim[this.AnimName].time <= 3.03333330154419)
              break;
            Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
            ++this.EffectPhase;
            break;
          default:
            if (this.EffectPhase == 0)
            {
              if ((double) this.YandereAnim[this.AnimName].time <= 2.76666665077209)
                break;
              this.Yandere.Bloodiness += 20f;
              this.Yandere.StainWeapon();
              Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
              ++this.EffectPhase;
              break;
            }
            if (this.EffectPhase == 1)
            {
              if ((double) this.YandereAnim[this.AnimName].time <= 3.53333330154419)
                break;
              Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
              ++this.EffectPhase;
              break;
            }
            if (this.EffectPhase != 2 || (double) this.YandereAnim[this.AnimName].time <= 4.16666650772095)
              break;
            Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
            ++this.EffectPhase;
            break;
        }
      }
      else
      {
        if (this.EffectPhase != 0 || (double) this.YandereAnim[this.AnimName].time <= 0.966666638851166)
          return;
        this.Yandere.Bloodiness += 20f;
        this.Yandere.StainWeapon();
        Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
        ++this.EffectPhase;
      }
    }
    else if (weapon.Type == WeaponType.Katana)
    {
      if (!this.Stealth)
      {
        switch (sanityType)
        {
          case SanityType.High:
            if (this.EffectPhase != 0 || (double) this.YandereAnim[this.AnimName].time <= 0.483333319425583)
              break;
            this.Yandere.Bloodiness += 20f;
            this.Yandere.StainWeapon();
            Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
            ++this.EffectPhase;
            break;
          case SanityType.Medium:
            if (this.EffectPhase == 0)
            {
              if ((double) this.YandereAnim[this.AnimName].time <= 0.550000011920929)
                break;
              this.Yandere.Bloodiness += 20f;
              this.Yandere.StainWeapon();
              Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
              ++this.EffectPhase;
              break;
            }
            if (this.EffectPhase != 1 || (double) this.YandereAnim[this.AnimName].time <= 1.51666665077209)
              break;
            Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
            ++this.EffectPhase;
            break;
          default:
            if (this.EffectPhase == 0)
            {
              if ((double) this.YandereAnim[this.AnimName].time <= 0.5)
                break;
              this.Yandere.Bloodiness += 20f;
              this.Yandere.StainWeapon();
              Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.6666667f, Quaternion.identity);
              ++this.EffectPhase;
              break;
            }
            if (this.EffectPhase == 1)
            {
              if ((double) this.YandereAnim[this.AnimName].time <= 1.0)
                break;
              weapon.transform.localEulerAngles = new Vector3(0.0f, 180f, 0.0f);
              ++this.EffectPhase;
              break;
            }
            if (this.EffectPhase == 2)
            {
              if ((double) this.YandereAnim[this.AnimName].time <= 2.33333325386047)
                break;
              Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.6666667f, Quaternion.identity);
              ++this.EffectPhase;
              break;
            }
            if (this.EffectPhase == 3)
            {
              if ((double) this.YandereAnim[this.AnimName].time <= 2.73333334922791)
                break;
              Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.6666667f, Quaternion.identity);
              ++this.EffectPhase;
              break;
            }
            if (this.EffectPhase == 4)
            {
              if ((double) this.YandereAnim[this.AnimName].time <= 3.13333344459534)
                break;
              Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.6666667f, Quaternion.identity);
              ++this.EffectPhase;
              break;
            }
            if (this.EffectPhase == 5)
            {
              if ((double) this.YandereAnim[this.AnimName].time <= 3.53333330154419)
                break;
              Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.6666667f, Quaternion.identity);
              ++this.EffectPhase;
              break;
            }
            if (this.EffectPhase == 6)
            {
              if ((double) this.YandereAnim[this.AnimName].time <= 4.13333320617676)
                break;
              Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.6666667f, Quaternion.identity);
              ++this.EffectPhase;
              break;
            }
            if (this.EffectPhase != 8 || (double) this.YandereAnim[this.AnimName].time <= 5.0)
              break;
            weapon.transform.localEulerAngles = Vector3.zero;
            ++this.EffectPhase;
            break;
        }
      }
      else if (this.EffectPhase == 0)
      {
        if ((double) this.YandereAnim[this.AnimName].time <= 0.366666674613953)
          return;
        this.Yandere.Bloodiness += 20f;
        this.Yandere.StainWeapon();
        Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.6666667f, Quaternion.identity);
        ++this.EffectPhase;
      }
      else
      {
        if (this.EffectPhase != 1 || (double) this.YandereAnim[this.AnimName].time <= 1.0)
          return;
        Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.3333333f, Quaternion.identity);
        ++this.EffectPhase;
      }
    }
    else if (weapon.Type == WeaponType.Bat)
    {
      if (!this.Stealth)
      {
        switch (sanityType)
        {
          case SanityType.High:
            if (this.EffectPhase != 0 || (double) this.YandereAnim[this.AnimName].time <= 0.733333349227905)
              break;
            if (!weapon.Blunt)
              this.Yandere.Bloodiness += 20f;
            this.Yandere.StainWeapon();
            Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
            ++this.EffectPhase;
            break;
          case SanityType.Medium:
            if (this.EffectPhase == 0)
            {
              if ((double) this.YandereAnim[this.AnimName].time <= 1.0)
                break;
              if (!weapon.Blunt)
                this.Yandere.Bloodiness += 20f;
              this.Yandere.StainWeapon();
              Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
              ++this.EffectPhase;
              break;
            }
            if (this.EffectPhase != 1 || (double) this.YandereAnim[this.AnimName].time <= 2.96666669845581)
              break;
            Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
            ++this.EffectPhase;
            break;
          default:
            if (this.EffectPhase == 0)
            {
              if ((double) this.YandereAnim[this.AnimName].time <= 0.699999988079071)
                break;
              if (!weapon.Blunt)
                this.Yandere.Bloodiness += 20f;
              this.Yandere.StainWeapon();
              Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
              ++this.EffectPhase;
              break;
            }
            if (this.EffectPhase == 1)
            {
              if ((double) this.YandereAnim[this.AnimName].time <= 3.09999990463257)
                break;
              Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
              ++this.EffectPhase;
              break;
            }
            if (this.EffectPhase == 2)
            {
              if ((double) this.YandereAnim[this.AnimName].time <= 3.76666665077209)
                break;
              Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
              ++this.EffectPhase;
              break;
            }
            if (this.EffectPhase != 3 || (double) this.YandereAnim[this.AnimName].time <= 4.40000009536743)
              break;
            Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
            ++this.EffectPhase;
            break;
        }
      }
      else
      {
        this.Yandere.TargetStudent.Ragdoll.NeckSnapped = true;
        this.Yandere.TargetStudent.NeckSnapped = true;
      }
    }
    else if (weapon.Type == WeaponType.Saw)
    {
      if (!this.Stealth)
      {
        switch (sanityType)
        {
          case SanityType.High:
            if (this.EffectPhase == 0)
            {
              if ((double) this.YandereAnim[this.AnimName].time <= 0.0)
                break;
              weapon.Spin = true;
              ++this.EffectPhase;
              break;
            }
            if (this.EffectPhase == 1)
            {
              if ((double) this.YandereAnim[this.AnimName].time <= 0.733333349227905)
                break;
              this.Yandere.Bloodiness += 20f;
              this.Yandere.StainWeapon();
              weapon.BloodSpray[0].Play();
              weapon.BloodSpray[1].Play();
              ++this.EffectPhase;
              break;
            }
            if (this.EffectPhase != 2 || (double) this.YandereAnim[this.AnimName].time <= 1.43333327770233)
              break;
            weapon.Spin = false;
            weapon.BloodSpray[0].Stop();
            weapon.BloodSpray[1].Stop();
            ++this.EffectPhase;
            break;
          case SanityType.Medium:
            if (this.EffectPhase == 0)
            {
              if ((double) this.YandereAnim[this.AnimName].time <= 0.0)
                break;
              weapon.Spin = true;
              ++this.EffectPhase;
              break;
            }
            if (this.EffectPhase == 1)
            {
              if ((double) this.YandereAnim[this.AnimName].time <= 1.10000002384186)
                break;
              this.Yandere.Bloodiness += 20f;
              this.Yandere.StainWeapon();
              weapon.BloodSpray[0].Play();
              weapon.BloodSpray[1].Play();
              ++this.EffectPhase;
              break;
            }
            if (this.EffectPhase == 2)
            {
              if ((double) this.YandereAnim[this.AnimName].time <= 1.43333327770233)
                break;
              weapon.BloodSpray[0].Stop();
              weapon.BloodSpray[1].Stop();
              ++this.EffectPhase;
              break;
            }
            if (this.EffectPhase == 3)
            {
              if ((double) this.YandereAnim[this.AnimName].time <= 2.36666655540466)
                break;
              weapon.BloodSpray[0].Play();
              weapon.BloodSpray[1].Play();
              ++this.EffectPhase;
              break;
            }
            if (this.EffectPhase != 4 || (double) this.YandereAnim[this.AnimName].time <= 2.40000009536743)
              break;
            weapon.Spin = true;
            weapon.BloodSpray[0].Stop();
            weapon.BloodSpray[1].Stop();
            ++this.EffectPhase;
            break;
          default:
            if (this.EffectPhase == 0)
            {
              if ((double) this.YandereAnim[this.AnimName].time <= 0.0)
                break;
              weapon.Spin = true;
              ++this.EffectPhase;
              break;
            }
            if (this.EffectPhase == 1)
            {
              if ((double) this.YandereAnim[this.AnimName].time <= 0.666666686534882)
                break;
              this.Yandere.Bloodiness += 20f;
              this.Yandere.StainWeapon();
              weapon.BloodSpray[0].Play();
              weapon.BloodSpray[1].Play();
              ++this.EffectPhase;
              break;
            }
            if (this.EffectPhase == 2)
            {
              if ((double) this.YandereAnim[this.AnimName].time <= 0.733333349227905)
                break;
              weapon.BloodSpray[0].Stop();
              weapon.BloodSpray[1].Stop();
              ++this.EffectPhase;
              break;
            }
            if (this.EffectPhase == 3)
            {
              if ((double) this.YandereAnim[this.AnimName].time <= 3.0)
                break;
              weapon.BloodSpray[0].Play();
              weapon.BloodSpray[1].Play();
              ++this.EffectPhase;
              break;
            }
            if (this.EffectPhase != 4 || (double) this.YandereAnim[this.AnimName].time <= 4.86666679382324)
              break;
            weapon.Spin = false;
            weapon.BloodSpray[0].Stop();
            weapon.BloodSpray[1].Stop();
            ++this.EffectPhase;
            break;
        }
      }
      else
      {
        if (this.EffectPhase != 0 || (double) this.YandereAnim[this.AnimName].time <= 1.0)
          return;
        this.Yandere.Bloodiness += 20f;
        this.Yandere.StainWeapon();
        Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.right * 0.2f + weapon.transform.forward * -0.06666667f, Quaternion.identity);
        ++this.EffectPhase;
      }
    }
    else if (weapon.Type == WeaponType.Weight)
    {
      if (!this.Stealth)
      {
        switch (sanityType)
        {
          case SanityType.High:
            if (this.EffectPhase != 0 || (double) this.YandereAnim[this.AnimName].time <= 0.666666686534882)
              break;
            if (!weapon.Blunt)
            {
              this.Yandere.Bloodiness += 20f;
              this.Yandere.StainWeapon();
            }
            Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
            ++this.EffectPhase;
            break;
          case SanityType.Medium:
            if (this.EffectPhase == 0)
            {
              if ((double) this.YandereAnim[this.AnimName].time <= 1.0)
                break;
              if (!weapon.Blunt)
              {
                this.Yandere.Bloodiness += 20f;
                this.Yandere.StainWeapon();
              }
              Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
              ++this.EffectPhase;
              break;
            }
            if (this.EffectPhase != 1 || (double) this.YandereAnim[this.AnimName].time <= 2.83333325386047)
              break;
            Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
            ++this.EffectPhase;
            break;
          default:
            if (this.EffectPhase == 0)
            {
              if ((double) this.YandereAnim[this.AnimName].time <= 2.16666674613953)
                break;
              if (!weapon.Blunt)
              {
                this.Yandere.Bloodiness += 20f;
                this.Yandere.StainWeapon();
              }
              Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
              ++this.EffectPhase;
              break;
            }
            if (this.EffectPhase != 1 || (double) this.YandereAnim[this.AnimName].time <= 4.16666650772095)
              break;
            Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
            ++this.EffectPhase;
            break;
        }
      }
      else
      {
        this.Yandere.TargetStudent.Ragdoll.NeckSnapped = true;
        this.Yandere.TargetStudent.NeckSnapped = true;
      }
    }
    else
    {
      if (weapon.Type != WeaponType.Garrote)
        return;
      this.Yandere.TargetStudent.Ragdoll.NeckSnapped = true;
      this.Yandere.TargetStudent.NeckSnapped = true;
    }
  }

  private void LoopCheck(WeaponScript weapon)
  {
    if (Input.GetButtonDown("X") && !this.Yandere.Chased && this.Yandere.Chasers == 0)
    {
      if (weapon.Type == WeaponType.Knife)
      {
        if ((double) this.YandereAnim[this.AnimName].time > 3.53333330154419 && (double) this.YandereAnim[this.AnimName].time < 4.16666650772095)
        {
          this.LoopStart = 106f;
          this.LoopEnd = 125f;
          this.LoopPhase = 2;
          this.Loop = true;
        }
      }
      else if (weapon.Type == WeaponType.Katana)
      {
        if ((double) this.YandereAnim[this.AnimName].time > 3.36666655540466 && (double) this.YandereAnim[this.AnimName].time < 3.90000009536743)
        {
          this.LoopStart = 101f;
          this.LoopEnd = 117f;
          this.LoopPhase = 5;
          this.Loop = true;
        }
      }
      else if (weapon.Type == WeaponType.Bat)
      {
        if ((double) this.YandereAnim[this.AnimName].time > 3.76666665077209 && (double) this.YandereAnim[this.AnimName].time < 4.40000009536743)
        {
          this.LoopStart = 113f;
          this.LoopEnd = 132f;
          this.LoopPhase = 2;
          this.Loop = true;
        }
      }
      else if (weapon.Type == WeaponType.Saw)
      {
        if ((double) this.YandereAnim[this.AnimName].time > 3.03333330154419 && (double) this.YandereAnim[this.AnimName].time < 4.56666660308838)
        {
          this.LoopStart = 91f;
          this.LoopEnd = 137f;
          this.LoopPhase = 3;
          this.PingPong = true;
        }
      }
      else if (weapon.Type == WeaponType.Weight && (double) this.YandereAnim[this.AnimName].time > 3.0 && (double) this.YandereAnim[this.AnimName].time < 4.5)
      {
        this.LoopStart = 90f;
        this.LoopEnd = 135f;
        this.LoopPhase = 1;
        this.Loop = true;
      }
    }
    if (this.PingPong)
    {
      if ((double) this.YandereAnim[this.AnimName].time > (double) this.LoopEnd / 30.0)
      {
        weapon.MyAudio.pitch = 1f + Random.Range(0.1f, -0.1f);
        weapon.MyAudio.time = this.LoopStart / 30f;
        this.VictimAnim[this.VictimAnimName].speed = -1f;
        this.YandereAnim[this.AnimName].speed = -1f;
        this.EffectPhase = this.LoopPhase;
        this.AttackTimer = 0.0f;
      }
      else if ((double) this.YandereAnim[this.AnimName].time < (double) this.LoopStart / 30.0)
      {
        weapon.MyAudio.pitch = 1f + Random.Range(0.1f, -0.1f);
        weapon.MyAudio.time = this.LoopStart / 30f;
        this.VictimAnim[this.VictimAnimName].speed = 1f;
        this.YandereAnim[this.AnimName].speed = 1f;
        this.EffectPhase = this.LoopPhase;
        this.AttackTimer = this.LoopStart / 30f;
        this.EffectPhase = this.LoopPhase;
        this.PingPong = false;
      }
    }
    if (!this.Loop || (double) this.YandereAnim[this.AnimName].time <= (double) this.LoopEnd / 30.0)
      return;
    weapon.MyAudio.pitch = 1f + Random.Range(0.1f, -0.1f);
    weapon.MyAudio.time = this.LoopStart / 30f;
    this.VictimAnim[this.VictimAnimName].time = this.LoopStart / 30f;
    this.YandereAnim[this.AnimName].time = this.LoopStart / 30f;
    this.AttackTimer = this.LoopStart / 30f;
    this.EffectPhase = this.LoopPhase;
    this.Loop = false;
  }

  private void CheckForSpecialCase(WeaponScript weapon)
  {
    if (weapon.WeaponID != 8 || !GameGlobals.Paranormal)
      return;
    this.Yandere.TargetStudent.Ragdoll.Sacrifice = true;
    weapon.Effect();
  }

  public int OnlyDefault => 1;

  private void CheckForWalls()
  {
    this.RaycastOrigin = this.Yandere.Zoom.transform;
    Vector3 vector3 = this.RaycastOrigin.TransformDirection(this.Yandere.transform.forward);
    Debug.DrawRay(this.RaycastOrigin.position, vector3, Color.green);
    if (!Physics.Raycast(this.RaycastOrigin.position, vector3, out this.hit, 2f, this.OnlyDefault))
      return;
    int num = (int) this.Yandere.MyController.Move(this.transform.forward * -1f * Time.deltaTime);
  }
}
