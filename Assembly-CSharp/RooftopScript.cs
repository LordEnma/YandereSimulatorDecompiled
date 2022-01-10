using System;
using UnityEngine;

// Token: 0x020003E9 RID: 1001
public class RooftopScript : MonoBehaviour
{
	// Token: 0x06001BC7 RID: 7111 RVA: 0x00142E34 File Offset: 0x00141034
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

	// Token: 0x040030BC RID: 12476
	public GameObject[] DumpPoints;

	// Token: 0x040030BD RID: 12477
	public GameObject Railing;

	// Token: 0x040030BE RID: 12478
	public GameObject Fence;
}
