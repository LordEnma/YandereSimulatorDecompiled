using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000249 RID: 585
public class ClassScript : MonoBehaviour
{
	// Token: 0x06001259 RID: 4697 RVA: 0x0008D4D4 File Offset: 0x0008B6D4
	private void Start()
	{
		if (this.Portal == null || !this.Portal.StudentManager.ReturnedFromSave)
		{
			this.GetStats();
		}
		if (SceneManager.GetActiveScene().name != "SchoolScene")
		{
			base.enabled = false;
		}
		else
		{
			this.GradeUpWindow.localScale = Vector3.zero;
			this.Subject[1] = this.Biology;
			this.Subject[2] = this.Chemistry;
			this.Subject[3] = this.Language;
			this.Subject[4] = this.Physical;
			this.Subject[5] = this.Psychology;
			this.DescLabel.text = this.Desc[this.Selected];
			this.UpdateSubjectLabels();
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
			this.UpdateBars();
		}
		if (GameGlobals.Eighties)
		{
			this.Subject3GradeText = this.Subject3GradeTextEighties;
		}
	}

	// Token: 0x0600125A RID: 4698 RVA: 0x0008D600 File Offset: 0x0008B800
	public void GetStats()
	{
		if (!this.Initialized)
		{
			this.BonusPoints += ClassGlobals.BonusStudyPoints;
			this.Initialized = true;
		}
		this.Biology = ClassGlobals.Biology;
		this.Chemistry = ClassGlobals.Chemistry;
		this.Language = ClassGlobals.Language;
		this.Physical = ClassGlobals.Physical;
		this.Psychology = ClassGlobals.Psychology;
		this.BiologyGrade = ClassGlobals.BiologyGrade;
		this.ChemistryGrade = ClassGlobals.ChemistryGrade;
		this.LanguageGrade = ClassGlobals.LanguageGrade;
		this.PhysicalGrade = ClassGlobals.PhysicalGrade;
		this.PsychologyGrade = ClassGlobals.PsychologyGrade;
		if (this.BiologyBonus == 0)
		{
			this.BiologyBonus = ClassGlobals.BiologyBonus;
		}
		if (this.ChemistryBonus == 0)
		{
			this.ChemistryBonus = ClassGlobals.ChemistryBonus;
		}
		if (this.LanguageBonus == 0)
		{
			this.LanguageBonus = ClassGlobals.LanguageBonus;
		}
		if (this.PhysicalBonus == 0)
		{
			this.PhysicalBonus = ClassGlobals.PhysicalBonus;
		}
		if (this.PsychologyBonus == 0)
		{
			this.PsychologyBonus = ClassGlobals.PsychologyBonus;
		}
		this.Seduction = PlayerGlobals.Seduction;
		this.Numbness = PlayerGlobals.Numbness;
		this.Enlightenment = PlayerGlobals.Enlightenment;
		if (this.SpeedBonus == 0)
		{
			this.SpeedBonus = PlayerGlobals.SpeedBonus;
		}
		if (this.SocialBonus == 0)
		{
			this.SocialBonus = PlayerGlobals.SocialBonus;
		}
		if (this.StealthBonus == 0)
		{
			this.StealthBonus = PlayerGlobals.StealthBonus;
		}
		if (this.SeductionBonus == 0)
		{
			this.SeductionBonus = PlayerGlobals.SeductionBonus;
		}
		if (this.NumbnessBonus == 0)
		{
			this.NumbnessBonus = PlayerGlobals.NumbnessBonus;
		}
		if (this.EnlightenmentBonus == 0)
		{
			this.EnlightenmentBonus = PlayerGlobals.EnlightenmentBonus;
		}
	}

	// Token: 0x0600125B RID: 4699 RVA: 0x0008D790 File Offset: 0x0008B990
	private void Update()
	{
		if (this.Show)
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a - Time.deltaTime);
			if (this.Darkness.color.a <= 0f)
			{
				if (!this.Portal.Yandere.NoDebug)
				{
					if (Input.GetKeyDown(KeyCode.Backslash))
					{
						this.GivePoints();
					}
					if (Input.GetKeyDown(KeyCode.P))
					{
						this.MaxPhysical();
					}
				}
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 0f);
				if (this.InputManager.TappedDown)
				{
					this.Selected++;
					if (this.Selected > 5)
					{
						this.Selected = 1;
					}
					this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 375f - 125f * (float)this.Selected, this.Highlight.localPosition.z);
					this.DescLabel.text = this.Desc[this.Selected];
					this.UpdateSubjectLabels();
				}
				if (this.InputManager.TappedUp)
				{
					this.Selected--;
					if (this.Selected < 1)
					{
						this.Selected = 5;
					}
					this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 375f - 125f * (float)this.Selected, this.Highlight.localPosition.z);
					this.DescLabel.text = this.Desc[this.Selected];
					this.UpdateSubjectLabels();
				}
				if (this.InputManager.TappedRight)
				{
					this.AddStudyPoints();
				}
				if (this.InputManager.TappedLeft)
				{
					this.SubtractStudyPoints();
				}
				if (Input.GetAxisRaw("DpadX") > 0.5f || Input.GetAxisRaw("Horizontal") > 0.5f)
				{
					this.HoldRightTimer += Time.deltaTime;
					if (this.HoldRightTimer > 0.5f)
					{
						this.AddStudyPoints();
					}
				}
				else
				{
					this.HoldRightTimer = 0f;
				}
				if (Input.GetAxisRaw("DpadX") < -0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
				{
					this.HoldLeftTimer += Time.deltaTime;
					if (this.HoldLeftTimer > 0.5f)
					{
						this.SubtractStudyPoints();
					}
				}
				else
				{
					this.HoldLeftTimer = 0f;
				}
				if (Input.GetButtonDown("A"))
				{
					this.Show = false;
					this.PromptBar.ClearButtons();
					this.PromptBar.Show = false;
					this.Biology = this.Subject[1] + this.SubjectTemp[1];
					this.Chemistry = this.Subject[2] + this.SubjectTemp[2];
					this.Language = this.Subject[3] + this.SubjectTemp[3];
					this.Physical = this.Subject[4] + this.SubjectTemp[4];
					this.Psychology = this.Subject[5] + this.SubjectTemp[5];
					for (int i = 0; i < 6; i++)
					{
						this.Subject[i] += this.SubjectTemp[i];
						this.SubjectTemp[i] = 0;
					}
					this.CheckForGradeUp();
					return;
				}
			}
		}
		else
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a + Time.deltaTime);
			if (this.Darkness.color.a >= 1f)
			{
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
				if (!this.GradeUp)
				{
					if (this.GradeUpWindow.localScale.x > 0.1f)
					{
						this.GradeUpWindow.localScale = Vector3.Lerp(this.GradeUpWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
					}
					else
					{
						this.GradeUpWindow.localScale = Vector3.zero;
					}
					if (this.GradeUpWindow.localScale.x < 0.01f)
					{
						this.GradeUpWindow.localScale = Vector3.zero;
						this.CheckForGradeUp();
						if (!this.GradeUp)
						{
							if (this.ChemistryGrade > 0 && this.Poison != null)
							{
								this.Poison.SetActive(true);
							}
							StudentManagerScript studentManager = this.Portal.Yandere.StudentManager;
							if (this.CutsceneManager.Scheme > 0 && studentManager.Students[studentManager.RivalID] != null && studentManager.Students[studentManager.RivalID].Alive && !studentManager.Students[studentManager.RivalID].Tranquil)
							{
								SchemeGlobals.SetSchemeStage(this.CutsceneManager.Scheme, 100);
								this.PromptBar.ClearButtons();
								this.PromptBar.Label[0].text = "Continue";
								this.PromptBar.UpdateButtons();
								this.CutsceneManager.gameObject.SetActive(true);
								this.Schemes.UpdateInstructions();
								base.gameObject.SetActive(false);
								return;
							}
							if (!this.Portal.FadeOut)
							{
								this.Portal.Yandere.PhysicalGrade = this.PhysicalGrade;
								this.PromptBar.Show = false;
								this.Portal.Proceed = true;
								base.gameObject.SetActive(false);
								return;
							}
						}
					}
				}
				else
				{
					if (this.GradeUpWindow.localScale.x == 0f)
					{
						if (this.GradeUpSubject == 1)
						{
							this.GradeUpName.text = "BIOLOGY RANK UP";
							this.GradeUpDesc.text = this.Subject1GradeText[this.Grade];
						}
						else if (this.GradeUpSubject == 2)
						{
							this.GradeUpName.text = "CHEMISTRY RANK UP";
							this.GradeUpDesc.text = this.Subject2GradeText[this.Grade];
						}
						else if (this.GradeUpSubject == 3)
						{
							this.GradeUpName.text = "LANGUAGE RANK UP";
							this.GradeUpDesc.text = this.Subject3GradeText[this.Grade];
						}
						else if (this.GradeUpSubject == 4)
						{
							this.GradeUpName.text = "PHYSICAL RANK UP";
							this.GradeUpDesc.text = this.Subject4GradeText[this.Grade];
						}
						else if (this.GradeUpSubject == 5)
						{
							this.GradeUpName.text = "PSYCHOLOGY RANK UP";
							this.GradeUpDesc.text = this.Subject5GradeText[this.Grade];
						}
						this.PromptBar.ClearButtons();
						this.PromptBar.Label[0].text = "Continue";
						this.PromptBar.UpdateButtons();
						this.PromptBar.Show = true;
					}
					else if (this.GradeUpWindow.localScale.x > 0.99f && Input.GetButtonDown("A"))
					{
						this.PromptBar.ClearButtons();
						this.GradeUp = false;
					}
					this.GradeUpWindow.localScale = Vector3.Lerp(this.GradeUpWindow.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				}
			}
		}
	}

	// Token: 0x0600125C RID: 4700 RVA: 0x0008DF98 File Offset: 0x0008C198
	private void UpdateSubjectLabels()
	{
		for (int i = 1; i < 6; i++)
		{
			this.SubjectLabels[i].color = new Color(0f, 0f, 0f, 1f);
		}
		this.SubjectLabels[this.Selected].color = new Color(1f, 1f, 1f, 1f);
	}

	// Token: 0x0600125D RID: 4701 RVA: 0x0008E004 File Offset: 0x0008C204
	public void UpdateLabel()
	{
		this.StudyPointsLabel.text = "STUDY POINTS: " + this.StudyPoints.ToString();
		this.PromptBar.Label[0].text = "Confirm";
		this.PromptBar.UpdateButtons();
	}

	// Token: 0x0600125E RID: 4702 RVA: 0x0008E054 File Offset: 0x0008C254
	private void UpdateBars()
	{
		for (int i = 1; i < 6; i++)
		{
			Transform transform = this.Subject1Bars[i];
			if (this.Subject[1] + this.SubjectTemp[1] > (i - 1) * 20)
			{
				transform.localScale = new Vector3(-((float)((i - 1) * 20 - (this.Subject[1] + this.SubjectTemp[1])) / 20f), transform.localScale.y, transform.localScale.z);
				if (transform.localScale.x > 1f)
				{
					transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
				}
			}
			else
			{
				transform.localScale = new Vector3(0f, transform.localScale.y, transform.localScale.z);
			}
		}
		for (int j = 1; j < 6; j++)
		{
			Transform transform2 = this.Subject2Bars[j];
			if (this.Subject[2] + this.SubjectTemp[2] > (j - 1) * 20)
			{
				transform2.localScale = new Vector3(-((float)((j - 1) * 20 - (this.Subject[2] + this.SubjectTemp[2])) / 20f), transform2.localScale.y, transform2.localScale.z);
				if (transform2.localScale.x > 1f)
				{
					transform2.localScale = new Vector3(1f, transform2.localScale.y, transform2.localScale.z);
				}
			}
			else
			{
				transform2.localScale = new Vector3(0f, transform2.localScale.y, transform2.localScale.z);
			}
		}
		for (int k = 1; k < 6; k++)
		{
			Transform transform3 = this.Subject3Bars[k];
			if (this.Subject[3] + this.SubjectTemp[3] > (k - 1) * 20)
			{
				transform3.localScale = new Vector3(-((float)((k - 1) * 20 - (this.Subject[3] + this.SubjectTemp[3])) / 20f), transform3.localScale.y, transform3.localScale.z);
				if (transform3.localScale.x > 1f)
				{
					transform3.localScale = new Vector3(1f, transform3.localScale.y, transform3.localScale.z);
				}
			}
			else
			{
				transform3.localScale = new Vector3(0f, transform3.localScale.y, transform3.localScale.z);
			}
		}
		for (int l = 1; l < 6; l++)
		{
			Transform transform4 = this.Subject4Bars[l];
			if (this.Subject[4] + this.SubjectTemp[4] > (l - 1) * 20)
			{
				transform4.localScale = new Vector3(-((float)((l - 1) * 20 - (this.Subject[4] + this.SubjectTemp[4])) / 20f), transform4.localScale.y, transform4.localScale.z);
				if (transform4.localScale.x > 1f)
				{
					transform4.localScale = new Vector3(1f, transform4.localScale.y, transform4.localScale.z);
				}
			}
			else
			{
				transform4.localScale = new Vector3(0f, transform4.localScale.y, transform4.localScale.z);
			}
		}
		for (int m = 1; m < 6; m++)
		{
			Transform transform5 = this.Subject5Bars[m];
			if (this.Subject[5] + this.SubjectTemp[5] > (m - 1) * 20)
			{
				transform5.localScale = new Vector3(-((float)((m - 1) * 20 - (this.Subject[5] + this.SubjectTemp[5])) / 20f), transform5.localScale.y, transform5.localScale.z);
				if (transform5.localScale.x > 1f)
				{
					transform5.localScale = new Vector3(1f, transform5.localScale.y, transform5.localScale.z);
				}
			}
			else
			{
				transform5.localScale = new Vector3(0f, transform5.localScale.y, transform5.localScale.z);
			}
		}
	}

	// Token: 0x0600125F RID: 4703 RVA: 0x0008E4CC File Offset: 0x0008C6CC
	private void CheckForGradeUp()
	{
		if (this.Biology >= 20 && this.BiologyGrade < 1)
		{
			this.BiologyGrade = 1;
			this.GradeUpSubject = 1;
			this.GradeUp = true;
			this.Grade = 1;
			return;
		}
		if (this.Biology >= 40 && this.BiologyGrade < 2)
		{
			this.BiologyGrade = 2;
			this.GradeUpSubject = 1;
			this.GradeUp = true;
			this.Grade = 2;
			return;
		}
		if (this.Biology >= 60 && this.BiologyGrade < 3)
		{
			this.BiologyGrade = 3;
			this.GradeUpSubject = 1;
			this.GradeUp = true;
			this.Grade = 3;
			return;
		}
		if (this.Biology >= 80 && this.BiologyGrade < 4)
		{
			this.BiologyGrade = 4;
			this.GradeUpSubject = 1;
			this.GradeUp = true;
			this.Grade = 4;
			return;
		}
		if (this.Biology >= 100 && this.BiologyGrade < 5)
		{
			this.BiologyGrade = 5;
			this.GradeUpSubject = 1;
			this.GradeUp = true;
			this.Grade = 5;
			return;
		}
		if (this.Chemistry >= 20 && this.ChemistryGrade < 1)
		{
			this.ChemistryGrade = 1;
			this.GradeUpSubject = 2;
			this.GradeUp = true;
			this.Grade = 1;
			return;
		}
		if (this.Chemistry >= 40 && this.ChemistryGrade < 2)
		{
			this.ChemistryGrade = 2;
			this.GradeUpSubject = 2;
			this.GradeUp = true;
			this.Grade = 2;
			return;
		}
		if (this.Chemistry >= 60 && this.ChemistryGrade < 3)
		{
			this.ChemistryGrade = 3;
			this.GradeUpSubject = 2;
			this.GradeUp = true;
			this.Grade = 3;
			return;
		}
		if (this.Chemistry >= 80 && this.ChemistryGrade < 4)
		{
			this.ChemistryGrade = 4;
			this.GradeUpSubject = 2;
			this.GradeUp = true;
			this.Grade = 4;
			return;
		}
		if (this.Chemistry >= 100 && this.ChemistryGrade < 5)
		{
			this.ChemistryGrade = 5;
			this.GradeUpSubject = 2;
			this.GradeUp = true;
			this.Grade = 5;
			return;
		}
		if (this.Language >= 20 && this.LanguageGrade < 1)
		{
			this.LanguageGrade = 1;
			this.GradeUpSubject = 3;
			this.GradeUp = true;
			this.Grade = 1;
			return;
		}
		if (this.Language >= 40 && this.LanguageGrade < 2)
		{
			this.LanguageGrade = 2;
			this.GradeUpSubject = 3;
			this.GradeUp = true;
			this.Grade = 2;
			return;
		}
		if (this.Language >= 60 && this.LanguageGrade < 3)
		{
			this.LanguageGrade = 3;
			this.GradeUpSubject = 3;
			this.GradeUp = true;
			this.Grade = 3;
			return;
		}
		if (this.Language >= 80 && this.LanguageGrade < 4)
		{
			this.LanguageGrade = 4;
			this.GradeUpSubject = 3;
			this.GradeUp = true;
			this.Grade = 4;
			return;
		}
		if (this.Language >= 100 && this.LanguageGrade < 5)
		{
			this.LanguageGrade = 5;
			this.GradeUpSubject = 3;
			this.GradeUp = true;
			this.Grade = 5;
			return;
		}
		if (this.Physical >= 20 && this.PhysicalGrade < 1)
		{
			this.PhysicalGrade = 1;
			this.GradeUpSubject = 4;
			this.GradeUp = true;
			this.Grade = 1;
			return;
		}
		if (this.Physical >= 40 && this.PhysicalGrade < 2)
		{
			this.PhysicalGrade = 2;
			this.GradeUpSubject = 4;
			this.GradeUp = true;
			this.Grade = 2;
			return;
		}
		if (this.Physical >= 60 && this.PhysicalGrade < 3)
		{
			this.PhysicalGrade = 3;
			this.GradeUpSubject = 4;
			this.GradeUp = true;
			this.Grade = 3;
			return;
		}
		if (this.Physical >= 80 && this.PhysicalGrade < 4)
		{
			this.PhysicalGrade = 4;
			this.GradeUpSubject = 4;
			this.GradeUp = true;
			this.Grade = 4;
			return;
		}
		if (this.Physical == 100 && this.PhysicalGrade < 5)
		{
			this.PhysicalGrade = 5;
			this.GradeUpSubject = 4;
			this.GradeUp = true;
			this.Grade = 5;
			return;
		}
		if (this.Psychology >= 20 && this.PsychologyGrade < 1)
		{
			this.PsychologyGrade = 1;
			this.GradeUpSubject = 5;
			this.GradeUp = true;
			this.Grade = 1;
			return;
		}
		if (this.Psychology >= 40 && this.PsychologyGrade < 2)
		{
			this.PsychologyGrade = 2;
			this.GradeUpSubject = 5;
			this.GradeUp = true;
			this.Grade = 2;
			return;
		}
		if (this.Psychology >= 60 && this.PsychologyGrade < 3)
		{
			this.PsychologyGrade = 3;
			this.GradeUpSubject = 5;
			this.GradeUp = true;
			this.Grade = 3;
			return;
		}
		if (this.Psychology >= 80 && this.PsychologyGrade < 4)
		{
			this.PsychologyGrade = 4;
			this.GradeUpSubject = 5;
			this.GradeUp = true;
			this.Grade = 4;
			return;
		}
		if (this.Psychology >= 100 && this.PsychologyGrade < 5)
		{
			this.PsychologyGrade = 5;
			this.GradeUpSubject = 5;
			this.GradeUp = true;
			this.Grade = 5;
		}
	}

	// Token: 0x06001260 RID: 4704 RVA: 0x0008E988 File Offset: 0x0008CB88
	private void GivePoints()
	{
		this.BiologyGrade = 0;
		this.ChemistryGrade = 0;
		this.LanguageGrade = 0;
		this.PhysicalGrade = 0;
		this.PsychologyGrade = 0;
		this.Biology = 19;
		this.Chemistry = 19;
		this.Language = 19;
		this.Physical = 19;
		this.Psychology = 19;
		this.Subject[1] = this.Biology;
		this.Subject[2] = this.Chemistry;
		this.Subject[3] = this.Language;
		this.Subject[4] = this.Physical;
		this.Subject[5] = this.Psychology;
		this.UpdateBars();
	}

	// Token: 0x06001261 RID: 4705 RVA: 0x0008EA2C File Offset: 0x0008CC2C
	private void MaxPhysical()
	{
		this.PhysicalGrade = 0;
		this.Physical = 99;
		this.Subject[4] = this.Physical;
		this.UpdateBars();
	}

	// Token: 0x06001262 RID: 4706 RVA: 0x0008EA54 File Offset: 0x0008CC54
	private void AddStudyPoints()
	{
		if (this.StudyPoints > 0 && this.Subject[this.Selected] + this.SubjectTemp[this.Selected] < 100)
		{
			this.SubjectTemp[this.Selected]++;
			this.StudyPoints--;
			this.UpdateLabel();
			this.UpdateBars();
		}
	}

	// Token: 0x06001263 RID: 4707 RVA: 0x0008EABC File Offset: 0x0008CCBC
	private void SubtractStudyPoints()
	{
		if (this.SubjectTemp[this.Selected] > 0)
		{
			this.SubjectTemp[this.Selected]--;
			this.StudyPoints++;
			this.UpdateLabel();
			this.UpdateBars();
		}
	}

	// Token: 0x04001735 RID: 5941
	public CutsceneManagerScript CutsceneManager;

	// Token: 0x04001736 RID: 5942
	public InputManagerScript InputManager;

	// Token: 0x04001737 RID: 5943
	public PromptBarScript PromptBar;

	// Token: 0x04001738 RID: 5944
	public SchemesScript Schemes;

	// Token: 0x04001739 RID: 5945
	public PortalScript Portal;

	// Token: 0x0400173A RID: 5946
	public GameObject Poison;

	// Token: 0x0400173B RID: 5947
	public UILabel StudyPointsLabel;

	// Token: 0x0400173C RID: 5948
	public UILabel[] SubjectLabels;

	// Token: 0x0400173D RID: 5949
	public UILabel GradeUpDesc;

	// Token: 0x0400173E RID: 5950
	public UILabel GradeUpName;

	// Token: 0x0400173F RID: 5951
	public UILabel DescLabel;

	// Token: 0x04001740 RID: 5952
	public UISprite Darkness;

	// Token: 0x04001741 RID: 5953
	public Transform[] Subject1Bars;

	// Token: 0x04001742 RID: 5954
	public Transform[] Subject2Bars;

	// Token: 0x04001743 RID: 5955
	public Transform[] Subject3Bars;

	// Token: 0x04001744 RID: 5956
	public Transform[] Subject4Bars;

	// Token: 0x04001745 RID: 5957
	public Transform[] Subject5Bars;

	// Token: 0x04001746 RID: 5958
	public string[] Subject1GradeText;

	// Token: 0x04001747 RID: 5959
	public string[] Subject2GradeText;

	// Token: 0x04001748 RID: 5960
	public string[] Subject3GradeText;

	// Token: 0x04001749 RID: 5961
	public string[] Subject3GradeTextEighties;

	// Token: 0x0400174A RID: 5962
	public string[] Subject4GradeText;

	// Token: 0x0400174B RID: 5963
	public string[] Subject5GradeText;

	// Token: 0x0400174C RID: 5964
	public Transform GradeUpWindow;

	// Token: 0x0400174D RID: 5965
	public Transform Highlight;

	// Token: 0x0400174E RID: 5966
	public int[] SubjectTemp;

	// Token: 0x0400174F RID: 5967
	public int[] Subject;

	// Token: 0x04001750 RID: 5968
	public string[] Desc;

	// Token: 0x04001751 RID: 5969
	public int GradeUpSubject;

	// Token: 0x04001752 RID: 5970
	public int BonusPoints;

	// Token: 0x04001753 RID: 5971
	public int StudyPoints;

	// Token: 0x04001754 RID: 5972
	public int Selected;

	// Token: 0x04001755 RID: 5973
	public int Grade;

	// Token: 0x04001756 RID: 5974
	public bool GradeUp;

	// Token: 0x04001757 RID: 5975
	public bool Show;

	// Token: 0x04001758 RID: 5976
	public int Biology;

	// Token: 0x04001759 RID: 5977
	public int Chemistry;

	// Token: 0x0400175A RID: 5978
	public int Language;

	// Token: 0x0400175B RID: 5979
	public int Physical;

	// Token: 0x0400175C RID: 5980
	public int Psychology;

	// Token: 0x0400175D RID: 5981
	public int BiologyGrade;

	// Token: 0x0400175E RID: 5982
	public int ChemistryGrade;

	// Token: 0x0400175F RID: 5983
	public int LanguageGrade;

	// Token: 0x04001760 RID: 5984
	public int PhysicalGrade;

	// Token: 0x04001761 RID: 5985
	public int PsychologyGrade;

	// Token: 0x04001762 RID: 5986
	public int BiologyBonus;

	// Token: 0x04001763 RID: 5987
	public int ChemistryBonus;

	// Token: 0x04001764 RID: 5988
	public int LanguageBonus;

	// Token: 0x04001765 RID: 5989
	public int PhysicalBonus;

	// Token: 0x04001766 RID: 5990
	public int PsychologyBonus;

	// Token: 0x04001767 RID: 5991
	public int Seduction;

	// Token: 0x04001768 RID: 5992
	public int Numbness;

	// Token: 0x04001769 RID: 5993
	public int Social;

	// Token: 0x0400176A RID: 5994
	public int Stealth;

	// Token: 0x0400176B RID: 5995
	public int Speed;

	// Token: 0x0400176C RID: 5996
	public int Enlightenment;

	// Token: 0x0400176D RID: 5997
	public int SpeedBonus;

	// Token: 0x0400176E RID: 5998
	public int SocialBonus;

	// Token: 0x0400176F RID: 5999
	public int StealthBonus;

	// Token: 0x04001770 RID: 6000
	public int SeductionBonus;

	// Token: 0x04001771 RID: 6001
	public int NumbnessBonus;

	// Token: 0x04001772 RID: 6002
	public int EnlightenmentBonus;

	// Token: 0x04001773 RID: 6003
	public float HoldRightTimer;

	// Token: 0x04001774 RID: 6004
	public float HoldLeftTimer;

	// Token: 0x04001775 RID: 6005
	public bool Initialized;
}
