using System;
using UnityEngine;

// Token: 0x02000482 RID: 1154
public class TitleScreenOsanaScript : MonoBehaviour
{
	// Token: 0x06001F03 RID: 7939 RVA: 0x001B5D30 File Offset: 0x001B3F30
	private void Start()
	{
		if (GameGlobals.SpecificEliminationID > 0)
		{
			this.NewTitleScreen.ExtrasLabel.alpha = 1f;
			this.DeadOsanas[GameGlobals.SpecificEliminationID].SetActive(true);
		}
	}

	// Token: 0x0400409D RID: 16541
	public NewTitleScreenScript NewTitleScreen;

	// Token: 0x0400409E RID: 16542
	public Animation CharacterAnimation;

	// Token: 0x0400409F RID: 16543
	public GameObject BloodPool;

	// Token: 0x040040A0 RID: 16544
	public GameObject[] DeadOsanas;
}
