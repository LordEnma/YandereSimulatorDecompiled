using System;
using UnityEngine;

// Token: 0x020002E9 RID: 745
public class GlobalKnifeArrayScript : MonoBehaviour
{
	// Token: 0x0600151A RID: 5402 RVA: 0x000D981C File Offset: 0x000D7A1C
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

	// Token: 0x040021E7 RID: 8679
	public TimeStopKnifeScript[] Knives;

	// Token: 0x040021E8 RID: 8680
	public int ID;
}
