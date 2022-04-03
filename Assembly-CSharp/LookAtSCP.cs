using System;
using UnityEngine;

// Token: 0x02000522 RID: 1314
public class LookAtSCP : MonoBehaviour
{
	// Token: 0x0600218C RID: 8588 RVA: 0x001EE081 File Offset: 0x001EC281
	private void Start()
	{
		if (this.SCP == null)
		{
			this.SCP = GameObject.Find("SCPTarget").transform;
		}
		base.transform.LookAt(this.SCP);
	}

	// Token: 0x0600218D RID: 8589 RVA: 0x001EE0B7 File Offset: 0x001EC2B7
	private void LateUpdate()
	{
		base.transform.LookAt(this.SCP);
	}

	// Token: 0x040049D3 RID: 18899
	public Transform SCP;
}
