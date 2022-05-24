using System;
using UnityEngine;

// Token: 0x02000481 RID: 1153
public class TitleSaveDataScript : MonoBehaviour
{
	// Token: 0x06001F0F RID: 7951 RVA: 0x001B85E4 File Offset: 0x001B67E4
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

	// Token: 0x040040BD RID: 16573
	public TitleSaveFilesScript TitleSaveFiles;

	// Token: 0x040040BE RID: 16574
	public GameObject EmptyFile;

	// Token: 0x040040BF RID: 16575
	public GameObject Data;

	// Token: 0x040040C0 RID: 16576
	public Texture[] Bloods;

	// Token: 0x040040C1 RID: 16577
	public UITexture Blood;

	// Token: 0x040040C2 RID: 16578
	public UILabel Kills;

	// Token: 0x040040C3 RID: 16579
	public UILabel Mood;

	// Token: 0x040040C4 RID: 16580
	public UILabel Alerts;

	// Token: 0x040040C5 RID: 16581
	public UILabel Week;

	// Token: 0x040040C6 RID: 16582
	public UILabel Day;

	// Token: 0x040040C7 RID: 16583
	public UILabel Rival;

	// Token: 0x040040C8 RID: 16584
	public UILabel Rep;

	// Token: 0x040040C9 RID: 16585
	public UILabel Club;

	// Token: 0x040040CA RID: 16586
	public UILabel Friends;

	// Token: 0x040040CB RID: 16587
	public bool Eighties;

	// Token: 0x040040CC RID: 16588
	public int ID;
}
