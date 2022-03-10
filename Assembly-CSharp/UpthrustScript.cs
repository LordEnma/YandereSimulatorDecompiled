using System;
using UnityEngine;

// Token: 0x0200048E RID: 1166
public class UpthrustScript : MonoBehaviour
{
	// Token: 0x06001F24 RID: 7972 RVA: 0x001BA084 File Offset: 0x001B8284
	private void Start()
	{
		this.startPosition = base.transform.localPosition;
	}

	// Token: 0x06001F25 RID: 7973 RVA: 0x001BA098 File Offset: 0x001B8298
	private void Update()
	{
		float d = this.amplitude * Mathf.Sin(6.2831855f * this.frequency * Time.time);
		base.transform.localPosition = this.startPosition + this.evaluatePosition(Time.time);
		base.transform.Rotate(this.rotationAmplitude * d);
	}

	// Token: 0x06001F26 RID: 7974 RVA: 0x001BA0FC File Offset: 0x001B82FC
	private Vector3 evaluatePosition(float time)
	{
		float y = this.amplitude * Mathf.Sin(6.2831855f * this.frequency * time);
		return new Vector3(0f, y, 0f);
	}

	// Token: 0x04004185 RID: 16773
	[SerializeField]
	private float amplitude = 0.1f;

	// Token: 0x04004186 RID: 16774
	[SerializeField]
	private float frequency = 0.6f;

	// Token: 0x04004187 RID: 16775
	[SerializeField]
	private Vector3 rotationAmplitude = new Vector3(4.45f, 4.45f, 4.45f);

	// Token: 0x04004188 RID: 16776
	private Vector3 startPosition;
}
