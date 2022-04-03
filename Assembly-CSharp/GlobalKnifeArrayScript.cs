using System;
using UnityEngine;

// Token: 0x020002E7 RID: 743
public class GlobalKnifeArrayScript : MonoBehaviour
{
	// Token: 0x0600150C RID: 5388 RVA: 0x000D8D84 File Offset: 0x000D6F84
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

	// Token: 0x040021D1 RID: 8657
	public TimeStopKnifeScript[] Knives;

	// Token: 0x040021D2 RID: 8658
	public int ID;
}
