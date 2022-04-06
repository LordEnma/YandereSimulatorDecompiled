using System;
using UnityEngine;

// Token: 0x0200043C RID: 1084
public class SpeedrunMenuScript : MonoBehaviour
{
	// Token: 0x06001CFB RID: 7419 RVA: 0x00159E5D File Offset: 0x0015805D
	private void Start()
	{
		this.YandereAnim["f02_nierRun_00"].speed = 1.5f;
	}

	// Token: 0x06001CFC RID: 7420 RVA: 0x00159E79 File Offset: 0x00158079
	private void Update()
	{
	}

	// Token: 0x04003477 RID: 13431
	public Animation YandereAnim;
}
