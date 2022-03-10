using System;
using UnityEngine;

// Token: 0x02000306 RID: 774
public class GrandfatherScript : MonoBehaviour
{
	// Token: 0x06001829 RID: 6185 RVA: 0x000E5638 File Offset: 0x000E3838
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

	// Token: 0x0400231F RID: 8991
	public ClockScript Clock;

	// Token: 0x04002320 RID: 8992
	public Transform MinuteHand;

	// Token: 0x04002321 RID: 8993
	public Transform HourHand;

	// Token: 0x04002322 RID: 8994
	public Transform Pendulum;

	// Token: 0x04002323 RID: 8995
	public float Rotation;

	// Token: 0x04002324 RID: 8996
	public float Force;

	// Token: 0x04002325 RID: 8997
	public float Speed;

	// Token: 0x04002326 RID: 8998
	public bool Flip;
}
