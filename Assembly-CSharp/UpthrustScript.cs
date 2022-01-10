using System;
using UnityEngine;

// Token: 0x0200048B RID: 1163
public class UpthrustScript : MonoBehaviour
{
	// Token: 0x06001F08 RID: 7944 RVA: 0x001B7220 File Offset: 0x001B5420
	private void Start()
	{
		this.startPosition = base.transform.localPosition;
	}

	// Token: 0x06001F09 RID: 7945 RVA: 0x001B7234 File Offset: 0x001B5434
	private void Update()
	{
		float d = this.amplitude * Mathf.Sin(6.2831855f * this.frequency * Time.time);
		base.transform.localPosition = this.startPosition + this.evaluatePosition(Time.time);
		base.transform.Rotate(this.rotationAmplitude * d);
	}

	// Token: 0x06001F0A RID: 7946 RVA: 0x001B7298 File Offset: 0x001B5498
	private Vector3 evaluatePosition(float time)
	{
		float y = this.amplitude * Mathf.Sin(6.2831855f * this.frequency * time);
		return new Vector3(0f, y, 0f);
	}

	// Token: 0x0400413D RID: 16701
	[SerializeField]
	private float amplitude = 0.1f;

	// Token: 0x0400413E RID: 16702
	[SerializeField]
	private float frequency = 0.6f;

	// Token: 0x0400413F RID: 16703
	[SerializeField]
	private Vector3 rotationAmplitude = new Vector3(4.45f, 4.45f, 4.45f);

	// Token: 0x04004140 RID: 16704
	private Vector3 startPosition;
}
