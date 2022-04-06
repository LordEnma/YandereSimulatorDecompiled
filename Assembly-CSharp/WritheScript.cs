using System;
using UnityEngine;

// Token: 0x020004CD RID: 1229
public class WritheScript : MonoBehaviour
{
	// Token: 0x0600201A RID: 8218 RVA: 0x001C8C66 File Offset: 0x001C6E66
	private void Start()
	{
		this.StartTime = Time.time;
		this.Duration = UnityEngine.Random.Range(1f, 5f);
	}

	// Token: 0x0600201B RID: 8219 RVA: 0x001C8C88 File Offset: 0x001C6E88
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

	// Token: 0x040043AA RID: 17322
	public float Rotation;

	// Token: 0x040043AB RID: 17323
	public float StartTime;

	// Token: 0x040043AC RID: 17324
	public float Duration;

	// Token: 0x040043AD RID: 17325
	public float StartValue;

	// Token: 0x040043AE RID: 17326
	public float EndValue;

	// Token: 0x040043AF RID: 17327
	public int ID;

	// Token: 0x040043B0 RID: 17328
	public bool SpecialCase;
}
