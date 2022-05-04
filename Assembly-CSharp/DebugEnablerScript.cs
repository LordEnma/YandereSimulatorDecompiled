using System;
using UnityEngine;

// Token: 0x02000276 RID: 630
public class DebugEnablerScript : MonoBehaviour
{
	// Token: 0x06001363 RID: 4963 RVA: 0x000AF7A8 File Offset: 0x000AD9A8
	private void Start()
	{
		if (MissionModeGlobals.MissionMode || GameGlobals.AlphabetMode || GameGlobals.LoveSick || (!GameGlobals.Eighties && DateGlobals.Week == 2))
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		if (GameGlobals.Debug || this.Editor)
		{
			this.Editor = true;
			this.EnableDebug();
		}
	}

	// Token: 0x06001364 RID: 4964 RVA: 0x000AF800 File Offset: 0x000ADA00
	public void EnableDebug()
	{
		this.Yandere.NotificationManager.CustomText = "Debug Commands Enabled!";
		this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
		Debug.Log("Enabling the use of debug commands.");
		this.Yandere.Inventory.PantyShots = 100;
		this.Yandere.NoDebug = false;
		this.Yandere.EggBypass = 10;
		this.Yandere.Egg = false;
		this.StandWeapons.SetActive(true);
		this.VoidGoddess.SetActive(true);
		this.MurderKit.SetActive(true);
		this.Memes.SetActive(true);
		this.Keys.SetActive(true);
		this.DebugMenu.MissionMode = false;
		this.DebugMenu.NoDebug = false;
		this.Yandere.NoDebug = false;
		this.Turtle.enabled = true;
		this.MemeClosetDoor.Locked = false;
		base.gameObject.SetActive(false);
		this.Skull.Prompt.enabled = true;
		this.Skull.enabled = true;
		GameGlobals.Debug = true;
	}

	// Token: 0x04001C2F RID: 7215
	public GameObject StandWeapons;

	// Token: 0x04001C30 RID: 7216
	public GameObject VoidGoddess;

	// Token: 0x04001C31 RID: 7217
	public GameObject MurderKit;

	// Token: 0x04001C32 RID: 7218
	public GameObject Memes;

	// Token: 0x04001C33 RID: 7219
	public GameObject Keys;

	// Token: 0x04001C34 RID: 7220
	public DebugMenuScript DebugMenu;

	// Token: 0x04001C35 RID: 7221
	public YandereScript Yandere;

	// Token: 0x04001C36 RID: 7222
	public SkullScript Skull;

	// Token: 0x04001C37 RID: 7223
	public PrayScript Turtle;

	// Token: 0x04001C38 RID: 7224
	public DoorScript MemeClosetDoor;

	// Token: 0x04001C39 RID: 7225
	public PromptScript Prompt;

	// Token: 0x04001C3A RID: 7226
	public bool Editor;

	// Token: 0x04001C3B RID: 7227
	public int Spaces;
}
