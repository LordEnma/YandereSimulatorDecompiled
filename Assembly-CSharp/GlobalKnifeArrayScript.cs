using System;
using UnityEngine;

// Token: 0x020002E8 RID: 744
public class GlobalKnifeArrayScript : MonoBehaviour
{
	// Token: 0x06001512 RID: 5394 RVA: 0x000D8E94 File Offset: 0x000D7094
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

	// Token: 0x040021D3 RID: 8659
	public TimeStopKnifeScript[] Knives;

	// Token: 0x040021D4 RID: 8660
	public int ID;
}
