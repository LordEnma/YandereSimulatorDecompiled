using System;
using UnityEngine;

// Token: 0x02000276 RID: 630
public class DebugEnablerScript : MonoBehaviour
{
	// Token: 0x0600135B RID: 4955 RVA: 0x000AE824 File Offset: 0x000ACA24
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

	// Token: 0x0600135C RID: 4956 RVA: 0x000AE87C File Offset: 0x000ACA7C
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

	// Token: 0x04001C0B RID: 7179
	public GameObject StandWeapons;

	// Token: 0x04001C0C RID: 7180
	public GameObject VoidGoddess;

	// Token: 0x04001C0D RID: 7181
	public GameObject MurderKit;

	// Token: 0x04001C0E RID: 7182
	public GameObject Memes;

	// Token: 0x04001C0F RID: 7183
	public GameObject Keys;

	// Token: 0x04001C10 RID: 7184
	public DebugMenuScript DebugMenu;

	// Token: 0x04001C11 RID: 7185
	public YandereScript Yandere;

	// Token: 0x04001C12 RID: 7186
	public SkullScript Skull;

	// Token: 0x04001C13 RID: 7187
	public PrayScript Turtle;

	// Token: 0x04001C14 RID: 7188
	public DoorScript MemeClosetDoor;

	// Token: 0x04001C15 RID: 7189
	public PromptScript Prompt;

	// Token: 0x04001C16 RID: 7190
	public bool Editor;

	// Token: 0x04001C17 RID: 7191
	public int Spaces;
}
