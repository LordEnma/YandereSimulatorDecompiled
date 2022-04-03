using System;
using UnityEngine;

// Token: 0x020004CC RID: 1228
public class WritheScript : MonoBehaviour
{
	// Token: 0x06002012 RID: 8210 RVA: 0x001C8746 File Offset: 0x001C6946
	private void Start()
	{
		this.StartTime = Time.time;
		this.Duration = UnityEngine.Random.Range(1f, 5f);
	}

	// Token: 0x06002013 RID: 8211 RVA: 0x001C8768 File Offset: 0x001C6968
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

	// Token: 0x040043A6 RID: 17318
	public float Rotation;

	// Token: 0x040043A7 RID: 17319
	public float StartTime;

	// Token: 0x040043A8 RID: 17320
	public float Duration;

	// Token: 0x040043A9 RID: 17321
	public float StartValue;

	// Token: 0x040043AA RID: 17322
	public float EndValue;

	// Token: 0x040043AB RID: 17323
	public int ID;

	// Token: 0x040043AC RID: 17324
	public bool SpecialCase;
}
