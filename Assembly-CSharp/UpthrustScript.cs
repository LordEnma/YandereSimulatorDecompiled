using System;
using UnityEngine;

// Token: 0x0200048E RID: 1166
public class UpthrustScript : MonoBehaviour
{
	// Token: 0x06001F21 RID: 7969 RVA: 0x001B98E4 File Offset: 0x001B7AE4
	private void Start()
	{
		this.startPosition = base.transform.localPosition;
	}

	// Token: 0x06001F22 RID: 7970 RVA: 0x001B98F8 File Offset: 0x001B7AF8
	private void Update()
	{
		float d = this.amplitude * Mathf.Sin(6.2831855f * this.frequency * Time.time);
		base.transform.localPosition = this.startPosition + this.evaluatePosition(Time.time);
		base.transform.Rotate(this.rotationAmplitude * d);
	}

	// Token: 0x06001F23 RID: 7971 RVA: 0x001B995C File Offset: 0x001B7B5C
	private Vector3 evaluatePosition(float time)
	{
		float y = this.amplitude * Mathf.Sin(6.2831855f * this.frequency * time);
		return new Vector3(0f, y, 0f);
	}

	// Token: 0x0400416E RID: 16750
	[SerializeField]
	private float amplitude = 0.1f;

	// Token: 0x0400416F RID: 16751
	[SerializeField]
	private float frequency = 0.6f;

	// Token: 0x04004170 RID: 16752
	[SerializeField]
	private Vector3 rotationAmplitude = new Vector3(4.45f, 4.45f, 4.45f);

	// Token: 0x04004171 RID: 16753
	private Vector3 startPosition;
}
