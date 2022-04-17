using System;
using UnityEngine;

// Token: 0x02000495 RID: 1173
public class UpthrustScript : MonoBehaviour
{
	// Token: 0x06001F4E RID: 8014 RVA: 0x001BDC74 File Offset: 0x001BBE74
	private void Start()
	{
		this.startPosition = base.transform.localPosition;
	}

	// Token: 0x06001F4F RID: 8015 RVA: 0x001BDC88 File Offset: 0x001BBE88
	private void Update()
	{
		float d = this.amplitude * Mathf.Sin(6.2831855f * this.frequency * Time.time);
		base.transform.localPosition = this.startPosition + this.evaluatePosition(Time.time);
		base.transform.Rotate(this.rotationAmplitude * d);
	}

	// Token: 0x06001F50 RID: 8016 RVA: 0x001BDCEC File Offset: 0x001BBEEC
	private Vector3 evaluatePosition(float time)
	{
		float y = this.amplitude * Mathf.Sin(6.2831855f * this.frequency * time);
		return new Vector3(0f, y, 0f);
	}

	// Token: 0x04004210 RID: 16912
	[SerializeField]
	private float amplitude = 0.1f;

	// Token: 0x04004211 RID: 16913
	[SerializeField]
	private float frequency = 0.6f;

	// Token: 0x04004212 RID: 16914
	[SerializeField]
	private Vector3 rotationAmplitude = new Vector3(4.45f, 4.45f, 4.45f);

	// Token: 0x04004213 RID: 16915
	private Vector3 startPosition;
}
