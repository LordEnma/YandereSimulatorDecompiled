using Pathfinding;
using UnityEngine;

public class RobotChanScript : MonoBehaviour
{
	public CharacterController MyController;

	public StudentScript TargetStudent;

	public GameObject OriginalRobot;

	public AudioClip ExplosionSFX;

	public AudioClip BloodSFX;

	public PromptScript Prompt;

	public AudioSource MyAudio;

	public AIPath Pathfinding;

	public Animation MyAnim;

	public string RandomAnim;

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
		else if (Prompt.Yandere.StudentManager.Students[65] != null && Prompt.Yandere.StudentManager.Students[65].Routine && Vector3.Distance(base.transform.position, Prompt.Yandere.StudentManager.Students[65].transform.position) < 1.1f)
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
			MyAnim.CrossFade("f02_properIdle_00");
			if (base.transform.eulerAngles.y < 179f)
			{
				base.transform.eulerAngles = Vector3.Lerp(base.transform.eulerAngles, new Vector3(0f, 180f, 0f), Time.deltaTime * 360f);
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
			ImpaleAnim = "snapImpaleB_00";
		}
		else
		{
			ImpaleAnim = "f02_snapImpaleB_00";
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
		float num = Vector3.Distance(base.transform.position, TargetStudent.transform.position);
		if (ImpalePhase == 7)
		{
			MyAnim["f02_snapImpaleA_00"].weight -= Time.deltaTime;
		}
		else
		{
			if (!TargetStudent.Alive || TargetStudent.Tranquil || TargetStudent.PinningDown)
			{
				return;
			}
			if (num > 1f)
			{
				if (TargetStudent.Dying || TargetStudent.Struggling || TargetStudent.Ragdoll.enabled || (TargetStudent.Hunter != null && TargetStudent.Hunter != this))
				{
					Hunting = false;
					SelfDestruct();
				}
				return;
			}
			if (TargetStudent.ClubActivityPhase >= 16 || TargetStudent.Shoving || TargetStudent.ChangingShoes || TargetStudent.Chasing || Prompt.Yandere.Pursuer == TargetStudent || TargetStudent.SeekingMedicine || TargetStudent.EndSearch || (Prompt.Yandere.StudentManager.CombatMinigame.Delinquent == TargetStudent && Prompt.Yandere.StudentManager.CombatMinigame.Path == 5) || !TargetStudent.enabled || TargetStudent.BreakingUpFight || (TargetStudent.Cheer != null && TargetStudent.Cheer.enabled))
			{
				MyAnim.CrossFade("f02_properIdle_00");
				Pathfinding.canSearch = false;
				Pathfinding.canMove = false;
				return;
			}
			MyController.enabled = false;
			Pathfinding.canSearch = false;
			Pathfinding.canMove = false;
			targetRotation = Quaternion.LookRotation(TargetStudent.transform.position - base.transform.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, Time.deltaTime * 10f);
			TargetStudent.targetRotation = Quaternion.LookRotation(base.transform.position - TargetStudent.transform.position);
			TargetStudent.transform.rotation = Quaternion.Slerp(TargetStudent.transform.rotation, TargetStudent.targetRotation, Time.deltaTime * 10f);
			TargetStudent.MoveTowardsTarget(base.transform.position + base.transform.forward * 0.3f);
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
				MyAnim.CrossFade("f02_properIdle_00");
				characterAnimation.CrossFade(TargetStudent.IdleAnim);
				characterAnimation[ImpaleAnim].layer = 1;
				MyAnim["f02_snapImpaleA_00"].layer = 1;
				characterAnimation[ImpaleAnim].speed = 0f;
				MyAnim["f02_snapImpaleA_00"].speed = 0f;
				characterAnimation[ImpaleAnim].time = 0f;
				MyAnim["f02_snapImpaleA_00"].time = 0f;
				characterAnimation[ImpaleAnim].weight = 0f;
				MyAnim["f02_snapImpaleA_00"].weight = 0f;
				characterAnimation.CrossFade(ImpaleAnim);
				MyAnim.CrossFade("f02_snapImpaleA_00");
				MyAudio.Stop();
				ImpalePhase++;
			}
			else if (ImpalePhase == 1)
			{
				Speed += Time.deltaTime;
				AnimWeight = Mathf.Lerp(AnimWeight, 1f, Time.deltaTime * Speed);
				characterAnimation[ImpaleAnim].weight = AnimWeight;
				MyAnim["f02_snapImpaleA_00"].weight = AnimWeight;
				if (AnimWeight > 0.99f)
				{
					ImpalePhase++;
					Speed = 0f;
				}
			}
			else if (ImpalePhase == 2)
			{
				Speed += Time.deltaTime * 2f;
				AnimTime = Mathf.Lerp(AnimTime, MyAnim["f02_snapImpaleA_00"].length, Time.deltaTime * Speed);
				characterAnimation[ImpaleAnim].time = AnimTime;
				MyAnim["f02_snapImpaleA_00"].time = AnimTime;
				if (Speed > 1.5f && !Heart.gameObject.activeInHierarchy)
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
					Heart.gameObject.SetActive(value: true);
					MyAudio.clip = BloodSFX;
					MyAudio.loop = false;
					MyAudio.Play();
				}
				if (AnimTime >= MyAnim["f02_snapImpaleA_00"].length * 0.99f)
				{
					characterAnimation[ImpaleAnim].speed = -0.02f;
					MyAnim["f02_snapImpaleA_00"].speed = -0.02f;
					ImpalePhase++;
				}
			}
			else if (ImpalePhase == 3)
			{
				RotationSpeed += Time.deltaTime;
				HeadRotation = Mathf.Lerp(HeadRotation, 30f, Time.deltaTime * RotationSpeed);
				EyeRotation = Mathf.Lerp(EyeRotation, 30f, Time.deltaTime * RotationSpeed);
				if (RotationSpeed > 3f)
				{
					RotationSpeed = 0f;
					ImpalePhase++;
				}
			}
			else if (ImpalePhase == 4)
			{
				RotationSpeed += Time.deltaTime;
				HeadRotation = Mathf.Lerp(HeadRotation, 22.5f, Time.deltaTime * RotationSpeed);
				EyeRotation = Mathf.Lerp(EyeRotation, 15f, Time.deltaTime * RotationSpeed);
				if (RotationSpeed > 3f)
				{
					RotationSpeed = 0f;
					ImpalePhase++;
				}
			}
			else if (ImpalePhase == 5)
			{
				RotationSpeed += Time.deltaTime;
				if (RotationSpeed > 3f)
				{
					Object.Instantiate(Explosion, MyHead.position, Quaternion.identity);
					MyAudio.clip = ExplosionSFX;
					MyAudio.Play();
					MyHead.localScale = new Vector3(0f, 0f, 0f);
					RotationSpeed = 0f;
					ImpalePhase++;
				}
			}
			else if (ImpalePhase == 6)
			{
				RotationSpeed += Time.deltaTime;
				if (RotationSpeed > 3f)
				{
					Prompt.Yandere.StudentManager.RobotDestroyed = true;
					TargetStudent.Ragdoll.BurningAnimation = false;
					TargetStudent.DeathType = DeathType.Mystery;
					TargetStudent.BecomeRagdoll();
					Prompt.Yandere.Police.RobotMurder = true;
					MyAnim.CrossFade("f02_fallBack_00");
					Heart.transform.parent = null;
					Heart.isKinematic = false;
					Heart.useGravity = true;
					RotationSpeed = 0f;
					ImpalePhase++;
				}
			}
		}
	}

	private void LateUpdate()
	{
		if (ImpalePhase > 0)
		{
			if (ImpalePhase < 7)
			{
				TargetStudent.Neck.localEulerAngles += new Vector3(HeadRotation, 0f, 0f);
				TargetStudent.Head.localEulerAngles += new Vector3(HeadRotation, 0f, 0f);
				TargetStudent.RightEye.localEulerAngles -= new Vector3(EyeRotation * 0.66666f, 0f, 0f);
				TargetStudent.LeftEye.localEulerAngles += new Vector3(EyeRotation * 0.66666f, 0f, 0f);
			}
			if (ImpalePhase == 5)
			{
				MyHead.localEulerAngles = new Vector3(Random.Range(RotationSpeed * 5f, RotationSpeed * -5f), Random.Range(RotationSpeed * 5f, RotationSpeed * -5f), Random.Range(RotationSpeed * 5f, RotationSpeed * -5f));
			}
			else if (ImpalePhase > 5)
			{
				MyHead.localScale = new Vector3(0f, 0f, 0f);
			}
		}
	}

	private void SelfDestruct()
	{
		Object.Instantiate(Explosion, MyHead.position, Quaternion.identity);
		Prompt.Yandere.StudentManager.RobotDestroyed = true;
		MyHead.localScale = new Vector3(0f, 0f, 0f);
		MyAnim.CrossFade("f02_fallBack_00");
		RotationSpeed = 0f;
		ImpalePhase = 7;
		MyAudio.clip = ExplosionSFX;
		MyAudio.Play();
	}
}
