using System;
using UnityEngine;

// Token: 0x020004F3 RID: 1267
[ExecuteAlways]
public class WaterBob : MonoBehaviour
{
	// Token: 0x060020F6 RID: 8438 RVA: 0x001E6BF4 File Offset: 0x001E4DF4
	private void Awake()
	{
		this.initialPosition = base.transform.position;
		this.offset = 1f - UnityEngine.Random.value * 2f;
	}

	// Token: 0x060020F7 RID: 8439 RVA: 0x001E6C20 File Offset: 0x001E4E20
	private void Update()
	{
		base.transform.position = this.initialPosition - Vector3.up * Mathf.Sin((Time.time + this.offset) * this.period) * this.height;
	}

	// Token: 0x040048BE RID: 18622
	[SerializeField]
	private float height = 0.1f;

	// Token: 0x040048BF RID: 18623
	[SerializeField]
	private float period = 1f;

	// Token: 0x040048C0 RID: 18624
	private Vector3 initialPosition;

	// Token: 0x040048C1 RID: 18625
	private float offset;
}
