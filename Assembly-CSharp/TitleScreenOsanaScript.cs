using System;
using UnityEngine;

// Token: 0x02000476 RID: 1142
public class TitleScreenOsanaScript : MonoBehaviour
{
	// Token: 0x06001EB9 RID: 7865 RVA: 0x001AF460 File Offset: 0x001AD660
	private void Start()
	{
		if (GameGlobals.SpecificEliminationID > 0)
		{
			this.NewTitleScreen.ExtrasLabel.alpha = 1f;
			Debug.Log("TitleScreenOsanaScript is enabling the Extras menu.");
			this.DeadOsanas[GameGlobals.SpecificEliminationID].SetActive(true);
		}
	}

	// Token: 0x04003FC6 RID: 16326
	public NewTitleScreenScript NewTitleScreen;

	// Token: 0x04003FC7 RID: 16327
	public Animation CharacterAnimation;

	// Token: 0x04003FC8 RID: 16328
	public GameObject BloodPool;

	// Token: 0x04003FC9 RID: 16329
	public GameObject[] DeadOsanas;
}
