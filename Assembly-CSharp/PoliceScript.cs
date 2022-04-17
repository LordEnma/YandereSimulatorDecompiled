using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020003B1 RID: 945
public class PoliceScript : MonoBehaviour
{
	// Token: 0x06001AE5 RID: 6885 RVA: 0x001246E0 File Offset: 0x001228E0
	private void Start()
	{
		if (SchoolGlobals.SchoolAtmosphere > 0.5f)
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 0f);
			this.Darkness.enabled = false;
		}
		base.transform.localPosition = new Vector3(-260f, base.transform.localPosition.y, base.transform.localPosition.z);
		foreach (UILabel uilabel in this.ResultsLabels)
		{
			uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 0f);
		}
		this.ContinueLabel.color = new Color(this.ContinueLabel.color.r, this.ContinueLabel.color.g, this.ContinueLabel.color.b, 0f);
		this.ContinueButton.color = new Color(this.ContinueButton.color.r, this.ContinueButton.color.g, this.ContinueButton.color.b, 0f);
		this.Icons.SetActive(false);
		if (GameGlobals.Eighties)
		{
			this.Protagonist = "Ryoba";
			this.TargetX = 25f;
			this.TargetY = -25f;
		}
	}

	// Token: 0x06001AE6 RID: 6886 RVA: 0x00124888 File Offset: 0x00122A88
	private void Update()
	{
		if (this.Show)
		{
			if (this.StudentManager.Eighties && !this.TextUpdated)
			{
				this.Frame++;
				if (this.Frame > 1)
				{
					foreach (UILabel label in base.gameObject.GetComponentsInChildren<UILabel>())
					{
						this.StudentManager.EightiesifyLabel(label);
					}
					this.TextUpdated = true;
				}
			}
			this.StudentManager.TutorialWindow.ShowPoliceMessage = true;
			bool poisonScene = this.PoisonScene;
			if (!this.Icons.activeInHierarchy)
			{
				this.Icons.SetActive(true);
			}
			base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, this.TargetX, Time.deltaTime * 10f), Mathf.Lerp(base.transform.localPosition.y, this.TargetY, Time.deltaTime * 10f), base.transform.localPosition.z);
			if (this.BloodParent.childCount == 0)
			{
				if (!this.BloodDisposed)
				{
					this.BloodIcon.spriteName = "Yes";
					this.BloodDisposed = true;
				}
			}
			else if (this.BloodDisposed)
			{
				this.BloodIcon.spriteName = "No";
				this.BloodDisposed = false;
			}
			if (this.BloodyClothing == 0)
			{
				if (!this.UniformDisposed)
				{
					this.UniformIcon.spriteName = "Yes";
					this.UniformDisposed = true;
				}
			}
			else if (this.UniformDisposed)
			{
				this.UniformIcon.spriteName = "No";
				this.UniformDisposed = false;
			}
			if (this.MurderWeapons == 0 || this.IncineratedWeapons == this.MurderWeapons)
			{
				if (!this.WeaponDisposed)
				{
					this.WeaponIcon.spriteName = "Yes";
					this.WeaponDisposed = true;
				}
			}
			else if (this.WeaponDisposed)
			{
				this.WeaponIcon.spriteName = "No";
				this.WeaponDisposed = false;
			}
			if (this.Corpses == 0)
			{
				if (!this.CorpseDisposed)
				{
					this.CorpseIcon.spriteName = "Yes";
					this.CorpseDisposed = true;
				}
			}
			else if (this.CorpseDisposed)
			{
				this.CorpseIcon.spriteName = "No";
				this.CorpseDisposed = false;
			}
			if (this.BodyParts == 0)
			{
				if (!this.PartsDisposed)
				{
					this.PartsIcon.spriteName = "Yes";
					this.PartsDisposed = true;
				}
			}
			else if (this.PartsDisposed)
			{
				this.PartsIcon.spriteName = "No";
				this.PartsDisposed = false;
			}
			if (this.Yandere.Sanity == 100f)
			{
				if (!this.SanityRestored)
				{
					this.SanityIcon.spriteName = "Yes";
					this.SanityRestored = true;
				}
			}
			else if (this.SanityRestored)
			{
				this.SanityIcon.spriteName = "No";
				this.SanityRestored = false;
			}
			if (!this.Clock.StopTime)
			{
				this.Timer = Mathf.MoveTowards(this.Timer, 0f, Time.deltaTime);
			}
			if (this.Timer <= 0f)
			{
				this.Timer = 0f;
				if (!this.Yandere.Attacking && !this.Yandere.Struggling && !this.Yandere.Egg && !this.FadeOut)
				{
					this.BeginFadingOut();
				}
			}
			int num = Mathf.CeilToInt(this.Timer);
			this.Minutes = num / 60;
			this.Seconds = num % 60;
			this.TimeLabel.text = string.Format("{0:00}:{1:00}", this.Minutes, this.Seconds);
			if (this.Yandere.NotificationManager.NotificationParent.localPosition.x == 0f)
			{
				this.Yandere.NotificationManager.NotificationParent.localPosition = new Vector3(0.15f, this.Yandere.NotificationManager.NotificationParent.localPosition.y, this.Yandere.NotificationManager.NotificationParent.localPosition.z);
			}
		}
		else if (this.Deaths > 86 && !this.Invalid && !this.Yandere.Egg && this.Clock.Weekday == 1 && this.StudentManager.Students[1].gameObject.activeInHierarchy && !this.StudentManager.Students[1].Fleeing)
		{
			this.GenocideEnding = true;
			this.BeginFadingOut();
		}
		if (this.FadeOut)
		{
			if (this.Yandere.Laughing)
			{
				this.Yandere.StopLaughing();
			}
			if (this.Clock.TimeSkip || this.Yandere.CanMove)
			{
				if (this.Clock.TimeSkip)
				{
					this.Clock.EndTimeSkip();
				}
				this.Yandere.StopAiming();
				this.Yandere.CanMove = false;
				this.Yandere.YandereVision = false;
				this.Yandere.PauseScreen.enabled = false;
				this.Yandere.CharacterAnimation.CrossFade("f02_idleShort_00");
				if (this.Yandere.Mask != null)
				{
					this.Yandere.Mask.Drop();
				}
				if (this.Yandere.PickUp != null)
				{
					this.Yandere.EmptyHands();
				}
				if (this.Yandere.Dragging || this.Yandere.Carrying)
				{
					this.Yandere.EmptyHands();
				}
			}
			this.PauseScreen.Panel.alpha = Mathf.MoveTowards(this.PauseScreen.Panel.alpha, 0f, Time.deltaTime);
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
			if (this.Darkness.color.a >= 1f && !this.ShowResults)
			{
				this.HeartbeatCamera.SetActive(false);
				this.DetectionCamera.SetActive(false);
				if (this.ClubActivity)
				{
					this.ClubManager.Club = this.Yandere.Club;
					this.ClubManager.ClubActivity();
					this.FadeOut = false;
				}
				else
				{
					this.Yandere.MyController.enabled = false;
					this.Yandere.enabled = false;
					this.DetermineResults();
					this.ShowResults = true;
					Time.timeScale = 2f;
					this.Jukebox.Volume = 0f;
				}
				if (this.GenocideEnding)
				{
					SceneManager.LoadScene("GenocideScene");
				}
			}
		}
		if (this.ShowResults)
		{
			this.ResultsTimer += Time.deltaTime;
			if (this.ResultsTimer > 1f)
			{
				UILabel uilabel = this.ResultsLabels[0];
				uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, uilabel.color.a + Time.deltaTime);
			}
			if (this.ResultsTimer > 2f)
			{
				UILabel uilabel2 = this.ResultsLabels[1];
				uilabel2.color = new Color(uilabel2.color.r, uilabel2.color.g, uilabel2.color.b, uilabel2.color.a + Time.deltaTime);
			}
			if (this.ResultsTimer > 3f)
			{
				UILabel uilabel3 = this.ResultsLabels[2];
				uilabel3.color = new Color(uilabel3.color.r, uilabel3.color.g, uilabel3.color.b, uilabel3.color.a + Time.deltaTime);
			}
			if (this.ResultsTimer > 4f)
			{
				UILabel uilabel4 = this.ResultsLabels[3];
				uilabel4.color = new Color(uilabel4.color.r, uilabel4.color.g, uilabel4.color.b, uilabel4.color.a + Time.deltaTime);
			}
			if (this.ResultsTimer > 5f)
			{
				UILabel uilabel5 = this.ResultsLabels[4];
				uilabel5.color = new Color(uilabel5.color.r, uilabel5.color.g, uilabel5.color.b, uilabel5.color.a + Time.deltaTime);
			}
			if (this.ResultsTimer > 6f)
			{
				this.ContinueButton.color = new Color(this.ContinueButton.color.r, this.ContinueButton.color.g, this.ContinueButton.color.b, this.ContinueButton.color.a + Time.deltaTime);
				this.ContinueLabel.color = new Color(this.ContinueLabel.color.r, this.ContinueLabel.color.g, this.ContinueLabel.color.b, this.ContinueLabel.color.a + Time.deltaTime);
				if (this.ContinueButton.color.a > 1f)
				{
					this.ContinueButton.color = new Color(this.ContinueButton.color.r, this.ContinueButton.color.g, this.ContinueButton.color.b, 1f);
				}
				if (this.ContinueLabel.color.a > 1f)
				{
					this.ContinueLabel.color = new Color(this.ContinueLabel.color.r, this.ContinueLabel.color.g, this.ContinueLabel.color.b, 1f);
				}
			}
			if (Input.GetKeyDown("space"))
			{
				this.ShowResults = false;
				this.FadeResults = true;
				this.FadeOut = false;
				this.ResultsTimer = 0f;
			}
			if (this.ResultsTimer > 7f && Input.GetButtonDown("A"))
			{
				this.ShowResults = false;
				this.FadeResults = true;
				this.FadeOut = false;
				this.ResultsTimer = 0f;
			}
		}
		foreach (UILabel uilabel6 in this.ResultsLabels)
		{
			if (uilabel6.color.a > 1f)
			{
				uilabel6.color = new Color(uilabel6.color.r, uilabel6.color.g, uilabel6.color.b, 1f);
			}
		}
		if (this.FadeResults)
		{
			foreach (UILabel uilabel7 in this.ResultsLabels)
			{
				uilabel7.color = new Color(uilabel7.color.r, uilabel7.color.g, uilabel7.color.b, uilabel7.color.a - Time.deltaTime);
			}
			this.ContinueButton.color = new Color(this.ContinueButton.color.r, this.ContinueButton.color.g, this.ContinueButton.color.b, this.ContinueButton.color.a - Time.deltaTime);
			this.ContinueLabel.color = new Color(this.ContinueLabel.color.r, this.ContinueLabel.color.g, this.ContinueLabel.color.b, this.ContinueLabel.color.a - Time.deltaTime);
			if (this.ResultsLabels[0].color.a <= 0f)
			{
				if (this.BeginConfession)
				{
					this.LoveManager.Suitor = this.StudentManager.Students[1];
					this.LoveManager.Rival = this.StudentManager.Students[this.StudentManager.RivalID];
					this.LoveManager.Suitor.CharacterAnimation.enabled = true;
					this.LoveManager.Rival.CharacterAnimation.enabled = true;
					this.LoveManager.BeginConfession();
					Time.timeScale = 1f;
					base.enabled = false;
					return;
				}
				if (this.GameOver)
				{
					this.Heartbroken.transform.parent.transform.parent = null;
					this.Heartbroken.transform.parent.gameObject.SetActive(true);
					this.Heartbroken.Noticed = false;
					base.transform.parent.transform.parent.gameObject.SetActive(false);
					if (!this.EndOfDay.gameObject.activeInHierarchy)
					{
						Time.timeScale = 1f;
						return;
					}
				}
				else
				{
					if (this.LowRep)
					{
						this.Yandere.RPGCamera.enabled = false;
						this.Yandere.RPGCamera.transform.parent = this.LowRepGameOver.MyCamera;
						this.Yandere.RPGCamera.transform.localPosition = new Vector3(0f, 0f, 0f);
						this.Yandere.RPGCamera.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
						this.LowRepGameOver.gameObject.SetActive(true);
						this.UICamera.SetActive(false);
						this.FPS.SetActive(false);
						Time.timeScale = 1f;
						base.enabled = false;
						return;
					}
					if (!this.TeacherReport)
					{
						if (this.EndOfDay.Phase == 1)
						{
							this.EndOfDay.gameObject.SetActive(true);
							this.EndOfDay.enabled = true;
							this.EndOfDay.Phase = 14;
							if (this.EndOfDay.PreviouslyActivated)
							{
								this.EndOfDay.Start();
							}
							for (int j = 0; j < 5; j++)
							{
								this.ResultsLabels[j].text = string.Empty;
							}
							base.enabled = false;
							return;
						}
					}
					else
					{
						this.DetermineResults();
						this.TeacherReport = false;
						this.FadeResults = false;
						this.ShowResults = true;
					}
				}
			}
		}
	}

	// Token: 0x06001AE7 RID: 6887 RVA: 0x0012572C File Offset: 0x0012392C
	private void DetermineResults()
	{
		if (this.Yandere.VtuberID > 0)
		{
			this.Protagonist = this.VtuberNames[this.Yandere.VtuberID];
		}
		this.ResultsLabels[0].transform.parent.gameObject.SetActive(true);
		if (this.Show)
		{
			this.EndOfDay.gameObject.SetActive(true);
			this.EndOfDay.enabled = true;
			base.enabled = false;
			if (this.EndOfDay.PreviouslyActivated)
			{
				this.EndOfDay.Start();
			}
			for (int i = 0; i < 5; i++)
			{
				this.ResultsLabels[i].text = string.Empty;
			}
			return;
		}
		if (this.Yandere.ShoulderCamera.GoingToCounselor)
		{
			this.ResultsLabels[0].text = "While " + this.Protagonist + " was in the counselor's office,";
			this.ResultsLabels[1].text = "a corpse was discovered on school grounds.";
			this.ResultsLabels[2].text = "The school faculty was informed of the corpse,";
			this.ResultsLabels[3].text = "and the police were called to the school.";
			this.ResultsLabels[4].text = "No one is allowed to leave school until a police investigation has taken place.";
			this.TeacherReport = true;
			this.Show = true;
			return;
		}
		if (this.Reputation.Reputation <= -100f)
		{
			this.ResultsLabels[0].text = this.Protagonist + "'s bizarre conduct has been observed and discussed by many people.";
			this.ResultsLabels[1].text = "Word of " + this.Protagonist + "'s strange behavior has reached Senpai.";
			this.ResultsLabels[2].text = "Senpai is now aware that " + this.Protagonist + " is a deranged person.";
			this.ResultsLabels[3].text = "From this day forward, Senpai will fear and avoid " + this.Protagonist + ".";
			this.ResultsLabels[4].text = this.Protagonist + " will never have her Senpai's love.";
			this.LowRep = true;
			return;
		}
		if (!this.Suicide && !this.PoisonScene)
		{
			if (this.Clock.HourTime < 18f)
			{
				if (this.Yandere.InClass)
				{
					if (this.SkippingPastPoison)
					{
						this.ResultsLabels[0].text = "A student has died from eating poisoned food.";
					}
					else
					{
						this.ResultsLabels[0].text = this.Protagonist + " attempts to attend class without disposing of a corpse.";
					}
				}
				else if (this.Yandere.Resting && this.Corpses > 0)
				{
					this.ResultsLabels[0].text = this.Protagonist + " rests without disposing of a corpse.";
				}
				else if (this.Yandere.Resting)
				{
					if (GameGlobals.SenpaiMourning)
					{
						this.ResultsLabels[0].text = this.Protagonist + " recovers from her injuries, and is ready to leave school.";
					}
					else
					{
						this.ResultsLabels[0].text = this.Protagonist + " recovers from her injuries, and is ready to leave school.";
					}
				}
				else if (GameGlobals.SenpaiMourning)
				{
					this.ResultsLabels[0].text = this.Protagonist + " is ready to leave school.";
				}
				else
				{
					this.ResultsLabels[0].text = this.Protagonist + " is ready to leave school.";
				}
			}
			else
			{
				this.ResultsLabels[0].text = "The school day has ended. Faculty members must walk through the school and tell any lingering students to leave.";
			}
			if (this.Suspended)
			{
				this.Yandere.Class.Portal.EndFinalEvents();
				if (this.Clock.Weekday == 1)
				{
					this.RemainingDays = 5;
				}
				else if (this.Clock.Weekday == 2)
				{
					this.RemainingDays = 4;
				}
				else if (this.Clock.Weekday == 3)
				{
					this.RemainingDays = 3;
				}
				else if (this.Clock.Weekday == 4)
				{
					this.RemainingDays = 2;
				}
				else if (this.Clock.Weekday == 5)
				{
					this.RemainingDays = 1;
				}
				if (this.EndOfDay.Counselor.CounselorPunishments > 5)
				{
					this.ResultsLabels[0].text = this.Protagonist + " is no longer allowed";
					this.ResultsLabels[1].text = "to attend Akademi.";
					this.ResultsLabels[2].text = "This means that she will";
					this.ResultsLabels[3].text = "never be able to confess";
					this.ResultsLabels[4].text = "her love to her Senpai.";
					this.GameOver = true;
					return;
				}
				if (this.RemainingDays - this.SuspensionLength <= 0 && !this.StudentManager.RivalEliminated)
				{
					this.ResultsLabels[0].text = "Due to her suspension,";
					this.ResultsLabels[1].text = this.Protagonist + " will be unable";
					this.ResultsLabels[2].text = "to prevent her rival";
					this.ResultsLabels[3].text = "from confessing to Senpai.";
					this.ResultsLabels[4].text = this.Protagonist + " will never have Senpai.";
					this.GameOver = true;
					return;
				}
				if (this.SuspensionLength == 1)
				{
					this.ResultsLabels[0].text = this.Protagonist + " has been sent home early.";
					this.ResultsLabels[1].text = "";
					this.ResultsLabels[2].text = "She won't be able to see Senpai again until tomorrow.";
					this.ResultsLabels[3].text = "";
					this.ResultsLabels[4].text = this.Protagonist + "'s heart aches as she thinks of Senpai.";
					return;
				}
				this.ResultsLabels[0].text = this.Protagonist + " has been sent home early.";
				this.ResultsLabels[1].text = "";
				this.ResultsLabels[2].text = "She will have to wait " + this.SuspensionLength.ToString() + " days before returning to school.";
				this.ResultsLabels[3].text = "";
				this.ResultsLabels[4].text = this.Protagonist + "'s heart aches as she thinks of Senpai.";
				return;
			}
			else
			{
				this.BloodyClothing -= this.RedPaintClothing;
				if (this.Corpses == 0 && this.LimbParent.childCount == 0 && this.BloodParent.childCount == 0 && this.BloodyWeapons == 0 && this.BloodyClothing == 0 && !this.SuicideScene)
				{
					if (this.Yandere.Sanity < 66.66666f || (this.Yandere.Bloodiness > 0f && !this.Yandere.RedPaint))
					{
						this.ResultsLabels[1].text = this.Protagonist + " is approached by a faculty member.";
						if (this.Yandere.Bloodiness > 0f)
						{
							this.ResultsLabels[2].text = "The faculty member immediately notices the blood staining her clothing.";
							this.ResultsLabels[3].text = this.Protagonist + " is not able to convince the faculty member that nothing is wrong.";
							this.ResultsLabels[4].text = "The faculty member calls the police.";
							this.TeacherReport = true;
							this.Show = true;
							return;
						}
						this.ResultsLabels[2].text = this.Protagonist + " exhibited extremely erratic behavior, frightening the faculty member.";
						this.ResultsLabels[3].text = string.Concat(new string[]
						{
							"The faculty member becomes angry with ",
							this.Protagonist,
							", but ",
							this.Protagonist,
							" leaves before the situation gets worse."
						});
						this.ResultsLabels[4].text = this.Protagonist + " returns home.";
						return;
					}
					else
					{
						if (this.Yandere.Inventory.Ring || (this.Yandere.Inventory.RivalPhone && this.StudentManager.CommunalLocker.RivalPhone.StudentID == this.StudentManager.RivalID && !this.StudentManager.RivalEliminated) || (this.Yandere.Inventory.RivalPhone && this.StudentManager.CommunalLocker.RivalPhone.StudentID != this.StudentManager.RivalID && this.StudentManager.Students[this.StudentManager.CommunalLocker.RivalPhone.StudentID].Alive))
						{
							if (this.Yandere.Inventory.Ring)
							{
								this.ResultsLabels[1].text = "A student tells the faculty that her ring is missing.";
								this.ResultsLabels[2].text = "Suspecting theft, the faculty check all students' belongings before they are allowed to leave school.";
								this.ResultsLabels[3].text = "The stolen ring is found on " + this.Protagonist + "'s person.";
								this.ResultsLabels[4].text = this.Protagonist + " is expelled from school for stealing from another student.";
							}
							else if (this.StudentManager.CommunalLocker.RivalPhone.StudentID == this.StudentManager.RivalID)
							{
								this.ResultsLabels[1].text = "Osana tells the faculty that her phone is missing.";
								this.ResultsLabels[2].text = "Suspecting theft, the faculty check all students' belongings before they are allowed to leave school.";
								this.ResultsLabels[3].text = "Osana's stolen phone is found on " + this.Protagonist + "'s person.";
								this.ResultsLabels[4].text = this.Protagonist + " is expelled from school for stealing from another student.";
							}
							else
							{
								this.ResultsLabels[1].text = "A student tells the faculty that her phone is missing.";
								this.ResultsLabels[2].text = "Suspecting theft, the faculty check all students' belongings before they are allowed to leave school.";
								this.ResultsLabels[3].text = "The student's stolen phone is found on " + this.Protagonist + "'s person.";
								this.ResultsLabels[4].text = this.Protagonist + " is expelled from school for stealing from another student.";
							}
							this.GameOver = true;
							this.Heartbroken.Counselor.Expelled = true;
							return;
						}
						if (DateGlobals.Weekday == DayOfWeek.Friday)
						{
							if (this.StudentManager.RivalEliminated || this.StudentManager.SabotageProgress == 5 || this.StudentManager.LoveManager.ConfessToSuitor)
							{
								if (!this.StudentManager.RivalEliminated)
								{
									if (this.StudentManager.LoveManager.ConfessToSuitor)
									{
										this.StudentManager.RivalEliminated = true;
										this.EndOfDay.RivalEliminationMethod = RivalEliminationType.Matchmade;
									}
									else if (this.StudentManager.SabotageProgress == 5)
									{
										this.StudentManager.RivalEliminated = true;
										this.EndOfDay.RivalEliminationMethod = RivalEliminationType.Rejected;
									}
								}
								this.ResultsLabels[0].text = this.Protagonist + "'s rival is no longer a threat.";
								this.ResultsLabels[1].text = this.Protagonist + " considers confessing her love to Senpai...";
								this.ResultsLabels[2].text = "...but she cannot build up the courage to speak to him.";
								this.ResultsLabels[3].text = this.Protagonist + " follows Senpai out of school and watches him from a distance until he has returned to his home.";
								this.ResultsLabels[4].text = "Then, " + this.Protagonist + " returns to her own home, and considers what she should do next...";
								return;
							}
							this.ResultsLabels[0].text = "It is 6:00 PM on Friday.";
							this.ResultsLabels[1].text = this.Protagonist + "'s rival asks Senpai to meet her under the cherry tree behind the school.";
							this.ResultsLabels[2].text = "As cherry blossoms fall around them...";
							this.ResultsLabels[3].text = "...she confesses her feelings for Senpai.";
							this.ResultsLabels[4].text = this.Protagonist + " watches from a short distance away...";
							this.BeginConfession = true;
							return;
						}
						else
						{
							if (this.Clock.HourTime < 18f)
							{
								if (this.Yandere.Senpai.position.z > -75f)
								{
									this.ResultsLabels[1].text = "However, she can't bring herself to leave before Senpai does.";
									this.ResultsLabels[2].text = this.Protagonist + " waits at the school's entrance until Senpai eventually appears.";
									this.ResultsLabels[3].text = "She follows him and watches him from a distance until he has returned to his home.";
									this.ResultsLabels[4].text = "Then, " + this.Protagonist + " returns to her house.";
								}
								else
								{
									this.ResultsLabels[1].text = this.Protagonist + " quickly runs out of school, determined to catch a glimpse of Senpai as he walks home.";
									this.ResultsLabels[2].text = "Eventually, she catches up to him.";
									this.ResultsLabels[3].text = this.Protagonist + " follows Senpai and watches him from a distance until he has returned to his home.";
									this.ResultsLabels[4].text = "Then, " + this.Protagonist + " returns to her house.";
								}
							}
							else
							{
								this.ResultsLabels[1].text = "Like all other students, " + this.Protagonist + " is instructed to leave school.";
								this.ResultsLabels[2].text = "After exiting school, " + this.Protagonist + " locates Senpai.";
								this.ResultsLabels[3].text = this.Protagonist + " follows Senpai and watches him from a distance until he has returned to his home.";
								this.ResultsLabels[4].text = "Then, " + this.Protagonist + " returns to her house.";
							}
							if (GameGlobals.SenpaiMourning)
							{
								this.ResultsLabels[1].text = "Like all other students, " + this.Protagonist + " is instructed to leave school.";
								this.ResultsLabels[2].text = this.Protagonist + " leaves school.";
								this.ResultsLabels[3].text = this.Protagonist + " returns to her home.";
								this.ResultsLabels[4].text = "Her heart aches as she thinks of Senpai.";
								return;
							}
						}
					}
				}
				else
				{
					if (this.Corpses > 0)
					{
						this.ResultsLabels[1].text = "While walking around the school, a faculty member discovers a corpse.";
						this.ResultsLabels[2].text = "The faculty member immediately calls the police.";
						this.ResultsLabels[3].text = "The faculty member informs the rest of the faculty about her discovery.";
						this.ResultsLabels[4].text = "The faculty do not allow any students to leave the school until a police investigation has taken place.";
						this.TeacherReport = true;
						this.Show = true;
					}
					else if (this.LimbParent.childCount > 0)
					{
						this.ResultsLabels[1].text = "While walking around the school, a faculty member discovers a dismembered body part.";
						this.ResultsLabels[2].text = "The faculty member decides to call the police.";
						this.ResultsLabels[3].text = "The faculty member informs the rest of the faculty about her discovery.";
						this.ResultsLabels[4].text = "The faculty do not allow any students to leave the school until a police investigation has taken place.";
						this.TeacherReport = true;
						this.Show = true;
					}
					else if (this.BloodParent.childCount > 0 || this.BloodyClothing > 0)
					{
						this.ResultsLabels[1].text = "While walking around the school, a faculty member discovers a mysterious blood stain.";
						this.ResultsLabels[2].text = "The faculty member decides to call the police.";
						this.ResultsLabels[3].text = "The faculty member informs the rest of the faculty about her discovery.";
						this.ResultsLabels[4].text = "The faculty do not allow any students to leave the school until a police investigation has taken place.";
						this.TeacherReport = true;
						this.Show = true;
					}
					else if (this.BloodyWeapons > 0)
					{
						this.ResultsLabels[1].text = "While walking around the school, a faculty member discovers a mysterious bloody weapon.";
						this.ResultsLabels[2].text = "The faculty member decides to call the police.";
						this.ResultsLabels[3].text = "The faculty member informs the rest of the faculty about her discovery.";
						this.ResultsLabels[4].text = "The faculty do not allow any students to leave the school until a police investigation has taken place.";
						this.TeacherReport = true;
						this.Show = true;
					}
					else if (this.SuicideScene)
					{
						this.ResultsLabels[1].text = "While walking around the school, a faculty member discovers a pair of shoes on the rooftop.";
						this.ResultsLabels[2].text = "The faculty member fears that there has been a suicide, but cannot find a corpse anywhere. The faculty member does not take any action.";
						this.ResultsLabels[3].text = this.Protagonist + " leaves school and follows Senpai, watching him as he walks home.";
						this.ResultsLabels[4].text = "Once he is safely home, " + this.Protagonist + " returns to her own home.";
						if (GameGlobals.SenpaiMourning)
						{
							this.ResultsLabels[3].text = this.Protagonist + " leaves school.";
							this.ResultsLabels[4].text = this.Protagonist + " returns home.";
						}
					}
					if (this.SelfReported)
					{
						this.ResultsLabels[0].text = this.Protagonist + " informs a faculty member that something alarming is present at school.";
						this.ResultsLabels[1].text = "The faculty member confirms that " + this.Protagonist + " is telling the truth.";
						return;
					}
				}
			}
		}
		else
		{
			if (this.Suicide)
			{
				if (!this.Yandere.InClass)
				{
					this.ResultsLabels[0].text = "The school day has ended. Faculty members must walk through the school and tell any lingering students to leave.";
				}
				else if (this.Corpses > 0)
				{
					this.ResultsLabels[0].text = this.Protagonist + " attempts to attend class without disposing of a corpse.";
				}
				else
				{
					this.ResultsLabels[0].text = this.Protagonist + " attempts to attend class without cleaning up some blood.";
				}
				this.ResultsLabels[1].text = "While walking around the school, a faculty member discovers a corpse.";
				if (this.SuicideNote)
				{
					this.ResultsLabels[2].text = "It appears as though a student has committed suicide.";
				}
				else
				{
					this.ResultsLabels[2].text = "It appears as though a student has fallen from the school rooftop.";
				}
				this.ResultsLabels[3].text = "The faculty member informs the rest of the faculty about her discovery.";
				this.ResultsLabels[4].text = "The faculty members agree to call the police and report the student's death.";
				this.TeacherReport = true;
				this.Show = true;
				return;
			}
			if (this.PoisonScene)
			{
				this.ResultsLabels[0].text = "A faculty member discovers the student who " + this.Protagonist + " poisoned.";
				this.ResultsLabels[1].text = "The faculty member calls for an ambulance immediately.";
				this.ResultsLabels[2].text = "The faculty member suspects that the student's death was a murder.";
				this.ResultsLabels[3].text = "The faculty member also calls for the police.";
				this.ResultsLabels[4].text = "The school's students are not allowed to leave until a police investigation has taken place.";
				this.TeacherReport = true;
				this.Show = true;
			}
		}
	}

	// Token: 0x06001AE8 RID: 6888 RVA: 0x0012689C File Offset: 0x00124A9C
	public void KillStudents()
	{
		Debug.Log("KillStudents() is being called.");
		for (int i = 1; i < 101; i++)
		{
			if (!StudentGlobals.GetStudentDead(i) && this.StudentManager.StudentReps[i] < -150f)
			{
				this.Deaths++;
				StudentGlobals.SetStudentDead(i, true);
				Debug.Log("Student #" + i.ToString() + " committed suicide due to low reputation. They will have a memorial at school tomorrow.");
				if (StudentGlobals.MemorialStudents < 9)
				{
					StudentGlobals.MemorialStudents++;
					if (StudentGlobals.MemorialStudents == 1)
					{
						StudentGlobals.MemorialStudent1 = i;
					}
					else if (StudentGlobals.MemorialStudents == 2)
					{
						StudentGlobals.MemorialStudent2 = i;
					}
					else if (StudentGlobals.MemorialStudents == 3)
					{
						StudentGlobals.MemorialStudent3 = i;
					}
					else if (StudentGlobals.MemorialStudents == 4)
					{
						StudentGlobals.MemorialStudent4 = i;
					}
					else if (StudentGlobals.MemorialStudents == 5)
					{
						StudentGlobals.MemorialStudent5 = i;
					}
					else if (StudentGlobals.MemorialStudents == 6)
					{
						StudentGlobals.MemorialStudent6 = i;
					}
					else if (StudentGlobals.MemorialStudents == 7)
					{
						StudentGlobals.MemorialStudent7 = i;
					}
					else if (StudentGlobals.MemorialStudents == 8)
					{
						StudentGlobals.MemorialStudent8 = i;
					}
					else if (StudentGlobals.MemorialStudents == 9)
					{
						StudentGlobals.MemorialStudent9 = i;
					}
				}
			}
		}
		if (this.Deaths > 0)
		{
			PlayerGlobals.Kills += this.Deaths;
			Debug.Log("There were deaths at school today. As a result, PlayerGlobals.Kills is being incremented.");
			for (int j = 2; j < this.StudentManager.NPCsTotal + 1; j++)
			{
				if (StudentGlobals.GetStudentDying(j) || (this.StudentManager.Students[j] != null && !this.StudentManager.Students[j].Alive))
				{
					Debug.Log("Subtracting 10% school atmosphere because someone died.");
					SchoolGlobals.SchoolAtmosphere -= 0.1f;
					if (this.JSON.Students[j].Club == ClubType.Council)
					{
						SchoolGlobals.SchoolAtmosphere -= 1f;
						SchoolGlobals.HighSecurity = true;
					}
					StudentGlobals.SetStudentDead(j, true);
					if (j > 10 && j < DateGlobals.Week + 10 && this.StudentManager.Students[j] != null && this.StudentManager.Students[j].Ragdoll.Disposed)
					{
						Debug.Log("The player killed a previous rival and disposed of her corpse.");
						this.EndOfDay.SetFormerRivalDeath(j - 10, this.StudentManager.Students[j]);
						GameGlobals.SetRivalEliminations(j - 10, 11);
					}
				}
			}
			SchoolGlobals.SchoolAtmosphere -= (float)this.Corpses * 0.1f;
			if (this.DrownVictims + this.Corpses > 0)
			{
				foreach (RagdollScript ragdollScript in this.CorpseList)
				{
					if (ragdollScript != null && !ragdollScript.Disposed && StudentGlobals.MemorialStudents < 9)
					{
						StudentGlobals.MemorialStudents++;
						if (StudentGlobals.MemorialStudents == 1)
						{
							StudentGlobals.MemorialStudent1 = ragdollScript.Student.StudentID;
						}
						else if (StudentGlobals.MemorialStudents == 2)
						{
							StudentGlobals.MemorialStudent2 = ragdollScript.Student.StudentID;
						}
						else if (StudentGlobals.MemorialStudents == 3)
						{
							StudentGlobals.MemorialStudent3 = ragdollScript.Student.StudentID;
						}
						else if (StudentGlobals.MemorialStudents == 4)
						{
							StudentGlobals.MemorialStudent4 = ragdollScript.Student.StudentID;
						}
						else if (StudentGlobals.MemorialStudents == 5)
						{
							StudentGlobals.MemorialStudent5 = ragdollScript.Student.StudentID;
						}
						else if (StudentGlobals.MemorialStudents == 6)
						{
							StudentGlobals.MemorialStudent6 = ragdollScript.Student.StudentID;
						}
						else if (StudentGlobals.MemorialStudents == 7)
						{
							StudentGlobals.MemorialStudent7 = ragdollScript.Student.StudentID;
						}
						else if (StudentGlobals.MemorialStudents == 8)
						{
							StudentGlobals.MemorialStudent8 = ragdollScript.Student.StudentID;
						}
						else if (StudentGlobals.MemorialStudents == 9)
						{
							StudentGlobals.MemorialStudent9 = ragdollScript.Student.StudentID;
						}
					}
				}
			}
		}
		SchoolGlobals.SchoolAtmosphere = Mathf.Clamp01(SchoolGlobals.SchoolAtmosphere);
		for (int l = 1; l < this.StudentManager.StudentsTotal; l++)
		{
			StudentScript studentScript = this.StudentManager.Students[l];
			if (studentScript != null && studentScript.Grudge && studentScript.Persona != PersonaType.Evil)
			{
				StudentGlobals.SetStudentGrudge(l, true);
				if (studentScript.OriginalPersona == PersonaType.Sleuth && !StudentGlobals.GetStudentDying(l))
				{
					StudentGlobals.SetStudentGrudge(56, true);
					StudentGlobals.SetStudentGrudge(57, true);
					StudentGlobals.SetStudentGrudge(58, true);
					StudentGlobals.SetStudentGrudge(59, true);
					StudentGlobals.SetStudentGrudge(60, true);
				}
			}
		}
	}

	// Token: 0x06001AE9 RID: 6889 RVA: 0x00126D10 File Offset: 0x00124F10
	public void BeginFadingOut()
	{
		this.DayOver = true;
		this.StudentManager.StopMoving();
		this.Darkness.enabled = true;
		this.Yandere.StopLaughing();
		this.Clock.StopTime = true;
		this.FadeOut = true;
		if (!this.EndOfDay.gameObject.activeInHierarchy)
		{
			Time.timeScale = 1f;
		}
	}

	// Token: 0x06001AEA RID: 6890 RVA: 0x00126D78 File Offset: 0x00124F78
	public void UpdateCorpses()
	{
		foreach (RagdollScript ragdollScript in this.CorpseList)
		{
			if (ragdollScript != null)
			{
				ragdollScript.Prompt.HideButton[3] = true;
				if (this.Yandere.Class.PhysicalGrade + this.Yandere.Class.PhysicalBonus > 0 && !ragdollScript.Tranquil)
				{
					ragdollScript.Prompt.HideButton[3] = false;
				}
			}
		}
	}

	// Token: 0x04002D04 RID: 11524
	public LowRepGameOverScript LowRepGameOver;

	// Token: 0x04002D05 RID: 11525
	public StudentManagerScript StudentManager;

	// Token: 0x04002D06 RID: 11526
	public ClubManagerScript ClubManager;

	// Token: 0x04002D07 RID: 11527
	public HeartbrokenScript Heartbroken;

	// Token: 0x04002D08 RID: 11528
	public LoveManagerScript LoveManager;

	// Token: 0x04002D09 RID: 11529
	public PauseScreenScript PauseScreen;

	// Token: 0x04002D0A RID: 11530
	public ReputationScript Reputation;

	// Token: 0x04002D0B RID: 11531
	public TranqCaseScript TranqCase;

	// Token: 0x04002D0C RID: 11532
	public EndOfDayScript EndOfDay;

	// Token: 0x04002D0D RID: 11533
	public JukeboxScript Jukebox;

	// Token: 0x04002D0E RID: 11534
	public YandereScript Yandere;

	// Token: 0x04002D0F RID: 11535
	public ClockScript Clock;

	// Token: 0x04002D10 RID: 11536
	public JsonScript JSON;

	// Token: 0x04002D11 RID: 11537
	public UIPanel Panel;

	// Token: 0x04002D12 RID: 11538
	public GameObject HeartbeatCamera;

	// Token: 0x04002D13 RID: 11539
	public GameObject DetectionCamera;

	// Token: 0x04002D14 RID: 11540
	public GameObject SuicideStudent;

	// Token: 0x04002D15 RID: 11541
	public GameObject UICamera;

	// Token: 0x04002D16 RID: 11542
	public GameObject Icons;

	// Token: 0x04002D17 RID: 11543
	public GameObject FPS;

	// Token: 0x04002D18 RID: 11544
	public Transform GarbageParent;

	// Token: 0x04002D19 RID: 11545
	public Transform BloodParent;

	// Token: 0x04002D1A RID: 11546
	public Transform LimbParent;

	// Token: 0x04002D1B RID: 11547
	public RagdollScript[] CorpseList;

	// Token: 0x04002D1C RID: 11548
	public UILabel[] ResultsLabels;

	// Token: 0x04002D1D RID: 11549
	public UILabel ContinueLabel;

	// Token: 0x04002D1E RID: 11550
	public UILabel TimeLabel;

	// Token: 0x04002D1F RID: 11551
	public UISprite ContinueButton;

	// Token: 0x04002D20 RID: 11552
	public UISprite Darkness;

	// Token: 0x04002D21 RID: 11553
	public UISprite BloodIcon;

	// Token: 0x04002D22 RID: 11554
	public UISprite UniformIcon;

	// Token: 0x04002D23 RID: 11555
	public UISprite WeaponIcon;

	// Token: 0x04002D24 RID: 11556
	public UISprite CorpseIcon;

	// Token: 0x04002D25 RID: 11557
	public UISprite PartsIcon;

	// Token: 0x04002D26 RID: 11558
	public UISprite SanityIcon;

	// Token: 0x04002D27 RID: 11559
	public string ElectrocutedStudentName = string.Empty;

	// Token: 0x04002D28 RID: 11560
	public string DrownedStudentName = string.Empty;

	// Token: 0x04002D29 RID: 11561
	public bool BloodDisposed;

	// Token: 0x04002D2A RID: 11562
	public bool UniformDisposed;

	// Token: 0x04002D2B RID: 11563
	public bool WeaponDisposed;

	// Token: 0x04002D2C RID: 11564
	public bool CorpseDisposed;

	// Token: 0x04002D2D RID: 11565
	public bool PartsDisposed;

	// Token: 0x04002D2E RID: 11566
	public bool SanityRestored;

	// Token: 0x04002D2F RID: 11567
	public bool MurderSuicideScene;

	// Token: 0x04002D30 RID: 11568
	public bool ElectroScene;

	// Token: 0x04002D31 RID: 11569
	public bool SuicideScene;

	// Token: 0x04002D32 RID: 11570
	public bool PoisonScene;

	// Token: 0x04002D33 RID: 11571
	public bool MurderScene;

	// Token: 0x04002D34 RID: 11572
	public bool SkippingPastPoison;

	// Token: 0x04002D35 RID: 11573
	public bool StudentFoundCorpse;

	// Token: 0x04002D36 RID: 11574
	public bool BeginConfession;

	// Token: 0x04002D37 RID: 11575
	public bool GenocideEnding;

	// Token: 0x04002D38 RID: 11576
	public bool TeacherReport;

	// Token: 0x04002D39 RID: 11577
	public bool ClubActivity;

	// Token: 0x04002D3A RID: 11578
	public bool CouncilDeath;

	// Token: 0x04002D3B RID: 11579
	public bool MaskReported;

	// Token: 0x04002D3C RID: 11580
	public bool SelfReported;

	// Token: 0x04002D3D RID: 11581
	public bool FadeResults;

	// Token: 0x04002D3E RID: 11582
	public bool ShowResults;

	// Token: 0x04002D3F RID: 11583
	public bool SuicideNote;

	// Token: 0x04002D40 RID: 11584
	public bool TextUpdated;

	// Token: 0x04002D41 RID: 11585
	public bool GameOver;

	// Token: 0x04002D42 RID: 11586
	public bool DayOver;

	// Token: 0x04002D43 RID: 11587
	public bool Delayed;

	// Token: 0x04002D44 RID: 11588
	public bool FadeOut;

	// Token: 0x04002D45 RID: 11589
	public bool Invalid;

	// Token: 0x04002D46 RID: 11590
	public bool Suicide;

	// Token: 0x04002D47 RID: 11591
	public bool Called;

	// Token: 0x04002D48 RID: 11592
	public bool LowRep;

	// Token: 0x04002D49 RID: 11593
	public bool Show;

	// Token: 0x04002D4A RID: 11594
	public int IncineratedWeapons;

	// Token: 0x04002D4B RID: 11595
	public int RedPaintClothing;

	// Token: 0x04002D4C RID: 11596
	public int SuicideVictims;

	// Token: 0x04002D4D RID: 11597
	public int BloodyClothing;

	// Token: 0x04002D4E RID: 11598
	public int BloodyWeapons;

	// Token: 0x04002D4F RID: 11599
	public int HiddenCorpses;

	// Token: 0x04002D50 RID: 11600
	public int MurderWeapons;

	// Token: 0x04002D51 RID: 11601
	public int PhotoEvidence;

	// Token: 0x04002D52 RID: 11602
	public int DrownVictims;

	// Token: 0x04002D53 RID: 11603
	public int BodyParts;

	// Token: 0x04002D54 RID: 11604
	public int SuicideID;

	// Token: 0x04002D55 RID: 11605
	public int Witnesses;

	// Token: 0x04002D56 RID: 11606
	public int Corpses;

	// Token: 0x04002D57 RID: 11607
	public int Deaths;

	// Token: 0x04002D58 RID: 11608
	public int Frame;

	// Token: 0x04002D59 RID: 11609
	public float ResultsTimer;

	// Token: 0x04002D5A RID: 11610
	public float Timer;

	// Token: 0x04002D5B RID: 11611
	public float TargetX;

	// Token: 0x04002D5C RID: 11612
	public float TargetY;

	// Token: 0x04002D5D RID: 11613
	public int Minutes;

	// Token: 0x04002D5E RID: 11614
	public int Seconds;

	// Token: 0x04002D5F RID: 11615
	public string Protagonist = "Ayano";

	// Token: 0x04002D60 RID: 11616
	public string[] VtuberNames;

	// Token: 0x04002D61 RID: 11617
	public int SuspensionLength;

	// Token: 0x04002D62 RID: 11618
	public int RemainingDays;

	// Token: 0x04002D63 RID: 11619
	public bool Suspended;
}
