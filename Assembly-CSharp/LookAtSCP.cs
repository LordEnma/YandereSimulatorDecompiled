using System;
using UnityEngine;

// Token: 0x02000523 RID: 1315
public class LookAtSCP : MonoBehaviour
{
	// Token: 0x06002194 RID: 8596 RVA: 0x001EE5B1 File Offset: 0x001EC7B1
	private void Start()
	{
		if (this.SCP == null)
		{
			this.SCP = GameObject.Find("SCPTarget").transform;
		}
		base.transform.LookAt(this.SCP);
	}

	// Token: 0x06002195 RID: 8597 RVA: 0x001EE5E7 File Offset: 0x001EC7E7
	private void LateUpdate()
	{
		base.transform.LookAt(this.SCP);
	}

	// Token: 0x040049D7 RID: 18903
	public Transform SCP;
}
