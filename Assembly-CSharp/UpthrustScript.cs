using System;
using UnityEngine;

// Token: 0x02000488 RID: 1160
public class UpthrustScript : MonoBehaviour
{
	// Token: 0x06001EF0 RID: 7920 RVA: 0x001B560C File Offset: 0x001B380C
	private void Start()
	{
		this.startPosition = base.transform.localPosition;
	}

	// Token: 0x06001EF1 RID: 7921 RVA: 0x001B5620 File Offset: 0x001B3820
	private void Update()
	{
		float d = this.amplitude * Mathf.Sin(6.2831855f * this.frequency * Time.time);
		base.transform.localPosition = this.startPosition + this.evaluatePosition(Time.time);
		base.transform.Rotate(this.rotationAmplitude * d);
	}

	// Token: 0x06001EF2 RID: 7922 RVA: 0x001B5684 File Offset: 0x001B3884
	private Vector3 evaluatePosition(float time)
	{
		float y = this.amplitude * Mathf.Sin(6.2831855f * this.frequency * time);
		return new Vector3(0f, y, 0f);
	}

	// Token: 0x040040F2 RID: 16626
	[SerializeField]
	private float amplitude = 0.1f;

	// Token: 0x040040F3 RID: 16627
	[SerializeField]
	private float frequency = 0.6f;

	// Token: 0x040040F4 RID: 16628
	[SerializeField]
	private Vector3 rotationAmplitude = new Vector3(4.45f, 4.45f, 4.45f);

	// Token: 0x040040F5 RID: 16629
	private Vector3 startPosition;
}
