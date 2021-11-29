using System;
using UnityEngine;

// Token: 0x02000511 RID: 1297
public class LookAtSCP : MonoBehaviour
{
	// Token: 0x06002124 RID: 8484 RVA: 0x001E4CED File Offset: 0x001E2EED
	private void Start()
	{
		if (this.SCP == null)
		{
			this.SCP = GameObject.Find("SCPTarget").transform;
		}
		base.transform.LookAt(this.SCP);
	}

	// Token: 0x06002125 RID: 8485 RVA: 0x001E4D23 File Offset: 0x001E2F23
	private void LateUpdate()
	{
		base.transform.LookAt(this.SCP);
	}

	// Token: 0x04004895 RID: 18581
	public Transform SCP;
}
