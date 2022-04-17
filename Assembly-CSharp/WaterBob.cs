using System;
using UnityEngine;

// Token: 0x020004FC RID: 1276
[ExecuteAlways]
public class WaterBob : MonoBehaviour
{
	// Token: 0x0600212B RID: 8491 RVA: 0x001EB324 File Offset: 0x001E9524
	private void Awake()
	{
		this.initialPosition = base.transform.position;
		this.offset = 1f - UnityEngine.Random.value * 2f;
	}

	// Token: 0x0600212C RID: 8492 RVA: 0x001EB350 File Offset: 0x001E9550
	private void Update()
	{
		base.transform.position = this.initialPosition - Vector3.up * Mathf.Sin((Time.time + this.offset) * this.period) * this.height;
	}

	// Token: 0x04004964 RID: 18788
	[SerializeField]
	private float height = 0.1f;

	// Token: 0x04004965 RID: 18789
	[SerializeField]
	private float period = 1f;

	// Token: 0x04004966 RID: 18790
	private Vector3 initialPosition;

	// Token: 0x04004967 RID: 18791
	private float offset;
}
