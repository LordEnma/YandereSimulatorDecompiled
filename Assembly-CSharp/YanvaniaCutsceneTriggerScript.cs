using System;
using UnityEngine;

// Token: 0x020004D8 RID: 1240
public class YanvaniaCutsceneTriggerScript : MonoBehaviour
{
	// Token: 0x06002093 RID: 8339 RVA: 0x001DE620 File Offset: 0x001DC820
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YanmontChan")
		{
			this.BossBattleWall.SetActive(true);
			this.Yanmont.EnterCutscene = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04004748 RID: 18248
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x04004749 RID: 18249
	public GameObject BossBattleWall;
}
