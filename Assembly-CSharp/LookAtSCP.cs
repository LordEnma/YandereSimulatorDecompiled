using System;
using UnityEngine;

// Token: 0x02000518 RID: 1304
public class LookAtSCP : MonoBehaviour
{
	// Token: 0x0600215E RID: 8542 RVA: 0x001E9ED1 File Offset: 0x001E80D1
	private void Start()
	{
		if (this.SCP == null)
		{
			this.SCP = GameObject.Find("SCPTarget").transform;
		}
		base.transform.LookAt(this.SCP);
	}

	// Token: 0x0600215F RID: 8543 RVA: 0x001E9F07 File Offset: 0x001E8107
	private void LateUpdate()
	{
		base.transform.LookAt(this.SCP);
	}

	// Token: 0x04004925 RID: 18725
	public Transform SCP;
}
