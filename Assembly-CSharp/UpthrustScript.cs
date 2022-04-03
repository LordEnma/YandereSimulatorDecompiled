using System;
using UnityEngine;

// Token: 0x02000494 RID: 1172
public class UpthrustScript : MonoBehaviour
{
	// Token: 0x06001F40 RID: 8000 RVA: 0x001BCD90 File Offset: 0x001BAF90
	private void Start()
	{
		this.startPosition = base.transform.localPosition;
	}

	// Token: 0x06001F41 RID: 8001 RVA: 0x001BCDA4 File Offset: 0x001BAFA4
	private void Update()
	{
		float d = this.amplitude * Mathf.Sin(6.2831855f * this.frequency * Time.time);
		base.transform.localPosition = this.startPosition + this.evaluatePosition(Time.time);
		base.transform.Rotate(this.rotationAmplitude * d);
	}

	// Token: 0x06001F42 RID: 8002 RVA: 0x001BCE08 File Offset: 0x001BB008
	private Vector3 evaluatePosition(float time)
	{
		float y = this.amplitude * Mathf.Sin(6.2831855f * this.frequency * time);
		return new Vector3(0f, y, 0f);
	}

	// Token: 0x040041FD RID: 16893
	[SerializeField]
	private float amplitude = 0.1f;

	// Token: 0x040041FE RID: 16894
	[SerializeField]
	private float frequency = 0.6f;

	// Token: 0x040041FF RID: 16895
	[SerializeField]
	private Vector3 rotationAmplitude = new Vector3(4.45f, 4.45f, 4.45f);

	// Token: 0x04004200 RID: 16896
	private Vector3 startPosition;
}
