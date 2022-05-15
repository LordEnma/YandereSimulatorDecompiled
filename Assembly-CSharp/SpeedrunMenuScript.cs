using System;
using UnityEngine;

// Token: 0x0200043E RID: 1086
public class SpeedrunMenuScript : MonoBehaviour
{
	// Token: 0x06001D0C RID: 7436 RVA: 0x0015B729 File Offset: 0x00159929
	private void Start()
	{
		this.YandereAnim["f02_nierRun_00"].speed = 1.5f;
	}

	// Token: 0x06001D0D RID: 7437 RVA: 0x0015B745 File Offset: 0x00159945
	private void Update()
	{
	}

	// Token: 0x040034A6 RID: 13478
	public Animation YandereAnim;
}
