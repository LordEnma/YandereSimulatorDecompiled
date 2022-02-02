using System;
using UnityEngine;

// Token: 0x020004C1 RID: 1217
public class WritheScript : MonoBehaviour
{
	// Token: 0x06001FD4 RID: 8148 RVA: 0x001C3442 File Offset: 0x001C1642
	private void Start()
	{
		this.StartTime = Time.time;
		this.Duration = UnityEngine.Random.Range(1f, 5f);
	}

	// Token: 0x06001FD5 RID: 8149 RVA: 0x001C3464 File Offset: 0x001C1664
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

	// Token: 0x040042DB RID: 17115
	public float Rotation;

	// Token: 0x040042DC RID: 17116
	public float StartTime;

	// Token: 0x040042DD RID: 17117
	public float Duration;

	// Token: 0x040042DE RID: 17118
	public float StartValue;

	// Token: 0x040042DF RID: 17119
	public float EndValue;

	// Token: 0x040042E0 RID: 17120
	public int ID;

	// Token: 0x040042E1 RID: 17121
	public bool SpecialCase;
}
