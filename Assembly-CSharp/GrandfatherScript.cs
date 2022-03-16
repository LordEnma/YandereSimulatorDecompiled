using System;
using UnityEngine;

// Token: 0x02000306 RID: 774
public class GrandfatherScript : MonoBehaviour
{
	// Token: 0x0600182E RID: 6190 RVA: 0x000E5AE4 File Offset: 0x000E3CE4
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

	// Token: 0x04002330 RID: 9008
	public ClockScript Clock;

	// Token: 0x04002331 RID: 9009
	public Transform MinuteHand;

	// Token: 0x04002332 RID: 9010
	public Transform HourHand;

	// Token: 0x04002333 RID: 9011
	public Transform Pendulum;

	// Token: 0x04002334 RID: 9012
	public float Rotation;

	// Token: 0x04002335 RID: 9013
	public float Force;

	// Token: 0x04002336 RID: 9014
	public float Speed;

	// Token: 0x04002337 RID: 9015
	public bool Flip;
}
