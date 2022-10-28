// Decompiled with JetBrains decompiler
// Type: TitleSaveDataScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
      this.Rival.text = DateGlobals.Week >= 11 ? "Rival: ?????" : (!this.Eighties ? "Rival: " + this.TitleSaveFiles.NewTitleScreen.RivalNames[DateGlobals.Week] : "Rival: " + this.TitleSaveFiles.NewTitleScreen.EightiesRivalNames[DateGlobals.Week]);
      this.Rep.text = "Rep: " + PlayerGlobals.Reputation.ToString();
      this.Club.text = "Club: " + ClubGlobals.Club.ToString();
      this.Friends.text = "Friends: " + PlayerGlobals.Friends.ToString();
      if (PlayerGlobals.Kills == 0)
        this.Blood.mainTexture = (Texture) null;
      else if (PlayerGlobals.Kills > 0)
        this.Blood.mainTexture = this.Bloods[1];
      else if (PlayerGlobals.Kills > 5)
        this.Blood.mainTexture = this.Bloods[2];
      else if (PlayerGlobals.Kills > 10)
        this.Blood.mainTexture = this.Bloods[3];
      else if (PlayerGlobals.Kills > 15)
        this.Blood.mainTexture = this.Bloods[4];
      else if (PlayerGlobals.Kills > 20)
        this.Blood.mainTexture = this.Bloods[5];
      GameGlobals.Profile = profile;
    }
    else
    {
      this.EmptyFile.SetActive(true);
      this.Data.SetActive(false);
      this.Blood.enabled = false;
    }
  }
}
