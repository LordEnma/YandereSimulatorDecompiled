using System;
using UnityEngine;

// Token: 0x02000484 RID: 1156
public class TitleScreenOsanaScript : MonoBehaviour
{
	// Token: 0x06001F1B RID: 7963 RVA: 0x001B8CEC File Offset: 0x001B6EEC
	private void Start()
	{
		if (GameGlobals.SpecificEliminationID > 0)
		{
			this.NewTitleScreen.ExtrasLabel.alpha = 1f;
			this.DeadOsanas[GameGlobals.SpecificEliminationID].SetActive(true);
		}
	}

	// Token: 0x040040E1 RID: 16609
	public NewTitleScreenScript NewTitleScreen;

	// Token: 0x040040E2 RID: 16610
	public Animation CharacterAnimation;

	// Token: 0x040040E3 RID: 16611
	public GameObject BloodPool;

	// Token: 0x040040E4 RID: 16612
	public GameObject[] DeadOsanas;
}
