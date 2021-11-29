using System;
using UnityEngine;

// Token: 0x020004BC RID: 1212
public class WritheScript : MonoBehaviour
{
	// Token: 0x06001FB1 RID: 8113 RVA: 0x001BFB42 File Offset: 0x001BDD42
	private void Start()
	{
		this.StartTime = Time.time;
		this.Duration = UnityEngine.Random.Range(1f, 5f);
	}

	// Token: 0x06001FB2 RID: 8114 RVA: 0x001BFB64 File Offset: 0x001BDD64
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

	// Token: 0x04004270 RID: 17008
	public float Rotation;

	// Token: 0x04004271 RID: 17009
	public float StartTime;

	// Token: 0x04004272 RID: 17010
	public float Duration;

	// Token: 0x04004273 RID: 17011
	public float StartValue;

	// Token: 0x04004274 RID: 17012
	public float EndValue;

	// Token: 0x04004275 RID: 17013
	public int ID;

	// Token: 0x04004276 RID: 17014
	public bool SpecialCase;
}
