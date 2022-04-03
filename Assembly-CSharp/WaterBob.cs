using System;
using UnityEngine;

// Token: 0x020004FB RID: 1275
[ExecuteAlways]
public class WaterBob : MonoBehaviour
{
	// Token: 0x0600211C RID: 8476 RVA: 0x001EA398 File Offset: 0x001E8598
	private void Awake()
	{
		this.initialPosition = base.transform.position;
		this.offset = 1f - UnityEngine.Random.value * 2f;
	}

	// Token: 0x0600211D RID: 8477 RVA: 0x001EA3C4 File Offset: 0x001E85C4
	private void Update()
	{
		base.transform.position = this.initialPosition - Vector3.up * Mathf.Sin((Time.time + this.offset) * this.period) * this.height;
	}

	// Token: 0x0400494E RID: 18766
	[SerializeField]
	private float height = 0.1f;

	// Token: 0x0400494F RID: 18767
	[SerializeField]
	private float period = 1f;

	// Token: 0x04004950 RID: 18768
	private Vector3 initialPosition;

	// Token: 0x04004951 RID: 18769
	private float offset;
}
