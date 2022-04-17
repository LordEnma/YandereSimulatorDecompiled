using System;
using UnityEngine;

// Token: 0x02000523 RID: 1315
public class LookAtSCP : MonoBehaviour
{
	// Token: 0x0600219B RID: 8603 RVA: 0x001EF00D File Offset: 0x001ED20D
	private void Start()
	{
		if (this.SCP == null)
		{
			this.SCP = GameObject.Find("SCPTarget").transform;
		}
		base.transform.LookAt(this.SCP);
	}

	// Token: 0x0600219C RID: 8604 RVA: 0x001EF043 File Offset: 0x001ED243
	private void LateUpdate()
	{
		base.transform.LookAt(this.SCP);
	}

	// Token: 0x040049E9 RID: 18921
	public Transform SCP;
}
