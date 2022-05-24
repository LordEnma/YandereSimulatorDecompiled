using System;
using UnityEngine;

// Token: 0x02000484 RID: 1156
public class TitleScreenOsanaScript : MonoBehaviour
{
	// Token: 0x06001F1C RID: 7964 RVA: 0x001B917C File Offset: 0x001B737C
	private void Start()
	{
		if (GameGlobals.SpecificEliminationID > 0)
		{
			this.NewTitleScreen.ExtrasLabel.alpha = 1f;
			this.DeadOsanas[GameGlobals.SpecificEliminationID].SetActive(true);
		}
	}

	// Token: 0x040040EA RID: 16618
	public NewTitleScreenScript NewTitleScreen;

	// Token: 0x040040EB RID: 16619
	public Animation CharacterAnimation;

	// Token: 0x040040EC RID: 16620
	public GameObject BloodPool;

	// Token: 0x040040ED RID: 16621
	public GameObject[] DeadOsanas;
}
