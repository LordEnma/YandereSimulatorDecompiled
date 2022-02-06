using System;
using UnityEngine;

// Token: 0x020004F0 RID: 1264
[ExecuteAlways]
public class WaterBob : MonoBehaviour
{
	// Token: 0x060020E0 RID: 8416 RVA: 0x001E5188 File Offset: 0x001E3388
	private void Awake()
	{
		this.initialPosition = base.transform.position;
		this.offset = 1f - UnityEngine.Random.value * 2f;
	}

	// Token: 0x060020E1 RID: 8417 RVA: 0x001E51B4 File Offset: 0x001E33B4
	private void Update()
	{
		base.transform.position = this.initialPosition - Vector3.up * Mathf.Sin((Time.time + this.offset) * this.period) * this.height;
	}

	// Token: 0x04004888 RID: 18568
	[SerializeField]
	private float height = 0.1f;

	// Token: 0x04004889 RID: 18569
	[SerializeField]
	private float period = 1f;

	// Token: 0x0400488A RID: 18570
	private Vector3 initialPosition;

	// Token: 0x0400488B RID: 18571
	private float offset;
}
