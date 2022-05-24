using System;
using UnityEngine;

// Token: 0x020004CF RID: 1231
public class WritheScript : MonoBehaviour
{
	// Token: 0x06002035 RID: 8245 RVA: 0x001CC562 File Offset: 0x001CA762
	private void Start()
	{
		this.StartTime = Time.time;
		this.Duration = UnityEngine.Random.Range(1f, 5f);
	}

	// Token: 0x06002036 RID: 8246 RVA: 0x001CC584 File Offset: 0x001CA784
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

	// Token: 0x040043FF RID: 17407
	public float Rotation;

	// Token: 0x04004400 RID: 17408
	public float StartTime;

	// Token: 0x04004401 RID: 17409
	public float Duration;

	// Token: 0x04004402 RID: 17410
	public float StartValue;

	// Token: 0x04004403 RID: 17411
	public float EndValue;

	// Token: 0x04004404 RID: 17412
	public int ID;

	// Token: 0x04004405 RID: 17413
	public bool SpecialCase;
}
