using System;
using UnityEngine;

// Token: 0x02000516 RID: 1302
public class LookAtSCP : MonoBehaviour
{
	// Token: 0x0600214E RID: 8526 RVA: 0x001E8E3D File Offset: 0x001E703D
	private void Start()
	{
		if (this.SCP == null)
		{
			this.SCP = GameObject.Find("SCPTarget").transform;
		}
		base.transform.LookAt(this.SCP);
	}

	// Token: 0x0600214F RID: 8527 RVA: 0x001E8E73 File Offset: 0x001E7073
	private void LateUpdate()
	{
		base.transform.LookAt(this.SCP);
	}

	// Token: 0x0400490C RID: 18700
	public Transform SCP;
}
