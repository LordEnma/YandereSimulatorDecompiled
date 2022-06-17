// Decompiled with JetBrains decompiler
// Type: DiscordRPC
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using Discord;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiscordRPC : MonoBehaviour
{
  private Discord.Discord _discord;
  private ActivityManager _activity;
  private ClockScript _clockScript;
  [SerializeField]
  private string _applicationID = "560185502691491841";
  [SerializeField]
  private string _boxArtImage = "boxart";
  [SerializeField]
  private string _boxArtText = "This might be the game's box art one day!";
  [SerializeField]
  private string _details = "He... will... be... mine.";
  private string _currentScene;
  [SerializeField]
  private float _updateRate = 5f;
  private bool _createdDictionary;
  [SerializeField]
  private bool _updateRichPresence = true;
  [SerializeField]
  private Dictionary<string, string> _sceneDescription = new Dictionary<string, string>();
  [SerializeField]
  private Dictionary<int, string> _gamePeriod = new Dictionary<int, string>();
  [SerializeField]
  private Dictionary<int, string> _gameWeekday = new Dictionary<int, string>();

  private void Start()
  {
    Object.DontDestroyOnLoad((Object) this.gameObject);
    if (this._applicationID != string.Empty)
    {
      this._discord = new Discord.Discord(long.Parse(this._applicationID), 1UL);
      this.UpdateActivity();
    }
    else
      Debug.Log((object) "An error has occurred. You probably didn't set the Application ID.");
    this.StartCoroutine(this.RichPresenceUpdate());
  }

  private void Update()
  {
    if (this._discord == null)
      return;
    this._discord.RunCallbacks();
  }

  private void UpdateRichPresenceInfo()
  {
    if (SceneManager.GetActiveScene().name == "SchoolScene" && (Object) this._clockScript == (Object) null)
      this._clockScript = Object.FindObjectOfType<ClockScript>();
    this.UpdateActivity();
  }

  private void UpdateActivity()
  {
    this._currentScene = SceneManager.GetActiveScene().name;
    this._activity = this._discord.GetActivityManager();
    this._activity.UpdateActivity(new Activity()
    {
      Assets = {
        LargeImage = this._boxArtImage,
        LargeText = this._boxArtText
      },
      Details = this._details,
      State = this.GetSceneDescription()
    }, (ActivityManager.UpdateActivityHandler) (RichPresenceResult =>
    {
      if (RichPresenceResult == Result.Ok)
        return;
      Debug.Log((object) ("Error! Connection Error (" + RichPresenceResult.ToString() + ")"));
    }));
  }

  private string GetSceneDescription()
  {
    this.UpdateSceneDescription();
    switch (this._currentScene)
    {
      case "SchoolScene":
        return string.Format("{0}, {1}, {2}, {3}{4}", (object) this._sceneDescription["SchoolScene"], (object) this._clockScript.TimeLabel.text, (object) this._gamePeriod[this._clockScript.Period], (object) this._gameWeekday[this._clockScript.Weekday], (object) (MissionModeGlobals.MissionMode ? ", Mission Mode" : string.Empty));
      default:
        return this._sceneDescription.ContainsKey(this._currentScene) ? this._sceneDescription[this._currentScene] : "No description available yet.";
    }
  }

  private void UpdateSceneDescription()
  {
    if (this._createdDictionary)
      return;
    this._sceneDescription.Add("ResolutionScene", "Setting the resolution!");
    this._sceneDescription.Add("WelcomeScene", "Launching the game!");
    this._sceneDescription.Add("SponsorScene", "Checking out the sponsors!");
    this._sceneDescription.Add("NewTitleScene", "At the title screen!");
    this._sceneDescription.Add("SenpaiScene", "Customizing Senpai!");
    this._sceneDescription.Add("IntroScene", "Watching the Intro!");
    this._sceneDescription.Add("NewIntroScene", "Watching the Intro!");
    this._sceneDescription.Add("PhoneScene", "Texting with Info-Chan!");
    this._sceneDescription.Add("CalendarScene", "Checking out the Calendar!");
    this._sceneDescription.Add("HomeScene", "Chilling at home!");
    this._sceneDescription.Add("LoadingScene", "Now Loading!");
    this._sceneDescription.Add("SchoolScene", "At School");
    this._sceneDescription.Add("YanvaniaTitleScene", "Beginning Yanvania: Senpai of the Night!");
    this._sceneDescription.Add("YanvaniaScene", "Playing Yanvania: Senpai of the Night!");
    this._sceneDescription.Add("LivingRoomScene", "Preparing to befriend or betray  Osana!");
    this._sceneDescription.Add("MissionModeScene", "Accepting a mission!");
    this._sceneDescription.Add("VeryFunScene", "??????????");
    this._sceneDescription.Add("CreditsScene", "Viewing the credits!");
    this._sceneDescription.Add("MiyukiTitleScene", "Beginning Magical Girl Pretty Miyuki!");
    this._sceneDescription.Add("MiyukiGameplayScene", "Playing Magical Girl Pretty Miyuki!");
    this._sceneDescription.Add("MiyukiThanksScene", "Finishing Magical Girl Pretty Miyuki!");
    this._sceneDescription.Add("RhythmMinigameScene", "Jamming out with the Light Music Club!");
    this._sceneDescription.Add("LifeNoteScene", "Watching an episode of Life Note!");
    this._sceneDescription.Add("YancordScene", "Chatting over Yancord!");
    this._sceneDescription.Add("MaidMenuScene", "Getting ready to be cute at a maid cafe!");
    this._sceneDescription.Add("MaidGameScene", "Being a cute maid! MOE MOE KYUN!");
    this._sceneDescription.Add("StreetScene", "Chilling in town!");
    this._sceneDescription.Add("BusStopScene", "Watching Senpai meet Amai!");
    this._sceneDescription.Add("PostCreditsScene", "Eavesdropping on the headmaster!");
    this._sceneDescription.Add("DiscordScene", "Awaiting Verification");
    this._sceneDescription.Add("OsanaJokeScene", "Killing Osana at long last!");
    this._sceneDescription.Add("ThanksForPlayingScene", "Just beat the Osana demo!");
    this._sceneDescription.Add("StalkerHouseScene", "Sneaking through a stalker's house!");
    this._sceneDescription.Add("GenocideScene", "Successfully committed genocide!");
    this._sceneDescription.Add("RivalRejectionProgressScene", "Making Senpai reject a confession!");
    this._sceneDescription.Add("EightiesCutsceneScene", "Listening to Ryoba talk!");
    this._sceneDescription.Add("CourtroomScene", "Awaiting the judge's verdict!");
    this._sceneDescription.Add("TrueEndingScene", "Witnessing the true ending!");
    this._sceneDescription.Add("AsylumScene", "Sneaking through a spooky asylum!");
    this._sceneDescription.Add("AbductionScene", "Watching an abduction take place!");
    this._sceneDescription.Add("WeekSelectScene", "Deciding what week to skip to!");
    this._gameWeekday.Add(0, " Monday");
    this._gameWeekday.Add(1, "Monday");
    this._gameWeekday.Add(2, "Tuesday");
    this._gameWeekday.Add(3, "Wednesday");
    this._gameWeekday.Add(4, "Thursday");
    this._gameWeekday.Add(5, "Friday");
    this._gamePeriod.Add(0, " Before Class");
    this._gamePeriod.Add(1, "Before Class");
    this._gamePeriod.Add(2, "Class Time");
    this._gamePeriod.Add(3, "Lunch Time");
    this._gamePeriod.Add(4, "Class Time");
    this._gamePeriod.Add(5, "Cleaning Time");
    this._gamePeriod.Add(6, "After School");
    this._createdDictionary = true;
  }

  private IEnumerator RichPresenceUpdate()
  {
    while (this._updateRichPresence)
    {
      yield return (object) new WaitForSeconds(this._updateRate);
      this.UpdateRichPresenceInfo();
    }
  }

  private void OnDisable()
  {
    if (this._discord == null)
      return;
    this._discord.Dispose();
  }
}
