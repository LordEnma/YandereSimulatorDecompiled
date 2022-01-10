using System;
using UnityEngine;

// Token: 0x020003CC RID: 972
public class RedStringScript : MonoBehaviour
{
	// Token: 0x06001B4E RID: 6990 RVA: 0x001321F4 File Offset: 0x001303F4
	private void LateUpdate()
	{
		base.transform.LookAt(this.Target.position);
		base.transform.localScale = new Vector3(1f, 1f, Vector3.Distance(base.transform.position, this.Target.position));
	}

	// Token: 0x04002E94 RID: 11924
	public Transform Target;
}
