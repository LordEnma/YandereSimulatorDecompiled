using System;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class BusStopScript : MonoBehaviour
{
	public PostProcessingProfile Profile;

	public PedestrianManagerScript PedestrianManager;

	public RiggedAccessoryAttacher BakerAttacher;

	public RiggedAccessoryAttacher Attacher;

	public SkinnedMeshRenderer BakerSenpaiRenderer;

	public SkinnedMeshRenderer NewSenpaiRenderer;

	public SkinnedMeshRenderer SenpaiRenderer;

	public CosmeticScript Cosmetic;

	public Texture CasualClothes;

	public MeshRenderer Renderer;

	public Animation SenpaiAnim;

	public AudioSource MeetingJukebox;

	public AudioSource DoomJukebox;

	public UILabel Subtitle;

	public UISprite SkipCircle;

	public UIPanel SkipPanel;

	public Animation BakerySenpai;

	public Animation SecondKizana;

	public Animation BakeryAmai;

	public Animation SecondAmai;

	public Animation FirstAmai;

	public Animation ThirdAmai;

	public Animation InfoChan;

	public Animation NewSenpaiAnim;

	public Animation NewAmaiAnim;

	public Transform SenpaiLeftHand;

	public Transform AmaiRightHand;

	public Transform AmaiLeftHand;

	public Transform CameraTarget;

	public Transform CupcakeBox;

	public Transform DonutLid;

	public Transform Cupcake;

	public Transform Target;

	public Transform Hips;

	public Transform[] SenpaiBrow;

	public Transform[] SenpaiLip;

	public GameObject UtilityPole;

	public GameObject Amai;

	public Mesh CasualMesh;

	public int RivalEliminationID;

	public int ShockPhase;

	public int SpeechID;

	public int Phase = 1;

	public int Week;

	public float IntroCameraSpeed;

	public float BakeryFocus;

	public float ExtraTimer;

	public float AnimTimer;

	public float TimeLimit;

	public float SkipTimer;

	public float Rotation;

	public float Alpha;

	public float Speed;

	public float Timer;

	public float DOF;

	public float RotationX;

	public float RotationY;

	public float RotationZ;

	public bool EndEarly;

	public bool InBakery;

	public bool TreeShot;

	public bool CloseUp;

	public bool NoAnim;

	public AudioClip[] OsanaEliminations;

	public AudioClip[] Speech;

	public AudioSource Audio;

	public AudioClip Sigh;

	public string[] EliminationDescriptions;

	public string[] Subtitles;

	public GameObject KizanaClothing;

	public GameObject KizanaChoker;

	public GameObject KizanaHair;

	public GameObject AmaiClothing;

	public GameObject AmaiCupcakes;

	public GameObject AmaiHair;

	public GameObject BakeryKizanaClothing;

	public GameObject BakeryKizanaChoker;

	public GameObject BakeryKizanaHair;

	public GameObject BakeryAmaiClothing;

	public GameObject BakeryAmaiHair;

	public GameObject Environment;

	public GameObject Theater;

	public GameObject Stores;

	public GameObject Road;

	public Transform[] Eyebrow;

	public bool Smile;

	public float Strength;

	public float LipValue = -0.08f;

	public int Frames;

	public Transform[] Breasts;

	private void Start()
	{
		Debug.Log("The game believes that we are currently in Week #" + DateGlobals.Week);
		Debug.Log("GameGlobals.SenpaiMeetsNewRival is: " + GameGlobals.SenpaiMeetsNewRival);
		Theater.SetActive(value: false);
		Renderer.material.color = new Color(0f, 0f, 0f, 1f);
		base.transform.position = new Vector3(0.375f, 0.5f, 2.5f);
		base.transform.eulerAngles = new Vector3(0f, 180f, 0f);
		SecondKizana.gameObject.SetActive(value: false);
		SecondAmai.gameObject.SetActive(value: false);
		ThirdAmai.gameObject.SetActive(value: false);
		DepthOfFieldModel.Settings settings = Profile.depthOfField.settings;
		settings.focusDistance = 1.2f;
		settings.aperture = 5.6f;
		Profile.depthOfField.settings = settings;
		Week = DateGlobals.Week;
		Subtitle.text = "";
		if (GameGlobals.RivalEliminationID == 0)
		{
			GameGlobals.RivalEliminationID = 1;
			GameGlobals.SpecificEliminationID = 1;
			GameGlobals.NonlethalElimination = false;
		}
		RivalEliminationID = GameGlobals.RivalEliminationID;
		if (GameGlobals.RivalEliminationID == 14)
		{
			RivalEliminationID = 1;
		}
		Time.timeScale = 1f;
		Debug.Log("GameGlobals.RivalEliminationID is: " + GameGlobals.RivalEliminationID + ", and this cutscene's RivalEliminationID is: " + RivalEliminationID);
		if (DateGlobals.Week > 1)
		{
			Subtitles[0] = "...(sigh)...";
			Speech[0] = Sigh;
			FirstAmai.Play("f02_walkElegant_00");
			KizanaClothing.SetActive(value: true);
			KizanaChoker.SetActive(value: true);
			KizanaHair.SetActive(value: true);
			AmaiClothing.SetActive(value: false);
			AmaiCupcakes.SetActive(value: false);
			AmaiHair.SetActive(value: false);
			UpdateDOF(2f);
			if (GameGlobals.SenpaiMeetsNewRival)
			{
				Environment.transform.position = new Vector3(0f, -2.975f, 1f);
				Environment.transform.eulerAngles = new Vector3(0f, 180f, 0f);
				BakeryAmai.GetComponent<Animation>()["f02_smile_01"].layer = 2;
				BakeryAmai.GetComponent<Animation>().Play("f02_smile_01");
				BakeryAmai.GetComponent<Animation>()["f02_smile_01"].weight = 1f;
				BakeryAmai.GetComponent<Animation>()["f02_smugEyes_00"].layer = 3;
				BakeryAmai.GetComponent<Animation>().Play("f02_smugEyes_00");
				BakeryAmai.GetComponent<Animation>()["f02_smugEyes_00"].weight = 1f;
				BakeryKizanaClothing.SetActive(value: true);
				BakeryKizanaChoker.SetActive(value: true);
				BakeryKizanaHair.SetActive(value: true);
				BakeryAmaiClothing.SetActive(value: false);
				BakeryAmaiHair.SetActive(value: false);
				Phase = 20;
			}
			else
			{
				PedestrianManager.gameObject.SetActive(value: true);
				Environment.transform.position = new Vector3(12.28f, 0f, -4.1135f);
				Amai.gameObject.SetActive(value: false);
				Theater.SetActive(value: true);
				Stores.SetActive(value: false);
				Road.SetActive(value: false);
				base.transform.position = new Vector3(12.28f, 5f, 20f);
				base.transform.eulerAngles = new Vector3(0f, 180f, 0f);
				Phase = 0;
			}
		}
		else
		{
			NewAmaiAnim["f02_amaiLipSync_01"].layer = 1;
			NewAmaiAnim["f02_amaiLipSync_02"].layer = 1;
			NewAmaiAnim["f02_amaiLipSync_03"].layer = 1;
			NewAmaiAnim["f02_amaiLipSync_04"].layer = 1;
			NewAmaiAnim["f02_amaiLipSync_05"].layer = 1;
			NewAmaiAnim["f02_amaiLipSync_06"].layer = 1;
			NewAmaiAnim["f02_amaiLipSync_07"].layer = 1;
			NewAmaiAnim["f02_amaiLipSync_08"].layer = 1;
			BakerAttacher.gameObject.SetActive(value: true);
			Attacher.gameObject.SetActive(value: true);
		}
	}

	private void Update()
	{
		SkipTimer += Time.deltaTime;
		if (SkipTimer > 5f)
		{
			SkipPanel.alpha -= Time.deltaTime;
		}
		if (EndEarly)
		{
			Alpha = Mathf.MoveTowards(Alpha, 1f, Time.deltaTime * 0.5f);
			SkipPanel.alpha -= Time.deltaTime;
			Renderer.material.color = new Color(0f, 0f, 0f, Alpha);
			Subtitle.text = "";
			if (Alpha == 1f)
			{
				Debug.Log("Calling ExitCutscene() because EndEarly was true.");
				ExitCutscene();
				return;
			}
		}
		else if (Input.GetButton(InputNames.Xbox_X))
		{
			SkipPanel.alpha = 1f;
			SkipTimer = 0f;
			SkipCircle.fillAmount -= Time.deltaTime;
			if (SkipCircle.fillAmount == 0f)
			{
				EndEarly = true;
			}
		}
		else
		{
			SkipCircle.fillAmount = 1f;
		}
		Audio.pitch = Time.timeScale;
		if (Phase > 1 && Phase < 4)
		{
			base.transform.Translate(Vector3.back * Time.deltaTime * 0.01f);
			Speed += Time.deltaTime * 0.1f;
			Rotation = Mathf.Lerp(Rotation, -150f, Time.deltaTime * Speed);
			base.transform.eulerAngles = new Vector3(0f, Rotation, 0f);
		}
		if (Phase > 7 && Phase < 11)
		{
			base.transform.Translate(Vector3.back * Time.deltaTime * 0.01f);
		}
		if (Phase == 0)
		{
			base.transform.position += new Vector3(0f, 0f, Speed * Time.deltaTime);
			Alpha = Mathf.MoveTowards(Alpha, 0f, Time.deltaTime * 0.2f);
			Renderer.material.color = new Color(0f, 0f, 0f, Alpha);
			MeetingJukebox.volume = (1f - Alpha) * 0.1f;
			Amai.gameObject.SetActive(value: false);
			SenpaiRendererCheck();
			UpdateDOF(2f);
			base.transform.LookAt(CameraTarget);
			Timer += Time.deltaTime;
			if (Timer > 6f)
			{
				IntroCameraSpeed += Time.deltaTime;
				CameraTarget.position = Vector3.Lerp(CameraTarget.position, SenpaiAnim.transform.position, IntroCameraSpeed * 0.001f);
				if (IntroCameraSpeed > 10f)
				{
					base.transform.position = new Vector3(0.375f, 0.5f, 2.5f);
					base.transform.eulerAngles = new Vector3(0f, 180f, 0f);
					Amai.gameObject.SetActive(value: true);
					FirstAmai.Play("f02_walkElegant_00");
					PedestrianManager.MovePedestrians();
					Phase++;
				}
			}
		}
		else if (Phase == 1)
		{
			Alpha = Mathf.MoveTowards(Alpha, 0f, Time.deltaTime * 0.2f);
			Renderer.material.color = new Color(0f, 0f, 0f, Alpha);
			MeetingJukebox.volume = (1f - Alpha) * 0.1f;
			if (Alpha == 0f)
			{
				if (SpeechID == 0)
				{
					Subtitle.text = Subtitles[0];
					Audio.clip = Speech[0];
					Audio.Play();
					SpeechID++;
				}
				else
				{
					Timer += Time.deltaTime;
					if (Timer > 6f)
					{
						Subtitle.text = "";
					}
				}
			}
			SenpaiRendererCheck();
			base.transform.position += new Vector3(0f, 0f, Speed * Time.deltaTime);
			Amai.transform.position -= new Vector3(1f * Time.deltaTime, 0f, 0f);
			if (Amai.transform.position.x < -2f)
			{
				if (Week == 1)
				{
					SecondAmai.gameObject.SetActive(value: true);
					if (SecondAmai["f02_motherRecipe_00"].speed == 1f)
					{
						SecondAmai["f02_motherRecipe_00"].speed = 0.66666f;
						SecondAmai["f02_motherRecipe_00"].time = 16f;
						SecondAmai["f02_carry_00"].layer = 1;
						SecondAmai.Play("f02_carry_00");
					}
				}
				else
				{
					SecondKizana.gameObject.SetActive(value: true);
				}
			}
			if (Week == 1)
			{
				if (Amai.transform.position.x < -10f)
				{
					UpdateDOF(1f);
					base.transform.position = new Vector3(0.55f, 1f, 1.55f);
					base.transform.eulerAngles = new Vector3(0f, -135f, 0f);
					SenpaiAnim.transform.parent.gameObject.SetActive(value: false);
					SecondAmai.gameObject.SetActive(value: false);
					NewSenpaiAnim.gameObject.SetActive(value: true);
					NewAmaiAnim.gameObject.SetActive(value: true);
					Amai.gameObject.SetActive(value: false);
					Rotation = -125f;
					SpeechID = 0;
					Timer = 0f;
					Phase++;
				}
			}
			else
			{
				if (Amai.transform.position.x < -7.5f)
				{
					Alpha = Mathf.MoveTowards(Alpha, 1f, Time.deltaTime * 0.5f);
					SkipPanel.alpha -= Time.deltaTime;
					Renderer.material.color = new Color(0f, 0f, 0f, Alpha);
					if (Alpha > 0.999f)
					{
						Debug.Log("Week is: " + Week);
						Debug.Log("DateGlobals.Week is: " + DateGlobals.Week);
						Debug.Log("Moving to the VisualNovelScene from here.");
						Debug.Log("GameGlobals.SenpaiMeetsNewRival is getting set to ''true'' here.");
						GameGlobals.SenpaiMeetsNewRival = true;
						SceneManager.LoadScene("VisualNovelScene");
					}
				}
				if (Amai.transform.position.x < -5f)
				{
					SecondKizana["f02_girlWalk_LookLeft_00"].speed = Mathf.MoveTowards(SecondKizana["f02_girlWalk_LookLeft_00"].speed, 0f, Time.deltaTime * 0.11f);
				}
			}
		}
		else if (Phase == 2)
		{
			Timer += Time.deltaTime;
			if (Timer > 0f && SpeechID == 0)
			{
				Debug.Log("Now playing Amai's lip sync animation, supposedly.");
				NewAmaiAnim.Play("f02_amaiLipSync_01");
				Subtitle.text = Subtitles[1];
				Audio.clip = Speech[1];
				Audio.Play();
				SpeechID++;
			}
			if (Timer > 5f)
			{
				CupcakeBox.transform.localPosition = Vector3.MoveTowards(CupcakeBox.transform.localPosition, new Vector3(-0.02f, 0.05f, 0.25f), Time.deltaTime * 0.1f);
			}
			else if (Timer > 4f)
			{
				if (CupcakeBox.parent != Hips)
				{
					CupcakeBox.parent = Hips;
					RotationX = CupcakeBox.transform.localEulerAngles.x;
					RotationY = CupcakeBox.transform.localEulerAngles.y;
					RotationZ = CupcakeBox.transform.localEulerAngles.z;
				}
				CupcakeBox.transform.localPosition = Vector3.MoveTowards(CupcakeBox.transform.localPosition, new Vector3(-0.05f, 0.05f, 0.25f), Time.deltaTime * 0.25f);
				RotationX = Mathf.MoveTowards(RotationX, 375f, Time.deltaTime * 90f);
				RotationY = Mathf.MoveTowards(RotationY, 360f, Time.deltaTime * 90f);
				RotationZ = Mathf.MoveTowards(RotationZ, 0f, Time.deltaTime * 90f);
				CupcakeBox.transform.localEulerAngles = new Vector3(RotationX, RotationY, RotationZ);
			}
			if (Timer > 6f)
			{
				Subtitle.text = "";
				SpeechID = 0;
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 3)
		{
			Timer += Time.deltaTime;
			if (Timer > 0.5f)
			{
				Subtitle.text = Subtitles[2];
			}
			if (Timer > 7.5f)
			{
				UpdateDOF(0.66666f);
				base.transform.position = new Vector3(0f, 1f, 1.5f);
				base.transform.eulerAngles = new Vector3(0f, 150f, 0f);
				Subtitle.text = "";
				SpeechID = 0;
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 4)
		{
			Timer += Time.deltaTime;
			if (Timer > 0.5f && SpeechID == 0)
			{
				Subtitle.text = Subtitles[3];
				Audio.clip = Speech[2];
				Audio.Play();
				SpeechID++;
			}
			if (Timer > 6f)
			{
				UpdateDOF(0.66666f);
				base.transform.position = new Vector3(0f, 1f, 1.5f);
				base.transform.eulerAngles = new Vector3(0f, -150f, 0f);
				Subtitle.text = "";
				SpeechID = 0;
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 5)
		{
			Timer += Time.deltaTime;
			if (Timer > 0f && SpeechID == 0)
			{
				NewAmaiAnim.Play("f02_amaiLipSync_02");
				Subtitle.text = Subtitles[4];
				Audio.clip = Speech[3];
				Audio.Play();
				SpeechID++;
			}
			if (Timer > 2f && SpeechID == 1)
			{
				Subtitle.text = Subtitles[5];
				SpeechID++;
			}
			if (Timer > 6.75f && SpeechID == 2)
			{
				Subtitle.text = Subtitles[6];
				SpeechID++;
			}
			if (Timer > 16.75f && SpeechID == 3)
			{
				Subtitle.text = Subtitles[7];
				SpeechID++;
			}
			if (Timer > 20f)
			{
				UpdateDOF(0.75f);
				base.transform.position = new Vector3(0f, 1f, 0f);
				base.transform.eulerAngles = new Vector3(0f, 0f, 0f);
				UtilityPole.SetActive(value: false);
				NewSenpaiAnim["SenpaiMeet_1"].time = NewSenpaiAnim["SenpaiMeet_1"].length - 4f;
				Subtitle.text = "";
				SpeechID = 0;
				Speed = 0f;
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 6)
		{
			Timer += Time.deltaTime;
			if (Timer > 5f && SpeechID == 0)
			{
				Subtitle.text = EliminationDescriptions[RivalEliminationID];
				Audio.clip = OsanaEliminations[RivalEliminationID];
				Audio.Play();
				TimeLimit = OsanaEliminations[RivalEliminationID].length;
				SpeechID++;
			}
			if (NewSenpaiAnim["SenpaiMeet_1"].time >= NewSenpaiAnim["SenpaiMeet_1"].length)
			{
				NewSenpaiAnim.CrossFade("SenpaiMeet_2");
				NewAmaiAnim.CrossFade("AmaiMeet_2");
			}
			if (ShockPhase == 0)
			{
				if (Timer > 9.5f)
				{
					NewAmaiAnim.CrossFade("AmaiShock_1");
					ShockPhase++;
				}
			}
			else if (ShockPhase == 1)
			{
				if (NewAmaiAnim["AmaiShock_1"].time >= NewAmaiAnim["AmaiShock_1"].length)
				{
					NewAmaiAnim.CrossFade("AmaiShock_2");
					ShockPhase = 2;
				}
			}
			else if (ShockPhase == 2 && Timer > TimeLimit + 4f)
			{
				NewAmaiAnim["AmaiShock_1"].time = 0f;
				NewAmaiAnim["AmaiShock_1"].speed = 0f;
				NewAmaiAnim.CrossFade("AmaiShock_1", 2f);
				ShockPhase = 3;
			}
			base.transform.Translate(Vector3.back * Time.deltaTime * 0.01f);
			if (Timer > TimeLimit + 6f)
			{
				UpdateDOF(0.66666f);
				base.transform.position = new Vector3(0f, 1f, 1.5f);
				base.transform.eulerAngles = new Vector3(0f, -150f, 0f);
				CupcakeBox.localPosition = new Vector3(-0.025f, 0.05f, 0.25f);
				CupcakeBox.localEulerAngles = new Vector3(15f, 0f, 0f);
				CupcakeBox.localScale = new Vector3(0.133333f, 0.15f, 0.15f);
				NewSenpaiAnim.CrossFade("SenpaiMeet_3");
				NewAmaiAnim.CrossFade("AmaiMeet_3");
				UtilityPole.SetActive(value: true);
				Subtitle.text = "";
				SpeechID = 0;
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 7)
		{
			Timer += Time.deltaTime;
			if (Timer > 1.5f && SpeechID == 0)
			{
				NewAmaiAnim.Play("f02_amaiLipSync_03");
				Subtitle.text = Subtitles[8];
				Audio.clip = Speech[4];
				Audio.Play();
				SpeechID++;
			}
			if (Timer > 13f)
			{
				UpdateDOF(1f);
				base.transform.position = new Vector3(0f, 1f, 2f);
				base.transform.eulerAngles = new Vector3(0f, 180f, 0f);
				NewSenpaiAnim.transform.parent.transform.position = new Vector3(-0.1f, 0f, 0f);
				NewSenpaiAnim["SenpaiMeet_3"].time += 0.25f;
				NewAmaiAnim["AmaiMeet_3"].time += 0.25f;
				Rotation = -90f;
				SpeechID = 0;
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 8)
		{
			Timer += Time.deltaTime;
			if (Timer > 0.5f && SpeechID == 0)
			{
				NewAmaiAnim.Play("f02_amaiLipSync_04");
				Subtitle.text = Subtitles[9];
				Audio.clip = Speech[5];
				Audio.Play();
				SpeechID++;
			}
			if (NewAmaiAnim["AmaiMeet_3"].time > 15.75f)
			{
				Rotation = Mathf.MoveTowards(Rotation, -20.5f, Time.deltaTime * 100f);
				DonutLid.localEulerAngles = new Vector3(Rotation, 180f, 180f);
			}
			if (Timer > 8.5f)
			{
				Subtitle.text = "";
				SpeechID = 0;
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 9)
		{
			base.transform.Translate(0f, 0f, Time.deltaTime * -0.01f);
			Timer += Time.deltaTime;
			if (Timer > 0.5f && SpeechID == 0)
			{
				Subtitle.text = Subtitles[10];
				Audio.clip = Speech[6];
				Audio.Play();
				SpeechID++;
			}
			if (Timer > 5f && SpeechID == 1)
			{
				NewAmaiAnim.Play("f02_amaiLipSync_05");
				Subtitle.text = Subtitles[11];
				Audio.clip = Speech[7];
				Audio.Play();
				SpeechID++;
			}
			if (NewSenpaiAnim["SenpaiMeet_3"].time > 28f)
			{
				if (Cupcake.parent != SenpaiLeftHand)
				{
					Cupcake.parent = SenpaiLeftHand;
				}
				Cupcake.localPosition = Vector3.MoveTowards(Cupcake.localPosition, new Vector3(-0.02f, -0.02f, 0f), Time.deltaTime);
				Cupcake.transform.localEulerAngles = new Vector3(-15f, -15f, 0f);
			}
			if (Timer > 8.5f)
			{
				Subtitle.text = "";
				SpeechID = 0;
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 10)
		{
			Timer += Time.deltaTime;
			if (Timer > 1f && SpeechID == 0)
			{
				Subtitle.text = Subtitles[12];
				Audio.clip = Speech[8];
				Audio.Play();
				SpeechID++;
			}
			if (Timer > 4.5f && SpeechID == 1)
			{
				NewAmaiAnim.Play("f02_amaiLipSync_06");
				Subtitle.text = Subtitles[13];
				Audio.clip = Speech[9];
				Audio.Play();
				SpeechID++;
			}
			if (NewAmaiAnim["AmaiMeet_3"].time > 35.75f)
			{
				Rotation = Mathf.MoveTowards(Rotation, -90f, Time.deltaTime * 100f);
				DonutLid.localEulerAngles = new Vector3(Rotation, 180f, 180f);
			}
			if (Timer > 9.5f)
			{
				UpdateDOF(0.66666f);
				base.transform.position = new Vector3(0f, 1f, 1.5f);
				base.transform.eulerAngles = new Vector3(0f, -150f, 0f);
				CupcakeBox.localPosition = new Vector3(-0.025f, 0.0375f, 0.25f);
				CupcakeBox.localEulerAngles = new Vector3(15f, 0f, 0f);
				NewSenpaiAnim.transform.parent.transform.position = new Vector3(0.1f, 0f, 0f);
				Subtitle.text = Subtitles[14];
				SpeechID = 0;
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 11)
		{
			Timer += Time.deltaTime;
			if (Timer > 9f)
			{
				UpdateDOF(0.66666f);
				base.transform.position = new Vector3(0f, 1f, 1.5f);
				base.transform.eulerAngles = new Vector3(0f, 150f, 0f);
				Subtitle.text = "";
				SpeechID = 0;
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 12)
		{
			Timer += Time.deltaTime;
			if (Timer > 0.5f && SpeechID == 0)
			{
				Subtitle.text = Subtitles[15];
				Audio.clip = Speech[10];
				Audio.Play();
				SpeechID++;
			}
			if (Timer > 7f)
			{
				UpdateDOF(0.66666f);
				base.transform.position = new Vector3(0f, 1f, 1.5f);
				base.transform.eulerAngles = new Vector3(0f, -150f, 0f);
				Subtitle.text = "";
				SpeechID = 0;
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 13)
		{
			Timer += Time.deltaTime;
			if (Timer > 0.5f && SpeechID == 0)
			{
				NewAmaiAnim.Play("f02_amaiLipSync_07");
				Subtitle.text = Subtitles[16];
				Audio.clip = Speech[11];
				Audio.Play();
				SpeechID++;
			}
			if (Timer > 6.5f)
			{
				UpdateDOF(0.66666f);
				base.transform.position = new Vector3(0f, 1f, 1.5f);
				base.transform.eulerAngles = new Vector3(0f, 150f, 0f);
				Subtitle.text = "";
				SpeechID = 0;
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 14)
		{
			Timer += Time.deltaTime;
			if (Timer > 0.5f && SpeechID == 0)
			{
				Subtitle.text = Subtitles[17];
				Audio.clip = Speech[12];
				Audio.Play();
				SpeechID++;
			}
			if (Timer > 11.5f)
			{
				UpdateDOF(0.66666f);
				base.transform.position = new Vector3(0f, 1f, 1.5f);
				base.transform.eulerAngles = new Vector3(0f, -150f, 0f);
				CupcakeBox.localPosition = new Vector3(-0.025f, 0.0375f, 0.25f);
				CupcakeBox.localEulerAngles = new Vector3(15f, 0f, 0f);
				Subtitle.text = "";
				SpeechID = 0;
				Alpha = 0f;
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 15)
		{
			if (SpeechID == 0)
			{
				NewAmaiAnim.Play("f02_amaiLipSync_08");
				Subtitle.text = Subtitles[18];
				Audio.clip = Speech[13];
				Audio.Play();
				SpeechID++;
			}
			if (NewAmaiAnim["AmaiMeet_3"].time > NewAmaiAnim["AmaiMeet_3"].length - 2f)
			{
				Alpha = Mathf.MoveTowards(Alpha, 1f, Time.deltaTime * 0.5f);
				Renderer.material.color = new Color(0f, 0f, 0f, Alpha);
				MeetingJukebox.volume = (1f - Alpha) * 0.2f;
				Subtitle.text = "";
				if (Alpha == 1f)
				{
					Timer += Time.deltaTime;
					if (Timer > 1f)
					{
						Phase = 20;
					}
				}
			}
		}
		else if (Phase == 20)
		{
			SenpaiRendererCheck();
			base.transform.position = new Vector3(-0.75f, 1.1f, 7.75f);
			base.transform.eulerAngles = new Vector3(0f, 30f, 0f);
			Renderer.material.color = new Color(0f, 0f, 0f, 1f);
			Alpha = 1f;
			InBakery = true;
			BakerySenpai.transform.position = new Vector3(-0.5f, 0f, 9f);
			BakeryAmai.transform.position = new Vector3(0.5f, 0f, 9f);
			InfoChan.transform.position = new Vector3(-1.925f, 0f, 6.4f);
			BakerySenpai.Play();
			BakeryAmai.Play();
			DoomJukebox.Play();
			UpdateDOF(1.2f);
			Speed = 0f;
			Timer = 0f;
			Phase++;
		}
		else if (Phase == 21)
		{
			if (!EndEarly)
			{
				Alpha = Mathf.MoveTowards(Alpha, 0f, Time.deltaTime * 0.5f);
			}
			else
			{
				Alpha = Mathf.MoveTowards(Alpha, 1f, Time.deltaTime);
				if (Alpha > 0.999f)
				{
					Debug.Log("Calling ExitCutscene() because EndEarly was true while we're inside of Amai's bakery.");
					ExitCutscene();
					return;
				}
			}
			Renderer.material.color = new Color(0f, 0f, 0f, Alpha);
			Timer += Time.deltaTime;
			if (Timer > 13.5f)
			{
				LipValue = SenpaiLip[0].localPosition.y;
				Smile = true;
			}
			if (Timer > 15f)
			{
				Speed += Time.deltaTime * 0.1f;
			}
			BakeryFocus = Mathf.Lerp(BakeryFocus, 1.5f, Speed * Time.deltaTime);
			UpdateDOF(1.2f);
			base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(-1.939f, 1.4f, 5.69f), Speed * Time.deltaTime);
			if (Speed > 1f)
			{
				InfoChan.CrossFade("f02_infoSnapPhoto_00", 1f);
			}
			if (Timer > 30.5f)
			{
				Alpha = 1f;
			}
			if (BakerySenpai["bakeryTalk_00"].time >= BakerySenpai["bakeryTalk_00"].length - 1f)
			{
				if (Alpha < 1f)
				{
					ExtraTimer += Time.deltaTime;
				}
				BakerySenpai.CrossFade("carefreeTalk_02", 1f);
				BakeryAmai.CrossFade("f02_carefreeTalk_02", 1f);
				BakerySenpai["f02_smile_00"].layer = 1;
				BakerySenpai.Play("f02_smile_00");
			}
			if (Timer > 35f)
			{
				Debug.Log("Calling ExitCutscene() because Info-chan just took a picture of Taro talking to Amai.");
				ExitCutscene();
				return;
			}
		}
		MeetingJukebox.pitch = Time.timeScale;
		DoomJukebox.pitch = Time.timeScale;
	}

	private void LateUpdate()
	{
		SenpaiBrow[0].localPosition = new Vector3(-0.025f, 0.025f, 0f);
		SenpaiBrow[0].localEulerAngles = new Vector3(0f, 0f, 22.5f);
		SenpaiBrow[1].localPosition = new Vector3(0.025f, 0.025f, 0f);
		SenpaiBrow[1].localEulerAngles = new Vector3(0f, 0f, -22.5f);
		if (Smile)
		{
			Strength += Time.deltaTime;
			LipValue = Mathf.Lerp(LipValue, -0.06f, Time.deltaTime * Strength);
			SenpaiLip[0].localPosition = new Vector3(SenpaiLip[0].localPosition.x, LipValue, SenpaiLip[0].localPosition.z);
			SenpaiLip[1].localPosition = new Vector3(SenpaiLip[1].localPosition.x, LipValue, SenpaiLip[1].localPosition.z);
		}
		if (Frames == 1)
		{
			ResetAllBreasts();
		}
		Eyebrow[0].localScale = new Vector3(0f, 1f, 1f);
		Eyebrow[1].localScale = new Vector3(0f, 1f, 1f);
		Frames++;
	}

	private void SenpaiRendererCheck()
	{
		if (SenpaiRenderer.sharedMesh != CasualMesh)
		{
			SenpaiRenderer.sharedMesh = CasualMesh;
			SenpaiRenderer.materials[0].mainTexture = CasualClothes;
			SenpaiRenderer.materials[1].mainTexture = Cosmetic.FaceTextures[Cosmetic.SkinColor];
			SenpaiRenderer.materials[2].mainTexture = Cosmetic.SkinTextures[Cosmetic.SkinColor];
		}
		if (NewSenpaiRenderer.sharedMesh != CasualMesh)
		{
			NewSenpaiRenderer.sharedMesh = CasualMesh;
			NewSenpaiRenderer.materials[0].mainTexture = CasualClothes;
			NewSenpaiRenderer.materials[1].mainTexture = Cosmetic.FaceTextures[Cosmetic.SkinColor];
			NewSenpaiRenderer.materials[2].mainTexture = Cosmetic.SkinTextures[Cosmetic.SkinColor];
		}
		if (BakerSenpaiRenderer.sharedMesh != CasualMesh)
		{
			BakerSenpaiRenderer.sharedMesh = CasualMesh;
			BakerSenpaiRenderer.materials[0].mainTexture = CasualClothes;
			BakerSenpaiRenderer.materials[1].mainTexture = Cosmetic.FaceTextures[Cosmetic.SkinColor];
			BakerSenpaiRenderer.materials[2].mainTexture = Cosmetic.SkinTextures[Cosmetic.SkinColor];
		}
	}

	private void UpdateDOF(float Focus)
	{
		DepthOfFieldModel.Settings settings = Profile.depthOfField.settings;
		if (CloseUp)
		{
			settings.focusDistance = Focus;
		}
		else if (TreeShot)
		{
			settings.focusDistance = Focus;
		}
		else if (InBakery)
		{
			settings.focusDistance = Focus;
		}
		else
		{
			settings.focusDistance = Focus;
		}
		settings.focusDistance = Focus;
		Profile.depthOfField.settings = settings;
		UpdateAperture(5.6f);
	}

	public void UpdateAperture(float Aperture)
	{
		DepthOfFieldModel.Settings settings = Profile.depthOfField.settings;
		float num = (float)Screen.width / 1280f;
		settings.aperture = Aperture * num;
		settings.focalLength = 50f;
		Profile.depthOfField.settings = settings;
	}

	private void ExitCutscene()
	{
		Debug.Log("ExitCutscene has been called. GameGlobals.SenpaiMeetsNewRival is " + GameGlobals.SenpaiMeetsNewRival);
		Debug.Log("Week is " + Week + " and DateGlobals.Week is " + DateGlobals.Week);
		if (GameGlobals.SenpaiMeetsNewRival || DateGlobals.Week == 1)
		{
			DateGlobals.Week++;
			DateGlobals.PassDays = 0;
			DateGlobals.Weekday = DayOfWeek.Sunday;
			GameGlobals.SenpaiMeetsNewRival = false;
			SceneManager.LoadScene("CalendarScene");
		}
		else
		{
			Debug.Log("Moving to the VisualNovelScene from here, specifically.");
			GameGlobals.SenpaiMeetsNewRival = true;
			SceneManager.LoadScene("VisualNovelScene");
		}
	}

	private void ResetAllBreasts()
	{
		GameObject[] array = UnityEngine.Object.FindObjectsOfType<GameObject>();
		foreach (GameObject gameObject in array)
		{
			if (gameObject.name.Contains("Breast"))
			{
				gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			}
		}
	}
}
