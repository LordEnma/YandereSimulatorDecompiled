using System;
using UnityEngine;

// Token: 0x020004EB RID: 1259
[ExecuteAlways]
public class WaterBob : MonoBehaviour
{
	// Token: 0x060020B6 RID: 8374 RVA: 0x001E1038 File Offset: 0x001DF238
	private void Awake()
	{
		this.initialPosition = base.transform.position;
		this.offset = 1f - UnityEngine.Random.value * 2f;
	}

	// Token: 0x060020B7 RID: 8375 RVA: 0x001E1064 File Offset: 0x001DF264
	private void Update()
	{
		base.transform.position = this.initialPosition - Vector3.up * Mathf.Sin((Time.time + this.offset) * this.period) * this.height;
	}

	// Token: 0x04004811 RID: 18449
	[SerializeField]
	private float height = 0.1f;

	// Token: 0x04004812 RID: 18450
	[SerializeField]
	private float period = 1f;

	// Token: 0x04004813 RID: 18451
	private Vector3 initialPosition;

	// Token: 0x04004814 RID: 18452
	private float offset;
}
