using System;
using UnityEngine;

// Token: 0x020002E8 RID: 744
public class GlobalKnifeArrayScript : MonoBehaviour
{
	// Token: 0x06001518 RID: 5400 RVA: 0x000D954C File Offset: 0x000D774C
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

	// Token: 0x040021DE RID: 8670
	public TimeStopKnifeScript[] Knives;

	// Token: 0x040021DF RID: 8671
	public int ID;
}
