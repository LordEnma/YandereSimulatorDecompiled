using System;
using UnityEngine;

// Token: 0x02000491 RID: 1169
public class UpthrustScript : MonoBehaviour
{
	// Token: 0x06001F36 RID: 7990 RVA: 0x001BB804 File Offset: 0x001B9A04
	private void Start()
	{
		this.startPosition = base.transform.localPosition;
	}

	// Token: 0x06001F37 RID: 7991 RVA: 0x001BB818 File Offset: 0x001B9A18
	private void Update()
	{
		float d = this.amplitude * Mathf.Sin(6.2831855f * this.frequency * Time.time);
		base.transform.localPosition = this.startPosition + this.evaluatePosition(Time.time);
		base.transform.Rotate(this.rotationAmplitude * d);
	}

	// Token: 0x06001F38 RID: 7992 RVA: 0x001BB87C File Offset: 0x001B9A7C
	private Vector3 evaluatePosition(float time)
	{
		float y = this.amplitude * Mathf.Sin(6.2831855f * this.frequency * time);
		return new Vector3(0f, y, 0f);
	}

	// Token: 0x040041D0 RID: 16848
	[SerializeField]
	private float amplitude = 0.1f;

	// Token: 0x040041D1 RID: 16849
	[SerializeField]
	private float frequency = 0.6f;

	// Token: 0x040041D2 RID: 16850
	[SerializeField]
	private Vector3 rotationAmplitude = new Vector3(4.45f, 4.45f, 4.45f);

	// Token: 0x040041D3 RID: 16851
	private Vector3 startPosition;
}
