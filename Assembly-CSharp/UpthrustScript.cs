using System;
using UnityEngine;

// Token: 0x02000497 RID: 1175
public class UpthrustScript : MonoBehaviour
{
	// Token: 0x06001F62 RID: 8034 RVA: 0x001C0740 File Offset: 0x001BE940
	private void Start()
	{
		this.startPosition = base.transform.localPosition;
	}

	// Token: 0x06001F63 RID: 8035 RVA: 0x001C0754 File Offset: 0x001BE954
	private void Update()
	{
		float d = this.amplitude * Mathf.Sin(6.2831855f * this.frequency * Time.time);
		base.transform.localPosition = this.startPosition + this.evaluatePosition(Time.time);
		base.transform.Rotate(this.rotationAmplitude * d);
	}

	// Token: 0x06001F64 RID: 8036 RVA: 0x001C07B8 File Offset: 0x001BE9B8
	private Vector3 evaluatePosition(float time)
	{
		float y = this.amplitude * Mathf.Sin(6.2831855f * this.frequency * time);
		return new Vector3(0f, y, 0f);
	}

	// Token: 0x0400424D RID: 16973
	[SerializeField]
	private float amplitude = 0.1f;

	// Token: 0x0400424E RID: 16974
	[SerializeField]
	private float frequency = 0.6f;

	// Token: 0x0400424F RID: 16975
	[SerializeField]
	private Vector3 rotationAmplitude = new Vector3(4.45f, 4.45f, 4.45f);

	// Token: 0x04004250 RID: 16976
	private Vector3 startPosition;
}
