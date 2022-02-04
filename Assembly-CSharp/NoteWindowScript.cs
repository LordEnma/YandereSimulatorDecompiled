using System;
using UnityEngine;

// Token: 0x0200037B RID: 891
public class NoteWindowScript : MonoBehaviour
{
	// Token: 0x060019FD RID: 6653 RVA: 0x00110A5C File Offset: 0x0010EC5C
	private void Start()
	{
		this.SubMenu.transform.localScale = Vector3.zero;
		base.transform.localPosition = new Vector3(455f, -965f, 0f);
		base.transform.localEulerAngles = new Vector3(0f, 0f, -90f);
		this.OriginalText[1] = this.SlotLabels[1].text;
		this.OriginalText[2] = this.SlotLabels[2].text;
		this.OriginalText[3] = this.SlotLabels[3].text;
		this.UpdateHighlights();
		this.UpdateSubLabels();
		if (GameGlobals.Eighties)
		{
			this.Subjects[10] = "''Evil Photographer''";
			this.Subjects[6] = "''Technology''";
		}
	}

	// Token: 0x060019FE RID: 6654 RVA: 0x00110B2C File Offset: 0x0010ED2C
	public void BecomeLifeNote()
	{
		this.Stationery.mainTexture = this.LifeNoteTexture;
		this.Stationery.color = new Color(1f, 1f, 1f, 1f);
		this.Background2.color = new Color(0f, 0f, 0f, 1f);
		foreach (UILabel uilabel in this.Labels)
		{
			if (uilabel != null)
			{
				uilabel.color = new Color(1f, 1f, 1f, 1f);
			}
		}
		this.Labels[1].color = new Color(1f, 1f, 1f, 0f);
		this.Labels[2].color = new Color(1f, 1f, 1f, 0f);
		this.Labels[3].transform.localPosition = new Vector3(-365f, 265f, 0f);
		this.Labels[3].text = "______________";
		this.Labels[4].text = "will die from";
		this.Labels[8].color = new Color(1f, 1f, 1f, 0f);
		this.SlotHighlights[1].transform.localPosition = new Vector3(-100f, 280f, 0f);
		foreach (UILabel uilabel2 in this.SubLabels)
		{
			if (uilabel2 != null)
			{
				uilabel2.color = new Color(1f, 1f, 1f, 1f);
			}
		}
		this.LifeNote = true;
	}

	// Token: 0x060019FF RID: 6655 RVA: 0x00110D00 File Offset: 0x0010EF00
	private void Update()
	{
		float t = Time.unscaledDeltaTime * 10f;
		if (this.Show)
		{
			base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, Vector3.zero, t);
			this.Rotation = Mathf.Lerp(this.Rotation, 0f, t);
			base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y, this.Rotation);
			if (!this.Selecting)
			{
				if (this.SubMenu.transform.localScale.x > 0.1f)
				{
					this.SubMenu.transform.localScale = Vector3.Lerp(this.SubMenu.transform.localScale, Vector3.zero, t);
				}
				else
				{
					this.SubMenu.transform.localScale = Vector3.zero;
				}
				if (this.InputManager.TappedDown)
				{
					this.Slot++;
					if (this.Slot > 3)
					{
						this.Slot = 1;
					}
					this.UpdateHighlights();
				}
				if (this.InputManager.TappedUp)
				{
					this.Slot--;
					if (this.Slot < 1)
					{
						this.Slot = 3;
					}
					this.UpdateHighlights();
				}
				if (Input.GetButtonDown("A"))
				{
					if (this.LifeNote && this.Slot == 1)
					{
						this.Yandere.PauseScreen.transform.parent.GetComponent<UIPanel>().alpha = 1f;
						this.Yandere.PauseScreen.StudentInfoMenu.UsingLifeNote = true;
						this.Yandere.PauseScreen.StudentInfoMenu.gameObject.SetActive(true);
						this.Yandere.PauseScreen.StudentInfoMenu.Column = 0;
						this.Yandere.PauseScreen.StudentInfoMenu.Row = 0;
						this.Yandere.PauseScreen.StudentInfoMenu.UpdateHighlight();
						this.Yandere.PauseScreen.StudentInfoMenu.GrabbedPortraits = false;
						this.Yandere.PauseScreen.MainMenu.SetActive(false);
						this.Yandere.PauseScreen.Panel.enabled = true;
						this.Yandere.PauseScreen.Sideways = true;
						this.Yandere.PauseScreen.Show = true;
						Time.timeScale = 0.0001f;
						this.Yandere.PromptBar.ClearButtons();
						this.Yandere.PromptBar.Label[1].text = "Cancel";
						this.Yandere.PromptBar.UpdateButtons();
						this.Yandere.PromptBar.Show = true;
						base.gameObject.SetActive(false);
					}
					else
					{
						this.PromptBar.Label[2].text = string.Empty;
						this.PromptBar.UpdateButtons();
						this.Selecting = true;
						this.UpdateSubLabels();
					}
				}
				if (Input.GetButtonDown("B"))
				{
					this.Exit();
				}
				if (Input.GetButtonDown("X") && this.SlotsFilled[1] && this.SlotsFilled[2] && this.SlotsFilled[3])
				{
					if (this.LifeNote)
					{
						AudioSource.PlayClipAtPoint(this.Yandere.DramaticWriting, this.Yandere.transform.position);
						this.Yandere.CharacterAnimation.CrossFade(this.Yandere.IdleAnim);
						this.Yandere.CharacterAnimation["f02_dramaticWriting_00"].speed = 2f;
						this.Yandere.CharacterAnimation["f02_dramaticWriting_00"].time = 0f;
						this.Yandere.CharacterAnimation["f02_dramaticWriting_00"].weight = 0.75f;
						this.Yandere.CharacterAnimation.CrossFade("f02_dramaticWriting_00");
						this.Yandere.WritingName = true;
						this.Exit();
					}
					else
					{
						this.NoteLocker.MeetID = this.MeetID;
						this.NoteLocker.MeetTime = this.TimeID;
						this.NoteLocker.Prompt.enabled = false;
						this.NoteLocker.CanLeaveNote = false;
						this.NoteLocker.NoteLeft = true;
						if (this.NoteLocker.Student.StudentID == 30)
						{
							if (this.NoteSubject == NoteWindowScript.NoteSubjectType.CompensatedDating || this.NoteSubject == NoteWindowScript.NoteSubjectType.DomesticAbuse)
							{
								this.NoteLocker.Success = true;
							}
						}
						else if (this.NoteLocker.Student.StudentID == 5)
						{
							if (this.NoteLocker.Student.Bullied && this.NoteSubject == NoteWindowScript.NoteSubjectType.Bullying && this.MeetID > 7)
							{
								this.NoteLocker.Success = true;
							}
						}
						else if (this.NoteLocker.Student.StudentID == this.Yandere.StudentManager.RivalID && this.NoteSubject == NoteWindowScript.NoteSubjectType.DomesticAbuse)
						{
							this.NoteLocker.Success = true;
							if (SchemeGlobals.GetSchemeStage(6) == 5)
							{
								SchemeGlobals.SetSchemeStage(6, 6);
								this.Yandere.PauseScreen.Schemes.UpdateInstructions();
							}
						}
						if (this.NoteLocker.Student.Persona == PersonaType.Loner || this.NoteLocker.Student.Persona == PersonaType.Sleuth)
						{
							if (this.NoteSubject == NoteWindowScript.NoteSubjectType.MakingFriends)
							{
								this.NoteLocker.Success = true;
							}
						}
						else if (this.NoteLocker.Student.Persona == PersonaType.TeachersPet && this.NoteSubject == NoteWindowScript.NoteSubjectType.LowGrades)
						{
							this.NoteLocker.Success = true;
						}
						else if (this.NoteLocker.Student.Persona == PersonaType.Heroic || this.NoteLocker.Student.Persona == PersonaType.Sleuth)
						{
							if (this.NoteSubject == NoteWindowScript.NoteSubjectType.FightingEvil)
							{
								this.NoteLocker.Success = true;
							}
						}
						else if (this.NoteLocker.Student.Persona == PersonaType.Coward || this.NoteLocker.Student.Persona == PersonaType.Sleuth)
						{
							if (this.NoteSubject == NoteWindowScript.NoteSubjectType.MakingFriends || this.NoteSubject == NoteWindowScript.NoteSubjectType.SuspiciousActivity)
							{
								this.NoteLocker.Success = true;
							}
						}
						else if (this.NoteLocker.Student.Persona == PersonaType.SocialButterfly || this.NoteLocker.Student.Persona == PersonaType.Sleuth)
						{
							if (this.NoteSubject == NoteWindowScript.NoteSubjectType.YourFriends)
							{
								this.NoteLocker.Success = true;
							}
						}
						else if (this.NoteLocker.Student.Persona == PersonaType.PhoneAddict && this.NoteSubject == NoteWindowScript.NoteSubjectType.SocialMedia)
						{
							this.NoteLocker.Success = true;
						}
						else if (this.NoteLocker.Student.StudentID == 2 || this.NoteLocker.Student.StudentID == 3 || this.NoteLocker.Student.Club == ClubType.Occult)
						{
							if (this.NoteSubject == NoteWindowScript.NoteSubjectType.TheSupernatural)
							{
								this.NoteLocker.Success = true;
							}
						}
						else if (this.NoteLocker.Student.Club == ClubType.Bully && (this.NoteSubject == NoteWindowScript.NoteSubjectType.YourFriends || this.NoteSubject == NoteWindowScript.NoteSubjectType.CompensatedDating))
						{
							this.NoteLocker.Success = true;
						}
						this.NoteLocker.FindStudentLocker.Prompt.Hide();
						this.NoteLocker.FindStudentLocker.Prompt.Label[0].text = "     You Must Wait For Other Student";
						this.NoteLocker.FindStudentLocker.TargetedStudent = this.NoteLocker.Student;
						this.NoteLocker.transform.GetChild(0).gameObject.SetActive(false);
					}
					this.Exit();
				}
			}
			else
			{
				this.SubMenu.transform.localScale = Vector3.Lerp(this.SubMenu.transform.localScale, new Vector3(1f, 1f, 1f), t);
				if (this.InputManager.TappedDown)
				{
					this.SubSlot++;
					if (this.LifeNote && this.Slot == 2)
					{
						if (this.SubSlot > 6)
						{
							this.SubSlot = 1;
						}
					}
					else if (this.SubSlot > 10)
					{
						this.SubSlot = 1;
					}
					this.SubHighlight.localPosition = new Vector3(this.SubHighlight.localPosition.x, 550f - 100f * (float)this.SubSlot, this.SubHighlight.localPosition.z);
				}
				if (this.InputManager.TappedUp)
				{
					this.SubSlot--;
					if (this.LifeNote && this.Slot == 2)
					{
						if (this.SubSlot < 1)
						{
							this.SubSlot = 6;
						}
					}
					else if (this.SubSlot < 1)
					{
						this.SubSlot = 10;
					}
					this.SubHighlight.localPosition = new Vector3(this.SubHighlight.localPosition.x, 550f - 100f * (float)this.SubSlot, this.SubHighlight.localPosition.z);
				}
				if (Input.GetButtonDown("A") && this.SubLabels[this.SubSlot].color.a > 0.5f && this.SubLabels[this.SubSlot].text != string.Empty && this.SubLabels[this.SubSlot].text != "??????????")
				{
					this.SlotLabels[this.Slot].text = this.SubLabels[this.SubSlot].text;
					this.SlotsFilled[this.Slot] = true;
					if (this.Slot == 1)
					{
						this.NoteSubject = (NoteWindowScript.NoteSubjectType)this.SubSlot;
					}
					if (this.Slot == 2)
					{
						this.MeetID = this.SubSlot;
					}
					if (this.Slot == 3)
					{
						this.TimeID = this.Hours[this.SubSlot];
					}
					this.CheckForCompletion();
					this.Selecting = false;
					this.SubSlot = 1;
					this.SubHighlight.localPosition = new Vector3(this.SubHighlight.localPosition.x, 450f, this.SubHighlight.localPosition.z);
				}
				if (Input.GetButtonDown("B"))
				{
					this.CheckForCompletion();
					this.Selecting = false;
					this.SubSlot = 1;
					this.SubHighlight.localPosition = new Vector3(this.SubHighlight.localPosition.x, 450f, this.SubHighlight.localPosition.z);
				}
			}
			UISprite uisprite = this.SlotHighlights[this.Slot];
			if (!this.Fade)
			{
				uisprite.color = new Color(uisprite.color.r, uisprite.color.g, uisprite.color.b, uisprite.color.a + 0.016666668f);
				if (uisprite.color.a >= 0.5f)
				{
					this.Fade = true;
					return;
				}
			}
			else
			{
				uisprite.color = new Color(uisprite.color.r, uisprite.color.g, uisprite.color.b, uisprite.color.a - 0.016666668f);
				if (uisprite.color.a <= 0f)
				{
					this.Fade = false;
				}
			}
			return;
		}
		if (this.Rotation > -90f)
		{
			base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(455f, -965f, 0f), t);
			this.Rotation = Mathf.Lerp(this.Rotation, -91f, t);
			base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y, this.Rotation);
			return;
		}
		base.gameObject.SetActive(false);
	}

	// Token: 0x06001A00 RID: 6656 RVA: 0x00111908 File Offset: 0x0010FB08
	private void UpdateHighlights()
	{
		for (int i = 1; i < this.SlotHighlights.Length; i++)
		{
			UISprite uisprite = this.SlotHighlights[i];
			uisprite.color = new Color(uisprite.color.r, uisprite.color.g, uisprite.color.b, 0f);
		}
	}

	// Token: 0x06001A01 RID: 6657 RVA: 0x00111964 File Offset: 0x0010FB64
	private void UpdateSubLabels()
	{
		if (this.Slot == 1)
		{
			this.ID = 1;
			while (this.ID < this.SubLabels.Length)
			{
				UILabel uilabel = this.SubLabels[this.ID];
				uilabel.text = this.Subjects[this.ID];
				uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 1f);
				this.ID++;
			}
			if (!EventGlobals.Event1)
			{
				this.SubLabels[9].text = "??????????";
			}
			if (!GameGlobals.Eighties)
			{
				if (!this.Yandere.Police.EndOfDay.LearnedOsanaInfo1 || !this.Yandere.Police.EndOfDay.LearnedOsanaInfo2)
				{
					this.SubLabels[10].text = "??????????";
					return;
				}
			}
			else if (!this.Yandere.Police.EndOfDay.LearnedAboutPhotographer)
			{
				this.SubLabels[10].text = "??????????";
				return;
			}
		}
		else
		{
			if (this.Slot == 2)
			{
				this.ID = 1;
				while (this.ID < this.SubLabels.Length)
				{
					UILabel uilabel2 = this.SubLabels[this.ID];
					uilabel2.color = new Color(uilabel2.color.r, uilabel2.color.g, uilabel2.color.b, 1f);
					if (this.LifeNote)
					{
						uilabel2.text = this.MurderMethods[this.ID];
					}
					else
					{
						uilabel2.text = this.Locations[this.ID];
					}
					this.ID++;
				}
				return;
			}
			if (this.Slot == 3)
			{
				this.ID = 1;
				while (this.ID < this.SubLabels.Length)
				{
					UILabel uilabel3 = this.SubLabels[this.ID];
					uilabel3.text = this.Times[this.ID];
					uilabel3.color = new Color(uilabel3.color.r, uilabel3.color.g, uilabel3.color.b, 1f);
					this.ID++;
				}
				this.DisableOptions();
			}
		}
	}

	// Token: 0x06001A02 RID: 6658 RVA: 0x00111BB8 File Offset: 0x0010FDB8
	public void CheckForCompletion()
	{
		if (this.SlotsFilled[1] && this.SlotsFilled[2] && this.SlotsFilled[3])
		{
			this.PromptBar.Label[2].text = "Finish";
			this.PromptBar.UpdateButtons();
		}
	}

	// Token: 0x06001A03 RID: 6659 RVA: 0x00111C08 File Offset: 0x0010FE08
	private void Exit()
	{
		this.UpdateHighlights();
		if (!this.Yandere.WritingName)
		{
			this.Yandere.CanMove = true;
		}
		this.Yandere.RPGCamera.enabled = true;
		this.Yandere.Blur.enabled = false;
		this.Yandere.HUD.alpha = 1f;
		Time.timeScale = 1f;
		this.Show = false;
		this.Slot = 1;
		this.PromptBar.Label[0].text = string.Empty;
		this.PromptBar.Label[1].text = string.Empty;
		this.PromptBar.Label[2].text = string.Empty;
		this.PromptBar.Label[4].text = string.Empty;
		this.PromptBar.Show = false;
		this.PromptBar.UpdateButtons();
		this.SlotLabels[1].text = this.OriginalText[1];
		this.SlotLabels[2].text = this.OriginalText[2];
		this.SlotLabels[3].text = this.OriginalText[3];
		this.SlotsFilled[1] = false;
		this.SlotsFilled[2] = false;
		this.SlotsFilled[3] = false;
	}

	// Token: 0x06001A04 RID: 6660 RVA: 0x00111D50 File Offset: 0x0010FF50
	private void DisableOptions()
	{
		if (this.Clock.HourTime >= 7.25f)
		{
			UILabel uilabel = this.SubLabels[1];
			uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 0.5f);
		}
		if (this.Clock.HourTime >= 7.5f)
		{
			UILabel uilabel2 = this.SubLabels[2];
			uilabel2.color = new Color(uilabel2.color.r, uilabel2.color.g, uilabel2.color.b, 0.5f);
		}
		if (this.Clock.HourTime >= 7.75f)
		{
			UILabel uilabel3 = this.SubLabels[3];
			uilabel3.color = new Color(uilabel3.color.r, uilabel3.color.g, uilabel3.color.b, 0.5f);
		}
		if (this.Clock.HourTime >= 8f)
		{
			UILabel uilabel4 = this.SubLabels[4];
			uilabel4.color = new Color(uilabel4.color.r, uilabel4.color.g, uilabel4.color.b, 0.5f);
		}
		if (this.Clock.HourTime >= 8.25f)
		{
			UILabel uilabel5 = this.SubLabels[5];
			uilabel5.color = new Color(uilabel5.color.r, uilabel5.color.g, uilabel5.color.b, 0.5f);
		}
		if (this.Clock.HourTime >= 15.5f)
		{
			UILabel uilabel6 = this.SubLabels[6];
			uilabel6.color = new Color(uilabel6.color.r, uilabel6.color.g, uilabel6.color.b, 0.5f);
		}
		if (this.Clock.HourTime >= 16f)
		{
			UILabel uilabel7 = this.SubLabels[7];
			uilabel7.color = new Color(uilabel7.color.r, uilabel7.color.g, uilabel7.color.b, 0.5f);
		}
		if (this.Clock.HourTime >= 16.5f)
		{
			UILabel uilabel8 = this.SubLabels[8];
			uilabel8.color = new Color(uilabel8.color.r, uilabel8.color.g, uilabel8.color.b, 0.5f);
		}
		if (this.Clock.HourTime >= 17f)
		{
			UILabel uilabel9 = this.SubLabels[9];
			uilabel9.color = new Color(uilabel9.color.r, uilabel9.color.g, uilabel9.color.b, 0.5f);
		}
		if (this.Clock.HourTime >= 17.5f)
		{
			UILabel uilabel10 = this.SubLabels[10];
			uilabel10.color = new Color(uilabel10.color.r, uilabel10.color.g, uilabel10.color.b, 0.5f);
		}
	}

	// Token: 0x04002A26 RID: 10790
	public InputManagerScript InputManager;

	// Token: 0x04002A27 RID: 10791
	public NoteLockerScript NoteLocker;

	// Token: 0x04002A28 RID: 10792
	public PromptBarScript PromptBar;

	// Token: 0x04002A29 RID: 10793
	public YandereScript Yandere;

	// Token: 0x04002A2A RID: 10794
	public ClockScript Clock;

	// Token: 0x04002A2B RID: 10795
	public Transform SubHighlight;

	// Token: 0x04002A2C RID: 10796
	public Transform SubMenu;

	// Token: 0x04002A2D RID: 10797
	public UISprite[] SlotHighlights;

	// Token: 0x04002A2E RID: 10798
	public UILabel[] SlotLabels;

	// Token: 0x04002A2F RID: 10799
	public UILabel[] SubLabels;

	// Token: 0x04002A30 RID: 10800
	public string[] OriginalText;

	// Token: 0x04002A31 RID: 10801
	public string[] Subjects;

	// Token: 0x04002A32 RID: 10802
	public string[] Locations;

	// Token: 0x04002A33 RID: 10803
	public string[] Times;

	// Token: 0x04002A34 RID: 10804
	public float[] Hours;

	// Token: 0x04002A35 RID: 10805
	public bool[] SlotsFilled;

	// Token: 0x04002A36 RID: 10806
	public int SubSlot;

	// Token: 0x04002A37 RID: 10807
	public int MeetID;

	// Token: 0x04002A38 RID: 10808
	public int Slot = 1;

	// Token: 0x04002A39 RID: 10809
	public float Rotation;

	// Token: 0x04002A3A RID: 10810
	public float TimeID;

	// Token: 0x04002A3B RID: 10811
	public int ID;

	// Token: 0x04002A3C RID: 10812
	public bool Selecting;

	// Token: 0x04002A3D RID: 10813
	public bool Fade;

	// Token: 0x04002A3E RID: 10814
	public bool Show;

	// Token: 0x04002A3F RID: 10815
	public NoteWindowScript.NoteSubjectType NoteSubject;

	// Token: 0x04002A40 RID: 10816
	public UITexture Stationery;

	// Token: 0x04002A41 RID: 10817
	public UISprite Background1;

	// Token: 0x04002A42 RID: 10818
	public UISprite Background2;

	// Token: 0x04002A43 RID: 10819
	public Texture LifeNoteTexture;

	// Token: 0x04002A44 RID: 10820
	public UILabel[] Labels;

	// Token: 0x04002A45 RID: 10821
	public bool LifeNote;

	// Token: 0x04002A46 RID: 10822
	public int TargetStudent;

	// Token: 0x04002A47 RID: 10823
	public string[] MurderMethods;

	// Token: 0x02000660 RID: 1632
	public enum NoteSubjectType
	{
		// Token: 0x04004F3A RID: 20282
		Empty,
		// Token: 0x04004F3B RID: 20283
		MakingFriends,
		// Token: 0x04004F3C RID: 20284
		LowGrades,
		// Token: 0x04004F3D RID: 20285
		FightingEvil,
		// Token: 0x04004F3E RID: 20286
		SuspiciousActivity,
		// Token: 0x04004F3F RID: 20287
		YourFriends,
		// Token: 0x04004F40 RID: 20288
		SocialMedia,
		// Token: 0x04004F41 RID: 20289
		Bullying,
		// Token: 0x04004F42 RID: 20290
		TheSupernatural,
		// Token: 0x04004F43 RID: 20291
		CompensatedDating,
		// Token: 0x04004F44 RID: 20292
		DomesticAbuse
	}
}
