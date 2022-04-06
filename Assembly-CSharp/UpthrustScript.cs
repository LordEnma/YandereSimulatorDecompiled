using System;
using UnityEngine;

// Token: 0x02000495 RID: 1173
public class UpthrustScript : MonoBehaviour
{
	// Token: 0x06001F48 RID: 8008 RVA: 0x001BD298 File Offset: 0x001BB498
	private void Start()
	{
		this.startPosition = base.transform.localPosition;
	}

	// Token: 0x06001F49 RID: 8009 RVA: 0x001BD2AC File Offset: 0x001BB4AC
	private void Update()
	{
		float d = this.amplitude * Mathf.Sin(6.2831855f * this.frequency * Time.time);
		base.transform.localPosition = this.startPosition + this.evaluatePosition(Time.time);
		base.transform.Rotate(this.rotationAmplitude * d);
	}

	// Token: 0x06001F4A RID: 8010 RVA: 0x001BD310 File Offset: 0x001BB510
	private Vector3 evaluatePosition(float time)
	{
		float y = this.amplitude * Mathf.Sin(6.2831855f * this.frequency * time);
		return new Vector3(0f, y, 0f);
	}

	// Token: 0x04004200 RID: 16896
	[SerializeField]
	private float amplitude = 0.1f;

	// Token: 0x04004201 RID: 16897
	[SerializeField]
	private float frequency = 0.6f;

	// Token: 0x04004202 RID: 16898
	[SerializeField]
	private Vector3 rotationAmplitude = new Vector3(4.45f, 4.45f, 4.45f);

	// Token: 0x04004203 RID: 16899
	private Vector3 startPosition;
}
