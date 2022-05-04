using System;
using UnityEngine;

// Token: 0x02000308 RID: 776
public class GrandfatherScript : MonoBehaviour
{
	// Token: 0x06001842 RID: 6210 RVA: 0x000E6824 File Offset: 0x000E4A24
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

	// Token: 0x0400234C RID: 9036
	public ClockScript Clock;

	// Token: 0x0400234D RID: 9037
	public Transform MinuteHand;

	// Token: 0x0400234E RID: 9038
	public Transform HourHand;

	// Token: 0x0400234F RID: 9039
	public Transform Pendulum;

	// Token: 0x04002350 RID: 9040
	public float Rotation;

	// Token: 0x04002351 RID: 9041
	public float Force;

	// Token: 0x04002352 RID: 9042
	public float Speed;

	// Token: 0x04002353 RID: 9043
	public bool Flip;
}
