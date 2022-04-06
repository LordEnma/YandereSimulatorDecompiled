using System;
using UnityEngine;

// Token: 0x020004FE RID: 1278
public class Rotator : MonoBehaviour
{
	// Token: 0x0600212A RID: 8490 RVA: 0x001EA98F File Offset: 0x001E8B8F
	private void Update()
	{
		base.transform.Rotate(0f, this.speed * Time.deltaTime, 0f);
	}

	// Token: 0x04004958 RID: 18776
	public float speed = 15f;
}
