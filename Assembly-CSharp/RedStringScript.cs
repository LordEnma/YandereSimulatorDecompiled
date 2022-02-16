using System;
using UnityEngine;

// Token: 0x020003CD RID: 973
public class RedStringScript : MonoBehaviour
{
	// Token: 0x06001B58 RID: 7000 RVA: 0x00132DD4 File Offset: 0x00130FD4
	private void LateUpdate()
	{
		base.transform.LookAt(this.Target.position);
		base.transform.localScale = new Vector3(1f, 1f, Vector3.Distance(base.transform.position, this.Target.position));
	}

	// Token: 0x04002EA8 RID: 11944
	public Transform Target;
}
