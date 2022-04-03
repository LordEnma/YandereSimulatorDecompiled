using System;
using UnityEngine;

// Token: 0x020004BC RID: 1212
public class VtuberHairReplacerScript : MonoBehaviour
{
	// Token: 0x06001FB9 RID: 8121 RVA: 0x001BF085 File Offset: 0x001BD285
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

	// Token: 0x0400424B RID: 16971
	public GameObject YandereHair;

	// Token: 0x0400424C RID: 16972
	public GameObject[] VtuberHair;
}
