using UnityEngine;
using UnityEngine.SceneManagement;

public class NemesisScript : MonoBehaviour
{
	public MissionModeScript MissionMode;

	public CosmeticScript Cosmetic;

	public StudentScript Student;

	public YandereScript Yandere;

	public AudioClip YandereDeath;

	public Texture NemesisUniform;

	public Texture NemesisFace;

	public Texture NemesisEyes;

	public GameObject BloodEffect;

	public GameObject NemesisHair;

	public GameObject Knife;

	public bool PutOnDisguise;

	public bool Aggressive;

	public bool Attacking;

	public bool Chasing;

	public bool InView;

	public bool Dying;

	public int EffectPhase;

	public int Difficulty;

	public int Frame;

	public int ID;

	public float OriginalYPosition;

	public float ScanTimer = 6f;

	private void Start()
	{
		GameObject[] femaleHair = Cosmetic.FemaleHair;
		foreach (GameObject gameObject in femaleHair)
		{
			if (gameObject != null)
			{
				gameObject.SetActive(false);
			}
		}
		femaleHair = Cosmetic.TeacherHair;
		foreach (GameObject gameObject2 in femaleHair)
		{
			if (gameObject2 != null)
			{
				gameObject2.SetActive(false);
			}
		}
		femaleHair = Cosmetic.FemaleAccessories;
		foreach (GameObject gameObject3 in femaleHair)
		{
			if (gameObject3 != null)
			{
				gameObject3.SetActive(false);
			}
		}
		femaleHair = Cosmetic.TeacherAccessories;
		foreach (GameObject gameObject4 in femaleHair)
		{
			if (gameObject4 != null)
			{
				gameObject4.SetActive(false);
			}
		}
		femaleHair = Cosmetic.ClubAccessories;
		foreach (GameObject gameObject5 in femaleHair)
		{
			if (gameObject5 != null)
			{
				gameObject5.SetActive(false);
			}
		}
		femaleHair = Cosmetic.Kerchiefs;
		foreach (GameObject gameObject6 in femaleHair)
		{
			if (gameObject6 != null)
			{
				gameObject6.SetActive(false);
			}
		}
		femaleHair = Cosmetic.CatGifts;
		foreach (GameObject gameObject7 in femaleHair)
		{
			if (gameObject7 != null)
			{
				gameObject7.SetActive(false);
			}
		}
		femaleHair = Cosmetic.Rings;
		foreach (GameObject gameObject8 in femaleHair)
		{
			if (gameObject8 != null)
			{
				gameObject8.SetActive(false);
			}
		}
		Difficulty = MissionModeGlobals.NemesisDifficulty;
		if (Difficulty == 0)
		{
			Difficulty = 1;
		}
		Student.StudentManager = GameObject.Find("StudentManager").GetComponent<StudentManagerScript>();
		Student.WitnessCamera = GameObject.Find("WitnessCamera").GetComponent<WitnessCameraScript>();
		Student.Police = GameObject.Find("Police").GetComponent<PoliceScript>();
		Student.JSON = GameObject.Find("JSON").GetComponent<JsonScript>();
		Student.CharacterAnimation = Student.Character.GetComponent<Animation>();
		Student.Ragdoll.Nemesis = true;
		Student.Yandere = Yandere;
		Student.IdleAnim = "f02_newIdle_00";
		Student.WalkAnim = "f02_newWalk_00";
		Student.ShoeRemoval.RightCasualShoe.gameObject.SetActive(false);
		Student.ShoeRemoval.LeftCasualShoe.gameObject.SetActive(false);
		if (Difficulty < 3)
		{
			Student.Character.GetComponent<Animation>()["f02_nemesisEyes_00"].layer = 2;
			Student.Character.GetComponent<Animation>().Play("f02_nemesisEyes_00");
			Cosmetic.MyRenderer.sharedMesh = Cosmetic.FemaleUniforms[5];
			Cosmetic.MyRenderer.materials[0].mainTexture = NemesisUniform;
			Cosmetic.MyRenderer.materials[1].mainTexture = NemesisUniform;
			Cosmetic.MyRenderer.materials[2].mainTexture = NemesisFace;
			Cosmetic.RightEyeRenderer.material.mainTexture = NemesisEyes;
			Cosmetic.LeftEyeRenderer.material.mainTexture = NemesisEyes;
			Student.FaceCollider.tag = "Nemesis";
			NemesisHair.SetActive(true);
		}
		else
		{
			NemesisHair.SetActive(false);
			PutOnDisguise = true;
		}
		Student.LowPoly.enabled = false;
		Student.DisableEffects();
		HideObjects();
		for (ID = 0; ID < Student.Ragdoll.AllRigidbodies.Length; ID++)
		{
			Student.Ragdoll.AllRigidbodies[ID].isKinematic = true;
			Student.Ragdoll.AllColliders[ID].enabled = false;
		}
		Student.Ragdoll.AllColliders[10].enabled = true;
		Student.Prompt.HideButton[0] = true;
		Student.Prompt.HideButton[2] = true;
		Object.Destroy(Student.MyRigidbody);
		base.transform.position = MissionMode.SpawnPoints[Random.Range(0, 4)].position;
		MissionMode.LastKnownPosition.position = new Vector3(0f, 0f, -36f);
		UpdateLKP();
		base.transform.parent = null;
		Student.Name = "Nemesis";
		Aggressive = MissionModeGlobals.NemesisAggression;
	}

	private void Update()
	{
		if (Frame > 1)
		{
			Student.FaceCollider.enabled = true;
			if (PutOnDisguise)
			{
				Debug.Log("Nemesis is supposed to be choosing a disguise right now.");
				bool flag = false;
				int num = 1;
				while ((Student.StudentManager.Students[num] != null && Student.StudentManager.Students[num].Male) || (num > 5 && num < 21) || num == 21 || num == 26 || num == 31 || num == 36 || num == 41 || num == 46 || num == 51 || num == 56 || num == 61 || num == 66 || num == 71 || num == MissionMode.TargetID || flag)
				{
					num = Random.Range(2, 90);
					if (!MissionMode.MultiMission)
					{
						continue;
					}
					flag = false;
					for (int i = 1; i < 11; i++)
					{
						if (num == PlayerPrefs.GetInt("MissionModeTarget" + i))
						{
							flag = true;
						}
					}
				}
				Debug.Log("Nemesis is replacing Student# " + num + " - " + Student.StudentManager.Students[num].Name);
				Student.StudentManager.Students[num].gameObject.SetActive(false);
				Student.StudentManager.Students[num].Replaced = true;
				Cosmetic.StudentID = num;
				Cosmetic.Start();
				if (Student.StudentManager.Students[num].Club != ClubType.Council)
				{
					Debug.Log("Not council member. Putting on black blazer.");
					if (Cosmetic.StudentID > 80)
					{
						Cosmetic.MyRenderer.materials[0].mainTexture = Cosmetic.GanguroUniformTextures[5];
						Cosmetic.MyRenderer.materials[1].mainTexture = Cosmetic.GanguroUniformTextures[5];
					}
					else
					{
						Cosmetic.MyRenderer.materials[0].mainTexture = Cosmetic.FemaleUniformTextures[5];
						Cosmetic.MyRenderer.materials[1].mainTexture = Cosmetic.FemaleUniformTextures[5];
					}
				}
				else
				{
					Debug.Log("Council member. Attempting to put on white blazer.");
					Cosmetic.MyRenderer.materials[0].mainTexture = Cosmetic.FemaleUniformTextures[7];
					Cosmetic.MyRenderer.materials[1].mainTexture = Cosmetic.FemaleUniformTextures[7];
				}
				OutlineScript component = Cosmetic.FemaleHair[Cosmetic.Hairstyle].GetComponent<OutlineScript>();
				if (component != null)
				{
					component.enabled = false;
				}
				else
				{
					component = Cosmetic.FemaleHairRenderers[Cosmetic.Hairstyle].GetComponent<OutlineScript>();
					if (component != null)
					{
						component.enabled = false;
					}
				}
				Student.FaceCollider.tag = "Disguise";
				Debug.Log("As of now, Nemesis should have disguised herself as " + Student.StudentManager.Students[num].Name);
				PutOnDisguise = false;
			}
		}
		Frame++;
		if (!Dying && !Student.Dying)
		{
			if (!Attacking)
			{
				if (Yandere.Laughing && Vector3.Distance(base.transform.position, Yandere.transform.position) < 10f)
				{
					MissionMode.LastKnownPosition.position = Yandere.transform.position;
					UpdateLKP();
				}
				if (!Yandere.CanMove && !Yandere.Laughing)
				{
					if (Student.Pathfinding.canSearch)
					{
						Student.Character.GetComponent<Animation>().CrossFade("f02_idleShort_00");
						Student.Pathfinding.canSearch = false;
						Student.Pathfinding.canMove = false;
						Student.Pathfinding.speed = 0f;
					}
				}
				else
				{
					if (Yandere.Stance.Current != StanceType.Crouching && Yandere.Stance.Current != StanceType.Crawling && Vector3.Distance(base.transform.position, Yandere.transform.position) < 10f && Yandere.Running)
					{
						MissionMode.LastKnownPosition.position = Yandere.transform.position;
						UpdateLKP();
					}
					if (!Student.Pathfinding.canSearch)
					{
						if (!Chasing)
						{
							Student.Character.GetComponent<Animation>().CrossFade(Student.WalkAnim);
							Student.Pathfinding.speed = 1f;
						}
						else
						{
							Student.Character.GetComponent<Animation>().CrossFade("f02_sithRun_00");
							Student.Pathfinding.speed = 5f;
						}
						Student.Pathfinding.canSearch = true;
						Student.Pathfinding.canMove = true;
					}
					InView = false;
					LookForYandere();
					if (!Chasing)
					{
						Student.Pathfinding.speed = Mathf.MoveTowards(Student.Pathfinding.speed, InView ? 2f : 1f, Time.deltaTime * 0.1f);
						Student.Character.GetComponent<Animation>()[Student.WalkAnim].speed = Student.Pathfinding.speed;
					}
					else
					{
						Student.Pathfinding.speed = 5f;
					}
					if (Vector3.Distance(base.transform.position, Yandere.transform.position) < 1f)
					{
						if (InView || Chasing)
						{
							Student.CharacterAnimation.CrossFade("f02_knifeLowSanityA_00");
							Yandere.CharacterAnimation.CrossFade("f02_knifeLowSanityB_00");
							AudioSource.PlayClipAtPoint(YandereDeath, base.transform.position);
							Student.Pathfinding.canSearch = false;
							Student.Pathfinding.canMove = false;
							Knife.SetActive(true);
							Attacking = true;
							OriginalYPosition = Yandere.transform.position.y;
							Yandere.StudentManager.YandereDying = true;
							Yandere.StudentManager.StopMoving();
							GetComponent<AudioSource>().Play();
							Yandere.YandereVision = false;
							Yandere.FollowHips = true;
							Yandere.Laughing = false;
							Yandere.CanMove = false;
							Yandere.EyeShrink = 0.5f;
							Yandere.StopAiming();
							Yandere.EmptyHands();
						}
					}
					else if (Vector3.Distance(base.transform.position, MissionMode.LastKnownPosition.position) < 1f)
					{
						Student.Character.GetComponent<Animation>().CrossFade("f02_nemesisScan_00");
						Student.Pathfinding.speed = 0f;
						ScanTimer += Time.deltaTime;
						if (ScanTimer > 6f)
						{
							Vector3 vector = new Vector3(0f, 0f, -2.5f);
							MissionMode.LastKnownPosition.position = ((MissionMode.LastKnownPosition.position == vector) ? Yandere.transform.position : vector);
							Chasing = false;
							UpdateLKP();
						}
					}
				}
				if (Difficulty != 1 && Difficulty != 3)
				{
					return;
				}
				if (Vector3.Distance(base.transform.position, Yandere.transform.position) < 1f)
				{
					if (Mathf.Abs(Vector3.Angle(-base.transform.forward, Yandere.transform.position - base.transform.position)) > 45f)
					{
						Student.Prompt.HideButton[2] = true;
					}
					else if (Yandere.Armed)
					{
						Student.Prompt.HideButton[2] = false;
					}
					if (!Yandere.Armed)
					{
						Student.Prompt.HideButton[2] = true;
					}
					if (Student.Prompt.Circle[2].fillAmount < 1f)
					{
						Yandere.TargetStudent = Student;
						Yandere.AttackManager.Stealth = true;
						Student.AttackReaction();
						Student.Pathfinding.canSearch = false;
						Student.Pathfinding.canMove = false;
						Student.Prompt.HideButton[2] = true;
						Dying = true;
					}
				}
				else
				{
					Student.Prompt.HideButton[2] = true;
				}
				return;
			}
			SpecialEffect();
			Yandere.targetRotation = Quaternion.LookRotation(base.transform.position - Yandere.transform.position);
			Yandere.transform.rotation = Quaternion.Slerp(Yandere.transform.rotation, Yandere.targetRotation, Time.deltaTime * 10f);
			Yandere.MoveTowardsTarget(base.transform.position + base.transform.forward * 0.5f);
			Yandere.EyeShrink = 0.5f;
			Yandere.transform.position = new Vector3(Yandere.transform.position.x, OriginalYPosition, Yandere.transform.position.z);
			Quaternion b = Quaternion.LookRotation(Yandere.transform.position - base.transform.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * 10f);
			Animation component2 = Student.Character.GetComponent<Animation>();
			if (component2["f02_knifeLowSanityA_00"].time >= component2["f02_knifeLowSanityA_00"].length)
			{
				if (MissionMode.enabled)
				{
					MissionMode.GameOverID = 13;
					MissionMode.GameOver();
					MissionMode.Phase = 4;
					base.enabled = false;
				}
				else
				{
					SceneManager.LoadScene("LoadingScene");
				}
			}
		}
		else if (Student.Alive && !Student.Electrified)
		{
			Student.MoveTowardsTarget(Yandere.transform.position + Yandere.transform.forward * Yandere.AttackManager.Distance);
			Quaternion b2 = Quaternion.LookRotation(base.transform.position - new Vector3(Yandere.transform.position.x, base.transform.position.y, Yandere.transform.position.z));
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b2, Time.deltaTime * 10f);
		}
		else
		{
			base.enabled = false;
		}
	}

	private void LookForYandere()
	{
		Student.VisionDistance = 25f;
		if (Student.CanSeeObject(Yandere.gameObject, Yandere.HeadPosition))
		{
			MissionMode.LastKnownPosition.position = Yandere.transform.position;
			InView = true;
			UpdateLKP();
			if (Aggressive)
			{
				Chasing = true;
			}
		}
	}

	private void UpdateLKP()
	{
		if (!Chasing)
		{
			Student.Character.GetComponent<Animation>().CrossFade(Student.WalkAnim);
		}
		else
		{
			Student.Character.GetComponent<Animation>().CrossFade("f02_sithRun_00");
		}
		if (Student.Pathfinding.speed == 0f)
		{
			if (!Chasing)
			{
				Student.Pathfinding.speed = 1f;
			}
			else
			{
				Student.Pathfinding.speed = 5f;
			}
		}
		ScanTimer = 0f;
		InView = true;
	}

	private void SpecialEffect()
	{
		Animation component = Student.Character.GetComponent<Animation>();
		if (EffectPhase == 0)
		{
			if (component["f02_knifeLowSanityA_00"].time > 2.7666667f)
			{
				Object.Instantiate(BloodEffect, Knife.transform.position + Knife.transform.forward * 0.1f, Quaternion.identity);
				EffectPhase++;
			}
		}
		else if (EffectPhase == 1)
		{
			if (component["f02_knifeLowSanityA_00"].time > 3.5333333f)
			{
				Object.Instantiate(BloodEffect, Knife.transform.position + Knife.transform.forward * 0.1f, Quaternion.identity);
				EffectPhase++;
			}
		}
		else if (EffectPhase == 2 && component["f02_knifeLowSanityA_00"].time > 4.1666665f)
		{
			Object.Instantiate(BloodEffect, Knife.transform.position + Knife.transform.forward * 0.1f, Quaternion.identity);
			EffectPhase++;
		}
	}

	private void HideObjects()
	{
		Student.Cosmetic.RightStockings[0].SetActive(false);
		Student.Cosmetic.LeftStockings[0].SetActive(false);
		Student.Cosmetic.RightWristband.SetActive(false);
		Student.Cosmetic.LeftWristband.SetActive(false);
		Student.FollowCountdown.gameObject.SetActive(false);
		Student.DramaticCamera.gameObject.SetActive(false);
		Student.VomitEmitter.gameObject.SetActive(false);
		Student.Countdown.gameObject.SetActive(false);
		Student.ScienceProps[0].SetActive(false);
		Student.Chopsticks[0].SetActive(false);
		Student.Chopsticks[1].SetActive(false);
		Student.Handkerchief.SetActive(false);
		Student.ChaseCamera.SetActive(false);
		Student.PepperSpray.SetActive(false);
		Student.WateringCan.SetActive(false);
		Student.OccultBook.SetActive(false);
		Student.Cigarette.SetActive(false);
		Student.EventBook.SetActive(false);
		Student.Handcuffs.SetActive(false);
		Student.CandyBar.SetActive(false);
		Student.Scrubber.SetActive(false);
		Student.Lighter.SetActive(false);
		Student.Octodog.SetActive(false);
		Student.Eraser.SetActive(false);
		Student.Bento.SetActive(false);
		Student.Pen.SetActive(false);
		Student.SpeechLines.Stop();
		Student.InstrumentBag[1].SetActive(false);
		Student.InstrumentBag[2].SetActive(false);
		Student.InstrumentBag[3].SetActive(false);
		Student.InstrumentBag[4].SetActive(false);
		Student.InstrumentBag[5].SetActive(false);
		Student.Instruments[1].SetActive(false);
		Student.Instruments[2].SetActive(false);
		Student.Instruments[3].SetActive(false);
		Student.Instruments[4].SetActive(false);
		Student.Instruments[5].SetActive(false);
		Student.Drumsticks[0].SetActive(false);
		Student.Drumsticks[1].SetActive(false);
		Student.Cosmetic.ThickBrows.SetActive(false);
		Student.RetroCamera.SetActive(false);
		Student.WeaponBag.SetActive(false);
		ParticleSystem[] splashEmitters = Student.SplashEmitters;
		foreach (ParticleSystem particleSystem in splashEmitters)
		{
			if (particleSystem != null)
			{
				particleSystem.gameObject.SetActive(false);
			}
		}
		GameObject[] scienceProps = Student.ScienceProps;
		foreach (GameObject gameObject in scienceProps)
		{
			if (gameObject != null)
			{
				gameObject.SetActive(false);
			}
		}
		scienceProps = Student.Cosmetic.PunkAccessories;
		foreach (GameObject gameObject2 in scienceProps)
		{
			if (gameObject2 != null)
			{
				gameObject2.SetActive(false);
			}
		}
		scienceProps = Student.Fingerfood;
		foreach (GameObject gameObject3 in scienceProps)
		{
			if (gameObject3 != null)
			{
				gameObject3.SetActive(false);
			}
		}
	}
}
