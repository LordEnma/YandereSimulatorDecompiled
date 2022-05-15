using System;
using UnityEngine;

// Token: 0x02000481 RID: 1153
public class TitleSaveDataScript : MonoBehaviour
{
	// Token: 0x06001F0E RID: 7950 RVA: 0x001B8154 File Offset: 0x001B6354
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

	// Token: 0x040040B4 RID: 16564
	public TitleSaveFilesScript TitleSaveFiles;

	// Token: 0x040040B5 RID: 16565
	public GameObject EmptyFile;

	// Token: 0x040040B6 RID: 16566
	public GameObject Data;

	// Token: 0x040040B7 RID: 16567
	public Texture[] Bloods;

	// Token: 0x040040B8 RID: 16568
	public UITexture Blood;

	// Token: 0x040040B9 RID: 16569
	public UILabel Kills;

	// Token: 0x040040BA RID: 16570
	public UILabel Mood;

	// Token: 0x040040BB RID: 16571
	public UILabel Alerts;

	// Token: 0x040040BC RID: 16572
	public UILabel Week;

	// Token: 0x040040BD RID: 16573
	public UILabel Day;

	// Token: 0x040040BE RID: 16574
	public UILabel Rival;

	// Token: 0x040040BF RID: 16575
	public UILabel Rep;

	// Token: 0x040040C0 RID: 16576
	public UILabel Club;

	// Token: 0x040040C1 RID: 16577
	public UILabel Friends;

	// Token: 0x040040C2 RID: 16578
	public bool Eighties;

	// Token: 0x040040C3 RID: 16579
	public int ID;
}
