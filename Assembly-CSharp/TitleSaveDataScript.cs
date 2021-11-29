using System;
using UnityEngine;

// Token: 0x02000472 RID: 1138
public class TitleSaveDataScript : MonoBehaviour
{
	// Token: 0x06001EA0 RID: 7840 RVA: 0x001AD61C File Offset: 0x001AB81C
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

	// Token: 0x04003F62 RID: 16226
	public TitleSaveFilesScript TitleSaveFiles;

	// Token: 0x04003F63 RID: 16227
	public GameObject EmptyFile;

	// Token: 0x04003F64 RID: 16228
	public GameObject Data;

	// Token: 0x04003F65 RID: 16229
	public Texture[] Bloods;

	// Token: 0x04003F66 RID: 16230
	public UITexture Blood;

	// Token: 0x04003F67 RID: 16231
	public UILabel Kills;

	// Token: 0x04003F68 RID: 16232
	public UILabel Mood;

	// Token: 0x04003F69 RID: 16233
	public UILabel Alerts;

	// Token: 0x04003F6A RID: 16234
	public UILabel Week;

	// Token: 0x04003F6B RID: 16235
	public UILabel Day;

	// Token: 0x04003F6C RID: 16236
	public UILabel Rival;

	// Token: 0x04003F6D RID: 16237
	public UILabel Rep;

	// Token: 0x04003F6E RID: 16238
	public UILabel Club;

	// Token: 0x04003F6F RID: 16239
	public UILabel Friends;

	// Token: 0x04003F70 RID: 16240
	public bool Eighties;

	// Token: 0x04003F71 RID: 16241
	public int ID;
}
