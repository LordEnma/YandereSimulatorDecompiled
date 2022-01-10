using System;
using UnityEngine;

// Token: 0x020004EF RID: 1263
[ExecuteAlways]
public class WaterBob : MonoBehaviour
{
	// Token: 0x060020D5 RID: 8405 RVA: 0x001E36FC File Offset: 0x001E18FC
	private void Awake()
	{
		this.initialPosition = base.transform.position;
		this.offset = 1f - UnityEngine.Random.value * 2f;
	}

	// Token: 0x060020D6 RID: 8406 RVA: 0x001E3728 File Offset: 0x001E1928
	private void Update()
	{
		base.transform.position = this.initialPosition - Vector3.up * Mathf.Sin((Time.time + this.offset) * this.period) * this.height;
	}

	// Token: 0x0400486D RID: 18541
	[SerializeField]
	private float height = 0.1f;

	// Token: 0x0400486E RID: 18542
	[SerializeField]
	private float period = 1f;

	// Token: 0x0400486F RID: 18543
	private Vector3 initialPosition;

	// Token: 0x04004870 RID: 18544
	private float offset;
}
