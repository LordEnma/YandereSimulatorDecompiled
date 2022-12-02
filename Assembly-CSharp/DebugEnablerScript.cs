using UnityEngine;

public class DebugEnablerScript : MonoBehaviour
{
	public GameObject StandWeapons;

	public GameObject VoidGoddess;

	public GameObject MurderKit;

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
		bool editor = Editor;
		StandWeapons.SetActive(false);
		Keys.SetActive(false);
		if (MissionModeGlobals.MissionMode || GameGlobals.AlphabetMode || GameGlobals.LoveSick || (!GameGlobals.Eighties && DateGlobals.Week == 2))
		{
			if (GameGlobals.Debug || Editor)
			{
				base.gameObject.SetActive(false);
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
		StandWeapons.SetActive(true);
		VoidGoddess.SetActive(true);
		MurderKit.SetActive(true);
		Memes.SetActive(true);
		if (!GameGlobals.Eighties)
		{
			Keys.SetActive(true);
		}
		DebugMenu.MissionMode = false;
		DebugMenu.NoDebug = false;
		Yandere.NoDebug = false;
		Turtle.enabled = true;
		MemeClosetDoor.Locked = false;
		base.gameObject.SetActive(false);
		Skull.Prompt.enabled = true;
		Skull.enabled = true;
	}
}
