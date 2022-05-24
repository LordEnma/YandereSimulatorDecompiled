using System;
using UnityEngine;

// Token: 0x020004E3 RID: 1251
public class YanvaniaCutsceneTriggerScript : MonoBehaviour
{
	// Token: 0x060020DD RID: 8413 RVA: 0x001E5E90 File Offset: 0x001E4090
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YanmontChan")
		{
			this.BossBattleWall.SetActive(true);
			this.Yanmont.EnterCutscene = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04004834 RID: 18484
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x04004835 RID: 18485
	public GameObject BossBattleWall;
}
