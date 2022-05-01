using System;
using UnityEngine;

// Token: 0x02000480 RID: 1152
public class TitleSaveDataScript : MonoBehaviour
{
	// Token: 0x06001F05 RID: 7941 RVA: 0x001B6EE0 File Offset: 0x001B50E0
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

	// Token: 0x04004096 RID: 16534
	public TitleSaveFilesScript TitleSaveFiles;

	// Token: 0x04004097 RID: 16535
	public GameObject EmptyFile;

	// Token: 0x04004098 RID: 16536
	public GameObject Data;

	// Token: 0x04004099 RID: 16537
	public Texture[] Bloods;

	// Token: 0x0400409A RID: 16538
	public UITexture Blood;

	// Token: 0x0400409B RID: 16539
	public UILabel Kills;

	// Token: 0x0400409C RID: 16540
	public UILabel Mood;

	// Token: 0x0400409D RID: 16541
	public UILabel Alerts;

	// Token: 0x0400409E RID: 16542
	public UILabel Week;

	// Token: 0x0400409F RID: 16543
	public UILabel Day;

	// Token: 0x040040A0 RID: 16544
	public UILabel Rival;

	// Token: 0x040040A1 RID: 16545
	public UILabel Rep;

	// Token: 0x040040A2 RID: 16546
	public UILabel Club;

	// Token: 0x040040A3 RID: 16547
	public UILabel Friends;

	// Token: 0x040040A4 RID: 16548
	public bool Eighties;

	// Token: 0x040040A5 RID: 16549
	public int ID;
}
