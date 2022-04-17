using System;
using System.Collections;
using System.Collections.Generic;
using Discord;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000287 RID: 647
public class DiscordRPC : MonoBehaviour
{
	// Token: 0x0600139F RID: 5023 RVA: 0x000B8480 File Offset: 0x000B6680
	private void Start()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		if (this._applicationID != string.Empty)
		{
			this._discord = new Discord(long.Parse(this._applicationID), 1UL);
			this.UpdateActivity();
		}
		else
		{
			Debug.Log("An error has occurred. You probably didn't set the Application ID.");
		}
		base.StartCoroutine(this.RichPresenceUpdate());
	}

	// Token: 0x060013A0 RID: 5024 RVA: 0x000B84E1 File Offset: 0x000B66E1
	private void Update()
	{
		if (this._discord != null)
		{
			this._discord.RunCallbacks();
		}
	}

	// Token: 0x060013A1 RID: 5025 RVA: 0x000B84F8 File Offset: 0x000B66F8
	private void UpdateRichPresenceInfo()
	{
		if (SceneManager.GetActiveScene().name == "SchoolScene" && this._clockScript == null)
		{
			this._clockScript = UnityEngine.Object.FindObjectOfType<ClockScript>();
			Debug.Log("'ClockScript' behavior found.");
		}
		this.UpdateActivity();
	}

	// Token: 0x060013A2 RID: 5026 RVA: 0x000B8548 File Offset: 0x000B6748
	private void UpdateActivity()
	{
		this._currentScene = SceneManager.GetActiveScene().name;
		this._activity = this._discord.GetActivityManager();
		Activity activity = default(Activity);
		activity.Assets.LargeImage = this._boxArtImage;
		activity.Assets.LargeText = this._boxArtText;
		activity.Details = this._details;
		activity.State = this.GetSceneDescription();
		Activity activity2 = activity;
		this._activity.UpdateActivity(activity2, delegate(Result RichPresenceResult)
		{
			if (RichPresenceResult != Result.Ok)
			{
				Debug.Log("Error! Connection Error (" + RichPresenceResult.ToString() + ")");
				return;
			}
			Debug.Log("Discord Rich Presence activated successfully!");
		});
	}

	// Token: 0x060013A3 RID: 5027 RVA: 0x000B85EC File Offset: 0x000B67EC
	private string GetSceneDescription()
	{
		this.UpdateSceneDescription();
		string currentScene = this._currentScene;
		if (currentScene != null && currentScene == "SchoolScene")
		{
			string text = MissionModeGlobals.MissionMode ? ", Mission Mode" : string.Empty;
			return string.Format("{0}, {1}, {2}, {3}{4}", new object[]
			{
				this._sceneDescription["SchoolScene"],
				this._clockScript.TimeLabel.text,
				this._gamePeriod[this._clockScript.Period],
				this._gameWeekday[this._clockScript.Weekday],
				text
			});
		}
		if (this._sceneDescription.ContainsKey(this._currentScene))
		{
			return this._sceneDescription[this._currentScene];
		}
		return "No description available yet.";
	}

	// Token: 0x060013A4 RID: 5028 RVA: 0x000B86C8 File Offset: 0x000B68C8
	private void UpdateSceneDescription()
	{
		if (!this._createdDictionary)
		{
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
	}

	// Token: 0x060013A5 RID: 5029 RVA: 0x000B8B21 File Offset: 0x000B6D21
	private IEnumerator RichPresenceUpdate()
	{
		while (this._updateRichPresence)
		{
			yield return new WaitForSeconds(this._updateRate);
			this.UpdateRichPresenceInfo();
		}
		yield break;
	}

	// Token: 0x060013A6 RID: 5030 RVA: 0x000B8B30 File Offset: 0x000B6D30
	private void OnDisable()
	{
		if (this._discord != null)
		{
			this._discord.Dispose();
		}
	}

	// Token: 0x04001D23 RID: 7459
	private Discord _discord;

	// Token: 0x04001D24 RID: 7460
	private ActivityManager _activity;

	// Token: 0x04001D25 RID: 7461
	private ClockScript _clockScript;

	// Token: 0x04001D26 RID: 7462
	[SerializeField]
	private string _applicationID = "560185502691491841";

	// Token: 0x04001D27 RID: 7463
	[SerializeField]
	private string _boxArtImage = "boxart";

	// Token: 0x04001D28 RID: 7464
	[SerializeField]
	private string _boxArtText = "This might be the game's box art one day!";

	// Token: 0x04001D29 RID: 7465
	[SerializeField]
	private string _details = "He... will... be... mine.";

	// Token: 0x04001D2A RID: 7466
	private string _currentScene;

	// Token: 0x04001D2B RID: 7467
	[SerializeField]
	private float _updateRate = 5f;

	// Token: 0x04001D2C RID: 7468
	private bool _createdDictionary;

	// Token: 0x04001D2D RID: 7469
	[SerializeField]
	private bool _updateRichPresence = true;

	// Token: 0x04001D2E RID: 7470
	[SerializeField]
	private Dictionary<string, string> _sceneDescription = new Dictionary<string, string>();

	// Token: 0x04001D2F RID: 7471
	[SerializeField]
	private Dictionary<int, string> _gamePeriod = new Dictionary<int, string>();

	// Token: 0x04001D30 RID: 7472
	[SerializeField]
	private Dictionary<int, string> _gameWeekday = new Dictionary<int, string>();
}
