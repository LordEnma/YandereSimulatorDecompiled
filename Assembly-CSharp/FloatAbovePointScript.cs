using System;
using UnityEngine;

// Token: 0x020002CE RID: 718
public class FloatAbovePointScript : MonoBehaviour
{
	// Token: 0x060014BA RID: 5306 RVA: 0x000CC30D File Offset: 0x000CA50D
	private void Update()
	{
		base.transform.position = this.Target.position + new Vector3(0f, 0.15f, 0f);
	}

	// Token: 0x04002070 RID: 8304
	public Transform Target;
}
