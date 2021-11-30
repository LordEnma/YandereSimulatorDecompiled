using System;
using UnityEngine;

// Token: 0x020002C8 RID: 712
public class FloatAbovePointScript : MonoBehaviour
{
	// Token: 0x0600148E RID: 5262 RVA: 0x000C96C5 File Offset: 0x000C78C5
	private void Update()
	{
		base.transform.position = this.Target.position + new Vector3(0f, 0.15f, 0f);
	}

	// Token: 0x04001FFF RID: 8191
	public Transform Target;
}
