using System;
using UnityEngine;

// Token: 0x02000478 RID: 1144
public class TitleScreenOsanaScript : MonoBehaviour
{
	// Token: 0x06001EC4 RID: 7876 RVA: 0x001AFDE0 File Offset: 0x001ADFE0
	private void Start()
	{
		if (GameGlobals.SpecificEliminationID > 0)
		{
			this.NewTitleScreen.ExtrasLabel.alpha = 1f;
			Debug.Log("TitleScreenOsanaScript is enabling the Extras menu.");
			this.DeadOsanas[GameGlobals.SpecificEliminationID].SetActive(true);
		}
	}

	// Token: 0x04003FDA RID: 16346
	public NewTitleScreenScript NewTitleScreen;

	// Token: 0x04003FDB RID: 16347
	public Animation CharacterAnimation;

	// Token: 0x04003FDC RID: 16348
	public GameObject BloodPool;

	// Token: 0x04003FDD RID: 16349
	public GameObject[] DeadOsanas;
}
