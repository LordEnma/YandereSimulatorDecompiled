﻿using System;
using UnityEngine;

// Token: 0x0200030B RID: 779
public class HeadmasterScript : MonoBehaviour
{
	// Token: 0x0600182C RID: 6188 RVA: 0x000E5644 File Offset: 0x000E3844
	private void Start()
	{
		this.MyAnimation["HeadmasterRaiseTazer"].speed = 2f;
		this.Tazer.SetActive(false);
		this.IdleAnim = "HeadmasterType";
		if (GameGlobals.Eighties)
		{
			this.IdleAnim = "HeadmasterDeskWritePingPong";
			this.MyAnimation.CrossFade(this.IdleAnim);
			this.EightiesPaper.SetActive(true);
			this.Trashcan.SetActive(false);
			this.Laptop.SetActive(false);
			this.Pen.SetActive(true);
			this.EightiesAttacher.gameObject.SetActive(true);
			this.OriginalMesh[1].GetComponent<SkinnedMeshRenderer>().material = this.Transparency;
			this.OriginalMesh[2].SetActive(false);
			this.OriginalMesh[3].SetActive(false);
			this.OriginalMesh[4].SetActive(false);
			this.OriginalMesh[5].SetActive(false);
			this.HeadmasterSpeechText = this.EightiesHeadmasterSpeechText;
			this.HeadmasterThreatText = this.EightiesHeadmasterThreatText;
			this.HeadmasterBoxText = this.EightiesHeadmasterBoxText;
			this.HeadmasterWeaponText = this.EightiesHeadmasterWeaponText;
			this.HeadmasterCrypticText = this.EightiesHeadmasterCrypticText;
			this.HeadmasterCorpseText = this.EightiesHeadmasterCorpseText;
			this.Head = this.Head.parent;
			this.MyAudio.volume = 0f;
			this.MidDistance = 1.54f;
			this.MinDistance = 0.0001f;
		}
	}

	// Token: 0x0600182D RID: 6189 RVA: 0x000E57B8 File Offset: 0x000E39B8
	private void Update()
	{
		if (this.Yandere.transform.position.y > base.transform.position.y - 1f && this.Yandere.transform.position.y < base.transform.position.y + 1f && this.Yandere.transform.position.x < 6f && this.Yandere.transform.position.x > -6f)
		{
			this.Distance = Vector3.Distance(base.transform.position, this.Yandere.transform.position);
			if (this.Shooting)
			{
				this.targetRotation = Quaternion.LookRotation(base.transform.position - this.Yandere.transform.position);
				this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
				this.AimWeaponAtYandere();
				this.AimBodyAtYandere();
				this.Yandere.CanMove = false;
			}
			else if (this.Distance < this.MinDistance)
			{
				this.AimBodyAtYandere();
				if (this.Yandere.CanMove && !this.Yandere.Egg && !this.Shooting)
				{
					this.Shoot();
				}
			}
			else if (this.Distance < this.MidDistance)
			{
				this.PlayedSitSound = false;
				if (!this.StudentManager.Eighties)
				{
					if (!this.StudentManager.Clock.StopTime)
					{
						this.PatienceTimer -= Time.deltaTime;
					}
					if (this.PatienceTimer < 0f && !this.Yandere.Egg)
					{
						this.LostPatience = true;
						this.PatienceTimer = 60f;
						this.Patience = 0;
						this.Shoot();
					}
					if (!this.LostPatience)
					{
						this.LostPatience = true;
						this.Patience--;
						if (this.Patience < 1 && !this.Yandere.Egg && !this.Shooting)
						{
							this.Shoot();
						}
					}
					this.AimBodyAtYandere();
					this.Threatened = true;
					this.AimWeaponAtYandere();
				}
				this.ThreatTimer = Mathf.MoveTowards(this.ThreatTimer, 0f, Time.deltaTime);
				if (this.ThreatTimer == 0f)
				{
					this.ThreatID++;
					if (this.ThreatID < 5)
					{
						this.HeadmasterSubtitle.text = this.HeadmasterThreatText[this.ThreatID];
						this.MyAudio.clip = this.HeadmasterThreatClips[this.ThreatID];
						this.MyAudio.Play();
						this.ThreatTimer = this.HeadmasterThreatClips[this.ThreatID].length + 1f;
					}
				}
				this.CheckBehavior();
			}
			else if (this.Distance < this.MaxDistance)
			{
				this.PlayedStandSound = false;
				this.LostPatience = false;
				this.targetRotation = Quaternion.LookRotation(new Vector3(0f, 8f, 0f) - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
				this.Chair.localPosition = Vector3.Lerp(this.Chair.localPosition, new Vector3(this.Chair.localPosition.x, this.Chair.localPosition.y, -4.66666f), Time.deltaTime * 1f);
				this.LookAtPlayer = true;
				if (!this.Threatened)
				{
					if (this.StudentManager.Eighties && this.Yandere.transform.position.z < -32.63333f)
					{
						this.MyAnimation.CrossFade(this.IdleAnim, 1f);
						this.LookAtPlayer = false;
					}
					else
					{
						this.MyAnimation.CrossFade("HeadmasterAttention", 1f);
					}
					this.ScratchTimer = 0f;
					this.SpeechTimer = Mathf.MoveTowards(this.SpeechTimer, 0f, Time.deltaTime);
					if (this.SpeechTimer == 0f)
					{
						if (this.CardboardBox.parent != this.Yandere.Hips && this.Yandere.Mask == null)
						{
							this.VoiceID++;
							if (this.VoiceID < 6)
							{
								this.HeadmasterSubtitle.text = this.HeadmasterSpeechText[this.VoiceID];
								this.MyAudio.clip = this.HeadmasterSpeechClips[this.VoiceID];
								this.MyAudio.Play();
								this.SpeechTimer = this.HeadmasterSpeechClips[this.VoiceID].length + 1f;
							}
						}
						else
						{
							this.BoxID++;
							if (this.BoxID < 6)
							{
								this.HeadmasterSubtitle.text = this.HeadmasterBoxText[this.BoxID];
								this.MyAudio.clip = this.HeadmasterBoxClips[this.BoxID];
								this.MyAudio.Play();
								this.SpeechTimer = this.HeadmasterBoxClips[this.BoxID].length + 1f;
							}
						}
					}
				}
				else if (!this.Relaxing)
				{
					this.HeadmasterSubtitle.text = this.HeadmasterRelaxText;
					this.MyAudio.clip = this.HeadmasterRelaxClip;
					this.MyAudio.Play();
					this.Relaxing = true;
				}
				else
				{
					if (!this.PlayedSitSound)
					{
						AudioSource.PlayClipAtPoint(this.SitDown, base.transform.position);
						this.PlayedSitSound = true;
					}
					this.MyAnimation.CrossFade("HeadmasterLowerTazer");
					this.Aiming = false;
					if ((double)this.MyAnimation["HeadmasterLowerTazer"].time > 1.33333)
					{
						this.Tazer.SetActive(false);
					}
					if (this.MyAnimation["HeadmasterLowerTazer"].time > this.MyAnimation["HeadmasterLowerTazer"].length)
					{
						this.Threatened = false;
						this.Relaxing = false;
					}
				}
				this.CheckBehavior();
			}
			else
			{
				if (this.LookAtPlayer)
				{
					this.MyAnimation.CrossFade(this.IdleAnim);
					this.LookAtPlayer = false;
					this.Threatened = false;
					this.Relaxing = false;
					this.Aiming = false;
				}
				this.ScratchTimer += Time.deltaTime;
				if (this.ScratchTimer > 10f)
				{
					this.MyAnimation.CrossFade("HeadmasterScratch");
					if (this.MyAnimation["HeadmasterScratch"].time > this.MyAnimation["HeadmasterScratch"].length)
					{
						this.MyAnimation.CrossFade(this.IdleAnim);
						this.ScratchTimer = 0f;
					}
				}
			}
			if (!this.MyAudio.isPlaying)
			{
				this.HeadmasterSubtitle.text = string.Empty;
				if (this.Shooting)
				{
					this.Taze();
				}
			}
			if (this.Yandere.Attacked && this.Yandere.CharacterAnimation["f02_swingB_00"].time >= this.Yandere.CharacterAnimation["f02_swingB_00"].length * 0.85f)
			{
				this.MyAudio.clip = this.Crumple;
				this.MyAudio.Play();
				base.enabled = false;
				return;
			}
		}
		else
		{
			this.HeadmasterSubtitle.text = string.Empty;
		}
	}

	// Token: 0x0600182E RID: 6190 RVA: 0x000E5FAC File Offset: 0x000E41AC
	private void LateUpdate()
	{
		this.LookAtTarget = Vector3.Lerp(this.LookAtTarget, this.LookAtPlayer ? this.Yandere.Head.position : this.Default.position, Time.deltaTime * 10f);
		this.Head.LookAt(this.LookAtTarget);
	}

	// Token: 0x0600182F RID: 6191 RVA: 0x000E600C File Offset: 0x000E420C
	private void AimBodyAtYandere()
	{
		this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - base.transform.position);
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 5f);
		this.Chair.localPosition = Vector3.Lerp(this.Chair.localPosition, new Vector3(this.Chair.localPosition.x, this.Chair.localPosition.y, -5.2f), Time.deltaTime * 1f);
	}

	// Token: 0x06001830 RID: 6192 RVA: 0x000E60C0 File Offset: 0x000E42C0
	private void AimWeaponAtYandere()
	{
		if (!this.Aiming)
		{
			Debug.Log("The headmaster is being told to raise his tazer.");
			this.MyAnimation.CrossFade("HeadmasterRaiseTazer");
			if (!this.PlayedStandSound)
			{
				AudioSource.PlayClipAtPoint(this.StandUp, base.transform.position);
				this.PlayedStandSound = true;
			}
			if ((double)this.MyAnimation["HeadmasterRaiseTazer"].time > 1.166666)
			{
				this.Tazer.SetActive(true);
				this.Aiming = true;
				return;
			}
		}
		else
		{
			Debug.Log("The headmaster is being told to aim his tazer.");
			if (this.MyAnimation["HeadmasterRaiseTazer"].time > this.MyAnimation["HeadmasterRaiseTazer"].length)
			{
				this.MyAnimation.CrossFade("HeadmasterAimTazer");
			}
		}
	}

	// Token: 0x06001831 RID: 6193 RVA: 0x000E6190 File Offset: 0x000E4390
	public void Shoot()
	{
		this.StudentManager.YandereDying = true;
		if (this.StudentManager.Clock.TimeSkip)
		{
			this.StudentManager.Clock.EndTimeSkip();
		}
		this.Yandere.StopAiming();
		this.Yandere.StopLaughing();
		this.Yandere.CharacterAnimation.CrossFade("f02_readyToFight_00");
		if (this.Patience < 1)
		{
			this.HeadmasterSubtitle.text = this.HeadmasterPatienceText;
			this.MyAudio.clip = this.HeadmasterPatienceClip;
		}
		else if (this.Yandere.Armed)
		{
			this.HeadmasterSubtitle.text = this.HeadmasterWeaponText;
			this.MyAudio.clip = this.HeadmasterWeaponClip;
		}
		else if (this.Yandere.Carrying || this.Yandere.Dragging || (this.Yandere.PickUp != null && this.Yandere.PickUp.BodyPart))
		{
			this.HeadmasterSubtitle.text = this.HeadmasterCorpseText;
			this.MyAudio.clip = this.HeadmasterCorpseClip;
		}
		else
		{
			this.HeadmasterSubtitle.text = this.HeadmasterAttackText;
			this.MyAudio.clip = this.HeadmasterAttackClip;
		}
		this.StudentManager.StopMoving();
		this.Yandere.EmptyHands();
		this.Yandere.CanMove = false;
		this.Yandere.Stance.Current = StanceType.Standing;
		this.MyAudio.Play();
		this.LookAtPlayer = true;
		this.Shooting = true;
	}

	// Token: 0x06001832 RID: 6194 RVA: 0x000E6330 File Offset: 0x000E4530
	private void CheckBehavior()
	{
		if (this.Yandere.CanMove && !this.Yandere.Egg)
		{
			if (this.Yandere.Chased || this.Yandere.Chasers > 0)
			{
				if (!this.Shooting)
				{
					this.Shoot();
					return;
				}
			}
			else if (this.Yandere.Armed)
			{
				if (!this.Shooting)
				{
					this.Shoot();
					return;
				}
			}
			else if ((this.Yandere.Carrying || this.Yandere.Dragging || (this.Yandere.PickUp != null && this.Yandere.PickUp.BodyPart)) && !this.Shooting)
			{
				this.Shoot();
			}
		}
	}

	// Token: 0x06001833 RID: 6195 RVA: 0x000E63F8 File Offset: 0x000E45F8
	public void Taze()
	{
		if (this.Yandere.CanMove)
		{
			this.StudentManager.YandereDying = true;
			this.Yandere.StopAiming();
			this.Yandere.StopLaughing();
			this.StudentManager.StopMoving();
			this.Yandere.EmptyHands();
			this.Yandere.CanMove = false;
		}
		UnityEngine.Object.Instantiate<GameObject>(this.LightningEffect, this.TazerEffectTarget.position, Quaternion.identity);
		UnityEngine.Object.Instantiate<GameObject>(this.LightningEffect, this.Yandere.Spine[3].position, Quaternion.identity);
		this.MyAudio.clip = this.HeadmasterShockClip;
		this.MyAudio.Play();
		this.Yandere.CharacterAnimation.CrossFade("f02_swingB_00");
		this.Yandere.CharacterAnimation["f02_swingB_00"].time = 0.5f;
		this.Yandere.RPGCamera.enabled = false;
		this.Yandere.FakingReaction = false;
		this.Yandere.Attacked = true;
		this.Heartbroken.Headmaster = true;
		this.Jukebox.Volume = 0f;
		this.Shooting = false;
	}

	// Token: 0x0400232B RID: 9003
	public StudentManagerScript StudentManager;

	// Token: 0x0400232C RID: 9004
	public HeartbrokenScript Heartbroken;

	// Token: 0x0400232D RID: 9005
	public YandereScript Yandere;

	// Token: 0x0400232E RID: 9006
	public JukeboxScript Jukebox;

	// Token: 0x0400232F RID: 9007
	public AudioClip[] HeadmasterSpeechClips;

	// Token: 0x04002330 RID: 9008
	public AudioClip[] HeadmasterThreatClips;

	// Token: 0x04002331 RID: 9009
	public AudioClip[] HeadmasterBoxClips;

	// Token: 0x04002332 RID: 9010
	public AudioClip HeadmasterRelaxClip;

	// Token: 0x04002333 RID: 9011
	public AudioClip HeadmasterAttackClip;

	// Token: 0x04002334 RID: 9012
	public AudioClip HeadmasterCrypticClip;

	// Token: 0x04002335 RID: 9013
	public AudioClip HeadmasterShockClip;

	// Token: 0x04002336 RID: 9014
	public AudioClip HeadmasterPatienceClip;

	// Token: 0x04002337 RID: 9015
	public AudioClip HeadmasterCorpseClip;

	// Token: 0x04002338 RID: 9016
	public AudioClip HeadmasterWeaponClip;

	// Token: 0x04002339 RID: 9017
	public AudioClip Crumple;

	// Token: 0x0400233A RID: 9018
	public AudioClip StandUp;

	// Token: 0x0400233B RID: 9019
	public AudioClip SitDown;

	// Token: 0x0400233C RID: 9020
	public string[] HeadmasterSpeechText = new string[]
	{
		"",
		"Ahh...! It's...it's you!",
		"No, that would be impossible...you must be...her daughter...",
		"I'll tolerate you in my school, but not in my office.",
		"Leave at once.",
		"There is nothing for you to achieve here. Just. Get. Out."
	};

	// Token: 0x0400233D RID: 9021
	public string[] HeadmasterThreatText = new string[]
	{
		"",
		"Not another step!",
		"You're up to no good! I know it!",
		"I'm not going to let you harm me!",
		"I'll use self-defense if I deem it necessary!",
		"This is your final warning. Get out of here...or else."
	};

	// Token: 0x0400233E RID: 9022
	public string[] HeadmasterBoxText = new string[]
	{
		"",
		"What...in...blazes are you doing?",
		"Are you trying to re-enact something you saw in a video game?",
		"Ugh, do you really think such a stupid ploy is going to work?",
		"I know who you are. It's obvious. You're not fooling anyone.",
		"I don't have time for this tomfoolery. Leave at once!"
	};

	// Token: 0x0400233F RID: 9023
	public string[] EightiesHeadmasterSpeechText = new string[]
	{
		"",
		"...oh! Um...hello there, young lady!",
		"Can I, uh...help you with anything?",
		"You don't really...talk much, do you?",
		"Don't you...have a class to run along to?",
		"Well, I suppose there's no harm in letting you spend a bit of time here..."
	};

	// Token: 0x04002340 RID: 9024
	public string[] EightiesHeadmasterThreatText = new string[]
	{
		"",
		"My my, you're quite comfortable here, aren't you?",
		"Care to...introduce yourself?",
		"Most students...don't really do this sort of thing.",
		"You...really seem to have a lot of free time on your hands.",
		"Well, I suppose you're...technically...not breaking any rules..."
	};

	// Token: 0x04002341 RID: 9025
	public string[] EightiesHeadmasterBoxText = new string[]
	{
		"",
		"...uh.",
		"...why are you...doing that?",
		"Is this what the kids like to do these days?",
		"Is this some sort of new fad that nobody told me about?",
		"Well, I suppose that a small amount of tomfoolery is just...part of youth."
	};

	// Token: 0x04002342 RID: 9026
	public string HeadmasterRelaxText = "Hmm...a wise decision.";

	// Token: 0x04002343 RID: 9027
	public string HeadmasterAttackText = "You asked for it!";

	// Token: 0x04002344 RID: 9028
	public string HeadmasterCrypticText = "Mr. Saikou...the deal is off.";

	// Token: 0x04002345 RID: 9029
	public string HeadmasterWeaponText = "How dare you raise a weapon in my office!";

	// Token: 0x04002346 RID: 9030
	public string HeadmasterPatienceText = "Enough of this nonsense!";

	// Token: 0x04002347 RID: 9031
	public string HeadmasterCorpseText = "You...you murderer!";

	// Token: 0x04002348 RID: 9032
	public string EightiesHeadmasterWeaponText = "What are you doing?! Stay back!";

	// Token: 0x04002349 RID: 9033
	public string EightiesHeadmasterCrypticText = "Mr. Saikou, you'll never believe what just happened!";

	// Token: 0x0400234A RID: 9034
	public string EightiesHeadmasterCorpseText = "You...you killed someone!";

	// Token: 0x0400234B RID: 9035
	public UILabel HeadmasterSubtitle;

	// Token: 0x0400234C RID: 9036
	public Animation MyAnimation;

	// Token: 0x0400234D RID: 9037
	public AudioSource MyAudio;

	// Token: 0x0400234E RID: 9038
	public GameObject LightningEffect;

	// Token: 0x0400234F RID: 9039
	public GameObject Tazer;

	// Token: 0x04002350 RID: 9040
	public Transform TazerEffectTarget;

	// Token: 0x04002351 RID: 9041
	public Transform CardboardBox;

	// Token: 0x04002352 RID: 9042
	public Transform Chair;

	// Token: 0x04002353 RID: 9043
	public Quaternion targetRotation;

	// Token: 0x04002354 RID: 9044
	public float PatienceTimer;

	// Token: 0x04002355 RID: 9045
	public float ScratchTimer;

	// Token: 0x04002356 RID: 9046
	public float SpeechTimer;

	// Token: 0x04002357 RID: 9047
	public float ThreatTimer;

	// Token: 0x04002358 RID: 9048
	public float MaxDistance = 10f;

	// Token: 0x04002359 RID: 9049
	public float MidDistance = 2.8f;

	// Token: 0x0400235A RID: 9050
	public float MinDistance = 1.2f;

	// Token: 0x0400235B RID: 9051
	public float Distance;

	// Token: 0x0400235C RID: 9052
	public int Patience = 10;

	// Token: 0x0400235D RID: 9053
	public int ThreatID;

	// Token: 0x0400235E RID: 9054
	public int VoiceID;

	// Token: 0x0400235F RID: 9055
	public int BoxID;

	// Token: 0x04002360 RID: 9056
	public bool PlayedStandSound;

	// Token: 0x04002361 RID: 9057
	public bool PlayedSitSound;

	// Token: 0x04002362 RID: 9058
	public bool LostPatience;

	// Token: 0x04002363 RID: 9059
	public bool Threatened;

	// Token: 0x04002364 RID: 9060
	public bool Relaxing;

	// Token: 0x04002365 RID: 9061
	public bool Shooting;

	// Token: 0x04002366 RID: 9062
	public bool Aiming;

	// Token: 0x04002367 RID: 9063
	public string IdleAnim;

	// Token: 0x04002368 RID: 9064
	public RiggedAccessoryAttacher EightiesAttacher;

	// Token: 0x04002369 RID: 9065
	public GameObject EightiesPaper;

	// Token: 0x0400236A RID: 9066
	public GameObject Trashcan;

	// Token: 0x0400236B RID: 9067
	public GameObject Laptop;

	// Token: 0x0400236C RID: 9068
	public GameObject Pen;

	// Token: 0x0400236D RID: 9069
	public GameObject[] OriginalMesh;

	// Token: 0x0400236E RID: 9070
	public Material Transparency;

	// Token: 0x0400236F RID: 9071
	public Vector3 LookAtTarget;

	// Token: 0x04002370 RID: 9072
	public bool LookAtPlayer;

	// Token: 0x04002371 RID: 9073
	public Transform Default;

	// Token: 0x04002372 RID: 9074
	public Transform Head;
}
