using System;
using UnityEngine;

// Token: 0x020004FE RID: 1278
[ExecuteAlways]
public class WaterBob : MonoBehaviour
{
	// Token: 0x0600213F RID: 8511 RVA: 0x001EDEFC File Offset: 0x001EC0FC
	private void Awake()
	{
		this.initialPosition = base.transform.position;
		this.offset = 1f - UnityEngine.Random.value * 2f;
	}

	// Token: 0x06002140 RID: 8512 RVA: 0x001EDF28 File Offset: 0x001EC128
	private void Update()
	{
		base.transform.position = this.initialPosition - Vector3.up * Mathf.Sin((Time.time + this.offset) * this.period) * this.height;
	}

	// Token: 0x040049A1 RID: 18849
	[SerializeField]
	private float height = 0.1f;

	// Token: 0x040049A2 RID: 18850
	[SerializeField]
	private float period = 1f;

	// Token: 0x040049A3 RID: 18851
	private Vector3 initialPosition;

	// Token: 0x040049A4 RID: 18852
	private float offset;
}
