using System;
using UnityEngine;

// Token: 0x020004F2 RID: 1266
[ExecuteAlways]
public class WaterBob : MonoBehaviour
{
	// Token: 0x060020F0 RID: 8432 RVA: 0x001E621C File Offset: 0x001E441C
	private void Awake()
	{
		this.initialPosition = base.transform.position;
		this.offset = 1f - UnityEngine.Random.value * 2f;
	}

	// Token: 0x060020F1 RID: 8433 RVA: 0x001E6248 File Offset: 0x001E4448
	private void Update()
	{
		base.transform.position = this.initialPosition - Vector3.up * Mathf.Sin((Time.time + this.offset) * this.period) * this.height;
	}

	// Token: 0x040048A1 RID: 18593
	[SerializeField]
	private float height = 0.1f;

	// Token: 0x040048A2 RID: 18594
	[SerializeField]
	private float period = 1f;

	// Token: 0x040048A3 RID: 18595
	private Vector3 initialPosition;

	// Token: 0x040048A4 RID: 18596
	private float offset;
}
