using System;
using UnityEngine;

// Token: 0x020004BF RID: 1215
public class VtuberHairReplacerScript : MonoBehaviour
{
	// Token: 0x06001FDB RID: 8155 RVA: 0x001C2A35 File Offset: 0x001C0C35
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

	// Token: 0x0400429B RID: 17051
	public GameObject YandereHair;

	// Token: 0x0400429C RID: 17052
	public GameObject[] VtuberHair;
}
