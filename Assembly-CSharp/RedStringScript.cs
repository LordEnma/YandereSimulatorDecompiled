using System;
using UnityEngine;

// Token: 0x020003CC RID: 972
public class RedStringScript : MonoBehaviour
{
	// Token: 0x06001B51 RID: 6993 RVA: 0x00132AA4 File Offset: 0x00130CA4
	private void LateUpdate()
	{
		base.transform.LookAt(this.Target.position);
		base.transform.localScale = new Vector3(1f, 1f, Vector3.Distance(base.transform.position, this.Target.position));
	}

	// Token: 0x04002EA2 RID: 11938
	public Transform Target;
}
