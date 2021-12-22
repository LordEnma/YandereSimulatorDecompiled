using System;
using UnityEngine;

// Token: 0x020000D8 RID: 216
public class AttackManagerScript : MonoBehaviour
{
	// Token: 0x060009F5 RID: 2549 RVA: 0x0005406C File Offset: 0x0005226C
	private void Awake()
	{
		this.Yandere = base.GetComponent<YandereScript>();
	}

	// Token: 0x060009F6 RID: 2550 RVA: 0x0005407A File Offset: 0x0005227A
	private void Start()
	{
		this.Censor = GameGlobals.CensorKillingAnims;
		this.OriginalBloodEffect = this.BloodEffect;
	}

	// Token: 0x060009F7 RID: 2551 RVA: 0x00054093 File Offset: 0x00052293
	public bool IsAttacking()
	{
		return this.Victim != null;
	}

	// Token: 0x060009F8 RID: 2552 RVA: 0x000540A4 File Offset: 0x000522A4
	private float GetReachDistance(WeaponType weaponType, SanityType sanityType)
	{
		if (weaponType == WeaponType.Knife)
		{
			if (this.Stealth)
			{
				return 0.75f;
			}
			if (sanityType == SanityType.High)
			{
				return 1f;
			}
			if (sanityType == SanityType.Medium)
			{
				return 0.75f;
			}
			return 0.5f;
		}
		else if (weaponType == WeaponType.Katana)
		{
			if (!this.Stealth)
			{
				return 1f;
			}
			return 0.5f;
		}
		else if (weaponType == WeaponType.Bat)
		{
			if (this.Stealth)
			{
				return 0.5f;
			}
			if (sanityType == SanityType.High)
			{
				return 0.75f;
			}
			return 1f;
		}
		else if (weaponType == WeaponType.Saw)
		{
			if (!this.Stealth)
			{
				return 1f;
			}
			return 0.7f;
		}
		else if (weaponType == WeaponType.Weight)
		{
			if (this.Stealth)
			{
				return 0.75f;
			}
			if (sanityType == SanityType.High)
			{
				return 0.75f;
			}
			return 0.75f;
		}
		else
		{
			if (weaponType == WeaponType.Syringe)
			{
				return 0.5f;
			}
			if (weaponType == WeaponType.Garrote)
			{
				return 0.5f;
			}
			Debug.LogError("Weapon type \"" + weaponType.ToString() + "\" not implemented.");
			return 0f;
		}
	}

	// Token: 0x060009F9 RID: 2553 RVA: 0x00054190 File Offset: 0x00052390
	public void Attack(GameObject victim, WeaponScript weapon)
	{
		this.Victim = victim;
		this.Yandere.FollowHips = true;
		this.AttackTimer = 0f;
		this.EffectPhase = 0;
		this.Yandere.Sanity = Mathf.Clamp(this.Yandere.Sanity, 0f, 100f);
		SanityType sanityType = this.Yandere.SanityType;
		string sanityString = this.Yandere.GetSanityString(sanityType);
		string str = weapon.GetTypePrefix();
		string str2 = this.Yandere.TargetStudent.Male ? string.Empty : "f02_";
		if (!this.Stealth)
		{
			this.VictimAnimName = str2 + str + sanityString + "SanityB_00";
			if (weapon.WeaponID == 23)
			{
				str = "extin";
			}
			this.AnimName = "f02_" + str + sanityString + "SanityA_00";
		}
		else
		{
			this.VictimAnimName = str2 + str + "StealthB_00";
			if (weapon.WeaponID == 23)
			{
				str = "extin";
			}
			this.AnimName = "f02_" + str + "StealthA_00";
		}
		this.YandereAnim = this.Yandere.CharacterAnimation;
		this.YandereAnim[this.AnimName].time = 0f;
		this.YandereAnim.CrossFade(this.AnimName);
		this.VictimAnim = this.Yandere.TargetStudent.CharacterAnimation;
		this.VictimAnim[this.VictimAnimName].time = 0f;
		this.VictimAnim.CrossFade(this.VictimAnimName);
		weapon.MyAudio.clip = weapon.GetClip(this.Yandere.Sanity / 100f, this.Stealth);
		weapon.MyAudio.time = 0f;
		weapon.MyAudio.Play();
		if (weapon.Type == WeaponType.Knife)
		{
			weapon.Flip = true;
		}
		this.Distance = this.GetReachDistance(weapon.Type, sanityType);
	}

	// Token: 0x060009FA RID: 2554 RVA: 0x00054388 File Offset: 0x00052588
	private void Update()
	{
		if (this.IsAttacking())
		{
			this.CheckForWalls();
			this.VictimAnim.CrossFade(this.VictimAnimName);
			if (this.Censor)
			{
				if (this.AttackTimer == 0f)
				{
					this.Yandere.Blur.enabled = true;
					this.Yandere.Blur.Size = 1f;
				}
				if (this.AttackTimer < this.YandereAnim[this.AnimName].length - 0.5f)
				{
					this.Yandere.Blur.Size = Mathf.MoveTowards(this.Yandere.Blur.Size, 16f, Time.deltaTime * 10f);
				}
				else
				{
					this.Yandere.Blur.Size = Mathf.MoveTowards(this.Yandere.Blur.Size, 1f, Time.deltaTime * 32f);
				}
			}
			WeaponScript equippedWeapon = this.Yandere.EquippedWeapon;
			SanityType sanityType = this.Yandere.SanityType;
			this.AttackTimer += Time.deltaTime;
			if (this.Yandere.TargetStudent.StudentID == this.Yandere.StudentManager.RivalID && !this.Yandere.CanTranq)
			{
				if (this.AttackTimer < 1.5f)
				{
					Time.timeScale = Mathf.MoveTowards(Time.timeScale, 0.1f, Time.unscaledDeltaTime * 0.5f);
				}
				else
				{
					Time.timeScale = Mathf.MoveTowards(Time.timeScale, 1f, Time.unscaledDeltaTime * 2f);
				}
				equippedWeapon.MyAudio.pitch = Time.timeScale;
			}
			this.SpecialEffect(equippedWeapon, sanityType);
			if (sanityType == SanityType.Low)
			{
				this.LoopCheck(equippedWeapon);
			}
			this.SpecialEffect(equippedWeapon, sanityType);
			if (this.YandereAnim[this.AnimName].time > this.YandereAnim[this.AnimName].length - 0.33333334f)
			{
				this.YandereAnim.CrossFade("f02_idle_00");
				equippedWeapon.Flip = false;
			}
			if (this.AttackTimer > this.YandereAnim[this.AnimName].length)
			{
				if (this.Yandere.TargetStudent == this.Yandere.StudentManager.Reporter)
				{
					this.Yandere.StudentManager.Reporter = null;
				}
				if (!this.Yandere.CanTranq)
				{
					this.Yandere.TargetStudent.DeathType = DeathType.Weapon;
				}
				else
				{
					this.Yandere.TargetStudent.Tranquil = true;
					this.Yandere.NoStainGloves = true;
					this.Yandere.CanTranq = false;
					this.Yandere.StainWeapon();
					this.Yandere.Follower = null;
					this.Yandere.Followers--;
					equippedWeapon.Type = WeaponType.Knife;
				}
				this.Yandere.TargetStudent.DeathCause = equippedWeapon.WeaponID;
				this.Yandere.TargetStudent.BecomeRagdoll();
				this.Yandere.Sanity -= ((PlayerGlobals.PantiesEquipped == 10) ? 10f : 20f) * this.Yandere.Numbness;
				this.Yandere.Attacking = false;
				this.Yandere.FollowHips = false;
				this.Yandere.HipCollider.enabled = false;
				bool flag = false;
				if (this.Yandere.EquippedWeapon.Type == WeaponType.Bat)
				{
					flag = true;
				}
				if (!flag)
				{
					this.Yandere.EquippedWeapon.Evidence = true;
				}
				this.Victim = null;
				this.VictimAnimName = null;
				this.AnimName = null;
				this.Stealth = false;
				this.EffectPhase = 0;
				this.AttackTimer = 0f;
				this.Timer = 0f;
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
				{
					equippedWeapon.Drop();
				}
				equippedWeapon.MyAudio.pitch = 1f;
				Time.timeScale = 1f;
			}
		}
	}

	// Token: 0x060009FB RID: 2555 RVA: 0x00054800 File Offset: 0x00052A00
	private void SpecialEffect(WeaponScript weapon, SanityType sanityType)
	{
		this.BloodEffect = this.OriginalBloodEffect;
		if (weapon.WeaponID == 14)
		{
			this.BloodEffect = weapon.HeartBurst;
		}
		if (weapon.Type == WeaponType.Knife)
		{
			if (!this.Stealth)
			{
				if (sanityType == SanityType.High)
				{
					if (this.EffectPhase == 0 && this.YandereAnim[this.AnimName].time > 1.0833334f)
					{
						this.Yandere.Bloodiness += 20f;
						this.Yandere.StainWeapon();
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
						this.EffectPhase++;
						return;
					}
				}
				else if (sanityType == SanityType.Medium)
				{
					if (this.EffectPhase == 0)
					{
						if (this.YandereAnim[this.AnimName].time > 2.1666667f)
						{
							this.Yandere.Bloodiness += 20f;
							this.Yandere.StainWeapon();
							UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
							this.EffectPhase++;
							return;
						}
					}
					else if (this.EffectPhase == 1 && this.YandereAnim[this.AnimName].time > 3.0333333f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
						this.EffectPhase++;
						return;
					}
				}
				else if (this.EffectPhase == 0)
				{
					if (this.YandereAnim[this.AnimName].time > 2.7666667f)
					{
						this.Yandere.Bloodiness += 20f;
						this.Yandere.StainWeapon();
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
						this.EffectPhase++;
						return;
					}
				}
				else if (this.EffectPhase == 1)
				{
					if (this.YandereAnim[this.AnimName].time > 3.5333333f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
						this.EffectPhase++;
						return;
					}
				}
				else if (this.EffectPhase == 2 && this.YandereAnim[this.AnimName].time > 4.1666665f)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
					this.EffectPhase++;
					return;
				}
			}
			else if (this.EffectPhase == 0 && this.YandereAnim[this.AnimName].time > 0.96666664f)
			{
				this.Yandere.Bloodiness += 20f;
				this.Yandere.StainWeapon();
				UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
				this.EffectPhase++;
				return;
			}
		}
		else if (weapon.Type == WeaponType.Katana)
		{
			if (!this.Stealth)
			{
				if (sanityType == SanityType.High)
				{
					if (this.EffectPhase == 0 && this.YandereAnim[this.AnimName].time > 0.48333332f)
					{
						this.Yandere.Bloodiness += 20f;
						this.Yandere.StainWeapon();
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
						this.EffectPhase++;
						return;
					}
				}
				else if (sanityType == SanityType.Medium)
				{
					if (this.EffectPhase == 0)
					{
						if (this.YandereAnim[this.AnimName].time > 0.55f)
						{
							this.Yandere.Bloodiness += 20f;
							this.Yandere.StainWeapon();
							UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
							this.EffectPhase++;
							return;
						}
					}
					else if (this.EffectPhase == 1 && this.YandereAnim[this.AnimName].time > 1.5166667f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
						this.EffectPhase++;
						return;
					}
				}
				else if (this.EffectPhase == 0)
				{
					if (this.YandereAnim[this.AnimName].time > 0.5f)
					{
						this.Yandere.Bloodiness += 20f;
						this.Yandere.StainWeapon();
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.6666667f, Quaternion.identity);
						this.EffectPhase++;
						return;
					}
				}
				else if (this.EffectPhase == 1)
				{
					if (this.YandereAnim[this.AnimName].time > 1f)
					{
						weapon.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
						this.EffectPhase++;
						return;
					}
				}
				else if (this.EffectPhase == 2)
				{
					if (this.YandereAnim[this.AnimName].time > 2.3333333f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.6666667f, Quaternion.identity);
						this.EffectPhase++;
						return;
					}
				}
				else if (this.EffectPhase == 3)
				{
					if (this.YandereAnim[this.AnimName].time > 2.7333333f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.6666667f, Quaternion.identity);
						this.EffectPhase++;
						return;
					}
				}
				else if (this.EffectPhase == 4)
				{
					if (this.YandereAnim[this.AnimName].time > 3.1333334f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.6666667f, Quaternion.identity);
						this.EffectPhase++;
						return;
					}
				}
				else if (this.EffectPhase == 5)
				{
					if (this.YandereAnim[this.AnimName].time > 3.5333333f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.6666667f, Quaternion.identity);
						this.EffectPhase++;
						return;
					}
				}
				else if (this.EffectPhase == 6)
				{
					if (this.YandereAnim[this.AnimName].time > 4.133333f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.6666667f, Quaternion.identity);
						this.EffectPhase++;
						return;
					}
				}
				else if (this.EffectPhase == 8 && this.YandereAnim[this.AnimName].time > 5f)
				{
					weapon.transform.localEulerAngles = Vector3.zero;
					this.EffectPhase++;
					return;
				}
			}
			else if (this.EffectPhase == 0)
			{
				if (this.YandereAnim[this.AnimName].time > 0.36666667f)
				{
					this.Yandere.Bloodiness += 20f;
					this.Yandere.StainWeapon();
					UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.6666667f, Quaternion.identity);
					this.EffectPhase++;
					return;
				}
			}
			else if (this.EffectPhase == 1 && this.YandereAnim[this.AnimName].time > 1f)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.33333334f, Quaternion.identity);
				this.EffectPhase++;
				return;
			}
		}
		else if (weapon.Type == WeaponType.Bat)
		{
			if (this.Stealth)
			{
				this.Yandere.TargetStudent.Ragdoll.NeckSnapped = true;
				this.Yandere.TargetStudent.NeckSnapped = true;
				return;
			}
			if (sanityType == SanityType.High)
			{
				if (this.EffectPhase == 0 && this.YandereAnim[this.AnimName].time > 0.73333335f)
				{
					if (!weapon.Blunt)
					{
						this.Yandere.Bloodiness += 20f;
					}
					this.Yandere.StainWeapon();
					UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
					this.EffectPhase++;
					return;
				}
			}
			else if (sanityType == SanityType.Medium)
			{
				if (this.EffectPhase == 0)
				{
					if (this.YandereAnim[this.AnimName].time > 1f)
					{
						if (!weapon.Blunt)
						{
							this.Yandere.Bloodiness += 20f;
						}
						this.Yandere.StainWeapon();
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
						this.EffectPhase++;
						return;
					}
				}
				else if (this.EffectPhase == 1 && this.YandereAnim[this.AnimName].time > 2.9666667f)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
					this.EffectPhase++;
					return;
				}
			}
			else if (this.EffectPhase == 0)
			{
				if (this.YandereAnim[this.AnimName].time > 0.7f)
				{
					if (!weapon.Blunt)
					{
						this.Yandere.Bloodiness += 20f;
					}
					this.Yandere.StainWeapon();
					UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
					this.EffectPhase++;
					return;
				}
			}
			else if (this.EffectPhase == 1)
			{
				if (this.YandereAnim[this.AnimName].time > 3.1f)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
					this.EffectPhase++;
					return;
				}
			}
			else if (this.EffectPhase == 2)
			{
				if (this.YandereAnim[this.AnimName].time > 3.7666667f)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
					this.EffectPhase++;
					return;
				}
			}
			else if (this.EffectPhase == 3 && this.YandereAnim[this.AnimName].time > 4.4f)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
				this.EffectPhase++;
				return;
			}
		}
		else if (weapon.Type == WeaponType.Saw)
		{
			if (!this.Stealth)
			{
				if (sanityType == SanityType.High)
				{
					if (this.EffectPhase == 0)
					{
						if (this.YandereAnim[this.AnimName].time > 0f)
						{
							weapon.Spin = true;
							this.EffectPhase++;
							return;
						}
					}
					else if (this.EffectPhase == 1)
					{
						if (this.YandereAnim[this.AnimName].time > 0.73333335f)
						{
							this.Yandere.Bloodiness += 20f;
							this.Yandere.StainWeapon();
							weapon.BloodSpray[0].Play();
							weapon.BloodSpray[1].Play();
							this.EffectPhase++;
							return;
						}
					}
					else if (this.EffectPhase == 2 && this.YandereAnim[this.AnimName].time > 1.4333333f)
					{
						weapon.Spin = false;
						weapon.BloodSpray[0].Stop();
						weapon.BloodSpray[1].Stop();
						this.EffectPhase++;
						return;
					}
				}
				else if (sanityType == SanityType.Medium)
				{
					if (this.EffectPhase == 0)
					{
						if (this.YandereAnim[this.AnimName].time > 0f)
						{
							weapon.Spin = true;
							this.EffectPhase++;
							return;
						}
					}
					else if (this.EffectPhase == 1)
					{
						if (this.YandereAnim[this.AnimName].time > 1.1f)
						{
							this.Yandere.Bloodiness += 20f;
							this.Yandere.StainWeapon();
							weapon.BloodSpray[0].Play();
							weapon.BloodSpray[1].Play();
							this.EffectPhase++;
							return;
						}
					}
					else if (this.EffectPhase == 2)
					{
						if (this.YandereAnim[this.AnimName].time > 1.4333333f)
						{
							weapon.BloodSpray[0].Stop();
							weapon.BloodSpray[1].Stop();
							this.EffectPhase++;
							return;
						}
					}
					else if (this.EffectPhase == 3)
					{
						if (this.YandereAnim[this.AnimName].time > 2.3666666f)
						{
							weapon.BloodSpray[0].Play();
							weapon.BloodSpray[1].Play();
							this.EffectPhase++;
							return;
						}
					}
					else if (this.EffectPhase == 4 && this.YandereAnim[this.AnimName].time > 2.4f)
					{
						weapon.Spin = true;
						weapon.BloodSpray[0].Stop();
						weapon.BloodSpray[1].Stop();
						this.EffectPhase++;
						return;
					}
				}
				else if (this.EffectPhase == 0)
				{
					if (this.YandereAnim[this.AnimName].time > 0f)
					{
						weapon.Spin = true;
						this.EffectPhase++;
						return;
					}
				}
				else if (this.EffectPhase == 1)
				{
					if (this.YandereAnim[this.AnimName].time > 0.6666667f)
					{
						this.Yandere.Bloodiness += 20f;
						this.Yandere.StainWeapon();
						weapon.BloodSpray[0].Play();
						weapon.BloodSpray[1].Play();
						this.EffectPhase++;
						return;
					}
				}
				else if (this.EffectPhase == 2)
				{
					if (this.YandereAnim[this.AnimName].time > 0.73333335f)
					{
						weapon.BloodSpray[0].Stop();
						weapon.BloodSpray[1].Stop();
						this.EffectPhase++;
						return;
					}
				}
				else if (this.EffectPhase == 3)
				{
					if (this.YandereAnim[this.AnimName].time > 3f)
					{
						weapon.BloodSpray[0].Play();
						weapon.BloodSpray[1].Play();
						this.EffectPhase++;
						return;
					}
				}
				else if (this.EffectPhase == 4 && this.YandereAnim[this.AnimName].time > 4.866667f)
				{
					weapon.Spin = false;
					weapon.BloodSpray[0].Stop();
					weapon.BloodSpray[1].Stop();
					this.EffectPhase++;
					return;
				}
			}
			else if (this.EffectPhase == 0 && this.YandereAnim[this.AnimName].time > 1f)
			{
				this.Yandere.Bloodiness += 20f;
				this.Yandere.StainWeapon();
				UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.right * 0.2f + weapon.transform.forward * -0.06666667f, Quaternion.identity);
				this.EffectPhase++;
				return;
			}
		}
		else if (weapon.Type == WeaponType.Weight)
		{
			if (this.Stealth)
			{
				this.Yandere.TargetStudent.Ragdoll.NeckSnapped = true;
				this.Yandere.TargetStudent.NeckSnapped = true;
				return;
			}
			if (sanityType == SanityType.High)
			{
				if (this.EffectPhase == 0 && this.YandereAnim[this.AnimName].time > 0.6666667f)
				{
					if (!weapon.Blunt)
					{
						this.Yandere.Bloodiness += 20f;
						this.Yandere.StainWeapon();
					}
					UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
					this.EffectPhase++;
					return;
				}
			}
			else if (sanityType == SanityType.Medium)
			{
				if (this.EffectPhase == 0)
				{
					if (this.YandereAnim[this.AnimName].time > 1f)
					{
						if (!weapon.Blunt)
						{
							this.Yandere.Bloodiness += 20f;
							this.Yandere.StainWeapon();
						}
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
						this.EffectPhase++;
						return;
					}
				}
				else if (this.EffectPhase == 1 && this.YandereAnim[this.AnimName].time > 2.8333333f)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
					this.EffectPhase++;
					return;
				}
			}
			else if (this.EffectPhase == 0)
			{
				if (this.YandereAnim[this.AnimName].time > 2.1666667f)
				{
					if (!weapon.Blunt)
					{
						this.Yandere.Bloodiness += 20f;
						this.Yandere.StainWeapon();
					}
					UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
					this.EffectPhase++;
					return;
				}
			}
			else if (this.EffectPhase == 1 && this.YandereAnim[this.AnimName].time > 4.1666665f)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
				this.EffectPhase++;
				return;
			}
		}
		else if (weapon.Type == WeaponType.Garrote)
		{
			this.Yandere.TargetStudent.Ragdoll.NeckSnapped = true;
			this.Yandere.TargetStudent.NeckSnapped = true;
		}
	}

	// Token: 0x060009FC RID: 2556 RVA: 0x00055E48 File Offset: 0x00054048
	private void LoopCheck(WeaponScript weapon)
	{
		if (Input.GetButtonDown("X") && !this.Yandere.Chased && this.Yandere.Chasers == 0)
		{
			if (weapon.Type == WeaponType.Knife)
			{
				if (this.YandereAnim[this.AnimName].time > 3.5333333f && this.YandereAnim[this.AnimName].time < 4.1666665f)
				{
					this.LoopStart = 106f;
					this.LoopEnd = 125f;
					this.LoopPhase = 2;
					this.Loop = true;
				}
			}
			else if (weapon.Type == WeaponType.Katana)
			{
				if (this.YandereAnim[this.AnimName].time > 3.3666666f && this.YandereAnim[this.AnimName].time < 3.9f)
				{
					this.LoopStart = 101f;
					this.LoopEnd = 117f;
					this.LoopPhase = 5;
					this.Loop = true;
				}
			}
			else if (weapon.Type == WeaponType.Bat)
			{
				if (this.YandereAnim[this.AnimName].time > 3.7666667f && this.YandereAnim[this.AnimName].time < 4.4f)
				{
					this.LoopStart = 113f;
					this.LoopEnd = 132f;
					this.LoopPhase = 2;
					this.Loop = true;
				}
			}
			else if (weapon.Type == WeaponType.Saw)
			{
				if (this.YandereAnim[this.AnimName].time > 3.0333333f && this.YandereAnim[this.AnimName].time < 4.5666666f)
				{
					this.LoopStart = 91f;
					this.LoopEnd = 137f;
					this.LoopPhase = 3;
					this.PingPong = true;
				}
			}
			else if (weapon.Type == WeaponType.Weight && this.YandereAnim[this.AnimName].time > 3f && this.YandereAnim[this.AnimName].time < 4.5f)
			{
				this.LoopStart = 90f;
				this.LoopEnd = 135f;
				this.LoopPhase = 1;
				this.Loop = true;
			}
		}
		if (this.PingPong)
		{
			if (this.YandereAnim[this.AnimName].time > this.LoopEnd / 30f)
			{
				weapon.MyAudio.pitch = 1f + UnityEngine.Random.Range(0.1f, -0.1f);
				weapon.MyAudio.time = this.LoopStart / 30f;
				this.VictimAnim[this.VictimAnimName].speed = -1f;
				this.YandereAnim[this.AnimName].speed = -1f;
				this.EffectPhase = this.LoopPhase;
				this.AttackTimer = 0f;
			}
			else if (this.YandereAnim[this.AnimName].time < this.LoopStart / 30f)
			{
				weapon.MyAudio.pitch = 1f + UnityEngine.Random.Range(0.1f, -0.1f);
				weapon.MyAudio.time = this.LoopStart / 30f;
				this.VictimAnim[this.VictimAnimName].speed = 1f;
				this.YandereAnim[this.AnimName].speed = 1f;
				this.EffectPhase = this.LoopPhase;
				this.AttackTimer = this.LoopStart / 30f;
				this.EffectPhase = this.LoopPhase;
				this.PingPong = false;
			}
		}
		if (this.Loop && this.YandereAnim[this.AnimName].time > this.LoopEnd / 30f)
		{
			weapon.MyAudio.pitch = 1f + UnityEngine.Random.Range(0.1f, -0.1f);
			weapon.MyAudio.time = this.LoopStart / 30f;
			this.VictimAnim[this.VictimAnimName].time = this.LoopStart / 30f;
			this.YandereAnim[this.AnimName].time = this.LoopStart / 30f;
			this.AttackTimer = this.LoopStart / 30f;
			this.EffectPhase = this.LoopPhase;
			this.Loop = false;
		}
	}

	// Token: 0x060009FD RID: 2557 RVA: 0x00056302 File Offset: 0x00054502
	private void CheckForSpecialCase(WeaponScript weapon)
	{
		if (weapon.WeaponID == 8 && GameGlobals.Paranormal)
		{
			this.Yandere.TargetStudent.Ragdoll.Sacrifice = true;
			weapon.Effect();
		}
	}

	// Token: 0x170001FD RID: 509
	// (get) Token: 0x060009FE RID: 2558 RVA: 0x00056330 File Offset: 0x00054530
	public int OnlyDefault
	{
		get
		{
			return 1;
		}
	}

	// Token: 0x060009FF RID: 2559 RVA: 0x00056334 File Offset: 0x00054534
	private void CheckForWalls()
	{
		this.RaycastOrigin = this.Yandere.Zoom.transform;
		Vector3 vector = this.RaycastOrigin.TransformDirection(this.Yandere.transform.forward);
		Debug.DrawRay(this.RaycastOrigin.position, vector, Color.green);
		if (Physics.Raycast(this.RaycastOrigin.position, vector, out this.hit, 2f, this.OnlyDefault))
		{
			this.Yandere.MyController.Move(base.transform.forward * -1f * Time.deltaTime);
		}
	}

	// Token: 0x04000A98 RID: 2712
	public GameObject BloodEffect;

	// Token: 0x04000A99 RID: 2713
	private GameObject OriginalBloodEffect;

	// Token: 0x04000A9A RID: 2714
	private GameObject Victim;

	// Token: 0x04000A9B RID: 2715
	private YandereScript Yandere;

	// Token: 0x04000A9C RID: 2716
	private string VictimAnimName = string.Empty;

	// Token: 0x04000A9D RID: 2717
	private string AnimName = string.Empty;

	// Token: 0x04000A9E RID: 2718
	public bool PingPong;

	// Token: 0x04000A9F RID: 2719
	public bool Stealth;

	// Token: 0x04000AA0 RID: 2720
	public bool Censor;

	// Token: 0x04000AA1 RID: 2721
	public bool Loop;

	// Token: 0x04000AA2 RID: 2722
	public int EffectPhase;

	// Token: 0x04000AA3 RID: 2723
	public int LoopPhase;

	// Token: 0x04000AA4 RID: 2724
	public float AttackTimer;

	// Token: 0x04000AA5 RID: 2725
	public float Distance;

	// Token: 0x04000AA6 RID: 2726
	public float Timer;

	// Token: 0x04000AA7 RID: 2727
	public float LoopStart;

	// Token: 0x04000AA8 RID: 2728
	public float LoopEnd;

	// Token: 0x04000AA9 RID: 2729
	public Animation YandereAnim;

	// Token: 0x04000AAA RID: 2730
	public Animation VictimAnim;

	// Token: 0x04000AAB RID: 2731
	public RaycastHit hit;

	// Token: 0x04000AAC RID: 2732
	public Transform RaycastOrigin;
}
