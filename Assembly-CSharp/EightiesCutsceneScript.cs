using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EightiesCutsceneScript : MonoBehaviour
{
	public GameObject SkipTutorialButton;

	public GameObject SkipTutorialWindow;

	public GameObject Panel;

	public TypewriterEffect Typewriter;

	public UITexture Silhouette;

	public UITexture Render;

	public AudioSource MyAudio;

	public AudioSource BGM;

	public UISprite Darkness;

	public UILabel Label;

	public Texture[] RivalSilhouettes;

	public string[] Lines;

	public string[] CutsceneLines1;

	public string[] CutsceneLines2;

	public string[] CutsceneLines3;

	public string[] CutsceneLines4;

	public string[] CutsceneLines5;

	public string[] CutsceneLines6;

	public string[] CutsceneLines7;

	public string[] CutsceneLines8;

	public string[] CutsceneLines9;

	public string[] CutsceneLines10;

	public string[] CutsceneLines11;

	public string[] FinalCutsceneLines;

	public AudioClip[] Clips;

	public AudioClip[] CutsceneClips1;

	public AudioClip[] CutsceneClips2;

	public AudioClip[] CutsceneClips3;

	public AudioClip[] CutsceneClips4;

	public AudioClip[] CutsceneClips5;

	public AudioClip[] CutsceneClips6;

	public AudioClip[] CutsceneClips7;

	public AudioClip[] CutsceneClips8;

	public AudioClip[] CutsceneClips9;

	public AudioClip[] CutsceneClips10;

	public AudioClip[] CutsceneClips11;

	public AudioClip[] FinalCutsceneClips;

	public Texture[] Renders;

	public Texture[] TutorialRenders;

	public Texture[] Rival1Renders;

	public Texture[] Rival2Renders;

	public Texture[] Rival3Renders;

	public Texture[] Rival4Renders;

	public Texture[] Rival5Renders;

	public Texture[] Rival6Renders;

	public Texture[] Rival7Renders;

	public Texture[] Rival8Renders;

	public Texture[] Rival9Renders;

	public Texture[] Rival10Renders;

	public Texture[] ConfessionRenders;

	public Texture[] EndingRenders;

	public bool[] Nexts;

	public bool[] TutorialNexts;

	public bool[] Rival1Nexts;

	public bool[] Rival2Nexts;

	public bool[] Rival3Nexts;

	public bool[] Rival4Nexts;

	public bool[] Rival5Nexts;

	public bool[] Rival6Nexts;

	public bool[] Rival7Nexts;

	public bool[] Rival8Nexts;

	public bool[] Rival9Nexts;

	public bool[] Rival10Nexts;

	public bool[] ConfessionNexts;

	public bool[] EndingNexts;

	public float Speed;

	public int CurrentRender;

	public int RivalLine;

	public int DarkLine;

	public int Phase;

	public int ID;

	public string[] EliminationNames;

	public string[] EliminationDetails;

	public bool SkipTutorial;

	private void Start()
	{
		GameGlobals.Eighties = true;
		if (GameGlobals.EightiesCutsceneID < 2)
		{
			Darkness.color = new Color(1f, 1f, 1f, 1f);
		}
		else
		{
			Darkness.color = new Color(0.1f, 0.1f, 0.1f, 1f);
		}
		Typewriter.gameObject.SetActive(value: false);
		if (GameGlobals.EightiesCutsceneID == 0)
		{
			DarkLine = 13;
			Renders = TutorialRenders;
			Nexts = TutorialNexts;
		}
		if (GameGlobals.EightiesCutsceneID == 1)
		{
			Lines = CutsceneLines1;
			Clips = CutsceneClips1;
			DarkLine = 10;
			RivalLine = 10;
			Silhouette.mainTexture = RivalSilhouettes[1];
			Renders = Rival1Renders;
			Nexts = Rival1Nexts;
		}
		if (GameGlobals.EightiesCutsceneID == 2)
		{
			Lines = CutsceneLines2;
			Clips = CutsceneClips2;
			DarkLine = 13;
			RivalLine = 3;
			Silhouette.mainTexture = RivalSilhouettes[2];
			Renders = Rival2Renders;
			Nexts = Rival2Nexts;
		}
		if (GameGlobals.EightiesCutsceneID == 3)
		{
			Lines = CutsceneLines3;
			Clips = CutsceneClips3;
			DarkLine = 13;
			RivalLine = 3;
			Silhouette.mainTexture = RivalSilhouettes[3];
			Renders = Rival3Renders;
			Nexts = Rival3Nexts;
		}
		if (GameGlobals.EightiesCutsceneID == 4)
		{
			Lines = CutsceneLines4;
			Clips = CutsceneClips4;
			DarkLine = 12;
			RivalLine = 3;
			Silhouette.mainTexture = RivalSilhouettes[4];
			Renders = Rival4Renders;
			Nexts = Rival4Nexts;
		}
		if (GameGlobals.EightiesCutsceneID == 5)
		{
			Lines = CutsceneLines5;
			Clips = CutsceneClips5;
			DarkLine = 11;
			RivalLine = 2;
			Silhouette.mainTexture = RivalSilhouettes[5];
			Renders = Rival5Renders;
			Nexts = Rival5Nexts;
		}
		if (GameGlobals.EightiesCutsceneID == 6)
		{
			Lines = CutsceneLines6;
			Clips = CutsceneClips6;
			DarkLine = 12;
			RivalLine = 2;
			Silhouette.mainTexture = RivalSilhouettes[6];
			Renders = Rival6Renders;
			Nexts = Rival6Nexts;
		}
		if (GameGlobals.EightiesCutsceneID == 7)
		{
			Lines = CutsceneLines7;
			Clips = CutsceneClips7;
			DarkLine = 9;
			RivalLine = 3;
			Silhouette.mainTexture = RivalSilhouettes[7];
			Renders = Rival7Renders;
			Nexts = Rival7Nexts;
		}
		if (GameGlobals.EightiesCutsceneID == 8)
		{
			Lines = CutsceneLines8;
			Clips = CutsceneClips8;
			DarkLine = 14;
			RivalLine = 11;
			Silhouette.mainTexture = RivalSilhouettes[8];
			Renders = Rival8Renders;
			Nexts = Rival8Nexts;
		}
		if (GameGlobals.EightiesCutsceneID == 9)
		{
			Lines = CutsceneLines9;
			Clips = CutsceneClips9;
			DarkLine = 12;
			RivalLine = 8;
			Silhouette.mainTexture = RivalSilhouettes[9];
			Renders = Rival9Renders;
			Nexts = Rival9Nexts;
		}
		if (GameGlobals.EightiesCutsceneID == 10)
		{
			Lines = CutsceneLines10;
			Clips = CutsceneClips10;
			DarkLine = 1;
			RivalLine = 0;
			Silhouette.mainTexture = RivalSilhouettes[10];
			Renders = Rival10Renders;
			Nexts = Rival10Nexts;
		}
		if (GameGlobals.EightiesCutsceneID == 11)
		{
			Lines = CutsceneLines11;
			Clips = CutsceneClips11;
			DarkLine = 99;
			RivalLine = 99;
			Silhouette.mainTexture = RivalSilhouettes[10];
			Renders = ConfessionRenders;
			Nexts = ConfessionNexts;
		}
		if (GameGlobals.EightiesCutsceneID == 12)
		{
			Lines = FinalCutsceneLines;
			Clips = FinalCutsceneClips;
			DarkLine = 99;
			RivalLine = 99;
			Silhouette.mainTexture = RivalSilhouettes[10];
			Renders = EndingRenders;
			Nexts = EndingNexts;
		}
		Silhouette.alpha = 0f;
		Render.mainTexture = Renders[0];
		if (GameGlobals.EightiesCutsceneID > 0)
		{
			SkipTutorialButton.SetActive(value: false);
		}
		Time.timeScale = 1f;
	}

	private void Update()
	{
		if (Phase < 3)
		{
			BGM.volume = Mathf.MoveTowards(BGM.volume, 0.1f, Time.deltaTime * 0.1f);
		}
		if (DarkLine == 0)
		{
			BGM.pitch = 0.1f;
		}
		else if (ID >= DarkLine)
		{
			BGM.pitch = Mathf.MoveTowards(BGM.pitch, 0.9f, Time.deltaTime * 0.1f);
		}
		if (RivalLine > 0 && ID >= RivalLine)
		{
			Speed += Time.deltaTime;
			Silhouette.alpha = Mathf.MoveTowards(Silhouette.alpha, 1f, Time.deltaTime);
		}
		if (Render.alpha < 1f)
		{
			Render.alpha = Mathf.MoveTowards(Render.alpha, 1f, Time.deltaTime);
		}
		if (Phase == 0)
		{
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 0f, Time.deltaTime);
			if (Darkness.alpha == 0f)
			{
				Typewriter.gameObject.SetActive(value: true);
				Typewriter.ResetToBeginning();
				Label.text = "";
				Typewriter.mFullText = Lines[ID];
				MyAudio.clip = Clips[ID];
				MyAudio.Play();
				Phase++;
			}
		}
		else if (Phase == 1)
		{
			if (!SkipTutorialWindow.activeInHierarchy)
			{
				if (Input.GetButtonDown(InputNames.Xbox_A))
				{
					if (Typewriter.mCurrentOffset < Typewriter.mFullText.Length)
					{
						Typewriter.Finish();
						return;
					}
					ID++;
					if (ID < Lines.Length)
					{
						if (Nexts[ID])
						{
							CurrentRender++;
							GameObject gameObject = UnityEngine.Object.Instantiate(Render.gameObject, Render.transform.position, Render.transform.rotation);
							gameObject.transform.parent = Render.transform.parent;
							gameObject.transform.localScale = new Vector3(1.604f, 1.604f, 1f);
							Render = gameObject.GetComponent<UITexture>();
							Render.mainTexture = Renders[CurrentRender];
							Render.color = new Color(1f, 1f, 1f, 0f);
							Render.depth++;
						}
						Typewriter.ResetToBeginning();
						Label.text = "";
						Typewriter.mFullText = Lines[ID];
						MyAudio.clip = Clips[ID];
						MyAudio.Play();
					}
					else
					{
						Typewriter.enabled = false;
						Phase++;
					}
				}
				else if (Input.GetButtonDown(InputNames.Xbox_X))
				{
					Phase++;
				}
				else if (Input.GetButtonDown(InputNames.Xbox_Y) && SkipTutorialButton.activeInHierarchy)
				{
					SkipTutorialWindow.SetActive(value: true);
				}
			}
			else if (Input.GetButtonDown(InputNames.Xbox_A))
			{
				SkipTutorialWindow.SetActive(value: false);
				Panel.SetActive(value: true);
				Phase++;
				SkipTutorial = true;
			}
			else if (Input.GetButtonDown(InputNames.Xbox_B))
			{
				SkipTutorialWindow.SetActive(value: false);
				Panel.SetActive(value: true);
			}
		}
		else if (Phase == 2)
		{
			if (GameGlobals.EightiesCutsceneID > 0)
			{
				Darkness.color = new Color(0.1f, 0.1f, 0.1f, 0f);
			}
			Phase++;
		}
		else
		{
			if (Phase != 3)
			{
				return;
			}
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 1f, Time.deltaTime);
			MyAudio.volume = Mathf.MoveTowards(MyAudio.volume, 0f, Time.deltaTime);
			BGM.volume = Mathf.MoveTowards(BGM.volume, 0f, Time.deltaTime * 0.1f);
			if (Darkness.alpha != 1f)
			{
				return;
			}
			if (SkipTutorial)
			{
				GameGlobals.EightiesTutorial = false;
				GameGlobals.EightiesCutsceneID = 1;
				OptionGlobals.Fog = false;
				SceneManager.LoadScene("EightiesCutsceneScene");
				return;
			}
			if (GameGlobals.EightiesCutsceneID == 0)
			{
				SceneManager.LoadScene("LoadingScene");
				return;
			}
			GameGlobals.Eighties = true;
			if (GameGlobals.EightiesCutsceneID > 1)
			{
				if (GameGlobals.RivalEliminationID == 0)
				{
					GameGlobals.RivalEliminationID = 1;
				}
				GameGlobals.SetRivalEliminations(DateGlobals.Week, GameGlobals.RivalEliminationID);
				GameGlobals.SetSpecificEliminations(DateGlobals.Week, GameGlobals.SpecificEliminationID);
				GameGlobals.RivalEliminationID = 0;
				GameGlobals.SpecificEliminationID = 0;
				DateGlobals.Week = GameGlobals.EightiesCutsceneID;
			}
			EventGlobals.LearnedAboutPhotographer = false;
			SchemeGlobals.EmbarassingSecret = false;
			CounselorGlobals.ReportedAlcohol = false;
			CounselorGlobals.ReportedCheating = false;
			CounselorGlobals.ReportedCigarettes = false;
			CounselorGlobals.ReportedCondoms = false;
			CounselorGlobals.ReportedTheft = false;
			SchemeGlobals.SetSchemeStage(6, 0);
			StudentGlobals.ExpelProgress = 0;
			DatingGlobals.RivalSabotaged = 0;
			DatingGlobals.SuitorProgress = 0;
			DatingGlobals.Affection = 0f;
			StudentGlobals.CustomSuitor = false;
			StudentGlobals.CustomSuitorHair = 0;
			StudentGlobals.CustomSuitorAccessory = 0;
			StudentGlobals.CustomSuitorBlack = false;
			StudentGlobals.CustomSuitorJewelry = 0;
			StudentGlobals.CustomSuitorEyewear = 0;
			StudentGlobals.CustomSuitorTan = false;
			for (int i = 1; i < 26; i++)
			{
				DatingGlobals.SetTopicDiscussed(i, value: false);
			}
			for (int j = 1; j < 11; j++)
			{
				DatingGlobals.SetComplimentGiven(j, value: false);
			}
			for (int k = 1; k < 11; k++)
			{
				DatingGlobals.SetSuitorCheck(k, value: false);
			}
			for (int l = 1; l < 4; l++)
			{
				DatingGlobals.SetTraitDemonstrated(l, 0);
				DatingGlobals.SetSuitorTrait(l, 0);
			}
			for (int m = 1; m < 5; m++)
			{
				CollectibleGlobals.SetGiftGiven(m, value: false);
			}
			DateGlobals.Weekday = DayOfWeek.Sunday;
			if (DateGlobals.Week == 1)
			{
				DateGlobals.PassDays = 1;
			}
			ClubGlobals.ActivitiesAttended = 0;
			if (DateGlobals.Week < 11)
			{
				Save();
				SceneManager.LoadScene("CalendarScene");
			}
			else if (GameGlobals.EightiesCutsceneID == 12)
			{
				SceneManager.LoadScene("GenocideScene");
			}
			else
			{
				SceneManager.LoadScene("LoadingScene");
			}
		}
	}

	private void Save()
	{
		YanSave.SaveData("Profile_" + GameGlobals.Profile + "_Slot_" + 11);
	}
}
