using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200029D RID: 669
public class EightiesCutsceneScript : MonoBehaviour
{
	// Token: 0x06001411 RID: 5137 RVA: 0x000BEA14 File Offset: 0x000BCC14
	private void Start()
	{
		GameGlobals.Eighties = true;
		if (GameGlobals.EightiesCutsceneID < 2)
		{
			this.Darkness.color = new Color(1f, 1f, 1f, 1f);
		}
		else
		{
			this.Darkness.color = new Color(0f, 0f, 0f, 1f);
		}
		this.Typewriter.gameObject.SetActive(false);
		if (GameGlobals.EightiesCutsceneID == 0)
		{
			this.DarkLine = 13;
		}
		if (GameGlobals.EightiesCutsceneID == 1)
		{
			this.Lines = this.CutsceneLines1;
			this.Clips = this.CutsceneClips1;
			this.DarkLine = 10;
			this.RivalLine = 10;
			this.Silhouette.mainTexture = this.RivalSilhouettes[1];
		}
		if (GameGlobals.EightiesCutsceneID == 2)
		{
			this.Lines = this.CutsceneLines2;
			this.Clips = this.CutsceneClips2;
			this.DarkLine = 13;
			this.RivalLine = 3;
			this.Silhouette.mainTexture = this.RivalSilhouettes[2];
		}
		if (GameGlobals.EightiesCutsceneID == 3)
		{
			this.Lines = this.CutsceneLines3;
			this.Clips = this.CutsceneClips3;
			this.DarkLine = 13;
			this.RivalLine = 3;
			this.Silhouette.mainTexture = this.RivalSilhouettes[3];
		}
		if (GameGlobals.EightiesCutsceneID == 4)
		{
			this.Lines = this.CutsceneLines4;
			this.Clips = this.CutsceneClips4;
			this.DarkLine = 12;
			this.RivalLine = 3;
			this.Silhouette.mainTexture = this.RivalSilhouettes[4];
		}
		if (GameGlobals.EightiesCutsceneID == 5)
		{
			this.Lines = this.CutsceneLines5;
			this.Clips = this.CutsceneClips5;
			this.DarkLine = 11;
			this.RivalLine = 2;
			this.Silhouette.mainTexture = this.RivalSilhouettes[5];
		}
		if (GameGlobals.EightiesCutsceneID == 6)
		{
			this.Lines = this.CutsceneLines6;
			this.Clips = this.CutsceneClips6;
			this.DarkLine = 12;
			this.RivalLine = 2;
			this.Silhouette.mainTexture = this.RivalSilhouettes[6];
		}
		if (GameGlobals.EightiesCutsceneID == 7)
		{
			this.Lines = this.CutsceneLines7;
			this.Clips = this.CutsceneClips7;
			this.DarkLine = 9;
			this.RivalLine = 3;
			this.Silhouette.mainTexture = this.RivalSilhouettes[7];
		}
		if (GameGlobals.EightiesCutsceneID == 8)
		{
			this.Lines = this.CutsceneLines8;
			this.Clips = this.CutsceneClips8;
			this.DarkLine = 14;
			this.RivalLine = 11;
			this.Silhouette.mainTexture = this.RivalSilhouettes[8];
		}
		if (GameGlobals.EightiesCutsceneID == 9)
		{
			this.Lines = this.CutsceneLines9;
			this.Clips = this.CutsceneClips9;
			this.DarkLine = 12;
			this.RivalLine = 8;
			this.Silhouette.mainTexture = this.RivalSilhouettes[9];
		}
		if (GameGlobals.EightiesCutsceneID == 10)
		{
			this.Lines = this.CutsceneLines10;
			this.Clips = this.CutsceneClips10;
			this.DarkLine = 0;
			this.RivalLine = 9;
			this.Silhouette.mainTexture = this.RivalSilhouettes[10];
		}
		if (GameGlobals.EightiesCutsceneID == 11)
		{
			this.Lines = this.CutsceneLines11;
			this.Clips = this.CutsceneClips11;
			this.DarkLine = 99;
			this.RivalLine = 99;
			this.Silhouette.mainTexture = this.RivalSilhouettes[10];
		}
		if (GameGlobals.EightiesCutsceneID == 12)
		{
			this.Lines = this.FinalCutsceneLines;
			this.Clips = this.FinalCutsceneClips;
			this.DarkLine = 99;
			this.RivalLine = 99;
			this.Silhouette.mainTexture = this.RivalSilhouettes[10];
		}
		this.Silhouette.alpha = 0f;
		if (GameGlobals.EightiesCutsceneID > 0)
		{
			this.SkipTutorialButton.SetActive(false);
		}
		Time.timeScale = 1f;
	}

	// Token: 0x06001412 RID: 5138 RVA: 0x000BEDEC File Offset: 0x000BCFEC
	private void Update()
	{
		if (this.Phase < 3)
		{
			this.BGM.volume = Mathf.MoveTowards(this.BGM.volume, 0.1f, Time.deltaTime * 0.1f);
		}
		if (this.DarkLine == 0)
		{
			this.BGM.pitch = 0.1f;
		}
		else if (this.ID >= this.DarkLine)
		{
			this.BGM.pitch = Mathf.MoveTowards(this.BGM.pitch, 0.9f, Time.deltaTime * 0.1f);
		}
		if (this.RivalLine > 0 && this.ID >= this.RivalLine)
		{
			this.Speed += Time.deltaTime;
			this.Label.transform.localPosition = Vector3.Lerp(this.Label.transform.localPosition, new Vector3(-800f, 360f, 0f), Time.deltaTime * this.Speed);
			this.Silhouette.alpha = Mathf.MoveTowards(this.Silhouette.alpha, 1f, Time.deltaTime);
		}
		if (this.Phase == 0)
		{
			this.Darkness.alpha = Mathf.MoveTowards(this.Darkness.alpha, 0f, Time.deltaTime);
			if (this.Darkness.alpha == 0f)
			{
				this.Typewriter.gameObject.SetActive(true);
				this.Typewriter.ResetToBeginning();
				this.Label.text = "";
				this.Typewriter.mFullText = this.Lines[this.ID];
				this.MyAudio.clip = this.Clips[this.ID];
				this.MyAudio.Play();
				this.Phase++;
				return;
			}
		}
		else if (this.Phase == 1)
		{
			if (!this.SkipTutorialWindow.activeInHierarchy)
			{
				if (Input.GetButtonDown("A"))
				{
					if (this.Typewriter.mCurrentOffset < this.Typewriter.mFullText.Length)
					{
						this.Typewriter.Finish();
						return;
					}
					this.ID++;
					if (this.ID < this.Lines.Length)
					{
						this.Typewriter.ResetToBeginning();
						this.Label.text = "";
						this.Typewriter.mFullText = this.Lines[this.ID];
						this.MyAudio.clip = this.Clips[this.ID];
						this.MyAudio.Play();
						return;
					}
					this.Typewriter.enabled = false;
					this.Phase++;
					return;
				}
				else
				{
					if (Input.GetButtonDown("X"))
					{
						this.Phase++;
						return;
					}
					if (Input.GetButtonDown("Y") && this.SkipTutorialButton.activeInHierarchy)
					{
						this.SkipTutorialWindow.SetActive(true);
						this.Panel.SetActive(false);
						return;
					}
				}
			}
			else
			{
				if (Input.GetButtonDown("A"))
				{
					this.SkipTutorialWindow.SetActive(false);
					this.Panel.SetActive(true);
					this.Phase++;
					this.SkipTutorial = true;
					return;
				}
				if (Input.GetButtonDown("B"))
				{
					this.SkipTutorialWindow.SetActive(false);
					this.Panel.SetActive(true);
					return;
				}
			}
		}
		else
		{
			if (this.Phase == 2)
			{
				if (GameGlobals.EightiesCutsceneID > 0)
				{
					this.Darkness.color = new Color(0f, 0f, 0f, 0f);
				}
				this.Phase++;
				return;
			}
			if (this.Phase == 3)
			{
				this.Darkness.alpha = Mathf.MoveTowards(this.Darkness.alpha, 1f, Time.deltaTime);
				this.MyAudio.volume = Mathf.MoveTowards(this.MyAudio.volume, 0f, Time.deltaTime);
				this.BGM.volume = Mathf.MoveTowards(this.BGM.volume, 0f, Time.deltaTime * 0.1f);
				if (this.Darkness.alpha == 1f)
				{
					if (this.SkipTutorial)
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
					if (DateGlobals.Week < 11)
					{
						this.Save();
						SceneManager.LoadScene("CalendarScene");
						return;
					}
					if (GameGlobals.EightiesCutsceneID == 12)
					{
						SceneManager.LoadScene("GenocideScene");
						return;
					}
					SceneManager.LoadScene("LoadingScene");
				}
			}
		}
	}

	// Token: 0x06001413 RID: 5139 RVA: 0x000BF3E4 File Offset: 0x000BD5E4
	private void Save()
	{
		int profile = GameGlobals.Profile;
		int num = 11;
		Debug.Log("Current profile is: " + profile.ToString());
		YanSave.SaveData("Profile_" + profile.ToString() + "_Slot_" + num.ToString());
		Debug.Log("Saved current state of the game to Slot #" + num.ToString());
	}

	// Token: 0x04001DF2 RID: 7666
	public GameObject SkipTutorialButton;

	// Token: 0x04001DF3 RID: 7667
	public GameObject SkipTutorialWindow;

	// Token: 0x04001DF4 RID: 7668
	public GameObject Panel;

	// Token: 0x04001DF5 RID: 7669
	public TypewriterEffect Typewriter;

	// Token: 0x04001DF6 RID: 7670
	public UITexture Silhouette;

	// Token: 0x04001DF7 RID: 7671
	public AudioSource MyAudio;

	// Token: 0x04001DF8 RID: 7672
	public AudioSource BGM;

	// Token: 0x04001DF9 RID: 7673
	public UISprite Darkness;

	// Token: 0x04001DFA RID: 7674
	public UILabel Label;

	// Token: 0x04001DFB RID: 7675
	public Texture[] RivalSilhouettes;

	// Token: 0x04001DFC RID: 7676
	public string[] Lines;

	// Token: 0x04001DFD RID: 7677
	public string[] CutsceneLines1;

	// Token: 0x04001DFE RID: 7678
	public string[] CutsceneLines2;

	// Token: 0x04001DFF RID: 7679
	public string[] CutsceneLines3;

	// Token: 0x04001E00 RID: 7680
	public string[] CutsceneLines4;

	// Token: 0x04001E01 RID: 7681
	public string[] CutsceneLines5;

	// Token: 0x04001E02 RID: 7682
	public string[] CutsceneLines6;

	// Token: 0x04001E03 RID: 7683
	public string[] CutsceneLines7;

	// Token: 0x04001E04 RID: 7684
	public string[] CutsceneLines8;

	// Token: 0x04001E05 RID: 7685
	public string[] CutsceneLines9;

	// Token: 0x04001E06 RID: 7686
	public string[] CutsceneLines10;

	// Token: 0x04001E07 RID: 7687
	public string[] CutsceneLines11;

	// Token: 0x04001E08 RID: 7688
	public string[] FinalCutsceneLines;

	// Token: 0x04001E09 RID: 7689
	public AudioClip[] Clips;

	// Token: 0x04001E0A RID: 7690
	public AudioClip[] CutsceneClips1;

	// Token: 0x04001E0B RID: 7691
	public AudioClip[] CutsceneClips2;

	// Token: 0x04001E0C RID: 7692
	public AudioClip[] CutsceneClips3;

	// Token: 0x04001E0D RID: 7693
	public AudioClip[] CutsceneClips4;

	// Token: 0x04001E0E RID: 7694
	public AudioClip[] CutsceneClips5;

	// Token: 0x04001E0F RID: 7695
	public AudioClip[] CutsceneClips6;

	// Token: 0x04001E10 RID: 7696
	public AudioClip[] CutsceneClips7;

	// Token: 0x04001E11 RID: 7697
	public AudioClip[] CutsceneClips8;

	// Token: 0x04001E12 RID: 7698
	public AudioClip[] CutsceneClips9;

	// Token: 0x04001E13 RID: 7699
	public AudioClip[] CutsceneClips10;

	// Token: 0x04001E14 RID: 7700
	public AudioClip[] CutsceneClips11;

	// Token: 0x04001E15 RID: 7701
	public AudioClip[] FinalCutsceneClips;

	// Token: 0x04001E16 RID: 7702
	public float Speed;

	// Token: 0x04001E17 RID: 7703
	public int RivalLine;

	// Token: 0x04001E18 RID: 7704
	public int DarkLine;

	// Token: 0x04001E19 RID: 7705
	public int Phase;

	// Token: 0x04001E1A RID: 7706
	public int ID;

	// Token: 0x04001E1B RID: 7707
	public string[] EliminationNames;

	// Token: 0x04001E1C RID: 7708
	public string[] EliminationDetails;

	// Token: 0x04001E1D RID: 7709
	public bool SkipTutorial;
}
