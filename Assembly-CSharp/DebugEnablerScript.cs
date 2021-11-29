using System;
using UnityEngine;

// Token: 0x02000274 RID: 628
public class DebugEnablerScript : MonoBehaviour
{
	// Token: 0x0600134F RID: 4943 RVA: 0x000ADF44 File Offset: 0x000AC144
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

	// Token: 0x06001350 RID: 4944 RVA: 0x000ADF9C File Offset: 0x000AC19C
	public void EnableDebug()
	{
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
	}

	// Token: 0x04001BDE RID: 7134
	public GameObject StandWeapons;

	// Token: 0x04001BDF RID: 7135
	public GameObject VoidGoddess;

	// Token: 0x04001BE0 RID: 7136
	public GameObject MurderKit;

	// Token: 0x04001BE1 RID: 7137
	public GameObject Memes;

	// Token: 0x04001BE2 RID: 7138
	public GameObject Keys;

	// Token: 0x04001BE3 RID: 7139
	public DebugMenuScript DebugMenu;

	// Token: 0x04001BE4 RID: 7140
	public YandereScript Yandere;

	// Token: 0x04001BE5 RID: 7141
	public PrayScript Turtle;

	// Token: 0x04001BE6 RID: 7142
	public DoorScript MemeClosetDoor;

	// Token: 0x04001BE7 RID: 7143
	public PromptScript Prompt;

	// Token: 0x04001BE8 RID: 7144
	public bool Editor;

	// Token: 0x04001BE9 RID: 7145
	public int Spaces;
}
