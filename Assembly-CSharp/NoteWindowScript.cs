using System;
using UnityEngine;

public class NoteWindowScript : MonoBehaviour
{
	public enum NoteSubjectType
	{
		Empty = 0,
		MakingFriends = 1,
		LowGrades = 2,
		FightingEvil = 3,
		SuspiciousActivity = 4,
		YourFriends = 5,
		SocialMedia = 6,
		Bullying = 7,
		TheSupernatural = 8,
		CompensatedDating = 9,
		DomesticAbuse = 10
	}

	public InputManagerScript InputManager;

	public NoteLockerScript NoteLocker;

	public PromptBarScript PromptBar;

	public YandereScript Yandere;

	public ClockScript Clock;

	public Transform SubHighlight;

	public Transform SubMenu;

	public UISprite[] SlotHighlights;

	public UILabel[] SlotLabels;

	public UILabel[] SubLabels;

	public string[] OriginalText;

	public string[] Subjects;

	public string[] Locations;

	public string[] Times;

	public float[] Hours;

	public bool[] SlotsFilled;

	public int SubSlot;

	public int MeetID;

	public int Slot = 1;

	public float Rotation;

	public float TimeID;

	public int ID;

	public bool Selecting;

	public bool Fade;

	public bool Show;

	public NoteSubjectType NoteSubject;

	public UITexture Stationery;

	public UISprite Background1;

	public UISprite Background2;

	public Texture LifeNoteTexture;

	public UILabel[] Labels;

	public bool LifeNote;

	public int TargetStudent;

	public string[] MurderMethods;

	private void Start()
	{
		SubMenu.transform.localScale = Vector3.zero;
		base.transform.localPosition = new Vector3(455f, -965f, 0f);
		base.transform.localEulerAngles = new Vector3(0f, 0f, -90f);
		OriginalText[1] = SlotLabels[1].text;
		OriginalText[2] = SlotLabels[2].text;
		OriginalText[3] = SlotLabels[3].text;
		UpdateHighlights();
		UpdateSubLabels();
		if (GameGlobals.Eighties)
		{
			Subjects[10] = "''Evil Photographer''";
			Subjects[6] = "technology";
		}
	}

	public void BecomeLifeNote()
	{
		Stationery.mainTexture = LifeNoteTexture;
		Stationery.color = new Color(1f, 1f, 1f, 1f);
		Background2.color = new Color(0f, 0f, 0f, 1f);
		UILabel[] labels = Labels;
		foreach (UILabel uILabel in labels)
		{
			if (uILabel != null)
			{
				uILabel.color = new Color(1f, 1f, 1f, 1f);
			}
		}
		Labels[1].color = new Color(1f, 1f, 1f, 0f);
		Labels[2].color = new Color(1f, 1f, 1f, 0f);
		Labels[3].transform.localPosition = new Vector3(-365f, 265f, 0f);
		Labels[3].text = "______________";
		Labels[4].text = "will die from";
		Labels[8].color = new Color(1f, 1f, 1f, 0f);
		SlotHighlights[1].transform.localPosition = new Vector3(-100f, 280f, 0f);
		labels = SubLabels;
		foreach (UILabel uILabel2 in labels)
		{
			if (uILabel2 != null)
			{
				uILabel2.color = new Color(1f, 1f, 1f, 1f);
			}
		}
		LifeNote = true;
	}

	private void Update()
	{
		float t = Time.unscaledDeltaTime * 10f;
		if (!Show)
		{
			if (Rotation > -90f)
			{
				base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(455f, -965f, 0f), t);
				Rotation = Mathf.Lerp(Rotation, -91f, t);
				base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y, Rotation);
			}
			else
			{
				base.gameObject.SetActive(value: false);
			}
			return;
		}
		base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, Vector3.zero, t);
		Rotation = Mathf.Lerp(Rotation, 0f, t);
		base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y, Rotation);
		Time.timeScale = 0.0001f;
		if (!Selecting)
		{
			if (SubMenu.transform.localScale.x > 0.1f)
			{
				SubMenu.transform.localScale = Vector3.Lerp(SubMenu.transform.localScale, Vector3.zero, t);
			}
			else
			{
				SubMenu.transform.localScale = Vector3.zero;
			}
			if (InputManager.TappedDown)
			{
				Slot++;
				if (Slot > 3)
				{
					Slot = 1;
				}
				UpdateHighlights();
			}
			if (InputManager.TappedUp)
			{
				Slot--;
				if (Slot < 1)
				{
					Slot = 3;
				}
				UpdateHighlights();
			}
			if (Input.GetButtonDown(InputNames.Xbox_A))
			{
				if (LifeNote && Slot == 1)
				{
					Yandere.PauseScreen.transform.parent.GetComponent<UIPanel>().alpha = 1f;
					Yandere.PauseScreen.StudentInfoMenu.UsingLifeNote = true;
					Yandere.PauseScreen.StudentInfoMenu.gameObject.SetActive(value: true);
					Yandere.PauseScreen.StudentInfoMenu.Column = 0;
					Yandere.PauseScreen.StudentInfoMenu.Row = 0;
					Yandere.PauseScreen.StudentInfoMenu.UpdateHighlight();
					Yandere.PauseScreen.StudentInfoMenu.GrabbedPortraits = false;
					Yandere.PauseScreen.MainMenu.SetActive(value: false);
					Yandere.PauseScreen.Panel.enabled = true;
					Yandere.PauseScreen.Sideways = true;
					Yandere.PauseScreen.Show = true;
					Time.timeScale = 0.0001f;
					Yandere.PromptBar.ClearButtons();
					Yandere.PromptBar.Label[1].text = "Cancel";
					Yandere.PromptBar.UpdateButtons();
					Yandere.PromptBar.Show = true;
					base.gameObject.SetActive(value: false);
				}
				else
				{
					PromptBar.Label[2].text = string.Empty;
					PromptBar.UpdateButtons();
					Selecting = true;
					UpdateSubLabels();
				}
			}
			if (Input.GetButtonDown(InputNames.Xbox_B))
			{
				Exit();
			}
			if (Input.GetButtonDown(InputNames.Xbox_X) && SlotsFilled[1] && SlotsFilled[2] && SlotsFilled[3])
			{
				if (LifeNote)
				{
					AudioSource.PlayClipAtPoint(Yandere.DramaticWriting, Yandere.transform.position);
					Yandere.CharacterAnimation.CrossFade(Yandere.IdleAnim);
					Yandere.CharacterAnimation["f02_dramaticWriting_00"].speed = 2f;
					Yandere.CharacterAnimation["f02_dramaticWriting_00"].time = 0f;
					Yandere.CharacterAnimation["f02_dramaticWriting_00"].weight = 0.75f;
					Yandere.CharacterAnimation.CrossFade("f02_dramaticWriting_00");
					Yandere.WritingName = true;
					Exit();
				}
				else
				{
					NoteLocker.MeetID = MeetID;
					NoteLocker.MeetTime = TimeID;
					NoteLocker.Prompt.enabled = false;
					NoteLocker.CanLeaveNote = false;
					NoteLocker.NoteLeft = true;
					if (!NoteLocker.StudentManager.Eighties)
					{
						if (NoteLocker.Student.StudentID == 30)
						{
							if (NoteSubject == NoteSubjectType.CompensatedDating)
							{
								NoteLocker.Success = true;
							}
						}
						else if (NoteLocker.Student.StudentID == 5)
						{
							if ((NoteLocker.Student.Bullied && NoteSubject == NoteSubjectType.Bullying && MeetID > 7) || NoteLocker.StudentManager.MissionMode)
							{
								NoteLocker.Success = true;
							}
						}
						else if ((NoteLocker.Student.StudentID == 2 || NoteLocker.Student.StudentID == 3 || NoteLocker.Student.Club == ClubType.Occult) && NoteSubject == NoteSubjectType.TheSupernatural)
						{
							NoteLocker.Success = true;
						}
					}
					if (NoteLocker.Student.StudentID == Yandere.StudentManager.RivalID)
					{
						if (DateGlobals.Weekday == DayOfWeek.Friday && TimeID == 17f)
						{
							Debug.Log("Note must fail because she wouldn't accept a note that close to confessing to Senpai.");
						}
						else if (NoteSubject == NoteSubjectType.DomesticAbuse)
						{
							NoteLocker.Success = true;
							if (SchemeGlobals.GetSchemeStage(6) == 5)
							{
								SchemeGlobals.SetSchemeStage(6, 6);
								Yandere.PauseScreen.Schemes.UpdateInstructions();
							}
						}
					}
					else if (NoteLocker.Student.Persona == PersonaType.Loner && NoteSubject == NoteSubjectType.MakingFriends)
					{
						NoteLocker.Success = true;
					}
					else if (NoteLocker.Student.Persona == PersonaType.TeachersPet && NoteSubject == NoteSubjectType.LowGrades)
					{
						NoteLocker.Success = true;
					}
					else if (NoteLocker.Student.Persona == PersonaType.Heroic && NoteSubject == NoteSubjectType.FightingEvil)
					{
						NoteLocker.Success = true;
					}
					else if (NoteLocker.Student.Persona == PersonaType.Coward)
					{
						if (NoteSubject == NoteSubjectType.MakingFriends || NoteSubject == NoteSubjectType.SuspiciousActivity)
						{
							NoteLocker.Success = true;
						}
					}
					else if (NoteLocker.Student.Persona == PersonaType.SocialButterfly && NoteSubject == NoteSubjectType.YourFriends)
					{
						NoteLocker.Success = true;
					}
					else if (NoteLocker.Student.Persona == PersonaType.PhoneAddict && NoteSubject == NoteSubjectType.SocialMedia)
					{
						NoteLocker.Success = true;
					}
					else if (NoteLocker.Student.Club == ClubType.Bully)
					{
						if (NoteSubject == NoteSubjectType.YourFriends || NoteSubject == NoteSubjectType.CompensatedDating)
						{
							NoteLocker.Success = true;
						}
					}
					else if (NoteLocker.Student.Persona == PersonaType.Sleuth)
					{
						if (NoteSubject == NoteSubjectType.MakingFriends || NoteSubject == NoteSubjectType.FightingEvil || NoteSubject == NoteSubjectType.MakingFriends || NoteSubject == NoteSubjectType.SuspiciousActivity || NoteSubject == NoteSubjectType.YourFriends)
						{
							NoteLocker.Success = true;
						}
					}
					else if (NoteLocker.Student.Persona == PersonaType.Spiteful || NoteLocker.Student.Persona == PersonaType.Evil)
					{
						if (NoteSubject == NoteSubjectType.Bullying)
						{
							NoteLocker.Success = true;
						}
					}
					else if (NoteLocker.Student.Persona == PersonaType.Violent)
					{
						if (NoteSubject == NoteSubjectType.Bullying)
						{
							NoteLocker.Success = true;
						}
					}
					else if (NoteLocker.Student.Persona == PersonaType.LandlineUser && (NoteSubject == NoteSubjectType.Bullying || NoteSubject == NoteSubjectType.FightingEvil || NoteSubject == NoteSubjectType.SuspiciousActivity))
					{
						NoteLocker.Success = true;
					}
					NoteLocker.FindStudentLocker.Prompt.Hide();
					NoteLocker.FindStudentLocker.Prompt.Label[0].text = "     You Must Wait For Other Student";
					NoteLocker.FindStudentLocker.TargetedStudent = NoteLocker.Student;
					NoteLocker.transform.GetChild(0).gameObject.SetActive(value: false);
				}
				Exit();
			}
		}
		else
		{
			SubMenu.transform.localScale = Vector3.Lerp(SubMenu.transform.localScale, new Vector3(1f, 1f, 1f), t);
			if (InputManager.TappedDown)
			{
				SubSlot++;
				if (LifeNote && Slot == 2)
				{
					if (SubSlot > 6)
					{
						SubSlot = 1;
					}
				}
				else if (SubSlot > 10)
				{
					SubSlot = 1;
				}
				SubHighlight.localPosition = new Vector3(SubHighlight.localPosition.x, 550f - 100f * (float)SubSlot, SubHighlight.localPosition.z);
			}
			if (InputManager.TappedUp)
			{
				SubSlot--;
				if (LifeNote && Slot == 2)
				{
					if (SubSlot < 1)
					{
						SubSlot = 6;
					}
				}
				else if (SubSlot < 1)
				{
					SubSlot = 10;
				}
				SubHighlight.localPosition = new Vector3(SubHighlight.localPosition.x, 550f - 100f * (float)SubSlot, SubHighlight.localPosition.z);
			}
			if (Input.GetButtonDown(InputNames.Xbox_A) && SubLabels[SubSlot].color.a > 0.5f && SubLabels[SubSlot].text != string.Empty && SubLabels[SubSlot].text != "??????????")
			{
				SlotLabels[Slot].text = SubLabels[SubSlot].text;
				SlotsFilled[Slot] = true;
				if (Slot == 1)
				{
					NoteSubject = (NoteSubjectType)SubSlot;
				}
				if (Slot == 2)
				{
					MeetID = SubSlot;
				}
				if (Slot == 3)
				{
					TimeID = Hours[SubSlot];
				}
				CheckForCompletion();
				Selecting = false;
				SubSlot = 1;
				SubHighlight.localPosition = new Vector3(SubHighlight.localPosition.x, 450f, SubHighlight.localPosition.z);
			}
			if (Input.GetButtonDown(InputNames.Xbox_B))
			{
				CheckForCompletion();
				Selecting = false;
				SubSlot = 1;
				SubHighlight.localPosition = new Vector3(SubHighlight.localPosition.x, 450f, SubHighlight.localPosition.z);
			}
		}
		UISprite uISprite = SlotHighlights[Slot];
		if (!Fade)
		{
			uISprite.color = new Color(uISprite.color.r, uISprite.color.g, uISprite.color.b, uISprite.color.a + 1f / 60f);
			if (uISprite.color.a >= 0.5f)
			{
				Fade = true;
			}
		}
		else
		{
			uISprite.color = new Color(uISprite.color.r, uISprite.color.g, uISprite.color.b, uISprite.color.a - 1f / 60f);
			if (uISprite.color.a <= 0f)
			{
				Fade = false;
			}
		}
	}

	private void UpdateHighlights()
	{
		for (int i = 1; i < SlotHighlights.Length; i++)
		{
			UISprite uISprite = SlotHighlights[i];
			uISprite.color = new Color(uISprite.color.r, uISprite.color.g, uISprite.color.b, 0f);
		}
	}

	private void UpdateSubLabels()
	{
		if (Slot == 1)
		{
			for (ID = 1; ID < SubLabels.Length; ID++)
			{
				UILabel uILabel = SubLabels[ID];
				uILabel.text = Subjects[ID];
				uILabel.color = new Color(uILabel.color.r, uILabel.color.g, uILabel.color.b, 1f);
			}
			if (!EventGlobals.Event1)
			{
				SubLabels[9].text = "??????????";
			}
			if (!GameGlobals.Eighties)
			{
				if (!Yandere.Police.EndOfDay.LearnedOsanaInfo1 || !Yandere.Police.EndOfDay.LearnedOsanaInfo2)
				{
					SubLabels[10].text = "??????????";
				}
			}
			else if (!Yandere.Police.EndOfDay.LearnedAboutPhotographer)
			{
				SubLabels[10].text = "??????????";
			}
		}
		else if (Slot == 2)
		{
			for (ID = 1; ID < SubLabels.Length; ID++)
			{
				UILabel uILabel2 = SubLabels[ID];
				uILabel2.color = new Color(uILabel2.color.r, uILabel2.color.g, uILabel2.color.b, 1f);
				if (LifeNote)
				{
					uILabel2.text = MurderMethods[ID];
				}
				else
				{
					uILabel2.text = Locations[ID];
				}
			}
		}
		else if (Slot == 3)
		{
			for (ID = 1; ID < SubLabels.Length; ID++)
			{
				UILabel uILabel3 = SubLabels[ID];
				uILabel3.text = Times[ID];
				uILabel3.color = new Color(uILabel3.color.r, uILabel3.color.g, uILabel3.color.b, 1f);
			}
			DisableOptions();
		}
	}

	public void CheckForCompletion()
	{
		if (SlotsFilled[1] && SlotsFilled[2] && SlotsFilled[3])
		{
			PromptBar.Label[2].text = "Finish";
			PromptBar.UpdateButtons();
		}
	}

	private void Exit()
	{
		UpdateHighlights();
		if (!Yandere.WritingName)
		{
			Yandere.CanMove = true;
		}
		Yandere.RPGCamera.enabled = true;
		Yandere.Blur.enabled = false;
		Yandere.HUD.alpha = 1f;
		Time.timeScale = 1f;
		Show = false;
		Slot = 1;
		PromptBar.Label[0].text = string.Empty;
		PromptBar.Label[1].text = string.Empty;
		PromptBar.Label[2].text = string.Empty;
		PromptBar.Label[4].text = string.Empty;
		PromptBar.Show = false;
		PromptBar.UpdateButtons();
		SlotLabels[1].text = OriginalText[1];
		SlotLabels[2].text = OriginalText[2];
		SlotLabels[3].text = OriginalText[3];
		SlotsFilled[1] = false;
		SlotsFilled[2] = false;
		SlotsFilled[3] = false;
	}

	private void DisableOptions()
	{
		if (Clock.HourTime >= 7.25f)
		{
			UILabel uILabel = SubLabels[1];
			uILabel.color = new Color(uILabel.color.r, uILabel.color.g, uILabel.color.b, 0.5f);
		}
		if (Clock.HourTime >= 7.5f)
		{
			UILabel uILabel2 = SubLabels[2];
			uILabel2.color = new Color(uILabel2.color.r, uILabel2.color.g, uILabel2.color.b, 0.5f);
		}
		if (Clock.HourTime >= 7.75f)
		{
			UILabel uILabel3 = SubLabels[3];
			uILabel3.color = new Color(uILabel3.color.r, uILabel3.color.g, uILabel3.color.b, 0.5f);
		}
		if (Clock.HourTime >= 8f)
		{
			UILabel uILabel4 = SubLabels[4];
			uILabel4.color = new Color(uILabel4.color.r, uILabel4.color.g, uILabel4.color.b, 0.5f);
		}
		if (Clock.HourTime >= 8.25f)
		{
			UILabel uILabel5 = SubLabels[5];
			uILabel5.color = new Color(uILabel5.color.r, uILabel5.color.g, uILabel5.color.b, 0.5f);
		}
		if (Clock.HourTime >= 15.5f)
		{
			UILabel uILabel6 = SubLabels[6];
			uILabel6.color = new Color(uILabel6.color.r, uILabel6.color.g, uILabel6.color.b, 0.5f);
		}
		if (Clock.HourTime >= 16f)
		{
			UILabel uILabel7 = SubLabels[7];
			uILabel7.color = new Color(uILabel7.color.r, uILabel7.color.g, uILabel7.color.b, 0.5f);
		}
		if (Clock.HourTime >= 16.5f)
		{
			UILabel uILabel8 = SubLabels[8];
			uILabel8.color = new Color(uILabel8.color.r, uILabel8.color.g, uILabel8.color.b, 0.5f);
		}
		if (Clock.HourTime >= 17f)
		{
			UILabel uILabel9 = SubLabels[9];
			uILabel9.color = new Color(uILabel9.color.r, uILabel9.color.g, uILabel9.color.b, 0.5f);
		}
		if (Clock.HourTime >= 17.5f)
		{
			UILabel uILabel10 = SubLabels[10];
			uILabel10.color = new Color(uILabel10.color.r, uILabel10.color.g, uILabel10.color.b, 0.5f);
		}
	}
}
