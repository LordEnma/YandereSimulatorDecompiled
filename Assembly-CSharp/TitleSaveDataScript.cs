using System;
using UnityEngine;

// Token: 0x0200047E RID: 1150
public class TitleSaveDataScript : MonoBehaviour
{
	// Token: 0x06001EEE RID: 7918 RVA: 0x001B4C90 File Offset: 0x001B2E90
	public void Start()
	{
		this.Eighties = GameGlobals.Eighties;
		if (PlayerPrefs.GetInt("ProfileCreated_" + this.ID.ToString()) > 0)
		{
			int profile = GameGlobals.Profile;
			GameGlobals.Profile = this.ID;
			this.EmptyFile.SetActive(false);
			this.Data.SetActive(true);
			this.Kills.text = "Kills: " + PlayerGlobals.Kills.ToString();
			this.Mood.text = "Mood: " + Mathf.RoundToInt(SchoolGlobals.SchoolAtmosphere * 100f).ToString();
			this.Alerts.text = "Alerts: " + PlayerGlobals.Alerts.ToString();
			this.Week.text = "Week: " + DateGlobals.Week.ToString();
			this.Day.text = "Day: " + DateGlobals.Weekday.ToString();
			if (DateGlobals.Week < 11)
			{
				if (this.Eighties)
				{
					this.Rival.text = "Rival: " + this.TitleSaveFiles.NewTitleScreen.EightiesRivalNames[DateGlobals.Week];
				}
				else
				{
					this.Rival.text = "Rival: " + this.TitleSaveFiles.NewTitleScreen.RivalNames[DateGlobals.Week];
				}
			}
			else
			{
				this.Rival.text = "Rival: ?????";
			}
			this.Rep.text = "Rep: " + PlayerGlobals.Reputation.ToString();
			this.Club.text = "Club: " + ClubGlobals.Club.ToString();
			this.Friends.text = "Friends: " + PlayerGlobals.Friends.ToString();
			if (PlayerGlobals.Kills == 0)
			{
				this.Blood.mainTexture = null;
			}
			else if (PlayerGlobals.Kills > 0)
			{
				this.Blood.mainTexture = this.Bloods[1];
			}
			else if (PlayerGlobals.Kills > 5)
			{
				this.Blood.mainTexture = this.Bloods[2];
			}
			else if (PlayerGlobals.Kills > 10)
			{
				this.Blood.mainTexture = this.Bloods[3];
			}
			else if (PlayerGlobals.Kills > 15)
			{
				this.Blood.mainTexture = this.Bloods[4];
			}
			else if (PlayerGlobals.Kills > 20)
			{
				this.Blood.mainTexture = this.Bloods[5];
			}
			GameGlobals.Profile = profile;
			return;
		}
		this.EmptyFile.SetActive(true);
		this.Data.SetActive(false);
		this.Blood.enabled = false;
	}

	// Token: 0x0400406D RID: 16493
	public TitleSaveFilesScript TitleSaveFiles;

	// Token: 0x0400406E RID: 16494
	public GameObject EmptyFile;

	// Token: 0x0400406F RID: 16495
	public GameObject Data;

	// Token: 0x04004070 RID: 16496
	public Texture[] Bloods;

	// Token: 0x04004071 RID: 16497
	public UITexture Blood;

	// Token: 0x04004072 RID: 16498
	public UILabel Kills;

	// Token: 0x04004073 RID: 16499
	public UILabel Mood;

	// Token: 0x04004074 RID: 16500
	public UILabel Alerts;

	// Token: 0x04004075 RID: 16501
	public UILabel Week;

	// Token: 0x04004076 RID: 16502
	public UILabel Day;

	// Token: 0x04004077 RID: 16503
	public UILabel Rival;

	// Token: 0x04004078 RID: 16504
	public UILabel Rep;

	// Token: 0x04004079 RID: 16505
	public UILabel Club;

	// Token: 0x0400407A RID: 16506
	public UILabel Friends;

	// Token: 0x0400407B RID: 16507
	public bool Eighties;

	// Token: 0x0400407C RID: 16508
	public int ID;
}
