using System;
using UnityEngine;

// Token: 0x0200048C RID: 1164
public class UpthrustScript : MonoBehaviour
{
	// Token: 0x06001F0E RID: 7950 RVA: 0x001B8724 File Offset: 0x001B6924
	private void Start()
	{
		this.startPosition = base.transform.localPosition;
	}

	// Token: 0x06001F0F RID: 7951 RVA: 0x001B8738 File Offset: 0x001B6938
	private void Update()
	{
		float d = this.amplitude * Mathf.Sin(6.2831855f * this.frequency * Time.time);
		base.transform.localPosition = this.startPosition + this.evaluatePosition(Time.time);
		base.transform.Rotate(this.rotationAmplitude * d);
	}

	// Token: 0x06001F10 RID: 7952 RVA: 0x001B879C File Offset: 0x001B699C
	private Vector3 evaluatePosition(float time)
	{
		float y = this.amplitude * Mathf.Sin(6.2831855f * this.frequency * time);
		return new Vector3(0f, y, 0f);
	}

	// Token: 0x04004152 RID: 16722
	[SerializeField]
	private float amplitude = 0.1f;

	// Token: 0x04004153 RID: 16723
	[SerializeField]
	private float frequency = 0.6f;

	// Token: 0x04004154 RID: 16724
	[SerializeField]
	private Vector3 rotationAmplitude = new Vector3(4.45f, 4.45f, 4.45f);

	// Token: 0x04004155 RID: 16725
	private Vector3 startPosition;
}
