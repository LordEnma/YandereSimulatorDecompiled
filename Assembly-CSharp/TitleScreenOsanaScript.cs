using System;
using UnityEngine;

// Token: 0x02000483 RID: 1155
public class TitleScreenOsanaScript : MonoBehaviour
{
	// Token: 0x06001F12 RID: 7954 RVA: 0x001B7A78 File Offset: 0x001B5C78
	private void Start()
	{
		if (GameGlobals.SpecificEliminationID > 0)
		{
			this.NewTitleScreen.ExtrasLabel.alpha = 1f;
			this.DeadOsanas[GameGlobals.SpecificEliminationID].SetActive(true);
		}
	}

	// Token: 0x040040C3 RID: 16579
	public NewTitleScreenScript NewTitleScreen;

	// Token: 0x040040C4 RID: 16580
	public Animation CharacterAnimation;

	// Token: 0x040040C5 RID: 16581
	public GameObject BloodPool;

	// Token: 0x040040C6 RID: 16582
	public GameObject[] DeadOsanas;
}
