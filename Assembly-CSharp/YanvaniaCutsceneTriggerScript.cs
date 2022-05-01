using System;
using UnityEngine;

// Token: 0x020004E2 RID: 1250
public class YanvaniaCutsceneTriggerScript : MonoBehaviour
{
	// Token: 0x060020D1 RID: 8401 RVA: 0x001E41DC File Offset: 0x001E23DC
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YanmontChan")
		{
			this.BossBattleWall.SetActive(true);
			this.Yanmont.EnterCutscene = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04004804 RID: 18436
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x04004805 RID: 18437
	public GameObject BossBattleWall;
}
