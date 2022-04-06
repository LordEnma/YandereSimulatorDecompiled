using System;
using UnityEngine;

// Token: 0x020003D3 RID: 979
public class RedStringScript : MonoBehaviour
{
	// Token: 0x06001B7F RID: 7039 RVA: 0x00135860 File Offset: 0x00133A60
	private void LateUpdate()
	{
		base.transform.LookAt(this.Target.position);
		base.transform.localScale = new Vector3(1f, 1f, Vector3.Distance(base.transform.position, this.Target.position));
	}

	// Token: 0x04002F1E RID: 12062
	public Transform Target;
}
