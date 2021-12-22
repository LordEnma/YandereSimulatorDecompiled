using System;
using UnityEngine;

// Token: 0x020004D2 RID: 1234
public class YanvaniaCutsceneTriggerScript : MonoBehaviour
{
	// Token: 0x06002064 RID: 8292 RVA: 0x001DA198 File Offset: 0x001D8398
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YanmontChan")
		{
			this.BossBattleWall.SetActive(true);
			this.Yanmont.EnterCutscene = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040046DA RID: 18138
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x040046DB RID: 18139
	public GameObject BossBattleWall;
}
