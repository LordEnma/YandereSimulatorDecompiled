using System;
using UnityEngine;

// Token: 0x020004BD RID: 1213
public class VtuberHairReplacerScript : MonoBehaviour
{
	// Token: 0x06001FC7 RID: 8135 RVA: 0x001BFF69 File Offset: 0x001BE169
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

	// Token: 0x0400425E RID: 16990
	public GameObject YandereHair;

	// Token: 0x0400425F RID: 16991
	public GameObject[] VtuberHair;
}
