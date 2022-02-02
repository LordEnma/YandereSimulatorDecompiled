using System;
using UnityEngine;

// Token: 0x020004D5 RID: 1237
public class YanvaniaCutsceneTriggerScript : MonoBehaviour
{
	// Token: 0x06002078 RID: 8312 RVA: 0x001DC698 File Offset: 0x001DA898
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YanmontChan")
		{
			this.BossBattleWall.SetActive(true);
			this.Yanmont.EnterCutscene = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04004709 RID: 18185
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x0400470A RID: 18186
	public GameObject BossBattleWall;
}
