using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200029A RID: 666
public class EightiesCutsceneScript : MonoBehaviour
{
	// Token: 0x060013FC RID: 5116 RVA: 0x000BD51C File Offset: 0x000BB71C
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

	// Token: 0x060013FD RID: 5117 RVA: 0x000BD8F4 File Offset: 0x000BBAF4
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

	// Token: 0x060013FE RID: 5118 RVA: 0x000BDEDC File Offset: 0x000BC0DC
	private void Save()
	{
		int profile = GameGlobals.Profile;
		int num = 11;
		Debug.Log("Current profile is: " + profile.ToString());
		YanSave.SaveData("Profile_" + profile.ToString() + "_Slot_" + num.ToString());
		Debug.Log("Saved current state of the game to Slot #" + num.ToString());
	}

	// Token: 0x04001DB8 RID: 7608
	public GameObject SkipTutorialButton;

	// Token: 0x04001DB9 RID: 7609
	public GameObject SkipTutorialWindow;

	// Token: 0x04001DBA RID: 7610
	public GameObject Panel;

	// Token: 0x04001DBB RID: 7611
	public TypewriterEffect Typewriter;

	// Token: 0x04001DBC RID: 7612
	public UITexture Silhouette;

	// Token: 0x04001DBD RID: 7613
	public AudioSource MyAudio;

	// Token: 0x04001DBE RID: 7614
	public AudioSource BGM;

	// Token: 0x04001DBF RID: 7615
	public UISprite Darkness;

	// Token: 0x04001DC0 RID: 7616
	public UILabel Label;

	// Token: 0x04001DC1 RID: 7617
	public Texture[] RivalSilhouettes;

	// Token: 0x04001DC2 RID: 7618
	public string[] Lines;

	// Token: 0x04001DC3 RID: 7619
	public string[] CutsceneLines1;

	// Token: 0x04001DC4 RID: 7620
	public string[] CutsceneLines2;

	// Token: 0x04001DC5 RID: 7621
	public string[] CutsceneLines3;

	// Token: 0x04001DC6 RID: 7622
	public string[] CutsceneLines4;

	// Token: 0x04001DC7 RID: 7623
	public string[] CutsceneLines5;

	// Token: 0x04001DC8 RID: 7624
	public string[] CutsceneLines6;

	// Token: 0x04001DC9 RID: 7625
	public string[] CutsceneLines7;

	// Token: 0x04001DCA RID: 7626
	public string[] CutsceneLines8;

	// Token: 0x04001DCB RID: 7627
	public string[] CutsceneLines9;

	// Token: 0x04001DCC RID: 7628
	public string[] CutsceneLines10;

	// Token: 0x04001DCD RID: 7629
	public string[] CutsceneLines11;

	// Token: 0x04001DCE RID: 7630
	public string[] FinalCutsceneLines;

	// Token: 0x04001DCF RID: 7631
	public AudioClip[] Clips;

	// Token: 0x04001DD0 RID: 7632
	public AudioClip[] CutsceneClips1;

	// Token: 0x04001DD1 RID: 7633
	public AudioClip[] CutsceneClips2;

	// Token: 0x04001DD2 RID: 7634
	public AudioClip[] CutsceneClips3;

	// Token: 0x04001DD3 RID: 7635
	public AudioClip[] CutsceneClips4;

	// Token: 0x04001DD4 RID: 7636
	public AudioClip[] CutsceneClips5;

	// Token: 0x04001DD5 RID: 7637
	public AudioClip[] CutsceneClips6;

	// Token: 0x04001DD6 RID: 7638
	public AudioClip[] CutsceneClips7;

	// Token: 0x04001DD7 RID: 7639
	public AudioClip[] CutsceneClips8;

	// Token: 0x04001DD8 RID: 7640
	public AudioClip[] CutsceneClips9;

	// Token: 0x04001DD9 RID: 7641
	public AudioClip[] CutsceneClips10;

	// Token: 0x04001DDA RID: 7642
	public AudioClip[] CutsceneClips11;

	// Token: 0x04001DDB RID: 7643
	public AudioClip[] FinalCutsceneClips;

	// Token: 0x04001DDC RID: 7644
	public float Speed;

	// Token: 0x04001DDD RID: 7645
	public int RivalLine;

	// Token: 0x04001DDE RID: 7646
	public int DarkLine;

	// Token: 0x04001DDF RID: 7647
	public int Phase;

	// Token: 0x04001DE0 RID: 7648
	public int ID;

	// Token: 0x04001DE1 RID: 7649
	public string[] EliminationNames;

	// Token: 0x04001DE2 RID: 7650
	public string[] EliminationDetails;

	// Token: 0x04001DE3 RID: 7651
	public bool SkipTutorial;
}
