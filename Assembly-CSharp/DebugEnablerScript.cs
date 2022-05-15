using System;
using UnityEngine;

// Token: 0x02000277 RID: 631
public class DebugEnablerScript : MonoBehaviour
{
	// Token: 0x06001365 RID: 4965 RVA: 0x000AFA24 File Offset: 0x000ADC24
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

	// Token: 0x06001366 RID: 4966 RVA: 0x000AFA7C File Offset: 0x000ADC7C
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

	// Token: 0x04001C36 RID: 7222
	public GameObject StandWeapons;

	// Token: 0x04001C37 RID: 7223
	public GameObject VoidGoddess;

	// Token: 0x04001C38 RID: 7224
	public GameObject MurderKit;

	// Token: 0x04001C39 RID: 7225
	public GameObject Memes;

	// Token: 0x04001C3A RID: 7226
	public GameObject Keys;

	// Token: 0x04001C3B RID: 7227
	public DebugMenuScript DebugMenu;

	// Token: 0x04001C3C RID: 7228
	public YandereScript Yandere;

	// Token: 0x04001C3D RID: 7229
	public SkullScript Skull;

	// Token: 0x04001C3E RID: 7230
	public PrayScript Turtle;

	// Token: 0x04001C3F RID: 7231
	public DoorScript MemeClosetDoor;

	// Token: 0x04001C40 RID: 7232
	public PromptScript Prompt;

	// Token: 0x04001C41 RID: 7233
	public bool Editor;

	// Token: 0x04001C42 RID: 7234
	public int Spaces;
}
