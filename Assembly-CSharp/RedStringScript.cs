using System;
using UnityEngine;

// Token: 0x020003CA RID: 970
public class RedStringScript : MonoBehaviour
{
	// Token: 0x06001B47 RID: 6983 RVA: 0x00131E58 File Offset: 0x00130058
	private void LateUpdate()
	{
		base.transform.LookAt(this.Target.position);
		base.transform.localScale = new Vector3(1f, 1f, Vector3.Distance(base.transform.position, this.Target.position));
	}

	// Token: 0x04002E8E RID: 11918
	public Transform Target;
}
