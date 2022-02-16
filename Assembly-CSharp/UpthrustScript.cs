using System;
using UnityEngine;

// Token: 0x0200048D RID: 1165
public class UpthrustScript : MonoBehaviour
{
	// Token: 0x06001F18 RID: 7960 RVA: 0x001B8D98 File Offset: 0x001B6F98
	private void Start()
	{
		this.startPosition = base.transform.localPosition;
	}

	// Token: 0x06001F19 RID: 7961 RVA: 0x001B8DAC File Offset: 0x001B6FAC
	private void Update()
	{
		float d = this.amplitude * Mathf.Sin(6.2831855f * this.frequency * Time.time);
		base.transform.localPosition = this.startPosition + this.evaluatePosition(Time.time);
		base.transform.Rotate(this.rotationAmplitude * d);
	}

	// Token: 0x06001F1A RID: 7962 RVA: 0x001B8E10 File Offset: 0x001B7010
	private Vector3 evaluatePosition(float time)
	{
		float y = this.amplitude * Mathf.Sin(6.2831855f * this.frequency * time);
		return new Vector3(0f, y, 0f);
	}

	// Token: 0x0400415E RID: 16734
	[SerializeField]
	private float amplitude = 0.1f;

	// Token: 0x0400415F RID: 16735
	[SerializeField]
	private float frequency = 0.6f;

	// Token: 0x04004160 RID: 16736
	[SerializeField]
	private Vector3 rotationAmplitude = new Vector3(4.45f, 4.45f, 4.45f);

	// Token: 0x04004161 RID: 16737
	private Vector3 startPosition;
}
