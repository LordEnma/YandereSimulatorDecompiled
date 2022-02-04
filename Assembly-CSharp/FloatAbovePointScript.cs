using System;
using UnityEngine;

// Token: 0x020002CA RID: 714
public class FloatAbovePointScript : MonoBehaviour
{
	// Token: 0x0600149A RID: 5274 RVA: 0x000CA945 File Offset: 0x000C8B45
	private void Update()
	{
		base.transform.position = this.Target.position + new Vector3(0f, 0.15f, 0f);
	}

	// Token: 0x0400202F RID: 8239
	public Transform Target;
}
