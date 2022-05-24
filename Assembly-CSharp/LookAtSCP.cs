using System;
using UnityEngine;

// Token: 0x02000525 RID: 1317
public class LookAtSCP : MonoBehaviour
{
	// Token: 0x060021B0 RID: 8624 RVA: 0x001F214D File Offset: 0x001F034D
	private void Start()
	{
		if (this.SCP == null)
		{
			this.SCP = GameObject.Find("SCPTarget").transform;
		}
		base.transform.LookAt(this.SCP);
	}

	// Token: 0x060021B1 RID: 8625 RVA: 0x001F2183 File Offset: 0x001F0383
	private void LateUpdate()
	{
		base.transform.LookAt(this.SCP);
	}

	// Token: 0x04004A2F RID: 18991
	public Transform SCP;
}
