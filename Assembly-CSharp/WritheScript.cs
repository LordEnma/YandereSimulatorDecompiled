using System;
using UnityEngine;

// Token: 0x020004C0 RID: 1216
public class WritheScript : MonoBehaviour
{
	// Token: 0x06001FD0 RID: 8144 RVA: 0x001C220A File Offset: 0x001C040A
	private void Start()
	{
		this.StartTime = Time.time;
		this.Duration = UnityEngine.Random.Range(1f, 5f);
	}

	// Token: 0x06001FD1 RID: 8145 RVA: 0x001C222C File Offset: 0x001C042C
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

	// Token: 0x040042CC RID: 17100
	public float Rotation;

	// Token: 0x040042CD RID: 17101
	public float StartTime;

	// Token: 0x040042CE RID: 17102
	public float Duration;

	// Token: 0x040042CF RID: 17103
	public float StartValue;

	// Token: 0x040042D0 RID: 17104
	public float EndValue;

	// Token: 0x040042D1 RID: 17105
	public int ID;

	// Token: 0x040042D2 RID: 17106
	public bool SpecialCase;
}
