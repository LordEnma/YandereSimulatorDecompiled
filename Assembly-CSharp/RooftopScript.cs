using System;
using UnityEngine;

// Token: 0x020003ED RID: 1005
public class RooftopScript : MonoBehaviour
{
	// Token: 0x06001BEB RID: 7147 RVA: 0x00146D74 File Offset: 0x00144F74
	private void Start()
	{
		if (SchoolGlobals.RoofFence)
		{
			GameObject[] dumpPoints = this.DumpPoints;
			for (int i = 0; i < dumpPoints.Length; i++)
			{
				dumpPoints[i].SetActive(false);
			}
			this.Railing.SetActive(false);
			this.Fence.SetActive(true);
		}
	}

	// Token: 0x0400312B RID: 12587
	public GameObject[] DumpPoints;

	// Token: 0x0400312C RID: 12588
	public GameObject Railing;

	// Token: 0x0400312D RID: 12589
	public GameObject Fence;
}
