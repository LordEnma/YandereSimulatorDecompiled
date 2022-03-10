using System;
using UnityEngine;

// Token: 0x020004C4 RID: 1220
public class WritheScript : MonoBehaviour
{
	// Token: 0x06001FEF RID: 8175 RVA: 0x001C5272 File Offset: 0x001C3472
	private void Start()
	{
		this.StartTime = Time.time;
		this.Duration = UnityEngine.Random.Range(1f, 5f);
	}

	// Token: 0x06001FF0 RID: 8176 RVA: 0x001C5294 File Offset: 0x001C3494
	private void Update()
	{
		if (this.Rotation == this.EndValue)
		{
			this.StartValue = this.EndValue;
			this.EndValue = UnityEngine.Random.Range(-45f, 45f);
			this.StartTime = Time.time;
			this.Duration = UnityEngine.Random.Range(1f, 5f);
		}
		float t = (Time.time - this.StartTime) / this.Duration;
		this.Rotation = Mathf.SmoothStep(this.StartValue, this.EndValue, t);
		switch (this.ID)
		{
		case 1:
			base.transform.localEulerAngles = new Vector3(this.Rotation, base.transform.localEulerAngles.y, base.transform.localEulerAngles.z);
			return;
		case 2:
			if (this.SpecialCase)
			{
				this.Rotation += 180f;
			}
			base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, this.Rotation, base.transform.localEulerAngles.z);
			return;
		case 3:
			base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y, this.Rotation);
			return;
		default:
			return;
		}
	}

	// Token: 0x0400431A RID: 17178
	public float Rotation;

	// Token: 0x0400431B RID: 17179
	public float StartTime;

	// Token: 0x0400431C RID: 17180
	public float Duration;

	// Token: 0x0400431D RID: 17181
	public float StartValue;

	// Token: 0x0400431E RID: 17182
	public float EndValue;

	// Token: 0x0400431F RID: 17183
	public int ID;

	// Token: 0x04004320 RID: 17184
	public bool SpecialCase;
}
