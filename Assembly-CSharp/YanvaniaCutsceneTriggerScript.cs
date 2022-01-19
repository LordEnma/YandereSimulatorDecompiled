using System;
using UnityEngine;

// Token: 0x020004D5 RID: 1237
public class YanvaniaCutsceneTriggerScript : MonoBehaviour
{
	// Token: 0x06002074 RID: 8308 RVA: 0x001DBDF8 File Offset: 0x001D9FF8
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YanmontChan")
		{
			this.BossBattleWall.SetActive(true);
			this.Yanmont.EnterCutscene = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040046FE RID: 18174
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x040046FF RID: 18175
	public GameObject BossBattleWall;
}
