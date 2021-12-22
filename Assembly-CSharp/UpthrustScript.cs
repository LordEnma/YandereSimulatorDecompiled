using System;
using UnityEngine;

// Token: 0x02000489 RID: 1161
public class UpthrustScript : MonoBehaviour
{
	// Token: 0x06001EFA RID: 7930 RVA: 0x001B63C8 File Offset: 0x001B45C8
	private void Start()
	{
		this.startPosition = base.transform.localPosition;
	}

	// Token: 0x06001EFB RID: 7931 RVA: 0x001B63DC File Offset: 0x001B45DC
	private void Update()
	{
		float d = this.amplitude * Mathf.Sin(6.2831855f * this.frequency * Time.time);
		base.transform.localPosition = this.startPosition + this.evaluatePosition(Time.time);
		base.transform.Rotate(this.rotationAmplitude * d);
	}

	// Token: 0x06001EFC RID: 7932 RVA: 0x001B6440 File Offset: 0x001B4640
	private Vector3 evaluatePosition(float time)
	{
		float y = this.amplitude * Mathf.Sin(6.2831855f * this.frequency * time);
		return new Vector3(0f, y, 0f);
	}

	// Token: 0x04004122 RID: 16674
	[SerializeField]
	private float amplitude = 0.1f;

	// Token: 0x04004123 RID: 16675
	[SerializeField]
	private float frequency = 0.6f;

	// Token: 0x04004124 RID: 16676
	[SerializeField]
	private Vector3 rotationAmplitude = new Vector3(4.45f, 4.45f, 4.45f);

	// Token: 0x04004125 RID: 16677
	private Vector3 startPosition;
}
