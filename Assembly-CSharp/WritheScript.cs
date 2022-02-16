using System;
using UnityEngine;

// Token: 0x020004C2 RID: 1218
public class WritheScript : MonoBehaviour
{
	// Token: 0x06001FE0 RID: 8160 RVA: 0x001C3DC6 File Offset: 0x001C1FC6
	private void Start()
	{
		this.StartTime = Time.time;
		this.Duration = UnityEngine.Random.Range(1f, 5f);
	}

	// Token: 0x06001FE1 RID: 8161 RVA: 0x001C3DE8 File Offset: 0x001C1FE8
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

	// Token: 0x040042ED RID: 17133
	public float Rotation;

	// Token: 0x040042EE RID: 17134
	public float StartTime;

	// Token: 0x040042EF RID: 17135
	public float Duration;

	// Token: 0x040042F0 RID: 17136
	public float StartValue;

	// Token: 0x040042F1 RID: 17137
	public float EndValue;

	// Token: 0x040042F2 RID: 17138
	public int ID;

	// Token: 0x040042F3 RID: 17139
	public bool SpecialCase;
}
