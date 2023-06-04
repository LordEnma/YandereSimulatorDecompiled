using Pathfinding;
using UnityEngine;

public class JournalistScript : MonoBehaviour
{
	public GenericRivalEventScript RivalEvent;

	public ParticleSystem PepperSprayEffect;

	public CharacterController MyController;

	public RagdollScript Corpse;

	public float DistanceToDestination;

	public float DistanceToPlayer;

	public float SpeechTimer;

	public float ThreatTimer;

	public float ChaseTimer;

	public float Timer;

	public Quaternion targetRotation;

	public AudioClip PepperSpraySFX;

	public AudioClip ChaseVoice;

	public Transform[] Destinations;

	public AudioClip[] SpeechClips;

	public AudioClip[] ThreatClips;

	public string[] SpeechLines;

	public string[] ThreatLines;

	public SubtitleScript Subtitle;

	public YandereScript Yandere;

	public GameObject PepperSpray;

	public GameObject Face;

	public Animation MyAnimation;

	public Transform LookTarget;

	public AIPath Pathfinding;

	public float FreezeTimer;

	public float WaitTimer;

	public bool AwareOfMurder;

	public bool Waiting;

	public bool Chasing;

	public bool Freeze;

	public bool Flee;

	public int SpeechID;

	public int ThreatID;

	public Transform Head;

	public LayerMask Mask;

	private void Start()
	{
		if (!GameGlobals.Eighties || GameGlobals.EightiesTutorial || DateGlobals.Week > 10)
		{
			base.gameObject.SetActive(value: false);
		}
		else
		{
			Pathfinding.target = Destinations[0];
		}
		MyAnimation.CrossFade("crossarms_00");
		Pathfinding.canSearch = false;
		Pathfinding.canMove = false;
		PepperSpray.SetActive(value: false);
	}

	private void Update()
	{
		DistanceToDestination = Vector3.Distance(base.transform.position, Pathfinding.target.position);
		DistanceToPlayer = Vector3.Distance(base.transform.position, Yandere.transform.position);
		if (Waiting)
		{
			if (DistanceToPlayer < 5f)
			{
				SpeechCheck();
			}
			WaitTimer += Time.deltaTime;
			if (WaitTimer > 5f && (RivalEvent == null || Yandere.Armed))
			{
				Pathfinding.canSearch = true;
				Pathfinding.canMove = true;
				Waiting = false;
			}
			return;
		}
		if (Flee)
		{
			if (DistanceToDestination < 2.2f)
			{
				Yandere.StudentManager.Police.Show = true;
				base.gameObject.SetActive(value: false);
			}
			return;
		}
		if (Freeze)
		{
			MyAnimation.CrossFade("readyToFight_00");
			Pathfinding.canSearch = false;
			Pathfinding.canMove = false;
			if (AwareOfMurder)
			{
				return;
			}
			if (Corpse != null)
			{
				FreezeTimer += Time.deltaTime;
				targetRotation = Quaternion.LookRotation(new Vector3(Corpse.Student.Hips.position.x, base.transform.position.y, Corpse.Student.Hips.position.z) - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
				if (FreezeTimer > 5f)
				{
					RunAway();
				}
			}
			else
			{
				targetRotation = Quaternion.LookRotation(Yandere.StudentManager.MindBrokenSlave.transform.position - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
				if (!Yandere.StudentManager.MindBrokenSlave.Alive)
				{
					RunAway();
				}
			}
			return;
		}
		if (!Chasing)
		{
			if ((Yandere.transform.position.z < -50f && Yandere.Attacking) || AwareOfMurder)
			{
				Debug.Log("Journo is aware of murder.");
				Yandere.RunSpeed = 0f;
				AwareOfMurder = true;
				if (DistanceToPlayer > 1f)
				{
					Debug.Log("Journo is runnin'...");
					MyAnimation.CrossFade("sprint_00");
					base.transform.LookAt(Yandere.transform.position);
					MyController.Move(base.transform.forward * Time.deltaTime * 5f);
				}
				else
				{
					Debug.Log("Journo is close enough, he can stop now.");
					MyAnimation.CrossFade("readyToFight_00");
					if (!Yandere.Attacking)
					{
						Chase();
					}
				}
				if ((DistanceToPlayer < 15f && CanSeeYandere()) || (DistanceToPlayer < 5f && AwareOfMurder))
				{
					CheckBehavior();
				}
			}
			else
			{
				if (Yandere.transform.position.z < -50f && Yandere.transform.position.z > -75f)
				{
					Pathfinding.target = Yandere.transform;
				}
				else if (Pathfinding.target == Yandere.transform)
				{
					Pathfinding.target = Destinations[0];
				}
				if (DistanceToPlayer < 5f && CanSeeYandere())
				{
					MyAnimation.CrossFade("idleTough_00");
					Pathfinding.canSearch = false;
					Pathfinding.canMove = false;
					targetRotation = Quaternion.LookRotation(Yandere.transform.position - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
					SpeechCheck();
				}
				else if (Yandere.transform.position.z < -50f && DistanceToPlayer < 10f)
				{
					MyAnimation.CrossFade("idleTough_00");
					Pathfinding.canSearch = false;
					Pathfinding.canMove = false;
					targetRotation = Quaternion.LookRotation(Yandere.transform.position - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
				}
				else if (DistanceToDestination < 1f)
				{
					MyAnimation.CrossFade("leaning_00");
					Pathfinding.canSearch = false;
					Pathfinding.canMove = false;
					targetRotation = Quaternion.LookRotation(LookTarget.position - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
					Timer += Time.deltaTime;
					if (Timer > 5f)
					{
						if (Pathfinding.target != Destinations[1])
						{
							Pathfinding.target = Destinations[1];
						}
						else
						{
							Pathfinding.target = Destinations[2];
						}
						Timer = 0f;
					}
				}
				else
				{
					MyAnimation.CrossFade("walkTough_00");
					Pathfinding.canSearch = true;
					Pathfinding.canMove = true;
				}
			}
			if ((DistanceToPlayer < 15f && CanSeeYandere()) || (DistanceToPlayer < 5f && AwareOfMurder))
			{
				CheckBehavior();
			}
			if (Chasing || AwareOfMurder)
			{
				return;
			}
			if (Yandere.StudentManager.MurderTakingPlace)
			{
				Debug.Log("Journalist acknowledges that a mind-broken slave murder is walking around..");
				if (Yandere.StudentManager.MindBrokenSlave.MurderSuicidePhase > 1 && Vector3.Distance(base.transform.position, Yandere.StudentManager.MindBrokenSlave.transform.position) < 10f)
				{
					Debug.Log("A mind-broken murder is taking place within 10 meters of the Journalist!");
					Freeze = true;
				}
			}
			else
			{
				if (Yandere.StudentManager.Police.Corpses <= 0)
				{
					return;
				}
				for (int i = 0; i < Yandere.StudentManager.Police.Corpses; i++)
				{
					if (Yandere.StudentManager.Police.CorpseList[i] != null && !Yandere.StudentManager.Police.CorpseList[i].Concealed && Vector3.Distance(base.transform.position, Yandere.StudentManager.Police.CorpseList[i].transform.position) < 10f)
					{
						Corpse = Yandere.StudentManager.Police.CorpseList[i];
						Freeze = true;
					}
				}
			}
			return;
		}
		if (Yandere.TimeSkipping)
		{
			Yandere.StudentManager.Clock.EndTimeSkip();
			Yandere.CanMoveTimer = 0f;
		}
		Yandere.CanMove = false;
		targetRotation = Quaternion.LookRotation(base.transform.position - Yandere.transform.position);
		Yandere.transform.rotation = Quaternion.Slerp(Yandere.transform.rotation, targetRotation, 10f * Time.deltaTime);
		ChaseTimer += Time.deltaTime;
		if (ChaseTimer > 1f)
		{
			if (DistanceToPlayer > 1f)
			{
				MyAnimation.CrossFade("sprint_00");
				Pathfinding.canSearch = true;
				Pathfinding.canMove = true;
				Pathfinding.speed = 5f;
				return;
			}
			if (Yandere.Noticed)
			{
				MyAnimation.CrossFade("readyToFight_00");
				Pathfinding.canSearch = false;
				Pathfinding.canMove = false;
				Pathfinding.speed = 0f;
				base.enabled = false;
				return;
			}
			if (!Yandere.Sprayed)
			{
				AudioSource.PlayClipAtPoint(PepperSpraySFX, base.transform.position);
			}
			targetRotation = Quaternion.LookRotation(Yandere.transform.position - base.transform.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
			Yandere.CharacterAnimation.CrossFade("f02_sprayed_00");
			Yandere.SprayedByJournalist = true;
			Yandere.YandereVision = false;
			Yandere.NearSenpai = false;
			Yandere.Attacking = false;
			Yandere.FollowHips = true;
			Yandere.Punching = false;
			Yandere.CanMove = false;
			Yandere.Sprayed = true;
			Yandere.StudentManager.YandereDying = true;
			Yandere.StudentManager.StopMoving();
			Yandere.Jukebox.Volume = 0f;
			Yandere.Blur.Size = 1f;
			if (Yandere.DelinquentFighting)
			{
				Yandere.StudentManager.CombatMinigame.Stop();
			}
			MyAnimation.CrossFade("spray_00");
			Pathfinding.canSearch = false;
			Pathfinding.canMove = false;
			Pathfinding.speed = 0f;
			PepperSpray.SetActive(value: true);
			if ((double)MyAnimation["spray_00"].time > 0.66666)
			{
				PepperSprayEffect.Play();
				if (Yandere.Armed)
				{
					Yandere.EquippedWeapon.Drop();
				}
				Yandere.EmptyHands();
				base.enabled = false;
			}
		}
		else
		{
			targetRotation = Quaternion.LookRotation(Yandere.transform.position - base.transform.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
		}
	}

	private void CheckBehavior()
	{
		if (Yandere.CanMove && !Yandere.Egg && !Yandere.Invisible && (Yandere.Chased || Yandere.Chasers > 0 || Yandere.MurderousActionTimer > 0f || Yandere.PotentiallyMurderousTimer > 0f || (Yandere.Armed && Yandere.EquippedWeapon.Bloody) || (Yandere.Carrying && !Yandere.CurrentRagdoll.Concealed) || (Yandere.Dragging && !Yandere.CurrentRagdoll.Concealed) || (Yandere.Bloodiness + (float)Yandere.GloveBlood > 0f && !Yandere.Paint && Yandere.MyProjector.enabled) || (Yandere.PickUp != null && (bool)Yandere.PickUp.BodyPart && !Yandere.PickUp.Garbage)))
		{
			if (Yandere.Carrying)
			{
				Debug.Log("Yandere.CurrentRagdoll.Concealed is: " + Yandere.CurrentRagdoll.Concealed);
			}
			Chase();
		}
	}

	public bool CanSeeYandere()
	{
		if (!Yandere.Egg)
		{
			Vector3 position = Head.position;
			Vector3 end = new Vector3(Yandere.transform.position.x, Yandere.Head.position.y, Yandere.transform.position.z);
			if (Physics.Linecast(position, end, out var hitInfo, Mask) && hitInfo.collider.gameObject == Yandere.gameObject)
			{
				return true;
			}
		}
		return false;
	}

	private void Chase()
	{
		Face.name = "RENAMED";
		Subtitle.PreviousSubtitle = SubtitleType.AcceptFood;
		AudioSource.PlayClipAtPoint(ChaseVoice, Yandere.MainCamera.transform.position);
		Subtitle.CustomText = "I knew it was you!";
		Subtitle.UpdateLabel(SubtitleType.Custom, 0, 4f);
		MyAnimation.CrossFade("readyToFight_00");
		if (Yandere.Laughing)
		{
			Yandere.StopLaughing();
		}
		Yandere.CharacterAnimation.CrossFade("f02_readyToFight_00");
		Yandere.CanMove = false;
		Pathfinding.target = Yandere.transform;
		Pathfinding.canSearch = false;
		Pathfinding.canMove = false;
		if (Yandere.Carrying)
		{
			Yandere.EmptyHands();
		}
		Waiting = false;
		Chasing = true;
	}

	private void RunAway()
	{
		Pathfinding.target = Yandere.StudentManager.Exit;
		MyAnimation.CrossFade("sprint_00");
		Pathfinding.canSearch = true;
		Pathfinding.canMove = true;
		Pathfinding.speed = 5f;
		Flee = true;
	}

	private void SpeechCheck()
	{
		if (AwareOfMurder)
		{
			return;
		}
		if (DistanceToPlayer > 1f)
		{
			SpeechTimer -= Time.deltaTime;
			if (SpeechTimer <= 0f && SpeechID < SpeechLines.Length)
			{
				AudioSource.PlayClipAtPoint(SpeechClips[SpeechID], base.transform.position);
				if (Subtitle.EventSubtitle.text == "" || Subtitle.EventSubtitle.transform.localScale.x < 1f)
				{
					Subtitle.CustomText = SpeechLines[SpeechID];
					Subtitle.UpdateLabel(SubtitleType.Custom, 0, 4f);
				}
				SpeechTimer = 5f;
				SpeechID++;
			}
			return;
		}
		ThreatTimer -= Time.deltaTime;
		if (ThreatTimer <= 0f && ThreatID < ThreatLines.Length)
		{
			AudioSource.PlayClipAtPoint(ThreatClips[ThreatID], base.transform.position);
			if (Subtitle.EventSubtitle.text == "" || Subtitle.EventSubtitle.transform.localScale.x < 1f)
			{
				Subtitle.PreviousSubtitle = SubtitleType.AcceptFood;
				Subtitle.CustomText = ThreatLines[ThreatID];
				Subtitle.UpdateLabel(SubtitleType.Custom, 0, 4f);
			}
			ThreatTimer = 5f;
			ThreatID++;
		}
		if (Yandere.Armed)
		{
			Chase();
		}
	}
}
