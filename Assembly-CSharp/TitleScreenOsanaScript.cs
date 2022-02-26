using System;
using UnityEngine;

// Token: 0x0200047B RID: 1147
public class TitleScreenOsanaScript : MonoBehaviour
{
	// Token: 0x06001EDC RID: 7900 RVA: 0x001B243C File Offset: 0x001B063C
	private void Start()
	{
		if (GameGlobals.SpecificEliminationID > 0)
		{
			this.NewTitleScreen.ExtrasLabel.alpha = 1f;
			this.DeadOsanas[GameGlobals.SpecificEliminationID].SetActive(true);
		}
	}

	// Token: 0x0400400B RID: 16395
	public NewTitleScreenScript NewTitleScreen;

	// Token: 0x0400400C RID: 16396
	public Animation CharacterAnimation;

	// Token: 0x0400400D RID: 16397
	public GameObject BloodPool;

	// Token: 0x0400400E RID: 16398
	public GameObject[] DeadOsanas;
}
