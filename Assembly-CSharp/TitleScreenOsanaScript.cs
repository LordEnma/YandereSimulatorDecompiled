using System;
using UnityEngine;

// Token: 0x02000479 RID: 1145
public class TitleScreenOsanaScript : MonoBehaviour
{
	// Token: 0x06001EC7 RID: 7879 RVA: 0x001B0F88 File Offset: 0x001AF188
	private void Start()
	{
		if (GameGlobals.SpecificEliminationID > 0)
		{
			this.NewTitleScreen.ExtrasLabel.alpha = 1f;
			Debug.Log("TitleScreenOsanaScript is enabling the Extras menu.");
			this.DeadOsanas[GameGlobals.SpecificEliminationID].SetActive(true);
		}
	}

	// Token: 0x04003FE9 RID: 16361
	public NewTitleScreenScript NewTitleScreen;

	// Token: 0x04003FEA RID: 16362
	public Animation CharacterAnimation;

	// Token: 0x04003FEB RID: 16363
	public GameObject BloodPool;

	// Token: 0x04003FEC RID: 16364
	public GameObject[] DeadOsanas;
}
