using System;
using UnityEngine;

// Token: 0x020004D6 RID: 1238
public class YanvaniaCutsceneTriggerScript : MonoBehaviour
{
	// Token: 0x06002084 RID: 8324 RVA: 0x001DD068 File Offset: 0x001DB268
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YanmontChan")
		{
			this.BossBattleWall.SetActive(true);
			this.Yanmont.EnterCutscene = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0400471B RID: 18203
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x0400471C RID: 18204
	public GameObject BossBattleWall;
}
