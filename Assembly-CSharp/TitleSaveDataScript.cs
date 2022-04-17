using System;
using UnityEngine;

// Token: 0x0200047F RID: 1151
public class TitleSaveDataScript : MonoBehaviour
{
	// Token: 0x06001EFC RID: 7932 RVA: 0x001B5B70 File Offset: 0x001B3D70
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

	// Token: 0x04004080 RID: 16512
	public TitleSaveFilesScript TitleSaveFiles;

	// Token: 0x04004081 RID: 16513
	public GameObject EmptyFile;

	// Token: 0x04004082 RID: 16514
	public GameObject Data;

	// Token: 0x04004083 RID: 16515
	public Texture[] Bloods;

	// Token: 0x04004084 RID: 16516
	public UITexture Blood;

	// Token: 0x04004085 RID: 16517
	public UILabel Kills;

	// Token: 0x04004086 RID: 16518
	public UILabel Mood;

	// Token: 0x04004087 RID: 16519
	public UILabel Alerts;

	// Token: 0x04004088 RID: 16520
	public UILabel Week;

	// Token: 0x04004089 RID: 16521
	public UILabel Day;

	// Token: 0x0400408A RID: 16522
	public UILabel Rival;

	// Token: 0x0400408B RID: 16523
	public UILabel Rep;

	// Token: 0x0400408C RID: 16524
	public UILabel Club;

	// Token: 0x0400408D RID: 16525
	public UILabel Friends;

	// Token: 0x0400408E RID: 16526
	public bool Eighties;

	// Token: 0x0400408F RID: 16527
	public int ID;
}
