using System;
using UnityEngine;

// Token: 0x02000475 RID: 1141
public class TitleScreenOsanaScript : MonoBehaviour
{
	// Token: 0x06001EAD RID: 7853 RVA: 0x001AE1DC File Offset: 0x001AC3DC
	private void Start()
	{
		if (GameGlobals.SpecificEliminationID > 0)
		{
			this.NewTitleScreen.ExtrasLabel.alpha = 1f;
			Debug.Log("TitleScreenOsanaScript is enabling the Extras menu.");
			this.DeadOsanas[GameGlobals.SpecificEliminationID].SetActive(true);
		}
	}

	// Token: 0x04003F8F RID: 16271
	public NewTitleScreenScript NewTitleScreen;

	// Token: 0x04003F90 RID: 16272
	public Animation CharacterAnimation;

	// Token: 0x04003F91 RID: 16273
	public GameObject BloodPool;

	// Token: 0x04003F92 RID: 16274
	public GameObject[] DeadOsanas;
}
