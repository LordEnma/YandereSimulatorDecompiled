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

	public string SideWalkAnim;

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
		for (int i = 1; i < Weapons.Length; i++)
		{
			Weapons[i].SetActive(value: false);
		}
	}

	public void Start()
	{
		Physics.IgnoreLayerCollision(9, 9);
		Difficulty = GameGlobals.BeatEmUpDifficulty;
		MaxHealth += Difficulty * 25;
		MyAnimation[WalkAnim].speed = AnimSpeed;
		Weapons[MyWeapon].SetActive(value: true);
		Health = MaxHealth;
		if (GameGlobals.Eighties)
		{
			HairRenderer.material.color = new Color(0.2f, 0.2f, 0.2f, 1f);
			Name = "Rival Gang Member #" + EnemyID;
			WeaponBagRenderer.enabled = false;
			MyRenderer.SetActive(value: false);
			BeltCoat.SetActive(value: true);
		}
	}

	private void Update()
	{
		if (!StraightSpecial && !ArcSpecial)
		{
			base.transform.LookAt(Player.transform.position);
		}
		if (Player.Defeated)
		{
			MyAnimation.CrossFade(IdleAnim);
			if (Warning != null)
			{
				Object.Destroy(Warning);
			}
			return;
		}
		if (HitReacting)
		{
			if (MyAnimation[HitReactAnim].time >= MyAnimation[HitReactAnim].length)
			{
				MyAnimation.CrossFade(IdleAnim);
				HitReacting = false;
			}
			return;
		}
		if (Attacking)
		{
			if (MyAnimation[AttackAnim].time >= MyAnimation[AttackAnim].length)
			{
				MyAnimation.CrossFade(IdleAnim);
				Attacking = false;
			}
			else if (!HitboxSpawned && MyAnimation[AttackAnim].time >= MyAnimation[AttackAnim].length * 0.45f)
			{
				Object.Instantiate(Hitbox, base.transform.position + base.transform.forward * 0.67f + new Vector3(0f, 1f, 0f), base.transform.rotation);
				HitboxSpawned = true;
			}
			return;
		}
		if (StraightSpecial)
		{
			if (MyAnimation[StraightSpecialAnim].time >= MyAnimation[StraightSpecialAnim].length * 0.9f)
			{
				StraightSpecialHitbox.SetActive(value: false);
				EyeTwinkle.SetActive(value: false);
				StraightSpecial = false;
				HitboxSpawned = false;
				Object.Destroy(Warning);
			}
			else if (!HitboxSpawned)
			{
				if (MyAnimation[StraightSpecialAnim].time >= MyAnimation[StraightSpecialAnim].length * 0.39f)
				{
					StraightSpecialHitbox.SetActive(value: true);
					HitboxSpawned = true;
					Speed = MaxSpeed;
				}
			}
			else
			{
				MyController.Move(base.transform.forward * Speed * Time.deltaTime);
				Speed = Mathf.MoveTowards(Speed, 0f, Time.deltaTime * MaxSpeed);
				if (Speed < 1f)
				{
					StraightSpecialHitbox.SetActive(value: false);
				}
			}
			return;
		}
		if (ArcSpecial)
		{
			if (Vector3.Distance(base.transform.position, Player.transform.position) > 1f)
			{
				MyController.Move(base.transform.forward * Speed * Time.deltaTime);
			}
			Speed = Mathf.MoveTowards(Speed, 0f, Time.deltaTime * MaxSpeed);
			if (Speed > 0f)
			{
				base.transform.LookAt(Player.transform.position);
			}
			if (MyAnimation[ArcSpecialAnimA].time >= MyAnimation[ArcSpecialAnimA].length)
			{
				MyAnimation.CrossFade(ArcSpecialAnimB);
			}
			else if (MyAnimation[ArcSpecialAnimA].time >= MyAnimation[ArcSpecialAnimA].length * 0.35f)
			{
				Weapons[MyWeapon].transform.parent = RightHand;
				Weapons[MyWeapon].transform.localPosition = Vector3.zero;
				Weapons[MyWeapon].transform.localEulerAngles = Vector3.zero;
			}
			if (MyAnimation[ArcSpecialAnimB].time >= MyAnimation[ArcSpecialAnimB].length * 0.9f)
			{
				Weapons[MyWeapon].transform.parent = WeaponParent;
				Weapons[MyWeapon].transform.localPosition = Vector3.zero;
				Weapons[MyWeapon].transform.localEulerAngles = Vector3.zero;
				EyeTwinkle.SetActive(value: false);
				HitboxSpawned = false;
				ArcSpecial = false;
				Object.Destroy(Warning);
			}
			else if (!HitboxSpawned)
			{
				if (MyAnimation[ArcSpecialAnimB].time >= MyAnimation[ArcSpecialAnimB].length * 0.34f)
				{
					ArcSpecialHitbox.SetActive(value: true);
					HitboxSpawned = true;
				}
			}
			else if (MyAnimation[ArcSpecialAnimB].time >= MyAnimation[ArcSpecialAnimB].length * 0.44f)
			{
				ArcSpecialHitbox.SetActive(value: false);
			}
			return;
		}
		if (Defeated)
		{
			if (KnockedDown)
			{
				KnockBackSpeed = MaxKnockBackSpeed * (1f - MyAnimation[KnockedDownAnim].time / MyAnimation[KnockedDownAnim].length);
				MyController.Move(base.transform.forward * KnockBackSpeed * -1f * Time.deltaTime);
				if (MyAnimation[KnockedDownAnim].time >= MyAnimation[KnockedDownAnim].length)
				{
					MyAnimation.CrossFade(KnockedDownLoop);
					MyController.enabled = false;
					base.enabled = false;
				}
			}
			else if (MyAnimation[DefeatAnim].time >= MyAnimation[DefeatAnim].length)
			{
				MyAnimation.CrossFade(DefeatLoop);
				base.enabled = false;
			}
			return;
		}
		if (Vector3.Distance(base.transform.position, Player.transform.position) < 5f)
		{
			SpecialTimer += Time.deltaTime;
			if (SpecialTimer > 5f)
			{
				SpecialTimer = 0f;
				switch (Random.RandomRange(0, 3))
				{
				case 1:
					Warning = Object.Instantiate(StraightSpecialWarning, base.transform.position, base.transform.rotation);
					MyAnimation.CrossFade(StraightSpecialAnim);
					EyeTwinkle.SetActive(value: true);
					StraightSpecial = true;
					break;
				case 2:
					Warning = Object.Instantiate(ArcSpecialWarning, base.transform.position, base.transform.rotation);
					Warning.transform.parent = base.transform;
					MyAnimation.CrossFade(ArcSpecialAnimA);
					EyeTwinkle.SetActive(value: true);
					ArcSpecial = true;
					Speed = 5f;
					break;
				}
			}
		}
		if (StraightSpecial || ArcSpecial)
		{
			return;
		}
		if (Player.Enemy == this)
		{
			if (Vector3.Distance(base.transform.position, Player.transform.position) > 1f)
			{
				MyController.Move(base.transform.forward * Time.deltaTime);
				MyAnimation.CrossFade(WalkAnim);
				return;
			}
			MyAnimation.CrossFade(IdleAnim);
			AttackTimer += Time.deltaTime;
			if (AttackTimer > 0.5f)
			{
				MyAnimation.CrossFade(AttackAnim);
				MyAudio.clip = Whoosh;
				MyAudio.Play();
				HitboxSpawned = false;
				Attacking = true;
				AttackTimer = 0f;
			}
		}
		else if ((double)Vector3.Distance(base.transform.position, Player.transform.position) > 2.5)
		{
			MyController.Move(base.transform.forward * Time.deltaTime);
			MyAnimation.CrossFade(WalkAnim);
		}
		else
		{
			MyController.Move(base.transform.right * -1f * Time.deltaTime);
			MyAnimation.CrossFade(SideWalkAnim);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!(Health > 0f) || other.gameObject.layer != 18)
		{
			return;
		}
		BeatEmUpHitboxScript component = other.gameObject.GetComponent<BeatEmUpHitboxScript>();
		if (component.Enemy)
		{
			return;
		}
		if (!component.Super)
		{
			Player.SuperMeter += 5f;
			if (Player.SuperMeter > Player.MaxSuper)
			{
				Player.SuperMeter = Player.MaxSuper;
			}
			if (Player.SuperMeter >= 100f)
			{
				Player.SuperButton.alpha = 1f;
			}
			Player.SuperLabel.text = Player.SuperMeter + " / " + Player.MaxSuper;
			Player.SuperBar.transform.localScale = new Vector3(Player.SuperMeter / Player.MaxSuper, 1f, 1f);
		}
		MyAudio.clip = HitSFX;
		MyAudio.pitch = Random.Range(0.9f, 1.1f);
		MyAudio.Play();
		base.transform.localScale = new Vector3(base.transform.localScale.x * -1f, 1f, 1f);
		if (component.Heavy)
		{
			Object.Instantiate(HitEffect, Player.RightFoot.position, Quaternion.identity);
		}
		else if (component.AttackID == 1 || component.AttackID == 3 || component.AttackID == 5)
		{
			Object.Instantiate(HitEffect, Player.LeftHand.position, Quaternion.identity);
		}
		else
		{
			Object.Instantiate(HitEffect, Player.RightHand.position, Quaternion.identity);
		}
		Health -= component.Damage;
		if (Health <= 0f)
		{
			AudioSource.PlayClipAtPoint(Defeat[Random.Range(1, Defeat.Length)], Player.MainCamera.transform.position);
			StraightSpecialHitbox.SetActive(value: false);
			ArcSpecialHitbox.SetActive(value: false);
			if (Warning != null)
			{
				Object.Destroy(Warning);
			}
			StraightSpecial = false;
			HitReacting = false;
			ArcSpecial = false;
			Defeated = true;
			Health = 0f;
			if (component.AttackID == 14)
			{
				MyAnimation.CrossFade(KnockedDownAnim);
				KnockedDown = true;
			}
			else
			{
				MyAnimation.CrossFade(DefeatAnim);
				MyController.enabled = false;
			}
			Player.VictoryCheck();
			if (Player.Super)
			{
				Player.GetNearestEnemy();
				Player.transform.LookAt(Player.Ring.position);
			}
		}
		else
		{
			AudioSource.PlayClipAtPoint(HitReact[Random.Range(1, HitReact.Length)], Player.MainCamera.transform.position);
			if (!StraightSpecial && !ArcSpecial)
			{
				MyAnimation[HitReactAnim].time = 0f;
				MyAnimation.CrossFade(HitReactAnim);
				HitReacting = true;
				Attacking = false;
				AttackTimer = 0f;
			}
		}
	}
}
