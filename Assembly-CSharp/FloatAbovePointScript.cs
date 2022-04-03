using System;
using UnityEngine;

// Token: 0x020002CD RID: 717
public class FloatAbovePointScript : MonoBehaviour
{
	// Token: 0x060014AE RID: 5294 RVA: 0x000CBB74 File Offset: 0x000C9D74
	private void Update()
	{
		base.transform.position = this.Target.position + new Vector3(0f, 0.15f, 0f);
	}

	// Token: 0x04002063 RID: 8291
	public Transform Target;
}
