using System;
using UnityEngine;

// Token: 0x020004E1 RID: 1249
public class YanvaniaCutsceneTriggerScript : MonoBehaviour
{
	// Token: 0x060020C1 RID: 8385 RVA: 0x001E22F4 File Offset: 0x001E04F4
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YanmontChan")
		{
			this.BossBattleWall.SetActive(true);
			this.Yanmont.EnterCutscene = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040047DC RID: 18396
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x040047DD RID: 18397
	public GameObject BossBattleWall;
}
