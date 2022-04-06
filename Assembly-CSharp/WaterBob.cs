using System;
using UnityEngine;

// Token: 0x020004FC RID: 1276
[ExecuteAlways]
public class WaterBob : MonoBehaviour
{
	// Token: 0x06002124 RID: 8484 RVA: 0x001EA8C8 File Offset: 0x001E8AC8
	private void Awake()
	{
		this.initialPosition = base.transform.position;
		this.offset = 1f - UnityEngine.Random.value * 2f;
	}

	// Token: 0x06002125 RID: 8485 RVA: 0x001EA8F4 File Offset: 0x001E8AF4
	private void Update()
	{
		base.transform.position = this.initialPosition - Vector3.up * Mathf.Sin((Time.time + this.offset) * this.period) * this.height;
	}

	// Token: 0x04004952 RID: 18770
	[SerializeField]
	private float height = 0.1f;

	// Token: 0x04004953 RID: 18771
	[SerializeField]
	private float period = 1f;

	// Token: 0x04004954 RID: 18772
	private Vector3 initialPosition;

	// Token: 0x04004955 RID: 18773
	private float offset;
}
