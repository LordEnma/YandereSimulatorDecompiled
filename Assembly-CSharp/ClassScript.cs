using UnityEngine;
using UnityEngine.SceneManagement;

public class ClassScript : MonoBehaviour
{
	public CutsceneManagerScript CutsceneManager;

	public InputManagerScript InputManager;

	public PromptBarScript PromptBar;

	public SchemesScript Schemes;

	public PortalScript Portal;

	public GameObject Poison;

	public GameObject DetailsWindow;

	public GameObject DescWindow;

	public UILabel StudyPointsLabel;

	public UILabel[] BenefitLabels;

	public UILabel[] SubjectLabels;

	public UILabel GradeUpDesc;

	public UILabel GradeUpName;

	public UILabel DescLabel;

	public UISprite Darkness;

	public Transform[] Subject1Bars;

	public Transform[] Subject2Bars;

	public Transform[] Subject3Bars;

	public Transform[] Subject4Bars;

	public Transform[] Subject5Bars;

	public string[] Subject1GradeText;

	public string[] Subject2GradeText;

	public string[] Subject3GradeText;

	public string[] Subject3GradeTextEighties;

	public string[] Subject4GradeText;

	public string[] Subject5GradeText;

	public Transform WarningWindow;

	public Transform GradeUpWindow;

	public Transform Highlight;

	public int[] SubjectTemp;

	public int[] Subject;

	public string[] Desc;

	public string[] EightiesDesc;

	public string[] BiologyBenefits;

	public string[] ChemistryBenefits;

	public string[] LanguageBenefits;

	public string[] LanguageBenefitsEighties;

	public string[] PhysicalBenefits;

	public string[] PsychologyBenefits;

	public int StartingPoints;

	public int BonusPoints;

	public int StudyPoints;

	public int GradeUpSubject;

	public int Selected;

	public int Grade;

	public bool ShowWarning;

	public bool GradeUp;

	public bool Show;

	public int Biology;

	public int Chemistry;

	public int Language;

	public int Physical;

	public int Psychology;

	public int BiologyGrade;

	public int ChemistryGrade;

	public int LanguageGrade;

	public int PhysicalGrade;

	public int PsychologyGrade;

	public int BiologyBonus;

	public int ChemistryBonus;

	public int LanguageBonus;

	public int PhysicalBonus;

	public int PsychologyBonus;

	public int Seduction;

	public int Numbness;

	public int Social;

	public int Stealth;

	public int Speed;

	public int Enlightenment;

	public int SpeedBonus;

	public int SocialBonus;

	public int StealthBonus;

	public int SeductionBonus;

	public int NumbnessBonus;

	public int EnlightenmentBonus;

	public float HoldRightTimer;

	public float HoldLeftTimer;

	public bool Initialized;

	private void Start()
	{
		if (Portal == null || !Portal.StudentManager.ReturnedFromSave)
		{
			GetStats();
		}
		if (SceneManager.GetActiveScene().name != "SchoolScene")
		{
			base.enabled = false;
			if (GameGlobals.Eighties)
			{
				Subject3GradeText = Subject3GradeTextEighties;
				LanguageBenefits = LanguageBenefitsEighties;
				if (EightiesDesc.Length != 0)
				{
					Desc[3] = EightiesDesc[3];
				}
			}
		}
		else
		{
			GradeUpWindow.localScale = Vector3.zero;
			Subject[1] = Biology;
			Subject[2] = Chemistry;
			Subject[3] = Language;
			Subject[4] = Physical;
			Subject[5] = Psychology;
			UpdateSubjectLabels();
			Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, 1f);
			UpdateBars();
		}
	}

	public void GetStats()
	{
		if (!Initialized)
		{
			BonusPoints += ClassGlobals.BonusStudyPoints;
			Initialized = true;
			Biology = ClassGlobals.Biology;
			Chemistry = ClassGlobals.Chemistry;
			Language = ClassGlobals.Language;
			Physical = ClassGlobals.Physical;
			Psychology = ClassGlobals.Psychology;
			BiologyGrade = ClassGlobals.BiologyGrade;
			ChemistryGrade = ClassGlobals.ChemistryGrade;
			LanguageGrade = ClassGlobals.LanguageGrade;
			PhysicalGrade = ClassGlobals.PhysicalGrade;
			PsychologyGrade = ClassGlobals.PsychologyGrade;
			if (BiologyBonus == 0)
			{
				BiologyBonus = ClassGlobals.BiologyBonus;
			}
			if (ChemistryBonus == 0)
			{
				ChemistryBonus = ClassGlobals.ChemistryBonus;
			}
			if (LanguageBonus == 0)
			{
				LanguageBonus = ClassGlobals.LanguageBonus;
			}
			if (PhysicalBonus == 0)
			{
				PhysicalBonus = ClassGlobals.PhysicalBonus;
			}
			if (PsychologyBonus == 0)
			{
				PsychologyBonus = ClassGlobals.PsychologyBonus;
			}
			Seduction = PlayerGlobals.Seduction;
			Numbness = PlayerGlobals.Numbness;
			Enlightenment = PlayerGlobals.Enlightenment;
			if (SocialBonus == 0)
			{
				SocialBonus = PlayerGlobals.SocialBonus;
			}
			if (StealthBonus == 0)
			{
				StealthBonus = PlayerGlobals.StealthBonus;
			}
			if (SeductionBonus == 0)
			{
				SeductionBonus = PlayerGlobals.SeductionBonus;
			}
			if (NumbnessBonus == 0)
			{
				NumbnessBonus = PlayerGlobals.NumbnessBonus;
			}
			if (EnlightenmentBonus == 0)
			{
				EnlightenmentBonus = PlayerGlobals.EnlightenmentBonus;
			}
		}
	}

	private void Update()
	{
		if (Show)
		{
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 0f, Time.deltaTime);
			if (Darkness.alpha <= 0.001f)
			{
				Darkness.alpha = 0f;
				if (!Portal.Yandere.NoDebug)
				{
					if (Input.GetKeyDown(KeyCode.Backslash))
					{
						GivePoints();
					}
					if (Input.GetKeyDown(KeyCode.P))
					{
						MaxPhysical();
					}
				}
				if (!ShowWarning)
				{
					if (InputManager.TappedDown)
					{
						Selected++;
						if (Selected > 5)
						{
							Selected = 1;
						}
						Highlight.localPosition = new Vector3(Highlight.localPosition.x, 375f - 125f * (float)Selected, Highlight.localPosition.z);
						UpdateSubjectLabels();
					}
					if (InputManager.TappedUp)
					{
						Selected--;
						if (Selected < 1)
						{
							Selected = 5;
						}
						Highlight.localPosition = new Vector3(Highlight.localPosition.x, 375f - 125f * (float)Selected, Highlight.localPosition.z);
						UpdateSubjectLabels();
					}
					if (InputManager.TappedRight)
					{
						AddStudyPoints();
					}
					if (InputManager.TappedLeft)
					{
						SubtractStudyPoints();
					}
					if (Input.GetAxisRaw(InputNames.Xbox_DpadX) > 0.5f || Input.GetAxisRaw("Horizontal") > 0.5f)
					{
						HoldRightTimer += Time.deltaTime;
						if (HoldRightTimer > 0.5f)
						{
							AddStudyPoints();
						}
					}
					else
					{
						HoldRightTimer = 0f;
					}
					if (Input.GetAxisRaw(InputNames.Xbox_DpadX) < -0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
					{
						HoldLeftTimer += Time.deltaTime;
						if (HoldLeftTimer > 0.5f)
						{
							SubtractStudyPoints();
						}
					}
					else
					{
						HoldLeftTimer = 0f;
					}
					if (Input.GetButtonDown(InputNames.Xbox_A))
					{
						bool flag = true;
						if (BiologyGrade == 5 && ChemistryGrade == 5 && LanguageGrade == 5 && PhysicalGrade == 5 && PsychologyGrade == 5)
						{
							flag = false;
						}
						if (StudyPoints == StartingPoints && flag)
						{
							ShowWarning = true;
							PromptBar.ClearButtons();
							PromptBar.Label[0].text = "Finish Class";
							PromptBar.Label[1].text = "Allocate Points";
							PromptBar.UpdateButtons();
						}
						else
						{
							ExitClass();
						}
					}
					if (Input.GetButtonDown(InputNames.Xbox_X))
					{
						if (DescWindow.activeInHierarchy)
						{
							DetailsWindow.SetActive(value: true);
							DescWindow.SetActive(value: false);
						}
						else
						{
							DetailsWindow.SetActive(value: false);
							DescWindow.SetActive(value: true);
						}
					}
				}
				else if (WarningWindow.localScale.x > 0.9f)
				{
					if (Input.GetButtonDown(InputNames.Xbox_A))
					{
						ExitClass();
					}
					if (Input.GetButtonDown(InputNames.Xbox_B))
					{
						PromptBar.ClearButtons();
						PromptBar.Label[0].text = "Finish Class";
						PromptBar.Label[2].text = "Details";
						PromptBar.Label[4].text = "Choose";
						PromptBar.Label[5].text = "Allocate";
						PromptBar.UpdateButtons();
						PromptBar.Show = true;
						ShowWarning = false;
					}
				}
			}
			if (ShowWarning)
			{
				WarningWindow.localScale = Vector3.Lerp(WarningWindow.localScale, Vector3.one, Time.deltaTime * 10f);
			}
			else
			{
				WarningWindow.localScale = Vector3.Lerp(WarningWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
			}
			return;
		}
		Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 1f, Time.deltaTime);
		if (!(Darkness.color.a > 0.999f))
		{
			return;
		}
		Darkness.alpha = 1f;
		if (!GradeUp)
		{
			if (GradeUpWindow.localScale.x > 0.1f)
			{
				GradeUpWindow.localScale = Vector3.Lerp(GradeUpWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
			}
			else
			{
				GradeUpWindow.localScale = Vector3.zero;
			}
			if (!(GradeUpWindow.localScale.x < 0.01f))
			{
				return;
			}
			GradeUpWindow.localScale = Vector3.zero;
			CheckForGradeUp();
			if (GradeUp)
			{
				return;
			}
			if (ChemistryGrade > 0 && Poison != null)
			{
				Poison.SetActive(value: true);
			}
			StudentManagerScript studentManager = Portal.Yandere.StudentManager;
			Debug.Log("The ClassScript is now going to check to see if the counselor needs to talk to a rival.");
			if (CutsceneManager.Scheme > 0 && studentManager.Students[studentManager.RivalID] != null && studentManager.Students[studentManager.RivalID].Alive && !studentManager.Students[studentManager.RivalID].Tranquil)
			{
				Debug.Log("We need to go to the counselor's office.");
				SchemeGlobals.SetSchemeStage(CutsceneManager.Scheme, 100);
				PromptBar.ClearButtons();
				PromptBar.Label[0].text = "Continue";
				PromptBar.UpdateButtons();
				CutsceneManager.gameObject.SetActive(value: true);
				Schemes.UpdateInstructions();
				base.gameObject.SetActive(value: false);
				CutsceneManager.GetComponent<CutsceneManagerScript>().Darkness.color = new Color(1f, 1f, 1f, 1f);
				CutsceneManager.GetComponent<CutsceneManagerScript>().R = 1f;
				CutsceneManager.GetComponent<CutsceneManagerScript>().G = 1f;
				CutsceneManager.GetComponent<CutsceneManagerScript>().B = 1f;
			}
			else
			{
				Debug.Log("We don't need to go to the counselor's office.");
				if (!Portal.FadeOut)
				{
					Portal.Yandere.PhysicalGrade = PhysicalGrade;
					Portal.Yandere.CharacterAnimation["f02_wrapCorpse_00"].speed = 1f + (float)Portal.Yandere.PhysicalGrade * 0.2f;
					Portal.Yandere.CameraEffects.UpdateDOF(Portal.OriginalDOF);
					Portal.ClassDarkness.alpha = 1f;
					Portal.Transition = true;
					Portal.FadeOut = false;
					Portal.Proceed = true;
					PromptBar.Show = false;
					base.gameObject.SetActive(value: false);
				}
			}
			return;
		}
		if (GradeUpWindow.localScale.x == 0f)
		{
			if (GradeUpSubject == 1)
			{
				GradeUpName.text = "BIOLOGY RANK UP";
				GradeUpDesc.text = Subject1GradeText[Grade];
			}
			else if (GradeUpSubject == 2)
			{
				GradeUpName.text = "CHEMISTRY RANK UP";
				GradeUpDesc.text = Subject2GradeText[Grade];
			}
			else if (GradeUpSubject == 3)
			{
				GradeUpName.text = "LANGUAGE RANK UP";
				GradeUpDesc.text = Subject3GradeText[Grade];
			}
			else if (GradeUpSubject == 4)
			{
				GradeUpName.text = "PHYSICAL RANK UP";
				GradeUpDesc.text = Subject4GradeText[Grade];
			}
			else if (GradeUpSubject == 5)
			{
				GradeUpName.text = "PSYCHOLOGY RANK UP";
				GradeUpDesc.text = Subject5GradeText[Grade];
			}
			GradeUpDesc.text = GradeUpDesc.text.Replace("\\n", "\n\n");
			PromptBar.ClearButtons();
			PromptBar.Label[0].text = "Continue";
			PromptBar.UpdateButtons();
			PromptBar.Show = true;
		}
		else if (GradeUpWindow.localScale.x > 0.9f && Input.GetButtonDown(InputNames.Xbox_A))
		{
			PromptBar.ClearButtons();
			GradeUp = false;
		}
		GradeUpWindow.localScale = Vector3.Lerp(GradeUpWindow.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
	}

	private void UpdateSubjectLabels()
	{
		DescLabel.text = Desc[Selected];
		for (int i = 1; i < 6; i++)
		{
			if (Selected == 1)
			{
				BenefitLabels[i].text = BiologyBenefits[i];
			}
			else if (Selected == 2)
			{
				BenefitLabels[i].text = ChemistryBenefits[i];
			}
			else if (Selected == 3)
			{
				BenefitLabels[i].text = LanguageBenefits[i];
			}
			else if (Selected == 4)
			{
				BenefitLabels[i].text = PhysicalBenefits[i];
			}
			else if (Selected == 5)
			{
				BenefitLabels[i].text = PsychologyBenefits[i];
			}
		}
		for (int j = 1; j < 6; j++)
		{
			SubjectLabels[j].color = new Color(0f, 0f, 0f, 1f);
		}
		SubjectLabels[Selected].color = new Color(1f, 1f, 1f, 1f);
	}

	public void UpdateLabel()
	{
		StudyPointsLabel.text = "STUDY POINTS: " + StudyPoints;
	}

	private void UpdateBars()
	{
		for (int i = 1; i < 6; i++)
		{
			Transform transform = Subject1Bars[i];
			if (Subject[1] + SubjectTemp[1] > (i - 1) * 20)
			{
				transform.localScale = new Vector3(0f - (float)((i - 1) * 20 - (Subject[1] + SubjectTemp[1])) / 20f, transform.localScale.y, transform.localScale.z);
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
			Transform transform2 = Subject2Bars[j];
			if (Subject[2] + SubjectTemp[2] > (j - 1) * 20)
			{
				transform2.localScale = new Vector3(0f - (float)((j - 1) * 20 - (Subject[2] + SubjectTemp[2])) / 20f, transform2.localScale.y, transform2.localScale.z);
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
			Transform transform3 = Subject3Bars[k];
			if (Subject[3] + SubjectTemp[3] > (k - 1) * 20)
			{
				transform3.localScale = new Vector3(0f - (float)((k - 1) * 20 - (Subject[3] + SubjectTemp[3])) / 20f, transform3.localScale.y, transform3.localScale.z);
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
			Transform transform4 = Subject4Bars[l];
			if (Subject[4] + SubjectTemp[4] > (l - 1) * 20)
			{
				transform4.localScale = new Vector3(0f - (float)((l - 1) * 20 - (Subject[4] + SubjectTemp[4])) / 20f, transform4.localScale.y, transform4.localScale.z);
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
			Transform transform5 = Subject5Bars[m];
			if (Subject[5] + SubjectTemp[5] > (m - 1) * 20)
			{
				transform5.localScale = new Vector3(0f - (float)((m - 1) * 20 - (Subject[5] + SubjectTemp[5])) / 20f, transform5.localScale.y, transform5.localScale.z);
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

	private void CheckForGradeUp()
	{
		if (Biology >= 20 && BiologyGrade < 1)
		{
			BiologyGrade = 1;
			GradeUpSubject = 1;
			GradeUp = true;
			Grade = 1;
		}
		else if (Biology >= 40 && BiologyGrade < 2)
		{
			BiologyGrade = 2;
			GradeUpSubject = 1;
			GradeUp = true;
			Grade = 2;
		}
		else if (Biology >= 60 && BiologyGrade < 3)
		{
			BiologyGrade = 3;
			GradeUpSubject = 1;
			GradeUp = true;
			Grade = 3;
		}
		else if (Biology >= 80 && BiologyGrade < 4)
		{
			BiologyGrade = 4;
			GradeUpSubject = 1;
			GradeUp = true;
			Grade = 4;
		}
		else if (Biology >= 100 && BiologyGrade < 5)
		{
			BiologyGrade = 5;
			GradeUpSubject = 1;
			GradeUp = true;
			Grade = 5;
		}
		else if (Chemistry >= 20 && ChemistryGrade < 1)
		{
			ChemistryGrade = 1;
			GradeUpSubject = 2;
			GradeUp = true;
			Grade = 1;
		}
		else if (Chemistry >= 40 && ChemistryGrade < 2)
		{
			ChemistryGrade = 2;
			GradeUpSubject = 2;
			GradeUp = true;
			Grade = 2;
		}
		else if (Chemistry >= 60 && ChemistryGrade < 3)
		{
			ChemistryGrade = 3;
			GradeUpSubject = 2;
			GradeUp = true;
			Grade = 3;
		}
		else if (Chemistry >= 80 && ChemistryGrade < 4)
		{
			ChemistryGrade = 4;
			GradeUpSubject = 2;
			GradeUp = true;
			Grade = 4;
		}
		else if (Chemistry >= 100 && ChemistryGrade < 5)
		{
			ChemistryGrade = 5;
			GradeUpSubject = 2;
			GradeUp = true;
			Grade = 5;
		}
		else if (Language >= 20 && LanguageGrade < 1)
		{
			LanguageGrade = 1;
			GradeUpSubject = 3;
			GradeUp = true;
			Grade = 1;
		}
		else if (Language >= 40 && LanguageGrade < 2)
		{
			LanguageGrade = 2;
			GradeUpSubject = 3;
			GradeUp = true;
			Grade = 2;
		}
		else if (Language >= 60 && LanguageGrade < 3)
		{
			LanguageGrade = 3;
			GradeUpSubject = 3;
			GradeUp = true;
			Grade = 3;
		}
		else if (Language >= 80 && LanguageGrade < 4)
		{
			LanguageGrade = 4;
			GradeUpSubject = 3;
			GradeUp = true;
			Grade = 4;
		}
		else if (Language >= 100 && LanguageGrade < 5)
		{
			LanguageGrade = 5;
			GradeUpSubject = 3;
			GradeUp = true;
			Grade = 5;
		}
		else if (Physical >= 20 && PhysicalGrade < 1)
		{
			PhysicalGrade = 1;
			GradeUpSubject = 4;
			GradeUp = true;
			Grade = 1;
		}
		else if (Physical >= 40 && PhysicalGrade < 2)
		{
			PhysicalGrade = 2;
			GradeUpSubject = 4;
			GradeUp = true;
			Grade = 2;
		}
		else if (Physical >= 60 && PhysicalGrade < 3)
		{
			PhysicalGrade = 3;
			GradeUpSubject = 4;
			GradeUp = true;
			Grade = 3;
		}
		else if (Physical >= 80 && PhysicalGrade < 4)
		{
			PhysicalGrade = 4;
			GradeUpSubject = 4;
			GradeUp = true;
			Grade = 4;
		}
		else if (Physical == 100 && PhysicalGrade < 5)
		{
			PhysicalGrade = 5;
			GradeUpSubject = 4;
			GradeUp = true;
			Grade = 5;
		}
		else if (Psychology >= 20 && PsychologyGrade < 1)
		{
			PsychologyGrade = 1;
			GradeUpSubject = 5;
			GradeUp = true;
			Grade = 1;
		}
		else if (Psychology >= 40 && PsychologyGrade < 2)
		{
			PsychologyGrade = 2;
			GradeUpSubject = 5;
			GradeUp = true;
			Grade = 2;
		}
		else if (Psychology >= 60 && PsychologyGrade < 3)
		{
			PsychologyGrade = 3;
			GradeUpSubject = 5;
			GradeUp = true;
			Grade = 3;
		}
		else if (Psychology >= 80 && PsychologyGrade < 4)
		{
			PsychologyGrade = 4;
			GradeUpSubject = 5;
			GradeUp = true;
			Grade = 4;
		}
		else if (Psychology >= 100 && PsychologyGrade < 5)
		{
			PsychologyGrade = 5;
			GradeUpSubject = 5;
			GradeUp = true;
			Grade = 5;
		}
		Portal.Yandere.UpdateNumbness();
	}

	private void GivePoints()
	{
		StudyPoints = 500;
		BiologyGrade = 0;
		ChemistryGrade = 0;
		LanguageGrade = 0;
		PhysicalGrade = 0;
		PsychologyGrade = 0;
		Biology = 19;
		Chemistry = 19;
		Language = 19;
		Physical = 19;
		Psychology = 19;
		Subject[1] = Biology;
		Subject[2] = Chemistry;
		Subject[3] = Language;
		Subject[4] = Physical;
		Subject[5] = Psychology;
		UpdateBars();
	}

	private void MaxPhysical()
	{
		PhysicalGrade = 0;
		Physical = 99;
		Subject[4] = Physical;
		UpdateBars();
	}

	private void AddStudyPoints()
	{
		if (StudyPoints > 0 && Subject[Selected] + SubjectTemp[Selected] < 100)
		{
			SubjectTemp[Selected]++;
			StudyPoints--;
			UpdateLabel();
			UpdateBars();
		}
	}

	private void SubtractStudyPoints()
	{
		if (SubjectTemp[Selected] > 0)
		{
			SubjectTemp[Selected]--;
			StudyPoints++;
			UpdateLabel();
			UpdateBars();
		}
	}

	private void ExitClass()
	{
		WarningWindow.localScale = Vector3.zero;
		ShowWarning = false;
		Show = false;
		PromptBar.ClearButtons();
		PromptBar.Show = false;
		Biology = Subject[1] + SubjectTemp[1];
		Chemistry = Subject[2] + SubjectTemp[2];
		Language = Subject[3] + SubjectTemp[3];
		Physical = Subject[4] + SubjectTemp[4];
		Psychology = Subject[5] + SubjectTemp[5];
		for (int i = 0; i < 6; i++)
		{
			Subject[i] += SubjectTemp[i];
			SubjectTemp[i] = 0;
		}
		CheckForGradeUp();
	}
}
