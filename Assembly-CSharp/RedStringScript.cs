using System;
using UnityEngine;

// Token: 0x020003D4 RID: 980
public class RedStringScript : MonoBehaviour
{
	// Token: 0x06001B8E RID: 7054 RVA: 0x0013719C File Offset: 0x0013539C
	private void LateUpdate()
	{
		base.transform.LookAt(this.Target.position);
		base.transform.localScale = new Vector3(1f, 1f, Vector3.Distance(base.transform.position, this.Target.position));
	}

	// Token: 0x04002F50 RID: 12112
	public Transform Target;
}
