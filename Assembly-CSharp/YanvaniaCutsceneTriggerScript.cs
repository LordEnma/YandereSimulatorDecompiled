using System;
using UnityEngine;

// Token: 0x020004D2 RID: 1234
public class YanvaniaCutsceneTriggerScript : MonoBehaviour
{
	// Token: 0x06002067 RID: 8295 RVA: 0x001DA788 File Offset: 0x001D8988
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YanmontChan")
		{
			this.BossBattleWall.SetActive(true);
			this.Yanmont.EnterCutscene = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040046E3 RID: 18147
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x040046E4 RID: 18148
	public GameObject BossBattleWall;
}
