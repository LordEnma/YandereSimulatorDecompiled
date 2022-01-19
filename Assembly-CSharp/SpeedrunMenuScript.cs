using System;
using UnityEngine;

// Token: 0x02000435 RID: 1077
public class SpeedrunMenuScript : MonoBehaviour
{
	// Token: 0x06001CC8 RID: 7368 RVA: 0x001566CD File Offset: 0x001548CD
	private void Start()
	{
		this.YandereAnim["f02_nierRun_00"].speed = 1.5f;
	}

	// Token: 0x06001CC9 RID: 7369 RVA: 0x001566E9 File Offset: 0x001548E9
	private void Update()
	{
	}

	// Token: 0x040033ED RID: 13293
	public Animation YandereAnim;
}
