using System;
using UnityEngine;

// Token: 0x0200048C RID: 1164
public class UpthrustScript : MonoBehaviour
{
	// Token: 0x06001F0A RID: 7946 RVA: 0x001B7EF0 File Offset: 0x001B60F0
	private void Start()
	{
		this.startPosition = base.transform.localPosition;
	}

	// Token: 0x06001F0B RID: 7947 RVA: 0x001B7F04 File Offset: 0x001B6104
	private void Update()
	{
		float d = this.amplitude * Mathf.Sin(6.2831855f * this.frequency * Time.time);
		base.transform.localPosition = this.startPosition + this.evaluatePosition(Time.time);
		base.transform.Rotate(this.rotationAmplitude * d);
	}

	// Token: 0x06001F0C RID: 7948 RVA: 0x001B7F68 File Offset: 0x001B6168
	private Vector3 evaluatePosition(float time)
	{
		float y = this.amplitude * Mathf.Sin(6.2831855f * this.frequency * time);
		return new Vector3(0f, y, 0f);
	}

	// Token: 0x04004144 RID: 16708
	[SerializeField]
	private float amplitude = 0.1f;

	// Token: 0x04004145 RID: 16709
	[SerializeField]
	private float frequency = 0.6f;

	// Token: 0x04004146 RID: 16710
	[SerializeField]
	private Vector3 rotationAmplitude = new Vector3(4.45f, 4.45f, 4.45f);

	// Token: 0x04004147 RID: 16711
	private Vector3 startPosition;
}
