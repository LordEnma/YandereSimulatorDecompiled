using System;
using UnityEngine;

// Token: 0x02000304 RID: 772
public class GrandfatherScript : MonoBehaviour
{
	// Token: 0x06001816 RID: 6166 RVA: 0x000E4204 File Offset: 0x000E2404
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

	// Token: 0x040022EA RID: 8938
	public ClockScript Clock;

	// Token: 0x040022EB RID: 8939
	public Transform MinuteHand;

	// Token: 0x040022EC RID: 8940
	public Transform HourHand;

	// Token: 0x040022ED RID: 8941
	public Transform Pendulum;

	// Token: 0x040022EE RID: 8942
	public float Rotation;

	// Token: 0x040022EF RID: 8943
	public float Force;

	// Token: 0x040022F0 RID: 8944
	public float Speed;

	// Token: 0x040022F1 RID: 8945
	public bool Flip;
}
