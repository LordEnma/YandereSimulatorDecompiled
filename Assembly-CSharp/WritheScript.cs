using System;
using UnityEngine;

// Token: 0x020004C1 RID: 1217
public class WritheScript : MonoBehaviour
{
	// Token: 0x06001FD9 RID: 8153 RVA: 0x001C395E File Offset: 0x001C1B5E
	private void Start()
	{
		this.StartTime = Time.time;
		this.Duration = UnityEngine.Random.Range(1f, 5f);
	}

	// Token: 0x06001FDA RID: 8154 RVA: 0x001C3980 File Offset: 0x001C1B80
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

	// Token: 0x040042E4 RID: 17124
	public float Rotation;

	// Token: 0x040042E5 RID: 17125
	public float StartTime;

	// Token: 0x040042E6 RID: 17126
	public float Duration;

	// Token: 0x040042E7 RID: 17127
	public float StartValue;

	// Token: 0x040042E8 RID: 17128
	public float EndValue;

	// Token: 0x040042E9 RID: 17129
	public int ID;

	// Token: 0x040042EA RID: 17130
	public bool SpecialCase;
}
