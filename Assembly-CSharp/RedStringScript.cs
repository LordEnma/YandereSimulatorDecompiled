using System;
using UnityEngine;

// Token: 0x020003D4 RID: 980
public class RedStringScript : MonoBehaviour
{
	// Token: 0x06001B8D RID: 7053 RVA: 0x00136F00 File Offset: 0x00135100
	private void LateUpdate()
	{
		base.transform.LookAt(this.Target.position);
		base.transform.localScale = new Vector3(1f, 1f, Vector3.Distance(base.transform.position, this.Target.position));
	}

	// Token: 0x04002F48 RID: 12104
	public Transform Target;
}
