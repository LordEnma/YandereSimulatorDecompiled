using System;
using UnityEngine;

// Token: 0x02000479 RID: 1145
public class TitleScreenOsanaScript : MonoBehaviour
{
	// Token: 0x06001EC9 RID: 7881 RVA: 0x001B1294 File Offset: 0x001AF494
	private void Start()
	{
		if (GameGlobals.SpecificEliminationID > 0)
		{
			this.NewTitleScreen.ExtrasLabel.alpha = 1f;
			Debug.Log("TitleScreenOsanaScript is enabling the Extras menu.");
			this.DeadOsanas[GameGlobals.SpecificEliminationID].SetActive(true);
		}
	}

	// Token: 0x04003FEF RID: 16367
	public NewTitleScreenScript NewTitleScreen;

	// Token: 0x04003FF0 RID: 16368
	public Animation CharacterAnimation;

	// Token: 0x04003FF1 RID: 16369
	public GameObject BloodPool;

	// Token: 0x04003FF2 RID: 16370
	public GameObject[] DeadOsanas;
}
