using UnityEngine;

public class HeadmasterScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public HeartbrokenScript Heartbroken;

	public YandereScript Yandere;

	public JukeboxScript Jukebox;

	public AudioClip[] HeadmasterSpeechClips;

	public AudioClip[] HeadmasterThreatClips;

	public AudioClip[] HeadmasterBoxClips;

	public AudioClip HeadmasterRelaxClip;

	public AudioClip HeadmasterAttackClip;

	public AudioClip HeadmasterCrypticClip;

	public AudioClip HeadmasterShockClip;

	public AudioClip HeadmasterPatienceClip;

	public AudioClip HeadmasterCorpseClip;

	public AudioClip HeadmasterWeaponClip;

	public AudioClip[] EightiesHeadmasterSpeechClips;

	public AudioClip[] EightiesHeadmasterThreatClips;

	public AudioClip[] EightiesHeadmasterBoxClips;

	public AudioClip EightiesHeadmasterCrypticClip;

	public AudioClip EightiesHeadmasterCorpseClip;

	public AudioClip Crumple;

	public AudioClip StandUp;

	public AudioClip SitDown;

	public string[] HeadmasterSpeechText = new string[6] { "", "Ahh...! It's...it's you!", "No, that would be impossible...you must be...her daughter...", "I'll tolerate you in my school, but not in my office.", "Leave at once.", "There is nothing for you to achieve here. Just. Get. Out." };

	public string[] HeadmasterThreatText = new string[6] { "", "Not another step!", "You're up to no good! I know it!", "I'm not going to let you harm me!", "I'll use self-defense if I deem it necessary!", "This is your final warning. Get out of here...or else." };

	public string[] HeadmasterBoxText = new string[6] { "", "What...in...blazes are you doing?", "Are you trying to re-enact something you saw in a video game?", "Ugh, do you really think such a stupid ploy is going to work?", "I know who you are. It's obvious. You're not fooling anyone.", "I don't have time for this tomfoolery. Leave at once!" };

	public string[] EightiesHeadmasterSpeechText = new string[6] { "", "...oh! Um...hello there, young lady!", "Can I, uh...help you with anything?", "You don't really...talk much, do you?", "Don't you...have a class to run along to?", "Well, I suppose there's no harm in letting you spend a bit of time here..." };

	public string[] EightiesHeadmasterThreatText = new string[6] { "", "My my, you're quite comfortable here, aren't you?", "Care to...introduce yourself?", "Most students...don't really do this sort of thing.", "You...really seem to have a lot of free time on your hands.", "Well, I suppose you're...technically...not breaking any rules..." };

	public string[] EightiesHeadmasterBoxText = new string[6] { "", "...uh.", "...why are you...doing that?", "Is this what the kids like to do these days?", "Is this some sort of new fad that nobody told me about?", "Well, I suppose that a small amount of tomfoolery is just...part of youth." };

	public string HeadmasterRelaxText = "Hmm...a wise decision.";

	public string HeadmasterAttackText = "You asked for it!";

	public string HeadmasterCrypticText = "Mr. Saikou...the deal is off.";

	public string HeadmasterWeaponText = "How dare you raise a weapon in my office!";

	public string HeadmasterPatienceText = "Enough of this nonsense!";

	public string HeadmasterCorpseText = "You...you murderer!";

	public string EightiesHeadmasterWeaponText = "What are you doing?! Stay back!";

	public string EightiesHeadmasterCrypticText = "Mr. Saikou, you'll never believe what just happened!";

	public string EightiesHeadmasterCorpseText = "You...you killed someone!";

	public UILabel HeadmasterSubtitle;

	public Animation MyAnimation;

	public AudioSource MyAudio;

	public GameObject LightningEffect;

	public GameObject Tazer;

	public Transform TazerEffectTarget;

	public Transform CardboardBox;

	public Transform Chair;

	public Quaternion targetRotation;

	public float PatienceTimer;

	public float ScratchTimer;

	public float SpeechTimer;

	public float ThreatTimer;

	public float MaxDistance = 10f;

	public float MidDistance = 2.8f;

	public float MinDistance = 1.2f;

	public float Distance;

	public int Patience = 10;

	public int ThreatID;

	public int VoiceID;

	public int BoxID;

	public bool PlayedStandSound;

	public bool PlayedSitSound;

	public bool LostPatience;

	public bool Threatened;

	public bool Eighties;

	public bool Relaxing;

	public bool Shooting;

	public bool Aiming;

	public string IdleAnim;

	public RiggedAccessoryAttacher EightiesAttacher;

	public GameObject EightiesPaper;

	public GameObject Trashcan;

	public GameObject Laptop;

	public GameObject Pen;

	public GameObject[] OriginalMesh;

	public Material Transparency;

	public bool LookAtPlayer;

	public bool Initialized;

	public Vector3 LookAtTarget;

	public Transform Default;

	public Transform Head;

	public float LipTimer;

	public float JawRot;

	public Transform Jaw;

	private void Start()
	{
		MyAnimation["HeadmasterRaiseTazer"].speed = 2f;
		Tazer.SetActive(value: false);
		IdleAnim = "HeadmasterType";
		if (GameGlobals.Eighties)
		{
			IdleAnim = "HeadmasterDeskWritePingPong";
			MyAnimation.CrossFade(IdleAnim);
			EightiesPaper.SetActive(value: true);
			Trashcan.SetActive(value: false);
			Laptop.SetActive(value: false);
			Pen.SetActive(value: true);
			EightiesAttacher.gameObject.SetActive(value: true);
			OriginalMesh[1].GetComponent<SkinnedMeshRenderer>().material = Transparency;
			OriginalMesh[2].SetActive(value: false);
			OriginalMesh[3].SetActive(value: false);
			OriginalMesh[4].SetActive(value: false);
			OriginalMesh[5].SetActive(value: false);
			HeadmasterSpeechText = EightiesHeadmasterSpeechText;
			HeadmasterThreatText = EightiesHeadmasterThreatText;
			HeadmasterBoxText = EightiesHeadmasterBoxText;
			HeadmasterWeaponText = EightiesHeadmasterCorpseText;
			HeadmasterCrypticText = EightiesHeadmasterCrypticText;
			HeadmasterCorpseText = EightiesHeadmasterCorpseText;
			HeadmasterSpeechClips = EightiesHeadmasterSpeechClips;
			HeadmasterThreatClips = EightiesHeadmasterThreatClips;
			HeadmasterBoxClips = EightiesHeadmasterBoxClips;
			HeadmasterWeaponClip = EightiesHeadmasterCorpseClip;
			HeadmasterCorpseClip = EightiesHeadmasterCorpseClip;
			HeadmasterAttackClip = EightiesHeadmasterCorpseClip;
			Head = Head.parent;
			MidDistance = 1.54f;
			MinDistance = 0.0001f;
			Eighties = true;
		}
	}

	private void Update()
	{
		if (Yandere.transform.position.y > base.transform.position.y - 1f && Yandere.transform.position.y < base.transform.position.y + 1f && Yandere.transform.position.x < 6f && Yandere.transform.position.x > -6f)
		{
			Distance = Vector3.Distance(base.transform.position, Yandere.transform.position);
			if (Shooting)
			{
				targetRotation = Quaternion.LookRotation(base.transform.position - Yandere.transform.position);
				Yandere.transform.rotation = Quaternion.Slerp(Yandere.transform.rotation, targetRotation, Time.deltaTime * 10f);
				AimWeaponAtYandere();
				AimBodyAtYandere();
				Yandere.CanMove = false;
			}
			else if (Distance < MinDistance)
			{
				AimBodyAtYandere();
				if (Yandere.CanMove && !Yandere.Egg && !Shooting)
				{
					Shoot();
				}
			}
			else if (Distance < MidDistance)
			{
				PlayedSitSound = false;
				if (!StudentManager.Eighties)
				{
					if (!StudentManager.Clock.StopTime)
					{
						PatienceTimer -= Time.deltaTime;
					}
					if (PatienceTimer < 0f && !Yandere.Egg)
					{
						LostPatience = true;
						PatienceTimer = 60f;
						Patience = 0;
						Shoot();
					}
					if (!LostPatience)
					{
						LostPatience = true;
						Patience--;
						if (Patience < 1 && !Yandere.Egg && !Shooting)
						{
							Shoot();
						}
					}
					AimBodyAtYandere();
					Threatened = true;
					AimWeaponAtYandere();
				}
				ThreatTimer = Mathf.MoveTowards(ThreatTimer, 0f, Time.deltaTime);
				if (ThreatTimer == 0f)
				{
					ThreatID++;
					if (ThreatID < 6)
					{
						HeadmasterSubtitle.text = HeadmasterThreatText[ThreatID];
						MyAudio.clip = HeadmasterThreatClips[ThreatID];
						MyAudio.Play();
						ThreatTimer = HeadmasterThreatClips[ThreatID].length + 1f;
					}
				}
				CheckBehavior();
			}
			else if (Distance < MaxDistance)
			{
				PlayedStandSound = false;
				LostPatience = false;
				targetRotation = Quaternion.LookRotation(new Vector3(0f, 8f, 0f) - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, Time.deltaTime * 10f);
				Chair.localPosition = Vector3.Lerp(Chair.localPosition, new Vector3(Chair.localPosition.x, Chair.localPosition.y, -4.66666f), Time.deltaTime * 1f);
				LookAtPlayer = true;
				if (!Threatened)
				{
					if (StudentManager.Eighties && Yandere.transform.position.z < -32.63333f)
					{
						MyAnimation.CrossFade(IdleAnim, 1f);
						LookAtPlayer = false;
					}
					else
					{
						MyAnimation.CrossFade("HeadmasterAttention", 1f);
					}
					ScratchTimer = 0f;
					SpeechTimer = Mathf.MoveTowards(SpeechTimer, 0f, Time.deltaTime);
					if (SpeechTimer == 0f)
					{
						if (CardboardBox.parent != Yandere.Hips && Yandere.Mask == null)
						{
							VoiceID++;
							if (VoiceID < 6)
							{
								HeadmasterSubtitle.text = HeadmasterSpeechText[VoiceID];
								MyAudio.clip = HeadmasterSpeechClips[VoiceID];
								MyAudio.Play();
								SpeechTimer = HeadmasterSpeechClips[VoiceID].length + 1f;
							}
						}
						else
						{
							BoxID++;
							if (BoxID < 6)
							{
								HeadmasterSubtitle.text = HeadmasterBoxText[BoxID];
								MyAudio.clip = HeadmasterBoxClips[BoxID];
								MyAudio.Play();
								SpeechTimer = HeadmasterBoxClips[BoxID].length + 1f;
							}
						}
					}
				}
				else if (!Relaxing)
				{
					HeadmasterSubtitle.text = HeadmasterRelaxText;
					MyAudio.clip = HeadmasterRelaxClip;
					MyAudio.Play();
					Relaxing = true;
				}
				else
				{
					if (!PlayedSitSound)
					{
						AudioSource.PlayClipAtPoint(SitDown, base.transform.position);
						PlayedSitSound = true;
					}
					MyAnimation.CrossFade("HeadmasterLowerTazer");
					Aiming = false;
					if ((double)MyAnimation["HeadmasterLowerTazer"].time > 1.33333)
					{
						Tazer.SetActive(value: false);
					}
					if (MyAnimation["HeadmasterLowerTazer"].time > MyAnimation["HeadmasterLowerTazer"].length)
					{
						Threatened = false;
						Relaxing = false;
					}
				}
				CheckBehavior();
			}
			else
			{
				if (LookAtPlayer)
				{
					MyAnimation.CrossFade(IdleAnim);
					LookAtPlayer = false;
					Threatened = false;
					Relaxing = false;
					Aiming = false;
				}
				ScratchTimer += Time.deltaTime;
				if (ScratchTimer > 10f)
				{
					MyAnimation.CrossFade("HeadmasterScratch");
					if (MyAnimation["HeadmasterScratch"].time > MyAnimation["HeadmasterScratch"].length)
					{
						MyAnimation.CrossFade(IdleAnim);
						ScratchTimer = 0f;
					}
				}
			}
			if (!MyAudio.isPlaying)
			{
				HeadmasterSubtitle.text = string.Empty;
				if (Shooting)
				{
					Taze();
				}
			}
			if (Yandere.Attacked && Yandere.CharacterAnimation["f02_swingB_00"].time >= Yandere.CharacterAnimation["f02_swingB_00"].length * 0.85f)
			{
				MyAudio.clip = Crumple;
				MyAudio.Play();
				base.enabled = false;
			}
		}
		else
		{
			HeadmasterSubtitle.text = string.Empty;
		}
	}

	private void LateUpdate()
	{
		if (!(Distance < MaxDistance))
		{
			return;
		}
		LookAtTarget = Vector3.Lerp(LookAtTarget, LookAtPlayer ? Yandere.Head.position : Default.position, Time.deltaTime * 10f);
		Head.LookAt(LookAtTarget);
		if (EightiesAttacher.gameObject.activeInHierarchy && !Initialized)
		{
			EightiesAttacher.newRenderer.SetBlendShapeWeight(11, 100f);
			Initialized = true;
		}
		if (HeadmasterSubtitle.text != string.Empty)
		{
			LipTimer = Mathf.MoveTowards(LipTimer, 0f, Time.deltaTime);
			if (LipTimer == 0f)
			{
				JawRot = Random.Range(30f, 35f);
				LipTimer = 0.1f;
			}
			Jaw.transform.localEulerAngles = new Vector3(0f, 0f, JawRot);
		}
		else if (Time.timeScale > 0.1f)
		{
			Jaw.transform.localEulerAngles = new Vector3(0f, 0f, 30f);
		}
	}

	private void AimBodyAtYandere()
	{
		targetRotation = Quaternion.LookRotation(Yandere.transform.position - base.transform.position);
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, Time.deltaTime * 5f);
		Chair.localPosition = Vector3.Lerp(Chair.localPosition, new Vector3(Chair.localPosition.x, Chair.localPosition.y, -5.2f), Time.deltaTime * 1f);
	}

	private void AimWeaponAtYandere()
	{
		if (!Aiming)
		{
			Debug.Log("The headmaster is being told to raise his tazer.");
			MyAnimation.CrossFade("HeadmasterRaiseTazer");
			if (!PlayedStandSound)
			{
				AudioSource.PlayClipAtPoint(StandUp, base.transform.position);
				PlayedStandSound = true;
			}
			if ((double)MyAnimation["HeadmasterRaiseTazer"].time > 1.166666)
			{
				Tazer.SetActive(value: true);
				Aiming = true;
			}
		}
		else
		{
			Debug.Log("The headmaster is being told to aim his tazer.");
			if (MyAnimation["HeadmasterRaiseTazer"].time > MyAnimation["HeadmasterRaiseTazer"].length)
			{
				MyAnimation.CrossFade("HeadmasterAimTazer");
			}
		}
	}

	public void Shoot()
	{
		StudentManager.YandereDying = true;
		if (StudentManager.Clock.TimeSkip)
		{
			StudentManager.Clock.EndTimeSkip();
		}
		Yandere.StopAiming();
		Yandere.StopLaughing();
		Yandere.CharacterAnimation.CrossFade("f02_readyToFight_00");
		if (Patience < 1)
		{
			HeadmasterSubtitle.text = HeadmasterPatienceText;
			MyAudio.clip = HeadmasterPatienceClip;
		}
		else if (Yandere.Armed)
		{
			HeadmasterSubtitle.text = HeadmasterWeaponText;
			MyAudio.clip = HeadmasterWeaponClip;
		}
		else if (Yandere.Carrying || Yandere.Dragging || (Yandere.PickUp != null && (bool)Yandere.PickUp.BodyPart))
		{
			HeadmasterSubtitle.text = HeadmasterCorpseText;
			MyAudio.clip = HeadmasterCorpseClip;
		}
		else
		{
			HeadmasterSubtitle.text = HeadmasterAttackText;
			MyAudio.clip = HeadmasterAttackClip;
		}
		StudentManager.StopMoving();
		Yandere.EmptyHands();
		Yandere.CanMove = false;
		Yandere.Stance.Current = StanceType.Standing;
		MyAudio.Play();
		LookAtPlayer = true;
		Shooting = true;
	}

	private void CheckBehavior()
	{
		if (!Yandere.CanMove || Yandere.Egg)
		{
			return;
		}
		if (Yandere.Chased || Yandere.Chasers > 0)
		{
			if (!Shooting)
			{
				Shoot();
			}
		}
		else if (Yandere.Armed)
		{
			if (!Shooting)
			{
				Shoot();
			}
		}
		else if ((Yandere.Carrying || Yandere.Dragging || (Yandere.PickUp != null && (bool)Yandere.PickUp.BodyPart)) && !Shooting)
		{
			Shoot();
		}
	}

	public void Taze()
	{
		Debug.Log("The Headmaster's ''Taze'' function will run now.");
		if (Yandere.CanMove)
		{
			StudentManager.YandereDying = true;
			Yandere.StopAiming();
			Yandere.StopLaughing();
			StudentManager.StopMoving();
			Yandere.EmptyHands();
			Yandere.CanMove = false;
		}
		Object.Instantiate(LightningEffect, TazerEffectTarget.position, Quaternion.identity);
		Object.Instantiate(LightningEffect, Yandere.Spine[3].position, Quaternion.identity);
		MyAudio.clip = HeadmasterShockClip;
		MyAudio.Play();
		Yandere.CharacterAnimation.CrossFade("f02_swingB_00");
		Yandere.CharacterAnimation["f02_swingB_00"].time = 0.5f;
		Yandere.RPGCamera.enabled = false;
		Yandere.FakingReaction = false;
		Yandere.TargetStudent = null;
		Yandere.Attacked = true;
		Heartbroken.Headmaster = true;
		Jukebox.Volume = 0f;
		Shooting = false;
	}
}
