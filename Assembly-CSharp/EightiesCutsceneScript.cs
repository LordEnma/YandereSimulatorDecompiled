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

	public float Speed;

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
		Typewriter.gameObject.SetActive(false);
		if (GameGlobals.EightiesCutsceneID == 0)
		{
			DarkLine = 13;
		}
		if (GameGlobals.EightiesCutsceneID == 1)
		{
			Lines = CutsceneLines1;
			Clips = CutsceneClips1;
			DarkLine = 10;
			RivalLine = 10;
			Silhouette.mainTexture = RivalSilhouettes[1];
		}
		if (GameGlobals.EightiesCutsceneID == 2)
		{
			Lines = CutsceneLines2;
			Clips = CutsceneClips2;
			DarkLine = 13;
			RivalLine = 3;
			Silhouette.mainTexture = RivalSilhouettes[2];
		}
		if (GameGlobals.EightiesCutsceneID == 3)
		{
			Lines = CutsceneLines3;
			Clips = CutsceneClips3;
			DarkLine = 13;
			RivalLine = 3;
			Silhouette.mainTexture = RivalSilhouettes[3];
		}
		if (GameGlobals.EightiesCutsceneID == 4)
		{
			Lines = CutsceneLines4;
			Clips = CutsceneClips4;
			DarkLine = 12;
			RivalLine = 3;
			Silhouette.mainTexture = RivalSilhouettes[4];
		}
		if (GameGlobals.EightiesCutsceneID == 5)
		{
			Lines = CutsceneLines5;
			Clips = CutsceneClips5;
			DarkLine = 11;
			RivalLine = 2;
			Silhouette.mainTexture = RivalSilhouettes[5];
		}
		if (GameGlobals.EightiesCutsceneID == 6)
		{
			Lines = CutsceneLines6;
			Clips = CutsceneClips6;
			DarkLine = 12;
			RivalLine = 2;
			Silhouette.mainTexture = RivalSilhouettes[6];
		}
		if (GameGlobals.EightiesCutsceneID == 7)
		{
			Lines = CutsceneLines7;
			Clips = CutsceneClips7;
			DarkLine = 9;
			RivalLine = 3;
			Silhouette.mainTexture = RivalSilhouettes[7];
		}
		if (GameGlobals.EightiesCutsceneID == 8)
		{
			Lines = CutsceneLines8;
			Clips = CutsceneClips8;
			DarkLine = 14;
			RivalLine = 11;
			Silhouette.mainTexture = RivalSilhouettes[8];
		}
		if (GameGlobals.EightiesCutsceneID == 9)
		{
			Lines = CutsceneLines9;
			Clips = CutsceneClips9;
			DarkLine = 12;
			RivalLine = 8;
			Silhouette.mainTexture = RivalSilhouettes[9];
		}
		if (GameGlobals.EightiesCutsceneID == 10)
		{
			Lines = CutsceneLines10;
			Clips = CutsceneClips10;
			DarkLine = 0;
			RivalLine = 9;
			Silhouette.mainTexture = RivalSilhouettes[10];
		}
		if (GameGlobals.EightiesCutsceneID == 11)
		{
			Lines = CutsceneLines11;
			Clips = CutsceneClips11;
			DarkLine = 99;
			RivalLine = 99;
			Silhouette.mainTexture = RivalSilhouettes[10];
		}
		if (GameGlobals.EightiesCutsceneID == 12)
		{
			Lines = FinalCutsceneLines;
			Clips = FinalCutsceneClips;
			DarkLine = 99;
			RivalLine = 99;
			Silhouette.mainTexture = RivalSilhouettes[10];
		}
		Silhouette.alpha = 0f;
		if (GameGlobals.EightiesCutsceneID > 0)
		{
			SkipTutorialButton.SetActive(false);
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
			Label.transform.localPosition = Vector3.Lerp(Label.transform.localPosition, new Vector3(-800f, 360f, 0f), Time.deltaTime * Speed);
			Silhouette.alpha = Mathf.MoveTowards(Silhouette.alpha, 1f, Time.deltaTime);
		}
		if (Phase == 0)
		{
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 0f, Time.deltaTime);
			if (Darkness.alpha == 0f)
			{
				Typewriter.gameObject.SetActive(true);
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
				if (Input.GetButtonDown("A"))
				{
					if (Typewriter.mCurrentOffset < Typewriter.mFullText.Length)
					{
						Typewriter.Finish();
						return;
					}
					ID++;
					if (ID < Lines.Length)
					{
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
				else if (Input.GetButtonDown("X"))
				{
					Phase++;
				}
				else if (Input.GetButtonDown("Y") && SkipTutorialButton.activeInHierarchy)
				{
					SkipTutorialWindow.SetActive(true);
					Panel.SetActive(false);
				}
			}
			else if (Input.GetButtonDown("A"))
			{
				SkipTutorialWindow.SetActive(false);
				Panel.SetActive(true);
				Phase++;
				SkipTutorial = true;
			}
			else if (Input.GetButtonDown("B"))
			{
				SkipTutorialWindow.SetActive(false);
				Panel.SetActive(true);
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
				DatingGlobals.SetTopicDiscussed(i, false);
			}
			for (int j = 1; j < 11; j++)
			{
				DatingGlobals.SetComplimentGiven(j, false);
			}
			for (int k = 1; k < 4; k++)
			{
				DatingGlobals.SetTraitDemonstrated(k, 0);
				DatingGlobals.SetSuitorTrait(k, 0);
			}
			for (int l = 1; l < 5; l++)
			{
				CollectibleGlobals.SetGiftGiven(l, false);
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
