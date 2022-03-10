using System;
using UnityEngine;

// Token: 0x020002E6 RID: 742
public class GlobalKnifeArrayScript : MonoBehaviour
{
	// Token: 0x06001503 RID: 5379 RVA: 0x000D8414 File Offset: 0x000D6614
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

	// Token: 0x040021B3 RID: 8627
	public TimeStopKnifeScript[] Knives;

	// Token: 0x040021B4 RID: 8628
	public int ID;
}
