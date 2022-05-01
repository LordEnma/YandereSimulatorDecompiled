using System;
using UnityEngine;

// Token: 0x020004BE RID: 1214
public class VtuberHairReplacerScript : MonoBehaviour
{
	// Token: 0x06001FD0 RID: 8144 RVA: 0x001C1325 File Offset: 0x001BF525
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

	// Token: 0x04004274 RID: 17012
	public GameObject YandereHair;

	// Token: 0x04004275 RID: 17013
	public GameObject[] VtuberHair;
}
