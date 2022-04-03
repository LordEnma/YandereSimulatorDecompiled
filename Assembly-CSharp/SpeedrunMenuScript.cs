using System;
using UnityEngine;

// Token: 0x0200043B RID: 1083
public class SpeedrunMenuScript : MonoBehaviour
{
	// Token: 0x06001CF4 RID: 7412 RVA: 0x00159B3D File Offset: 0x00157D3D
	private void Start()
	{
		this.YandereAnim["f02_nierRun_00"].speed = 1.5f;
	}

	// Token: 0x06001CF5 RID: 7413 RVA: 0x00159B59 File Offset: 0x00157D59
	private void Update()
	{
	}

	// Token: 0x04003474 RID: 13428
	public Animation YandereAnim;
}
