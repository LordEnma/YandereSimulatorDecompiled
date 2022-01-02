using System;
using UnityEngine;

// Token: 0x020004ED RID: 1261
[ExecuteAlways]
public class WaterBob : MonoBehaviour
{
	// Token: 0x060020CA RID: 8394 RVA: 0x001E2D5C File Offset: 0x001E0F5C
	private void Awake()
	{
		this.initialPosition = base.transform.position;
		this.offset = 1f - UnityEngine.Random.value * 2f;
	}

	// Token: 0x060020CB RID: 8395 RVA: 0x001E2D88 File Offset: 0x001E0F88
	private void Update()
	{
		base.transform.position = this.initialPosition - Vector3.up * Mathf.Sin((Time.time + this.offset) * this.period) * this.height;
	}

	// Token: 0x04004859 RID: 18521
	[SerializeField]
	private float height = 0.1f;

	// Token: 0x0400485A RID: 18522
	[SerializeField]
	private float period = 1f;

	// Token: 0x0400485B RID: 18523
	private Vector3 initialPosition;

	// Token: 0x0400485C RID: 18524
	private float offset;
}
