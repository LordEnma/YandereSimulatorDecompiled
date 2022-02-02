using System;
using UnityEngine;

// Token: 0x0200048C RID: 1164
public class UpthrustScript : MonoBehaviour
{
	// Token: 0x06001F0C RID: 7948 RVA: 0x001B8418 File Offset: 0x001B6618
	private void Start()
	{
		this.startPosition = base.transform.localPosition;
	}

	// Token: 0x06001F0D RID: 7949 RVA: 0x001B842C File Offset: 0x001B662C
	private void Update()
	{
		float d = this.amplitude * Mathf.Sin(6.2831855f * this.frequency * Time.time);
		base.transform.localPosition = this.startPosition + this.evaluatePosition(Time.time);
		base.transform.Rotate(this.rotationAmplitude * d);
	}

	// Token: 0x06001F0E RID: 7950 RVA: 0x001B8490 File Offset: 0x001B6690
	private Vector3 evaluatePosition(float time)
	{
		float y = this.amplitude * Mathf.Sin(6.2831855f * this.frequency * time);
		return new Vector3(0f, y, 0f);
	}

	// Token: 0x0400414C RID: 16716
	[SerializeField]
	private float amplitude = 0.1f;

	// Token: 0x0400414D RID: 16717
	[SerializeField]
	private float frequency = 0.6f;

	// Token: 0x0400414E RID: 16718
	[SerializeField]
	private Vector3 rotationAmplitude = new Vector3(4.45f, 4.45f, 4.45f);

	// Token: 0x0400414F RID: 16719
	private Vector3 startPosition;
}
