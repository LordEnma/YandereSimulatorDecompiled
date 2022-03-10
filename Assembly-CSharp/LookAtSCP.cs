using System;
using UnityEngine;

// Token: 0x02000519 RID: 1305
public class LookAtSCP : MonoBehaviour
{
	// Token: 0x06002164 RID: 8548 RVA: 0x001EA8A9 File Offset: 0x001E8AA9
	private void Start()
	{
		if (this.SCP == null)
		{
			this.SCP = GameObject.Find("SCPTarget").transform;
		}
		base.transform.LookAt(this.SCP);
	}

	// Token: 0x06002165 RID: 8549 RVA: 0x001EA8DF File Offset: 0x001E8ADF
	private void LateUpdate()
	{
		base.transform.LookAt(this.SCP);
	}

	// Token: 0x04004942 RID: 18754
	public Transform SCP;
}
