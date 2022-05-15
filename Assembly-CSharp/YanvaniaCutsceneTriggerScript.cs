using System;
using UnityEngine;

// Token: 0x020004E3 RID: 1251
public class YanvaniaCutsceneTriggerScript : MonoBehaviour
{
	// Token: 0x060020DC RID: 8412 RVA: 0x001E5928 File Offset: 0x001E3B28
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YanmontChan")
		{
			this.BossBattleWall.SetActive(true);
			this.Yanmont.EnterCutscene = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0400482B RID: 18475
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x0400482C RID: 18476
	public GameObject BossBattleWall;
}
