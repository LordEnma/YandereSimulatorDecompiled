using System;
using UnityEngine;

// Token: 0x020004F0 RID: 1264
[ExecuteAlways]
public class WaterBob : MonoBehaviour
{
	// Token: 0x060020DD RID: 8413 RVA: 0x001E4F84 File Offset: 0x001E3184
	private void Awake()
	{
		this.initialPosition = base.transform.position;
		this.offset = 1f - UnityEngine.Random.value * 2f;
	}

	// Token: 0x060020DE RID: 8414 RVA: 0x001E4FB0 File Offset: 0x001E31B0
	private void Update()
	{
		base.transform.position = this.initialPosition - Vector3.up * Mathf.Sin((Time.time + this.offset) * this.period) * this.height;
	}

	// Token: 0x04004885 RID: 18565
	[SerializeField]
	private float height = 0.1f;

	// Token: 0x04004886 RID: 18566
	[SerializeField]
	private float period = 1f;

	// Token: 0x04004887 RID: 18567
	private Vector3 initialPosition;

	// Token: 0x04004888 RID: 18568
	private float offset;
}
