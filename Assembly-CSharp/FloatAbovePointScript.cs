using System;
using UnityEngine;

// Token: 0x020002CE RID: 718
public class FloatAbovePointScript : MonoBehaviour
{
	// Token: 0x060014B4 RID: 5300 RVA: 0x000CBC7C File Offset: 0x000C9E7C
	private void Update()
	{
		base.transform.position = this.Target.position + new Vector3(0f, 0.15f, 0f);
	}

	// Token: 0x04002065 RID: 8293
	public Transform Target;
}
