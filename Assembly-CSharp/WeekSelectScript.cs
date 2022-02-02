using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004BC RID: 1212
public class WeekSelectScript : MonoBehaviour
{
	// Token: 0x06001FBA RID: 8122 RVA: 0x001C0728 File Offset: 0x001BE928
	private void Start()
	{
		this.Darkness.alpha = 1f;
		this.UpdateArrow();
		this.UpdateText();
	}

	// Token: 0x06001FBB RID: 8123 RVA: 0x001C0748 File Offset: 0x001BE948
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
						if (GameGlobals.GetRivalEliminations(i) == 1 || GameGlobals.GetRivalEliminations(i) == 5 || GameGlobals.GetRivalEliminations(i) == 6 || GameGlobals.GetRivalEliminations(i) == 7 || GameGlobals.GetRivalEliminations(i) == 8 || GameGlobals.GetRivalEliminations(i) == 10 || GameGlobals.GetRivalEliminations(i) == 14 || GameGlobals.GetRivalEliminations(i) == 15 || GameGlobals.GetRivalEliminations(i) == 16 || GameGlobals.GetRivalEliminations(i) == 17 || GameGlobals.GetRivalEliminations(i) == 19 || GameGlobals.GetRivalEliminations(i) == 20)
						{
							StudentGlobals.SetStudentDead(i + 10, true);
						}
						else if (GameGlobals.GetRivalEliminations(i) == 3 || GameGlobals.GetRivalEliminations(i) == 4)
						{
							StudentGlobals.SetStudentMissing(i + 10, true);
						}
						else if (GameGlobals.GetRivalEliminations(i) == 9)
						{
							StudentGlobals.SetStudentExpelled(i + 10, true);
						}
						else if (GameGlobals.GetRivalEliminations(i) == 11)
						{
							StudentGlobals.SetStudentArrested(i + 10, true);
						}
						else if (GameGlobals.GetRivalEliminations(i) == 12)
						{
							StudentGlobals.SetStudentKidnapped(i + 10, true);
						}
					}
					ClassGlobals.BonusStudyPoints = DateGlobals.Week * 50 - 50;
					GameGlobals.EightiesCutsceneID = DateGlobals.Week;
					SceneManager.LoadScene("EightiesCutsceneScene");
				}
			}
		}
		if (this.SettingWeek)
		{
			if (this.InputManager.TappedDown)
			{
				this.SettingWeek = false;
				this.SettingRivals = true;
				this.RivalID = 1;
				this.UpdateArrow();
			}
			else if (this.InputManager.TappedUp)
			{
				this.SettingWeek = false;
				this.SettingDetails = true;
				this.DetailID = 4;
				this.UpdateArrow();
			}
			else if (Input.GetButtonDown("X"))
			{
				DateGlobals.Week--;
				if (DateGlobals.Week < 1)
				{
					for (int j = 1; j < 10; j++)
					{
						GameGlobals.SetRivalEliminations(j, 1);
						GameGlobals.SetSpecificEliminations(j, 1);
					}
					DateGlobals.Week = 10;
				}
				this.UpdateText();
			}
			else if (Input.GetButtonDown("Y"))
			{
				DateGlobals.Week++;
				if (DateGlobals.Week > 10)
				{
					DateGlobals.Week = 1;
				}
				GameGlobals.SetRivalEliminations(DateGlobals.Week - 1, 1);
				GameGlobals.SetSpecificEliminations(DateGlobals.Week - 1, 1);
				this.UpdateText();
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
				if (this.RivalID == 1 || this.RivalID == 6)
				{
					this.SettingRivals = false;
					this.SettingWeek = true;
				}
				else
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
			if (this.DetailID == 4 || this.DetailID == 8)
			{
				this.SettingDetails = false;
				this.SettingWeek = true;
			}
			else
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
		if (Input.GetButtonDown("A"))
		{
			this.Fading = true;
		}
	}

	// Token: 0x06001FBC RID: 8124 RVA: 0x001C0E9C File Offset: 0x001BF09C
	private void UpdateArrow()
	{
		if (this.SettingWeek)
		{
			this.Arrow.localPosition = new Vector3(-550f, 500f, 0f);
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

	// Token: 0x06001FBD RID: 8125 RVA: 0x001C0F9C File Offset: 0x001BF19C
	private void UpdateText()
	{
		this.WeekLabel.text = "STARTING WEEK: " + DateGlobals.Week.ToString();
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

	// Token: 0x06001FBE RID: 8126 RVA: 0x001C1018 File Offset: 0x001BF218
	private void SetGrudges(bool Grudge)
	{
		for (int i = 2; i < 12; i++)
		{
			StudentGlobals.SetStudentGrudge(i, Grudge);
		}
	}

	// Token: 0x06001FBF RID: 8127 RVA: 0x001C103C File Offset: 0x001BF23C
	private void MakeFriends(bool Friend)
	{
		for (int i = 2; i < 86; i++)
		{
			PlayerGlobals.SetStudentFriend(i, Friend);
		}
		if (Friend)
		{
			PlayerGlobals.Friends = 84;
			return;
		}
		PlayerGlobals.Friends = 0;
	}

	// Token: 0x04004286 RID: 17030
	public InputManagerScript InputManager;

	// Token: 0x04004287 RID: 17031
	public EightiesStatsScript Stats;

	// Token: 0x04004288 RID: 17032
	public GameObject[] Shadow;

	// Token: 0x04004289 RID: 17033
	public UISprite Darkness;

	// Token: 0x0400428A RID: 17034
	public UILabel WeekLabel;

	// Token: 0x0400428B RID: 17035
	public Transform Arrow;

	// Token: 0x0400428C RID: 17036
	public bool SettingDetails;

	// Token: 0x0400428D RID: 17037
	public bool SettingRivals;

	// Token: 0x0400428E RID: 17038
	public bool SettingWeek;

	// Token: 0x0400428F RID: 17039
	public bool Fading;

	// Token: 0x04004290 RID: 17040
	public int DetailID = 1;

	// Token: 0x04004291 RID: 17041
	public int RivalID = 1;

	// Token: 0x04004292 RID: 17042
	public int WeekID = 1;

	// Token: 0x04004293 RID: 17043
	public int FadeID = 1;

	// Token: 0x04004294 RID: 17044
	public int[] Specifics;
}
