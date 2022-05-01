using System;
using UnityEngine;

// Token: 0x020003D3 RID: 979
public class RedStringScript : MonoBehaviour
{
	// Token: 0x06001B87 RID: 7047 RVA: 0x001362E8 File Offset: 0x001344E8
	private void LateUpdate()
	{
		base.transform.LookAt(this.Target.position);
		base.transform.localScale = new Vector3(1f, 1f, Vector3.Distance(base.transform.position, this.Target.position));
	}

	// Token: 0x04002F33 RID: 12083
	public Transform Target;
}
