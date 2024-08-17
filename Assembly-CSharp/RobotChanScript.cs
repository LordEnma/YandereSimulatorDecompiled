using Pathfinding;
using UnityEngine;

public class RobotChanScript : MonoBehaviour
{
	public CharacterController MyController;

	public StudentScript TargetStudent;

	public GameObject OriginalRobot;

	public BodyPartScript BodyPart;

	public AudioClip ExplosionSFX;

	public AudioClip BloodSFX;

	public PromptScript Prompt;

	public AudioSource MyAudio;

	public AIPath Pathfinding;

	public Animation MyAnim;

	public string RandomAnim;

	public string IdleAnim;

	public string WalkAnim;

	public bool Hunting;

	public string[] AnimNames;

	public Quaternion targetRotation;

	public GameObject Explosion;

	public GameObject Blood;

	public Rigidbody Heart;

	public Animation TargetAnim;

	public Transform TargetHead;

	public Transform TargetNeck;

	public Transform MyHand;

	public Transform MyHead;

	public Transform EyeL;

	public Transform EyeR;

	public float RotationSpeed;

	public float HeadRotation;

	public float EyeRotation;

	public float AnimWeight;

	public float AnimTime;

	public float Speed;

	public string ImpaleAnim;

	public int ImpalePhase;

	public bool Impale;

	private void Start()
	{
		if (!GameGlobals.RobotComplete)
		{
			base.gameObject.SetActive(value: false);
			Prompt.enabled = false;
			Prompt.Hide();
		}
		else if (GameGlobals.RobotDestroyed)
		{
			OriginalRobot.SetActive(value: false);
			base.gameObject.SetActive(value: false);
			Prompt.enabled = false;
			Prompt.Hide();
		}
		else
		{
			OriginalRobot.SetActive(value: false);
		}
	}

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Circle[0].fillAmount = 1f;
			Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
			if (Prompt.Yandere.StudentManager.YandereVisible)
			{
				Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
				Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			else if (Prompt.Yandere.StudentManager.Students[65] != null && Vector3.Distance(Prompt.Yandere.transform.position, Prompt.Yandere.StudentManager.Students[65].transform.position) < 5f)
			{
				Prompt.Yandere.NotificationManager.CustomText = "...while Homu is nearby!";
				Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				Prompt.Yandere.NotificationManager.CustomText = "You can't interact with that...";
				Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			else
			{
				Prompt.Yandere.PauseScreen.StudentInfoMenu.RobotTargeting = true;
				Prompt.Yandere.PauseScreen.StudentInfoMenu.gameObject.SetActive(value: true);
				Prompt.Yandere.PauseScreen.StudentInfoMenu.Column = 0;
				Prompt.Yandere.PauseScreen.StudentInfoMenu.Row = 0;
				Prompt.Yandere.PauseScreen.StudentInfoMenu.UpdateHighlight();
				Prompt.StartCoroutine(Prompt.Yandere.PauseScreen.StudentInfoMenu.UpdatePortraits());
				Prompt.Yandere.PauseScreen.MainMenu.SetActive(value: false);
				Prompt.Yandere.PauseScreen.Panel.enabled = true;
				Prompt.Yandere.PauseScreen.Sideways = true;
				Prompt.Yandere.PauseScreen.Show = true;
				Time.timeScale = 0.0001f;
				Prompt.Yandere.PromptBar.ClearButtons();
				Prompt.Yandere.PromptBar.Label[1].text = "Cancel";
				Prompt.Yandere.PromptBar.UpdateButtons();
				Prompt.Yandere.PromptBar.Show = true;
			}
		}
		MyAudio.pitch = Time.timeScale;
		if (Hunting)
		{
			UpdateHunting();
		}
		else
		{
			if (ImpalePhase != 0)
			{
				return;
			}
			if (Prompt.Yandere.StudentManager.Students[65] != null && Prompt.Yandere.StudentManager.Students[65].Routine && Vector3.Distance(base.transform.position, Prompt.Yandere.StudentManager.Students[65].transform.position) < 1.1f)
			{
				MyAnim.CrossFade(RandomAnim);
				if (MyAnim[RandomAnim].time >= MyAnim[RandomAnim].length)
				{
					PickRandomAnim();
				}
				if (base.transform.eulerAngles.y > 91f)
				{
					base.transform.eulerAngles = Vector3.Lerp(base.transform.eulerAngles, new Vector3(0f, 90f, 0f), Time.deltaTime * 360f);
				}
			}
			else
			{
				MyAnim.CrossFade(IdleAnim);
				if (base.transform.eulerAngles.y < 179f)
				{
					base.transform.eulerAngles = Vector3.Lerp(base.transform.eulerAngles, new Vector3(0f, 180f, 0f), Time.deltaTime * 360f);
				}
			}
		}
	}

	public void PickRandomAnim()
	{
		RandomAnim = AnimNames[Random.Range(0, AnimNames.Length)];
	}

	public void GoCommitMurder()
	{
		if (TargetStudent.Male)
		{
			ImpaleAnim = "robotKillB_00";
		}
		else
		{
			ImpaleAnim = "f02_robotKillB_00";
		}
		Pathfinding.target = TargetStudent.transform;
		Pathfinding.canSearch = true;
		Pathfinding.canMove = true;
		MyAnim.CrossFade(WalkAnim);
		Prompt.enabled = false;
		Prompt.Hide();
		MyAudio.Play();
		Hunting = true;
	}

	private void UpdateHunting()
	{
		if (ImpalePhase > 4)
		{
			return;
		}
		if (Vector3.Distance(base.transform.position, TargetStudent.transform.position) > 1f)
		{
			if (!MyAudio.isPlaying)
			{
				MyAnim.CrossFade("f02_properWalk_00");
				Pathfinding.canSearch = true;
				Pathfinding.canMove = true;
				MyAudio.Play();
			}
			if (TargetStudent.Dying || TargetStudent.Struggling || TargetStudent.Ragdoll.enabled || TargetStudent.Tranquil || TargetStudent.PinningDown || (TargetStudent.Hunter != null && TargetStudent.Hunter != this))
			{
				Hunting = false;
				SelfDestruct();
			}
			return;
		}
		if (TargetStudent.ClubActivityPhase >= 16 || TargetStudent.Shoving || TargetStudent.ChangingShoes || TargetStudent.Chasing || Prompt.Yandere.Pursuer == TargetStudent || TargetStudent.SeekingMedicine || TargetStudent.EndSearch || TargetStudent.Talking || TargetStudent.InEvent || (Prompt.Yandere.StudentManager.CombatMinigame.Delinquent == TargetStudent && Prompt.Yandere.StudentManager.CombatMinigame.Path == 5) || !TargetStudent.enabled || TargetStudent.BreakingUpFight || (TargetStudent.Cheer != null && TargetStudent.Cheer.enabled))
		{
			MyAnim.CrossFade(IdleAnim);
			Pathfinding.canSearch = false;
			Pathfinding.canMove = false;
			MyAudio.Stop();
			return;
		}
		MyController.enabled = false;
		Pathfinding.canSearch = false;
		Pathfinding.canMove = false;
		targetRotation = Quaternion.LookRotation(TargetStudent.transform.position - base.transform.position);
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, Time.deltaTime * 10f);
		TargetStudent.targetRotation = Quaternion.LookRotation(base.transform.position - TargetStudent.transform.position);
		TargetStudent.transform.rotation = Quaternion.Slerp(TargetStudent.transform.rotation, TargetStudent.targetRotation, Time.deltaTime * 10f);
		TargetStudent.MoveTowardsTarget(base.transform.position + base.transform.forward * 0.4f);
		Animation characterAnimation = TargetStudent.CharacterAnimation;
		if (ImpalePhase == 0)
		{
			Debug.Log("ImpalePhase 0 fired.");
			TargetStudent.MurderSuicidePhase = 100;
			TargetStudent.SpawnAlarmDisc();
			TargetStudent.MurderSuicidePhase = 0;
			TargetStudent.SmartPhone.SetActive(value: false);
			TargetStudent.EmptyHands();
			TargetStudent.Prompt.Hide();
			TargetStudent.Prompt.enabled = false;
			TargetStudent.TargetedForDistraction = false;
			TargetStudent.Pathfinding.canSearch = false;
			TargetStudent.Pathfinding.canMove = false;
			TargetStudent.WitnessCamera.Show = false;
			TargetStudent.CameraReacting = false;
			TargetStudent.FocusOnStudent = false;
			TargetStudent.FocusOnYandere = false;
			TargetStudent.Investigating = false;
			TargetStudent.Distracting = false;
			TargetStudent.SentHome = false;
			TargetStudent.Splashed = false;
			TargetStudent.Alarmed = false;
			TargetStudent.Burning = false;
			TargetStudent.Fleeing = false;
			TargetStudent.Routine = false;
			TargetStudent.Shoving = false;
			TargetStudent.Tripped = false;
			TargetStudent.Blind = true;
			TargetStudent.Wet = false;
			MyAnim.CrossFade("f02_robotKillA_00");
			characterAnimation.CrossFade(ImpaleAnim);
			MyAudio.Stop();
			ImpalePhase++;
		}
		else if (ImpalePhase == 1)
		{
			if (MyAnim["f02_robotKillA_00"].time > 3.833333f)
			{
				TargetStudent.Police.CorpseList[TargetStudent.Police.Corpses] = TargetStudent.Ragdoll;
				TargetStudent.Police.Corpses++;
				TargetStudent.MyController.radius = 0.2f;
				GameObjectUtils.SetLayerRecursively(TargetStudent.gameObject, 11);
				TargetStudent.MapMarker.gameObject.layer = 10;
				TargetStudent.tag = "Blood";
				TargetStudent.Ragdoll.RobotDeath = true;
				TargetStudent.Ragdoll.Disturbing = true;
				TargetStudent.Dying = true;
				Object.Instantiate(Blood, MyHand.position, Quaternion.identity);
				BodyPart.StudentID = TargetStudent.StudentID;
				Heart.gameObject.SetActive(value: true);
				MyAudio.clip = BloodSFX;
				MyAudio.loop = false;
				MyAudio.Play();
				ImpalePhase++;
			}
		}
		else if (ImpalePhase == 2)
		{
			if (MyAnim["f02_robotKillA_00"].time > 6f)
			{
				Object.Instantiate(Blood, MyHand.position, Quaternion.identity);
				BodyPart.StudentID = TargetStudent.StudentID;
				MyAudio.Play();
				ImpalePhase++;
			}
		}
		else if (ImpalePhase == 3)
		{
			if (MyAnim["f02_robotKillA_00"].time > 14f)
			{
				Object.Instantiate(Explosion, MyHead.position, Quaternion.identity);
				MyAudio.clip = ExplosionSFX;
				MyAudio.Play();
				MyHead.localScale = new Vector3(0f, 0f, 0f);
				ImpalePhase++;
			}
		}
		else if (ImpalePhase == 4 && MyAnim["f02_robotKillA_00"].time > 17.5f)
		{
			Prompt.Yandere.StudentManager.RobotDestroyed = true;
			TargetStudent.Ragdoll.BurningAnimation = false;
			TargetStudent.DeathType = DeathType.Weapon;
			TargetStudent.Hunted = false;
			TargetStudent.BecomeRagdoll();
			Prompt.Yandere.Police.RobotMurder = true;
			Heart.transform.parent = TargetStudent.StudentManager.BloodParent.transform;
			Heart.isKinematic = false;
			Heart.useGravity = true;
			BodyPart.Prompt.enabled = true;
			ImpalePhase++;
		}
	}

	private void LateUpdate()
	{
		if (ImpalePhase > 3)
		{
			MyHead.localScale = new Vector3(0f, 0f, 0f);
		}
	}

	private void SelfDestruct()
	{
		Object.Instantiate(Explosion, MyHead.position, Quaternion.identity);
		Prompt.Yandere.StudentManager.RobotDestroyed = true;
		MyHead.localScale = new Vector3(0f, 0f, 0f);
		MyAnim["f02_fallBack_00"].weight = 1f;
		MyAnim["f02_fallBack_00"].speed = 1f;
		MyAnim["f02_fallBack_00"].time = 0f;
		MyAnim.Play("f02_fallBack_00");
		RotationSpeed = 0f;
		ImpalePhase = 6;
		Pathfinding.canSearch = false;
		Pathfinding.canMove = false;
		MyAudio.clip = ExplosionSFX;
		MyAudio.loop = false;
		MyAudio.Play();
		Hunting = false;
	}
}
