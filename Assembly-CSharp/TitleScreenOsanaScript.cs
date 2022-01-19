using System;
using UnityEngine;

// Token: 0x02000479 RID: 1145
public class TitleScreenOsanaScript : MonoBehaviour
{
	// Token: 0x06001EC6 RID: 7878 RVA: 0x001B0AB0 File Offset: 0x001AECB0
	private void Start()
	{
		if (GameGlobals.SpecificEliminationID > 0)
		{
			this.NewTitleScreen.ExtrasLabel.alpha = 1f;
			Debug.Log("TitleScreenOsanaScript is enabling the Extras menu.");
			this.DeadOsanas[GameGlobals.SpecificEliminationID].SetActive(true);
		}
	}

	// Token: 0x04003FE1 RID: 16353
	public NewTitleScreenScript NewTitleScreen;

	// Token: 0x04003FE2 RID: 16354
	public Animation CharacterAnimation;

	// Token: 0x04003FE3 RID: 16355
	public GameObject BloodPool;

	// Token: 0x04003FE4 RID: 16356
	public GameObject[] DeadOsanas;
}
