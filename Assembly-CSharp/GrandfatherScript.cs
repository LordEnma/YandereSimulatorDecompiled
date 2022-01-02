using System;
using UnityEngine;

// Token: 0x02000303 RID: 771
public class GrandfatherScript : MonoBehaviour
{
	// Token: 0x06001812 RID: 6162 RVA: 0x000E3EDC File Offset: 0x000E20DC
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

	// Token: 0x040022E6 RID: 8934
	public ClockScript Clock;

	// Token: 0x040022E7 RID: 8935
	public Transform MinuteHand;

	// Token: 0x040022E8 RID: 8936
	public Transform HourHand;

	// Token: 0x040022E9 RID: 8937
	public Transform Pendulum;

	// Token: 0x040022EA RID: 8938
	public float Rotation;

	// Token: 0x040022EB RID: 8939
	public float Force;

	// Token: 0x040022EC RID: 8940
	public float Speed;

	// Token: 0x040022ED RID: 8941
	public bool Flip;
}
