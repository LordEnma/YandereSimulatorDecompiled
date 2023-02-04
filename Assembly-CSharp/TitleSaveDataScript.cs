using UnityEngine;

public class TitleSaveDataScript : MonoBehaviour
{
	public TitleSaveFilesScript TitleSaveFiles;

	public GameObject EmptyFile;

	public GameObject Data;

	public Texture[] Bloods;

	public UITexture Blood;

	public UILabel Kills;

	public UILabel Mood;

	public UILabel Alerts;

	public UILabel Week;

	public UILabel Day;

	public UILabel Rival;

	public UILabel Rep;

	public UILabel Club;

	public UILabel Friends;

	public bool Eighties;

	public int ID;

	public void Start()
	{
		Eighties = GameGlobals.Eighties;
		if (PlayerPrefs.GetInt("ProfileCreated_" + ID) > 0)
		{
			int profile = GameGlobals.Profile;
			GameGlobals.Profile = ID;
			EmptyFile.SetActive(value: false);
			Data.SetActive(value: true);
			Kills.text = "Kills: " + PlayerGlobals.Kills;
			Mood.text = "Mood: " + Mathf.RoundToInt(SchoolGlobals.SchoolAtmosphere * 100f);
			Alerts.text = "Alerts: " + PlayerGlobals.Alerts;
			Week.text = "Week: " + DateGlobals.Week;
			Day.text = "Day: " + DateGlobals.Weekday;
			if (DateGlobals.Week < 11)
			{
				if (Eighties)
				{
					Rival.text = "Rival: " + TitleSaveFiles.NewTitleScreen.EightiesRivalNames[DateGlobals.Week];
				}
				else
				{
					Rival.text = "Rival: " + TitleSaveFiles.NewTitleScreen.RivalNames[DateGlobals.Week];
				}
			}
			else
			{
				Rival.text = "Rival: ?????";
			}
			Rep.text = "Rep: " + PlayerGlobals.Reputation;
			Club.text = "Club: " + ClubGlobals.Club;
			Friends.text = "Friends: " + PlayerGlobals.Friends;
			if (PlayerGlobals.Kills == 0)
			{
				Blood.mainTexture = null;
			}
			else if (PlayerGlobals.Kills > 0)
			{
				Blood.mainTexture = Bloods[1];
			}
			else if (PlayerGlobals.Kills > 5)
			{
				Blood.mainTexture = Bloods[2];
			}
			else if (PlayerGlobals.Kills > 10)
			{
				Blood.mainTexture = Bloods[3];
			}
			else if (PlayerGlobals.Kills > 15)
			{
				Blood.mainTexture = Bloods[4];
			}
			else if (PlayerGlobals.Kills > 20)
			{
				Blood.mainTexture = Bloods[5];
			}
			GameGlobals.Profile = profile;
		}
		else
		{
			EmptyFile.SetActive(value: true);
			Data.SetActive(value: false);
			Blood.enabled = false;
		}
	}
}
