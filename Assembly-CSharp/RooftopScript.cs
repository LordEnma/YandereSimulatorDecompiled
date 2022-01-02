using System;
using UnityEngine;

// Token: 0x020003E7 RID: 999
public class RooftopScript : MonoBehaviour
{
	// Token: 0x06001BC0 RID: 7104 RVA: 0x00142AC0 File Offset: 0x00140CC0
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

	// Token: 0x040030B6 RID: 12470
	public GameObject[] DumpPoints;

	// Token: 0x040030B7 RID: 12471
	public GameObject Railing;

	// Token: 0x040030B8 RID: 12472
	public GameObject Fence;
}
