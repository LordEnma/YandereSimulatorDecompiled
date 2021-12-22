using System;
using UnityEngine;

// Token: 0x020004ED RID: 1261
[ExecuteAlways]
public class WaterBob : MonoBehaviour
{
	// Token: 0x060020C7 RID: 8391 RVA: 0x001E276C File Offset: 0x001E096C
	private void Awake()
	{
		this.initialPosition = base.transform.position;
		this.offset = 1f - UnityEngine.Random.value * 2f;
	}

	// Token: 0x060020C8 RID: 8392 RVA: 0x001E2798 File Offset: 0x001E0998
	private void Update()
	{
		base.transform.position = this.initialPosition - Vector3.up * Mathf.Sin((Time.time + this.offset) * this.period) * this.height;
	}

	// Token: 0x04004850 RID: 18512
	[SerializeField]
	private float height = 0.1f;

	// Token: 0x04004851 RID: 18513
	[SerializeField]
	private float period = 1f;

	// Token: 0x04004852 RID: 18514
	private Vector3 initialPosition;

	// Token: 0x04004853 RID: 18515
	private float offset;
}
