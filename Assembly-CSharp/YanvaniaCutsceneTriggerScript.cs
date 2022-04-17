using System;
using UnityEngine;

// Token: 0x020004E1 RID: 1249
public class YanvaniaCutsceneTriggerScript : MonoBehaviour
{
	// Token: 0x060020C8 RID: 8392 RVA: 0x001E2D50 File Offset: 0x001E0F50
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YanmontChan")
		{
			this.BossBattleWall.SetActive(true);
			this.Yanmont.EnterCutscene = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040047EE RID: 18414
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x040047EF RID: 18415
	public GameObject BossBattleWall;
}
