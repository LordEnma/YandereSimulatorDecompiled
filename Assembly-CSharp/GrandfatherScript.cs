using System;
using UnityEngine;

// Token: 0x02000309 RID: 777
public class GrandfatherScript : MonoBehaviour
{
	// Token: 0x06001847 RID: 6215 RVA: 0x000E6CA0 File Offset: 0x000E4EA0
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

	// Token: 0x04002358 RID: 9048
	public ClockScript Clock;

	// Token: 0x04002359 RID: 9049
	public Transform MinuteHand;

	// Token: 0x0400235A RID: 9050
	public Transform HourHand;

	// Token: 0x0400235B RID: 9051
	public Transform Pendulum;

	// Token: 0x0400235C RID: 9052
	public float Rotation;

	// Token: 0x0400235D RID: 9053
	public float Force;

	// Token: 0x0400235E RID: 9054
	public float Speed;

	// Token: 0x0400235F RID: 9055
	public bool Flip;
}
