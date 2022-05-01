using System;
using UnityEngine;

// Token: 0x02000524 RID: 1316
public class LookAtSCP : MonoBehaviour
{
	// Token: 0x060021A4 RID: 8612 RVA: 0x001F0499 File Offset: 0x001EE699
	private void Start()
	{
		if (this.SCP == null)
		{
			this.SCP = GameObject.Find("SCPTarget").transform;
		}
		base.transform.LookAt(this.SCP);
	}

	// Token: 0x060021A5 RID: 8613 RVA: 0x001F04CF File Offset: 0x001EE6CF
	private void LateUpdate()
	{
		base.transform.LookAt(this.SCP);
	}

	// Token: 0x040049FF RID: 18943
	public Transform SCP;
}
