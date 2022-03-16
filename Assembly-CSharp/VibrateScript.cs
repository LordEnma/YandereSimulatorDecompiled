using System;
using UnityEngine;

// Token: 0x020004B6 RID: 1206
public class VibrateScript : MonoBehaviour
{
	// Token: 0x06001FA4 RID: 8100 RVA: 0x001BC909 File Offset: 0x001BAB09
	private void Start()
	{
		this.Origin = base.transform.localPosition;
	}

	// Token: 0x06001FA5 RID: 8101 RVA: 0x001BC91C File Offset: 0x001BAB1C
	private void Update()
	{
		base.transform.localPosition = new Vector3(this.Origin.x + UnityEngine.Random.Range(-5f, 5f), this.Origin.y + UnityEngine.Random.Range(-5f, 5f), base.transform.localPosition.z);
	}

	// Token: 0x040041FF RID: 16895
	public Vector3 Origin;
}
