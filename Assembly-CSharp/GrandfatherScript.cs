using System;
using UnityEngine;

// Token: 0x02000308 RID: 776
public class GrandfatherScript : MonoBehaviour
{
	// Token: 0x0600183A RID: 6202 RVA: 0x000E60F4 File Offset: 0x000E42F4
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

	// Token: 0x04002340 RID: 9024
	public ClockScript Clock;

	// Token: 0x04002341 RID: 9025
	public Transform MinuteHand;

	// Token: 0x04002342 RID: 9026
	public Transform HourHand;

	// Token: 0x04002343 RID: 9027
	public Transform Pendulum;

	// Token: 0x04002344 RID: 9028
	public float Rotation;

	// Token: 0x04002345 RID: 9029
	public float Force;

	// Token: 0x04002346 RID: 9030
	public float Speed;

	// Token: 0x04002347 RID: 9031
	public bool Flip;
}
