using System;
using UnityEngine;

// Token: 0x020002E4 RID: 740
public class GlobalKnifeArrayScript : MonoBehaviour
{
	// Token: 0x060014F4 RID: 5364 RVA: 0x000D7184 File Offset: 0x000D5384
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

	// Token: 0x04002183 RID: 8579
	public TimeStopKnifeScript[] Knives;

	// Token: 0x04002184 RID: 8580
	public int ID;
}
