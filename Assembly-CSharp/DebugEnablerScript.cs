using System;
using UnityEngine;

// Token: 0x02000275 RID: 629
public class DebugEnablerScript : MonoBehaviour
{
	// Token: 0x06001357 RID: 4951 RVA: 0x000AE868 File Offset: 0x000ACA68
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

	// Token: 0x06001358 RID: 4952 RVA: 0x000AE8C0 File Offset: 0x000ACAC0
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

	// Token: 0x04001C05 RID: 7173
	public GameObject StandWeapons;

	// Token: 0x04001C06 RID: 7174
	public GameObject VoidGoddess;

	// Token: 0x04001C07 RID: 7175
	public GameObject MurderKit;

	// Token: 0x04001C08 RID: 7176
	public GameObject Memes;

	// Token: 0x04001C09 RID: 7177
	public GameObject Keys;

	// Token: 0x04001C0A RID: 7178
	public DebugMenuScript DebugMenu;

	// Token: 0x04001C0B RID: 7179
	public YandereScript Yandere;

	// Token: 0x04001C0C RID: 7180
	public SkullScript Skull;

	// Token: 0x04001C0D RID: 7181
	public PrayScript Turtle;

	// Token: 0x04001C0E RID: 7182
	public DoorScript MemeClosetDoor;

	// Token: 0x04001C0F RID: 7183
	public PromptScript Prompt;

	// Token: 0x04001C10 RID: 7184
	public bool Editor;

	// Token: 0x04001C11 RID: 7185
	public int Spaces;
}
