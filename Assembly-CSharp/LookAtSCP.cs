using System;
using UnityEngine;

// Token: 0x02000524 RID: 1316
public class LookAtSCP : MonoBehaviour
{
	// Token: 0x060021A5 RID: 8613 RVA: 0x001F0595 File Offset: 0x001EE795
	private void Start()
	{
		if (this.SCP == null)
		{
			this.SCP = GameObject.Find("SCPTarget").transform;
		}
		base.transform.LookAt(this.SCP);
	}

	// Token: 0x060021A6 RID: 8614 RVA: 0x001F05CB File Offset: 0x001EE7CB
	private void LateUpdate()
	{
		base.transform.LookAt(this.SCP);
	}

	// Token: 0x040049FF RID: 18943
	public Transform SCP;
}
