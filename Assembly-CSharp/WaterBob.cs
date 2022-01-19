using System;
using UnityEngine;

// Token: 0x020004F0 RID: 1264
[ExecuteAlways]
public class WaterBob : MonoBehaviour
{
	// Token: 0x060020D7 RID: 8407 RVA: 0x001E43CC File Offset: 0x001E25CC
	private void Awake()
	{
		this.initialPosition = base.transform.position;
		this.offset = 1f - UnityEngine.Random.value * 2f;
	}

	// Token: 0x060020D8 RID: 8408 RVA: 0x001E43F8 File Offset: 0x001E25F8
	private void Update()
	{
		base.transform.position = this.initialPosition - Vector3.up * Mathf.Sin((Time.time + this.offset) * this.period) * this.height;
	}

	// Token: 0x04004874 RID: 18548
	[SerializeField]
	private float height = 0.1f;

	// Token: 0x04004875 RID: 18549
	[SerializeField]
	private float period = 1f;

	// Token: 0x04004876 RID: 18550
	private Vector3 initialPosition;

	// Token: 0x04004877 RID: 18551
	private float offset;
}
