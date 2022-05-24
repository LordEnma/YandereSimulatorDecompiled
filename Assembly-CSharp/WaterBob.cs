using System;
using UnityEngine;

// Token: 0x020004FE RID: 1278
[ExecuteAlways]
public class WaterBob : MonoBehaviour
{
	// Token: 0x06002140 RID: 8512 RVA: 0x001EE464 File Offset: 0x001EC664
	private void Awake()
	{
		this.initialPosition = base.transform.position;
		this.offset = 1f - UnityEngine.Random.value * 2f;
	}

	// Token: 0x06002141 RID: 8513 RVA: 0x001EE490 File Offset: 0x001EC690
	private void Update()
	{
		base.transform.position = this.initialPosition - Vector3.up * Mathf.Sin((Time.time + this.offset) * this.period) * this.height;
	}

	// Token: 0x040049AA RID: 18858
	[SerializeField]
	private float height = 0.1f;

	// Token: 0x040049AB RID: 18859
	[SerializeField]
	private float period = 1f;

	// Token: 0x040049AC RID: 18860
	private Vector3 initialPosition;

	// Token: 0x040049AD RID: 18861
	private float offset;
}
