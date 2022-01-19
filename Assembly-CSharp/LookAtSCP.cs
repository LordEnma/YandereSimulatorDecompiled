using System;
using UnityEngine;

// Token: 0x02000516 RID: 1302
public class LookAtSCP : MonoBehaviour
{
	// Token: 0x06002145 RID: 8517 RVA: 0x001E8081 File Offset: 0x001E6281
	private void Start()
	{
		if (this.SCP == null)
		{
			this.SCP = GameObject.Find("SCPTarget").transform;
		}
		base.transform.LookAt(this.SCP);
	}

	// Token: 0x06002146 RID: 8518 RVA: 0x001E80B7 File Offset: 0x001E62B7
	private void LateUpdate()
	{
		base.transform.LookAt(this.SCP);
	}

	// Token: 0x040048F8 RID: 18680
	public Transform SCP;
}
