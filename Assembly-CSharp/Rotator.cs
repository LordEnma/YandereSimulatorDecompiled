using System;
using UnityEngine;

// Token: 0x02000500 RID: 1280
public class Rotator : MonoBehaviour
{
	// Token: 0x06002145 RID: 8517 RVA: 0x001EDFC3 File Offset: 0x001EC1C3
	private void Update()
	{
		base.transform.Rotate(0f, this.speed * Time.deltaTime, 0f);
	}

	// Token: 0x040049A7 RID: 18855
	public float speed = 15f;
}
