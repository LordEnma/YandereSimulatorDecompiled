using System;
using UnityEngine;

// Token: 0x02000515 RID: 1301
public class LookAtSCP : MonoBehaviour
{
	// Token: 0x06002143 RID: 8515 RVA: 0x001E73B1 File Offset: 0x001E55B1
	private void Start()
	{
		if (this.SCP == null)
		{
			this.SCP = GameObject.Find("SCPTarget").transform;
		}
		base.transform.LookAt(this.SCP);
	}

	// Token: 0x06002144 RID: 8516 RVA: 0x001E73E7 File Offset: 0x001E55E7
	private void LateUpdate()
	{
		base.transform.LookAt(this.SCP);
	}

	// Token: 0x040048F1 RID: 18673
	public Transform SCP;
}
