using System;
using UnityEngine;

// Token: 0x020002CE RID: 718
public class FloatAbovePointScript : MonoBehaviour
{
	// Token: 0x060014B6 RID: 5302 RVA: 0x000CBE45 File Offset: 0x000CA045
	private void Update()
	{
		base.transform.position = this.Target.position + new Vector3(0f, 0.15f, 0f);
	}

	// Token: 0x04002067 RID: 8295
	public Transform Target;
}
