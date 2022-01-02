using System;
using UnityEngine;

// Token: 0x02000489 RID: 1161
public class UpthrustScript : MonoBehaviour
{
	// Token: 0x06001EFD RID: 7933 RVA: 0x001B68A0 File Offset: 0x001B4AA0
	private void Start()
	{
		this.startPosition = base.transform.localPosition;
	}

	// Token: 0x06001EFE RID: 7934 RVA: 0x001B68B4 File Offset: 0x001B4AB4
	private void Update()
	{
		float d = this.amplitude * Mathf.Sin(6.2831855f * this.frequency * Time.time);
		base.transform.localPosition = this.startPosition + this.evaluatePosition(Time.time);
		base.transform.Rotate(this.rotationAmplitude * d);
	}

	// Token: 0x06001EFF RID: 7935 RVA: 0x001B6918 File Offset: 0x001B4B18
	private Vector3 evaluatePosition(float time)
	{
		float y = this.amplitude * Mathf.Sin(6.2831855f * this.frequency * time);
		return new Vector3(0f, y, 0f);
	}

	// Token: 0x04004129 RID: 16681
	[SerializeField]
	private float amplitude = 0.1f;

	// Token: 0x0400412A RID: 16682
	[SerializeField]
	private float frequency = 0.6f;

	// Token: 0x0400412B RID: 16683
	[SerializeField]
	private Vector3 rotationAmplitude = new Vector3(4.45f, 4.45f, 4.45f);

	// Token: 0x0400412C RID: 16684
	private Vector3 startPosition;
}
