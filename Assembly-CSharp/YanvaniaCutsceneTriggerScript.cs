using System;
using UnityEngine;

// Token: 0x020004D5 RID: 1237
public class YanvaniaCutsceneTriggerScript : MonoBehaviour
{
	// Token: 0x0600207A RID: 8314 RVA: 0x001DC9B0 File Offset: 0x001DABB0
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YanmontChan")
		{
			this.BossBattleWall.SetActive(true);
			this.Yanmont.EnterCutscene = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0400470F RID: 18191
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x04004710 RID: 18192
	public GameObject BossBattleWall;
}
