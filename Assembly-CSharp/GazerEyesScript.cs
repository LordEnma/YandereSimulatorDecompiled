using System;
using UnityEngine;

// Token: 0x020002DC RID: 732
public class GazerEyesScript : MonoBehaviour
{
	// Token: 0x060014DE RID: 5342 RVA: 0x000CE9D0 File Offset: 0x000CCBD0
	private void Start()
	{
		base.GetComponent<Animation>()["Eyeballs_Run"].speed = 0f;
		base.GetComponent<Animation>()["Eyeballs_Walk"].speed = 0f;
		base.GetComponent<Animation>()["Eyeballs_Idle"].speed = 0f;
	}

	// Token: 0x060014DF RID: 5343 RVA: 0x000CEA2C File Offset: 0x000CCC2C
	private void Update()
	{
		this.StudentManager.UpdateStudents(0);
		if (!this.Attacking)
		{
			this.AnimTime += Time.deltaTime;
			if (this.AnimTime > 144f)
			{
				this.AnimTime = 0f;
			}
		}
		else if (this.AnimTime < 72f)
		{
			this.AnimTime = Mathf.Lerp(this.AnimTime, 0f, Time.deltaTime * 1.44f * 5f);
		}
		else
		{
			this.AnimTime = Mathf.Lerp(this.AnimTime, 144f, Time.deltaTime * 1.44f * 5f);
		}
		base.GetComponent<Animation>()["Eyeballs_Run"].time = this.AnimTime;
		base.GetComponent<Animation>()["Eyeballs_Walk"].time = this.AnimTime;
		base.GetComponent<Animation>()["Eyeballs_Idle"].time = this.AnimTime;
		this.ID = 0;
		while (this.ID < this.Eyes.Length)
		{
			if (this.BlinkStrength[this.ID] == 0f)
			{
				this.RandomNumber = (float)UnityEngine.Random.Range(1, 101);
			}
			if (this.RandomNumber == 1f)
			{
				this.Blink[this.ID] = true;
			}
			if (this.Blink[this.ID])
			{
				this.BlinkStrength[this.ID] = Mathf.MoveTowards(this.BlinkStrength[this.ID], 100f, Time.deltaTime * 1000f);
				this.Eyes[this.ID].SetBlendShapeWeight(0, this.BlinkStrength[this.ID]);
				if (this.BlinkStrength[this.ID] == 100f)
				{
					this.Blink[this.ID] = false;
				}
			}
			else if (this.BlinkStrength[this.ID] > 0f)
			{
				this.BlinkStrength[this.ID] = Mathf.MoveTowards(this.BlinkStrength[this.ID], 0f, Time.deltaTime * 1000f);
				this.Eyes[this.ID].SetBlendShapeWeight(0, this.BlinkStrength[this.ID]);
			}
			this.ID++;
		}
		float axis = Input.GetAxis("Vertical");
		float axis2 = Input.GetAxis("Horizontal");
		if (this.Yandere.CanMove)
		{
			if (axis != 0f || axis2 != 0f)
			{
				if (Input.GetButton("LB"))
				{
					base.GetComponent<Animation>().CrossFade("Eyeballs_Run", 1f);
					return;
				}
				base.GetComponent<Animation>().CrossFade("Eyeballs_Walk", 1f);
				return;
			}
			else
			{
				base.GetComponent<Animation>().CrossFade("Eyeballs_Idle", 1f);
			}
		}
	}

	// Token: 0x060014E0 RID: 5344 RVA: 0x000CECF8 File Offset: 0x000CCEF8
	public void ChangeEffect()
	{
		this.Effect++;
		if (this.Effect == this.EyeTextures.Length)
		{
			this.Effect = 0;
		}
		this.ID = 0;
		while (this.ID < this.Eyes.Length)
		{
			UnityEngine.Object.Instantiate<GameObject>(this.ParticleEffect, this.Eyes[this.ID].transform.position, Quaternion.identity);
			this.Eyes[this.ID].material.mainTexture = this.EyeTextures[this.Effect];
			this.ID++;
		}
	}

	// Token: 0x060014E1 RID: 5345 RVA: 0x000CEDA0 File Offset: 0x000CCFA0
	public void Attack()
	{
		if (!this.Shinigami)
		{
			this.ID = 0;
			while (this.ID < this.Eyes.Length)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Laser, this.Eyes[this.ID].transform.position, Quaternion.identity);
				gameObject.transform.LookAt(this.Yandere.TargetStudent.Hips.position + new Vector3(0f, 0.33333f, 0f));
				gameObject.transform.localScale = new Vector3(1f, 1f, Vector3.Distance(this.Eyes[this.ID].transform.position, this.Yandere.TargetStudent.Hips.position + new Vector3(0f, 0.33333f, 0f)) * 0.5f);
				this.ID++;
			}
		}
		if (this.Effect == 0)
		{
			this.Yandere.TargetStudent.Combust();
			return;
		}
		if (this.Effect == 1)
		{
			this.ElectrocuteStudent(this.Yandere.TargetStudent);
			return;
		}
		if (this.Effect == 2)
		{
			UnityEngine.Object.Instantiate<GameObject>(this.Yandere.FalconPunch, this.Yandere.TargetStudent.transform.position + new Vector3(0f, 0.5f, 0f) - this.Yandere.transform.forward * 0.5f, Quaternion.identity);
			return;
		}
		if (this.Effect == 3)
		{
			UnityEngine.Object.Instantiate<GameObject>(this.Yandere.EbolaEffect, this.Yandere.TargetStudent.transform.position + Vector3.up, Quaternion.identity);
			this.Yandere.TargetStudent.SpawnAlarmDisc();
			this.Yandere.TargetStudent.DeathType = DeathType.Poison;
			this.Yandere.TargetStudent.BecomeRagdoll();
			return;
		}
		if (this.Effect == 4)
		{
			if (this.Yandere.TargetStudent.Male)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.MaleBloodyScream, this.Yandere.TargetStudent.transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
			}
			else
			{
				UnityEngine.Object.Instantiate<GameObject>(this.FemaleBloodyScream, this.Yandere.TargetStudent.transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
			}
			this.Yandere.TargetStudent.BecomeRagdoll();
			this.Yandere.TargetStudent.Ragdoll.Dismember();
			return;
		}
		if (this.Effect == 5)
		{
			this.Yandere.TargetStudent.TurnToStone();
		}
	}

	// Token: 0x060014E2 RID: 5346 RVA: 0x000CF09C File Offset: 0x000CD29C
	public void ElectrocuteStudent(StudentScript Target)
	{
		if (Target.StudentID == 1)
		{
			Debug.Log(Target.Name + " just dodged a bucket of liquid.");
			if (Target.Investigating)
			{
				Target.StopInvestigating();
			}
			if (Target.ReturningMisplacedWeapon)
			{
				Target.DropMisplacedWeapon();
			}
			Target.CharacterAnimation.CrossFade(Target.DodgeAnim);
			Target.Pathfinding.canSearch = false;
			Target.Pathfinding.canMove = false;
			Target.Routine = false;
			Target.DodgeSpeed = 2f;
			Target.Dodging = true;
			Target.Vomiting = false;
			Target.VomitPhase = 0;
			if (Target.Following)
			{
				Target.Hearts.emission.enabled = false;
				Target.FollowCountdown.gameObject.SetActive(false);
				Target.Yandere.Follower = null;
				Target.Yandere.Followers--;
				Target.Following = false;
				Target.CurrentDestination = Target.Destinations[Target.Phase];
				Target.Pathfinding.target = Target.Destinations[Target.Phase];
				Target.Pathfinding.speed = 1f;
				return;
			}
		}
		else
		{
			Target.EmptyHands();
			if (Target.Investigating)
			{
				Target.StopInvestigating();
			}
			Target.CharacterAnimation[Target.ElectroAnim].speed = 0.85f;
			Target.CharacterAnimation[Target.ElectroAnim].time = 2f;
			Target.CharacterAnimation.CrossFade(Target.ElectroAnim);
			Target.CharacterAnimation[Target.WetAnim].weight = 0f;
			Target.Pathfinding.canSearch = false;
			Target.Pathfinding.canMove = false;
			Target.EatingSnack = false;
			Target.Electrified = true;
			Target.Fleeing = false;
			Target.Routine = false;
			Target.Dying = true;
			if (Target.Following)
			{
				Target.Yandere.Follower = null;
				Target.Yandere.Followers--;
				Target.Following = false;
			}
			Target.Police.CorpseList[Target.Police.Corpses] = Target.Ragdoll;
			Target.Police.Corpses++;
			GameObjectUtils.SetLayerRecursively(Target.gameObject, 11);
			Target.MapMarker.gameObject.layer = 10;
			Target.tag = "Blood";
			Target.Ragdoll.ElectrocutionAnimation = true;
			Target.Ragdoll.Disturbing = true;
			Target.MurderSuicidePhase = 100;
			Target.SpawnAlarmDisc();
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.StudentManager.LightSwitch.Electricity, Target.transform.position, Quaternion.identity);
			gameObject.transform.parent = Target.BoneSets.RightArm;
			gameObject.transform.localPosition = Vector3.zero;
			GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.StudentManager.LightSwitch.Electricity, Target.transform.position, Quaternion.identity);
			gameObject2.transform.parent = Target.BoneSets.LeftArm;
			gameObject2.transform.localPosition = Vector3.zero;
			GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(this.StudentManager.LightSwitch.Electricity, Target.transform.position, Quaternion.identity);
			gameObject3.transform.parent = Target.BoneSets.RightLeg;
			gameObject3.transform.localPosition = Vector3.zero;
			GameObject gameObject4 = UnityEngine.Object.Instantiate<GameObject>(this.StudentManager.LightSwitch.Electricity, Target.transform.position, Quaternion.identity);
			gameObject4.transform.parent = Target.BoneSets.LeftLeg;
			gameObject4.transform.localPosition = Vector3.zero;
			GameObject gameObject5 = UnityEngine.Object.Instantiate<GameObject>(this.StudentManager.LightSwitch.Electricity, Target.transform.position, Quaternion.identity);
			gameObject5.transform.parent = Target.BoneSets.Head;
			gameObject5.transform.localPosition = Vector3.zero;
			GameObject gameObject6 = UnityEngine.Object.Instantiate<GameObject>(this.StudentManager.LightSwitch.Electricity, Target.transform.position, Quaternion.identity);
			gameObject6.transform.parent = Target.Hips;
			gameObject6.transform.localPosition = Vector3.zero;
			AudioSource.PlayClipAtPoint(this.StudentManager.LightSwitch.Flick[2], Target.transform.position + Vector3.up);
			if (Target.OsanaHairL != null)
			{
				Target.OsanaHairL.GetComponent<DynamicBone>().enabled = false;
				Target.OsanaHairR.GetComponent<DynamicBone>().enabled = false;
			}
		}
	}

	// Token: 0x04002106 RID: 8454
	public StudentManagerScript StudentManager;

	// Token: 0x04002107 RID: 8455
	public YandereScript Yandere;

	// Token: 0x04002108 RID: 8456
	public GameObject FemaleBloodyScream;

	// Token: 0x04002109 RID: 8457
	public GameObject MaleBloodyScream;

	// Token: 0x0400210A RID: 8458
	public GameObject ParticleEffect;

	// Token: 0x0400210B RID: 8459
	public GameObject Laser;

	// Token: 0x0400210C RID: 8460
	public SkinnedMeshRenderer[] Eyes;

	// Token: 0x0400210D RID: 8461
	public float[] BlinkStrength;

	// Token: 0x0400210E RID: 8462
	public Texture[] EyeTextures;

	// Token: 0x0400210F RID: 8463
	public bool[] Blink;

	// Token: 0x04002110 RID: 8464
	public float RandomNumber;

	// Token: 0x04002111 RID: 8465
	public float AnimTime;

	// Token: 0x04002112 RID: 8466
	public bool Attacking;

	// Token: 0x04002113 RID: 8467
	public int Effect;

	// Token: 0x04002114 RID: 8468
	public int ID;

	// Token: 0x04002115 RID: 8469
	public bool Shinigami;
}
