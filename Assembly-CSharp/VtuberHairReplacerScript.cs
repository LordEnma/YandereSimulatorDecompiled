using System;
using UnityEngine;

// Token: 0x020004B9 RID: 1209
public class VtuberHairReplacerScript : MonoBehaviour
{
	// Token: 0x06001FAF RID: 8111 RVA: 0x001BDAF9 File Offset: 0x001BBCF9
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

	// Token: 0x0400421E RID: 16926
	public GameObject YandereHair;

	// Token: 0x0400421F RID: 16927
	public GameObject[] VtuberHair;
}
