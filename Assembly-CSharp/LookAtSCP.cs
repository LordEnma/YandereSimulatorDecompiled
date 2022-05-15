using System;
using UnityEngine;

// Token: 0x02000525 RID: 1317
public class LookAtSCP : MonoBehaviour
{
	// Token: 0x060021AF RID: 8623 RVA: 0x001F1BE5 File Offset: 0x001EFDE5
	private void Start()
	{
		if (this.SCP == null)
		{
			this.SCP = GameObject.Find("SCPTarget").transform;
		}
		base.transform.LookAt(this.SCP);
	}

	// Token: 0x060021B0 RID: 8624 RVA: 0x001F1C1B File Offset: 0x001EFE1B
	private void LateUpdate()
	{
		base.transform.LookAt(this.SCP);
	}

	// Token: 0x04004A26 RID: 18982
	public Transform SCP;
}
