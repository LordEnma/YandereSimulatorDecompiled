using System;
using UnityEngine;

// Token: 0x0200047A RID: 1146
public class TitleScreenOsanaScript : MonoBehaviour
{
	// Token: 0x06001ED3 RID: 7891 RVA: 0x001B18F0 File Offset: 0x001AFAF0
	private void Start()
	{
		if (GameGlobals.SpecificEliminationID > 0)
		{
			this.NewTitleScreen.ExtrasLabel.alpha = 1f;
			this.DeadOsanas[GameGlobals.SpecificEliminationID].SetActive(true);
		}
	}

	// Token: 0x04003FFB RID: 16379
	public NewTitleScreenScript NewTitleScreen;

	// Token: 0x04003FFC RID: 16380
	public Animation CharacterAnimation;

	// Token: 0x04003FFD RID: 16381
	public GameObject BloodPool;

	// Token: 0x04003FFE RID: 16382
	public GameObject[] DeadOsanas;
}
