using UnityEngine;
using UnityEngine.SceneManagement;

public class LivingRoomCutsceneScript : MonoBehaviour
{
	public ColorCorrectionCurves ColorCorrection;

	public CosmeticScript YandereCosmetic;

	public AmbientObscurance Obscurance;

	public RivalDataScript RivalData;

	public Vignetting Vignette;

	public NoiseAndGrain Noise;

	public UISprite SkipCircle;

	public UIPanel SkipPanel;

	public SkinnedMeshRenderer YandereRenderer;

	public Renderer RightEyeRenderer;

	public Renderer LeftEyeRenderer;

	public Transform KettleCameraDestination;

	public Transform KettleCameraOrigin;

	public Transform FriendshipCamera;

	public Transform LivingRoomCamera;

	public Transform CutsceneCamera;

	public Transform AyanoHead;

	public Transform TeaCamera;

	public Transform AyanoEyes;

	public Transform OsanaEyes;

	public UIPanel EliminationPanel;

	public UIPanel Panel;

	public UISprite SubDarknessBG;

	public UISprite SubDarkness;

	public UISprite Darkness;

	public UILabel EightiesLabel;

	public UILabel PrologueLabel;

	public UILabel Subtitle;

	public Vector3 RightEyeOrigin;

	public Vector3 LeftEyeOrigin;

	public AudioClip DramaticBoom;

	public AudioClip RivalProtest;

	public AudioSource Jukebox;

	public AudioSource MyAudio;

	public AudioSource BGM;

	public GameObject WarningLabel;

	public GameObject TeaSteam;

	public GameObject CatStuff;

	public GameObject OfferTea;

	public GameObject Prologue;

	public GameObject Yandere;

	public GameObject TeaSet;

	public GameObject Rival;

	public Transform RightEye;

	public Transform LeftEye;

	public float CutsceneLimit = 167f;

	public float ShakeStrength;

	public float AnimOffset;

	public float ExitTimer;

	public float EyeShrink;

	public float xOffset;

	public float zOffset;

	public float Timer;

	public float Speed;

	public bool WaitingForInput;

	public bool OsanaCutscene;

	public bool DecisionMade;

	public bool FollowCamera;

	public bool BlurVision;

	public bool DruggedTea;

	public bool Eighties;

	public bool NoSkip;

	public bool Fall;

	public float[] CameraIDs;

	public string[] Lines;

	public float[] Times;

	public float BlurSpeed = 1f;

	public int Branch = 1;

	public int Phase = 1;

	public int ID = 1;

	public Texture ZTR;

	public int ZTRID;

	public Renderer PonytailRenderer;

	public Texture BlondePony;

	public GameObject OriginalHair;

	public GameObject[] VtuberHairs;

	public Texture[] VtuberFaces;

	public Texture[] VtuberEyes;

	public Renderer[] Eye;

	private void Start()
	{
		VtuberCheck();
		SkipPanel.alpha = 0f;
		if (BlondePony != null && GameGlobals.BlondeHair)
		{
			PonytailRenderer.material.mainTexture = BlondePony;
		}
		YandereCosmetic.FemaleUniformID = StudentGlobals.FemaleUniform;
		YandereCosmetic.SetFemaleUniform();
		YandereCosmetic.RightWristband.SetActive(false);
		YandereCosmetic.LeftWristband.SetActive(false);
		YandereCosmetic.ThickBrows.SetActive(false);
		for (ID = 0; ID < YandereCosmetic.FemaleHair.Length; ID++)
		{
			GameObject gameObject = YandereCosmetic.FemaleHair[ID];
			if (gameObject != null)
			{
				gameObject.SetActive(false);
			}
		}
		for (ID = 0; ID < YandereCosmetic.TeacherHair.Length; ID++)
		{
			GameObject gameObject2 = YandereCosmetic.TeacherHair[ID];
			if (gameObject2 != null)
			{
				gameObject2.SetActive(false);
			}
		}
		for (ID = 0; ID < YandereCosmetic.FemaleAccessories.Length; ID++)
		{
			GameObject gameObject3 = YandereCosmetic.FemaleAccessories[ID];
			if (gameObject3 != null)
			{
				gameObject3.SetActive(false);
			}
		}
		for (ID = 0; ID < YandereCosmetic.TeacherAccessories.Length; ID++)
		{
			GameObject gameObject4 = YandereCosmetic.TeacherAccessories[ID];
			if (gameObject4 != null)
			{
				gameObject4.SetActive(false);
			}
		}
		for (ID = 0; ID < YandereCosmetic.ClubAccessories.Length; ID++)
		{
			GameObject gameObject5 = YandereCosmetic.ClubAccessories[ID];
			if (gameObject5 != null)
			{
				gameObject5.SetActive(false);
			}
		}
		GameObject[] scanners = YandereCosmetic.Scanners;
		foreach (GameObject gameObject6 in scanners)
		{
			if (gameObject6 != null)
			{
				gameObject6.SetActive(false);
			}
		}
		scanners = YandereCosmetic.Flowers;
		foreach (GameObject gameObject7 in scanners)
		{
			if (gameObject7 != null)
			{
				gameObject7.SetActive(false);
			}
		}
		scanners = YandereCosmetic.PunkAccessories;
		foreach (GameObject gameObject8 in scanners)
		{
			if (gameObject8 != null)
			{
				gameObject8.SetActive(false);
			}
		}
		scanners = YandereCosmetic.RedCloth;
		foreach (GameObject gameObject9 in scanners)
		{
			if (gameObject9 != null)
			{
				gameObject9.SetActive(false);
			}
		}
		scanners = YandereCosmetic.Kerchiefs;
		foreach (GameObject gameObject10 in scanners)
		{
			if (gameObject10 != null)
			{
				gameObject10.SetActive(false);
			}
		}
		for (int j = 0; j < 10; j++)
		{
			YandereCosmetic.Fingernails[j].gameObject.SetActive(false);
		}
		ID = 0;
		YandereCosmetic.FemaleHair[1].SetActive(true);
		YandereCosmetic.MyRenderer.materials[2].mainTexture = YandereCosmetic.DefaultFaceTexture;
		Subtitle.text = string.Empty;
		RightEyeRenderer.material.color = new Color(0.33f, 0.33f, 0.33f, 1f);
		LeftEyeRenderer.material.color = new Color(0.33f, 0.33f, 0.33f, 1f);
		if (GameGlobals.VtuberID > 0)
		{
			RightEyeRenderer.material.color = Color.white;
			LeftEyeRenderer.material.color = Color.white;
		}
		RightEyeOrigin = RightEye.localPosition;
		LeftEyeOrigin = LeftEye.localPosition;
		EliminationPanel.alpha = 0f;
		Panel.alpha = 1f;
		ColorCorrection.saturation = 1f;
		Noise.intensityMultiplier = 0f;
		Obscurance.intensity = 0f;
		Vignette.enabled = false;
		Vignette.intensity = 1f;
		Vignette.blur = 1f;
		Vignette.chromaticAberration = 1f;
		if (EventGlobals.OsanaConversation)
		{
			PrologueLabel.transform.localPosition = new Vector3(0f, 125f, 0f);
			PrologueLabel.text = "Osana is eager to report her stalker to the police.\n\nHowever, she knows that the process could take a long time, so she decides to visit Ayano's house and get her cat back before contacting the police.\n\nThe next morning, Osana arrives at Ayano's house...";
			WarningLabel.SetActive(true);
			CatStuff.SetActive(true);
			OsanaCutscene = true;
			Lines = RivalData.OsanaIntroLines;
			Times = RivalData.OsanaIntroTimes;
			MyAudio.clip = RivalData.OsanaIntro;
			BGM.volume = 0.1f;
			if (SchemeGlobals.GetSchemeStage(6) == 9)
			{
				SchemeGlobals.SetSchemeStage(6, 100);
			}
		}
		if (GameGlobals.Eighties)
		{
			EightiesLabel.gameObject.SetActive(true);
			SkipPanel.gameObject.SetActive(false);
			PrologueLabel.enabled = false;
			WarningLabel.SetActive(false);
			Rival.SetActive(false);
			Eighties = true;
		}
	}

	private void Update()
	{
		if (Phase > 3 && !WaitingForInput && Timer < 172f && !NoSkip)
		{
			SkipPanel.alpha += Time.deltaTime;
			if (Input.GetButton("X"))
			{
				SkipPanel.alpha = 1f;
				SkipCircle.fillAmount -= Time.deltaTime;
				if (SkipCircle.fillAmount == 0f)
				{
					SkipCircle.fillAmount = 1f;
					if (!DecisionMade)
					{
						Yandere.GetComponent<Animation>()["FriendshipYandere"].time = 43f;
						Rival.GetComponent<Animation>()["FriendshipRival"].time = 43f;
						Yandere.GetComponent<Animation>()["FriendshipYandere"].speed = 0f;
						Rival.GetComponent<Animation>()["FriendshipRival"].speed = 0f;
						FriendshipCamera.gameObject.GetComponent<Animation>().Play();
						FriendshipCamera.gameObject.GetComponent<Animation>()["FriendshipCameraFlat"].time = 43f;
						FriendshipCamera.gameObject.GetComponent<Animation>()["FriendshipCameraFlat"].speed = 0f;
						MyAudio.Play();
						MyAudio.time = 43f;
						WaitingForInput = true;
						Timer = 43f;
						Phase = 5;
						ID = 17;
					}
					else
					{
						if (!DruggedTea && Branch < 3)
						{
							Yandere.GetComponent<Animation>()["FriendshipYandere"].time = 172f;
							Rival.GetComponent<Animation>()["FriendshipRival"].time = 172f;
							Yandere.GetComponent<Animation>()["FriendshipYandere"].speed = 0f;
							Rival.GetComponent<Animation>()["FriendshipRival"].speed = 0f;
							FriendshipCamera.gameObject.GetComponent<Animation>().Play();
							FriendshipCamera.gameObject.GetComponent<Animation>()["FriendshipCameraFlat"].time = 172f;
							FriendshipCamera.gameObject.GetComponent<Animation>()["FriendshipCameraFlat"].speed = 0f;
							CameraIDs = RivalData.OsanaBefriendCameraIDs;
							Lines = RivalData.OsanaBefriendLines;
							Times = RivalData.OsanaBefriendTimes;
							Yandere.gameObject.SetActive(true);
							MyAudio.clip = RivalData.OsanaBefriend;
							MyAudio.Play();
							MyAudio.time = 100f;
							SkipPanel.alpha = 0f;
							CutsceneLimit = 172f;
							Timer = 172f;
							Branch = 2;
							Phase = 5;
							ID = 37;
						}
						else
						{
							Rival.GetComponent<Animation>()["FriendshipRival"].speed = 1f;
							base.transform.parent = OsanaEyes;
							base.transform.localPosition = new Vector3(0f, 0f, 0f);
							base.transform.LookAt(AyanoEyes);
							Vignette.enabled = true;
							BlurVision = true;
							Yandere.gameObject.SetActive(true);
							Yandere.GetComponent<Animation>().Play("f02_evilWitness_00");
							Yandere.GetComponent<Animation>()["f02_evilWitness_00"].time = 2f;
							Yandere.GetComponent<Animation>()["f02_evilWitness_00"].speed = 0.25f;
							base.transform.parent = AyanoEyes;
							base.transform.localPosition = new Vector3(0f, 0f, 0.5f);
							base.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
							FollowCamera = false;
							CameraIDs = RivalData.OsanaBetrayCameraIDs;
							Lines = RivalData.OsanaBetrayLines;
							Times = RivalData.OsanaBetrayTimes;
							MyAudio.clip = RivalData.OsanaBetray;
							MyAudio.time = 32f;
							MyAudio.Play();
							CutsceneLimit = 110f;
							Timer = 103f;
							Branch = 3;
							Phase = 5;
							ID = 9;
						}
						SkipPanel.alpha = 0f;
						NoSkip = true;
					}
				}
			}
			else
			{
				SkipCircle.fillAmount = 1f;
			}
		}
		if (Phase == 1)
		{
			Timer += Time.deltaTime;
			if (Timer > 1f)
			{
				Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 0f, Time.deltaTime));
				if (Darkness.color.a == 0f && Input.GetButtonDown("A"))
				{
					Timer = 0f;
					Phase++;
				}
			}
		}
		else if (Phase == 2)
		{
			Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 1f, Time.deltaTime));
			if (Darkness.color.a == 1f)
			{
				Vignette.enabled = true;
				Prologue.SetActive(false);
				if (!Eighties)
				{
					base.transform.parent = LivingRoomCamera;
					base.transform.localPosition = new Vector3(-0.65f, 0f, 0f);
					base.transform.localEulerAngles = new Vector3(0f, -90f, 0f);
					Phase++;
					if (!OsanaCutscene)
					{
						BGM.Play();
					}
				}
				else
				{
					base.transform.position = TeaCamera.position;
					base.transform.rotation = TeaCamera.rotation;
					TeaSet.SetActive(true);
					Phase = 100;
				}
			}
		}
		else if (Phase == 3)
		{
			Timer += Time.deltaTime;
			if (Timer > 1f)
			{
				Panel.alpha = Mathf.MoveTowards(Panel.alpha, 0f, Time.deltaTime);
				if (Panel.alpha == 0f)
				{
					Yandere.GetComponent<Animation>()["FriendshipYandere"].time = 0f;
					Rival.GetComponent<Animation>()["FriendshipRival"].time = 0f;
					if (OsanaCutscene)
					{
						Yandere.GetComponent<Animation>()["FriendshipYandere"].speed = 0f;
						Rival.GetComponent<Animation>()["FriendshipRival"].speed = 0f;
					}
					LivingRoomCamera.gameObject.GetComponent<Animation>().Play();
					Timer = 0f;
					Phase++;
				}
			}
		}
		else if (Phase == 4)
		{
			SkipPanel.alpha += Time.deltaTime;
			Timer += Time.deltaTime;
			if (Timer > 1f && OsanaCutscene && !BGM.isPlaying)
			{
				BGM.Play();
			}
			if (Timer > 10f)
			{
				base.transform.parent = FriendshipCamera;
				base.transform.localPosition = new Vector3(-0.65f, 0f, 0f);
				base.transform.localEulerAngles = new Vector3(0f, -90f, 0f);
				FriendshipCamera.gameObject.GetComponent<Animation>().Play();
				MyAudio.Play();
				Subtitle.text = Lines[0];
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 5)
		{
			if (Input.GetKeyDown(KeyCode.Z))
			{
				Timer += 2f;
				MyAudio.time += 2f;
				if (FriendshipCamera.gameObject.GetComponent<Animation>()["FriendshipCameraFlat"].speed > 0f)
				{
					FriendshipCamera.gameObject.GetComponent<Animation>()["FriendshipCameraFlat"].time += 2f;
				}
			}
			Timer += Time.deltaTime;
			if (Timer < 166f && !OsanaCutscene)
			{
				Yandere.GetComponent<Animation>()["FriendshipYandere"].time = MyAudio.time + AnimOffset;
				Rival.GetComponent<Animation>()["FriendshipRival"].time = MyAudio.time + AnimOffset;
			}
			if (ID < Times.Length)
			{
				if (MyAudio.time > Times[ID] || !MyAudio.isPlaying)
				{
					if (OsanaCutscene)
					{
						if (Branch == 1)
						{
							Yandere.GetComponent<Animation>()["FriendshipYandere"].time = MyAudio.time + AnimOffset;
							Rival.GetComponent<Animation>()["FriendshipRival"].time = MyAudio.time + AnimOffset;
						}
						else
						{
							Yandere.GetComponent<Animation>()["FriendshipYandere"].time = MyAudio.time + 66f;
							Rival.GetComponent<Animation>()["FriendshipRival"].time = MyAudio.time + 66f;
							if (Branch == 3)
							{
								Rival.GetComponent<Animation>()["FriendshipRival"].time = MyAudio.time + 67f;
							}
						}
						if (ID > 1 && Branch > 1)
						{
							if (CameraIDs[ID] == 0f)
							{
								FriendshipCamera.gameObject.GetComponent<Animation>()["FriendshipCameraFlat"].speed = 1f;
							}
							else if (CameraIDs[ID] == 1000f)
							{
								Rival.GetComponent<Animation>()["FriendshipRival"].speed = 1f;
								base.transform.parent = OsanaEyes;
								base.transform.localPosition = new Vector3(0f, 0f, 0f);
								base.transform.LookAt(AyanoEyes);
								Vignette.enabled = true;
								FollowCamera = true;
								BlurVision = true;
							}
							else if (CameraIDs[ID] == 1001f)
							{
								if (FollowCamera)
								{
									Yandere.GetComponent<Animation>().Play("f02_evilWitness_00");
									Yandere.GetComponent<Animation>()["f02_evilWitness_00"].time = 2f;
									Yandere.GetComponent<Animation>()["f02_evilWitness_00"].speed = 0.25f;
								}
								base.transform.parent = AyanoEyes;
								base.transform.localPosition = new Vector3(0f, 0f, 0.5f);
								base.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
								FollowCamera = false;
							}
							else if (CameraIDs[ID] == 1002f)
							{
								Darkness.alpha = 0f;
								Panel.alpha = 1f;
								BlurSpeed = 10f;
								Fall = true;
							}
							else
							{
								FriendshipCamera.gameObject.GetComponent<Animation>()["FriendshipCameraFlat"].time = CameraIDs[ID];
								FriendshipCamera.gameObject.GetComponent<Animation>()["FriendshipCameraFlat"].speed = 0f;
							}
						}
					}
					Subtitle.text = Lines[ID];
					ID++;
					if (ID == 3)
					{
						OfferTea.SetActive(false);
					}
				}
			}
			else if (OsanaCutscene && Branch == 1)
			{
				Subtitle.text = "Here's your tea.";
				OfferTea.SetActive(true);
				Yandere.SetActive(true);
				if (!DruggedTea)
				{
					Debug.Log("Transitioning into Befriend branch NOW.");
					CameraIDs = RivalData.OsanaBefriendCameraIDs;
					Lines = RivalData.OsanaBefriendLines;
					Times = RivalData.OsanaBefriendTimes;
					MyAudio.clip = RivalData.OsanaBefriend;
					MyAudio.time = 0f;
					MyAudio.Play();
					CutsceneLimit = 172f;
					Branch = 2;
				}
				else
				{
					Debug.Log("Transitioning into Betray branch NOW.");
					CameraIDs = RivalData.OsanaBetrayCameraIDs;
					Lines = RivalData.OsanaBetrayLines;
					Times = RivalData.OsanaBetrayTimes;
					MyAudio.clip = RivalData.OsanaBetray;
					MyAudio.time = 0f;
					MyAudio.Play();
					CutsceneLimit = 110f;
					Branch = 3;
				}
				ID = 1;
			}
			if (OsanaCutscene)
			{
				if (Branch == 1)
				{
					if (ID == 12)
					{
						if (!TeaSteam.activeInHierarchy)
						{
							base.transform.parent = null;
							base.transform.position = KettleCameraOrigin.position;
							base.transform.rotation = KettleCameraOrigin.rotation;
							TeaSteam.SetActive(true);
						}
						else
						{
							Speed += Time.deltaTime * 0.2f;
							base.transform.position = Vector3.Lerp(base.transform.position, KettleCameraDestination.position, Time.deltaTime * Speed);
						}
					}
					else if (ID > 12 && ID < 16)
					{
						base.transform.position = new Vector3(-6f, 1f, 3f);
						base.transform.localEulerAngles = new Vector3(0f, 90f, 0f);
					}
					else if (ID > 17 && ID < 24 && !DecisionMade)
					{
						SkipPanel.alpha = Mathf.MoveTowards(SkipPanel.alpha, 0f, Time.deltaTime);
						if (!TeaSet.activeInHierarchy)
						{
							WaitingForInput = true;
							base.transform.parent = null;
							base.transform.position = TeaCamera.position;
							base.transform.rotation = TeaCamera.rotation;
							Yandere.SetActive(false);
							TeaSet.SetActive(true);
							AnimOffset += 2f;
						}
						if (Input.GetButtonDown("A"))
						{
							WaitingForInput = false;
							DecisionMade = true;
						}
						if (Input.GetButtonDown("B"))
						{
							WaitingForInput = false;
							DecisionMade = true;
							DruggedTea = true;
						}
					}
					else
					{
						base.transform.parent = FriendshipCamera;
						base.transform.localEulerAngles = new Vector3(0f, -90f, 0f);
						if (ID == 16 && FriendshipCamera.gameObject.GetComponent<Animation>()["FriendshipCameraFlat"].time < 44f)
						{
							FriendshipCamera.gameObject.GetComponent<Animation>()["FriendshipCameraFlat"].time = 44f;
							FriendshipCamera.gameObject.GetComponent<Animation>()["FriendshipCameraFlat"].speed = 0f;
						}
					}
				}
				else
				{
					int branch = Branch;
					int num = 2;
				}
			}
			if (!OsanaCutscene)
			{
				if (MyAudio.time > 54f)
				{
					DecreaseYandereEffects();
				}
				else if (MyAudio.time > 42f)
				{
					IncreaseYandereEffects();
				}
			}
			else if (Branch == 1)
			{
				if (DecisionMade || MyAudio.time > 60f)
				{
					DecreaseYandereEffects();
				}
				else if (MyAudio.time > 43f)
				{
					IncreaseYandereEffects();
				}
			}
			if (Timer > CutsceneLimit)
			{
				Animation component = Yandere.GetComponent<Animation>();
				component["FriendshipYandere"].speed = -0.2f;
				component.Play("FriendshipYandere");
				component["FriendshipYandere"].time = component["FriendshipYandere"].length;
				Subtitle.text = string.Empty;
				Phase = 10;
			}
		}
		else if (Phase == 6)
		{
			if (!MyAudio.isPlaying)
			{
				MyAudio.clip = DramaticBoom;
				MyAudio.Play();
				Subtitle.text = string.Empty;
				Phase++;
			}
		}
		else if (Phase == 7)
		{
			if (!MyAudio.isPlaying)
			{
				if (!OsanaCutscene)
				{
					StudentGlobals.SetStudentKidnapped(81, false);
					StudentGlobals.SetStudentBroken(81, true);
					SchoolGlobals.KidnapVictim = 0;
					StudentGlobals.SetStudentKidnapped(30, true);
					StudentGlobals.SetStudentHealth(30, 100);
					StudentGlobals.SetStudentSanity(30, 100);
					SchoolGlobals.KidnapVictim = 30;
					if (DateGlobals.PassDays < 1)
					{
						DateGlobals.PassDays = 1;
					}
					SceneManager.LoadScene("CalendarScene");
				}
				else
				{
					BetrayRival();
					Debug.Log("EventGlobals.OsanaConversation is currently: " + EventGlobals.OsanaConversation);
				}
				HomeGlobals.StartInBasement = true;
			}
		}
		else if (Phase == 10)
		{
			BGM.volume = 0f;
			SubDarkness.color = new Color(SubDarkness.color.r, SubDarkness.color.g, SubDarkness.color.b, Mathf.MoveTowards(SubDarkness.color.a, 1f, Time.deltaTime * 0.2f));
			if (SubDarkness.color.a == 1f)
			{
				if (DateGlobals.PassDays < 1)
				{
					DateGlobals.PassDays = 1;
				}
				BefriendRival();
				EventGlobals.OsanaConversation = false;
				Debug.Log("EventGlobals.OsanaConversation has been set to: " + EventGlobals.OsanaConversation);
			}
		}
		else if (Phase == 100)
		{
			if (!DecisionMade)
			{
				Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 0f, Time.deltaTime));
				if (Darkness.color.a == 0f)
				{
					if (Input.GetButtonDown("A"))
					{
						if (DateGlobals.Week < 10)
						{
							EightiesLabel.text = "Over a cup of tea, Ryoba describes the deep feelings she has for her Senpai, and explains how heartbroken she would feel if anyone took the boy away from her. She asks the girl to stay away from her Senpai.\n\nRyoba's rival cannot bring herself to compete romantically with someone who entered a life-threatening situation to help her out. She agrees to stay away from Ryoba's Senpai.\n\nRyoba's rival is no longer a threat, and the two girls are now the best of friends!";
						}
						else
						{
							EightiesLabel.text = "After the massive favor that Ryoba did for Sonoko, she can no longer consider Ryoba to be a murder suspect.\n\nOver a cup of tea, Ryoba describes the deep feelings she has for her Senpai, and explains how heartbroken she would feel if anyone took the boy away from her. She asks Sonoko to stay away from her Senpai.\n\nSonoko states that she must continue to investigate Senpai as a potential murder suspect, but will not attempt to date him.\n\nSonoko is no longer a threat, and the two girls are now the best of friends!";
						}
						DecisionMade = true;
					}
					if (Input.GetButtonDown("B"))
					{
						EightiesLabel.text = "Ryoba's rival drinks the drugged tea and passes out. When she wakes up...";
						DecisionMade = true;
						DruggedTea = true;
					}
				}
			}
			else
			{
				Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 1f, Time.deltaTime));
				if (Darkness.color.a == 1f)
				{
					Prologue.SetActive(true);
					DecisionMade = false;
					Phase++;
				}
			}
		}
		else if (Phase == 101)
		{
			if (!DecisionMade)
			{
				Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 0f, Time.deltaTime));
				if (Input.GetButtonDown("A"))
				{
					DecisionMade = true;
				}
			}
			else
			{
				Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 1f, Time.deltaTime));
				if (Darkness.color.a == 1f)
				{
					if (DruggedTea)
					{
						BetrayRival();
					}
					else
					{
						BefriendRival();
					}
				}
			}
		}
		if (Input.GetKeyDown(KeyCode.Minus))
		{
			Time.timeScale -= 1f;
		}
		if (Input.GetKeyDown(KeyCode.Equals))
		{
			Time.timeScale += 1f;
		}
		MyAudio.pitch = Time.timeScale;
		if (!BlurVision)
		{
			return;
		}
		BGM.pitch -= Time.deltaTime * 0.05f;
		Vignette.intensity += Time.deltaTime * BlurSpeed;
		Vignette.blur += Time.deltaTime * BlurSpeed;
		Vignette.chromaticAberration += Time.deltaTime * BlurSpeed;
		if (!Fall)
		{
			return;
		}
		Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 1f, Time.deltaTime));
		base.transform.localPosition -= new Vector3(0f, Time.deltaTime * 0.5f, 0f);
		base.transform.localEulerAngles += new Vector3(Time.deltaTime * 180f, Time.deltaTime * 180f, Time.deltaTime * 180f);
		BGM.volume -= Time.deltaTime;
		if (Darkness.color.a == 1f)
		{
			ExitTimer += Time.deltaTime;
			if (ExitTimer > 3f)
			{
				Phase = 7;
			}
		}
	}

	private void LateUpdate()
	{
		if (Phase > 2)
		{
			if (base.transform.parent != null)
			{
				if (OsanaCutscene)
				{
					if (FriendshipCamera.position.z > 2.4f)
					{
						base.transform.localPosition = new Vector3(-1.4f + ShakeStrength * Random.Range(-1f, 1f), ShakeStrength * Random.Range(-1f, 1f), ShakeStrength * Random.Range(-1f, 1f));
					}
					else if (Branch != 3)
					{
						base.transform.localPosition = new Vector3(-0.65f + ShakeStrength * Random.Range(-1f, 1f), ShakeStrength * Random.Range(-1f, 1f), ShakeStrength * Random.Range(-1f, 1f));
					}
				}
				else
				{
					base.transform.localPosition = new Vector3(-0.65f + ShakeStrength * Random.Range(-1f, 1f), ShakeStrength * Random.Range(-1f, 1f), ShakeStrength * Random.Range(-1f, 1f));
				}
			}
			CutsceneCamera.position = new Vector3(CutsceneCamera.position.x + xOffset, CutsceneCamera.position.y, CutsceneCamera.position.z + zOffset);
			LeftEye.localPosition = new Vector3(LeftEye.localPosition.x, LeftEye.localPosition.y, LeftEyeOrigin.z - EyeShrink * 0.01f);
			RightEye.localPosition = new Vector3(RightEye.localPosition.x, RightEye.localPosition.y, RightEyeOrigin.z + EyeShrink * 0.01f);
			LeftEye.localScale = new Vector3(1f - EyeShrink * 0.5f, 1f - EyeShrink * 0.5f, LeftEye.localScale.z);
			RightEye.localScale = new Vector3(1f - EyeShrink * 0.5f, 1f - EyeShrink * 0.5f, RightEye.localScale.z);
		}
		if (FollowCamera)
		{
			AyanoHead.transform.LookAt(base.transform.position);
		}
	}

	private void IncreaseYandereEffects()
	{
		if (!Jukebox.isPlaying)
		{
			Jukebox.Play();
		}
		Jukebox.volume = Mathf.MoveTowards(Jukebox.volume, 0.1f, Time.deltaTime * 0.1f);
		Vignette.intensity = Mathf.MoveTowards(Vignette.intensity, 5f, Time.deltaTime * 4f / 10f);
		Vignette.blur = Vignette.intensity;
		Vignette.chromaticAberration = Vignette.intensity;
		ColorCorrection.saturation = Mathf.MoveTowards(ColorCorrection.saturation, 0f, Time.deltaTime / 10f);
		Noise.intensityMultiplier = Mathf.MoveTowards(Noise.intensityMultiplier, 3f, Time.deltaTime * 3f / 10f);
		Obscurance.intensity = Mathf.MoveTowards(Obscurance.intensity, 3f, Time.deltaTime * 3f / 10f);
		if (!OsanaCutscene)
		{
			ShakeStrength = Mathf.MoveTowards(ShakeStrength, 0.01f, Time.deltaTime * 0.01f / 10f);
		}
		EyeShrink = Mathf.MoveTowards(EyeShrink, 0.9f, Time.deltaTime);
		if (!(MyAudio.time > 45f))
		{
			return;
		}
		if (MyAudio.time > 54f)
		{
			EliminationPanel.alpha = Mathf.MoveTowards(EliminationPanel.alpha, 0f, Time.deltaTime);
		}
		else if (!OsanaCutscene)
		{
			EliminationPanel.alpha = Mathf.MoveTowards(EliminationPanel.alpha, 1f, Time.deltaTime);
			if (Input.GetButtonDown("X"))
			{
				MyAudio.clip = RivalProtest;
				MyAudio.volume = 1f;
				MyAudio.Play();
				Jukebox.gameObject.SetActive(false);
				BGM.gameObject.SetActive(false);
				Subtitle.text = "Wait, what are you doing?! That's not funny! Stop! Let me go! ...n...NO!!!";
				SubDarknessBG.color = new Color(SubDarknessBG.color.r, SubDarknessBG.color.g, SubDarknessBG.color.b, 1f);
				Phase++;
			}
		}
	}

	private void DecreaseYandereEffects()
	{
		Jukebox.volume = Mathf.MoveTowards(Jukebox.volume, 0f, Time.deltaTime / 5f);
		MyAudio.volume = Mathf.MoveTowards(MyAudio.volume, 1f, Time.deltaTime * 0.1f / 5f);
		Vignette.intensity = Mathf.MoveTowards(Vignette.intensity, 1f, Time.deltaTime * 4f / 5f);
		Vignette.blur = Vignette.intensity;
		Vignette.chromaticAberration = Vignette.intensity;
		ColorCorrection.saturation = Mathf.MoveTowards(ColorCorrection.saturation, 1f, Time.deltaTime / 5f);
		Noise.intensityMultiplier = Mathf.MoveTowards(Noise.intensityMultiplier, 0f, Time.deltaTime * 3f / 5f);
		Obscurance.intensity = Mathf.MoveTowards(Obscurance.intensity, 0f, Time.deltaTime * 3f / 5f);
		ShakeStrength = Mathf.MoveTowards(ShakeStrength, 0f, Time.deltaTime * 0.01f / 5f);
		EliminationPanel.alpha = Mathf.MoveTowards(EliminationPanel.alpha, 0f, Time.deltaTime);
		EyeShrink = Mathf.MoveTowards(EyeShrink, 0f, Time.deltaTime);
	}

	private void BetrayRival()
	{
		StudentGlobals.SetStudentKidnapped(10 + DateGlobals.Week, true);
		StudentGlobals.SetStudentHealth(10 + DateGlobals.Week, 100);
		StudentGlobals.SetStudentSanity(10 + DateGlobals.Week, 100);
		int num = 10 + DateGlobals.Week;
		Debug.Log("The player had " + StudentGlobals.Prisoners + " prisoners in their basement before betraying their rival.");
		StudentGlobals.Prisoners++;
		if (StudentGlobals.Prisoners == 1)
		{
			StudentGlobals.Prisoner1 = num;
		}
		else if (StudentGlobals.Prisoners == 2)
		{
			StudentGlobals.Prisoner2 = num;
		}
		else if (StudentGlobals.Prisoners == 3)
		{
			StudentGlobals.Prisoner3 = num;
		}
		else if (StudentGlobals.Prisoners == 4)
		{
			StudentGlobals.Prisoner4 = num;
		}
		else if (StudentGlobals.Prisoners == 5)
		{
			StudentGlobals.Prisoner5 = num;
		}
		else if (StudentGlobals.Prisoners == 6)
		{
			StudentGlobals.Prisoner6 = num;
		}
		else if (StudentGlobals.Prisoners == 7)
		{
			StudentGlobals.Prisoner7 = num;
		}
		else if (StudentGlobals.Prisoners == 8)
		{
			StudentGlobals.Prisoner8 = num;
		}
		else if (StudentGlobals.Prisoners == 9)
		{
			StudentGlobals.Prisoner9 = num;
		}
		else if (StudentGlobals.Prisoners == 10)
		{
			StudentGlobals.Prisoner10 = num;
		}
		Debug.Log("Now that we have betrayed the rival, there should be " + StudentGlobals.Prisoners + " prisoners in the basement, and the rival should be Prisoner #" + StudentGlobals.Prisoners);
		EventGlobals.OsanaConversation = true;
		SceneManager.LoadScene("GenocideScene");
		GameGlobals.RivalEliminationID = 11;
		GameGlobals.NonlethalElimination = true;
		GameGlobals.SpecificEliminationID = 3;
		if (!GameGlobals.Debug)
		{
			PlayerPrefs.SetInt("Betray", 1);
		}
		if (!GameGlobals.Debug)
		{
			PlayerPrefs.SetInt("a", 1);
		}
	}

	private void BefriendRival()
	{
		SceneManager.LoadScene("CalendarScene");
		GameGlobals.RivalEliminationID = 4;
		GameGlobals.NonlethalElimination = true;
		GameGlobals.SpecificEliminationID = 2;
		if (!GameGlobals.Debug)
		{
			PlayerPrefs.SetInt("Befriend", 1);
		}
		if (!GameGlobals.Debug)
		{
			PlayerPrefs.SetInt("a", 1);
		}
	}

	private void VtuberCheck()
	{
		if (GameGlobals.VtuberID > 0)
		{
			OriginalHair.transform.position = new Vector3(0f, 100f, 0f);
			YandereCosmetic.FaceTexture = VtuberFaces[GameGlobals.VtuberID];
			YandereCosmetic.DefaultFaceTexture = VtuberFaces[GameGlobals.VtuberID];
			YandereCosmetic.FemaleHairRenderers[1].material.mainTexture = VtuberFaces[GameGlobals.VtuberID];
			RightEyeRenderer.material.mainTexture = VtuberFaces[GameGlobals.VtuberID];
			LeftEyeRenderer.material.mainTexture = VtuberFaces[GameGlobals.VtuberID];
			RightEyeRenderer.material.color = Color.white;
			LeftEyeRenderer.material.color = Color.white;
			for (ID = 0; ID < 13; ID++)
			{
				YandereRenderer.SetBlendShapeWeight(ID, 0f);
			}
			YandereRenderer.SetBlendShapeWeight(9, 100f);
		}
		else
		{
			for (int i = 1; i < VtuberHairs.Length; i++)
			{
				VtuberHairs[i].SetActive(false);
			}
		}
	}
}
