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
		CompileDictionaries();
		_discordController = GetComponent<DiscordController>();
		Object.DontDestroyOnLoad(base.gameObject);
		_discordController.enabled = false;
		_discordController.presence.state = GetSceneDescription();
		_discordController.presence.details = "Senpai... will... be... mine...";
		_discordController.presence.largeImageKey = "boxart";
		_discordController.presence.largeImageText = "This might be the game's box art one day!";
		_discordController.enabled = true;
		DiscordRpc.UpdatePresence(_discordController.presence);
		InvokeRepeating("UpdatePresence", 0f, 10f);
	}

	private void OnLevelWasLoaded(int level)
	{
		if (level == 12)
		{
			_clockScript = Object.FindObjectOfType<ClockScript>();
		}
		UpdatePresence();
	}

	private void UpdatePresence()
	{
		_discordController.presence.state = GetSceneDescription();
		DiscordRpc.UpdatePresence(_discordController.presence);
	}

	private void CompileDictionaries()
	{
		_weekdays.Add(1, "Monday");
		_weekdays.Add(2, "Tuesday");
		_weekdays.Add(3, "Wednesday");
		_weekdays.Add(4, "Thursday");
		_weekdays.Add(5, "Friday");
		_periods.Add(1, "Before Class");
		_periods.Add(2, "Class Time");
		_periods.Add(3, "Lunch Time");
		_periods.Add(4, "Class Time");
		_periods.Add(5, "Cleaning Time");
		_periods.Add(6, "After School");
		_sceneDescriptions.Add("ResolutionScene", "Setting the resolution!");
		_sceneDescriptions.Add("WelcomeScene", "Launching the game!");
		_sceneDescriptions.Add("SponsorScene", "Checking out the sponsors!");
		_sceneDescriptions.Add("NewTitleScene", "At the title screen!");
		_sceneDescriptions.Add("SenpaiScene", "Customizing Senpai!");
		_sceneDescriptions.Add("IntroScene", "Watching the Intro!");
		_sceneDescriptions.Add("NewIntroScene", "Watching the Intro!");
		_sceneDescriptions.Add("PhoneScene", "Texting with Info-Chan!");
		_sceneDescriptions.Add("CalendarScene", "Checking out the Calendar!");
		_sceneDescriptions.Add("HomeScene", "Chilling at home!");
		_sceneDescriptions.Add("LoadingScene", "Now Loading!");
		_sceneDescriptions.Add("SchoolScene", "At School");
		_sceneDescriptions.Add("YanvaniaTitleScene", "Beginning Yanvania: Senpai of the Night!");
		_sceneDescriptions.Add("YanvaniaScene", "Playing Yanvania: Senpai of the Night!");
		_sceneDescriptions.Add("LivingRoomScene", "Preparing to befriend or betray  Osana!");
		_sceneDescriptions.Add("MissionModeScene", "Accepting a mission!");
		_sceneDescriptions.Add("VeryFunScene", "??????????");
		_sceneDescriptions.Add("CreditsScene", "Viewing the credits!");
		_sceneDescriptions.Add("MiyukiTitleScene", "Beginning Magical Girl Pretty Miyuki!");
		_sceneDescriptions.Add("MiyukiGameplayScene", "Playing Magical Girl Pretty Miyuki!");
		_sceneDescriptions.Add("MiyukiThanksScene", "Finishing Magical Girl Pretty Miyuki!");
		_sceneDescriptions.Add("RhythmMinigameScene", "Jamming out with the Light Music Club!");
		_sceneDescriptions.Add("LifeNoteScene", "Watching an episode of Life Note!");
		_sceneDescriptions.Add("YancordScene", "Chatting over Yancord!");
		_sceneDescriptions.Add("MaidMenuScene", "Getting ready to be cute at a maid cafe!");
		_sceneDescriptions.Add("MaidGameScene", "Being a cute maid! MOE MOE KYUN!");
		_sceneDescriptions.Add("StreetScene", "Chilling in town!");
		_sceneDescriptions.Add("BusStopScene", "Watching Senpai meet Amai!");
		_sceneDescriptions.Add("PostCreditsScene", "Eavesdropping on the headmaster!");
		_sceneDescriptions.Add("DiscordScene", "Awaiting Verification");
		_sceneDescriptions.Add("OsanaJoke", "Killing Osana at long last!");
		_sceneDescriptions.Add("CustomMode", "Setting up a Custom Mode playthrough!");
	}

	private string GetSceneDescription()
	{
		string text = SceneManager.GetActiveScene().name;
		if (text != null && text == "SchoolScene")
		{
			string text2 = (MissionModeGlobals.MissionMode ? ", Mission Mode" : string.Empty);
			return string.Format("{0}, {1}, {2}, {3}{4}", _sceneDescriptions["SchoolScene"], _clockScript.TimeLabel.text, _periods[_clockScript.Period], _weekdays[_clockScript.Weekday], text2);
		}
		if (_sceneDescriptions.ContainsKey(text))
		{
			return _sceneDescriptions[text];
		}
		return "No description available yet.";
	}
}
