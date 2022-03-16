using System;
using UnityEngine;

// Token: 0x020004F7 RID: 1271
[ExecuteAlways]
public class WaterBob : MonoBehaviour
{
	// Token: 0x0600210E RID: 8462 RVA: 0x001E8B5C File Offset: 0x001E6D5C
	private void Awake()
	{
		this.initialPosition = base.transform.position;
		this.offset = 1f - UnityEngine.Random.value * 2f;
	}

	// Token: 0x0600210F RID: 8463 RVA: 0x001E8B88 File Offset: 0x001E6D88
	private void Update()
	{
		base.transform.position = this.initialPosition - Vector3.up * Mathf.Sin((Time.time + this.offset) * this.period) * this.height;
	}

	// Token: 0x0400491D RID: 18717
	[SerializeField]
	private float height = 0.1f;

	// Token: 0x0400491E RID: 18718
	[SerializeField]
	private float period = 1f;

	// Token: 0x0400491F RID: 18719
	private Vector3 initialPosition;

	// Token: 0x04004920 RID: 18720
	private float offset;
}
