using System;
using UnityEngine;

// Token: 0x02000500 RID: 1280
public class Rotator : MonoBehaviour
{
	// Token: 0x06002146 RID: 8518 RVA: 0x001EE52B File Offset: 0x001EC72B
	private void Update()
	{
		base.transform.Rotate(0f, this.speed * Time.deltaTime, 0f);
	}

	// Token: 0x040049B0 RID: 18864
	public float speed = 15f;
}
