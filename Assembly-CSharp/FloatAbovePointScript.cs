using System;
using UnityEngine;

// Token: 0x020002C9 RID: 713
public class FloatAbovePointScript : MonoBehaviour
{
	// Token: 0x06001495 RID: 5269 RVA: 0x000C9E61 File Offset: 0x000C8061
	private void Update()
	{
		base.transform.position = this.Target.position + new Vector3(0f, 0.15f, 0f);
	}

	// Token: 0x0400201F RID: 8223
	public Transform Target;
}
