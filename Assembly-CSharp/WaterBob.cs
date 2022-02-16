using System;
using UnityEngine;

// Token: 0x020004F1 RID: 1265
[ExecuteAlways]
public class WaterBob : MonoBehaviour
{
	// Token: 0x060020E7 RID: 8423 RVA: 0x001E563C File Offset: 0x001E383C
	private void Awake()
	{
		this.initialPosition = base.transform.position;
		this.offset = 1f - UnityEngine.Random.value * 2f;
	}

	// Token: 0x060020E8 RID: 8424 RVA: 0x001E5668 File Offset: 0x001E3868
	private void Update()
	{
		base.transform.position = this.initialPosition - Vector3.up * Mathf.Sin((Time.time + this.offset) * this.period) * this.height;
	}

	// Token: 0x04004891 RID: 18577
	[SerializeField]
	private float height = 0.1f;

	// Token: 0x04004892 RID: 18578
	[SerializeField]
	private float period = 1f;

	// Token: 0x04004893 RID: 18579
	private Vector3 initialPosition;

	// Token: 0x04004894 RID: 18580
	private float offset;
}
