using System;
using UnityEngine;

// Token: 0x020004D5 RID: 1237
public class YanvaniaCutsceneTriggerScript : MonoBehaviour
{
	// Token: 0x0600207D RID: 8317 RVA: 0x001DCBB4 File Offset: 0x001DADB4
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YanmontChan")
		{
			this.BossBattleWall.SetActive(true);
			this.Yanmont.EnterCutscene = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04004712 RID: 18194
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x04004713 RID: 18195
	public GameObject BossBattleWall;
}
