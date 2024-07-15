using UnityEngine;

public class DebugEnablerScript : MonoBehaviour
{
	public GameObject StandWeapons;

	public GameObject VoidGoddess;

	public GameObject MurderKit;

	public GameObject Llama;

	public GameObject Memes;

	public GameObject Keys;

	public DebugMenuScript DebugMenu;

	public YandereScript Yandere;

	public SkullScript Skull;

	public PrayScript Turtle;

	public DoorScript MemeClosetDoor;

	public PromptScript Prompt;

	public bool Editor;

	public int Spaces;

	private void Start()
	{
		_ = Editor;
		StandWeapons.SetActive(value: false);
		Keys.SetActive(value: false);
		if (MissionModeGlobals.MissionMode || GameGlobals.AlphabetMode || GameGlobals.LoveSick || GameGlobals.KokonaTutorial || GameGlobals.EightiesTutorial || ChallengeGlobals.KnifeOnly || ChallengeGlobals.NoAlerts || ChallengeGlobals.NoBag || ChallengeGlobals.NoFriends || ChallengeGlobals.NoGaming || ChallengeGlobals.NoInfo || ChallengeGlobals.NoLaugh || ChallengeGlobals.RivalsOnly)
		{
			if (GameGlobals.Debug || Editor)
			{
				base.gameObject.SetActive(value: false);
			}
			else
			{
				Object.Destroy(base.gameObject);
			}
		}
		if (GameGlobals.Debug || Editor)
		{
			Editor = true;
			EnableDebug();
		}
	}

	public void EnableDebug()
	{
		Yandere.NotificationManager.CustomText = "Debug Commands Enabled!";
		Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
		Debug.Log("Enabling the use of debug commands.");
		Yandere.Inventory.PantyShots = 100;
		Yandere.NoDebug = false;
		Yandere.EggBypass = 10;
		Yandere.Egg = false;
		StandWeapons.SetActive(value: true);
		VoidGoddess.SetActive(value: true);
		MurderKit.SetActive(value: true);
		Llama.SetActive(value: true);
		Memes.SetActive(value: true);
		if (!GameGlobals.Eighties)
		{
			Keys.SetActive(value: true);
		}
		DebugMenu.MissionMode = false;
		DebugMenu.NoDebug = false;
		Yandere.NoDebug = false;
		Turtle.enabled = true;
		MemeClosetDoor.Prompt.enabled = true;
		MemeClosetDoor.enabled = true;
		MemeClosetDoor.Locked = false;
		base.gameObject.SetActive(value: false);
		Skull.Prompt.enabled = true;
		Skull.enabled = true;
		if (!GameGlobals.Eighties && Yandere.StudentManager.Students[37] != null)
		{
			Yandere.StudentManager.Students[37].Cosmetic.HairRenderer.gameObject.GetComponent<BandanaScript>().enabled = true;
		}
	}
}
