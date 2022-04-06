using System;
using UnityEngine;

// Token: 0x020004BD RID: 1213
public class VtuberHairReplacerScript : MonoBehaviour
{
	// Token: 0x06001FC1 RID: 8129 RVA: 0x001BF58D File Offset: 0x001BD78D
	private void Start()
	{
		if (GameGlobals.VtuberID > 0)
		{
			this.YandereHair.SetActive(false);
			this.VtuberHair[GameGlobals.VtuberID].SetActive(true);
			return;
		}
		this.VtuberHair[1].SetActive(false);
	}

	// Token: 0x0400424E RID: 16974
	public GameObject YandereHair;

	// Token: 0x0400424F RID: 16975
	public GameObject[] VtuberHair;
}
