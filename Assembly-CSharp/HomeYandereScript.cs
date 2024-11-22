using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeYandereScript : MonoBehaviour
{
	public CharacterController MyController;

	public CharacterCustomizationScript CustomHair;

	public StudentManagerScript StudentManager;

	public PauseScreenScript PauseScreen;

	public HomeVideoGamesScript HomeVideoGames;

	public HomeCameraScript HomeCamera;

	public UISprite HomeDarkness;

	public Animation CharacterAnimation;

	public GameObject CutsceneYandere;

	public GameObject Controller;

	public GameObject Character;

	public GameObject Disc;

	public GameObject RyobaLongHair;

	public GameObject RyobaHair;

	public Renderer LongHairRenderer;

	public Renderer PonytailRenderer;

	public AudioClip MiyukiReaction;

	public AudioClip DiscScratch;

	public AudioSource MyAudio;

	public Texture EightiesSocks;

	public Texture BlondePony;

	public Texture BlondeLong;

	public float WalkSpeed;

	public float RunSpeed;

	public bool CannotAlphabet;

	public bool UpdateFace;

	public bool CanMove;

	public bool Running;

	public bool HidePony;

	public string IdleAnim = "";

	public string WalkAnim = "";

	public string RunAnim = "";

	public int Hairstyle;

	public int VictimID;

	public float Timer;

	public float BreastSize = 1f;

	public Transform BreastR;

	public Transform BreastL;

	public float PreviousH;

	public float PreviousV;

	public Vector3 PreviousForward;

	public Vector3 Forward;

	private int Kidnap;

	public int AlphabetID;

	public string[] Letter;

	public SkinnedMeshRenderer MyRenderer;

	public Texture[] UniformTextures;

	public Texture FaceTexture;

	public Mesh[] Uniforms;

	public RiggedAccessoryAttacher Pajamas;

	public Texture PajamaTexture;

	public Mesh PajamaMesh;

	public Texture NudeTexture;

	public Mesh NudeMesh;

	public GameObject[] OriginalHairs;

	public GameObject[] VtuberHairs;

	public Texture[] VtuberFaces;

	public Renderer[] Eyes;

	public bool Vtuber;

	public YandereScript YandereHairHost;

	public YandereScript Yandere;

	public JsonScript JSON;

	public string[] FemaleIdles;

	public string[] FemaleWalks;

	public Transform Head;

	public void Start()
	{
		CustomHair.gameObject.SetActive(value: false);
		VtuberCheck();
		if (CutsceneYandere != null)
		{
			CutsceneYandere.GetComponent<Animation>()["f02_midoriTexting_00"].speed = 0.1f;
		}
		if (SceneManager.GetActiveScene().name == "HomeScene")
		{
			if (!YanvaniaGlobals.DraculaDefeated && !HomeGlobals.MiyukiDefeated)
			{
				if (GameGlobals.CorkboardScene)
				{
					base.transform.position = Vector3.zero;
					base.transform.eulerAngles = Vector3.zero;
				}
				else
				{
					base.enabled = false;
				}
				if (!GameGlobals.Eighties && DateGlobals.Weekday == DayOfWeek.Sunday && GameGlobals.CorkboardScene)
				{
					WearPajamas();
				}
				else if (!HomeGlobals.Night)
				{
					if (DateGlobals.Weekday == DayOfWeek.Sunday)
					{
						WearPajamas();
					}
					else
					{
						ChangeSchoolwear();
						StartCoroutine(ApplyCustomCostume());
					}
				}
				else
				{
					WearPajamas();
				}
			}
			else if (HomeGlobals.StartInBasement)
			{
				HomeGlobals.StartInBasement = false;
				base.transform.position = new Vector3(0f, -135f, 0f);
				base.transform.eulerAngles = Vector3.zero;
			}
			else if (HomeGlobals.MiyukiDefeated)
			{
				base.transform.position = new Vector3(1f, 0f, 0f);
				base.transform.eulerAngles = new Vector3(0f, 90f, 0f);
				CharacterAnimation.Play("f02_discScratch_00");
				Controller.transform.localPosition = new Vector3(0.09425f, 0.0095f, 0.01878f);
				Controller.transform.localEulerAngles = new Vector3(0f, 0f, -180f);
				HomeCamera.Destination = HomeCamera.Destinations[5];
				HomeCamera.Target = HomeCamera.Targets[5];
				Disc.SetActive(value: true);
				WearPajamas();
				MyAudio.clip = MiyukiReaction;
			}
			else
			{
				base.transform.position = new Vector3(1f, 0f, 0f);
				base.transform.eulerAngles = new Vector3(0f, 90f, 0f);
				CharacterAnimation.Play("f02_discScratch_00");
				Controller.transform.localPosition = new Vector3(0.09425f, 0.0095f, 0.01878f);
				Controller.transform.localEulerAngles = new Vector3(0f, 0f, -180f);
				HomeCamera.Destination = HomeCamera.Destinations[5];
				HomeCamera.Target = HomeCamera.Targets[5];
				Disc.SetActive(value: true);
				WearPajamas();
			}
			if (GameGlobals.BlondeHair)
			{
				PonytailRenderer.material.mainTexture = BlondePony;
				LongHairRenderer.material.mainTexture = BlondeLong;
			}
		}
		Time.timeScale = 1f;
		IdleAnim = "f02_idleShort_00";
		WalkAnim = "f02_newWalk_00";
		RunAnim = "f02_newSprint_00";
		if (GameGlobals.Eighties)
		{
			StudentManager.Eighties = true;
			Hairstyle = 0;
			UpdateHair();
			IdleAnim = "f02_ryobaIdle_00";
			WalkAnim = "f02_ryobaWalk_00";
			RunAnim = "f02_ryobaRun_00";
			if (DateGlobals.Weekday != 0)
			{
				if (!Pajamas.gameObject.activeInHierarchy && !Vtuber)
				{
					MyRenderer.SetBlendShapeWeight(0, 50f);
					MyRenderer.SetBlendShapeWeight(5, 25f);
					MyRenderer.SetBlendShapeWeight(9, 0f);
					MyRenderer.SetBlendShapeWeight(12, 100f);
					if (!Pajamas.gameObject.activeInHierarchy)
					{
						ChangeSchoolwear();
					}
				}
				MyRenderer.materials[0].mainTexture = EightiesSocks;
			}
			BreastSize = 1.5f;
			BreastR.localScale = new Vector3(BreastSize, BreastSize, BreastSize);
			BreastL.localScale = new Vector3(BreastSize, BreastSize, BreastSize);
			if (HomeGlobals.Night)
			{
				RyobaLongHair.SetActive(value: true);
				RyobaHair.SetActive(value: false);
				UpdateFace = true;
			}
			else
			{
				RyobaLongHair.SetActive(value: false);
				RyobaHair.SetActive(value: true);
			}
		}
		else
		{
			PonytailRenderer.transform.parent.gameObject.SetActive(value: true);
			RyobaLongHair.SetActive(value: false);
			RyobaHair.SetActive(value: false);
			if (HomeGlobals.Night)
			{
				Hairstyle = 2;
				UpdateHair();
			}
			else
			{
				Hairstyle = 1;
				UpdateHair();
			}
		}
		if (DateGlobals.Week != 1 || DateGlobals.Weekday != DayOfWeek.Monday)
		{
			CannotAlphabet = true;
		}
		PlayerGlobals.BringingItem = 0;
		if (GameGlobals.CustomMode)
		{
			RyobaLongHair.SetActive(value: false);
			RyobaHair.SetActive(value: false);
			Hairstyle = 0;
			UpdateHair();
			for (int i = 0; i < YandereHairHost.Hairstyles.Length; i++)
			{
				if (YandereHairHost.Hairstyles[i] != null)
				{
					YandereHairHost.Hairstyles[i].SetActive(value: false);
					YandereHairHost.Hairstyles[i].transform.parent = Head;
				}
			}
			string hairstyle = JSON.Students[0].Hairstyle;
			YandereHairHost.Hairstyles[int.Parse(hairstyle)].SetActive(value: true);
			Yandere.Hairstyles = YandereHairHost.Hairstyles;
			if (!HomeGlobals.Night)
			{
				Debug.Log("It's Custom Mode. It's not nighttime. Calling Customize().");
				Customize();
			}
		}
		if (PlayerGlobals.CustomHair > 0)
		{
			CustomHair.gameObject.SetActive(value: true);
			CustomHair.Start();
			Hairstyle = 0;
			UpdateHair();
		}
	}

	private void Update()
	{
		if (!HomeCamera.gameObject.activeInHierarchy)
		{
			HomeCamera.gameObject.SetActive(value: true);
			CanMove = true;
		}
		if (UpdateFace && Pajamas.newRenderer != null)
		{
			Yandere.MyRenderer = Pajamas.newRenderer;
			if (GameGlobals.CustomMode)
			{
				Debug.Log("We are in Custom Mode, and we need to make the YandereScript aware of our pajamas...");
				Yandere.PajamaRenderer = Pajamas.newRenderer;
				Customize();
			}
			else if (!GameGlobals.Eighties)
			{
				if (Vtuber)
				{
					for (int i = 0; i < 13; i++)
					{
						Pajamas.newRenderer.SetBlendShapeWeight(i, 0f);
					}
					Pajamas.newRenderer.SetBlendShapeWeight(0, 100f);
					Pajamas.newRenderer.SetBlendShapeWeight(9, 100f);
					Pajamas.newRenderer.materials[1].mainTexture = FaceTexture;
					Debug.Log("Updating pajama mesh with Vtuber face.");
				}
				else
				{
					Pajamas.newRenderer.SetBlendShapeWeight(8, 50f);
				}
			}
			else
			{
				Debug.Log("Updating protagonist with Ryoba's face.");
				Pajamas.newRenderer.SetBlendShapeWeight(0, 50f);
				Pajamas.newRenderer.SetBlendShapeWeight(5, 25f);
				Pajamas.newRenderer.SetBlendShapeWeight(9, 0f);
				Pajamas.newRenderer.SetBlendShapeWeight(12, 100f);
			}
			UpdateFace = false;
		}
		if (!Disc.activeInHierarchy)
		{
			if (CanMove)
			{
				if (!OptionGlobals.ToggleRun)
				{
					Running = false;
					if (Input.GetButton(InputNames.Xbox_LB))
					{
						Running = true;
					}
				}
				else if (Input.GetButtonDown(InputNames.Xbox_LB))
				{
					Running = !Running;
				}
				MyController.Move(Physics.gravity * 0.01f);
				float num = Input.GetAxis("Vertical");
				float num2 = Input.GetAxis("Horizontal");
				Forward = Camera.main.transform.TransformDirection(Vector3.forward);
				if (!HomeCamera.RecentlyMoved)
				{
					PreviousForward = Forward;
					PreviousV = num;
					PreviousH = num2;
				}
				else if (Mathf.Abs(num - PreviousV) > 0.1f)
				{
					HomeCamera.RecentlyMoved = false;
				}
				else if (Mathf.Abs(num2 - PreviousH) > 0.1f)
				{
					HomeCamera.RecentlyMoved = false;
				}
				else
				{
					Forward = PreviousForward;
					num = PreviousV;
					num2 = PreviousH;
				}
				Forward.y = 0f;
				Forward = Forward.normalized;
				Vector3 vector = new Vector3(Forward.z, 0f, 0f - Forward.x);
				Vector3 vector2 = num2 * vector + num * Forward;
				if (vector2 != Vector3.zero)
				{
					Quaternion b = Quaternion.LookRotation(vector2);
					base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, Time.deltaTime * 10f);
				}
				if (num != 0f || num2 != 0f)
				{
					if (Running)
					{
						CharacterAnimation.CrossFade(RunAnim);
						MyController.Move(base.transform.forward * RunSpeed * Time.deltaTime);
					}
					else
					{
						CharacterAnimation.CrossFade(WalkAnim);
						MyController.Move(base.transform.forward * WalkSpeed * Time.deltaTime);
					}
				}
				else
				{
					CharacterAnimation.CrossFade(IdleAnim);
				}
			}
			else
			{
				CharacterAnimation.CrossFade(IdleAnim);
			}
		}
		else if (HomeDarkness.color.a == 0f)
		{
			if (Timer == 0f)
			{
				MyAudio.Play();
			}
			else if (Timer > MyAudio.clip.length + 1f)
			{
				YanvaniaGlobals.DraculaDefeated = false;
				HomeGlobals.MiyukiDefeated = false;
				Disc.SetActive(value: false);
				HomeVideoGames.Quit();
			}
			Timer += Time.deltaTime;
		}
		Rigidbody component = GetComponent<Rigidbody>();
		if (component != null)
		{
			component.velocity = Vector3.zero;
		}
		if (base.transform.position.y < -10f)
		{
			base.transform.position = new Vector3(base.transform.position.x, -10f, base.transform.position.z);
		}
	}

	private void LateUpdate()
	{
		if (!CannotAlphabet && Input.GetKeyDown(Letter[AlphabetID]))
		{
			AlphabetID++;
			if (AlphabetID == Letter.Length)
			{
				GameGlobals.AlphabetMode = true;
				StudentGlobals.MemorialStudents = 0;
				for (int i = 1; i < 101; i++)
				{
					StudentGlobals.SetStudentDead(i, value: false);
					StudentGlobals.SetStudentKidnapped(i, value: false);
					StudentGlobals.SetStudentArrested(i, value: false);
					StudentGlobals.SetStudentExpelled(i, value: false);
				}
				SceneManager.LoadScene("LoadingScene");
			}
		}
		if (CanMove && Input.GetKeyDown(KeyCode.Escape))
		{
			PauseScreen.QuitLabel.text = "Do you wish to return to the main menu?";
			PauseScreen.YesLabel.text = "Yes";
			PauseScreen.HomeButton.SetActive(value: false);
			PauseScreen.JumpToQuit();
			CanMove = false;
		}
	}

	private void UpdateHair()
	{
		if (Hairstyle == 0)
		{
			LongHairRenderer.gameObject.SetActive(value: false);
			PonytailRenderer.transform.parent.gameObject.SetActive(value: false);
		}
		else if (Hairstyle == 1)
		{
			LongHairRenderer.gameObject.SetActive(value: false);
			PonytailRenderer.enabled = true;
		}
		else if (Hairstyle == 2)
		{
			LongHairRenderer.gameObject.SetActive(value: true);
			PonytailRenderer.enabled = false;
		}
	}

	private void ChangeSchoolwear()
	{
		MyRenderer.sharedMesh = Uniforms[StudentGlobals.FemaleUniform];
		MyRenderer.materials[0].mainTexture = UniformTextures[StudentGlobals.FemaleUniform];
		MyRenderer.materials[1].mainTexture = UniformTextures[StudentGlobals.FemaleUniform];
		MyRenderer.materials[2].mainTexture = FaceTexture;
		StartCoroutine(ApplyCustomCostume());
	}

	private void WearPajamas()
	{
		Pajamas.gameObject.SetActive(value: true);
		MyRenderer.sharedMesh = null;
		MyRenderer.materials[0].mainTexture = PajamaTexture;
		MyRenderer.materials[1].mainTexture = PajamaTexture;
		MyRenderer.materials[2].mainTexture = FaceTexture;
		StartCoroutine(ApplyCustomFace());
		UpdateFace = true;
		if (!GameGlobals.Eighties && !GameGlobals.CustomMode)
		{
			OriginalHairs[3].SetActive(value: true);
		}
	}

	private void Nude()
	{
		MyRenderer.sharedMesh = NudeMesh;
		MyRenderer.materials[0].mainTexture = NudeTexture;
		MyRenderer.materials[1].mainTexture = NudeTexture;
		MyRenderer.materials[2].mainTexture = NudeTexture;
	}

	private IEnumerator ApplyCustomCostume()
	{
		if (StudentGlobals.FemaleUniform == 1)
		{
			WWW CustomUniform = new WWW("file:///" + Application.streamingAssetsPath + "/CustomUniform.png");
			yield return CustomUniform;
			if (CustomUniform.error == null)
			{
				MyRenderer.materials[0].mainTexture = CustomUniform.texture;
				MyRenderer.materials[1].mainTexture = CustomUniform.texture;
			}
		}
		else if (StudentGlobals.FemaleUniform == 2)
		{
			WWW CustomUniform = new WWW("file:///" + Application.streamingAssetsPath + "/CustomLong.png");
			yield return CustomUniform;
			if (CustomUniform.error == null)
			{
				MyRenderer.materials[0].mainTexture = CustomUniform.texture;
				MyRenderer.materials[1].mainTexture = CustomUniform.texture;
			}
		}
		else if (StudentGlobals.FemaleUniform == 3)
		{
			WWW CustomUniform = new WWW("file:///" + Application.streamingAssetsPath + "/CustomSweater.png");
			yield return CustomUniform;
			if (CustomUniform.error == null)
			{
				MyRenderer.materials[0].mainTexture = CustomUniform.texture;
				MyRenderer.materials[1].mainTexture = CustomUniform.texture;
			}
		}
		else if (StudentGlobals.FemaleUniform == 4 || StudentGlobals.FemaleUniform == 5)
		{
			WWW CustomUniform = new WWW("file:///" + Application.streamingAssetsPath + "/CustomBlazer.png");
			yield return CustomUniform;
			if (CustomUniform.error == null)
			{
				MyRenderer.materials[0].mainTexture = CustomUniform.texture;
				MyRenderer.materials[1].mainTexture = CustomUniform.texture;
			}
		}
		StartCoroutine(ApplyCustomFace());
	}

	private IEnumerator ApplyCustomFace()
	{
		WWW CustomFace = new WWW("file:///" + Application.streamingAssetsPath + "/CustomFace.png");
		yield return CustomFace;
		if (CustomFace.error == null)
		{
			MyRenderer.materials[2].mainTexture = CustomFace.texture;
			FaceTexture = CustomFace.texture;
		}
		WWW CustomHair = new WWW("file:///" + Application.streamingAssetsPath + "/CustomHair.png");
		yield return CustomHair;
		if (CustomHair.error == null)
		{
			PonytailRenderer.material.mainTexture = CustomHair.texture;
		}
	}

	private void VtuberCheck()
	{
		if (GameGlobals.VtuberID > 0)
		{
			for (int i = 1; i < OriginalHairs.Length; i++)
			{
				OriginalHairs[i].transform.localPosition = new Vector3(0f, 1f, 0f);
			}
			VtuberHairs[GameGlobals.VtuberID].SetActive(value: true);
			for (int i = 0; i < 13; i++)
			{
				MyRenderer.SetBlendShapeWeight(i, 0f);
			}
			MyRenderer.SetBlendShapeWeight(0, 100f);
			MyRenderer.SetBlendShapeWeight(9, 100f);
			FaceTexture = VtuberFaces[GameGlobals.VtuberID];
			Debug.Log("FaceTexture changed to Vtuber's face texture.");
			Eyes[1].material.mainTexture = VtuberFaces[GameGlobals.VtuberID];
			Eyes[2].material.mainTexture = VtuberFaces[GameGlobals.VtuberID];
			UpdateFace = true;
			Vtuber = true;
		}
		else
		{
			VtuberHairs[1].SetActive(value: false);
		}
	}

	private void Customize()
	{
		Debug.Log("HomeYandereScript is now going to fire Yandere.Customize()");
		Yandere.Customize();
		IdleAnim = FemaleIdles[JSON.Misc.AnimSet[0]];
		WalkAnim = FemaleWalks[JSON.Misc.AnimSet[0]];
	}
}
