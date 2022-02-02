using System;
using UnityEngine;

// Token: 0x02000516 RID: 1302
public class LookAtSCP : MonoBehaviour
{
	// Token: 0x06002149 RID: 8521 RVA: 0x001E8921 File Offset: 0x001E6B21
	private void Start()
	{
		if (this.SCP == null)
		{
			this.SCP = GameObject.Find("SCPTarget").transform;
		}
		base.transform.LookAt(this.SCP);
	}

	// Token: 0x0600214A RID: 8522 RVA: 0x001E8957 File Offset: 0x001E6B57
	private void LateUpdate()
	{
		base.transform.LookAt(this.SCP);
	}

	// Token: 0x04004903 RID: 18691
	public Transform SCP;
}
