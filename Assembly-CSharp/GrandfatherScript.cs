using System;
using UnityEngine;

// Token: 0x02000302 RID: 770
public class GrandfatherScript : MonoBehaviour
{
	// Token: 0x06001809 RID: 6153 RVA: 0x000E344C File Offset: 0x000E164C
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

	// Token: 0x040022C2 RID: 8898
	public ClockScript Clock;

	// Token: 0x040022C3 RID: 8899
	public Transform MinuteHand;

	// Token: 0x040022C4 RID: 8900
	public Transform HourHand;

	// Token: 0x040022C5 RID: 8901
	public Transform Pendulum;

	// Token: 0x040022C6 RID: 8902
	public float Rotation;

	// Token: 0x040022C7 RID: 8903
	public float Force;

	// Token: 0x040022C8 RID: 8904
	public float Speed;

	// Token: 0x040022C9 RID: 8905
	public bool Flip;
}
