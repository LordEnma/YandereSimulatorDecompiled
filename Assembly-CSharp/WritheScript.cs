using System;
using UnityEngine;

// Token: 0x020004C1 RID: 1217
public class WritheScript : MonoBehaviour
{
	// Token: 0x06001FD2 RID: 8146 RVA: 0x001C2EDA File Offset: 0x001C10DA
	private void Start()
	{
		this.StartTime = Time.time;
		this.Duration = UnityEngine.Random.Range(1f, 5f);
	}

	// Token: 0x06001FD3 RID: 8147 RVA: 0x001C2EFC File Offset: 0x001C10FC
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

	// Token: 0x040042D3 RID: 17107
	public float Rotation;

	// Token: 0x040042D4 RID: 17108
	public float StartTime;

	// Token: 0x040042D5 RID: 17109
	public float Duration;

	// Token: 0x040042D6 RID: 17110
	public float StartValue;

	// Token: 0x040042D7 RID: 17111
	public float EndValue;

	// Token: 0x040042D8 RID: 17112
	public int ID;

	// Token: 0x040042D9 RID: 17113
	public bool SpecialCase;
}
