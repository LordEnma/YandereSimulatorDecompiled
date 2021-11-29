using System;
using UnityEngine;

// Token: 0x020003C9 RID: 969
public class RedStringScript : MonoBehaviour
{
	// Token: 0x06001B3D RID: 6973 RVA: 0x0013119C File Offset: 0x0012F39C
	private void LateUpdate()
	{
		base.transform.LookAt(this.Target.position);
		base.transform.localScale = new Vector3(1f, 1f, Vector3.Distance(base.transform.position, this.Target.position));
	}

	// Token: 0x04002E5D RID: 11869
	public Transform Target;
}
