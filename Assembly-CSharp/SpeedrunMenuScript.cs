using System;
using UnityEngine;

// Token: 0x02000436 RID: 1078
public class SpeedrunMenuScript : MonoBehaviour
{
	// Token: 0x06001CD2 RID: 7378 RVA: 0x001570A5 File Offset: 0x001552A5
	private void Start()
	{
		this.YandereAnim["f02_nierRun_00"].speed = 1.5f;
	}

	// Token: 0x06001CD3 RID: 7379 RVA: 0x001570C1 File Offset: 0x001552C1
	private void Update()
	{
	}

	// Token: 0x040033FD RID: 13309
	public Animation YandereAnim;
}
