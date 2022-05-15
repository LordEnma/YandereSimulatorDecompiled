using System;
using UnityEngine;

// Token: 0x020004BF RID: 1215
public class VtuberHairReplacerScript : MonoBehaviour
{
	// Token: 0x06001FDA RID: 8154 RVA: 0x001C25B9 File Offset: 0x001C07B9
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

	// Token: 0x04004292 RID: 17042
	public GameObject YandereHair;

	// Token: 0x04004293 RID: 17043
	public GameObject[] VtuberHair;
}
