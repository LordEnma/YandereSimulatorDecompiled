using System;
using UnityEngine;

// Token: 0x020003CE RID: 974
public class RedStringScript : MonoBehaviour
{
	// Token: 0x06001B62 RID: 7010 RVA: 0x00133D34 File Offset: 0x00131F34
	private void LateUpdate()
	{
		base.transform.LookAt(this.Target.position);
		base.transform.localScale = new Vector3(1f, 1f, Vector3.Distance(base.transform.position, this.Target.position));
	}

	// Token: 0x04002ECE RID: 11982
	public Transform Target;
}
