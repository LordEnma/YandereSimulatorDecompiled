using System;
using UnityEngine;

// Token: 0x020000DF RID: 223
public class BeatEmUpEnemyScript : MonoBehaviour
{
	// Token: 0x06000A14 RID: 2580 RVA: 0x0005727C File Offset: 0x0005547C
	public void DisableWeapon()
	{
		for (int i = 1; i < this.Weapons.Length; i++)
		{
			this.Weapons[i].SetActive(false);
		}
	}

	// Token: 0x06000A15 RID: 2581 RVA: 0x000572AC File Offset: 0x000554AC
	public void Start()
	{
		Physics.IgnoreLayerCollision(9, 9);
		this.Difficulty = GameGlobals.BeatEmUpDifficulty;
		this.MaxHealth += (float)(this.Difficulty * 25);
		this.MyAnimation[this.WalkAnim].speed = this.AnimSpeed;
		this.Weapons[this.MyWeapon].SetActive(true);
		this.Health = this.MaxHealth;
		if (GameGlobals.Eighties)
		{
			this.HairRenderer.material.color = new Color(0.2f, 0.2f, 0.2f, 1f);
			this.Name = "Rival Gang Member #" + this.EnemyID.ToString();
			this.WeaponBagRenderer.enabled = false;
			this.MyRenderer.SetActive(false);
			this.BeltCoat.SetActive(true);
		}
	}

	// Token: 0x06000A16 RID: 2582 RVA: 0x00057390 File Offset: 0x00055590
	private void Update()
	{
		if (!this.StraightSpecial && !this.ArcSpecial)
		{
			base.transform.LookAt(this.Player.transform.position);
		}
		if (this.Player.Defeated)
		{
			this.MyAnimation.CrossFade(this.IdleAnim);
			if (this.Warning != null)
			{
				UnityEngine.Object.Destroy(this.Warning);
				return;
			}
		}
		else if (this.HitReacting)
		{
			if (this.MyAnimation[this.HitReactAnim].time >= this.MyAnimation[this.HitReactAnim].length)
			{
				this.MyAnimation.CrossFade(this.IdleAnim);
				this.HitReacting = false;
				return;
			}
		}
		else if (this.Attacking)
		{
			if (this.MyAnimation[this.AttackAnim].time >= this.MyAnimation[this.AttackAnim].length)
			{
				this.MyAnimation.CrossFade(this.IdleAnim);
				this.Attacking = false;
				return;
			}
			if (!this.HitboxSpawned && this.MyAnimation[this.AttackAnim].time >= this.MyAnimation[this.AttackAnim].length * 0.45f)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.Hitbox, base.transform.position + base.transform.forward * 0.67f + new Vector3(0f, 1f, 0f), base.transform.rotation);
				this.HitboxSpawned = true;
				return;
			}
		}
		else if (this.StraightSpecial)
		{
			if (this.MyAnimation[this.StraightSpecialAnim].time >= this.MyAnimation[this.StraightSpecialAnim].length * 0.9f)
			{
				this.StraightSpecialHitbox.SetActive(false);
				this.EyeTwinkle.SetActive(false);
				this.StraightSpecial = false;
				this.HitboxSpawned = false;
				UnityEngine.Object.Destroy(this.Warning);
				return;
			}
			if (!this.HitboxSpawned)
			{
				if (this.MyAnimation[this.StraightSpecialAnim].time >= this.MyAnimation[this.StraightSpecialAnim].length * 0.39f)
				{
					this.StraightSpecialHitbox.SetActive(true);
					this.HitboxSpawned = true;
					this.Speed = this.MaxSpeed;
					return;
				}
			}
			else
			{
				this.MyController.Move(base.transform.forward * this.Speed * Time.deltaTime);
				this.Speed = Mathf.MoveTowards(this.Speed, 0f, Time.deltaTime * this.MaxSpeed);
				if (this.Speed < 1f)
				{
					this.StraightSpecialHitbox.SetActive(false);
					return;
				}
			}
		}
		else if (this.ArcSpecial)
		{
			if (Vector3.Distance(base.transform.position, this.Player.transform.position) > 1f)
			{
				this.MyController.Move(base.transform.forward * this.Speed * Time.deltaTime);
			}
			this.Speed = Mathf.MoveTowards(this.Speed, 0f, Time.deltaTime * this.MaxSpeed);
			if (this.Speed > 0f)
			{
				base.transform.LookAt(this.Player.transform.position);
			}
			if (this.MyAnimation[this.ArcSpecialAnimA].time >= this.MyAnimation[this.ArcSpecialAnimA].length)
			{
				this.MyAnimation.CrossFade(this.ArcSpecialAnimB);
			}
			else if (this.MyAnimation[this.ArcSpecialAnimA].time >= this.MyAnimation[this.ArcSpecialAnimA].length * 0.35f)
			{
				this.Weapons[this.MyWeapon].transform.parent = this.RightHand;
				this.Weapons[this.MyWeapon].transform.localPosition = Vector3.zero;
				this.Weapons[this.MyWeapon].transform.localEulerAngles = Vector3.zero;
			}
			if (this.MyAnimation[this.ArcSpecialAnimB].time >= this.MyAnimation[this.ArcSpecialAnimB].length * 0.9f)
			{
				this.Weapons[this.MyWeapon].transform.parent = this.WeaponParent;
				this.Weapons[this.MyWeapon].transform.localPosition = Vector3.zero;
				this.Weapons[this.MyWeapon].transform.localEulerAngles = Vector3.zero;
				this.EyeTwinkle.SetActive(false);
				this.HitboxSpawned = false;
				this.ArcSpecial = false;
				UnityEngine.Object.Destroy(this.Warning);
				return;
			}
			if (!this.HitboxSpawned)
			{
				if (this.MyAnimation[this.ArcSpecialAnimB].time >= this.MyAnimation[this.ArcSpecialAnimB].length * 0.34f)
				{
					this.ArcSpecialHitbox.SetActive(true);
					this.HitboxSpawned = true;
					return;
				}
			}
			else if (this.MyAnimation[this.ArcSpecialAnimB].time >= this.MyAnimation[this.ArcSpecialAnimB].length * 0.44f)
			{
				this.ArcSpecialHitbox.SetActive(false);
				return;
			}
		}
		else if (this.Defeated)
		{
			if (this.KnockedDown)
			{
				this.KnockBackSpeed = this.MaxKnockBackSpeed * (1f - this.MyAnimation[this.KnockedDownAnim].time / this.MyAnimation[this.KnockedDownAnim].length);
				this.MyController.Move(base.transform.forward * this.KnockBackSpeed * -1f * Time.deltaTime);
				if (this.MyAnimation[this.KnockedDownAnim].time >= this.MyAnimation[this.KnockedDownAnim].length)
				{
					this.MyAnimation.CrossFade(this.KnockedDownLoop);
					this.MyController.enabled = false;
					base.enabled = false;
					return;
				}
			}
			else if (this.MyAnimation[this.DefeatAnim].time >= this.MyAnimation[this.DefeatAnim].length)
			{
				this.MyAnimation.CrossFade(this.DefeatLoop);
				base.enabled = false;
				return;
			}
		}
		else
		{
			if (Vector3.Distance(base.transform.position, this.Player.transform.position) < 5f)
			{
				this.SpecialTimer += Time.deltaTime;
				if (this.SpecialTimer > 5f)
				{
					this.SpecialTimer = 0f;
					int num = UnityEngine.Random.RandomRange(0, 3);
					if (num == 1)
					{
						this.Warning = UnityEngine.Object.Instantiate<GameObject>(this.StraightSpecialWarning, base.transform.position, base.transform.rotation);
						this.MyAnimation.CrossFade(this.StraightSpecialAnim);
						this.EyeTwinkle.SetActive(true);
						this.StraightSpecial = true;
					}
					else if (num == 2)
					{
						this.Warning = UnityEngine.Object.Instantiate<GameObject>(this.ArcSpecialWarning, base.transform.position, base.transform.rotation);
						this.Warning.transform.parent = base.transform;
						this.MyAnimation.CrossFade(this.ArcSpecialAnimA);
						this.EyeTwinkle.SetActive(true);
						this.ArcSpecial = true;
						this.Speed = 5f;
					}
				}
			}
			if (!this.StraightSpecial && !this.ArcSpecial)
			{
				if (this.Player.Enemy == this)
				{
					if (Vector3.Distance(base.transform.position, this.Player.transform.position) > 1f)
					{
						this.MyController.Move(base.transform.forward * Time.deltaTime);
						this.MyAnimation.CrossFade(this.WalkAnim);
						return;
					}
					this.MyAnimation.CrossFade(this.IdleAnim);
					this.AttackTimer += Time.deltaTime;
					if (this.AttackTimer > 0.5f)
					{
						this.MyAnimation.CrossFade(this.AttackAnim);
						this.MyAudio.clip = this.Whoosh;
						this.MyAudio.Play();
						this.HitboxSpawned = false;
						this.Attacking = true;
						this.AttackTimer = 0f;
						return;
					}
				}
				else
				{
					this.MyAnimation.CrossFade(this.WalkAnim);
					if ((double)Vector3.Distance(base.transform.position, this.Player.transform.position) > 2.5)
					{
						this.MyController.Move(base.transform.forward * Time.deltaTime);
						return;
					}
					this.MyController.Move(base.transform.right * -1f * Time.deltaTime);
				}
			}
		}
	}

	// Token: 0x06000A17 RID: 2583 RVA: 0x00057D14 File Offset: 0x00055F14
	private void OnTriggerEnter(Collider other)
	{
		if (this.Health > 0f && other.gameObject.layer == 18)
		{
			BeatEmUpHitboxScript component = other.gameObject.GetComponent<BeatEmUpHitboxScript>();
			if (!component.Enemy)
			{
				if (!component.Super)
				{
					this.Player.SuperMeter += 5f;
					if (this.Player.SuperMeter > this.Player.MaxSuper)
					{
						this.Player.SuperMeter = this.Player.MaxSuper;
					}
					if (this.Player.SuperMeter >= 100f)
					{
						this.Player.SuperButton.alpha = 1f;
					}
					this.Player.SuperLabel.text = this.Player.SuperMeter.ToString() + " / " + this.Player.MaxSuper.ToString();
					this.Player.SuperBar.transform.localScale = new Vector3(this.Player.SuperMeter / this.Player.MaxSuper, 1f, 1f);
				}
				this.MyAudio.clip = this.HitSFX;
				this.MyAudio.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
				this.MyAudio.Play();
				base.transform.localScale = new Vector3(base.transform.localScale.x * -1f, 1f, 1f);
				if (component.Heavy)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.HitEffect, this.Player.RightFoot.position, Quaternion.identity);
				}
				else if (component.AttackID == 1 || component.AttackID == 3 || component.AttackID == 5)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.HitEffect, this.Player.LeftHand.position, Quaternion.identity);
				}
				else
				{
					UnityEngine.Object.Instantiate<GameObject>(this.HitEffect, this.Player.RightHand.position, Quaternion.identity);
				}
				this.Health -= component.Damage;
				if (this.Health <= 0f)
				{
					AudioSource.PlayClipAtPoint(this.Defeat[UnityEngine.Random.Range(1, this.Defeat.Length)], this.Player.MainCamera.transform.position);
					this.StraightSpecialHitbox.SetActive(false);
					this.ArcSpecialHitbox.SetActive(false);
					if (this.Warning != null)
					{
						UnityEngine.Object.Destroy(this.Warning);
					}
					this.StraightSpecial = false;
					this.HitReacting = false;
					this.ArcSpecial = false;
					this.Defeated = true;
					this.Health = 0f;
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
					if (this.Player.Super)
					{
						this.Player.GetNearestEnemy();
						this.Player.transform.LookAt(this.Player.Ring.position);
						return;
					}
				}
				else
				{
					AudioSource.PlayClipAtPoint(this.HitReact[UnityEngine.Random.Range(1, this.HitReact.Length)], this.Player.MainCamera.transform.position);
					if (!this.StraightSpecial && !this.ArcSpecial)
					{
						this.MyAnimation[this.HitReactAnim].time = 0f;
						this.MyAnimation.CrossFade(this.HitReactAnim);
						this.HitReacting = true;
						this.Attacking = false;
						this.AttackTimer = 0f;
					}
				}
			}
		}
	}

	// Token: 0x04000AE0 RID: 2784
	public CharacterController MyController;

	// Token: 0x04000AE1 RID: 2785
	public BeatEmUpScript Player;

	// Token: 0x04000AE2 RID: 2786
	public GameObject StraightSpecialWarning;

	// Token: 0x04000AE3 RID: 2787
	public GameObject StraightSpecialHitbox;

	// Token: 0x04000AE4 RID: 2788
	public GameObject ArcSpecialWarning;

	// Token: 0x04000AE5 RID: 2789
	public GameObject ArcSpecialHitbox;

	// Token: 0x04000AE6 RID: 2790
	public GameObject EyeTwinkle;

	// Token: 0x04000AE7 RID: 2791
	public GameObject MyRenderer;

	// Token: 0x04000AE8 RID: 2792
	public GameObject HitEffect;

	// Token: 0x04000AE9 RID: 2793
	public GameObject BeltCoat;

	// Token: 0x04000AEA RID: 2794
	public GameObject Warning;

	// Token: 0x04000AEB RID: 2795
	public GameObject Hitbox;

	// Token: 0x04000AEC RID: 2796
	public Renderer WeaponBagRenderer;

	// Token: 0x04000AED RID: 2797
	public Renderer HairRenderer;

	// Token: 0x04000AEE RID: 2798
	public Transform WeaponParent;

	// Token: 0x04000AEF RID: 2799
	public Transform RightHand;

	// Token: 0x04000AF0 RID: 2800
	public Animation MyAnimation;

	// Token: 0x04000AF1 RID: 2801
	public GameObject[] Weapons;

	// Token: 0x04000AF2 RID: 2802
	public AudioSource MyAudio;

	// Token: 0x04000AF3 RID: 2803
	public AudioClip HitSFX;

	// Token: 0x04000AF4 RID: 2804
	public AudioClip Whoosh;

	// Token: 0x04000AF5 RID: 2805
	public AudioClip[] HitReact;

	// Token: 0x04000AF6 RID: 2806
	public AudioClip[] Defeat;

	// Token: 0x04000AF7 RID: 2807
	public float MaxKnockBackSpeed;

	// Token: 0x04000AF8 RID: 2808
	public float KnockBackSpeed;

	// Token: 0x04000AF9 RID: 2809
	public float MaxSpeed;

	// Token: 0x04000AFA RID: 2810
	public float Speed;

	// Token: 0x04000AFB RID: 2811
	public string KnockedDownAnim;

	// Token: 0x04000AFC RID: 2812
	public string KnockedDownLoop;

	// Token: 0x04000AFD RID: 2813
	public string DefeatAnim;

	// Token: 0x04000AFE RID: 2814
	public string DefeatLoop;

	// Token: 0x04000AFF RID: 2815
	public string StraightSpecialAnim;

	// Token: 0x04000B00 RID: 2816
	public string ArcSpecialAnimA;

	// Token: 0x04000B01 RID: 2817
	public string ArcSpecialAnimB;

	// Token: 0x04000B02 RID: 2818
	public string HitReactAnim;

	// Token: 0x04000B03 RID: 2819
	public string AttackAnim;

	// Token: 0x04000B04 RID: 2820
	public string IdleAnim;

	// Token: 0x04000B05 RID: 2821
	public string WalkAnim;

	// Token: 0x04000B06 RID: 2822
	public string Name;

	// Token: 0x04000B07 RID: 2823
	public bool StraightSpecial;

	// Token: 0x04000B08 RID: 2824
	public bool HitboxSpawned;

	// Token: 0x04000B09 RID: 2825
	public bool HitReacting;

	// Token: 0x04000B0A RID: 2826
	public bool KnockedDown;

	// Token: 0x04000B0B RID: 2827
	public bool ArcSpecial;

	// Token: 0x04000B0C RID: 2828
	public bool Attacking;

	// Token: 0x04000B0D RID: 2829
	public bool Defeated;

	// Token: 0x04000B0E RID: 2830
	public float SpecialTimer;

	// Token: 0x04000B0F RID: 2831
	public float AttackTimer;

	// Token: 0x04000B10 RID: 2832
	public float AnimSpeed;

	// Token: 0x04000B11 RID: 2833
	public float MaxHealth;

	// Token: 0x04000B12 RID: 2834
	public float Health;

	// Token: 0x04000B13 RID: 2835
	public int Difficulty = 1;

	// Token: 0x04000B14 RID: 2836
	public int MyWeapon = 1;

	// Token: 0x04000B15 RID: 2837
	public int EnemyID = 1;
}
