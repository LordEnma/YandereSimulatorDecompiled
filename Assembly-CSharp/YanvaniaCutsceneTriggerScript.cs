using System;
using UnityEngine;

// Token: 0x020004E2 RID: 1250
public class YanvaniaCutsceneTriggerScript : MonoBehaviour
{
	// Token: 0x060020D2 RID: 8402 RVA: 0x001E42D8 File Offset: 0x001E24D8
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
