using System;
using UnityEngine;

// Token: 0x020004CE RID: 1230
public class WritheScript : MonoBehaviour
{
	// Token: 0x0600202A RID: 8234 RVA: 0x001CAAFA File Offset: 0x001C8CFA
	private void Start()
	{
		this.StartTime = Time.time;
		this.Duration = UnityEngine.Random.Range(1f, 5f);
	}

	// Token: 0x0600202B RID: 8235 RVA: 0x001CAB1C File Offset: 0x001C8D1C
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

	// Token: 0x040043D0 RID: 17360
	public float Rotation;

	// Token: 0x040043D1 RID: 17361
	public float StartTime;

	// Token: 0x040043D2 RID: 17362
	public float Duration;

	// Token: 0x040043D3 RID: 17363
	public float StartValue;

	// Token: 0x040043D4 RID: 17364
	public float EndValue;

	// Token: 0x040043D5 RID: 17365
	public int ID;

	// Token: 0x040043D6 RID: 17366
	public bool SpecialCase;
}
