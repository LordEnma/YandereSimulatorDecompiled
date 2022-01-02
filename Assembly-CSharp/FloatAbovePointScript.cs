using System;
using UnityEngine;

// Token: 0x020002C9 RID: 713
public class FloatAbovePointScript : MonoBehaviour
{
	// Token: 0x06001495 RID: 5269 RVA: 0x000CA0A9 File Offset: 0x000C82A9
	private void Update()
	{
		base.transform.position = this.Target.position + new Vector3(0f, 0.15f, 0f);
	}

	// Token: 0x04002022 RID: 8226
	public Transform Target;
}
