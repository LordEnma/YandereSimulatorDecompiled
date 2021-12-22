using System;
using UnityEngine;

// Token: 0x02000473 RID: 1139
public class TitleSaveDataScript : MonoBehaviour
{
	// Token: 0x06001EAA RID: 7850 RVA: 0x001AE3A8 File Offset: 0x001AC5A8
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

	// Token: 0x04003F92 RID: 16274
	public TitleSaveFilesScript TitleSaveFiles;

	// Token: 0x04003F93 RID: 16275
	public GameObject EmptyFile;

	// Token: 0x04003F94 RID: 16276
	public GameObject Data;

	// Token: 0x04003F95 RID: 16277
	public Texture[] Bloods;

	// Token: 0x04003F96 RID: 16278
	public UITexture Blood;

	// Token: 0x04003F97 RID: 16279
	public UILabel Kills;

	// Token: 0x04003F98 RID: 16280
	public UILabel Mood;

	// Token: 0x04003F99 RID: 16281
	public UILabel Alerts;

	// Token: 0x04003F9A RID: 16282
	public UILabel Week;

	// Token: 0x04003F9B RID: 16283
	public UILabel Day;

	// Token: 0x04003F9C RID: 16284
	public UILabel Rival;

	// Token: 0x04003F9D RID: 16285
	public UILabel Rep;

	// Token: 0x04003F9E RID: 16286
	public UILabel Club;

	// Token: 0x04003F9F RID: 16287
	public UILabel Friends;

	// Token: 0x04003FA0 RID: 16288
	public bool Eighties;

	// Token: 0x04003FA1 RID: 16289
	public int ID;
}
