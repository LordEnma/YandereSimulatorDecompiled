using System;
using UnityEngine;

// Token: 0x020003D3 RID: 979
public class RedStringScript : MonoBehaviour
{
	// Token: 0x06001B83 RID: 7043 RVA: 0x00135C70 File Offset: 0x00133E70
	private void LateUpdate()
	{
		base.transform.LookAt(this.Target.position);
		base.transform.localScale = new Vector3(1f, 1f, Vector3.Distance(base.transform.position, this.Target.position));
	}

	// Token: 0x04002F29 RID: 12073
	public Transform Target;
}
