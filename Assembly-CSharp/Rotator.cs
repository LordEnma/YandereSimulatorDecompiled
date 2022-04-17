using System;
using UnityEngine;

// Token: 0x020004FE RID: 1278
public class Rotator : MonoBehaviour
{
	// Token: 0x06002131 RID: 8497 RVA: 0x001EB3EB File Offset: 0x001E95EB
	private void Update()
	{
		base.transform.Rotate(0f, this.speed * Time.deltaTime, 0f);
	}

	// Token: 0x0400496A RID: 18794
	public float speed = 15f;
}
