using System;
using UnityEngine;

// Token: 0x0200047E RID: 1150
public class TitleScreenOsanaScript : MonoBehaviour
{
	// Token: 0x06001EF1 RID: 7921 RVA: 0x001B42B4 File Offset: 0x001B24B4
	private void Start()
	{
		if (GameGlobals.SpecificEliminationID > 0)
		{
			this.NewTitleScreen.ExtrasLabel.alpha = 1f;
			this.DeadOsanas[GameGlobals.SpecificEliminationID].SetActive(true);
		}
	}

	// Token: 0x0400406D RID: 16493
	public NewTitleScreenScript NewTitleScreen;

	// Token: 0x0400406E RID: 16494
	public Animation CharacterAnimation;

	// Token: 0x0400406F RID: 16495
	public GameObject BloodPool;

	// Token: 0x04004070 RID: 16496
	public GameObject[] DeadOsanas;
}
