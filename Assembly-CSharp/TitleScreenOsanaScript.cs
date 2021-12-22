using System;
using UnityEngine;

// Token: 0x02000476 RID: 1142
public class TitleScreenOsanaScript : MonoBehaviour
{
	// Token: 0x06001EB7 RID: 7863 RVA: 0x001AEFAC File Offset: 0x001AD1AC
	private void Start()
	{
		if (GameGlobals.SpecificEliminationID > 0)
		{
			this.NewTitleScreen.ExtrasLabel.alpha = 1f;
			Debug.Log("TitleScreenOsanaScript is enabling the Extras menu.");
			this.DeadOsanas[GameGlobals.SpecificEliminationID].SetActive(true);
		}
	}

	// Token: 0x04003FBF RID: 16319
	public NewTitleScreenScript NewTitleScreen;

	// Token: 0x04003FC0 RID: 16320
	public Animation CharacterAnimation;

	// Token: 0x04003FC1 RID: 16321
	public GameObject BloodPool;

	// Token: 0x04003FC2 RID: 16322
	public GameObject[] DeadOsanas;
}
