using System;
using UnityEngine;

// Token: 0x020002E6 RID: 742
public class GlobalKnifeArrayScript : MonoBehaviour
{
	// Token: 0x06001503 RID: 5379 RVA: 0x000D80E4 File Offset: 0x000D62E4
	public void ActivateKnives()
	{
		foreach (TimeStopKnifeScript timeStopKnifeScript in this.Knives)
		{
			if (timeStopKnifeScript != null)
			{
				timeStopKnifeScript.Unfreeze = true;
			}
		}
		this.ID = 0;
	}

	// Token: 0x0400219F RID: 8607
	public TimeStopKnifeScript[] Knives;

	// Token: 0x040021A0 RID: 8608
	public int ID;
}
