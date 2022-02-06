using System;
using UnityEngine;

// Token: 0x02000479 RID: 1145
public class TitleScreenOsanaScript : MonoBehaviour
{
	// Token: 0x06001ECC RID: 7884 RVA: 0x001B14B4 File Offset: 0x001AF6B4
	private void Start()
	{
		if (GameGlobals.SpecificEliminationID > 0)
		{
			this.NewTitleScreen.ExtrasLabel.alpha = 1f;
			Debug.Log("TitleScreenOsanaScript is enabling the Extras menu.");
			this.DeadOsanas[GameGlobals.SpecificEliminationID].SetActive(true);
		}
	}

	// Token: 0x04003FF2 RID: 16370
	public NewTitleScreenScript NewTitleScreen;

	// Token: 0x04003FF3 RID: 16371
	public Animation CharacterAnimation;

	// Token: 0x04003FF4 RID: 16372
	public GameObject BloodPool;

	// Token: 0x04003FF5 RID: 16373
	public GameObject[] DeadOsanas;
}
