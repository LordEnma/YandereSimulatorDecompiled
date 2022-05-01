using System;
using UnityEngine;

// Token: 0x02000496 RID: 1174
public class UpthrustScript : MonoBehaviour
{
	// Token: 0x06001F57 RID: 8023 RVA: 0x001BF030 File Offset: 0x001BD230
	private void Start()
	{
		this.startPosition = base.transform.localPosition;
	}

	// Token: 0x06001F58 RID: 8024 RVA: 0x001BF044 File Offset: 0x001BD244
	private void Update()
	{
		float d = this.amplitude * Mathf.Sin(6.2831855f * this.frequency * Time.time);
		base.transform.localPosition = this.startPosition + this.evaluatePosition(Time.time);
		base.transform.Rotate(this.rotationAmplitude * d);
	}

	// Token: 0x06001F59 RID: 8025 RVA: 0x001BF0A8 File Offset: 0x001BD2A8
	private Vector3 evaluatePosition(float time)
	{
		float y = this.amplitude * Mathf.Sin(6.2831855f * this.frequency * time);
		return new Vector3(0f, y, 0f);
	}

	// Token: 0x04004226 RID: 16934
	[SerializeField]
	private float amplitude = 0.1f;

	// Token: 0x04004227 RID: 16935
	[SerializeField]
	private float frequency = 0.6f;

	// Token: 0x04004228 RID: 16936
	[SerializeField]
	private Vector3 rotationAmplitude = new Vector3(4.45f, 4.45f, 4.45f);

	// Token: 0x04004229 RID: 16937
	private Vector3 startPosition;
}
