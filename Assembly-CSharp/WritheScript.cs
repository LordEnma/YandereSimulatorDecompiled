using System;
using UnityEngine;

// Token: 0x020004C3 RID: 1219
public class WritheScript : MonoBehaviour
{
	// Token: 0x06001FE9 RID: 8169 RVA: 0x001C4952 File Offset: 0x001C2B52
	private void Start()
	{
		this.StartTime = Time.time;
		this.Duration = UnityEngine.Random.Range(1f, 5f);
	}

	// Token: 0x06001FEA RID: 8170 RVA: 0x001C4974 File Offset: 0x001C2B74
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

	// Token: 0x040042FD RID: 17149
	public float Rotation;

	// Token: 0x040042FE RID: 17150
	public float StartTime;

	// Token: 0x040042FF RID: 17151
	public float Duration;

	// Token: 0x04004300 RID: 17152
	public float StartValue;

	// Token: 0x04004301 RID: 17153
	public float EndValue;

	// Token: 0x04004302 RID: 17154
	public int ID;

	// Token: 0x04004303 RID: 17155
	public bool SpecialCase;
}
