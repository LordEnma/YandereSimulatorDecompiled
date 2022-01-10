using System;
using UnityEngine;

// Token: 0x02000475 RID: 1141
public class TitleSaveDataScript : MonoBehaviour
{
	// Token: 0x06001EB7 RID: 7863 RVA: 0x001AF1DC File Offset: 0x001AD3DC
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

	// Token: 0x04003FAD RID: 16301
	public TitleSaveFilesScript TitleSaveFiles;

	// Token: 0x04003FAE RID: 16302
	public GameObject EmptyFile;

	// Token: 0x04003FAF RID: 16303
	public GameObject Data;

	// Token: 0x04003FB0 RID: 16304
	public Texture[] Bloods;

	// Token: 0x04003FB1 RID: 16305
	public UITexture Blood;

	// Token: 0x04003FB2 RID: 16306
	public UILabel Kills;

	// Token: 0x04003FB3 RID: 16307
	public UILabel Mood;

	// Token: 0x04003FB4 RID: 16308
	public UILabel Alerts;

	// Token: 0x04003FB5 RID: 16309
	public UILabel Week;

	// Token: 0x04003FB6 RID: 16310
	public UILabel Day;

	// Token: 0x04003FB7 RID: 16311
	public UILabel Rival;

	// Token: 0x04003FB8 RID: 16312
	public UILabel Rep;

	// Token: 0x04003FB9 RID: 16313
	public UILabel Club;

	// Token: 0x04003FBA RID: 16314
	public UILabel Friends;

	// Token: 0x04003FBB RID: 16315
	public bool Eighties;

	// Token: 0x04003FBC RID: 16316
	public int ID;
}
