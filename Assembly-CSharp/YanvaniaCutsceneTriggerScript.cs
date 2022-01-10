using System;
using UnityEngine;

// Token: 0x020004D4 RID: 1236
public class YanvaniaCutsceneTriggerScript : MonoBehaviour
{
	// Token: 0x06002072 RID: 8306 RVA: 0x001DB128 File Offset: 0x001D9328
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YanmontChan")
		{
			this.BossBattleWall.SetActive(true);
			this.Yanmont.EnterCutscene = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040046F7 RID: 18167
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x040046F8 RID: 18168
	public GameObject BossBattleWall;
}
