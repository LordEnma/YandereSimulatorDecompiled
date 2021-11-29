using System;
using UnityEngine;

// Token: 0x020004D0 RID: 1232
public class YanvaniaCutsceneTriggerScript : MonoBehaviour
{
	// Token: 0x06002053 RID: 8275 RVA: 0x001D8A64 File Offset: 0x001D6C64
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YanmontChan")
		{
			this.BossBattleWall.SetActive(true);
			this.Yanmont.EnterCutscene = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0400469B RID: 18075
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x0400469C RID: 18076
	public GameObject BossBattleWall;
}
