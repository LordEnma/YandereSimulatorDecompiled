using System;
using UnityEngine;

// Token: 0x02000304 RID: 772
public class GrandfatherScript : MonoBehaviour
{
	// Token: 0x06001819 RID: 6169 RVA: 0x000E48B0 File Offset: 0x000E2AB0
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

	// Token: 0x040022F6 RID: 8950
	public ClockScript Clock;

	// Token: 0x040022F7 RID: 8951
	public Transform MinuteHand;

	// Token: 0x040022F8 RID: 8952
	public Transform HourHand;

	// Token: 0x040022F9 RID: 8953
	public Transform Pendulum;

	// Token: 0x040022FA RID: 8954
	public float Rotation;

	// Token: 0x040022FB RID: 8955
	public float Force;

	// Token: 0x040022FC RID: 8956
	public float Speed;

	// Token: 0x040022FD RID: 8957
	public bool Flip;
}
