using System;
using UnityEngine;

// Token: 0x020004CD RID: 1229
public class WritheScript : MonoBehaviour
{
	// Token: 0x06002020 RID: 8224 RVA: 0x001C9642 File Offset: 0x001C7842
	private void Start()
	{
		this.StartTime = Time.time;
		this.Duration = UnityEngine.Random.Range(1f, 5f);
	}

	// Token: 0x06002021 RID: 8225 RVA: 0x001C9664 File Offset: 0x001C7864
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

	// Token: 0x040043BA RID: 17338
	public float Rotation;

	// Token: 0x040043BB RID: 17339
	public float StartTime;

	// Token: 0x040043BC RID: 17340
	public float Duration;

	// Token: 0x040043BD RID: 17341
	public float StartValue;

	// Token: 0x040043BE RID: 17342
	public float EndValue;

	// Token: 0x040043BF RID: 17343
	public int ID;

	// Token: 0x040043C0 RID: 17344
	public bool SpecialCase;
}
