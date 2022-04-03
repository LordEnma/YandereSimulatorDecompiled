using System;
using UnityEngine;

// Token: 0x020003D2 RID: 978
public class RedStringScript : MonoBehaviour
{
	// Token: 0x06001B79 RID: 7033 RVA: 0x00135648 File Offset: 0x00133848
	private void LateUpdate()
	{
		base.transform.LookAt(this.Target.position);
		base.transform.localScale = new Vector3(1f, 1f, Vector3.Distance(base.transform.position, this.Target.position));
	}

	// Token: 0x04002F1B RID: 12059
	public Transform Target;
}
