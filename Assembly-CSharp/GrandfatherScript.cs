using System;
using UnityEngine;

// Token: 0x02000305 RID: 773
public class GrandfatherScript : MonoBehaviour
{
	// Token: 0x06001820 RID: 6176 RVA: 0x000E4A24 File Offset: 0x000E2C24
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

	// Token: 0x040022FC RID: 8956
	public ClockScript Clock;

	// Token: 0x040022FD RID: 8957
	public Transform MinuteHand;

	// Token: 0x040022FE RID: 8958
	public Transform HourHand;

	// Token: 0x040022FF RID: 8959
	public Transform Pendulum;

	// Token: 0x04002300 RID: 8960
	public float Rotation;

	// Token: 0x04002301 RID: 8961
	public float Force;

	// Token: 0x04002302 RID: 8962
	public float Speed;

	// Token: 0x04002303 RID: 8963
	public bool Flip;
}
