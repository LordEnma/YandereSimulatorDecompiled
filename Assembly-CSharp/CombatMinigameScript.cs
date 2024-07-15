using UnityEngine;

public class CombatMinigameScript : MonoBehaviour
{
	public UISprite[] ButtonPrompts;

	public UISprite Circle;

	public UISprite BG;

	public GameObject HitEffect;

	public PracticeWindowScript PracticeWindow;

	public StudentScript Delinquent;

	public YandereScript Yandere;

	public UIPanel CombatPanel;

	public Transform CombatTarget;

	public Transform MainCamera;

	public Transform Midpoint;

	public Vector3 CameraTarget;

	public Vector3 CameraStart;

	public Vector3 StartPoint;

	public UITexture RedVignette;

	public UILabel Label;

	public string CurrentButton;

	public float SlowdownFactor;

	public float ShakeFactor;

	public float Difficulty;

	public float StartTime;

	public float Strength;

	public float Shake;

	public float Timer;

	public bool ExitSchoolWhenDone;

	public bool KnockedOut;

	public bool Practice;

	public bool Success;

	public bool Zoom;

	public string StopFightingAnim;

	public string Prefix;

	public int ButtonID;

	public int Strike;

	public int Phase;

	public int Path;

	public AudioSource MyVocals;

	public AudioSource MyAudio;

	public AudioClip[] CombatSFX;

	public AudioClip[] Vocals;

	private void Start()
	{
		RedVignette.color = new Color(1f, 1f, 1f, 0f);
		ButtonPrompts[1].enabled = false;
		ButtonPrompts[2].enabled = false;
		ButtonPrompts[3].enabled = false;
		ButtonPrompts[4].enabled = false;
		ButtonPrompts[1].alpha = 0f;
		ButtonPrompts[2].alpha = 0f;
		ButtonPrompts[3].alpha = 0f;
		ButtonPrompts[4].alpha = 0f;
		Circle.enabled = false;
		BG.enabled = false;
	}

	public void StartCombat()
	{
		Debug.Log("StartCombat() is being fired right NOW.");
		StartPoint = MainCamera.transform.position;
		Midpoint.transform.position = MainCamera.transform.position + MainCamera.transform.forward;
		MainCamera.transform.parent = CombatTarget;
		Yandere.RPGCamera.enabled = false;
		CombatPanel.alpha = 1f;
		Zoom = true;
		if (Delinquent.Male)
		{
			Prefix = "";
		}
		else
		{
			Prefix = "Female_";
		}
		if (!Practice)
		{
			Difficulty = 1f;
		}
		else
		{
			Delinquent.MyWeapon.GetComponent<Rigidbody>().isKinematic = true;
			Delinquent.MyWeapon.GetComponent<Rigidbody>().useGravity = false;
		}
		Difficulty -= (float)(Yandere.PhysicalGrade + Yandere.Class.PhysicalBonus) * 0.1f;
		Debug.Log("Difficulty is: " + Difficulty);
		Yandere.DelinquentFighting = true;
		Yandere.CanMove = false;
	}

	private void Update()
	{
		if (Zoom)
		{
			MainCamera.transform.localPosition = Vector3.Lerp(MainCamera.transform.localPosition, new Vector3(1.5f, 0.25f, -0.5f), Time.deltaTime * 2f);
			RedVignette.color = Vector4.Lerp(RedVignette.color, new Color(1f, 1f, 1f, 1f - (float)Yandere.Health * 1f / 10f), Time.deltaTime);
			if (Timer < 1f)
			{
				Delinquent.MoveTowardsTarget(Yandere.transform.position + Yandere.transform.forward);
			}
			Timer += Time.deltaTime;
			AdjustMidpoint();
			if (Timer > 1.5f)
			{
				Debug.Log(base.name + " is being instructed to perform the first combat animation of the combat minigame.");
				Delinquent.CharacterAnimation.CrossFade(Prefix + "Delinquent_CombatA");
				Yandere.CharacterAnimation.CrossFade("Yandere_CombatA");
				CameraStart = MainCamera.localPosition;
				Label.text = "State: A";
				Zoom = false;
				Timer = 0f;
				Phase = 1;
				Path = 1;
				MyAudio.clip = CombatSFX[Phase];
				MyAudio.Play();
				MyVocals.clip = Vocals[Phase];
				MyVocals.Play();
			}
			Yandere.DelinquentFighting = true;
			Yandere.CanMove = false;
		}
		if (Phase > 0)
		{
			MainCamera.position += new Vector3(Shake * Random.Range(-1f, 1f), Shake * Random.Range(-1f, 1f), Shake * Random.Range(-1f, 1f));
			Shake = Mathf.Lerp(Shake, 0f, Time.deltaTime * 10f);
			AdjustMidpoint();
		}
		if (ButtonID > 0)
		{
			Timer += Time.deltaTime;
			Circle.fillAmount = 1f - Timer / 0.33333f;
			if ((Input.GetButtonDown(InputNames.Xbox_A) && CurrentButton != InputNames.Xbox_A) || (Input.GetButtonDown(InputNames.Xbox_B) && CurrentButton != InputNames.Xbox_B) || (Input.GetButtonDown(InputNames.Xbox_X) && CurrentButton != InputNames.Xbox_X) || (Input.GetButtonDown(InputNames.Xbox_Y) && CurrentButton != InputNames.Xbox_Y))
			{
				Time.timeScale = 1f;
				MyVocals.pitch = 1f;
				MyAudio.pitch = 1f;
				DisablePrompts();
				Phase++;
			}
			else if (Input.GetButtonDown(CurrentButton))
			{
				Success = true;
			}
		}
		if (Path == 1)
		{
			if (!Delinquent.CharacterAnimation.IsPlaying(Prefix + "Delinquent_CombatA"))
			{
				Delinquent.CharacterAnimation.CrossFade(Prefix + "Delinquent_CombatA");
				Delinquent.CharacterAnimation[Prefix + "Delinquent_CombatA"].time = Yandere.CharacterAnimation["Yandere_CombatA"].time;
			}
			MainCamera.localPosition = Vector3.Lerp(MainCamera.localPosition, CameraStart, Time.deltaTime);
			if (Phase == 1)
			{
				if (Yandere.CharacterAnimation["Yandere_CombatA"].time > 1f)
				{
					StartTime = Yandere.CharacterAnimation["Yandere_CombatA"].time - 1f;
					ChooseButton();
					Slowdown();
					Phase++;
				}
			}
			else if (Phase == 2)
			{
				if (Yandere.CharacterAnimation["Yandere_CombatA"].time > 1.33333f)
				{
					Time.timeScale = 1f;
					MyVocals.pitch = 1f;
					MyAudio.pitch = 1f;
					DisablePrompts();
					Phase++;
				}
				else if (Success)
				{
					Delinquent.CharacterAnimation[Prefix + "Delinquent_CombatB"].time = Delinquent.CharacterAnimation[Prefix + "Delinquent_CombatA"].time;
					Yandere.CharacterAnimation["Yandere_CombatB"].time = Yandere.CharacterAnimation["Yandere_CombatA"].time;
					Delinquent.CharacterAnimation.Play(Prefix + "Delinquent_CombatB");
					Yandere.CharacterAnimation.Play("Yandere_CombatB");
					Label.text = "State: B";
					Time.timeScale = 1f;
					MyAudio.pitch = 1f;
					DisablePrompts();
					Strike = 0;
					Path = 2;
					Phase++;
					MyAudio.clip = CombatSFX[Path];
					MyAudio.time = Yandere.CharacterAnimation["Yandere_CombatB"].time;
					MyAudio.Play();
					MyVocals.clip = Vocals[Path];
					MyVocals.time = Yandere.CharacterAnimation["Yandere_CombatB"].time + 0.5f;
					MyVocals.Play();
				}
			}
			else
			{
				if (Phase != 3)
				{
					return;
				}
				if (Strike < 1)
				{
					if (Yandere.CharacterAnimation["Yandere_CombatA"].time > 1.66666f)
					{
						Object.Instantiate(HitEffect, Yandere.LeftArmRoll.position, Quaternion.identity);
						Shake += ShakeFactor;
						Strike++;
						Yandere.Health--;
						RedVignette.color = new Color(1f, 1f, 1f, 1f - (float)Yandere.Health * 1f / 10f);
					}
				}
				else if (Strike < 2 && Yandere.CharacterAnimation["Yandere_CombatA"].time > 2.5f)
				{
					Object.Instantiate(HitEffect, Yandere.RightArmRoll.position, Quaternion.identity);
					Shake += ShakeFactor;
					Strike++;
					Yandere.Health--;
					if (Yandere.Health < 0)
					{
						Yandere.Health = 0;
					}
					RedVignette.color = new Color(1f, 1f, 1f, 1f - (float)Yandere.Health * 1f / 10f);
					if (!Practice)
					{
						Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount1", 1f - (float)Yandere.Health * 1f / 10f);
					}
					if (Yandere.Health < 1)
					{
						if (!Delinquent.WitnessedMurder && !Delinquent.WitnessedCorpse)
						{
							Delinquent.CharacterAnimation[Prefix + "Delinquent_CombatF"].time = Delinquent.CharacterAnimation[Prefix + "Delinquent_CombatA"].time;
							Yandere.CharacterAnimation["Yandere_CombatF"].time = Yandere.CharacterAnimation["Yandere_CombatA"].time;
							Delinquent.CharacterAnimation.CrossFade(Prefix + "Delinquent_CombatF");
							Yandere.CharacterAnimation.CrossFade("Yandere_CombatF");
							Shake += ShakeFactor;
							Label.text = "State: F";
							Time.timeScale = 1f;
							MyVocals.pitch = 1f;
							MyAudio.pitch = 1f;
							DisablePrompts();
							Timer = 0f;
							Path = 6;
							Phase++;
							MyAudio.clip = CombatSFX[Path];
							MyAudio.time = Yandere.CharacterAnimation["Yandere_CombatF"].time;
							MyAudio.Play();
							MyVocals.clip = Vocals[Path];
							MyVocals.time = Yandere.CharacterAnimation["Yandere_CombatF"].time;
							MyVocals.Play();
						}
						else
						{
							Delinquent.CharacterAnimation[Prefix + "Delinquent_CombatE"].time = Delinquent.CharacterAnimation[Prefix + "Delinquent_CombatA"].time;
							Yandere.CharacterAnimation["Yandere_CombatE"].time = Yandere.CharacterAnimation["Yandere_CombatA"].time;
							Delinquent.CharacterAnimation.CrossFade(Prefix + "Delinquent_CombatE");
							Yandere.CharacterAnimation.CrossFade("Yandere_CombatE");
							CameraTarget = MainCamera.position + new Vector3(0f, 1f, 0f);
							MainCamera.parent = null;
							Shake += ShakeFactor;
							KnockedOut = true;
							Label.text = "State: E";
							Time.timeScale = 1f;
							MyVocals.pitch = 1f;
							MyAudio.pitch = 1f;
							DisablePrompts();
							Timer = 0f;
							Path = 5;
							Phase++;
							MyAudio.clip = CombatSFX[Path];
							MyAudio.time = Yandere.CharacterAnimation["Yandere_CombatE"].time;
							MyAudio.Play();
							MyVocals.clip = Vocals[Path];
							MyVocals.time = Yandere.CharacterAnimation["Yandere_CombatE"].time;
							MyVocals.Play();
							Delinquent.StudentManager.DisableAllStudentScripts();
						}
					}
				}
				if (Yandere.CharacterAnimation["Yandere_CombatA"].time > Yandere.CharacterAnimation["Yandere_CombatA"].length)
				{
					Delinquent.CharacterAnimation[Prefix + "Delinquent_CombatA"].time = 0f;
					Yandere.CharacterAnimation["Yandere_CombatA"].time = 0f;
					Label.text = "State: A";
					Strike = 0;
					Phase = 1;
					MyAudio.clip = CombatSFX[Path];
					MyAudio.time = Yandere.CharacterAnimation["Yandere_CombatA"].time;
					MyAudio.Play();
					MyVocals.clip = Vocals[Path];
					MyVocals.time = Yandere.CharacterAnimation["Yandere_CombatA"].time;
					MyVocals.Play();
				}
			}
		}
		else if (Path == 2)
		{
			if (Phase == 3)
			{
				if (Yandere.CharacterAnimation["Yandere_CombatB"].time > 1.833333f)
				{
					StartTime = Yandere.CharacterAnimation["Yandere_CombatB"].time - 1.833333f;
					ChooseButton();
					Slowdown();
					Phase++;
				}
			}
			else if (Phase == 4)
			{
				if (Yandere.CharacterAnimation["Yandere_CombatB"].time > 2.166666f)
				{
					Time.timeScale = 1f;
					MyVocals.pitch = 1f;
					MyAudio.pitch = 1f;
					DisablePrompts();
					Phase++;
				}
				else if (Success)
				{
					Delinquent.CharacterAnimation[Prefix + "Delinquent_CombatC"].time = Delinquent.CharacterAnimation[Prefix + "Delinquent_CombatB"].time;
					Yandere.CharacterAnimation["Yandere_CombatC"].time = Yandere.CharacterAnimation["Yandere_CombatB"].time;
					Delinquent.CharacterAnimation.Play(Prefix + "Delinquent_CombatC");
					Yandere.CharacterAnimation.Play("Yandere_CombatC");
					Label.text = "State: C";
					Time.timeScale = 1f;
					MyVocals.pitch = 1f;
					MyAudio.pitch = 1f;
					DisablePrompts();
					Strike = 0;
					Path = 3;
					Phase++;
					MyAudio.clip = CombatSFX[Path];
					MyAudio.time = Yandere.CharacterAnimation["Yandere_CombatC"].time;
					MyAudio.Play();
					MyVocals.clip = Vocals[Path];
					MyVocals.time = Yandere.CharacterAnimation["Yandere_CombatC"].time;
					MyVocals.Play();
				}
			}
			else if (Phase == 5)
			{
				if (Strike < 1 && Yandere.CharacterAnimation["Yandere_CombatB"].time > 2.66666f)
				{
					Object.Instantiate(HitEffect, Delinquent.LeftHand.position, Quaternion.identity);
					Shake += ShakeFactor;
					Strike++;
				}
				if (Yandere.CharacterAnimation["Yandere_CombatB"].time > Yandere.CharacterAnimation["Yandere_CombatB"].length)
				{
					Delinquent.CharacterAnimation.CrossFade(Prefix + "Delinquent_CombatA");
					Yandere.CharacterAnimation.CrossFade("Yandere_CombatA");
					Label.text = "State: A";
					Strike = 0;
					Phase = 1;
					Path = 1;
					MyAudio.clip = CombatSFX[Path];
					MyAudio.time = Yandere.CharacterAnimation["Yandere_CombatA"].time;
					MyAudio.Play();
					MyVocals.clip = Vocals[Path];
					MyVocals.time = Yandere.CharacterAnimation["Yandere_CombatA"].time;
					MyVocals.Play();
				}
			}
		}
		else if (Path == 3)
		{
			if (Phase == 5)
			{
				if (Strike < 1 && Yandere.CharacterAnimation["Yandere_CombatC"].time > 2.5f)
				{
					Object.Instantiate(HitEffect, Yandere.RightHand.position, Quaternion.identity);
					Shake += ShakeFactor;
					Strike++;
				}
				if (Yandere.CharacterAnimation["Yandere_CombatC"].time > 3.166666f)
				{
					StartTime = Yandere.CharacterAnimation["Yandere_CombatC"].time - 3.166666f;
					ChooseButton();
					Slowdown();
					Phase++;
				}
			}
			else if (Phase == 6)
			{
				if (Yandere.CharacterAnimation["Yandere_CombatC"].time > 3.5f)
				{
					DisablePrompts();
					Time.timeScale = 1f;
					MyVocals.pitch = 1f;
					MyAudio.pitch = 1f;
					Phase++;
				}
				else if (Success)
				{
					Delinquent.CharacterAnimation[Prefix + "Delinquent_CombatD"].time = Delinquent.CharacterAnimation[Prefix + "Delinquent_CombatC"].time;
					Yandere.CharacterAnimation["Yandere_CombatD"].time = Yandere.CharacterAnimation["Yandere_CombatC"].time;
					Delinquent.CharacterAnimation.Play(Prefix + "Delinquent_CombatD");
					Yandere.CharacterAnimation.Play("Yandere_CombatD");
					Label.text = "State: D";
					Time.timeScale = 1f;
					MyVocals.pitch = 1f;
					MyAudio.pitch = 1f;
					DisablePrompts();
					Strike = 0;
					Path = 4;
					Phase++;
					MyAudio.clip = CombatSFX[Path];
					MyAudio.time = Yandere.CharacterAnimation["Yandere_CombatD"].time;
					MyAudio.Play();
					MyVocals.clip = Vocals[Path];
					MyVocals.time = Yandere.CharacterAnimation["Yandere_CombatD"].time;
					MyVocals.Play();
				}
			}
			else if (Phase == 7 && Yandere.CharacterAnimation["Yandere_CombatC"].time > Yandere.CharacterAnimation["Yandere_CombatC"].length)
			{
				Delinquent.CharacterAnimation.CrossFade(Prefix + "Delinquent_CombatA");
				Yandere.CharacterAnimation.CrossFade("Yandere_CombatA");
				Label.text = "State: A";
				Strike = 0;
				Phase = 1;
				Path = 1;
				MyAudio.clip = CombatSFX[Path];
				MyAudio.time = Yandere.CharacterAnimation["Yandere_CombatA"].time;
				MyAudio.Play();
				MyVocals.clip = Vocals[Path];
				MyVocals.time = Yandere.CharacterAnimation["Yandere_CombatA"].time;
				MyVocals.Play();
			}
		}
		else if (Path == 4)
		{
			if (Phase != 7)
			{
				return;
			}
			if (Strike < 1)
			{
				if (Yandere.CharacterAnimation["Yandere_CombatD"].time > 4f)
				{
					Object.Instantiate(HitEffect, Yandere.RightKnee.position, Quaternion.identity);
					Delinquent.MyWeapon.transform.parent = null;
					Delinquent.MyWeapon.MyCollider.enabled = true;
					Delinquent.MyWeapon.MyCollider.isTrigger = false;
					Delinquent.MyWeapon.Prompt.enabled = true;
					Delinquent.IgnoreBlood = true;
					Rigidbody component = Delinquent.MyWeapon.GetComponent<Rigidbody>();
					component.constraints = RigidbodyConstraints.None;
					component.isKinematic = false;
					component.useGravity = true;
					if (!Practice)
					{
						Delinquent.MyWeapon.DelinquentOwned = false;
						Delinquent.MyWeapon = null;
					}
					else
					{
						Delinquent.MyWeapon.Prompt.Hide();
						Delinquent.MyWeapon.Prompt.enabled = false;
					}
					Shake += ShakeFactor;
					Strike++;
				}
			}
			else if (Yandere.CharacterAnimation["Yandere_CombatD"].time > 5.5f)
			{
				MainCamera.transform.parent = null;
				Strength += Time.deltaTime;
				MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, StartPoint, Time.deltaTime * Strength);
				RedVignette.color = Vector4.Lerp(RedVignette.color, new Vector4(1f, 0f, 0f, 0f), Time.deltaTime * Strength);
				Zoom = false;
			}
			if (!(Yandere.CharacterAnimation["Yandere_CombatD"].time > Yandere.CharacterAnimation["Yandere_CombatD"].length))
			{
				return;
			}
			Debug.Log("Player won.");
			Delinquent.WillChase = false;
			if (Delinquent.WitnessedMurder || Delinquent.WitnessedCorpse)
			{
				ExitSchoolWhenDone = true;
			}
			if (!Practice)
			{
				Yandere.Subtitle.UpdateLabel(SubtitleType.DelinquentSurrender, 0, 5f);
				Delinquent.Persona = PersonaType.Loner;
			}
			if (!Practice)
			{
				Debug.Log("Deciding what to do now that the minigame is over.");
				if (Delinquent.FoundEnemyCorpse)
				{
					ExitSchoolWhenDone = true;
				}
				if (Delinquent.WitnessedCorpse || Delinquent.WitnessedMurder || ExitSchoolWhenDone)
				{
					Debug.Log("The delinquent will now run for the exit.");
					for (int i = 1; i < Delinquent.ScheduleBlocks.Length; i++)
					{
						ScheduleBlock obj = Delinquent.ScheduleBlocks[i];
						obj.destination = "Exit";
						obj.action = "Exit";
					}
				}
				else
				{
					Debug.Log("This delinquent will now go sulk.");
					ScheduleBlock obj2 = Delinquent.ScheduleBlocks[2];
					obj2.destination = "Sulk";
					obj2.action = "Sulk";
					ScheduleBlock obj3 = Delinquent.ScheduleBlocks[4];
					obj3.destination = "Sulk";
					obj3.action = "Sulk";
					ScheduleBlock obj4 = Delinquent.ScheduleBlocks[6];
					obj4.destination = "Sulk";
					obj4.action = "Sulk";
					ScheduleBlock obj5 = Delinquent.ScheduleBlocks[7];
					obj5.destination = "Sulk";
					obj5.action = "Sulk";
				}
				ExitSchoolWhenDone = false;
				if (Delinquent.Phase == 0)
				{
					Delinquent.Phase++;
				}
				Delinquent.GetDestinations();
				Delinquent.CurrentDestination = Delinquent.Destinations[Delinquent.Phase];
				Delinquent.Pathfinding.target = Delinquent.Destinations[Delinquent.Phase];
				if (Delinquent.CurrentDestination == null)
				{
					Debug.Log("Manually setting Delinquent's destination to locker, to fix a saving/loading bug.");
					Delinquent.CurrentDestination = Delinquent.Destinations[1];
					Delinquent.Pathfinding.target = Delinquent.Destinations[1];
				}
				if (Delinquent.Male)
				{
					Delinquent.IdleAnim = "idleInjured_00";
					Delinquent.WalkAnim = "walkInjured_00";
				}
				else
				{
					Delinquent.IdleAnim = "f02_delinquentIdleInjured_00";
					Delinquent.WalkAnim = "f02_delinquentWalkInjured_00";
				}
				Delinquent.OriginalIdleAnim = Delinquent.IdleAnim;
				Delinquent.OriginalWalkAnim = Delinquent.WalkAnim;
				Delinquent.LeanAnim = Delinquent.IdleAnim;
				Delinquent.CharacterAnimation.CrossFade(Delinquent.IdleAnim);
				Delinquent.Threatened = true;
				Delinquent.Alarmed = true;
				Delinquent.Injured = true;
				Delinquent.Strength = 0;
				Delinquent.Defeats++;
			}
			else
			{
				PracticeWindow.DefeatedSho = true;
				PracticeWindow.StudentManager.TaskManager.UpdateTaskStatus();
				Delinquent.Threatened = false;
				Delinquent.Alarmed = false;
				PracticeWindow.Finish();
				Yandere.Health = 10;
				Practice = false;
			}
			Delinquent.Fighting = false;
			Delinquent.enabled = true;
			Delinquent.Distracted = false;
			Delinquent.Shoving = false;
			Delinquent.Paired = false;
			Delinquent = null;
			ReleaseYandere();
			ResetValues();
			Yandere.StudentManager.UpdateStudents();
		}
		else if (Path == 5)
		{
			if (Phase != 4)
			{
				return;
			}
			MainCamera.position = Vector3.Lerp(MainCamera.position, CameraTarget, Time.deltaTime);
			if (Yandere.CharacterAnimation["Yandere_CombatE"].time > Yandere.CharacterAnimation["Yandere_CombatE"].length)
			{
				Timer += Time.deltaTime;
				if (Timer > 1f)
				{
					Yandere.ShoulderCamera.HeartbrokenCamera.SetActive(value: true);
					Yandere.ShoulderCamera.enabled = false;
					Yandere.RPGCamera.enabled = false;
					Yandere.Jukebox.GameOver();
					Yandere.enabled = false;
					Yandere.EmptyHands();
					Yandere.Lost = true;
					Phase++;
				}
			}
		}
		else if (Path == 6)
		{
			if (Phase != 4)
			{
				return;
			}
			if (Yandere.CharacterAnimation["Yandere_CombatF"].time > 6.33333f)
			{
				MainCamera.transform.parent = null;
				Strength += Time.deltaTime;
				MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, StartPoint, Time.deltaTime * Strength);
				RedVignette.color = Vector4.Lerp(RedVignette.color, new Vector4(1f, 0f, 0f, 0f), Time.deltaTime * Strength);
				Zoom = false;
			}
			if (Delinquent.CharacterAnimation[Prefix + "Delinquent_CombatF"].time > 7.83333f)
			{
				Delinquent.MyWeapon.transform.parent = Delinquent.WeaponBagParent;
				Delinquent.MyWeapon.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
				Delinquent.MyWeapon.transform.localPosition = new Vector3(0f, 0f, 0f);
			}
			if (Yandere.CharacterAnimation["Yandere_CombatF"].time > Yandere.CharacterAnimation["Yandere_CombatF"].length)
			{
				if (!Practice)
				{
					Yandere.Subtitle.UpdateLabel(SubtitleType.DelinquentWin, 0, 5f);
					Yandere.IdleAnim = "f02_idleInjured_00";
					Yandere.WalkAnim = "f02_walkInjured_00";
					Yandere.OriginalIdleAnim = Yandere.IdleAnim;
					Yandere.OriginalWalkAnim = Yandere.WalkAnim;
					Yandere.StudentManager.Rest.Prompt.enabled = true;
				}
				else
				{
					PracticeWindow.Finish();
					Yandere.Health = 10;
					Practice = false;
				}
				Yandere.CharacterAnimation.CrossFade(Yandere.IdleAnim);
				Yandere.DelinquentFighting = false;
				Yandere.RPGCamera.enabled = true;
				Yandere.CannotRecover = false;
				Yandere.ChaseTimer = 0f;
				Yandere.CanMove = true;
				Yandere.Chased = false;
				Delinquent.Threatened = false;
				Delinquent.Fighting = false;
				Delinquent.Injured = false;
				Delinquent.Alarmed = false;
				Delinquent.Routine = true;
				Delinquent.enabled = true;
				Delinquent.Distracted = false;
				Delinquent.Shoving = false;
				Delinquent.Paired = false;
				Delinquent.Patience = 5;
				ResetValues();
				Yandere.StudentManager.UpdateStudents();
			}
		}
		else
		{
			if (Path != 7)
			{
				return;
			}
			if (Yandere.CharacterAnimation["f02_stopFighting_00"].time > 1f)
			{
				MainCamera.transform.parent = null;
				Strength += Time.deltaTime;
				MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, StartPoint, Time.deltaTime * Strength);
				RedVignette.color = Vector4.Lerp(RedVignette.color, new Vector4(1f, 0f, 0f, 0f), Time.deltaTime * Strength);
				Zoom = false;
			}
			if (Delinquent.CharacterAnimation[StopFightingAnim].time > 3.83333f)
			{
				Delinquent.MyWeapon.transform.parent = Delinquent.WeaponBagParent;
				Delinquent.MyWeapon.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
				Delinquent.MyWeapon.transform.localPosition = new Vector3(0f, 0f, 0f);
			}
			if (Yandere.CharacterAnimation["f02_stopFighting_00"].time > Yandere.CharacterAnimation["f02_stopFighting_00"].length)
			{
				if (Delinquent.Phase == 0)
				{
					Delinquent.Phase++;
				}
				Delinquent.GetDestinations();
				Delinquent.CurrentDestination = Delinquent.Destinations[Delinquent.Phase];
				Delinquent.Pathfinding.target = Delinquent.Destinations[Delinquent.Phase];
				if (Delinquent.CurrentDestination == null)
				{
					Debug.Log("Manually setting Delinquent's destination to locker, to fix a saving/loading bug.");
					Delinquent.CurrentDestination = Delinquent.Destinations[1];
					Delinquent.Pathfinding.target = Delinquent.Destinations[1];
				}
				ReleaseYandere();
				Delinquent.Threatened = false;
				Delinquent.Fighting = false;
				Delinquent.Alarmed = false;
				Delinquent.enabled = true;
				Delinquent.Distracted = false;
				Delinquent.Shoving = false;
				Delinquent.Paired = false;
				Delinquent.Routine = true;
				Delinquent.Patience = 5;
				Delinquent = null;
				DisablePrompts();
				ResetValues();
				Yandere.StudentManager.UpdateStudents();
			}
		}
	}

	private void Slowdown()
	{
		Time.timeScale = SlowdownFactor * Difficulty;
		MyVocals.pitch = SlowdownFactor * Difficulty;
		MyAudio.pitch = SlowdownFactor * Difficulty;
	}

	private void ChooseButton()
	{
		ButtonPrompts[1].enabled = false;
		ButtonPrompts[2].enabled = false;
		ButtonPrompts[3].enabled = false;
		ButtonPrompts[4].enabled = false;
		ButtonPrompts[1].alpha = 0f;
		ButtonPrompts[2].alpha = 0f;
		ButtonPrompts[3].alpha = 0f;
		ButtonPrompts[4].alpha = 0f;
		int buttonID = ButtonID;
		while (ButtonID == buttonID)
		{
			ButtonID = Random.Range(1, 5);
		}
		if (ButtonID == 1)
		{
			CurrentButton = InputNames.Xbox_A;
		}
		else if (ButtonID == 2)
		{
			CurrentButton = InputNames.Xbox_B;
		}
		else if (ButtonID == 3)
		{
			CurrentButton = InputNames.Xbox_X;
		}
		else if (ButtonID == 4)
		{
			CurrentButton = InputNames.Xbox_Y;
		}
		ButtonPrompts[ButtonID].enabled = true;
		ButtonPrompts[ButtonID].alpha = 1f;
		Circle.enabled = true;
		BG.enabled = true;
		Timer = StartTime;
	}

	public void DisablePrompts()
	{
		ButtonPrompts[1].enabled = false;
		ButtonPrompts[2].enabled = false;
		ButtonPrompts[3].enabled = false;
		ButtonPrompts[4].enabled = false;
		ButtonPrompts[1].alpha = 0f;
		ButtonPrompts[2].alpha = 0f;
		ButtonPrompts[3].alpha = 0f;
		ButtonPrompts[4].alpha = 0f;
		Circle.fillAmount = 1f;
		Circle.enabled = false;
		BG.enabled = false;
		Success = false;
		ButtonID = 0;
	}

	private void AdjustMidpoint()
	{
		if (Strength == 0f)
		{
			if (!KnockedOut)
			{
				Midpoint.position = (Delinquent.Hips.position - Yandere.Hips.position) * 0.5f + Yandere.Hips.position;
				Midpoint.position += new Vector3(0f, 0.25f, 0f);
			}
			else
			{
				Midpoint.position = Vector3.Lerp(Midpoint.position, Yandere.Hips.position + new Vector3(0f, 0.5f, 0f), Time.deltaTime);
			}
		}
		else
		{
			Midpoint.position = Vector3.Lerp(Midpoint.position, Yandere.RPGCamera.cameraPivot.position, Time.deltaTime * Strength);
		}
		MainCamera.LookAt(Midpoint.position);
	}

	public void Stop()
	{
		if (Delinquent != null)
		{
			Delinquent.CharacterAnimation.CrossFade("delinquentCombatIdle_00");
			ResetValues();
			base.enabled = false;
		}
	}

	public void ResetValues()
	{
		Label.text = "State: A";
		Strength = 0f;
		Strike = 0;
		Phase = 0;
		Path = 0;
		MyAudio.clip = CombatSFX[Path];
		MyAudio.time = 0f;
		MyAudio.Stop();
		MyVocals.clip = Vocals[Path];
		MyVocals.time = 0f;
		MyVocals.Stop();
		Delinquent = null;
	}

	public void ReleaseYandere()
	{
		Debug.Log("Yandere-chan has been released from combat.");
		Yandere.CharacterAnimation.CrossFade(Yandere.IdleAnim);
		Yandere.DelinquentFighting = false;
		Yandere.RPGCamera.enabled = true;
		Yandere.CannotRecover = false;
		Yandere.Pursuer = null;
		Yandere.ChaseTimer = 0f;
		Yandere.CanMove = true;
		Yandere.Chased = false;
		CombatPanel.alpha = 0f;
	}
}
