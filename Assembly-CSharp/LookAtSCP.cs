using System;
using UnityEngine;

// Token: 0x02000517 RID: 1303
public class LookAtSCP : MonoBehaviour
{
	// Token: 0x06002155 RID: 8533 RVA: 0x001E92F1 File Offset: 0x001E74F1
	private void Start()
	{
		if (this.SCP == null)
		{
			this.SCP = GameObject.Find("SCPTarget").transform;
		}
		base.transform.LookAt(this.SCP);
	}

	// Token: 0x06002156 RID: 8534 RVA: 0x001E9327 File Offset: 0x001E7527
	private void LateUpdate()
	{
		base.transform.LookAt(this.SCP);
	}

	// Token: 0x04004915 RID: 18709
	public Transform SCP;
}
