using System;
using UnityEngine;

// Token: 0x020004CF RID: 1231
public class WritheScript : MonoBehaviour
{
	// Token: 0x06002034 RID: 8244 RVA: 0x001CC04E File Offset: 0x001CA24E
	private void Start()
	{
		this.StartTime = Time.time;
		this.Duration = UnityEngine.Random.Range(1f, 5f);
	}

	// Token: 0x06002035 RID: 8245 RVA: 0x001CC070 File Offset: 0x001CA270
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

	// Token: 0x040043F6 RID: 17398
	public float Rotation;

	// Token: 0x040043F7 RID: 17399
	public float StartTime;

	// Token: 0x040043F8 RID: 17400
	public float Duration;

	// Token: 0x040043F9 RID: 17401
	public float StartValue;

	// Token: 0x040043FA RID: 17402
	public float EndValue;

	// Token: 0x040043FB RID: 17403
	public int ID;

	// Token: 0x040043FC RID: 17404
	public bool SpecialCase;
}
