using System;
using UnityEngine;

// Token: 0x02000481 RID: 1153
public class TitleScreenOsanaScript : MonoBehaviour
{
	// Token: 0x06001EFB RID: 7931 RVA: 0x001B5828 File Offset: 0x001B3A28
	private void Start()
	{
		if (GameGlobals.SpecificEliminationID > 0)
		{
			this.NewTitleScreen.ExtrasLabel.alpha = 1f;
			this.DeadOsanas[GameGlobals.SpecificEliminationID].SetActive(true);
		}
	}

	// Token: 0x0400409A RID: 16538
	public NewTitleScreenScript NewTitleScreen;

	// Token: 0x0400409B RID: 16539
	public Animation CharacterAnimation;

	// Token: 0x0400409C RID: 16540
	public GameObject BloodPool;

	// Token: 0x0400409D RID: 16541
	public GameObject[] DeadOsanas;
}
