using System;
using UnityEngine;

// Token: 0x020002CB RID: 715
public class FloatAbovePointScript : MonoBehaviour
{
	// Token: 0x0600149F RID: 5279 RVA: 0x000CAAC9 File Offset: 0x000C8CC9
	private void Update()
	{
		base.transform.position = this.Target.position + new Vector3(0f, 0.15f, 0f);
	}

	// Token: 0x04002036 RID: 8246
	public Transform Target;
}
