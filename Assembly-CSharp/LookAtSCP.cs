using System;
using UnityEngine;

// Token: 0x02000513 RID: 1299
public class LookAtSCP : MonoBehaviour
{
	// Token: 0x06002135 RID: 8501 RVA: 0x001E6421 File Offset: 0x001E4621
	private void Start()
	{
		if (this.SCP == null)
		{
			this.SCP = GameObject.Find("SCPTarget").transform;
		}
		base.transform.LookAt(this.SCP);
	}

	// Token: 0x06002136 RID: 8502 RVA: 0x001E6457 File Offset: 0x001E4657
	private void LateUpdate()
	{
		base.transform.LookAt(this.SCP);
	}

	// Token: 0x040048D4 RID: 18644
	public Transform SCP;
}
