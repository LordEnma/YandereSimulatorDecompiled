using System;
using UnityEngine;

// Token: 0x020002E8 RID: 744
public class GlobalKnifeArrayScript : MonoBehaviour
{
	// Token: 0x06001514 RID: 5396 RVA: 0x000D907C File Offset: 0x000D727C
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

	// Token: 0x040021D5 RID: 8661
	public TimeStopKnifeScript[] Knives;

	// Token: 0x040021D6 RID: 8662
	public int ID;
}
