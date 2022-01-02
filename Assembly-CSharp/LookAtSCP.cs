using System;
using UnityEngine;

// Token: 0x02000513 RID: 1299
public class LookAtSCP : MonoBehaviour
{
	// Token: 0x06002138 RID: 8504 RVA: 0x001E6A11 File Offset: 0x001E4C11
	private void Start()
	{
		if (this.SCP == null)
		{
			this.SCP = GameObject.Find("SCPTarget").transform;
		}
		base.transform.LookAt(this.SCP);
	}

	// Token: 0x06002139 RID: 8505 RVA: 0x001E6A47 File Offset: 0x001E4C47
	private void LateUpdate()
	{
		base.transform.LookAt(this.SCP);
	}

	// Token: 0x040048DD RID: 18653
	public Transform SCP;
}
