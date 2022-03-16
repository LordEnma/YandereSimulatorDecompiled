using System;
using UnityEngine;

// Token: 0x0200047B RID: 1147
public class TitleSaveDataScript : MonoBehaviour
{
	// Token: 0x06001EE4 RID: 7908 RVA: 0x001B371C File Offset: 0x001B191C
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

	// Token: 0x04004040 RID: 16448
	public TitleSaveFilesScript TitleSaveFiles;

	// Token: 0x04004041 RID: 16449
	public GameObject EmptyFile;

	// Token: 0x04004042 RID: 16450
	public GameObject Data;

	// Token: 0x04004043 RID: 16451
	public Texture[] Bloods;

	// Token: 0x04004044 RID: 16452
	public UITexture Blood;

	// Token: 0x04004045 RID: 16453
	public UILabel Kills;

	// Token: 0x04004046 RID: 16454
	public UILabel Mood;

	// Token: 0x04004047 RID: 16455
	public UILabel Alerts;

	// Token: 0x04004048 RID: 16456
	public UILabel Week;

	// Token: 0x04004049 RID: 16457
	public UILabel Day;

	// Token: 0x0400404A RID: 16458
	public UILabel Rival;

	// Token: 0x0400404B RID: 16459
	public UILabel Rep;

	// Token: 0x0400404C RID: 16460
	public UILabel Club;

	// Token: 0x0400404D RID: 16461
	public UILabel Friends;

	// Token: 0x0400404E RID: 16462
	public bool Eighties;

	// Token: 0x0400404F RID: 16463
	public int ID;
}
