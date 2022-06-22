// Decompiled with JetBrains decompiler
// Type: RichPresenceHelper
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RichPresenceHelper : MonoBehaviour
{
  private DiscordController _discordController;
  private ClockScript _clockScript;
  private Dictionary<int, string> _weekdays = new Dictionary<int, string>();
  private Dictionary<int, string> _periods = new Dictionary<int, string>();
  private Dictionary<string, string> _sceneDescriptions = new Dictionary<string, string>();

  private void Start()
  {
    this.CompileDictionaries();
    this._discordController = this.GetComponent<DiscordController>();
    Object.DontDestroyOnLoad((Object) this.gameObject);
    this._discordController.enabled = false;
    this._discordController.presence.state = this.GetSceneDescription();
    this._discordController.presence.details = "Senpai... will... be... mine...";
    this._discordController.presence.largeImageKey = "boxart";
    this._discordController.presence.largeImageText = "This might be the game's box art one day!";
    this._discordController.enabled = true;
    DiscordRpc.UpdatePresence(this._discordController.presence);
    this.InvokeRepeating("UpdatePresence", 0.0f, 10f);
  }

  private void OnLevelWasLoaded(int level)
  {
    if (level == 12)
      this._clockScript = Object.FindObjectOfType<ClockScript>();
    this.UpdatePresence();
  }

  private void UpdatePresence()
  {
    this._discordController.presence.state = this.GetSceneDescription();
    DiscordRpc.UpdatePresence(this._discordController.presence);
  }

  private void CompileDictionaries()
  {
    this._weekdays.Add(1, "Monday");
    this._weekdays.Add(2, "Tuesday");
    this._weekdays.Add(3, "Wednesday");
    this._weekdays.Add(4, "Thursday");
    this._weekdays.Add(5, "Friday");
    this._periods.Add(1, "Before Class");
    this._periods.Add(2, "Class Time");
    this._periods.Add(3, "Lunch Time");
    this._periods.Add(4, "Class Time");
    this._periods.Add(5, "Cleaning Time");
    this._periods.Add(6, "After School");
    this._sceneDescriptions.Add("ResolutionScene", "Setting the resolution!");
    this._sceneDescriptions.Add("WelcomeScene", "Launching the game!");
    this._sceneDescriptions.Add("SponsorScene", "Checking out the sponsors!");
    this._sceneDescriptions.Add("NewTitleScene", "At the title screen!");
    this._sceneDescriptions.Add("SenpaiScene", "Customizing Senpai!");
    this._sceneDescriptions.Add("IntroScene", "Watching the Intro!");
    this._sceneDescriptions.Add("NewIntroScene", "Watching the Intro!");
    this._sceneDescriptions.Add("PhoneScene", "Texting with Info-Chan!");
    this._sceneDescriptions.Add("CalendarScene", "Checking out the Calendar!");
    this._sceneDescriptions.Add("HomeScene", "Chilling at home!");
    this._sceneDescriptions.Add("LoadingScene", "Now Loading!");
    this._sceneDescriptions.Add("SchoolScene", "At School");
    this._sceneDescriptions.Add("YanvaniaTitleScene", "Beginning Yanvania: Senpai of the Night!");
    this._sceneDescriptions.Add("YanvaniaScene", "Playing Yanvania: Senpai of the Night!");
    this._sceneDescriptions.Add("LivingRoomScene", "Preparing to befriend or betray  Osana!");
    this._sceneDescriptions.Add("MissionModeScene", "Accepting a mission!");
    this._sceneDescriptions.Add("VeryFunScene", "??????????");
    this._sceneDescriptions.Add("CreditsScene", "Viewing the credits!");
    this._sceneDescriptions.Add("MiyukiTitleScene", "Beginning Magical Girl Pretty Miyuki!");
    this._sceneDescriptions.Add("MiyukiGameplayScene", "Playing Magical Girl Pretty Miyuki!");
    this._sceneDescriptions.Add("MiyukiThanksScene", "Finishing Magical Girl Pretty Miyuki!");
    this._sceneDescriptions.Add("RhythmMinigameScene", "Jamming out with the Light Music Club!");
    this._sceneDescriptions.Add("LifeNoteScene", "Watching an episode of Life Note!");
    this._sceneDescriptions.Add("YancordScene", "Chatting over Yancord!");
    this._sceneDescriptions.Add("MaidMenuScene", "Getting ready to be cute at a maid cafe!");
    this._sceneDescriptions.Add("MaidGameScene", "Being a cute maid! MOE MOE KYUN!");
    this._sceneDescriptions.Add("StreetScene", "Chilling in town!");
    this._sceneDescriptions.Add("BusStopScene", "Watching Senpai meet Amai!");
    this._sceneDescriptions.Add("PostCreditsScene", "Eavesdropping on the headmaster!");
    this._sceneDescriptions.Add("DiscordScene", "Awaiting Verification");
    this._sceneDescriptions.Add("OsanaJoke", "Killing Osana at long last!");
  }

  private string GetSceneDescription()
  {
    string name = SceneManager.GetActiveScene().name;
    return name != null && name == "SchoolScene" ? string.Format("{0}, {1}, {2}, {3}{4}", (object) this._sceneDescriptions["SchoolScene"], (object) this._clockScript.TimeLabel.text, (object) this._periods[this._clockScript.Period], (object) this._weekdays[this._clockScript.Weekday], (object) (MissionModeGlobals.MissionMode ? ", Mission Mode" : string.Empty)) : (this._sceneDescriptions.ContainsKey(name) ? this._sceneDescriptions[name] : "No description available yet.");
  }
}
