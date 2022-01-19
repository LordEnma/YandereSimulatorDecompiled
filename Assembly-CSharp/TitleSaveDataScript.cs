using System;
using UnityEngine;

// Token: 0x02000476 RID: 1142
public class TitleSaveDataScript : MonoBehaviour
{
	// Token: 0x06001EB9 RID: 7865 RVA: 0x001AFEAC File Offset: 0x001AE0AC
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

	// Token: 0x04003FB4 RID: 16308
	public TitleSaveFilesScript TitleSaveFiles;

	// Token: 0x04003FB5 RID: 16309
	public GameObject EmptyFile;

	// Token: 0x04003FB6 RID: 16310
	public GameObject Data;

	// Token: 0x04003FB7 RID: 16311
	public Texture[] Bloods;

	// Token: 0x04003FB8 RID: 16312
	public UITexture Blood;

	// Token: 0x04003FB9 RID: 16313
	public UILabel Kills;

	// Token: 0x04003FBA RID: 16314
	public UILabel Mood;

	// Token: 0x04003FBB RID: 16315
	public UILabel Alerts;

	// Token: 0x04003FBC RID: 16316
	public UILabel Week;

	// Token: 0x04003FBD RID: 16317
	public UILabel Day;

	// Token: 0x04003FBE RID: 16318
	public UILabel Rival;

	// Token: 0x04003FBF RID: 16319
	public UILabel Rep;

	// Token: 0x04003FC0 RID: 16320
	public UILabel Club;

	// Token: 0x04003FC1 RID: 16321
	public UILabel Friends;

	// Token: 0x04003FC2 RID: 16322
	public bool Eighties;

	// Token: 0x04003FC3 RID: 16323
	public int ID;
}
