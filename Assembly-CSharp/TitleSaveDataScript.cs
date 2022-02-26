using System;
using UnityEngine;

// Token: 0x02000478 RID: 1144
public class TitleSaveDataScript : MonoBehaviour
{
	// Token: 0x06001ECF RID: 7887 RVA: 0x001B18A4 File Offset: 0x001AFAA4
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

	// Token: 0x04003FDE RID: 16350
	public TitleSaveFilesScript TitleSaveFiles;

	// Token: 0x04003FDF RID: 16351
	public GameObject EmptyFile;

	// Token: 0x04003FE0 RID: 16352
	public GameObject Data;

	// Token: 0x04003FE1 RID: 16353
	public Texture[] Bloods;

	// Token: 0x04003FE2 RID: 16354
	public UITexture Blood;

	// Token: 0x04003FE3 RID: 16355
	public UILabel Kills;

	// Token: 0x04003FE4 RID: 16356
	public UILabel Mood;

	// Token: 0x04003FE5 RID: 16357
	public UILabel Alerts;

	// Token: 0x04003FE6 RID: 16358
	public UILabel Week;

	// Token: 0x04003FE7 RID: 16359
	public UILabel Day;

	// Token: 0x04003FE8 RID: 16360
	public UILabel Rival;

	// Token: 0x04003FE9 RID: 16361
	public UILabel Rep;

	// Token: 0x04003FEA RID: 16362
	public UILabel Club;

	// Token: 0x04003FEB RID: 16363
	public UILabel Friends;

	// Token: 0x04003FEC RID: 16364
	public bool Eighties;

	// Token: 0x04003FED RID: 16365
	public int ID;
}
