using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004CA RID: 1226
public class WeekSelectScript : MonoBehaviour
{
	// Token: 0x0600201A RID: 8218 RVA: 0x001C9494 File Offset: 0x001C7694
	private void Start()
	{
		base.transform.position = new Vector3(0f, 2.31f, 0f);
		this.EditLabel.gameObject.SetActive(false);
		this.StartLabel.text = "NEXT";
		this.Darkness.alpha = 1f;
		this.UpdateArrow();
		this.UpdateText();
		for (int i = 1; i < 11; i++)
		{
			this.StartingPosition[i] = this.Sleeve[i].position;
		}
		this.DetermineSelectedWeek();
	}

	// Token: 0x0600201B RID: 8219 RVA: 0x001C952C File Offset: 0x001C772C
	private void Update()
	{
		if (this.Fading)
		{
			if (this.FadeID == 1)
			{
				this.Darkness.alpha = Mathf.MoveTowards(this.Darkness.alpha, 0f, Time.deltaTime);
				if (this.Darkness.alpha == 0f)
				{
					this.Fading = false;
					this.FadeID++;
				}
			}
			else
			{
				this.Darkness.alpha = Mathf.MoveTowards(this.Darkness.alpha, 1f, Time.deltaTime);
				if (this.Darkness.alpha == 1f)
				{
					for (int i = 1; i < 11; i++)
					{
						if (GameGlobals.GetSpecificEliminations(i) == 1 || GameGlobals.GetSpecificEliminations(i) == 5 || GameGlobals.GetSpecificEliminations(i) == 6 || GameGlobals.GetSpecificEliminations(i) == 7 || GameGlobals.GetSpecificEliminations(i) == 8 || GameGlobals.GetSpecificEliminations(i) == 10 || GameGlobals.GetSpecificEliminations(i) == 14 || GameGlobals.GetSpecificEliminations(i) == 15 || GameGlobals.GetSpecificEliminations(i) == 16 || GameGlobals.GetSpecificEliminations(i) == 17 || GameGlobals.GetSpecificEliminations(i) == 19 || GameGlobals.GetSpecificEliminations(i) == 20)
						{
							Debug.Log("Rival #" + i.ToString() + " is dead.");
							StudentGlobals.SetStudentDead(i + 10, true);
						}
						else if (GameGlobals.GetSpecificEliminations(i) == 3 || GameGlobals.GetSpecificEliminations(i) == 4)
						{
							StudentGlobals.SetStudentMissing(i + 10, true);
						}
						else if (GameGlobals.GetSpecificEliminations(i) == 9)
						{
							StudentGlobals.SetStudentExpelled(i + 10, true);
						}
						else if (GameGlobals.GetSpecificEliminations(i) == 11)
						{
							StudentGlobals.SetStudentArrested(i + 10, true);
						}
						else if (GameGlobals.GetSpecificEliminations(i) == 12)
						{
							StudentGlobals.SetStudentKidnapped(i + 10, true);
						}
					}
					ClassGlobals.BonusStudyPoints = DateGlobals.Week * 50 - 50;
					GameGlobals.EightiesCutsceneID = DateGlobals.Week;
					DateGlobals.PassDays = 0;
					SceneManager.LoadScene("EightiesCutsceneScene");
				}
			}
		}
		if (this.SettingWeek)
		{
			if (this.InputManager.TappedDown || this.InputManager.TappedUp)
			{
				if (this.Row == 1)
				{
					this.Row = 2;
				}
				else
				{
					this.Row = 1;
				}
				this.DetermineSelectedWeek();
			}
			else if (this.InputManager.TappedRight)
			{
				this.Column++;
				if (this.Column > 5)
				{
					this.Column = 1;
				}
				this.DetermineSelectedWeek();
			}
			else if (this.InputManager.TappedLeft)
			{
				this.Column--;
				if (this.Column < 1)
				{
					this.Column = 5;
				}
				this.DetermineSelectedWeek();
			}
		}
		else if (this.SettingRivals)
		{
			if (this.InputManager.TappedDown)
			{
				if (this.RivalID == 5 || this.RivalID == 10)
				{
					this.SettingRivals = false;
					this.SettingDetails = true;
					if (this.RivalID == 5)
					{
						this.DetailID = 1;
					}
					else
					{
						this.DetailID = 5;
					}
				}
				else
				{
					this.RivalID++;
				}
				this.UpdateArrow();
			}
			else if (this.InputManager.TappedUp)
			{
				if (this.RivalID != 1 && this.RivalID != 6)
				{
					this.RivalID--;
				}
				this.UpdateArrow();
			}
			else if (this.InputManager.TappedRight)
			{
				if (this.RivalID < 6)
				{
					this.RivalID += 5;
				}
				else
				{
					this.RivalID -= 5;
				}
				this.UpdateArrow();
			}
			else if (this.InputManager.TappedLeft)
			{
				if (this.RivalID > 5)
				{
					this.RivalID -= 5;
				}
				else
				{
					this.RivalID += 5;
				}
				this.UpdateArrow();
			}
			else if (Input.GetButtonDown("Y"))
			{
				GameGlobals.SetSpecificEliminations(this.RivalID, GameGlobals.GetSpecificEliminations(this.RivalID) + 1);
				if (GameGlobals.GetSpecificEliminations(this.RivalID) > 20)
				{
					GameGlobals.SetSpecificEliminations(this.RivalID, 1);
				}
				GameGlobals.SetRivalEliminations(this.RivalID, this.Specifics[GameGlobals.GetSpecificEliminations(this.RivalID)]);
				Debug.Log("Rival #" + this.RivalID.ToString() + "'s SpecificElimination is now " + GameGlobals.GetSpecificEliminations(this.RivalID).ToString());
				Debug.Log("Rival #" + this.RivalID.ToString() + "'s Elimination is now " + GameGlobals.GetRivalEliminations(this.RivalID).ToString());
				this.UpdateText();
			}
			else if (Input.GetButtonDown("X"))
			{
				GameGlobals.SetSpecificEliminations(this.RivalID, GameGlobals.GetSpecificEliminations(this.RivalID) - 1);
				if (GameGlobals.GetSpecificEliminations(this.RivalID) < 1)
				{
					GameGlobals.SetSpecificEliminations(this.RivalID, 20);
				}
				GameGlobals.SetRivalEliminations(this.RivalID, this.Specifics[GameGlobals.GetSpecificEliminations(this.RivalID)]);
				this.UpdateText();
			}
		}
		else if (this.InputManager.TappedDown)
		{
			if (this.DetailID != 4 && this.DetailID != 8)
			{
				this.DetailID++;
			}
			this.UpdateArrow();
		}
		else if (this.InputManager.TappedUp)
		{
			if (this.DetailID == 1 || this.DetailID == 5)
			{
				this.SettingDetails = false;
				this.SettingRivals = true;
				if (this.DetailID == 1)
				{
					this.RivalID = 5;
				}
				else
				{
					this.RivalID = 10;
				}
			}
			else
			{
				this.DetailID--;
			}
			this.UpdateArrow();
		}
		else if (this.InputManager.TappedRight)
		{
			if (this.DetailID < 5)
			{
				this.DetailID += 4;
			}
			else
			{
				this.DetailID -= 4;
			}
			this.UpdateArrow();
		}
		else if (this.InputManager.TappedLeft)
		{
			if (this.DetailID > 4)
			{
				this.DetailID -= 4;
			}
			else
			{
				this.DetailID += 4;
			}
			this.UpdateArrow();
		}
		else if (Input.GetButtonDown("Y") || Input.GetButtonDown("X"))
		{
			if (this.DetailID == 1)
			{
				if (PlayerGlobals.PoliceVisits == 0)
				{
					PlayerGlobals.PoliceVisits = 10;
				}
				else
				{
					PlayerGlobals.PoliceVisits = 0;
				}
			}
			else if (this.DetailID == 2)
			{
				if (PlayerGlobals.CorpsesDiscovered == 0)
				{
					PlayerGlobals.CorpsesDiscovered = 10;
				}
				else
				{
					PlayerGlobals.CorpsesDiscovered = 0;
				}
			}
			else if (this.DetailID == 3)
			{
				if (PlayerGlobals.Reputation == 0f)
				{
					PlayerGlobals.Reputation = 100f;
				}
				else
				{
					PlayerGlobals.Reputation = 0f;
				}
			}
			else if (this.DetailID == 4)
			{
				if (!StudentGlobals.GetStudentGrudge(2))
				{
					this.SetGrudges(true);
				}
				else
				{
					this.SetGrudges(false);
				}
			}
			else if (this.DetailID == 5)
			{
				if (PlayerGlobals.Friends == 0)
				{
					this.MakeFriends(true);
				}
				else
				{
					this.MakeFriends(false);
				}
			}
			else if (this.DetailID == 6)
			{
				if (PlayerGlobals.Alerts == 0)
				{
					PlayerGlobals.Alerts = 10;
				}
				else
				{
					PlayerGlobals.Alerts = 0;
				}
			}
			else if (this.DetailID == 7)
			{
				if (PlayerGlobals.WeaponWitnessed == 0)
				{
					PlayerGlobals.WeaponWitnessed = 10;
				}
				else
				{
					PlayerGlobals.WeaponWitnessed = 0;
				}
			}
			else if (this.DetailID == 8)
			{
				if (PlayerGlobals.BloodWitnessed == 0)
				{
					PlayerGlobals.BloodWitnessed = 10;
				}
				else
				{
					PlayerGlobals.BloodWitnessed = 0;
				}
			}
			this.UpdateText();
		}
		if (this.SettingWeek)
		{
			base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(0f, 2.31f, 0f), Time.deltaTime * 10f);
			if (Input.GetButtonDown("A"))
			{
				this.SettingWeek = false;
				this.SettingRivals = true;
				this.EditLabel.gameObject.SetActive(true);
				this.StartLabel.text = "START";
				this.RivalID = 1;
				this.UpdateArrow();
			}
		}
		else
		{
			base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(0f, 0f, 0f), Time.deltaTime * 10f);
			if (Input.GetButtonDown("A"))
			{
				this.Fading = true;
			}
			if (Input.GetButtonDown("B"))
			{
				this.SettingWeek = true;
				this.SettingRivals = false;
				this.SettingDetails = false;
				this.EditLabel.gameObject.SetActive(false);
				this.StartLabel.text = "NEXT";
				this.UpdateArrow();
			}
		}
		for (int j = 1; j < 11; j++)
		{
			if (j == this.CurrentWeek)
			{
				this.Sleeve[j].transform.position = Vector3.Lerp(this.Sleeve[j].transform.position, this.StartingPosition[j] + base.transform.up * 0.05f + base.transform.right * -0.05f, Time.deltaTime * 10f);
				this.Tape[j].transform.localPosition = Vector3.Lerp(this.Tape[j].transform.localPosition, new Vector3(0f, -0.0003f, 0f), Time.deltaTime * 10f);
			}
			else
			{
				this.Sleeve[j].transform.position = Vector3.Lerp(this.Sleeve[j].transform.position, this.StartingPosition[j], Time.deltaTime * 10f);
				this.Tape[j].transform.localPosition = Vector3.Lerp(this.Tape[j].transform.localPosition, Vector3.zero, Time.deltaTime * 10f);
			}
		}
	}

	// Token: 0x0600201C RID: 8220 RVA: 0x001C9F0C File Offset: 0x001C810C
	private void UpdateArrow()
	{
		if (this.SettingWeek)
		{
			this.Arrow.localPosition = new Vector3(0f, 610f, 0f);
			return;
		}
		if (this.SettingRivals)
		{
			if (this.RivalID < 6)
			{
				this.Arrow.localPosition = new Vector3(-820f, (float)(495 - 120 * this.RivalID), 0f);
				return;
			}
			this.Arrow.localPosition = new Vector3(-15f, (float)(495 - 120 * (this.RivalID - 5)), 0f);
			return;
		}
		else
		{
			if (this.DetailID < 5)
			{
				this.Arrow.localPosition = new Vector3(-800f, (float)(-257 - 33 * this.DetailID), 0f);
				return;
			}
			this.Arrow.localPosition = new Vector3(0f, (float)(-257 - 33 * (this.DetailID - 4)), 0f);
			return;
		}
	}

	// Token: 0x0600201D RID: 8221 RVA: 0x001CA00C File Offset: 0x001C820C
	private void UpdateText()
	{
		this.WeekLabel.text = "STARTING WEEK: " + this.CurrentWeek.ToString();
		for (int i = 1; i < 11; i++)
		{
			if (i < DateGlobals.Week)
			{
				this.Shadow[i].SetActive(false);
			}
			else
			{
				this.Shadow[i].SetActive(true);
				GameGlobals.SetRivalEliminations(i, 0);
				GameGlobals.SetSpecificEliminations(i, 0);
			}
		}
		this.Stats.Start();
	}

	// Token: 0x0600201E RID: 8222 RVA: 0x001CA088 File Offset: 0x001C8288
	private void SetGrudges(bool Grudge)
	{
		for (int i = 2; i < 12; i++)
		{
			StudentGlobals.SetStudentGrudge(i, Grudge);
		}
	}

	// Token: 0x0600201F RID: 8223 RVA: 0x001CA0AC File Offset: 0x001C82AC
	private void MakeFriends(bool Friend)
	{
		for (int i = 2; i < 86; i++)
		{
			PlayerGlobals.SetStudentFriend(i, Friend);
		}
		if (Friend)
		{
			PlayerGlobals.Friends = 84;
			GameGlobals.YakuzaPhase = 1;
			return;
		}
		PlayerGlobals.Friends = 0;
		GameGlobals.YakuzaPhase = 0;
	}

	// Token: 0x06002020 RID: 8224 RVA: 0x001CA0EC File Offset: 0x001C82EC
	private void DetermineSelectedWeek()
	{
		this.CurrentWeek = this.Column + (this.Row - 1) * 5;
		for (int i = 1; i < 10; i++)
		{
			GameGlobals.SetRivalEliminations(i, 0);
			GameGlobals.SetSpecificEliminations(i, 0);
		}
		for (int i = 1; i < this.CurrentWeek; i++)
		{
			GameGlobals.SetRivalEliminations(i, 1);
			GameGlobals.SetSpecificEliminations(i, 1);
		}
		DateGlobals.Week = this.CurrentWeek;
		this.UpdateText();
	}

	// Token: 0x040043A1 RID: 17313
	public InputManagerScript InputManager;

	// Token: 0x040043A2 RID: 17314
	public EightiesStatsScript Stats;

	// Token: 0x040043A3 RID: 17315
	public GameObject[] Shadow;

	// Token: 0x040043A4 RID: 17316
	public UISprite Darkness;

	// Token: 0x040043A5 RID: 17317
	public UILabel StartLabel;

	// Token: 0x040043A6 RID: 17318
	public UILabel EditLabel;

	// Token: 0x040043A7 RID: 17319
	public UILabel WeekLabel;

	// Token: 0x040043A8 RID: 17320
	public Transform Arrow;

	// Token: 0x040043A9 RID: 17321
	public bool SettingDetails;

	// Token: 0x040043AA RID: 17322
	public bool SettingRivals;

	// Token: 0x040043AB RID: 17323
	public bool SettingWeek;

	// Token: 0x040043AC RID: 17324
	public bool Fading;

	// Token: 0x040043AD RID: 17325
	public int DetailID = 1;

	// Token: 0x040043AE RID: 17326
	public int RivalID = 1;

	// Token: 0x040043AF RID: 17327
	public int WeekID = 1;

	// Token: 0x040043B0 RID: 17328
	public int FadeID = 1;

	// Token: 0x040043B1 RID: 17329
	public int Row = 1;

	// Token: 0x040043B2 RID: 17330
	public int Column = 1;

	// Token: 0x040043B3 RID: 17331
	public int[] Specifics;

	// Token: 0x040043B4 RID: 17332
	public int CurrentWeek;

	// Token: 0x040043B5 RID: 17333
	public Vector3[] StartingPosition;

	// Token: 0x040043B6 RID: 17334
	public Transform[] Sleeve;

	// Token: 0x040043B7 RID: 17335
	public Transform[] Tape;
}
