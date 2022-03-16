using System;
using UnityEngine;

// Token: 0x020003CF RID: 975
public class RedStringScript : MonoBehaviour
{
	// Token: 0x06001B6F RID: 7023 RVA: 0x00134BD4 File Offset: 0x00132DD4
	private void LateUpdate()
	{
		base.transform.LookAt(this.Target.position);
		base.transform.localScale = new Vector3(1f, 1f, Vector3.Distance(base.transform.position, this.Target.position));
	}

	// Token: 0x04002F02 RID: 12034
	public Transform Target;
}
