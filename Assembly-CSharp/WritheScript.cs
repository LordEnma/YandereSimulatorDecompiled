using System;
using UnityEngine;

// Token: 0x020004C8 RID: 1224
public class WritheScript : MonoBehaviour
{
	// Token: 0x06002005 RID: 8197 RVA: 0x001C6FBE File Offset: 0x001C51BE
	private void Start()
	{
		this.StartTime = Time.time;
		this.Duration = UnityEngine.Random.Range(1f, 5f);
	}

	// Token: 0x06002006 RID: 8198 RVA: 0x001C6FE0 File Offset: 0x001C51E0
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

	// Token: 0x04004375 RID: 17269
	public float Rotation;

	// Token: 0x04004376 RID: 17270
	public float StartTime;

	// Token: 0x04004377 RID: 17271
	public float Duration;

	// Token: 0x04004378 RID: 17272
	public float StartValue;

	// Token: 0x04004379 RID: 17273
	public float EndValue;

	// Token: 0x0400437A RID: 17274
	public int ID;

	// Token: 0x0400437B RID: 17275
	public bool SpecialCase;
}
