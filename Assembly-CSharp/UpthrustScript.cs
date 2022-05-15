using System;
using UnityEngine;

// Token: 0x02000497 RID: 1175
public class UpthrustScript : MonoBehaviour
{
	// Token: 0x06001F61 RID: 8033 RVA: 0x001C02C4 File Offset: 0x001BE4C4
	private void Start()
	{
		this.startPosition = base.transform.localPosition;
	}

	// Token: 0x06001F62 RID: 8034 RVA: 0x001C02D8 File Offset: 0x001BE4D8
	private void Update()
	{
		float d = this.amplitude * Mathf.Sin(6.2831855f * this.frequency * Time.time);
		base.transform.localPosition = this.startPosition + this.evaluatePosition(Time.time);
		base.transform.Rotate(this.rotationAmplitude * d);
	}

	// Token: 0x06001F63 RID: 8035 RVA: 0x001C033C File Offset: 0x001BE53C
	private Vector3 evaluatePosition(float time)
	{
		float y = this.amplitude * Mathf.Sin(6.2831855f * this.frequency * time);
		return new Vector3(0f, y, 0f);
	}

	// Token: 0x04004244 RID: 16964
	[SerializeField]
	private float amplitude = 0.1f;

	// Token: 0x04004245 RID: 16965
	[SerializeField]
	private float frequency = 0.6f;

	// Token: 0x04004246 RID: 16966
	[SerializeField]
	private Vector3 rotationAmplitude = new Vector3(4.45f, 4.45f, 4.45f);

	// Token: 0x04004247 RID: 16967
	private Vector3 startPosition;
}
