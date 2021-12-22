using System;
using UnityEngine;

// Token: 0x020004BE RID: 1214
public class WritheScript : MonoBehaviour
{
	// Token: 0x06001FC2 RID: 8130 RVA: 0x001C126A File Offset: 0x001BF46A
	private void Start()
	{
		this.StartTime = Time.time;
		this.Duration = UnityEngine.Random.Range(1f, 5f);
	}

	// Token: 0x06001FC3 RID: 8131 RVA: 0x001C128C File Offset: 0x001BF48C
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

	// Token: 0x040042AF RID: 17071
	public float Rotation;

	// Token: 0x040042B0 RID: 17072
	public float StartTime;

	// Token: 0x040042B1 RID: 17073
	public float Duration;

	// Token: 0x040042B2 RID: 17074
	public float StartValue;

	// Token: 0x040042B3 RID: 17075
	public float EndValue;

	// Token: 0x040042B4 RID: 17076
	public int ID;

	// Token: 0x040042B5 RID: 17077
	public bool SpecialCase;
}
