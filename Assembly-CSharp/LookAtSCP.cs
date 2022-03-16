using System;
using UnityEngine;

// Token: 0x0200051D RID: 1309
public class LookAtSCP : MonoBehaviour
{
	// Token: 0x0600217C RID: 8572 RVA: 0x001EC811 File Offset: 0x001EAA11
	private void Start()
	{
		if (this.SCP == null)
		{
			this.SCP = GameObject.Find("SCPTarget").transform;
		}
		base.transform.LookAt(this.SCP);
	}

	// Token: 0x0600217D RID: 8573 RVA: 0x001EC847 File Offset: 0x001EAA47
	private void LateUpdate()
	{
		base.transform.LookAt(this.SCP);
	}

	// Token: 0x040049A1 RID: 18849
	public Transform SCP;
}
