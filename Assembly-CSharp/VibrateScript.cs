using System;
using UnityEngine;

// Token: 0x020004B9 RID: 1209
public class VibrateScript : MonoBehaviour
{
	// Token: 0x06001FAE RID: 8110 RVA: 0x001BDE95 File Offset: 0x001BC095
	private void Start()
	{
		this.Origin = base.transform.localPosition;
	}

	// Token: 0x06001FAF RID: 8111 RVA: 0x001BDEA8 File Offset: 0x001BC0A8
	private void Update()
	{
		base.transform.localPosition = new Vector3(this.Origin.x + UnityEngine.Random.Range(-5f, 5f), this.Origin.y + UnityEngine.Random.Range(-5f, 5f), base.transform.localPosition.z);
	}

	// Token: 0x0400422C RID: 16940
	public Vector3 Origin;
}
