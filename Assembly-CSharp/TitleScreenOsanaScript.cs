using System;
using UnityEngine;

// Token: 0x02000482 RID: 1154
public class TitleScreenOsanaScript : MonoBehaviour
{
	// Token: 0x06001F09 RID: 7945 RVA: 0x001B6708 File Offset: 0x001B4908
	private void Start()
	{
		if (GameGlobals.SpecificEliminationID > 0)
		{
			this.NewTitleScreen.ExtrasLabel.alpha = 1f;
			this.DeadOsanas[GameGlobals.SpecificEliminationID].SetActive(true);
		}
	}

	// Token: 0x040040AD RID: 16557
	public NewTitleScreenScript NewTitleScreen;

	// Token: 0x040040AE RID: 16558
	public Animation CharacterAnimation;

	// Token: 0x040040AF RID: 16559
	public GameObject BloodPool;

	// Token: 0x040040B0 RID: 16560
	public GameObject[] DeadOsanas;
}
