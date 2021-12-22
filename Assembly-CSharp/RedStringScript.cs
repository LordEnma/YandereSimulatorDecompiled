using System;
using UnityEngine;

// Token: 0x020003CA RID: 970
public class RedStringScript : MonoBehaviour
{
	// Token: 0x06001B45 RID: 6981 RVA: 0x00131A5C File Offset: 0x0012FC5C
	private void LateUpdate()
	{
		base.transform.LookAt(this.Target.position);
		base.transform.localScale = new Vector3(1f, 1f, Vector3.Distance(base.transform.position, this.Target.position));
	}

	// Token: 0x04002E87 RID: 11911
	public Transform Target;
}
