using System;
using UnityEngine;

// Token: 0x020003EA RID: 1002
public class RooftopScript : MonoBehaviour
{
	// Token: 0x06001BCA RID: 7114 RVA: 0x00144A84 File Offset: 0x00142C84
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

	// Token: 0x040030C8 RID: 12488
	public GameObject[] DumpPoints;

	// Token: 0x040030C9 RID: 12489
	public GameObject Railing;

	// Token: 0x040030CA RID: 12490
	public GameObject Fence;
}
