using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000453 RID: 1107
public class StudentInfoMenuScript : MonoBehaviour
{
	// Token: 0x06001D48 RID: 7496 RVA: 0x0015F328 File Offset: 0x0015D528
	private void Start()
	{
		StudentGlobals.GetStudentPhotographed(11);
		this.BusyBlocker.position = new Vector3(0f, 0f, 0f);
		for (int i = 1; i < 101; i++)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.StudentPortrait, base.transform.position, Quaternion.identity);
			gameObject.transform.parent = this.PortraitGrid;
			gameObject.transform.localPosition = new Vector3(-300f + (float)this.Column * 150f, 80f - (float)this.Row * 160f, 0f);
			gameObject.transform.localEulerAngles = Vector3.zero;
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			this.StudentPortraits[i] = gameObject.GetComponent<StudentPortraitScript>();
			this.Column++;
			if (this.Column > 4)
			{
				this.Column = 0;
				this.Row++;
			}
		}
		if (this.PauseScreen.Eighties)
		{
			this.Headmaster = this.EightiesHeadmaster;
			this.Counselor = this.EightiesCounselor;
			this.InfoChan = this.Journalist;
		}
		this.Column = 0;
		this.Row = 0;
	}

	// Token: 0x06001D49 RID: 7497 RVA: 0x0015F480 File Offset: 0x0015D680
	private void Update()
	{
		if (!this.GrabbedPortraits)
		{
			base.StartCoroutine(this.UpdatePortraits());
			this.GrabbedPortraits = true;
			if (this.PauseScreen.Eighties)
			{
				this.PauseScreen.BlackenAllText();
			}
		}
		if (Input.GetButtonDown("A"))
		{
			if (this.PromptBar.Label[0].text != string.Empty)
			{
				if (StudentGlobals.GetStudentPhotographed(this.StudentID) || this.StudentID > 97)
				{
					if (this.UsingLifeNote)
					{
						this.PauseScreen.MainMenu.SetActive(true);
						this.PauseScreen.Sideways = false;
						this.PauseScreen.Show = false;
						base.gameObject.SetActive(false);
						this.NoteWindow.TargetStudent = this.StudentID;
						this.NoteWindow.gameObject.SetActive(true);
						this.NoteWindow.SlotLabels[1].text = this.StudentManager.Students[this.StudentID].Name;
						this.NoteWindow.SlotsFilled[1] = true;
						this.UsingLifeNote = false;
						this.PromptBar.Label[0].text = "Confirm";
						this.PromptBar.UpdateButtons();
						this.NoteWindow.CheckForCompletion();
					}
					else
					{
						this.StudentInfo.gameObject.SetActive(true);
						this.StudentInfo.UpdateInfo(this.StudentID);
						this.StudentInfo.Topics.SetActive(false);
						base.gameObject.SetActive(false);
						this.PromptBar.ClearButtons();
						if (this.Gossiping)
						{
							this.PromptBar.Label[0].text = "Gossip";
						}
						if (this.Distracting)
						{
							this.PromptBar.Label[0].text = "Distract";
						}
						if (this.CyberBullying || this.CyberStalking)
						{
							this.PromptBar.Label[0].text = "Accept";
						}
						if (this.FindingLocker)
						{
							this.PromptBar.Label[0].text = "Find Locker";
						}
						if (this.MatchMaking)
						{
							this.PromptBar.Label[0].text = "Match";
						}
						if (this.Targeting || this.UsingLifeNote)
						{
							this.PromptBar.Label[0].text = "Kill";
						}
						if (this.SendingHome)
						{
							this.PromptBar.Label[0].text = "Send Home";
						}
						if (this.FiringCouncilMember)
						{
							this.PromptBar.Label[0].text = "Fire";
						}
						if (this.GettingOpinions)
						{
							this.PromptBar.Label[0].text = "Get Opinions";
						}
						if (this.StudentManager.Students[this.StudentID] != null)
						{
							if (this.StudentManager.Students[this.StudentID].gameObject.activeInHierarchy)
							{
								if (this.StudentManager.Tag.Target == this.StudentManager.Students[this.StudentID].Head)
								{
									this.PromptBar.Label[2].text = "Untag";
								}
								else
								{
									this.PromptBar.Label[2].text = "Tag";
								}
							}
							else
							{
								this.PromptBar.Label[2].text = "";
							}
						}
						else
						{
							this.PromptBar.Label[2].text = "";
						}
						this.PromptBar.Label[1].text = "Back";
						this.PromptBar.Label[3].text = "Interests";
						this.PromptBar.Label[6].text = "Reputation";
						this.PromptBar.UpdateButtons();
					}
				}
				else
				{
					StudentGlobals.SetStudentPhotographed(this.StudentID, true);
					if (this.StudentManager.Students[this.StudentID] != null)
					{
						for (int i = 0; i < this.StudentManager.Students[this.StudentID].Outlines.Length; i++)
						{
							if (this.StudentManager.Students[this.StudentID].Outlines[i] != null)
							{
								this.StudentManager.Students[this.StudentID].Outlines[i].enabled = true;
							}
						}
					}
					this.PauseScreen.ServiceMenu.gameObject.SetActive(true);
					this.PauseScreen.ServiceMenu.UpdateList();
					this.PauseScreen.ServiceMenu.UpdateDesc();
					this.PauseScreen.ServiceMenu.Purchase();
					this.GettingInfo = false;
					base.gameObject.SetActive(false);
				}
				if (this.PauseScreen.Eighties)
				{
					this.PauseScreen.BlackenAllText();
				}
			}
		}
		else if (Input.GetButtonDown("B"))
		{
			this.BusyBlocker.position = new Vector3(0f, 0f, 0f);
			if (this.Gossiping || this.Distracting || this.MatchMaking || this.Targeting)
			{
				if (this.Targeting)
				{
					this.PauseScreen.Yandere.RPGCamera.enabled = true;
				}
				this.PauseScreen.Yandere.Interaction = YandereInteractionType.Bye;
				this.PauseScreen.Yandere.TalkTimer = 2f;
				this.PauseScreen.MainMenu.SetActive(true);
				this.PauseScreen.Sideways = false;
				this.PauseScreen.Show = false;
				base.gameObject.SetActive(false);
				Time.timeScale = 1f;
				this.Distracting = false;
				this.MatchMaking = false;
				this.Gossiping = false;
				this.Targeting = false;
				this.PromptBar.ClearButtons();
				this.PromptBar.Show = false;
			}
			else if (this.CyberBullying || this.CyberStalking || this.FindingLocker)
			{
				this.PauseScreen.MainMenu.SetActive(true);
				this.PauseScreen.Sideways = false;
				this.PauseScreen.Show = false;
				base.gameObject.SetActive(false);
				Time.timeScale = 1f;
				if (this.FindingLocker)
				{
					this.PauseScreen.Yandere.RPGCamera.enabled = true;
				}
				this.FindingLocker = false;
				this.PromptBar.ClearButtons();
				this.PromptBar.Show = false;
			}
			else if (this.SendingHome || this.GettingInfo || this.GettingOpinions || this.FiringCouncilMember)
			{
				this.PauseScreen.ServiceMenu.gameObject.SetActive(true);
				this.PauseScreen.ServiceMenu.UpdateList();
				this.PauseScreen.ServiceMenu.UpdateDesc();
				base.gameObject.SetActive(false);
				this.FiringCouncilMember = false;
				this.GettingOpinions = false;
				this.SendingHome = false;
				this.GettingInfo = false;
			}
			else if (this.UsingLifeNote)
			{
				this.PauseScreen.MainMenu.SetActive(true);
				this.PauseScreen.Sideways = false;
				this.PauseScreen.Show = false;
				base.gameObject.SetActive(false);
				this.NoteWindow.gameObject.SetActive(true);
				this.UsingLifeNote = false;
			}
			else
			{
				this.PauseScreen.MainMenu.SetActive(true);
				this.PauseScreen.Sideways = false;
				this.PauseScreen.PressedB = true;
				base.gameObject.SetActive(false);
				this.PromptBar.ClearButtons();
				this.PromptBar.Label[0].text = "Accept";
				this.PromptBar.Label[1].text = "Exit";
				this.PromptBar.Label[4].text = "Choose";
				this.PromptBar.UpdateButtons();
				this.PromptBar.Show = true;
			}
		}
		float t = Time.unscaledDeltaTime * 10f;
		float num = (float)((this.Row % 2 == 0) ? (this.Row / 2) : ((this.Row - 1) / 2));
		float b = 320f * num;
		this.PortraitGrid.localPosition = new Vector3(this.PortraitGrid.localPosition.x, Mathf.Lerp(this.PortraitGrid.localPosition.y, b, t), this.PortraitGrid.localPosition.z);
		this.Scrollbar.localPosition = new Vector3(this.Scrollbar.localPosition.x, Mathf.Lerp(this.Scrollbar.localPosition.y, 175f - 350f * (this.PortraitGrid.localPosition.y / 2880f), t), this.Scrollbar.localPosition.z);
		if (this.InputManager.TappedUp)
		{
			this.Row--;
			if (this.Row < 0)
			{
				this.Row = this.Rows - 1;
			}
			this.UpdateHighlight();
		}
		if (this.InputManager.TappedDown)
		{
			this.Row++;
			if (this.Row > this.Rows - 1)
			{
				this.Row = 0;
			}
			this.UpdateHighlight();
		}
		if (this.InputManager.TappedRight)
		{
			this.Column++;
			if (this.Column > this.Columns - 1)
			{
				this.Column = 0;
			}
			this.UpdateHighlight();
		}
		if (this.InputManager.TappedLeft)
		{
			this.Column--;
			if (this.Column < 0)
			{
				this.Column = this.Columns - 1;
			}
			this.UpdateHighlight();
		}
		if (this.GrabPortraitsNextFrame)
		{
			this.Frame++;
			if (this.Frame > 1)
			{
				base.StartCoroutine(this.UpdatePortraits());
				this.GrabPortraitsNextFrame = false;
				this.Frame = 0;
			}
		}
	}

	// Token: 0x06001D4A RID: 7498 RVA: 0x0015FE90 File Offset: 0x0015E090
	public void UpdateHighlight()
	{
		this.Highlight.localPosition = new Vector3(-300f + (float)this.Column * 150f, 80f - (float)this.Row * 160f, this.Highlight.localPosition.z);
		this.BusyBlocker.position = new Vector3(0f, 0f, 0f);
		this.StudentID = 1 + (this.Column + this.Row * this.Columns);
		if (StudentGlobals.GetStudentPhotographed(this.StudentID) || this.StudentID > 97)
		{
			this.PromptBar.Label[0].text = "View Info";
			this.PromptBar.UpdateButtons();
		}
		else
		{
			this.PromptBar.Label[0].text = string.Empty;
			this.PromptBar.UpdateButtons();
		}
		if (this.Gossiping && (this.StudentID == 1 || this.StudentID == this.PauseScreen.Yandere.TargetStudent.StudentID || this.JSON.Students[this.StudentID].Club == ClubType.Sports || this.StudentManager.Students[this.StudentID] == null || StudentGlobals.GetStudentDead(this.StudentID) || this.StudentID > 97))
		{
			this.PromptBar.Label[0].text = string.Empty;
			this.PromptBar.UpdateButtons();
		}
		if (this.CyberBullying && (this.JSON.Students[this.StudentID].Gender == 1 || StudentGlobals.GetStudentDead(this.StudentID) || this.StudentID > 97))
		{
			this.PromptBar.Label[0].text = string.Empty;
			this.PromptBar.UpdateButtons();
		}
		if (this.CyberStalking && (StudentGlobals.GetStudentDead(this.StudentID) || StudentGlobals.GetStudentArrested(this.StudentID) || this.StudentID > 97))
		{
			this.PromptBar.Label[0].text = string.Empty;
			this.PromptBar.UpdateButtons();
		}
		if (this.FindingLocker && (this.StudentID == 1 || this.StudentID > 89 || (this.StudentManager.Students[this.StudentID] != null && this.StudentManager.Students[this.StudentID].Club == ClubType.Council) || StudentGlobals.GetStudentDead(this.StudentID)))
		{
			this.PromptBar.Label[0].text = string.Empty;
			this.PromptBar.UpdateButtons();
		}
		if (this.Distracting)
		{
			this.Dead = false;
			if (this.StudentManager.Students[this.StudentID] == null)
			{
				this.Dead = true;
			}
			if (this.Dead)
			{
				this.PromptBar.Label[0].text = string.Empty;
				this.PromptBar.UpdateButtons();
			}
			else if (this.StudentID == 1 || !this.StudentManager.Students[this.StudentID].Alive || this.StudentID == this.PauseScreen.Yandere.TargetStudent.StudentID || StudentGlobals.GetStudentKidnapped(this.StudentID) || this.StudentManager.Students[this.StudentID].Tranquil || this.StudentManager.Students[this.StudentID].Teacher || this.StudentManager.Students[this.StudentID].Slave || StudentGlobals.GetStudentDead(this.StudentID) || this.StudentManager.Students[this.StudentID].MyBento.Tampered || this.StudentID > 97)
			{
				if (this.StudentID > 1 && this.StudentManager.Students[this.StudentID] != null && this.StudentManager.Students[this.StudentID].InEvent)
				{
					this.BusyBlocker.position = this.Highlight.position;
				}
				this.PromptBar.Label[0].text = string.Empty;
				this.PromptBar.UpdateButtons();
			}
		}
		if (this.MatchMaking && (this.StudentID == this.PauseScreen.Yandere.TargetStudent.StudentID || StudentGlobals.GetStudentDead(this.StudentID) || this.StudentID > 97))
		{
			this.PromptBar.Label[0].text = string.Empty;
			this.PromptBar.UpdateButtons();
		}
		if (this.Targeting && (this.StudentID == 1 || this.StudentID > 97 || StudentGlobals.GetStudentDead(this.StudentID) || (this.StudentManager.Students[this.StudentID] != null && !this.StudentManager.Students[this.StudentID].gameObject.activeInHierarchy) || (this.StudentManager.Students[this.StudentID] != null && this.StudentManager.Students[this.StudentID].InEvent) || (this.StudentManager.Students[this.StudentID] != null && this.StudentManager.Students[this.StudentID].Tranquil)))
		{
			if (this.StudentID > 1 && this.StudentManager.Students[this.StudentID] != null && this.StudentManager.Students[this.StudentID].InEvent)
			{
				this.BusyBlocker.position = this.Highlight.position;
			}
			this.PromptBar.Label[0].text = string.Empty;
			this.PromptBar.UpdateButtons();
		}
		if (this.SendingHome)
		{
			Debug.Log("Highlighting student number " + this.StudentID.ToString());
			if (this.StudentManager.Students[this.StudentID] != null)
			{
				StudentScript studentScript = this.StudentManager.Students[this.StudentID];
				if (this.StudentID == 1 || StudentGlobals.GetStudentDead(this.StudentID) || (this.StudentID < 98 && studentScript.SentHome) || (this.StudentID > 97 || StudentGlobals.StudentSlave == this.StudentID || (studentScript.Club == ClubType.MartialArts && studentScript.ClubAttire)) || (studentScript.Club == ClubType.Sports && studentScript.ClubAttire) || this.StudentManager.Students[this.StudentID].CameraReacting || !StudentGlobals.GetStudentPhotographed(this.StudentID) || studentScript.Wet || studentScript.Slave || studentScript.Phoneless)
				{
					this.PromptBar.Label[0].text = string.Empty;
					this.PromptBar.UpdateButtons();
				}
			}
		}
		if (this.GettingInfo)
		{
			if (StudentGlobals.GetStudentPhotographed(this.StudentID) || this.StudentID > 97)
			{
				this.PromptBar.Label[0].text = string.Empty;
			}
			else
			{
				this.PromptBar.Label[0].text = "Get Info";
			}
			this.PromptBar.UpdateButtons();
		}
		if (this.GettingOpinions)
		{
			this.PromptBar.Label[0].text = "Get Opinions";
			this.PromptBar.UpdateButtons();
		}
		if (this.UsingLifeNote)
		{
			if (this.StudentID == 1 || this.StudentID > 97 || (this.StudentID > 11 && this.StudentID < 21) || this.StudentPortraits[this.StudentID].DeathShadow.activeInHierarchy || (this.StudentManager.Students[this.StudentID] != null && !this.StudentManager.Students[this.StudentID].enabled))
			{
				this.PromptBar.Label[0].text = "";
			}
			else
			{
				this.PromptBar.Label[0].text = "Kill";
			}
			this.PromptBar.UpdateButtons();
		}
		if (this.FiringCouncilMember)
		{
			if (this.StudentManager.Students[this.StudentID] != null)
			{
				if (!StudentGlobals.GetStudentPhotographed(this.StudentID) || this.StudentManager.Students[this.StudentID].Club != ClubType.Council)
				{
					this.PromptBar.Label[0].text = "";
				}
				else
				{
					this.PromptBar.Label[0].text = "Fire";
				}
			}
			this.PromptBar.UpdateButtons();
		}
		if (MissionModeGlobals.MissionMode && this.StudentID == 1)
		{
			this.PromptBar.Label[0].text = "";
		}
		if (this.PauseScreen.Eighties && this.Headmaster != this.EightiesHeadmaster)
		{
			this.Headmaster = this.EightiesHeadmaster;
			this.Counselor = this.EightiesCounselor;
			this.InfoChan = this.Journalist;
			if (this.StudentPortraits[98] != null)
			{
				this.StudentPortraits[98].Portrait.mainTexture = this.Counselor;
				this.StudentPortraits[99].Portrait.mainTexture = this.Headmaster;
				this.StudentPortraits[100].Portrait.mainTexture = this.InfoChan;
			}
		}
		this.UpdateNameLabel();
	}

	// Token: 0x06001D4B RID: 7499 RVA: 0x0016084C File Offset: 0x0015EA4C
	private void UpdateNameLabel()
	{
		if (this.StudentID > 97 || StudentGlobals.GetStudentPhotographed(this.StudentID) || this.GettingInfo)
		{
			this.NameLabel.text = this.JSON.Students[this.StudentID].Name;
			return;
		}
		this.NameLabel.text = "Unknown";
	}

	// Token: 0x06001D4C RID: 7500 RVA: 0x001608AB File Offset: 0x0015EAAB
	public IEnumerator UpdatePortraits()
	{
		if (this.Debugging)
		{
			Debug.Log("The Student Info Menu was instructed to get photos.");
		}
		string EightiesPrefix = "";
		if (this.PauseScreen.Eighties)
		{
			EightiesPrefix = "1989";
		}
		int num;
		for (int ID = 1; ID < 101; ID = num + 1)
		{
			if (ID == 0)
			{
				this.StudentPortraits[ID].Portrait.mainTexture = this.InfoChan;
			}
			else if (!this.PortraitLoaded[ID])
			{
				if (ID < 98)
				{
					if (this.PauseScreen.Eighties || (!this.PauseScreen.Eighties && ID < 12) || (!this.PauseScreen.Eighties && ID > 20))
					{
						if (StudentGlobals.GetStudentPhotographed(ID))
						{
							string url = string.Concat(new string[]
							{
								"file:///",
								Application.streamingAssetsPath,
								"/Portraits",
								EightiesPrefix,
								"/Student_",
								ID.ToString(),
								".png"
							});
							WWW www = new WWW(url);
							yield return www;
							if (www.error == null)
							{
								if (!StudentGlobals.GetStudentReplaced(ID))
								{
									this.StudentPortraits[ID].Portrait.mainTexture = www.texture;
								}
								else
								{
									this.StudentPortraits[ID].Portrait.mainTexture = this.BlankPortrait;
								}
							}
							else
							{
								this.StudentPortraits[ID].Portrait.mainTexture = this.UnknownPortrait;
							}
							this.PortraitLoaded[ID] = true;
							www = null;
						}
						else
						{
							this.StudentPortraits[ID].Portrait.mainTexture = this.UnknownPortrait;
						}
					}
					else
					{
						this.StudentPortraits[ID].Portrait.mainTexture = this.RivalPortraits[ID];
					}
				}
				else if (ID == 98)
				{
					this.StudentPortraits[ID].Portrait.mainTexture = this.Counselor;
				}
				else if (ID == 99)
				{
					this.StudentPortraits[ID].Portrait.mainTexture = this.Headmaster;
				}
				else if (ID == 100)
				{
					this.StudentPortraits[ID].Portrait.mainTexture = this.InfoChan;
				}
				else
				{
					this.StudentPortraits[ID].Portrait.mainTexture = this.RivalPortraits[ID];
				}
			}
			if (this.StudentManager.PantyShotTaken[ID] || PlayerGlobals.GetStudentPantyShot(ID))
			{
				this.StudentPortraits[ID].Panties.SetActive(true);
			}
			if (this.StudentManager.Students[ID] != null)
			{
				this.StudentPortraits[ID].Friend.SetActive(this.StudentManager.Students[ID].Friend);
			}
			if (StudentGlobals.GetStudentDying(ID) || StudentGlobals.GetStudentDead(ID))
			{
				this.StudentPortraits[ID].DeathShadow.SetActive(true);
			}
			if (MissionModeGlobals.MissionMode && ID == 1)
			{
				this.StudentPortraits[ID].DeathShadow.SetActive(true);
			}
			if (SceneManager.GetActiveScene().name == "SchoolScene" && this.StudentManager.Students[ID] != null && this.StudentManager.Students[ID].Tranquil)
			{
				this.StudentPortraits[ID].DeathShadow.SetActive(true);
			}
			if (StudentGlobals.GetStudentArrested(ID))
			{
				this.StudentPortraits[ID].PrisonBars.SetActive(true);
				this.StudentPortraits[ID].DeathShadow.SetActive(true);
			}
			num = ID;
		}
		yield break;
	}

	// Token: 0x040035AA RID: 13738
	public StudentManagerScript StudentManager;

	// Token: 0x040035AB RID: 13739
	public InputManagerScript InputManager;

	// Token: 0x040035AC RID: 13740
	public PauseScreenScript PauseScreen;

	// Token: 0x040035AD RID: 13741
	public StudentInfoScript StudentInfo;

	// Token: 0x040035AE RID: 13742
	public NoteWindowScript NoteWindow;

	// Token: 0x040035AF RID: 13743
	public PromptBarScript PromptBar;

	// Token: 0x040035B0 RID: 13744
	public JsonScript JSON;

	// Token: 0x040035B1 RID: 13745
	public GameObject StudentPortrait;

	// Token: 0x040035B2 RID: 13746
	public Texture UnknownPortrait;

	// Token: 0x040035B3 RID: 13747
	public Texture BlankPortrait;

	// Token: 0x040035B4 RID: 13748
	public Texture Headmaster;

	// Token: 0x040035B5 RID: 13749
	public Texture Counselor;

	// Token: 0x040035B6 RID: 13750
	public Texture InfoChan;

	// Token: 0x040035B7 RID: 13751
	public Texture EightiesHeadmaster;

	// Token: 0x040035B8 RID: 13752
	public Texture EightiesCounselor;

	// Token: 0x040035B9 RID: 13753
	public Texture Journalist;

	// Token: 0x040035BA RID: 13754
	public Transform PortraitGrid;

	// Token: 0x040035BB RID: 13755
	public Transform BusyBlocker;

	// Token: 0x040035BC RID: 13756
	public Transform Highlight;

	// Token: 0x040035BD RID: 13757
	public Transform Scrollbar;

	// Token: 0x040035BE RID: 13758
	public StudentPortraitScript[] StudentPortraits;

	// Token: 0x040035BF RID: 13759
	public Texture[] RivalPortraits;

	// Token: 0x040035C0 RID: 13760
	public bool[] PortraitLoaded;

	// Token: 0x040035C1 RID: 13761
	public UISprite[] DeathShadows;

	// Token: 0x040035C2 RID: 13762
	public UISprite[] Friends;

	// Token: 0x040035C3 RID: 13763
	public UISprite[] Panties;

	// Token: 0x040035C4 RID: 13764
	public UITexture[] PrisonBars;

	// Token: 0x040035C5 RID: 13765
	public UITexture[] Portraits;

	// Token: 0x040035C6 RID: 13766
	public UILabel NameLabel;

	// Token: 0x040035C7 RID: 13767
	public bool FiringCouncilMember;

	// Token: 0x040035C8 RID: 13768
	public bool GettingOpinions;

	// Token: 0x040035C9 RID: 13769
	public bool CyberBullying;

	// Token: 0x040035CA RID: 13770
	public bool CyberStalking;

	// Token: 0x040035CB RID: 13771
	public bool FindingLocker;

	// Token: 0x040035CC RID: 13772
	public bool UsingLifeNote;

	// Token: 0x040035CD RID: 13773
	public bool GettingInfo;

	// Token: 0x040035CE RID: 13774
	public bool MatchMaking;

	// Token: 0x040035CF RID: 13775
	public bool Distracting;

	// Token: 0x040035D0 RID: 13776
	public bool SendingHome;

	// Token: 0x040035D1 RID: 13777
	public bool Gossiping;

	// Token: 0x040035D2 RID: 13778
	public bool Targeting;

	// Token: 0x040035D3 RID: 13779
	public bool Dead;

	// Token: 0x040035D4 RID: 13780
	public int[] SetSizes;

	// Token: 0x040035D5 RID: 13781
	public int StudentID;

	// Token: 0x040035D6 RID: 13782
	public int Column;

	// Token: 0x040035D7 RID: 13783
	public int Row;

	// Token: 0x040035D8 RID: 13784
	public int Set;

	// Token: 0x040035D9 RID: 13785
	public int Columns;

	// Token: 0x040035DA RID: 13786
	public int Rows;

	// Token: 0x040035DB RID: 13787
	public bool GrabPortraitsNextFrame;

	// Token: 0x040035DC RID: 13788
	public int Frame;

	// Token: 0x040035DD RID: 13789
	public bool GrabbedPortraits;

	// Token: 0x040035DE RID: 13790
	public bool Debugging;
}
