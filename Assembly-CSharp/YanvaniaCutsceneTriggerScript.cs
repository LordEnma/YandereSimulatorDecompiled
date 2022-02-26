using System;
using UnityEngine;

// Token: 0x020004D7 RID: 1239
public class YanvaniaCutsceneTriggerScript : MonoBehaviour
{
	// Token: 0x0600208D RID: 8333 RVA: 0x001DDC48 File Offset: 0x001DBE48
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YanmontChan")
		{
			this.BossBattleWall.SetActive(true);
			this.Yanmont.EnterCutscene = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0400472B RID: 18219
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x0400472C RID: 18220
	public GameObject BossBattleWall;
}
