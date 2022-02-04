using System;
using UnityEngine;

// Token: 0x02000516 RID: 1302
public class LookAtSCP : MonoBehaviour
{
	// Token: 0x0600214B RID: 8523 RVA: 0x001E8C39 File Offset: 0x001E6E39
	private void Start()
	{
		if (this.SCP == null)
		{
			this.SCP = GameObject.Find("SCPTarget").transform;
		}
		base.transform.LookAt(this.SCP);
	}

	// Token: 0x0600214C RID: 8524 RVA: 0x001E8C6F File Offset: 0x001E6E6F
	private void LateUpdate()
	{
		base.transform.LookAt(this.SCP);
	}

	// Token: 0x04004909 RID: 18697
	public Transform SCP;
}
