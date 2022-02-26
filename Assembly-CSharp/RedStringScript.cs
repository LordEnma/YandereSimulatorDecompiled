using System;
using UnityEngine;

// Token: 0x020003CE RID: 974
public class RedStringScript : MonoBehaviour
{
	// Token: 0x06001B61 RID: 7009 RVA: 0x0013381C File Offset: 0x00131A1C
	private void LateUpdate()
	{
		base.transform.LookAt(this.Target.position);
		base.transform.localScale = new Vector3(1f, 1f, Vector3.Distance(base.transform.position, this.Target.position));
	}

	// Token: 0x04002EB8 RID: 11960
	public Transform Target;
}
