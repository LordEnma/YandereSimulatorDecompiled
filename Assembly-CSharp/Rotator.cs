using System;
using UnityEngine;

// Token: 0x020004FF RID: 1279
public class Rotator : MonoBehaviour
{
	// Token: 0x0600213B RID: 8507 RVA: 0x001EC973 File Offset: 0x001EAB73
	private void Update()
	{
		base.transform.Rotate(0f, this.speed * Time.deltaTime, 0f);
	}

	// Token: 0x04004980 RID: 18816
	public float speed = 15f;
}
