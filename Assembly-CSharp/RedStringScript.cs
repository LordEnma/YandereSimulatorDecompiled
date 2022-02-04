using System;
using UnityEngine;

// Token: 0x020003CC RID: 972
public class RedStringScript : MonoBehaviour
{
	// Token: 0x06001B4F RID: 6991 RVA: 0x0013290C File Offset: 0x00130B0C
	private void LateUpdate()
	{
		base.transform.LookAt(this.Target.position);
		base.transform.localScale = new Vector3(1f, 1f, Vector3.Distance(base.transform.position, this.Target.position));
	}

	// Token: 0x04002E9F RID: 11935
	public Transform Target;
}
