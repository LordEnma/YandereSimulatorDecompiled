using System;
using UnityEngine;

// Token: 0x020002CF RID: 719
public class FloatAbovePointScript : MonoBehaviour
{
	// Token: 0x060014BC RID: 5308 RVA: 0x000CC66D File Offset: 0x000CA86D
	private void Update()
	{
		base.transform.position = this.Target.position + new Vector3(0f, 0.15f, 0f);
	}

	// Token: 0x04002077 RID: 8311
	public Transform Target;
}
