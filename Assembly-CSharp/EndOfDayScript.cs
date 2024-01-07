using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfDayScript : MonoBehaviour
{
	public RemovableItemManagerScript RemovableItemManager;

	public SecuritySystemScript SecuritySystem;

	public StudentManagerScript StudentManager;

	public WeaponManagerScript WeaponManager;

	public ClubManagerScript ClubManager;

	public HeartbrokenScript Heartbroken;

	public IncineratorScript Incinerator;

	public LoveManagerScript LoveManager;

	public RummageSpotScript RummageSpot;

	public SchoolMangaScript SchoolManga;

	public VoidGoddessScript VoidGoddess;

	public WoodChipperScript WoodChipper;

	public ReputationScript Reputation;

	public DumpsterLidScript Dumpster;

	public CounselorScript Counselor;

	public WeaponScript MurderWeapon;

	public TranqCaseScript TranqCase;

	public AudioListener MyListener;

	public YandereScript Yandere;

	public RagdollScript Corpse;

	public StudentScript Senpai;

	public StudentScript Patsy;

	public PoliceScript Police;

	public Transform EODCamera;

	public StudentScript Rival;

	public ClassScript Class;

	public ClockScript Clock;

	public PlantScript Plant;

	public JsonScript JSON;

	public GrowStationScript[] GrowStations;

	public GardenHoleScript[] GardenHoles;

	public StudentScript[] WitnessList;

	public Animation[] CopAnimation;

	public GameObject MainCamera;

	public UISprite EndOfDayDarkness;

	public UILabel Label;

	public bool RivalDismemberedAndIncinerated;

	public bool RivalBuried;

	public bool CurrentMurderWeaponKilledRival;

	public bool GrudgeConversationHappened;

	public bool LearnedAboutPhotographer;

	public bool InvolvementNotSuspected;

	public bool ExplosiveDeviceUsed;

	public bool PreviouslyActivated;

	public bool LearnedOsanaInfo1;

	public bool LearnedOsanaInfo2;

	public bool GoToSuicideScene;

	public bool RivalArrested;

	public bool PoliceArrived;

	public bool KillerIsDead;

	public bool RaibaruLoner;

	public bool StopMourning;

	public bool FunGameOver;

	public bool HeardMegami;

	public bool ClubClosed;

	public bool ClubKicked;

	public bool ErectFence;

	public bool PoolEvent;

	public bool GameOver;

	public bool Darken;

	public float DistanceToMoveForward;

	public int ClothingWithRedPaint;

	public int ShrineItemsCollected;

	public int WeaponWitnessed;

	public int BloodWitnessed;

	public int FragileTarget;

	public int EyeWitnesses;

	public int NewFriends;

	public int ClubLimit;

	public int DeadPerps;

	public int Arrests;

	public int Corpses;

	public int Victims;

	public int Weapons;

	public int Phase = 1;

	public int MatchmakingGifts;

	public int SenpaiGifts;

	public int ArticleID;

	public int WeaponID;

	public int ArrestID;

	public int ClubID;

	public int ID;

	public string[] ClubNames;

	public int[] VictimArray;

	public ClubType[] ClubArray;

	private SaveFile saveFile;

	public GameObject TextWindow;

	public GameObject Cops;

	public GameObject SearchingCop;

	public GameObject MurderScene;

	public GameObject ShruggingCops;

	public GameObject TabletCop;

	public GameObject SecuritySystemScene;

	public GameObject OpenTranqCase;

	public GameObject ClosedTranqCase;

	public GameObject GaudyRing;

	public GameObject AnswerSheet;

	public GameObject Fence;

	public GameObject SCP;

	public GameObject Headmaster;

	public GameObject ArrestingCops;

	public GameObject Mask;

	public GameObject EyeWitnessScene;

	public GameObject ScaredCops;

	public GameObject EightiesGaudyRing;

	public StudentScript KidnappedVictim;

	public Renderer TabletPortrait;

	public Transform CardboardBox;

	public RivalEliminationType RivalEliminationMethod;

	public Vector3 YandereInitialPosition;

	public Quaternion YandereInitialRotation;

	public bool[] StudentsToArrest;

	public string Protagonist = "Ayano";

	public string RivalName = "";

	public string[] EightiesRivalNames;

	public string[] RivalNames;

	public AudioClip EightiesBGM;

	public string[] VtuberNames;

	public bool WeaponsChecked;

	public string AchievementToGrant;

	public void Start()
	{
		Debug.Log("The End-of-Day GameObject has just fired its Start() function.");
		StudentManager.PlazaOccluder.gameObject.SetActive(value: false);
		VoidGoddess.Start();
		GameGlobals.PoliceYesterday = false;
		YandereInitialPosition = Yandere.transform.position;
		YandereInitialRotation = Yandere.transform.rotation;
		if (GameGlobals.SenpaiMourning)
		{
			StopMourning = true;
		}
		Yandere.MainCamera.gameObject.SetActive(value: false);
		EndOfDayDarkness.color = new Color(EndOfDayDarkness.color.r, EndOfDayDarkness.color.g, EndOfDayDarkness.color.b, 1f);
		PreviouslyActivated = true;
		GetComponent<AudioSource>().volume = 0f;
		Clock.enabled = false;
		Clock.MainLight.color = new Color(1f, 1f, 1f, 1f);
		RenderSettings.ambientLight = new Color(0.75f, 0.75f, 0.75f, 1f);
		RenderSettings.skybox.SetColor("_Tint", new Color(0.5f, 0.5f, 0.5f));
		UpdateScene();
		CopAnimation[5]["idleShort_00"].speed = UnityEngine.Random.Range(0.9f, 1.1f);
		CopAnimation[6]["idleShort_00"].speed = UnityEngine.Random.Range(0.9f, 1.1f);
		CopAnimation[7]["idleShort_00"].speed = UnityEngine.Random.Range(0.9f, 1.1f);
		Time.timeScale = 1f;
		for (int i = 1; i < 6; i++)
		{
			Yandere.CharacterAnimation[Yandere.CreepyIdles[i]].weight = 0f;
			Yandere.CharacterAnimation[Yandere.CreepyWalks[i]].weight = 0f;
		}
		for (int j = 1; j < StudentManager.AllBuckets.Length; j++)
		{
			if (StudentManager.AllBuckets[j] != null && StudentManager.AllBuckets[j].Bloodiness > 50f)
			{
				StudentManager.AllBuckets[j].transform.parent = Police.BloodParent;
			}
		}
		ClothingWithRedPaint += Incinerator.ClothingWithRedPaint;
		foreach (Transform item in Police.BloodParent)
		{
			PickUpScript component = item.gameObject.GetComponent<PickUpScript>();
			if (component != null && component.RedPaint)
			{
				ClothingWithRedPaint++;
			}
		}
		int num = 0;
		if (Police.Corpses > 1)
		{
			RagdollScript[] corpseList = Police.CorpseList;
			foreach (RagdollScript ragdollScript in corpseList)
			{
				if (ragdollScript != null && (ragdollScript.MurderSuicide || ragdollScript.Student.MurderedByStudent))
				{
					num++;
				}
			}
		}
		if (num > 1)
		{
			Police.MurderSuicideScene = true;
		}
		ClubLimit = ClubArray.Length;
		if (!GameGlobals.Eighties)
		{
			ClubLimit--;
		}
		else
		{
			GetComponent<AudioSource>().clip = EightiesBGM;
			GetComponent<AudioSource>().Play();
		}
		if (!Counselor.Lecturing)
		{
			EODCamera.localPosition = new Vector3(1f, 1.8f, -2.5f);
			EODCamera.localEulerAngles = new Vector3(22.5f, -22.5f, 0f);
			TextWindow.SetActive(value: true);
		}
		if (Yandere.VtuberID > 0)
		{
			Protagonist = VtuberNames[Yandere.VtuberID];
		}
		if (Yandere.RedPaint)
		{
			ClothingWithRedPaint++;
		}
		StudentManager.RemoveLowPolyEffect();
	}

	private void Update()
	{
		Yandere.UpdateSlouch();
		if (Input.GetKeyDown("space"))
		{
			EndOfDayDarkness.color = new Color(0f, 0f, 0f, 1f);
			Darken = true;
		}
		if (EndOfDayDarkness.color.a < 0.001f && Input.GetButtonDown(InputNames.Xbox_A))
		{
			Darken = true;
		}
		if (Darken)
		{
			EndOfDayDarkness.color = new Color(EndOfDayDarkness.color.r, EndOfDayDarkness.color.g, EndOfDayDarkness.color.b, Mathf.MoveTowards(EndOfDayDarkness.color.a, 1f, Time.deltaTime * 2f));
			if (EndOfDayDarkness.color.a > 0.999f)
			{
				if (Senpai == null && StudentManager.Students[1] != null)
				{
					Senpai = StudentManager.Students[1];
					Senpai.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					Senpai.CharacterAnimation.enabled = true;
				}
				if (Senpai != null)
				{
					Senpai.gameObject.SetActive(value: false);
				}
				if (Rival == null && StudentManager.Students[StudentManager.RivalID] != null)
				{
					Rival = StudentManager.Students[StudentManager.RivalID];
					Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					Rival.CharacterAnimation.enabled = true;
				}
				if (Rival != null)
				{
					Rival.gameObject.SetActive(value: false);
				}
				Yandere.transform.parent = null;
				Yandere.transform.position = new Vector3(0f, 0f, -75f);
				Yandere.gameObject.SetActive(value: true);
				EODCamera.localPosition = new Vector3(1f, 1.8f, -2.5f);
				EODCamera.localEulerAngles = new Vector3(22.5f, -22.5f, 0f);
				if (KidnappedVictim != null)
				{
					KidnappedVictim.gameObject.SetActive(value: false);
				}
				if (StudentManager.Students[StudentManager.SuitorID] != null)
				{
					StudentManager.Students[StudentManager.SuitorID].gameObject.SetActive(value: false);
				}
				CardboardBox.parent = null;
				Yandere.LifeNotePen.SetActive(value: false);
				SearchingCop.SetActive(value: false);
				MurderScene.SetActive(value: false);
				Cops.SetActive(value: false);
				TabletCop.SetActive(value: false);
				ShruggingCops.SetActive(value: false);
				SecuritySystemScene.SetActive(value: false);
				OpenTranqCase.SetActive(value: false);
				ClosedTranqCase.SetActive(value: false);
				GaudyRing.SetActive(value: false);
				AnswerSheet.SetActive(value: false);
				Fence.SetActive(value: false);
				SCP.SetActive(value: false);
				Headmaster.SetActive(value: false);
				ArrestingCops.SetActive(value: false);
				Mask.SetActive(value: false);
				EyeWitnessScene.SetActive(value: false);
				ScaredCops.SetActive(value: false);
				EightiesGaudyRing.SetActive(value: false);
				Yandere.LookAt.enabled = false;
				if (WitnessList[1] != null)
				{
					WitnessList[1].gameObject.SetActive(value: false);
				}
				if (WitnessList[2] != null)
				{
					WitnessList[2].gameObject.SetActive(value: false);
				}
				if (WitnessList[3] != null)
				{
					WitnessList[3].gameObject.SetActive(value: false);
				}
				if (WitnessList[4] != null)
				{
					WitnessList[4].gameObject.SetActive(value: false);
				}
				if (WitnessList[5] != null)
				{
					WitnessList[5].gameObject.SetActive(value: false);
				}
				if (Patsy != null)
				{
					Patsy.gameObject.SetActive(value: false);
				}
				if (!GameOver)
				{
					Darken = false;
					UpdateScene();
				}
				else
				{
					Heartbroken.transform.parent.transform.parent = null;
					Heartbroken.transform.parent.gameObject.SetActive(value: true);
					Heartbroken.Cursor.HeartbrokenCamera.depth = 6f;
					if (Police.Deaths + PlayerGlobals.Kills > 50)
					{
						Heartbroken.Noticed = true;
					}
					else
					{
						Heartbroken.Noticed = false;
						Heartbroken.Arrested = true;
					}
					MainCamera.SetActive(value: false);
					base.gameObject.SetActive(value: false);
					Yandere.MyListener.enabled = true;
					Time.timeScale = 1f;
				}
				if (RivalName == "")
				{
					if (StudentManager.Eighties)
					{
						Protagonist = "Ryoba";
						RivalName = EightiesRivalNames[DateGlobals.Week];
						if (StudentManager.CustomMode)
						{
							RivalName = JSON.Students[10 + DateGlobals.Week].Name;
						}
					}
					else
					{
						RivalName = RivalNames[DateGlobals.Week];
					}
				}
				if (Yandere.VtuberID > 0)
				{
					Protagonist = VtuberNames[Yandere.VtuberID];
				}
				if (Yandere.Mop != null)
				{
					Yandere.EmptyHands();
				}
			}
			if (StudentManager.CustomMode)
			{
				Protagonist = JSON.Students[0].Name;
			}
		}
		else
		{
			EndOfDayDarkness.color = new Color(EndOfDayDarkness.color.r, EndOfDayDarkness.color.g, EndOfDayDarkness.color.b, Mathf.MoveTowards(EndOfDayDarkness.color.a, 0f, Time.deltaTime * 2f));
		}
		AudioSource component = GetComponent<AudioSource>();
		component.volume = Mathf.MoveTowards(component.volume, 1f, Time.deltaTime * 2f);
		if (WitnessList[2] != null)
		{
			WitnessList[2].CharacterAnimation.Play(WitnessList[2].IdleAnim);
		}
		if (WitnessList[3] != null)
		{
			WitnessList[3].CharacterAnimation.Play(WitnessList[3].IdleAnim);
		}
		if (WitnessList[4] != null)
		{
			WitnessList[4].CharacterAnimation.Play(WitnessList[4].IdleAnim);
		}
		if (WitnessList[5] != null)
		{
			WitnessList[5].CharacterAnimation.Play(WitnessList[5].IdleAnim);
		}
		if (Phase == 17)
		{
			EODCamera.position = ClubManager.ClubVantages[ClubID].position;
			EODCamera.eulerAngles = ClubManager.ClubVantages[ClubID].eulerAngles;
			EODCamera.Translate(Vector3.forward * 0f, Space.Self);
		}
	}

	public void UpdateScene()
	{
		Label.color = new Color(0f, 0f, 0f, 1f);
		if (Phase != 14)
		{
			for (int i = 0; i < Yandere.Weapon.Length; i++)
			{
				if (Yandere.Weapon[i] != null && Yandere.Weapon[i].Bloody)
				{
					Yandere.Weapon[i].Drop();
				}
			}
			if (!WeaponsChecked)
			{
				Debug.Log("We're counting the number of bloody weapons at school right now...");
				WeaponManager.CheckWeapons();
				WeaponsChecked = true;
				Debug.Log(WeaponManager.MurderWeapons + " bloody weapons were found.");
			}
			for (ID = 0; ID < WeaponManager.Weapons.Length; ID++)
			{
				if (WeaponManager.Weapons[ID] != null)
				{
					WeaponManager.Weapons[ID].gameObject.SetActive(value: false);
				}
			}
		}
		if (Input.GetKeyDown(KeyCode.Backspace))
		{
			Finish();
		}
		if (Phase == 1)
		{
			Time.timeScale = 1f;
			CopAnimation[1]["walk_00"].speed = UnityEngine.Random.Range(0.9f, 1.1f);
			CopAnimation[2]["walk_00"].speed = UnityEngine.Random.Range(0.9f, 1.1f);
			CopAnimation[3]["walk_00"].speed = UnityEngine.Random.Range(0.9f, 1.1f);
			Counselor.LectureID = 0;
			Cops.SetActive(value: true);
			bool flag = false;
			if (Yandere.Egg && !flag)
			{
				Label.text = "The police arrive at school.";
				Phase = 999;
				return;
			}
			if (Police.PoisonScene)
			{
				Label.text = "The police and the paramedics arrive at school.";
				Phase = 103;
				return;
			}
			if (Police.DrownVictims == 1)
			{
				Label.text = "The police arrive at school.";
				Phase = 104;
				return;
			}
			if (Police.ElectroScene)
			{
				Label.text = "The police arrive at school.";
				Phase = 105;
				return;
			}
			if (Police.MurderSuicideScene)
			{
				Label.text = "The police arrive at school, and discover what appears to be the scene of a murder-suicide.";
				Phase++;
				return;
			}
			Label.text = "The police arrive at school.";
			if (Police.SuicideScene)
			{
				Phase = 102;
			}
			else
			{
				Phase++;
			}
		}
		else if (Phase == 2)
		{
			if (Police.Corpses == 0)
			{
				Debug.Log("Zero corpses were present at school.");
				if (!Police.PoisonScene && !Police.SuicideScene)
				{
					if (Police.LimbParent.childCount > 0 || Police.GarbageParent.childCount > 0)
					{
						Debug.Log("At least one severed limb was present at school.");
						foreach (Transform item in Police.LimbParent)
						{
							if (!(item != null))
							{
								continue;
							}
							BodyPartScript component = item.gameObject.GetComponent<BodyPartScript>();
							if (component != null)
							{
								if (component.StudentID == StudentManager.RivalID)
								{
									Debug.Log("It was a rival's limb!");
									DetermineHowRivalDied(StudentManager.Students[StudentManager.RivalID].Ragdoll);
								}
								else if (component.StudentID > 10 && component.StudentID < DateGlobals.Week + 10)
								{
									Debug.Log("A previous rival died today.");
									SetFormerRivalDeath(component.StudentID - 10, StudentManager.Students[component.StudentID]);
								}
							}
						}
						if (Police.LimbParent.childCount + Police.GarbageParent.childCount == 1)
						{
							Label.text = "The police find a severed body part at school.";
						}
						else
						{
							Label.text = "The police find multiple severed body parts at school.";
						}
						MurderScene.SetActive(value: true);
					}
					else
					{
						SearchingCop.SetActive(value: true);
						if (Police.BloodParent.childCount - ClothingWithRedPaint > 0)
						{
							Label.text = "The police find mysterious blood stains, but are unable to locate any corpses on school grounds.";
						}
						else if (ClothingWithRedPaint == 0)
						{
							Label.text = "The police are unable to locate any corpses on school grounds.";
						}
						else
						{
							Label.text = "The police find clothing that is stained with red paint, but are unable to locate any actual blood stains, and cannot locate any corpses, either.";
						}
					}
					Phase++;
				}
				else
				{
					SearchingCop.SetActive(value: true);
					Label.text = "The police are unable to locate any other corpses on school grounds.";
					Phase++;
				}
				return;
			}
			Debug.Log("Corpses were present at school.");
			MurderScene.SetActive(value: true);
			List<string> list = new List<string>();
			RagdollScript[] corpseList = Police.CorpseList;
			foreach (RagdollScript ragdollScript in corpseList)
			{
				if (ragdollScript != null && !ragdollScript.Disposed)
				{
					if (ragdollScript.Student.StudentID == StudentManager.RivalID)
					{
						DetermineHowRivalDied(ragdollScript);
					}
					else if (ragdollScript.Student.StudentID > 10 && ragdollScript.Student.StudentID < DateGlobals.Week + 10)
					{
						Debug.Log("A previous rival's corpse has been discovered.");
						SetFormerRivalDeath(ragdollScript.Student.StudentID - 10, ragdollScript.Student);
					}
					VictimArray[Corpses] = ragdollScript.Student.StudentID;
					list.Add(ragdollScript.Student.Name);
					Corpses++;
				}
			}
			list.Sort();
			string text = "The police discover the corpse" + ((list.Count == 1) ? string.Empty : "s") + " of ";
			if (list.Count == 1)
			{
				Label.text = text + list[0] + ".";
			}
			else if (list.Count == 2)
			{
				Label.text = text + list[0] + " and " + list[1] + ".";
			}
			else if (list.Count < 6)
			{
				Label.text = "The police discover multiple corpses on school grounds.";
				StringBuilder stringBuilder = new StringBuilder();
				for (int k = 0; k < list.Count - 1; k++)
				{
					stringBuilder.Append(list[k] + ", ");
				}
				stringBuilder.Append("and " + list[list.Count - 1] + ".");
				Label.text = text + stringBuilder.ToString();
			}
			else
			{
				Label.text = "The police discover more than five corpses on school grounds.";
			}
			Phase++;
		}
		else if (Phase == 3)
		{
			if (WeaponManager.MurderWeapons == 0)
			{
				ShruggingCops.SetActive(value: true);
				if (Weapons == 0)
				{
					if (Police.Corpses == 1 && Police.CorpseList[0] != null && Police.CorpseList[0].Student.CrushedByBucket)
					{
						Label.text = "The police can tell that the victim was killed by a bucket of heavy weights that was dropped from above, but they are unable to collect sufficient evidence to identify a culprit.";
						Phase += 2;
					}
					else if (PoolEvent)
					{
						Label.text = "The police can tell that Osana was murdered by someone who tied a heavy weight to her hair and pushed the weight into the school pool to drown her, but they have no way of knowing who did it.";
						Phase += 2;
					}
					else
					{
						Label.text = "The police are unable to locate any murder weapons.";
						Phase += 2;
					}
				}
				else
				{
					Phase += 2;
					UpdateScene();
				}
				return;
			}
			MurderWeapon = null;
			for (ID = 0; ID < WeaponManager.Weapons.Length; ID++)
			{
				if (MurderWeapon == null)
				{
					WeaponScript weaponScript = WeaponManager.Weapons[ID];
					if (weaponScript != null && !weaponScript.Disposed && weaponScript.Blood.enabled)
					{
						if (!weaponScript.AlreadyExamined)
						{
							WeaponManager.MurderWeapons--;
							weaponScript.gameObject.SetActive(value: true);
							weaponScript.AlreadyExamined = true;
							MurderWeapon = weaponScript;
							WeaponID = ID;
						}
						else
						{
							weaponScript.gameObject.SetActive(value: false);
						}
					}
				}
			}
			List<string> list2 = new List<string>();
			CurrentMurderWeaponKilledRival = false;
			for (ID = 0; ID < MurderWeapon.Victims.Length; ID++)
			{
				if (MurderWeapon.Victims[ID])
				{
					list2.Add(JSON.Students[ID].Name);
					if (MurderWeapon.Victims[StudentManager.RivalID])
					{
						CurrentMurderWeaponKilledRival = true;
					}
				}
			}
			list2.Sort();
			Victims = list2.Count;
			string text2 = MurderWeapon.Name;
			string text3 = ((text2[text2.Length - 1] != 's') ? ("a " + text2.ToLower() + " that is") : (text2.ToLower() + " that are"));
			string text4 = "The police discover " + text3 + " stained with the blood of ";
			if (list2.Count == 1)
			{
				Label.text = text4 + list2[0] + ".";
			}
			else if (list2.Count == 2)
			{
				Label.text = text4 + list2[0] + " and " + list2[1] + ".";
			}
			else
			{
				StringBuilder stringBuilder2 = new StringBuilder();
				for (int l = 0; l < list2.Count - 1; l++)
				{
					stringBuilder2.Append(list2[l] + ", ");
				}
				stringBuilder2.Append("and " + list2[list2.Count - 1] + ".");
				Label.text = text4 + stringBuilder2.ToString();
			}
			Weapons++;
			Phase++;
			MurderWeapon.transform.parent = base.transform;
			MurderWeapon.transform.localPosition = new Vector3(0.6f, 1.4f, -1.5f);
			MurderWeapon.transform.localEulerAngles = new Vector3(-45f, 90f, -90f);
			MurderWeapon.MyRigidbody.useGravity = false;
			MurderWeapon.Rotate = true;
		}
		else if (Phase == 4)
		{
			if (MurderWeapon.FingerprintID == 0)
			{
				ShruggingCops.SetActive(value: true);
				Label.text = "The police find no fingerprints on the weapon.";
				Phase = 3;
			}
			else if (MurderWeapon.FingerprintID == 100)
			{
				TeleportYandere();
				Yandere.CharacterAnimation.Play("f02_disappointed_00");
				if (Yandere.StudentManager.Eighties)
				{
					Yandere.LoseGentleEyes();
				}
				Label.text = "The police find " + Protagonist + "'s fingerprints on the weapon.";
				Phase = 100;
			}
			else
			{
				int fingerprintID = WeaponManager.Weapons[WeaponID].FingerprintID;
				TabletCop.SetActive(value: true);
				CopAnimation[4]["scienceTablet_00"].speed = 0f;
				TabletPortrait.material.mainTexture = VoidGoddess.Portraits[fingerprintID].mainTexture;
				Label.text = "The police find the fingerprints of " + JSON.Students[fingerprintID].Name + " on the weapon.";
				Phase = 101;
			}
		}
		else if (Phase == 5)
		{
			if (Police.PhotoEvidence > 0)
			{
				TeleportYandere();
				Yandere.CharacterAnimation.Play("f02_disappointed_00");
				if (Yandere.StudentManager.Eighties)
				{
					Yandere.LoseGentleEyes();
				}
				ShruggingCops.SetActive(value: false);
				Label.text = "The police find a smartphone with photographic evidence of " + Protagonist + " committing a crime.";
				Phase = 100;
			}
			else
			{
				Phase++;
				UpdateScene();
			}
		}
		else if (Phase == 6)
		{
			if (SchoolGlobals.HighSecurity)
			{
				SecuritySystemScene.SetActive(value: true);
				if (!SecuritySystem.Evidence)
				{
					Label.text = "The police investigate the security camera recordings, but cannot find anything incriminating in the footage.";
					Phase++;
				}
				else if (!SecuritySystem.Masked)
				{
					Label.text = "The police investigate the security camera recordings, and find incriminating footage of " + Protagonist + ".";
					Phase = 100;
				}
				else
				{
					Label.text = "The police investigate the security camera recordings, and find footage of a suspicious masked person.";
					Police.MaskReported = true;
					Phase++;
				}
			}
			else
			{
				Phase++;
				UpdateScene();
			}
		}
		else if (Phase == 7)
		{
			for (ID = 1; ID < StudentManager.Students.Length; ID++)
			{
				if (StudentManager.Students[ID] != null && StudentManager.Students[ID].WitnessedMurder && StudentManager.Students[ID].Alive && StudentManager.Students[ID].Persona != PersonaType.Coward && StudentManager.Students[ID].Persona != PersonaType.Fragile && StudentManager.Students[ID].Persona != PersonaType.Spiteful && StudentManager.Students[ID].Persona != PersonaType.Evil && StudentManager.Students[ID].Club != ClubType.Delinquent && !StudentManager.Students[ID].SawMask)
				{
					EyeWitnesses++;
					WitnessList[EyeWitnesses] = StudentManager.Students[ID];
				}
			}
			if (EyeWitnesses > 0)
			{
				DisableThings(WitnessList[1]);
				DisableThings(WitnessList[2]);
				DisableThings(WitnessList[3]);
				DisableThings(WitnessList[4]);
				DisableThings(WitnessList[5]);
				WitnessList[1].transform.localPosition = Vector3.zero;
				if (WitnessList[2] != null)
				{
					WitnessList[2].transform.localPosition = new Vector3(-1f, 0f, -0.5f);
				}
				if (WitnessList[3] != null)
				{
					WitnessList[3].transform.localPosition = new Vector3(1f, 0f, -0.5f);
				}
				if (WitnessList[4] != null)
				{
					WitnessList[4].transform.localPosition = new Vector3(-2f, 0f, -1f);
				}
				if (WitnessList[5] != null)
				{
					WitnessList[5].transform.localPosition = new Vector3(1.5f, 0f, -1f);
				}
				if (WitnessList[1].Male)
				{
					WitnessList[1].CharacterAnimation.Play("carefreeTalk_02");
				}
				else
				{
					WitnessList[1].CharacterAnimation.Play("f02_carefreeTalk_02");
				}
				EyeWitnessScene.SetActive(value: true);
				if (EyeWitnesses == 1)
				{
					Label.text = "One student accuses " + Protagonist + " of murder, but nobody else can corroborate that students' claims, so the police are unable to develop reasonable justification to arrest " + Protagonist + ".";
					Phase++;
				}
				else if (EyeWitnesses < 5)
				{
					Label.text = "Several students accuse " + Protagonist + " of murder, but there are not enough witnesses to provide the police with reasonable justification to arrest her.";
					Phase++;
				}
				else
				{
					Label.text = "Numerous students accuse " + Protagonist + " of murder, providing the police with enough justification to arrest her.";
					Phase = 100;
				}
			}
			else
			{
				Phase++;
				UpdateScene();
			}
		}
		else if (Phase == 8)
		{
			ShruggingCops.SetActive(value: false);
			if (Yandere.Sanity > 33.33333f)
			{
				if ((Yandere.Bloodiness > 0f && !Yandere.RedPaint) || (Yandere.Gloved && Yandere.Gloves.Blood.enabled))
				{
					if (Arrests == 0)
					{
						TeleportYandere();
						Yandere.CharacterAnimation.Play("f02_disappointed_00");
						if (Yandere.StudentManager.Eighties)
						{
							Yandere.LoseGentleEyes();
						}
						Label.text = "The police notice that " + Protagonist + "'s clothing is bloody. They confirm that the blood is not hers. " + Protagonist + " is unable to convince the police that she did not commit murder.";
						Phase = 100;
					}
					else
					{
						TeleportYandere();
						Yandere.CharacterAnimation["YandereConfessionRejected"].time = 4f;
						Yandere.CharacterAnimation.Play("YandereConfessionRejected");
						Label.text = "The police notice that " + Protagonist + "'s clothing is bloody. They confirm that the blood is not hers. " + Protagonist + " is able to convince the police that she was splashed with blood while witnessing a murder.";
						if (!TranqCase.Occupied)
						{
							Phase += 2;
						}
						else
						{
							Phase++;
						}
					}
				}
				else if (Police.BloodyClothing - ClothingWithRedPaint > 0)
				{
					TeleportYandere();
					Yandere.CharacterAnimation.Play("f02_disappointed_00");
					if (Yandere.StudentManager.Eighties)
					{
						Yandere.LoseGentleEyes();
					}
					Label.text = "The police find bloody clothing that has traces of " + Protagonist + "'s DNA. " + Protagonist + " is unable to convince the police that she did not commit murder.";
					Phase = 100;
				}
				else
				{
					TeleportYandere();
					Yandere.CharacterAnimation["YandereConfessionRejected"].time = 4f;
					Yandere.CharacterAnimation.Play("YandereConfessionRejected");
					Label.text = "The police question all students in the school, including " + Protagonist + ". The police are unable to link " + Protagonist + " to any crimes.";
					if (!TranqCase.Occupied)
					{
						Phase += 2;
					}
					else if (TranqCase.VictimID == ArrestID)
					{
						Phase += 2;
					}
					else
					{
						Phase++;
					}
					if (Yandere.StudentManager.Eighties)
					{
						Yandere.LoseGentleEyes();
					}
				}
			}
			else
			{
				TeleportYandere();
				Yandere.CharacterAnimation.Play("f02_disappointed_00");
				if (Yandere.StudentManager.Eighties)
				{
					Yandere.LoseGentleEyes();
				}
				if (Yandere.Bloodiness == 0f)
				{
					Label.text = "The police question " + Protagonist + ", who exhibits extremely unusual behavior. The police decide to investigate " + Protagonist + " further, and eventually learn of her crimes.";
					Phase = 100;
				}
				else
				{
					Label.text = "The police notice that " + Protagonist + " is covered in blood and exhibiting extremely unusual behavior. The police decide to investigate " + Protagonist + " further, and eventually learn of her crimes.";
					Phase = 100;
				}
			}
		}
		else if (Phase == 9)
		{
			KidnappedVictim = StudentManager.Students[TranqCase.VictimID];
			KidnappedVictim.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
			KidnappedVictim.CharacterAnimation.enabled = true;
			KidnappedVictim.gameObject.SetActive(value: true);
			KidnappedVictim.Ragdoll.Zs.SetActive(value: false);
			KidnappedVictim.transform.parent = base.transform;
			KidnappedVictim.transform.localPosition = new Vector3(0f, 0.145f, 0f);
			KidnappedVictim.transform.localEulerAngles = new Vector3(0f, 90f, 0f);
			KidnappedVictim.CharacterAnimation.Play("f02_sit_06");
			KidnappedVictim.WhiteQuestionMark.SetActive(value: true);
			KidnappedVictim.Cosmetic.FemaleHair[KidnappedVictim.Cosmetic.Hairstyle].SetActive(value: true);
			OpenTranqCase.SetActive(value: true);
			Label.text = "The police discover " + JSON.Students[TranqCase.VictimID].Name + " inside of a musical instrument case. However, she is unable to recall how she got inside of the case. The police are unable to determine what happened.";
			StudentGlobals.SetStudentKidnapped(TranqCase.VictimID, value: false);
			StudentGlobals.SetStudentMissing(TranqCase.VictimID, value: false);
			if (TranqCase.VictimID == StudentManager.RivalID)
			{
				StudentManager.RivalEliminated = false;
			}
			TranqCase.VictimClubType = ClubType.None;
			TranqCase.VictimID = 0;
			TranqCase.Occupied = false;
			Phase++;
		}
		else if (Phase == 10)
		{
			if (Police.MaskReported)
			{
				Mask.SetActive(value: true);
				GameGlobals.MasksBanned = true;
				if (SecuritySystem.Masked)
				{
					Label.text = "In security camera footage, the killer was wearing a mask. As a result, the police are unable to gather meaningful information about the murderer. To prevent this from ever happening again, the Headmaster decides to ban all masks from the school from this day forward.";
				}
				else
				{
					Label.text = "Witnesses state that the killer was wearing a mask. As a result, the police are unable to gather meaningful information about the murderer. To prevent this from ever happening again, the Headmaster decides to ban all masks from the school from this day forward.";
				}
				Police.MaskReported = false;
				Phase++;
			}
			else
			{
				Phase++;
				UpdateScene();
			}
		}
		else if (Phase == 11)
		{
			Cops.transform.eulerAngles = new Vector3(0f, 180f, 0f);
			Cops.SetActive(value: true);
			if (Arrests == 0)
			{
				if (DeadPerps == 0)
				{
					Label.text = "The police do not have enough evidence to perform an arrest. The police investigation ends, and students are free to leave.";
				}
				else if (Police.MurderSuicideScene)
				{
					Label.text = "The police conclude that a murder-suicide took place, but are unable to take any further action. The police investigation ends, and students are free to leave.";
				}
				else if (KillerIsDead)
				{
					Label.text = "The police are not able to take any further action. The police investigation ends, and students are free to leave.";
				}
				else
				{
					Label.text = "The police believe that they know the identity of the killer, but they cannot locate the suspect at school. The police leave to search for the person that they believe is the killer. The police investigation ends, and students are free to leave.";
				}
			}
			else if (Arrests == 1)
			{
				Label.text = "The police believe that they have arrested the perpetrator of the crime. The police investigation ends, and students are free to leave.";
			}
			else
			{
				Label.text = "The police believe that they have arrested the perpetrators of the crimes. The police investigation ends, and students are free to leave.";
			}
			if (StudentManager.RivalEliminated || RivalEliminationMethod != 0)
			{
				Phase++;
			}
			else if (DateGlobals.Weekday == DayOfWeek.Friday)
			{
				Phase = 24;
			}
			else
			{
				Phase += 2;
			}
		}
		else if (Phase == 12)
		{
			if (Police.Deaths + PlayerGlobals.Kills > 50)
			{
				Phase = 16;
				UpdateScene();
				return;
			}
			Senpai.enabled = false;
			Senpai.Pathfinding.enabled = false;
			Senpai.transform.parent = base.transform;
			Senpai.gameObject.SetActive(value: true);
			Senpai.transform.localPosition = new Vector3(0f, 0f, 0f);
			Senpai.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			Senpai.EmptyHands();
			Physics.SyncTransforms();
			string text5 = "";
			if (Yandere.Egg && RivalEliminationMethod == RivalEliminationType.None)
			{
				RivalEliminationMethod = RivalEliminationType.Murdered;
			}
			if (RivalEliminationMethod == RivalEliminationType.None && !RivalArrested)
			{
				Label.text = "Your Senpai feels a growing sense of concern that the school may not be safe.";
			}
			else if (RivalEliminationMethod == RivalEliminationType.Murdered || RivalEliminationMethod == RivalEliminationType.MurderedWitnessed || RivalEliminationMethod == RivalEliminationType.Accident || RivalEliminationMethod == RivalEliminationType.SuicideFake)
			{
				if (!StudentManager.Eighties)
				{
					Senpai.CharacterAnimation.Play("kneelCry_00");
					if (DateGlobals.Weekday != DayOfWeek.Friday)
					{
						text5 = "Senpai will stay home from school for one day to mourn her death.";
						GameGlobals.SenpaiMourning = true;
					}
					Label.text = "Senpai is absolutely devastated by the death of his childhood friend. His mental stability has been greatly affected." + text5;
				}
				else
				{
					Senpai.CharacterAnimation.Play(Senpai.BulliedIdleAnim);
					Label.text = "Senpai is deeply saddened by the death of his friend.";
				}
			}
			else
			{
				Senpai.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
				if (RivalEliminationMethod == RivalEliminationType.Arrested || RivalArrested)
				{
					Senpai.CharacterAnimation["refuse_02"].speed = 0.5f;
					Senpai.CharacterAnimation.Play("refuse_02");
					Label.text = "Senpai is disgusted to learn that " + RivalName + " would actually commit murder. He is deeply disappointed in her.";
				}
				else if (RivalEliminationMethod == RivalEliminationType.Befriended || RivalEliminationMethod == RivalEliminationType.Matchmade)
				{
					Senpai.CharacterAnimation.Play(Senpai.BulliedIdleAnim);
					Label.text = "Senpai notices that " + RivalName + " is distancing herself from him. He feels a little sad about it, but he accepts it.";
				}
				else if (RivalEliminationMethod == RivalEliminationType.Expelled)
				{
					Senpai.CharacterAnimation.Play("surprisedPose_00");
					Label.text = "Senpai is shocked to learn that " + RivalName + " has been expelled. He is deeply disappointed in her.";
				}
				else if (RivalEliminationMethod == RivalEliminationType.Ruined)
				{
					Senpai.CharacterAnimation["refuse_02"].speed = 0.5f;
					Senpai.CharacterAnimation.Play("refuse_02");
					Label.text = "Senpai is disturbed by the rumors circulating about " + RivalName + ". He is deeply disappointed in her.";
				}
				else if (RivalEliminationMethod == RivalEliminationType.Rejected)
				{
					Senpai.CharacterAnimation.Play(Senpai.BulliedIdleAnim);
					Label.text = "Senpai feels guilty for turning down " + RivalName + "'s feelings, but also he knows that he cannot take back what has been said.";
				}
				else if (RivalEliminationMethod == RivalEliminationType.Vanished)
				{
					Senpai.CharacterAnimation.Play(Senpai.BulliedIdleAnim);
					Label.text = "Senpai is concerned about the sudden disappearance of " + RivalName + ". His mental stability has been slightly affected.";
				}
			}
			Phase++;
		}
		else if (Phase == 13)
		{
			Senpai.enabled = false;
			Senpai.Pathfinding.enabled = false;
			Senpai.transform.parent = base.transform;
			Senpai.gameObject.SetActive(value: true);
			Senpai.transform.localPosition = new Vector3(0f, 0f, 0f);
			Senpai.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
			Senpai.Character.transform.localPosition = new Vector3(0f, 0f, 0f);
			Senpai.Character.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			Senpai.EmptyHands();
			if (StudentManager.RivalEliminated)
			{
				Senpai.CharacterAnimation.Play(Senpai.BulliedWalkAnim);
			}
			else
			{
				Senpai.CharacterAnimation.Play(Senpai.WalkAnim);
			}
			Yandere.LookAt.gameObject.name = "HeadRENAMED";
			Yandere.LookAt.enabled = true;
			Yandere.MyController.enabled = false;
			Yandere.transform.parent = base.transform;
			Yandere.transform.localPosition = new Vector3(2.5f, 0f, 2.5f);
			Yandere.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
			Yandere.gameObject.SetActive(value: true);
			Yandere.CharacterAnimation.Play(Yandere.WalkAnim);
			Label.text = Protagonist + " stalks Senpai until he has returned home, and then returns to her own home.";
			if (GameGlobals.SenpaiMourning)
			{
				Senpai.gameObject.SetActive(value: false);
				Yandere.LookAt.enabled = false;
				Yandere.transform.localPosition = new Vector3(0f, 0f, 0f);
				Yandere.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
				Label.text = Protagonist + " returns home, thinking of Senpai every step of the way.";
			}
			Physics.SyncTransforms();
			Phase++;
		}
		else if (Phase == 14)
		{
			if (!StudentGlobals.GetStudentDying(StudentManager.RivalID) && !StudentGlobals.GetStudentDead(StudentManager.RivalID) && !StudentGlobals.GetStudentArrested(StudentManager.RivalID))
			{
				if (Counselor.LectureID > 0)
				{
					Yandere.gameObject.SetActive(value: false);
					for (int m = 1; m < 100; m++)
					{
						StudentManager.DisableStudent(m);
					}
					EODCamera.position = new Vector3(-18.5f, 1f, 6.5f);
					EODCamera.eulerAngles = new Vector3(0f, -45f, 0f);
					EODCamera.Translate(EODCamera.transform.forward * 0.3f);
					Counselor.Lecturing = true;
					base.enabled = false;
					Debug.Log("The counselor is going to lecture somebody! Exiting End-of-Day sequence.");
				}
				else
				{
					Phase++;
					UpdateScene();
				}
			}
			else
			{
				Phase++;
				UpdateScene();
			}
		}
		else if (Phase == 15)
		{
			EODCamera.localPosition = new Vector3(1f, 1.8f, -2.5f);
			EODCamera.localEulerAngles = new Vector3(22.5f, -22.5f, 0f);
			TextWindow.SetActive(value: true);
			if (Counselor.MustReturnStolenRing)
			{
				if (!StudentManager.Eighties)
				{
					GaudyRing.SetActive(value: true);
				}
				else
				{
					EightiesGaudyRing.SetActive(value: true);
				}
				if (!StudentManager.Eighties)
				{
					if (StudentManager.Students[2] != null)
					{
						if (StudentManager.Students[2].Alive)
						{
							Label.text = "The guidance counselor returns Sakyu's stolen ring to her. Sakyu decides to stop bringing the ring to school.";
						}
						else
						{
							Label.text = "The guidance counselor cannot return Sakyu's stolen ring to her, because she is dead.";
						}
					}
					else
					{
						Label.text = "The guidance counselor cannot return Sakyu's stolen ring to her.";
					}
					GameGlobals.RingStolen = true;
				}
				else if (StudentManager.Students[2] != null)
				{
					if (StudentManager.Students[30].Alive)
					{
						Label.text = "The guidance counselor returns Himeko's stolen ring to her. Having her ring stolen does not affect Himeko's decision to wear expensive jewelry at school every day.";
					}
					else
					{
						Label.text = "The guidance counselor cannot return Himeko's stolen ring to her, because she is dead.";
					}
				}
				else
				{
					Label.text = "The guidance counselor cannot return Himeko's stolen ring to her.";
				}
				Counselor.MustReturnStolenRing = false;
			}
			else if (SchemeGlobals.GetSchemeStage(2) == 3)
			{
				GaudyRing.SetActive(value: true);
				if (!StudentGlobals.GetStudentDying(StudentManager.RivalID) && !StudentGlobals.GetStudentDead(StudentManager.RivalID) && !StudentGlobals.GetStudentArrested(StudentManager.RivalID))
				{
					Label.text = RivalName + " discovers a ring inside of her book bag. She returns the ring to its owner.";
				}
				else
				{
					Label.text = "Sakyu Basu will never recover her stolen ring.";
				}
				SchemeGlobals.SetSchemeStage(2, 100);
				GameGlobals.RingStolen = true;
			}
			else
			{
				Phase++;
				UpdateScene();
			}
		}
		else if (Phase == 16)
		{
			if (Police.Deaths + PlayerGlobals.Kills > 50)
			{
				EODCamera.position = new Vector3(-6f, 0.15f, -49f);
				EODCamera.eulerAngles = new Vector3(-22.5f, 22.5f, 0f);
				Label.text = "More than half of the school's population is dead. For the safety of the remaining students, the headmaster of Akademi makes the decision to shut down the school. Senpai enrolls in a school far away. " + Protagonist + " will not be able to follow him, and another girl will steal his heart. " + Protagonist + " has permanently lost her chance to be with Senpai.";
				Heartbroken.NoSnap = true;
				GameOver = true;
			}
			else
			{
				Phase++;
				UpdateScene();
			}
		}
		else if (Phase == 17)
		{
			ClubLimit = ClubArray.Length;
			if (!GameGlobals.Eighties)
			{
				ClubLimit--;
			}
			ClubClosed = false;
			ClubKicked = false;
			DistanceToMoveForward = 1.2f;
			if (ClubID < ClubLimit)
			{
				if (StudentManager.Eighties && ClubID == 11)
				{
					ClubID++;
				}
				if (!ClubGlobals.GetClubClosed(ClubArray[ClubID]))
				{
					ClubManager.CheckClub(ClubArray[ClubID]);
					if (ClubManager.ClubMembers < 5)
					{
						EODCamera.position = ClubManager.ClubVantages[ClubID].position;
						EODCamera.eulerAngles = ClubManager.ClubVantages[ClubID].eulerAngles;
						EODCamera.Translate(Vector3.forward * DistanceToMoveForward, Space.Self);
						ClubGlobals.SetClubClosed(ClubArray[ClubID], value: true);
						if (ClubID != 11)
						{
							Label.text = "The " + ClubNames[ClubID].ToString() + " no longer has enough members to remain operational. The school forces the club to disband.";
						}
						else if (ClubManager.ClubMembers > 0)
						{
							Label.text = "The Gaming Club makes the decision to disband.";
						}
						else
						{
							Label.text = "The Gaming Club no longer exists.";
						}
						ClubClosed = true;
						if (Yandere.Club == ClubArray[ClubID])
						{
							Yandere.Club = ClubType.None;
						}
					}
					if (ClubManager.LeaderMissing)
					{
						EODCamera.position = ClubManager.ClubVantages[ClubID].position;
						EODCamera.eulerAngles = ClubManager.ClubVantages[ClubID].eulerAngles;
						EODCamera.Translate(Vector3.forward * DistanceToMoveForward, Space.Self);
						ClubGlobals.SetClubClosed(ClubArray[ClubID], value: true);
						Label.text = "The leader of the " + ClubNames[ClubID].ToString() + " has gone missing. The " + ClubNames[ClubID].ToString() + " cannot operate without its leader. The club disbands.";
						ClubClosed = true;
						if (Yandere.Club == ClubArray[ClubID])
						{
							Yandere.Club = ClubType.None;
						}
					}
					else if (ClubManager.LeaderDead)
					{
						EODCamera.position = ClubManager.ClubVantages[ClubID].position;
						EODCamera.eulerAngles = ClubManager.ClubVantages[ClubID].eulerAngles;
						EODCamera.Translate(Vector3.forward * DistanceToMoveForward, Space.Self);
						ClubGlobals.SetClubClosed(ClubArray[ClubID], value: true);
						Label.text = "The leader of the " + ClubNames[ClubID].ToString() + " is gone. The " + ClubNames[ClubID].ToString() + " cannot operate without its leader. The club disbands.";
						ClubClosed = true;
						if (Yandere.Club == ClubArray[ClubID])
						{
							Yandere.Club = ClubType.None;
						}
					}
					else if (ClubManager.LeaderAshamed)
					{
						EODCamera.position = ClubManager.ClubVantages[ClubID].position;
						EODCamera.eulerAngles = ClubManager.ClubVantages[ClubID].eulerAngles;
						EODCamera.Translate(Vector3.forward * DistanceToMoveForward, Space.Self);
						ClubGlobals.SetClubClosed(ClubArray[ClubID], value: true);
						Label.text = "The leader of the " + ClubNames[ClubID].ToString() + " has unexpectedly disbanded the club without explanation.";
						ClubClosed = true;
						ClubManager.LeaderAshamed = false;
						if (Yandere.Club == ClubArray[ClubID])
						{
							Yandere.Club = ClubType.None;
						}
					}
				}
				if (!ClubGlobals.GetClubClosed(ClubArray[ClubID]) && !ClubGlobals.GetClubKicked(ClubArray[ClubID]) && Yandere.Club == ClubArray[ClubID])
				{
					ClubManager.CheckGrudge(ClubArray[ClubID]);
					if (StudentManager.Eighties)
					{
						Protagonist = "Ryoba";
					}
					if (StudentManager.CustomMode)
					{
						Protagonist = JSON.Students[0].Name;
					}
					if (ClubManager.LeaderGrudge)
					{
						EODCamera.position = ClubManager.ClubVantages[ClubID].position;
						EODCamera.eulerAngles = ClubManager.ClubVantages[ClubID].eulerAngles;
						EODCamera.Translate(Vector3.forward * DistanceToMoveForward, Space.Self);
						Label.text = Protagonist + " receives a message from the president of the " + ClubNames[ClubID].ToString() + ". " + Protagonist + " is no longer a member of the " + ClubNames[ClubID].ToString() + ", and is not welcome in the " + ClubNames[ClubID].ToString() + " room.";
						ClubGlobals.SetClubKicked(ClubArray[ClubID], value: true);
						Yandere.Club = ClubType.None;
						ClubKicked = true;
					}
					else if (ClubManager.ClubGrudge)
					{
						Debug.Log("Yeah, someone does.");
						EODCamera.position = ClubManager.ClubVantages[ClubID].position;
						EODCamera.eulerAngles = ClubManager.ClubVantages[ClubID].eulerAngles;
						EODCamera.Translate(Vector3.forward * DistanceToMoveForward, Space.Self);
						Label.text = Protagonist + " receives a message from the president of the " + ClubNames[ClubID].ToString() + ". There is someone in the " + ClubNames[ClubID].ToString() + " who hates and fears " + Protagonist + ". " + Protagonist + " is no longer a member of the " + ClubNames[ClubID].ToString() + ", and is not welcome in the " + ClubNames[ClubID].ToString() + " room.";
						ClubGlobals.SetClubKicked(ClubArray[ClubID], value: true);
						Yandere.Club = ClubType.None;
						ClubKicked = true;
					}
				}
				if (!ClubClosed && !ClubKicked)
				{
					ClubID++;
					UpdateScene();
				}
				ClubManager.LeaderAshamed = false;
			}
			else
			{
				Phase++;
				UpdateScene();
			}
		}
		else if (Phase == 18)
		{
			Debug.Log("The EoD sequence is now checking the TranqCase.");
			if (TranqCase.Occupied)
			{
				ClosedTranqCase.SetActive(value: true);
				Label.color = new Color(Label.color.r, Label.color.g, Label.color.b, 1f);
				if (StudentManager.Eighties)
				{
					Protagonist = "Ryoba";
				}
				if (StudentManager.CustomMode)
				{
					Protagonist = JSON.Students[0].Name;
				}
				Label.text = Protagonist + " waits until midnight, sneaks into school, and returns to the musical instrument case that contains her unconscious victim. She pushes the case back to her house and ties the victim to a chair in her basement.";
				if (TranqCase.VictimID == StudentManager.RivalID)
				{
					RivalEliminationMethod = RivalEliminationType.Vanished;
					GameGlobals.SpecificEliminationID = 12;
					if (!GameGlobals.Debug)
					{
						PlayerPrefs.SetInt("Kidnap", 1);
					}
					if (!GameGlobals.Debug)
					{
						PlayerPrefs.SetInt("a", 1);
					}
				}
				Phase++;
			}
			else
			{
				Phase++;
				UpdateScene();
			}
		}
		else if (Phase == 19)
		{
			if (ErectFence)
			{
				Fence.SetActive(value: true);
				Label.text = "To prevent any other students from falling off of the school rooftop, the school erects a fence around the roof.";
				SchoolGlobals.RoofFence = true;
				ErectFence = false;
			}
			else
			{
				Phase++;
				UpdateScene();
			}
		}
		else if (Phase == 20)
		{
			if (!SchoolGlobals.HighSecurity && Police.CouncilDeath)
			{
				if (!StudentManager.Eighties)
				{
					SCP.SetActive(value: true);
					Label.text = "The student council president has ordered the implementation of heightened security precautions. Security cameras and metal detectors are now present at school.";
				}
				else
				{
					Headmaster.SetActive(value: true);
					Label.text = "The headmaster has ordered the implementation of heightened security precautions. Security cameras and metal detectors are now present at school.";
				}
				Police.CouncilDeath = false;
			}
			else
			{
				Phase++;
				UpdateScene();
			}
		}
		else if (Phase == 21)
		{
			Debug.Log("The EoD sequence is now checking the rival's reputation.");
			Rival = StudentManager.Students[StudentManager.RivalID];
			if (ArticleID == 2)
			{
				StudentManager.StudentReps[StudentManager.RivalID] -= 20f * (1f + (float)Class.LanguageGrade * 0.2f);
				StudentGlobals.SetStudentReputation(StudentManager.RivalID, Mathf.RoundToInt(StudentManager.StudentReps[StudentManager.RivalID]));
			}
			if (Rival != null && Rival.Alive && !Rival.Tranquil && StudentManager.StudentReps[StudentManager.RivalID] <= -100f)
			{
				Debug.Log("The rival is not null, the rival is alive, and the rival's reputation is below -100.");
				Rival.gameObject.SetActive(value: true);
				Rival.transform.parent = base.transform;
				Rival.transform.localPosition = new Vector3(0f, 0f, 0f);
				Rival.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
				Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
				Rival.CharacterAnimation.Play(Rival.BulliedWalkAnim);
				Rival.CharacterAnimation.enabled = true;
				if (StudentManager.Eighties)
				{
					RivalName = EightiesRivalNames[DateGlobals.Week];
					if (StudentManager.CustomMode)
					{
						RivalName = JSON.Students[10 + DateGlobals.Week].Name;
					}
				}
				else
				{
					RivalName = RivalNames[DateGlobals.Week];
				}
				Label.text = RivalName + " cannot endure the bullying and harassment that she is being subjected to due to her damaged reputation. She chooses to withdraw from Akademi and never return.";
				RivalEliminationMethod = RivalEliminationType.Ruined;
				StudentManager.RivalEliminated = true;
				GameGlobals.SpecificEliminationID = 4;
				if (StudentManager.StudentReps[StudentManager.RivalID] <= -150f)
				{
					Debug.Log("GoToSuicideScene is being set to true right here...");
					Label.text = RivalName + " is absolutely devastated by the unbearable bullying and harassment that she is being subjected to. She silently returns to her home, planning something drastic...";
					Rival.CharacterAnimation.Play(Rival.BulliedIdleAnim);
					RivalEliminationMethod = RivalEliminationType.SuicideBully;
					GoToSuicideScene = true;
					StudentManager.Students[StudentManager.RivalID].Hearts.Stop();
					GameGlobals.SpecificEliminationID = 19;
					if (!GameGlobals.Debug)
					{
						PlayerPrefs.SetInt("Suicide", 1);
					}
					if (!GameGlobals.Debug)
					{
						PlayerPrefs.SetInt("a", 1);
					}
				}
				else
				{
					Debug.Log("Informing the Content Checklist.");
					if (!GameGlobals.Debug)
					{
						PlayerPrefs.SetInt("Bully", 1);
					}
					if (!GameGlobals.Debug)
					{
						PlayerPrefs.SetInt("a", 1);
					}
				}
				Phase++;
			}
			else
			{
				Phase++;
				UpdateScene();
			}
		}
		else if (Phase == 22)
		{
			if (Yandere.Club != 0 && DateGlobals.Weekday == DayOfWeek.Friday && ClubManager.ActivitiesAttended == 0)
			{
				TeleportYandere();
				Yandere.CharacterAnimation.Play("f02_disappointed_00");
				if (Yandere.StudentManager.Eighties)
				{
					Yandere.LoseGentleEyes();
				}
				if (StudentManager.Eighties)
				{
					Protagonist = "Ryoba";
				}
				if (StudentManager.CustomMode)
				{
					Protagonist = JSON.Students[0].Name;
				}
				Label.text = Protagonist + " did not participate in any activities with her club this week. She has been kicked out of the club.";
				ClubGlobals.SetClubKicked(Yandere.Club, value: true);
				ClubGlobals.Club = ClubType.None;
				Yandere.Club = ClubType.None;
				Debug.Log("The player has been kicked out of a club.");
			}
			else
			{
				Phase++;
				UpdateScene();
			}
		}
		else if (Phase == 23)
		{
			Finish();
		}
		else if (Phase == 24)
		{
			if (LoveManager.ConfessToSuitor && StudentManager.Students[StudentManager.SuitorID].Alive)
			{
				StudentScript obj = StudentManager.Students[StudentManager.SuitorID];
				obj.enabled = false;
				obj.Pathfinding.enabled = false;
				obj.transform.parent = base.transform;
				obj.gameObject.SetActive(value: true);
				obj.transform.localPosition = new Vector3(-0.4f, 0f, 0f);
				obj.transform.localEulerAngles = new Vector3(0f, 90f, 0f);
				obj.EmptyHands();
				obj.MyController.enabled = false;
				obj.CharacterAnimation.enabled = true;
				obj.CharacterAnimation.Play("holdHandsLoop_00");
				ParticleSystem.EmissionModule emission = obj.Hearts.emission;
				emission.enabled = true;
				obj.Hearts.Play();
				Rival.enabled = false;
				Rival.Pathfinding.enabled = false;
				Rival.transform.parent = base.transform;
				Rival.gameObject.SetActive(value: true);
				Rival.transform.localPosition = new Vector3(0.4f, 0f, 0f);
				Rival.transform.localEulerAngles = new Vector3(0f, -90f, 0f);
				Rival.EmptyHands();
				Rival.MyController.enabled = false;
				Rival.CharacterAnimation.enabled = true;
				Rival.CharacterAnimation.Play("f02_holdHandsLoop_00");
				emission = Rival.Hearts.emission;
				emission.enabled = true;
				Rival.Hearts.Play();
				RivalEliminationMethod = RivalEliminationType.Matchmade;
				Label.text = "After the police investigation ends, " + RivalName + " confesses to a boy that she has fallen in love with. She will no longer attempt to pursue a relationship with " + Protagonist + "'s Senpai.";
				Phase = 12;
			}
			else if (LoveManager.ConfessToSuitor)
			{
				Rival.enabled = false;
				Rival.Pathfinding.enabled = false;
				Rival.transform.parent = base.transform;
				Rival.gameObject.SetActive(value: true);
				Rival.transform.localPosition = new Vector3(0f, 0f, 0f);
				Rival.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
				Rival.EmptyHands();
				Rival.MyController.enabled = false;
				Rival.CharacterAnimation.enabled = true;
				Rival.CharacterAnimation.CrossFade("f02_bulliedIdle_00");
				RivalEliminationMethod = RivalEliminationType.Matchmade;
				Label.text = RivalName + " was planning to confess her love to a boy that she had fallen in love with, but that boy is now dead. Her heart is broken. Under these circumstances, she can no longer consider pursuing a relationship with " + Protagonist + "'s Senpai.";
				Phase = 12;
			}
			else
			{
				Senpai.enabled = false;
				Senpai.Pathfinding.enabled = false;
				Senpai.transform.parent = base.transform;
				Senpai.gameObject.SetActive(value: true);
				Senpai.transform.localPosition = new Vector3(0f, 0f, 0f);
				Senpai.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
				Senpai.EmptyHands();
				Senpai.MyController.enabled = false;
				Senpai.CharacterAnimation.enabled = true;
				Senpai.CharacterAnimation.CrossFade(Senpai.IdleAnim);
				Rival.enabled = false;
				Rival.Pathfinding.enabled = false;
				Rival.transform.parent = base.transform;
				Rival.gameObject.SetActive(value: true);
				Rival.transform.localPosition = new Vector3(0f, 0f, 1f);
				Rival.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
				Rival.EmptyHands();
				Rival.MyController.enabled = false;
				Rival.CharacterAnimation.enabled = true;
				Rival.CharacterAnimation.CrossFade(Rival.IdleAnim);
				Rival.CharacterAnimation["f02_shy_00"].weight = 1f;
				Rival.CharacterAnimation.Play("f02_shy_00");
				Label.text = "After the police investigation ends, " + RivalName + " asks Senpai to speak with her under the cherry tree behind the school.";
				Phase++;
			}
		}
		else if (Phase == 25)
		{
			for (int n = 1; n < 100; n++)
			{
				StudentManager.DisableStudent(n);
			}
			LoveManager.Suitor = Senpai;
			LoveManager.Rival = Rival;
			LoveManager.Rival.CharacterAnimation["f02_shy_00"].weight = 0f;
			LoveManager.Suitor.gameObject.SetActive(value: true);
			LoveManager.Rival.gameObject.SetActive(value: true);
			Yandere.gameObject.SetActive(value: true);
			Yandere.MyListener.enabled = true;
			LoveManager.Suitor.transform.parent = null;
			LoveManager.Rival.transform.parent = null;
			Yandere.gameObject.transform.parent = null;
			LoveManager.BeginConfession();
			Clock.NightLighting();
			Clock.enabled = false;
			base.gameObject.SetActive(value: false);
		}
		else if (Phase == 100)
		{
			Yandere.MyController.enabled = false;
			Yandere.transform.parent = base.transform;
			Yandere.transform.localPosition = new Vector3(0f, 0f, 0f);
			Yandere.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			Yandere.gameObject.SetActive(value: true);
			Yandere.CharacterAnimation.Play("f02_handcuffs_00");
			Yandere.Handcuffs.SetActive(value: true);
			ArrestingCops.SetActive(value: true);
			Physics.SyncTransforms();
			Label.text = Protagonist + " is arrested by the police. She will never have Senpai.";
			GameOver = true;
			Heartbroken.Arrested = true;
			Heartbroken.NoSnap = true;
		}
		else if (Phase == 101)
		{
			int fingerprintID2 = WeaponManager.Weapons[WeaponID].FingerprintID;
			StudentScript studentScript = StudentManager.Students[fingerprintID2];
			if (studentScript.Alive)
			{
				Patsy = StudentManager.Students[fingerprintID2];
				Patsy.gameObject.SetActive(value: true);
				Patsy.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
				Patsy.CharacterAnimation.enabled = true;
				if (Patsy.WeaponBag != null)
				{
					Patsy.WeaponBag.SetActive(value: false);
				}
				Patsy.EmptyHands();
				Patsy.SpeechLines.Stop();
				Patsy.Handcuffs.SetActive(value: true);
				Patsy.gameObject.SetActive(value: true);
				Patsy.Ragdoll.Zs.SetActive(value: false);
				Patsy.SmartPhone.SetActive(value: false);
				Patsy.MyController.enabled = false;
				Patsy.transform.parent = base.transform;
				Patsy.transform.localPosition = new Vector3(0f, 0f, 0f);
				Patsy.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
				Patsy.Pathfinding.enabled = false;
				Patsy.ShoeRemoval.enabled = false;
				if (StudentManager.Students[fingerprintID2].Male)
				{
					StudentManager.Students[fingerprintID2].CharacterAnimation.Play("handcuffs_00");
				}
				else
				{
					StudentManager.Students[fingerprintID2].CharacterAnimation.Play("f02_handcuffs_00");
				}
				ArrestingCops.SetActive(value: true);
				if (!studentScript.Tranquil)
				{
					Label.text = JSON.Students[fingerprintID2].Name + " is arrested by the police.";
					StudentsToArrest[fingerprintID2] = true;
					Arrests++;
				}
				else
				{
					Label.text = JSON.Students[fingerprintID2].Name + " is found asleep inside of a musical instrument case. The police assume that she hid herself inside of the box after committing murder, and arrest her.";
					StudentsToArrest[fingerprintID2] = true;
					ArrestID = fingerprintID2;
					TranqCase.Occupied = false;
					Arrests++;
				}
				if (Patsy.StudentID == StudentManager.RivalID)
				{
					StudentManager.RivalEliminated = true;
					RivalArrested = true;
				}
			}
			else
			{
				ShruggingCops.SetActive(value: true);
				if (studentScript.Ragdoll.Disposed)
				{
					Label.text = JSON.Students[fingerprintID2].Name + " is missing. The police cannot perform an arrest.";
					DeadPerps++;
				}
				else
				{
					bool flag2 = false;
					bool flag3 = false;
					for (ID = 0; ID < VictimArray.Length; ID++)
					{
						if (VictimArray[ID] == fingerprintID2 && studentScript.Suicide)
						{
							flag2 = true;
						}
					}
					for (ID = 0; ID < VictimArray.Length; ID++)
					{
						if (VictimArray[ID] == fingerprintID2 && !studentScript.MurderSuicide)
						{
							flag3 = true;
						}
					}
					if (flag2)
					{
						Label.text = JSON.Students[fingerprintID2].Name + " is dead, and the wound that caused her death appears to be self-inflicted. The police conclude that she ended her own life.";
						KillerIsDead = true;
						DeadPerps++;
					}
					else if (flag3)
					{
						Label.text = JSON.Students[fingerprintID2].Name + "'s fingerprints are on the same weapon that killed them. However, the wounds on the victim's body are not consistent with those of a suicide. The police conclude that the victim's death was not a suicide, and was most likely a homicide. However, they lack sufficient evidence to name the perpetrator.";
					}
					else
					{
						Label.text = JSON.Students[fingerprintID2].Name + " is dead. The police cannot perform an arrest.";
						DeadPerps++;
					}
				}
			}
			if (CurrentMurderWeaponKilledRival)
			{
				Debug.Log("The police believe that they know who killed the rival. ''Details'' for this rival should be set to ''14'' - ''Ryoba's involvement not suspected.''");
				InvolvementNotSuspected = true;
			}
			Phase = 3;
		}
		else if (Phase == 102)
		{
			_ = (bool)StudentManager.Students[Police.SuicideID];
			if (!StudentManager.Students[Police.SuicideID].Ragdoll.Disposed)
			{
				MurderScene.SetActive(value: true);
				if (Police.SuicideNote)
				{
					Label.text = "The police inspect the corpse of a student who appears to have fallen to their death from the school rooftop. The police find a suicide note, and conclude that the deceased student probably took their own life. However, they still search the school for clues and evidence.";
				}
				else
				{
					Label.text = "The police inspect the corpse of a student who appears to have fallen to their death from the school rooftop. The police treat the incident as a murder case, and search the school for any other victims.";
				}
				if (Police.SuicideID == StudentManager.RivalID && Police.SuicideNote)
				{
					Debug.Log("The police should be drawing the conclusion that the rival committed suicide, and the Calendar screen ought to reflect this.");
					RivalEliminationMethod = RivalEliminationType.SuicideFake;
				}
				ErectFence = true;
			}
			else
			{
				ShruggingCops.SetActive(value: true);
				Label.text = "The police attempt to determine whether or not a student fell to their death from the school rooftop. The police are unable to reach a conclusion.";
			}
			Phase = 2;
		}
		else if (Phase == 103)
		{
			MurderScene.SetActive(value: true);
			Label.text = "The paramedics attempt to resuscitate the poisoned student, but they are unable to revive her. The police treat the incident as a murder case, and search the school for any other victims.";
			for (ID = 0; ID < Police.CorpseList.Length; ID++)
			{
				RagdollScript ragdollScript2 = Police.CorpseList[ID];
				if (ragdollScript2 != null && ragdollScript2.Poisoned)
				{
					ragdollScript2 = null;
					if (Police.Corpses > 0)
					{
						Police.Corpses--;
					}
				}
			}
			if (Corpse.StudentID == StudentManager.RivalID)
			{
				GameGlobals.SpecificEliminationID = 15;
				if (!GameGlobals.Debug)
				{
					PlayerPrefs.SetInt("Poison", 1);
				}
				if (!GameGlobals.Debug)
				{
					PlayerPrefs.SetInt("a", 1);
				}
			}
			Phase = 2;
		}
		else if (Phase == 104)
		{
			MurderScene.SetActive(value: true);
			Label.text = "The police determine that " + Police.DrownedStudentName + " died from drowning. The police treat the death as a possible murder, and search the school for any other victims.";
			for (ID = 0; ID < Police.CorpseList.Length; ID++)
			{
				RagdollScript ragdollScript3 = Police.CorpseList[ID];
				if (ragdollScript3 != null)
				{
					if (ragdollScript3.Student.StudentID == StudentManager.RivalID)
					{
						Debug.Log("The player drowned the rival.");
						if (RivalEliminationMethod == RivalEliminationType.None)
						{
							RivalEliminationMethod = RivalEliminationType.Murdered;
						}
						GameGlobals.SpecificEliminationID = 7;
						if (!GameGlobals.Debug)
						{
							PlayerPrefs.SetInt("Drown", 1);
						}
						if (!GameGlobals.Debug)
						{
							PlayerPrefs.SetInt("a", 1);
						}
					}
					if (ragdollScript3.Drowned)
					{
						ragdollScript3 = null;
						if (Police.Corpses > 0)
						{
							Police.Corpses--;
						}
					}
				}
			}
			Phase = 2;
		}
		else if (Phase == 105)
		{
			MurderScene.SetActive(value: true);
			Label.text = "The police determine that " + Police.ElectrocutedStudentName + " died from being electrocuted. The police treat the death as a possible murder, and search the school for any other victims.";
			for (ID = 0; ID < Police.CorpseList.Length; ID++)
			{
				RagdollScript ragdollScript4 = Police.CorpseList[ID];
				if (ragdollScript4 != null && ragdollScript4.Electrocuted)
				{
					if (ragdollScript4.Student.StudentID == StudentManager.RivalID)
					{
						Debug.Log("The game should now be informing the Content Checklist that the player has performed an electrocution.");
						if (!GameGlobals.Debug)
						{
							PlayerPrefs.SetInt("Electrocute", 1);
						}
						if (!GameGlobals.Debug)
						{
							PlayerPrefs.SetInt("a", 1);
						}
					}
					if (Police.Corpses > 0)
					{
						Police.Corpses--;
					}
				}
			}
			Phase = 2;
		}
		else if (Phase == 999)
		{
			ScaredCops.SetActive(value: true);
			Yandere.MyController.enabled = false;
			Yandere.transform.parent = base.transform;
			Yandere.transform.localPosition = new Vector3(0f, 0f, -1f);
			Yandere.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			Yandere.gameObject.SetActive(value: true);
			Physics.SyncTransforms();
			Label.text = "The police witness actual evidence of the supernatural, are absolutely horrified, and run for their lives.";
			if (StudentManager.RivalEliminated)
			{
				Phase = 12;
			}
			else
			{
				Phase = 13;
			}
		}
	}

	private void DetermineHowRivalDied(RagdollScript corpse)
	{
		Debug.Log("The rival died, and now the game is determining exactly how she died.");
		RivalEliminationMethod = RivalEliminationType.Murdered;
		if (corpse.Student.Electrified || corpse.Student.Electrocuted || corpse.Student.Ragdoll.Decapitated || corpse.Student.DeathType == DeathType.Burning || corpse.Student.DeathType == DeathType.Weight || corpse.Student.DeathType == DeathType.Drowning || corpse.Student.DeathType == DeathType.Poison || corpse.Student.DeathType == DeathType.Explosion)
		{
			RivalEliminationMethod = RivalEliminationType.Accident;
		}
		if (corpse.Student.DeathType == DeathType.Falling && Police.SuicideID == StudentManager.RivalID && Police.SuicideNote)
		{
			Debug.Log("Calendar screen should say ''Not believed to be murdered.''");
			RivalEliminationMethod = RivalEliminationType.SuicideFake;
		}
		if (corpse.Student.DeathType == DeathType.Burning)
		{
			GameGlobals.SpecificEliminationID = 5;
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("Burn", 1);
			}
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("a", 1);
			}
		}
		else if (corpse.Student.DeathType == DeathType.Electrocution)
		{
			Debug.Log("The game should now be informing the Content Checklist that the player has performed an electrocution.");
			GameGlobals.SpecificEliminationID = 8;
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("Electrocute", 1);
			}
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("a", 1);
			}
		}
		else if (corpse.Student.DeathType == DeathType.Weight)
		{
			GameGlobals.SpecificEliminationID = 6;
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("Crush", 1);
			}
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("a", 1);
			}
		}
		else if (corpse.Student.DeathType == DeathType.Drowning)
		{
			Debug.Log("The rival drowned.");
			if (PoolEvent)
			{
				Debug.Log("The player eliminated the rival during a pool event.");
				GameGlobals.SpecificEliminationID = 16;
				if (!GameGlobals.Debug)
				{
					PlayerPrefs.SetInt("Pool", 1);
				}
				if (!GameGlobals.Debug)
				{
					PlayerPrefs.SetInt("a", 1);
				}
			}
			else
			{
				Debug.Log("The player did not eliminate the rival during a pool event.");
				GameGlobals.SpecificEliminationID = 7;
				if (!GameGlobals.Debug)
				{
					PlayerPrefs.SetInt("Drown", 1);
				}
				if (!GameGlobals.Debug)
				{
					PlayerPrefs.SetInt("a", 1);
				}
			}
		}
		else if (corpse.Decapitated)
		{
			GameGlobals.SpecificEliminationID = 10;
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("Fan", 1);
			}
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("a", 1);
			}
		}
		else if (corpse.Student.DeathType == DeathType.Poison)
		{
			GameGlobals.SpecificEliminationID = 15;
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("Poison", 1);
			}
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("a", 1);
			}
		}
		else if (corpse.Student.DeathType == DeathType.Falling)
		{
			Debug.Log("Rival was killed by being pushed from rooftop.");
			GameGlobals.SpecificEliminationID = 17;
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("Push", 1);
			}
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("a", 1);
			}
		}
		else if (corpse.Student.Hunted)
		{
			GameGlobals.SpecificEliminationID = 14;
			if (!GameGlobals.Debug)
			{
				if (corpse.Student.MurderedByFragile)
				{
					if (!GameGlobals.Debug)
					{
						PlayerPrefs.SetInt("DrivenToMurder", 1);
					}
					if (!GameGlobals.Debug)
					{
						PlayerPrefs.SetInt("a", 1);
					}
				}
				else
				{
					if (!GameGlobals.Debug)
					{
						PlayerPrefs.SetInt("MurderSuicide", 1);
					}
					if (!GameGlobals.Debug)
					{
						PlayerPrefs.SetInt("a", 1);
					}
				}
			}
			Debug.Log("The game knows that the rival died as part of a murder-suicide.");
		}
		else if (corpse.Student.DeathType == DeathType.Weapon)
		{
			Debug.Log("The game believes that the rival died from a ''Weapon''.");
			GameGlobals.SpecificEliminationID = 1;
			AchievementToGrant = "Attack";
		}
		else if (corpse.Student.DeathType == DeathType.Explosion)
		{
			Debug.Log("The game knows that the rival died from an explosion.");
			GameGlobals.SpecificEliminationID = 20;
			AchievementToGrant = "Attack";
		}
		else
		{
			Debug.Log("We know that the rival died, but we didn't get any noteworthy information about her death...");
		}
	}

	private void TeleportYandere()
	{
		Yandere.MyController.enabled = false;
		Yandere.transform.parent = base.transform;
		Yandere.transform.localPosition = new Vector3(0.75f, 0.33333f, -1.9f);
		Yandere.transform.localEulerAngles = new Vector3(-22.5f, 157.5f, 0f);
		Yandere.gameObject.SetActive(value: true);
		Physics.SyncTransforms();
	}

	private void Finish()
	{
		Debug.Log("We have reached the end of the End-of-Day sequence.");
		if (RivalArrested)
		{
			RivalEliminationMethod = RivalEliminationType.Arrested;
		}
		if (RivalEliminationMethod == RivalEliminationType.Murdered)
		{
			GameGlobals.RivalEliminationID = 1;
			GameGlobals.NonlethalElimination = false;
			if (StudentManager.Students[1].SenpaiWitnessingRivalDie)
			{
				GameGlobals.RivalEliminationID = 2;
			}
			if (InvolvementNotSuspected)
			{
				Debug.Log("The police found someone's fingerprints on the murder weapon, so Ryoba is not a suspect.");
				GameGlobals.RivalEliminationID = 14;
			}
		}
		else if (RivalEliminationMethod == RivalEliminationType.Arrested)
		{
			Debug.Log("The rival was arrested.");
			GameGlobals.RivalEliminationID = 3;
			GameGlobals.NonlethalElimination = true;
			GameGlobals.SpecificEliminationID = 11;
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("Frame", 1);
			}
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("a", 1);
			}
			StudentGlobals.SetStudentArrested(StudentManager.RivalID, value: true);
		}
		else if (RivalEliminationMethod == RivalEliminationType.Expelled)
		{
			Debug.Log("The rival was expelled.");
			StudentGlobals.SetStudentExpelled(StudentManager.RivalID, value: true);
			GameGlobals.RivalEliminationID = 5;
			GameGlobals.NonlethalElimination = true;
			GameGlobals.SpecificEliminationID = 9;
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("Expel", 1);
			}
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("a", 1);
			}
		}
		else if (RivalEliminationMethod == RivalEliminationType.Matchmade)
		{
			Debug.Log("The rival was matchmade.");
			GameGlobals.RivalEliminationID = 6;
			GameGlobals.NonlethalElimination = true;
			GameGlobals.SpecificEliminationID = 13;
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("Matchmake", 1);
			}
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("a", 1);
			}
		}
		else if (RivalEliminationMethod == RivalEliminationType.Rejected)
		{
			Debug.Log("The rival was rejected by Senpai.");
			GameGlobals.RivalEliminationID = 7;
			GameGlobals.NonlethalElimination = true;
			GameGlobals.SpecificEliminationID = 18;
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("Reject", 1);
			}
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("a", 1);
			}
		}
		else if (RivalEliminationMethod == RivalEliminationType.Ruined)
		{
			Debug.Log("The rival's reputation has been ruined.");
			GameGlobals.RivalEliminationID = 8;
			GameGlobals.NonlethalElimination = true;
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("Bully", 1);
			}
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("a", 1);
			}
		}
		else if (RivalEliminationMethod == RivalEliminationType.SuicideBully)
		{
			Debug.Log("The rival was bullied into suicide.");
			GameGlobals.RivalEliminationID = 9;
			GameGlobals.NonlethalElimination = false;
		}
		else if (RivalEliminationMethod == RivalEliminationType.SuicideFake)
		{
			Debug.Log("The rival was pushed off the school rooftop, and the player made her death look like an accident.");
			GameGlobals.RivalEliminationID = 10;
			GameGlobals.NonlethalElimination = false;
			GameGlobals.SpecificEliminationID = 17;
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("Push", 1);
			}
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("a", 1);
			}
		}
		else if (RivalEliminationMethod == RivalEliminationType.Vanished || RivalDismemberedAndIncinerated || RivalBuried)
		{
			Debug.Log("The rival ''mysteriously disappeared''.");
			GameGlobals.RivalEliminationID = 11;
			GameGlobals.NonlethalElimination = false;
			CheckForNatureOfDeath();
			if (TranqCase.VictimID == StudentManager.RivalID)
			{
				GameGlobals.NonlethalElimination = true;
			}
		}
		else if (RivalEliminationMethod == RivalEliminationType.Accident)
		{
			Debug.Log("The rival was killed in a ''mysterious accident''.");
			GameGlobals.RivalEliminationID = 12;
			GameGlobals.NonlethalElimination = false;
		}
		if (GameGlobals.RivalEliminationID == 0 && StudentManager.Students[StudentManager.RivalID] != null && !StudentManager.Students[StudentManager.RivalID].Alive)
		{
			Debug.Log("RivalEliminationID was 0, but the rival is dead. Bug?");
			if (StudentManager.Students[StudentManager.RivalID].Ragdoll.Hidden || !PoliceArrived)
			{
				Debug.Log("The rival ''mysteriously disappeared''.");
				GameGlobals.RivalEliminationID = 11;
				GameGlobals.NonlethalElimination = false;
			}
			CheckForNatureOfDeath();
		}
		PlayerGlobals.Reputation = Reputation.Reputation;
		ClubGlobals.Club = Yandere.Club;
		StudentGlobals.MemorialStudents = 0;
		HomeGlobals.Night = true;
		Police.KillStudents();
		if (Police.Suspended)
		{
			DateGlobals.PassDays = Police.SuspensionLength;
		}
		else
		{
			DateGlobals.PassDays = 1;
		}
		if (StudentManager.Students[StudentGlobals.StudentSlave] != null)
		{
			Debug.Log("A mind-broken slave came to school today.");
			if (StudentManager.Students[StudentGlobals.StudentSlave].Ragdoll.enabled || !StudentManager.Students[StudentGlobals.StudentSlave].Alive)
			{
				Debug.Log("That slave died. Reducing the number of slaves by one, and removing them from the prisoner array.");
				StudentGlobals.StudentSlave = 0;
				StudentGlobals.Prisoners--;
				if (StudentGlobals.PrisonerChosen == 1)
				{
					StudentGlobals.Prisoner1 = 0;
				}
				else if (StudentGlobals.PrisonerChosen == 2)
				{
					StudentGlobals.Prisoner2 = 0;
				}
				else if (StudentGlobals.PrisonerChosen == 3)
				{
					StudentGlobals.Prisoner3 = 0;
				}
				else if (StudentGlobals.PrisonerChosen == 4)
				{
					StudentGlobals.Prisoner4 = 0;
				}
				else if (StudentGlobals.PrisonerChosen == 5)
				{
					StudentGlobals.Prisoner5 = 0;
				}
				else if (StudentGlobals.PrisonerChosen == 6)
				{
					StudentGlobals.Prisoner6 = 0;
				}
				else if (StudentGlobals.PrisonerChosen == 7)
				{
					StudentGlobals.Prisoner7 = 0;
				}
				else if (StudentGlobals.PrisonerChosen == 8)
				{
					StudentGlobals.Prisoner8 = 0;
				}
				else if (StudentGlobals.PrisonerChosen == 9)
				{
					StudentGlobals.Prisoner9 = 0;
				}
				else if (StudentGlobals.PrisonerChosen == 10)
				{
					StudentGlobals.Prisoner10 = 0;
				}
			}
		}
		for (int i = 1; i < 11; i++)
		{
			if (StudentManager.RivalKilledSelf[i])
			{
				GameGlobals.SetRivalEliminations(i, 10);
				GameGlobals.SetSpecificEliminations(i, 19);
			}
		}
		bool flag = DateGlobals.Weekday != DayOfWeek.Friday && StudentManager.SabotageProgress > StudentManager.InitialSabotageProgress;
		if (StudentManager.RivalEliminated || GameGlobals.GetRivalEliminations(DateGlobals.Week) > 0)
		{
			Debug.Log("Rival is already eliminated; we don't need to go to the sabotage progress screen.");
			flag = false;
		}
		SenpaiGifts -= StudentManager.SenpaiLoveWindow.GiftsToSubtract;
		if (StudentManager.SenpaiLoveWindow.Updated)
		{
			GameGlobals.SenpaiLove = StudentManager.SenpaiLoveWindow.SenpaiLove;
		}
		Debug.Log("CollectibleGlobals.SenpaiGifts is now: " + CollectibleGlobals.SenpaiGifts);
		if (GameGlobals.AlternateTimeline)
		{
			FunCheck();
		}
		if (FunGameOver)
		{
			SceneManager.LoadScene("FunGameOverScene");
		}
		else if (!TranqCase.Occupied)
		{
			if (GoToSuicideScene)
			{
				SceneManager.LoadScene("SuicideScene");
			}
			else if (flag)
			{
				SceneManager.LoadScene("RivalRejectionProgressScene");
			}
			else if (!StudentManager.Eighties && DateGlobals.Week > 1)
			{
				SceneManager.LoadScene("WeekLimitScene");
			}
			else
			{
				SceneManager.LoadScene("HomeScene");
			}
		}
		else
		{
			Debug.Log("Subtracting 10% school atmosphere because someone went missing today.");
			SchoolGlobals.SchoolAtmosphere -= 0.1f;
			StudentGlobals.Prisoners++;
			if (StudentGlobals.Prisoners == 1)
			{
				StudentGlobals.Prisoner1 = TranqCase.VictimID;
			}
			else if (StudentGlobals.Prisoners == 2)
			{
				StudentGlobals.Prisoner2 = TranqCase.VictimID;
			}
			else if (StudentGlobals.Prisoners == 3)
			{
				StudentGlobals.Prisoner3 = TranqCase.VictimID;
			}
			else if (StudentGlobals.Prisoners == 4)
			{
				StudentGlobals.Prisoner4 = TranqCase.VictimID;
			}
			else if (StudentGlobals.Prisoners == 5)
			{
				StudentGlobals.Prisoner5 = TranqCase.VictimID;
			}
			else if (StudentGlobals.Prisoners == 6)
			{
				StudentGlobals.Prisoner6 = TranqCase.VictimID;
			}
			else if (StudentGlobals.Prisoners == 7)
			{
				StudentGlobals.Prisoner7 = TranqCase.VictimID;
			}
			else if (StudentGlobals.Prisoners == 8)
			{
				StudentGlobals.Prisoner8 = TranqCase.VictimID;
			}
			else if (StudentGlobals.Prisoners == 9)
			{
				StudentGlobals.Prisoner9 = TranqCase.VictimID;
			}
			else if (StudentGlobals.Prisoners == 10)
			{
				StudentGlobals.Prisoner10 = TranqCase.VictimID;
			}
			StudentGlobals.SetStudentKidnapped(TranqCase.VictimID, value: true);
			StudentGlobals.SetStudentHealth(TranqCase.VictimID, 100);
			StudentGlobals.SetStudentSanity(TranqCase.VictimID, 100);
			Debug.Log("Student #" + TranqCase.VictimID + " is being set as ''Kidnapped.''");
			if (TranqCase.VictimID == StudentManager.RivalID)
			{
				GoToSuicideScene = false;
			}
			Debug.Log("And now, GoToSuicideScreen is: " + GoToSuicideScene);
			if (GoToSuicideScene)
			{
				Debug.Log("Loading SuicideScene, or trying to.");
				SceneManager.LoadScene("SuicideScene");
			}
			else if (flag)
			{
				GameGlobals.JustKidnapped = true;
				SceneManager.LoadScene("RivalRejectionProgressScene");
			}
			else
			{
				Debug.Log("Going to the Calendar Scene now...");
				SceneManager.LoadScene("CalendarScene");
			}
		}
		if (Dumpster.StudentToGoMissing > 0)
		{
			Dumpster.SetVictimMissing();
		}
		for (ID = 0; ID < GardenHoles.Length; ID++)
		{
			GardenHoles[ID].EndOfDayCheck();
		}
		for (ID = 1; ID < Yandere.Inventory.ShrineCollectibles.Length; ID++)
		{
			if (Yandere.Inventory.ShrineCollectibles[ID])
			{
				PlayerGlobals.SetShrineCollectible(ID, value: true);
			}
		}
		Incinerator.SetVictimsMissing();
		WoodChipper.SetVictimsMissing();
		if (FragileTarget > 0)
		{
			StudentGlobals.FragileTarget = FragileTarget;
			StudentGlobals.FragileSlave = 5;
		}
		if (StudentManager.ReactedToGameLeader)
		{
			SchoolGlobals.ReactedToGameLeader = true;
		}
		if (TaskGlobals.GetTaskStatus(46) == 1)
		{
			TaskGlobals.SetTaskStatus(46, 0);
		}
		if (StudentManager.Students[46] != null && StudentManager.Students[46].TaskPhase == 5)
		{
			TaskGlobals.SetTaskStatus(46, 3);
			PlayerGlobals.SetStudentFriend(46, value: true);
			NewFriends++;
		}
		if (NewFriends > 0)
		{
			PlayerGlobals.Friends += NewFriends;
		}
		if (Yandere.Alerts > 0)
		{
			Debug.Log("PlayerGlobals.Alerts is being incremented!");
			PlayerGlobals.Alerts += Yandere.Alerts;
		}
		else
		{
			Debug.Log("PlayerGlobals.Alerts is not being incremented!");
		}
		if (Arrests > 0)
		{
			Debug.Log("Increasing Atmosphere by 50% because a culprit was arrested.");
			SchoolGlobals.SchoolAtmosphere += 0.5f;
		}
		if (Counselor.ExpelledDelinquents)
		{
			SchoolGlobals.SchoolAtmosphere += 0.25f;
			if (ClubGlobals.Club == ClubType.Delinquent)
			{
				ClubGlobals.Club = ClubType.None;
			}
		}
		if (Yandere.Inventory.FakeID)
		{
			PlayerGlobals.FakeID = true;
		}
		if (RaibaruLoner)
		{
			PlayerGlobals.RaibaruLoner = true;
		}
		if (StopMourning)
		{
			GameGlobals.SenpaiMourning = false;
		}
		if (StudentManager.EmbarassingSecret)
		{
			SchemeGlobals.SetServicePurchased(4, value: true);
			SchemeGlobals.EmbarassingSecret = true;
		}
		EventGlobals.LearnedAboutPhotographer = LearnedAboutPhotographer;
		EventGlobals.OsanaEvent1 = LearnedOsanaInfo1;
		EventGlobals.OsanaEvent2 = LearnedOsanaInfo2;
		CollectibleGlobals.MatchmakingGifts = MatchmakingGifts;
		CollectibleGlobals.SenpaiGifts = SenpaiGifts;
		PlayerGlobals.PantyShots = Yandere.Inventory.PantyShots;
		PlayerGlobals.Money = Yandere.Inventory.Money;
		ClassGlobals.Biology = Class.Biology;
		ClassGlobals.Chemistry = Class.Chemistry;
		ClassGlobals.Language = Class.Language;
		ClassGlobals.Physical = Class.Physical;
		ClassGlobals.Psychology = Class.Psychology;
		ClassGlobals.BiologyGrade = Class.BiologyGrade;
		ClassGlobals.ChemistryGrade = Class.ChemistryGrade;
		ClassGlobals.LanguageGrade = Class.LanguageGrade;
		ClassGlobals.PhysicalGrade = Class.PhysicalGrade;
		ClassGlobals.PsychologyGrade = Class.PsychologyGrade;
		PlayerGlobals.Numbness = Class.Numbness;
		PlayerGlobals.Seduction = Class.Seduction;
		PlayerGlobals.Enlightenment = Class.Enlightenment;
		PlayerGlobals.Headset = Yandere.Inventory.Headset;
		PlayerGlobals.DirectionalMic = Yandere.Inventory.DirectionalMic;
		WeaponManager.TrackDumpedWeapons();
		StudentManager.CommunalLocker.RivalPhone.StolenPhoneDropoff.SetPhonesHacked();
		Yandere.PauseScreen.FavorMenu.ServicesMenu.SaveServicesPurchased();
		StudentManager.LoveManager.SaveSuitorInstructions();
		StudentManager.TaskManager.SaveTaskStatuses();
		StudentManager.SaveCollectibles();
		StudentManager.SavePhotographs();
		StudentManager.SavePantyshots();
		StudentManager.SaveReps();
		if (StudentManager.DatingMinigame.DataNeedsSaving)
		{
			StudentManager.DatingMinigame.SaveTopicsAndCompliments();
		}
		if (StudentManager.DatingMinigame.GiftStatusNeedsSaving)
		{
			StudentManager.DatingMinigame.SaveGiftStatus();
		}
		if (StudentManager.DialogueWheel.AdviceWindow.DataNeedsSaving)
		{
			StudentManager.DialogueWheel.AdviceWindow.SaveTopicsAndCompliments();
		}
		if (StudentManager.DialogueWheel.AdviceWindow.GiftDataNeedsSaving)
		{
			StudentManager.DialogueWheel.AdviceWindow.SaveGiftStatus();
		}
		Debug.Log("Right here, at the End of Day Results Screen, SchemeGlobals.GetSchemeStage(6) is: " + SchemeGlobals.GetSchemeStage(6));
		if (SchemeGlobals.GetSchemeStage(6) == 8)
		{
			SchemeGlobals.SetSchemeStage(6, 9);
			Yandere.PauseScreen.Schemes.UpdateInstructions();
		}
		Yandere.CameraEffects.UpdateBloom(1f);
		Yandere.CameraEffects.UpdateBloomKnee(0.5f);
		Yandere.CameraEffects.UpdateBloomRadius(4f);
		DatingGlobals.RivalSabotaged = StudentManager.SabotageProgress;
		PlayerGlobals.PersonaID = Yandere.PersonaID;
		Police.Corpses += Police.DrownVictims;
		PlayerGlobals.CorpsesDiscovered += Police.Corpses;
		ClassGlobals.BonusStudyPoints = Class.StudyPoints + Class.BonusPoints;
		HomeGlobals.LateForSchool = false;
		PlayerGlobals.ShrineItems += ShrineItemsCollected;
		Counselor.SaveExcusesUsed();
		Counselor.ExpelStudents();
		Counselor.SaveCounselorData();
		StudentGlobals.ExpelProgress = Counselor.RivalExpelProgress;
		CounselorGlobals.ReportedAlcohol = Counselor.ReportedAlcohol;
		CounselorGlobals.ReportedCigarettes = Counselor.ReportedCigarettes;
		CounselorGlobals.ReportedCondoms = Counselor.ReportedCondoms;
		CounselorGlobals.ReportedTheft = Counselor.ReportedTheft;
		CounselorGlobals.ReportedCheating = Counselor.ReportedCheating;
		for (int j = 1; j < WeaponManager.BroughtWeapons.Length; j++)
		{
			if (WeaponManager.BroughtWeapons[j] == null || WeaponManager.BroughtWeapons[j].Disposed)
			{
				PlayerGlobals.SetCannotBringItem(j, value: true);
			}
		}
		if (Yandere.Inventory.ArrivedWithRatPoison && Yandere.Inventory.EmeticPoisons == 0)
		{
			PlayerGlobals.SetCannotBringItem(4, value: true);
		}
		if (Yandere.Inventory.ArrivedWithSake && !Yandere.Inventory.Sake)
		{
			PlayerGlobals.SetCannotBringItem(5, value: true);
		}
		if (Yandere.Inventory.ArrivedWithCigs && !Yandere.Inventory.Cigs)
		{
			PlayerGlobals.SetCannotBringItem(6, value: true);
		}
		if (Yandere.Inventory.ArrivedWithCondoms && !Yandere.Inventory.Condoms)
		{
			PlayerGlobals.SetCannotBringItem(7, value: true);
		}
		if (Yandere.Inventory.ArrivedWithSedative && Yandere.Inventory.SedativePoisons == 0)
		{
			PlayerGlobals.SetCannotBringItem(9, value: true);
			PlayerGlobals.BoughtSedative = false;
		}
		if (Yandere.Inventory.ArrivedWithPoison && Yandere.Inventory.LethalPoisons == 0)
		{
			Debug.Log("The player arrived with lethal poison. The player doesn't have lethal poison anymore.");
			PlayerGlobals.SetCannotBringItem(11, value: true);
			PlayerGlobals.BoughtPoison = false;
		}
		if (Yandere.Inventory.LethalPoisons > 0)
		{
			Debug.Log("The player is bringing some poison home from school.");
			PlayerGlobals.BoughtPoison = true;
		}
		if (Yandere.Inventory.SedativePoisons > 0)
		{
			PlayerGlobals.BoughtSedative = true;
		}
		if (Yandere.Inventory.LockPick)
		{
			PlayerGlobals.BoughtLockpick = true;
		}
		if (Counselor.ReportedNarcotics || (Yandere.Inventory.ArrivedWithNarcotics && !Yandere.Inventory.Narcotics))
		{
			PlayerGlobals.BoughtNarcotics = false;
		}
		if (ExplosiveDeviceUsed)
		{
			PlayerGlobals.BoughtExplosive = false;
		}
		if (Yandere.Inventory.Cigs)
		{
			PlayerGlobals.SetCannotBringItem(6, value: false);
		}
		if (Yandere.Inventory.Sake)
		{
			PlayerGlobals.SetCannotBringItem(5, value: false);
		}
		if (Yandere.Inventory.EmeticPoisons > 0)
		{
			PlayerGlobals.SetCannotBringItem(4, value: false);
		}
		if (Yandere.Inventory.SedativePoisons > 0)
		{
			PlayerGlobals.BoughtSedative = true;
			PlayerGlobals.SetCannotBringItem(9, value: false);
		}
		if (ArticleID == 1)
		{
			PlayerGlobals.Reputation += 20f * (1f + (float)ClassGlobals.LanguageGrade * 0.2f);
		}
		else if (ArticleID == 3)
		{
			SchoolGlobals.SchoolAtmosphere += 20f * (1f + (float)ClassGlobals.LanguageGrade * 0.2f);
		}
		if (PlayerGlobals.Reputation > 100f)
		{
			PlayerGlobals.Reputation = 100f;
		}
		if (HeardMegami)
		{
			SchoolGlobals.SCP = true;
		}
		int num = 0;
		for (int k = 0; k < 101; k++)
		{
			if (StudentManager.Students[k] != null && StudentManager.Students[k].Alive)
			{
				if (StudentManager.Students[k].TimesBloodWitnessed > 0)
				{
					BloodWitnessed++;
				}
				if (StudentManager.Students[k].TimesWeaponWitnessed > 0)
				{
					WeaponWitnessed++;
				}
				if (StudentManager.Students[k].TimesAlarmed > 0)
				{
					num++;
				}
			}
		}
		PlayerGlobals.WeaponWitnessed += WeaponWitnessed;
		PlayerGlobals.BloodWitnessed += BloodWitnessed;
		PlayerGlobals.Alarms += num;
		ClubManager.UpdateQuitClubs();
		ClubManager.UpdateKickedClubs();
		StudentGlobals.UpdateRivalReputation = false;
		ClubGlobals.ActivitiesAttended = ClubManager.ActivitiesAttended;
		UpdatePreviousRivalFriendships();
		ArrestStudents();
		SaveTopicsLearned();
		SaveTopicsDiscussed();
		StudentManager.DialogueWheel.Social.SaveFriendships();
		RemovableItemManager.RemoveItems();
		if (PoliceArrived)
		{
			GameGlobals.PoliceYesterday = true;
			PlayerGlobals.PoliceVisits++;
		}
		if (GrudgeConversationHappened)
		{
			GameGlobals.GrudgeConversationHappened = true;
		}
		Yandere.PauseScreen.PhotoGallery.SavePhotosTaken();
		SchoolManga.SaveMangaProgress();
		GrowStations[1].SaveSeeds();
		GrowStations[2].SaveSeeds();
		Plant.SavePlantProgress();
		Yandere.CameraEffects.UpdateVignette(0f);
		GrantAchievement();
	}

	private void DisableThings(StudentScript TargetStudent)
	{
		if (TargetStudent != null)
		{
			TargetStudent.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
			TargetStudent.CharacterAnimation.enabled = true;
			TargetStudent.CharacterAnimation.Play(TargetStudent.IdleAnim);
			TargetStudent.EmptyHands();
			TargetStudent.SpeechLines.Stop();
			TargetStudent.Ragdoll.Zs.SetActive(value: false);
			TargetStudent.SmartPhone.SetActive(value: false);
			TargetStudent.MyController.enabled = false;
			TargetStudent.ShoeRemoval.enabled = false;
			TargetStudent.enabled = false;
			TargetStudent.gameObject.SetActive(value: true);
			TargetStudent.transform.parent = base.transform;
			TargetStudent.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
		}
	}

	private void CheckForNatureOfDeath()
	{
		if (!(StudentManager.Students[StudentManager.RivalID] != null))
		{
			return;
		}
		RagdollScript ragdoll = StudentManager.Students[StudentManager.RivalID].Ragdoll;
		if (ragdoll.Student.DeathType == DeathType.Burning)
		{
			GameGlobals.SpecificEliminationID = 5;
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("Burn", 1);
			}
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("a", 1);
			}
			Debug.Log("The game knows that she was burned, though.");
		}
		else if (ragdoll.Student.DeathType == DeathType.Electrocution)
		{
			GameGlobals.SpecificEliminationID = 8;
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("Electrocute", 1);
			}
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("a", 1);
			}
			Debug.Log("The game knows that she was electrocuted, though.");
			Debug.Log("The game should now be informing the Content Checklist that the player has performed an electrocution.");
		}
		else if (ragdoll.Student.DeathType == DeathType.Weight)
		{
			GameGlobals.SpecificEliminationID = 6;
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("Crush", 1);
			}
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("a", 1);
			}
			Debug.Log("The game knows that she was crushed, though.");
		}
		else if (ragdoll.Student.DeathType == DeathType.Drowning)
		{
			if (PoolEvent)
			{
				Debug.Log("The player eliminated the rival during a pool event.");
				GameGlobals.SpecificEliminationID = 16;
				if (!GameGlobals.Debug)
				{
					PlayerPrefs.SetInt("Pool", 1);
				}
				if (!GameGlobals.Debug)
				{
					PlayerPrefs.SetInt("a", 1);
				}
			}
			else
			{
				Debug.Log("The game knows that she drowned, though.");
				GameGlobals.SpecificEliminationID = 7;
				if (!GameGlobals.Debug)
				{
					PlayerPrefs.SetInt("Drown", 1);
				}
				if (!GameGlobals.Debug)
				{
					PlayerPrefs.SetInt("a", 1);
				}
			}
		}
		else if (ragdoll.Decapitated)
		{
			GameGlobals.SpecificEliminationID = 10;
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("Fan", 1);
			}
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("a", 1);
			}
			Debug.Log("The game knows that she was decapitated, though.");
		}
		else if (ragdoll.Student.DeathType == DeathType.Poison)
		{
			GameGlobals.SpecificEliminationID = 15;
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("Poison", 1);
			}
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("a", 1);
			}
			Debug.Log("The game knows that she was poisoned, though.");
		}
		else if (ragdoll.Student.DeathType == DeathType.Falling)
		{
			GameGlobals.SpecificEliminationID = 17;
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("Push", 1);
			}
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("a", 1);
			}
			Debug.Log("The game knows that she was pushed, though.");
		}
		else if (ragdoll.Student.Hunted)
		{
			GameGlobals.SpecificEliminationID = 14;
			if (!GameGlobals.Debug)
			{
				if (ragdoll.Student.MurderedByFragile)
				{
					if (!GameGlobals.Debug)
					{
						PlayerPrefs.SetInt("DrivenToMurder", 1);
					}
					if (!GameGlobals.Debug)
					{
						PlayerPrefs.SetInt("a", 1);
					}
				}
				else
				{
					if (!GameGlobals.Debug)
					{
						PlayerPrefs.SetInt("MurderSuicide", 1);
					}
					if (!GameGlobals.Debug)
					{
						PlayerPrefs.SetInt("a", 1);
					}
				}
			}
			Debug.Log("The game knows that the rival died as part of a murder-suicide, though.");
		}
		else if (ragdoll.Student.DeathType == DeathType.Weapon)
		{
			GameGlobals.SpecificEliminationID = 1;
			AchievementToGrant = "Attack";
			Debug.Log("The game knows that she was attacked, though.");
		}
		else if (ragdoll.Student.DeathType == DeathType.Explosion)
		{
			GameGlobals.SpecificEliminationID = 20;
			AchievementToGrant = "Attack";
			Debug.Log("The game knows that she was blown up, though.");
		}
	}

	public void SetFormerRivalDeath(int RivalID, StudentScript Rival)
	{
		Debug.Log("The elimination information for Rival #" + RivalID + " is now being updated.");
		if (Rival.DeathType == DeathType.Burning)
		{
			GameGlobals.SetSpecificEliminations(RivalID, 5);
		}
		else if (Rival.DeathType == DeathType.Electrocution)
		{
			GameGlobals.SetSpecificEliminations(RivalID, 8);
		}
		else if (Rival.DeathType == DeathType.Weight)
		{
			GameGlobals.SetSpecificEliminations(RivalID, 6);
		}
		else if (Rival.DeathType == DeathType.Drowning)
		{
			if (PoolEvent)
			{
				GameGlobals.SetSpecificEliminations(RivalID, 16);
			}
			else
			{
				GameGlobals.SetSpecificEliminations(RivalID, 7);
			}
		}
		else if (Rival.Ragdoll.Decapitated)
		{
			GameGlobals.SetSpecificEliminations(RivalID, 10);
		}
		else if (Rival.DeathType == DeathType.Poison)
		{
			GameGlobals.SetSpecificEliminations(RivalID, 15);
		}
		else if (Rival.DeathType == DeathType.Falling)
		{
			GameGlobals.SetSpecificEliminations(RivalID, 17);
		}
		else if (Rival.Hunted)
		{
			Debug.Log("Was killed by a mind-broken slave.");
			GameGlobals.SetSpecificEliminations(RivalID, 14);
		}
		else if (Rival.DeathType == DeathType.Weapon)
		{
			Debug.Log("Was killed by a weapon.");
			GameGlobals.SetSpecificEliminations(RivalID, 1);
		}
		else
		{
			Debug.Log("Specific method of death wasn't listed in the chain.");
		}
		if (PoliceArrived)
		{
			Debug.Log("The police arrived.");
		}
		else
		{
			Debug.Log("The police didn't arrived.");
		}
		GameGlobals.SetRivalEliminations(RivalID, 14);
	}

	private void UpdatePreviousRivalFriendships()
	{
		if (GameGlobals.SpecificEliminationID == 2)
		{
			Debug.Log("This week's rival was befriended.");
			if ((StudentManager.Students[StudentManager.RivalID] != null && StudentManager.Students[StudentManager.RivalID].Grudge) || StudentGlobals.GetStudentGrudge(StudentManager.RivalID))
			{
				Debug.Log("However, she witnessed the player commit murder! Not friends anymore!");
				GameGlobals.RivalEliminationID = 7;
			}
		}
		for (int i = 1; i < DateGlobals.Week; i++)
		{
			if (GameGlobals.GetSpecificEliminations(i) == 2)
			{
				Debug.Log("Rival #" + i + " was befriended.");
				if ((StudentManager.Students[StudentManager.RivalID + 10] != null && StudentManager.Students[StudentManager.RivalID + 10].Grudge) || StudentGlobals.GetStudentGrudge(i + 10))
				{
					Debug.Log("However, she witnessed the player commit murder! Not friends anymore!");
					GameGlobals.SetRivalEliminations(i, 7);
				}
			}
		}
	}

	public void ArrestStudents()
	{
		for (int i = 1; i < 101; i++)
		{
			if (StudentsToArrest[i])
			{
				StudentGlobals.SetStudentArrested(i, value: true);
			}
		}
	}

	public void SaveTopicsLearned()
	{
		for (int i = 1; i < 101; i++)
		{
			for (int j = 1; j < 26; j++)
			{
				ConversationGlobals.SetTopicLearnedByStudent(j, i, StudentManager.GetTopicLearnedByStudent(j, i));
			}
		}
	}

	public void SaveTopicsDiscussed()
	{
		Debug.Log("Attempting to save all of the ''topics discussed ''.");
		for (int i = 1; i < 101; i++)
		{
			for (int j = 1; j < 26; j++)
			{
				ConversationGlobals.SetTopicDiscussedWithStudent(j, i, StudentManager.GetTopicDiscussedWithStudent(j, i));
			}
		}
	}

	public void GrantAchievement()
	{
		if (AchievementToGrant == "Attack")
		{
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("Attack", 1);
			}
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("a", 1);
			}
		}
	}

	public void LateUpdate()
	{
		if (Yandere.LookAt.enabled)
		{
			Yandere.Head.LookAt(Yandere.LookAt.target);
		}
	}

	public void FunCheck()
	{
		if (Yandere.Kills > 0 || Police.Deaths > 0)
		{
			Debug.Log("The player killed someone.");
			FunGameOver = true;
		}
		if (DateGlobals.Week == 9 && DateGlobals.Weekday == DayOfWeek.Friday)
		{
			Debug.Log("GameGlobals.SenpaiLove is: " + GameGlobals.SenpaiLove);
			Debug.Log("Reputation.Reputation + Reputation.PendingRep is: " + (Reputation.Reputation + Reputation.PendingRep));
			if (GameGlobals.SenpaiLove < 100 || Reputation.Reputation + Reputation.PendingRep < 100f)
			{
				FunGameOver = true;
			}
		}
	}
}
