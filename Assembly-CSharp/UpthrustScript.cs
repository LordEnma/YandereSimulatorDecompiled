using System;
using UnityEngine;

// Token: 0x0200048C RID: 1164
public class UpthrustScript : MonoBehaviour
{
	// Token: 0x06001F11 RID: 7953 RVA: 0x001B8944 File Offset: 0x001B6B44
	private void Start()
	{
		this.startPosition = base.transform.localPosition;
	}

	// Token: 0x06001F12 RID: 7954 RVA: 0x001B8958 File Offset: 0x001B6B58
	private void Update()
	{
		float d = this.amplitude * Mathf.Sin(6.2831855f * this.frequency * Time.time);
		base.transform.localPosition = this.startPosition + this.evaluatePosition(Time.time);
		base.transform.Rotate(this.rotationAmplitude * d);
	}

	// Token: 0x06001F13 RID: 7955 RVA: 0x001B89BC File Offset: 0x001B6BBC
	private Vector3 evaluatePosition(float time)
	{
		float y = this.amplitude * Mathf.Sin(6.2831855f * this.frequency * time);
		return new Vector3(0f, y, 0f);
	}

	// Token: 0x04004155 RID: 16725
	[SerializeField]
	private float amplitude = 0.1f;

	// Token: 0x04004156 RID: 16726
	[SerializeField]
	private float frequency = 0.6f;

	// Token: 0x04004157 RID: 16727
	[SerializeField]
	private Vector3 rotationAmplitude = new Vector3(4.45f, 4.45f, 4.45f);

	// Token: 0x04004158 RID: 16728
	private Vector3 startPosition;
}
