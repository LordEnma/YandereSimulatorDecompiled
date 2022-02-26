using System;
using UnityEngine;

// Token: 0x020002CC RID: 716
public class FloatAbovePointScript : MonoBehaviour
{
	// Token: 0x060014A8 RID: 5288 RVA: 0x000CB3AD File Offset: 0x000C95AD
	private void Update()
	{
		base.transform.position = this.Target.position + new Vector3(0f, 0.15f, 0f);
	}

	// Token: 0x04002045 RID: 8261
	public Transform Target;
}
