using System.Collections;
using System.Collections.Generic;
using Discord;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiscordRPC : MonoBehaviour
{
	private global::Discord.Discord _discord;

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
		if (base.enabled)
		{
			Object.DontDestroyOnLoad(base.gameObject);
			if (_applicationID != string.Empty)
			{
				_discord = new global::Discord.Discord(long.Parse(_applicationID), 1uL);
				UpdateActivity();
			}
			else
			{
				Debug.Log("An error has occurred. You probably didn't set the Application ID.");
			}
			StartCoroutine(RichPresenceUpdate());
		}
	}

	private void Update()
	{
		if (_discord != null)
		{
			_discord.RunCallbacks();
		}
	}

	private void UpdateRichPresenceInfo()
	{
		if (SceneManager.GetActiveScene().name == "SchoolScene" && _clockScript == null)
		{
			_clockScript = Object.FindObjectOfType<ClockScript>();
		}
		UpdateActivity();
	}

	private void UpdateActivity()
	{
		_currentScene = SceneManager.GetActiveScene().name;
		_activity = _discord.GetActivityManager();
		Activity activity = default(Activity);
		activity.Assets.LargeImage = _boxArtImage;
		activity.Assets.LargeText = _boxArtText;
		activity.Details = _details;
		activity.State = GetSceneDescription();
		Activity activity2 = activity;
		_activity.UpdateActivity(activity2, delegate(Result RichPresenceResult)
		{
			if (RichPresenceResult != 0)
			{
				Debug.Log("Error! Connection Error (" + RichPresenceResult.ToString() + ")");
			}
		});
	}

	private string GetSceneDescription()
	{
		UpdateSceneDescription();
		if (_currentScene == "SchoolScene")
		{
			string text = (MissionModeGlobals.MissionMode ? ", Mission Mode" : string.Empty);
			return string.Format("{0}, {1}, {2}, {3}{4}", _sceneDescription["SchoolScene"], _clockScript.TimeLabel.text, _gamePeriod[_clockScript.Period], _gameWeekday[_clockScript.Weekday], text);
		}
		if (_sceneDescription.ContainsKey(_currentScene))
		{
			return _sceneDescription[_currentScene];
		}
		return "No description available yet.";
	}

	private void UpdateSceneDescription()
	{
		if (!_createdDictionary)
		{
			_sceneDescription.Add("ResolutionScene", "Setting the resolution!");
			_sceneDescription.Add("WelcomeScene", "Launching the game!");
			_sceneDescription.Add("SponsorScene", "Checking out the sponsors!");
			_sceneDescription.Add("NewTitleScene", "At the title screen!");
			_sceneDescription.Add("SenpaiScene", "Customizing Senpai!");
			_sceneDescription.Add("IntroScene", "Watching the Intro!");
			_sceneDescription.Add("NewIntroScene", "Watching the Intro!");
			_sceneDescription.Add("PhoneScene", "Texting with Info-Chan!");
			_sceneDescription.Add("CalendarScene", "Checking out the Calendar!");
			_sceneDescription.Add("HomeScene", "Chilling at home!");
			_sceneDescription.Add("LoadingScene", "Now Loading!");
			_sceneDescription.Add("SchoolScene", "At School");
			_sceneDescription.Add("YanvaniaTitleScene", "Beginning Yanvania: Senpai of the Night!");
			_sceneDescription.Add("YanvaniaScene", "Playing Yanvania: Senpai of the Night!");
			_sceneDescription.Add("LivingRoomScene", "Preparing to befriend or betray  Osana!");
			_sceneDescription.Add("MissionModeScene", "Accepting a mission!");
			_sceneDescription.Add("VeryFunScene", "??????????");
			_sceneDescription.Add("CreditsScene", "Viewing the credits!");
			_sceneDescription.Add("MiyukiTitleScene", "Beginning Magical Girl Pretty Miyuki!");
			_sceneDescription.Add("MiyukiGameplayScene", "Playing Magical Girl Pretty Miyuki!");
			_sceneDescription.Add("MiyukiThanksScene", "Finishing Magical Girl Pretty Miyuki!");
			_sceneDescription.Add("RhythmMinigameScene", "Jamming out with the Light Music Club!");
			_sceneDescription.Add("LifeNoteScene", "Watching an episode of Life Note!");
			_sceneDescription.Add("YancordScene", "Chatting over Yancord!");
			_sceneDescription.Add("MaidMenuScene", "Getting ready to be cute at a maid cafe!");
			_sceneDescription.Add("MaidGameScene", "Being a cute maid! MOE MOE KYUN!");
			_sceneDescription.Add("StreetScene", "Chilling in town!");
			_sceneDescription.Add("BusStopScene", "Watching Senpai meet Amai!");
			_sceneDescription.Add("PostCreditsScene", "Eavesdropping on the headmaster!");
			_sceneDescription.Add("DiscordScene", "Awaiting Verification");
			_sceneDescription.Add("OsanaJokeScene", "Killing Osana at long last!");
			_sceneDescription.Add("ThanksForPlayingScene", "Just beat the Osana demo!");
			_sceneDescription.Add("StalkerHouseScene", "Sneaking through a stalker's house!");
			_sceneDescription.Add("GenocideScene", "Successfully committed genocide!");
			_sceneDescription.Add("RivalRejectionProgressScene", "Making Senpai reject a confession!");
			_sceneDescription.Add("EightiesCutsceneScene", "Listening to Ryoba talk!");
			_sceneDescription.Add("CourtroomScene", "Awaiting the judge's verdict!");
			_sceneDescription.Add("TrueEndingScene", "Witnessing the true ending!");
			_sceneDescription.Add("AsylumScene", "Sneaking through a spooky asylum!");
			_sceneDescription.Add("AbductionScene", "Watching an abduction take place!");
			_sceneDescription.Add("WeekSelectScene", "Deciding what week to skip to!");
			_gameWeekday.Add(0, " Monday");
			_gameWeekday.Add(1, "Monday");
			_gameWeekday.Add(2, "Tuesday");
			_gameWeekday.Add(3, "Wednesday");
			_gameWeekday.Add(4, "Thursday");
			_gameWeekday.Add(5, "Friday");
			_gamePeriod.Add(0, " Before Class");
			_gamePeriod.Add(1, "Before Class");
			_gamePeriod.Add(2, "Class Time");
			_gamePeriod.Add(3, "Lunch Time");
			_gamePeriod.Add(4, "Class Time");
			_gamePeriod.Add(5, "Cleaning Time");
			_gamePeriod.Add(6, "After School");
			_createdDictionary = true;
		}
	}

	private IEnumerator RichPresenceUpdate()
	{
		while (_updateRichPresence)
		{
			yield return new WaitForSeconds(_updateRate);
			UpdateRichPresenceInfo();
		}
	}

	private void OnDisable()
	{
		if (_discord != null)
		{
			_discord.Dispose();
		}
	}
}
