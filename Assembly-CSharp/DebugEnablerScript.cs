using System;
using UnityEngine;

// Token: 0x02000276 RID: 630
public class DebugEnablerScript : MonoBehaviour
{
	// Token: 0x0600135F RID: 4959 RVA: 0x000AF344 File Offset: 0x000AD544
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

	// Token: 0x06001360 RID: 4960 RVA: 0x000AF39C File Offset: 0x000AD59C
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

	// Token: 0x04001C27 RID: 7207
	public GameObject StandWeapons;

	// Token: 0x04001C28 RID: 7208
	public GameObject VoidGoddess;

	// Token: 0x04001C29 RID: 7209
	public GameObject MurderKit;

	// Token: 0x04001C2A RID: 7210
	public GameObject Memes;

	// Token: 0x04001C2B RID: 7211
	public GameObject Keys;

	// Token: 0x04001C2C RID: 7212
	public DebugMenuScript DebugMenu;

	// Token: 0x04001C2D RID: 7213
	public YandereScript Yandere;

	// Token: 0x04001C2E RID: 7214
	public SkullScript Skull;

	// Token: 0x04001C2F RID: 7215
	public PrayScript Turtle;

	// Token: 0x04001C30 RID: 7216
	public DoorScript MemeClosetDoor;

	// Token: 0x04001C31 RID: 7217
	public PromptScript Prompt;

	// Token: 0x04001C32 RID: 7218
	public bool Editor;

	// Token: 0x04001C33 RID: 7219
	public int Spaces;
}
