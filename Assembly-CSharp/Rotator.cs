using System;
using UnityEngine;

// Token: 0x020004FD RID: 1277
public class Rotator : MonoBehaviour
{
	// Token: 0x06002122 RID: 8482 RVA: 0x001EA45F File Offset: 0x001E865F
	private void Update()
	{
		base.transform.Rotate(0f, this.speed * Time.deltaTime, 0f);
	}

	// Token: 0x04004954 RID: 18772
	public float speed = 15f;
}
