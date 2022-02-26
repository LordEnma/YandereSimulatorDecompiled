using System;
using UnityEngine;

// Token: 0x02000306 RID: 774
public class GrandfatherScript : MonoBehaviour
{
	// Token: 0x06001829 RID: 6185 RVA: 0x000E5308 File Offset: 0x000E3508
	private void Update()
	{
		if (!this.Flip)
		{
			if ((double)this.Force < 0.1)
			{
				this.Force += Time.deltaTime * 0.1f * this.Speed;
			}
		}
		else if ((double)this.Force > -0.1)
		{
			this.Force -= Time.deltaTime * 0.1f * this.Speed;
		}
		this.Rotation += this.Force;
		if (this.Rotation > 1f)
		{
			this.Flip = true;
		}
		else if (this.Rotation < -1f)
		{
			this.Flip = false;
		}
		if (this.Rotation > 5f)
		{
			this.Rotation = 5f;
		}
		else if (this.Rotation < -5f)
		{
			this.Rotation = -5f;
		}
		this.Pendulum.localEulerAngles = new Vector3(0f, 0f, this.Rotation);
		this.MinuteHand.localEulerAngles = new Vector3(this.MinuteHand.localEulerAngles.x, this.MinuteHand.localEulerAngles.y, this.Clock.Minute * 6f);
		this.HourHand.localEulerAngles = new Vector3(this.HourHand.localEulerAngles.x, this.HourHand.localEulerAngles.y, this.Clock.Hour * 30f);
	}

	// Token: 0x0400230B RID: 8971
	public ClockScript Clock;

	// Token: 0x0400230C RID: 8972
	public Transform MinuteHand;

	// Token: 0x0400230D RID: 8973
	public Transform HourHand;

	// Token: 0x0400230E RID: 8974
	public Transform Pendulum;

	// Token: 0x0400230F RID: 8975
	public float Rotation;

	// Token: 0x04002310 RID: 8976
	public float Force;

	// Token: 0x04002311 RID: 8977
	public float Speed;

	// Token: 0x04002312 RID: 8978
	public bool Flip;
}
