using System;
using UnityEngine;

// Token: 0x02000478 RID: 1144
public class TitleSaveDataScript : MonoBehaviour
{
	// Token: 0x06001ED2 RID: 7890 RVA: 0x001B1FCC File Offset: 0x001B01CC
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

	// Token: 0x04003FF5 RID: 16373
	public TitleSaveFilesScript TitleSaveFiles;

	// Token: 0x04003FF6 RID: 16374
	public GameObject EmptyFile;

	// Token: 0x04003FF7 RID: 16375
	public GameObject Data;

	// Token: 0x04003FF8 RID: 16376
	public Texture[] Bloods;

	// Token: 0x04003FF9 RID: 16377
	public UITexture Blood;

	// Token: 0x04003FFA RID: 16378
	public UILabel Kills;

	// Token: 0x04003FFB RID: 16379
	public UILabel Mood;

	// Token: 0x04003FFC RID: 16380
	public UILabel Alerts;

	// Token: 0x04003FFD RID: 16381
	public UILabel Week;

	// Token: 0x04003FFE RID: 16382
	public UILabel Day;

	// Token: 0x04003FFF RID: 16383
	public UILabel Rival;

	// Token: 0x04004000 RID: 16384
	public UILabel Rep;

	// Token: 0x04004001 RID: 16385
	public UILabel Club;

	// Token: 0x04004002 RID: 16386
	public UILabel Friends;

	// Token: 0x04004003 RID: 16387
	public bool Eighties;

	// Token: 0x04004004 RID: 16388
	public int ID;
}
