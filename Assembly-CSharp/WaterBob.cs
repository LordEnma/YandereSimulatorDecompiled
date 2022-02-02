using System;
using UnityEngine;

// Token: 0x020004F0 RID: 1264
[ExecuteAlways]
public class WaterBob : MonoBehaviour
{
	// Token: 0x060020DB RID: 8411 RVA: 0x001E4C6C File Offset: 0x001E2E6C
	private void Awake()
	{
		this.initialPosition = base.transform.position;
		this.offset = 1f - UnityEngine.Random.value * 2f;
	}

	// Token: 0x060020DC RID: 8412 RVA: 0x001E4C98 File Offset: 0x001E2E98
	private void Update()
	{
		base.transform.position = this.initialPosition - Vector3.up * Mathf.Sin((Time.time + this.offset) * this.period) * this.height;
	}

	// Token: 0x0400487F RID: 18559
	[SerializeField]
	private float height = 0.1f;

	// Token: 0x04004880 RID: 18560
	[SerializeField]
	private float period = 1f;

	// Token: 0x04004881 RID: 18561
	private Vector3 initialPosition;

	// Token: 0x04004882 RID: 18562
	private float offset;
}
