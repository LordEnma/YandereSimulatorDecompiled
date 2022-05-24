using System;
using UnityEngine;

// Token: 0x0200043E RID: 1086
public class SpeedrunMenuScript : MonoBehaviour
{
	// Token: 0x06001D0D RID: 7437 RVA: 0x0015B9E5 File Offset: 0x00159BE5
	private void Start()
	{
		this.YandereAnim["f02_nierRun_00"].speed = 1.5f;
	}

	// Token: 0x06001D0E RID: 7438 RVA: 0x0015BA01 File Offset: 0x00159C01
	private void Update()
	{
	}

	// Token: 0x040034AE RID: 13486
	public Animation YandereAnim;
}
