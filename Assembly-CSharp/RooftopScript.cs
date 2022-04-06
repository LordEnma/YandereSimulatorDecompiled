using System;
using UnityEngine;

// Token: 0x020003F1 RID: 1009
public class RooftopScript : MonoBehaviour
{
	// Token: 0x06001BFB RID: 7163 RVA: 0x00147B14 File Offset: 0x00145D14
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

	// Token: 0x04003147 RID: 12615
	public GameObject[] DumpPoints;

	// Token: 0x04003148 RID: 12616
	public GameObject Railing;

	// Token: 0x04003149 RID: 12617
	public GameObject Fence;
}
