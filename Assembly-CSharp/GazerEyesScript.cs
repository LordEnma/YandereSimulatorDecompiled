using UnityEngine;

public class GazerEyesScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public YandereScript Yandere;

	public GameObject FemaleBloodyScream;

	public GameObject MaleBloodyScream;

	public GameObject ParticleEffect;

	public GameObject Laser;

	public SkinnedMeshRenderer[] Eyes;

	public float[] BlinkStrength;

	public Texture[] EyeTextures;

	public bool[] Blink;

	public float RandomNumber;

	public float AnimTime;

	public bool Attacking;

	public int Effect;

	public int ID;

	public bool Shinigami;

	private void Start()
	{
		GetComponent<Animation>()["Eyeballs_Run"].speed = 0f;
		GetComponent<Animation>()["Eyeballs_Walk"].speed = 0f;
		GetComponent<Animation>()["Eyeballs_Idle"].speed = 0f;
	}

	private void Update()
	{
		StudentManager.UpdateStudents();
		if (!Attacking)
		{
			AnimTime += Time.deltaTime;
			if (AnimTime > 144f)
			{
				AnimTime = 0f;
			}
		}
		else if (AnimTime < 72f)
		{
			AnimTime = Mathf.Lerp(AnimTime, 0f, Time.deltaTime * 1.44f * 5f);
		}
		else
		{
			AnimTime = Mathf.Lerp(AnimTime, 144f, Time.deltaTime * 1.44f * 5f);
		}
		GetComponent<Animation>()["Eyeballs_Run"].time = AnimTime;
		GetComponent<Animation>()["Eyeballs_Walk"].time = AnimTime;
		GetComponent<Animation>()["Eyeballs_Idle"].time = AnimTime;
		for (ID = 0; ID < Eyes.Length; ID++)
		{
			if (BlinkStrength[ID] == 0f)
			{
				RandomNumber = Random.Range(1, 101);
			}
			if (RandomNumber == 1f)
			{
				Blink[ID] = true;
			}
			if (Blink[ID])
			{
				BlinkStrength[ID] = Mathf.MoveTowards(BlinkStrength[ID], 100f, Time.deltaTime * 1000f);
				Eyes[ID].SetBlendShapeWeight(0, BlinkStrength[ID]);
				if (BlinkStrength[ID] == 100f)
				{
					Blink[ID] = false;
				}
			}
			else if (BlinkStrength[ID] > 0f)
			{
				BlinkStrength[ID] = Mathf.MoveTowards(BlinkStrength[ID], 0f, Time.deltaTime * 1000f);
				Eyes[ID].SetBlendShapeWeight(0, BlinkStrength[ID]);
			}
		}
		float axis = Input.GetAxis("Vertical");
		float axis2 = Input.GetAxis("Horizontal");
		if (!Yandere.CanMove)
		{
			return;
		}
		if (axis != 0f || axis2 != 0f)
		{
			if (Input.GetButton(InputNames.Xbox_LB))
			{
				GetComponent<Animation>().CrossFade("Eyeballs_Run", 1f);
			}
			else
			{
				GetComponent<Animation>().CrossFade("Eyeballs_Walk", 1f);
			}
		}
		else
		{
			GetComponent<Animation>().CrossFade("Eyeballs_Idle", 1f);
		}
	}

	public void ChangeEffect()
	{
		Effect++;
		if (Effect == EyeTextures.Length)
		{
			Effect = 0;
		}
		for (ID = 0; ID < Eyes.Length; ID++)
		{
			Object.Instantiate(ParticleEffect, Eyes[ID].transform.position, Quaternion.identity);
			Eyes[ID].material.mainTexture = EyeTextures[Effect];
		}
	}

	public void Attack()
	{
		if (!Shinigami)
		{
			for (ID = 0; ID < Eyes.Length; ID++)
			{
				GameObject obj = Object.Instantiate(Laser, Eyes[ID].transform.position, Quaternion.identity);
				obj.transform.LookAt(Yandere.TargetStudent.Hips.position + new Vector3(0f, 0.33333f, 0f));
				obj.transform.localScale = new Vector3(1f, 1f, Vector3.Distance(Eyes[ID].transform.position, Yandere.TargetStudent.Hips.position + new Vector3(0f, 0.33333f, 0f)) * 0.5f);
			}
		}
		if (Effect == 0)
		{
			Yandere.TargetStudent.Combust();
		}
		else if (Effect == 1)
		{
			ElectrocuteStudent(Yandere.TargetStudent);
		}
		else if (Effect == 2)
		{
			Object.Instantiate(Yandere.FalconPunch, Yandere.TargetStudent.transform.position + new Vector3(0f, 0.5f, 0f) - Yandere.transform.forward * 0.5f, Quaternion.identity);
		}
		else if (Effect == 3)
		{
			Object.Instantiate(Yandere.EbolaEffect, Yandere.TargetStudent.transform.position + Vector3.up, Quaternion.identity);
			Yandere.TargetStudent.SpawnAlarmDisc();
			Yandere.TargetStudent.DeathType = DeathType.Poison;
			Yandere.TargetStudent.BecomeRagdoll();
		}
		else if (Effect == 4)
		{
			if (Yandere.TargetStudent.Male)
			{
				Object.Instantiate(MaleBloodyScream, Yandere.TargetStudent.transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
			}
			else
			{
				Object.Instantiate(FemaleBloodyScream, Yandere.TargetStudent.transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
			}
			Yandere.TargetStudent.BecomeRagdoll();
			Yandere.TargetStudent.Ragdoll.Dismember();
		}
		else if (Effect == 5)
		{
			Yandere.TargetStudent.TurnToStone();
		}
	}

	public void ElectrocuteStudent(StudentScript Target)
	{
		Target.enabled = true;
		Target.RemoveOfferHelpPrompt();
		if (Target.Following)
		{
			ParticleSystem.EmissionModule emission = Target.Hearts.emission;
			emission.enabled = false;
			Target.FollowCountdown.gameObject.SetActive(value: false);
			Target.Yandere.Follower = null;
			Target.Yandere.Followers--;
			Target.Following = false;
			Target.CurrentDestination = Target.Destinations[Target.Phase];
			Target.Pathfinding.target = Target.Destinations[Target.Phase];
			Target.Pathfinding.speed = 1f;
		}
		if (Target.Distracting)
		{
			if (Target.DistractionTarget != null)
			{
				Target.DistractionTarget.TargetedForDistraction = false;
			}
			Target.ResumeDistracting = false;
			Target.Distracting = false;
		}
		if (Target.Vomiting)
		{
			Target.VomitEmitter.gameObject.SetActive(value: false);
			Target.Vomiting = false;
			Target.VomitPhase = 0;
		}
		if (Target.ReturningMisplacedWeapon)
		{
			Target.DropMisplacedWeapon();
		}
		if (Target.Investigating)
		{
			Target.StopInvestigating();
		}
		if (StudentManager.BloodReporter != null && StudentManager.BloodReporter.MyTeacher == Target)
		{
			StudentManager.BloodReporter.ReturnToNormal();
		}
		Target.Pathfinding.canSearch = false;
		Target.Pathfinding.canMove = false;
		Target.Routine = false;
		Target.EmptyHands();
		if (Target.StudentID == 1)
		{
			Debug.Log(Target.Name + " just ''dodged'' some electricity.");
			Target.CharacterAnimation.CrossFade(Target.DodgeAnim);
			Target.DodgeSpeed = 2f;
			Target.Dodging = true;
		}
		else
		{
			Debug.Log(Target.Name + " was just electrocuted.");
			Target.CharacterAnimation[Target.ElectroAnim].speed = 0.85f;
			Target.CharacterAnimation[Target.ElectroAnim].time = 2f;
			Target.CharacterAnimation.CrossFade(Target.ElectroAnim);
			if (!Target.Male)
			{
				Target.CharacterAnimation[Target.WetAnim].weight = 0f;
				Target.CharacterAnimation[Target.ShyAnim].weight = 0f;
			}
			if (Target.Shoving)
			{
				Yandere.CannotRecover = false;
			}
			Target.SpecialRivalDeathReaction = false;
			Target.InvestigatingBloodPool = false;
			Target.SearchingForPhone = false;
			Target.FocusOnYandere = false;
			Target.SolvingPuzzle = false;
			Target.EatingSnack = false;
			Target.Confessing = false;
			Target.Electrified = true;
			Target.EndSearch = false;
			Target.Attacked = false;
			Target.Vomiting = false;
			Target.Fleeing = false;
			Target.Shoving = false;
			Target.Dying = true;
			Target.Shy = false;
			Target.Wet = false;
			Target.Police.CorpseList[Target.Police.Corpses] = Target.Ragdoll;
			Target.Police.Corpses++;
			GameObjectUtils.SetLayerRecursively(Target.gameObject, 11);
			Target.MapMarker.gameObject.layer = 10;
			Target.tag = "Blood";
			Target.Ragdoll.ElectrocutionAnimation = true;
			Target.Ragdoll.Disturbing = true;
			Target.SpawnAlarmDisc();
			GameObject obj = Object.Instantiate(StudentManager.LightSwitch.Electricity, Target.transform.position, Quaternion.identity);
			obj.transform.parent = Target.BoneSets.RightArm;
			obj.transform.localPosition = Vector3.zero;
			GameObject obj2 = Object.Instantiate(StudentManager.LightSwitch.Electricity, Target.transform.position, Quaternion.identity);
			obj2.transform.parent = Target.BoneSets.LeftArm;
			obj2.transform.localPosition = Vector3.zero;
			GameObject obj3 = Object.Instantiate(StudentManager.LightSwitch.Electricity, Target.transform.position, Quaternion.identity);
			obj3.transform.parent = Target.BoneSets.RightLeg;
			obj3.transform.localPosition = Vector3.zero;
			GameObject obj4 = Object.Instantiate(StudentManager.LightSwitch.Electricity, Target.transform.position, Quaternion.identity);
			obj4.transform.parent = Target.BoneSets.LeftLeg;
			obj4.transform.localPosition = Vector3.zero;
			GameObject obj5 = Object.Instantiate(StudentManager.LightSwitch.Electricity, Target.transform.position, Quaternion.identity);
			obj5.transform.parent = Target.BoneSets.Head;
			obj5.transform.localPosition = Vector3.zero;
			GameObject obj6 = Object.Instantiate(StudentManager.LightSwitch.Electricity, Target.transform.position, Quaternion.identity);
			obj6.transform.parent = Target.Hips;
			obj6.transform.localPosition = Vector3.zero;
			AudioSource.PlayClipAtPoint(StudentManager.LightSwitch.Flick[2], Target.transform.position + Vector3.up);
			if (Target.OsanaHairL != null)
			{
				Target.OsanaHairL.GetComponent<DynamicBone>().enabled = false;
				Target.OsanaHairR.GetComponent<DynamicBone>().enabled = false;
			}
		}
		if (Yandere.PotentiallyMurderousTimer > 0f)
		{
			Yandere.Sanity -= ((PlayerGlobals.PantiesEquipped == 10) ? 10f : 20f) * Yandere.Numbness;
		}
		Target.HipCollider.enabled = true;
		if (!Target.Male)
		{
			Target.HorudaCollider.transform.localScale = Vector3.zero;
		}
	}
}
