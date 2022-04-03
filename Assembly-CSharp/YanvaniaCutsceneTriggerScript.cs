using System;
using UnityEngine;

// Token: 0x020004E0 RID: 1248
public class YanvaniaCutsceneTriggerScript : MonoBehaviour
{
	// Token: 0x060020B9 RID: 8377 RVA: 0x001E1DC4 File Offset: 0x001DFFC4
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YanmontChan")
		{
			this.BossBattleWall.SetActive(true);
			this.Yanmont.EnterCutscene = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040047D8 RID: 18392
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x040047D9 RID: 18393
	public GameObject BossBattleWall;
}
