using System;
using UnityEngine;

// Token: 0x02000476 RID: 1142
public class TitleSaveDataScript : MonoBehaviour
{
	// Token: 0x06001EBC RID: 7868 RVA: 0x001B0690 File Offset: 0x001AE890
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

	// Token: 0x04003FC2 RID: 16322
	public TitleSaveFilesScript TitleSaveFiles;

	// Token: 0x04003FC3 RID: 16323
	public GameObject EmptyFile;

	// Token: 0x04003FC4 RID: 16324
	public GameObject Data;

	// Token: 0x04003FC5 RID: 16325
	public Texture[] Bloods;

	// Token: 0x04003FC6 RID: 16326
	public UITexture Blood;

	// Token: 0x04003FC7 RID: 16327
	public UILabel Kills;

	// Token: 0x04003FC8 RID: 16328
	public UILabel Mood;

	// Token: 0x04003FC9 RID: 16329
	public UILabel Alerts;

	// Token: 0x04003FCA RID: 16330
	public UILabel Week;

	// Token: 0x04003FCB RID: 16331
	public UILabel Day;

	// Token: 0x04003FCC RID: 16332
	public UILabel Rival;

	// Token: 0x04003FCD RID: 16333
	public UILabel Rep;

	// Token: 0x04003FCE RID: 16334
	public UILabel Club;

	// Token: 0x04003FCF RID: 16335
	public UILabel Friends;

	// Token: 0x04003FD0 RID: 16336
	public bool Eighties;

	// Token: 0x04003FD1 RID: 16337
	public int ID;
}
