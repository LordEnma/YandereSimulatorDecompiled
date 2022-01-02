using System;
using UnityEngine;

// Token: 0x020004BE RID: 1214
public class WritheScript : MonoBehaviour
{
	// Token: 0x06001FC5 RID: 8133 RVA: 0x001C188A File Offset: 0x001BFA8A
	private void Start()
	{
		this.StartTime = Time.time;
		this.Duration = UnityEngine.Random.Range(1f, 5f);
	}

	// Token: 0x06001FC6 RID: 8134 RVA: 0x001C18AC File Offset: 0x001BFAAC
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

	// Token: 0x040042B8 RID: 17080
	public float Rotation;

	// Token: 0x040042B9 RID: 17081
	public float StartTime;

	// Token: 0x040042BA RID: 17082
	public float Duration;

	// Token: 0x040042BB RID: 17083
	public float StartValue;

	// Token: 0x040042BC RID: 17084
	public float EndValue;

	// Token: 0x040042BD RID: 17085
	public int ID;

	// Token: 0x040042BE RID: 17086
	public bool SpecialCase;
}
