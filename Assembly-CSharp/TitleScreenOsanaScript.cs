using System;
using UnityEngine;

// Token: 0x0200047B RID: 1147
public class TitleScreenOsanaScript : MonoBehaviour
{
	// Token: 0x06001EDF RID: 7903 RVA: 0x001B2B64 File Offset: 0x001B0D64
	private void Start()
	{
		if (GameGlobals.SpecificEliminationID > 0)
		{
			this.NewTitleScreen.ExtrasLabel.alpha = 1f;
			this.DeadOsanas[GameGlobals.SpecificEliminationID].SetActive(true);
		}
	}

	// Token: 0x04004022 RID: 16418
	public NewTitleScreenScript NewTitleScreen;

	// Token: 0x04004023 RID: 16419
	public Animation CharacterAnimation;

	// Token: 0x04004024 RID: 16420
	public GameObject BloodPool;

	// Token: 0x04004025 RID: 16421
	public GameObject[] DeadOsanas;
}
