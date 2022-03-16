using System;
using UnityEngine;

// Token: 0x020004DC RID: 1244
public class YanvaniaCutsceneTriggerScript : MonoBehaviour
{
	// Token: 0x060020AB RID: 8363 RVA: 0x001E0588 File Offset: 0x001DE788
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YanmontChan")
		{
			this.BossBattleWall.SetActive(true);
			this.Yanmont.EnterCutscene = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040047A7 RID: 18343
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x040047A8 RID: 18344
	public GameObject BossBattleWall;
}
