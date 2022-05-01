using System;
using UnityEngine;

// Token: 0x020004FD RID: 1277
[ExecuteAlways]
public class WaterBob : MonoBehaviour
{
	// Token: 0x06002134 RID: 8500 RVA: 0x001EC7B0 File Offset: 0x001EA9B0
	private void Awake()
	{
		this.initialPosition = base.transform.position;
		this.offset = 1f - UnityEngine.Random.value * 2f;
	}

	// Token: 0x06002135 RID: 8501 RVA: 0x001EC7DC File Offset: 0x001EA9DC
	private void Update()
	{
		base.transform.position = this.initialPosition - Vector3.up * Mathf.Sin((Time.time + this.offset) * this.period) * this.height;
	}

	// Token: 0x0400497A RID: 18810
	[SerializeField]
	private float height = 0.1f;

	// Token: 0x0400497B RID: 18811
	[SerializeField]
	private float period = 1f;

	// Token: 0x0400497C RID: 18812
	private Vector3 initialPosition;

	// Token: 0x0400497D RID: 18813
	private float offset;
}
