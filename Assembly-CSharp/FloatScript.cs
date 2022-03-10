using System;
using UnityEngine;

// Token: 0x020002CD RID: 717
public class FloatScript : MonoBehaviour
{
	// Token: 0x060014AA RID: 5290 RVA: 0x000CB534 File Offset: 0x000C9734
	private void Update()
	{
		if (!this.Down)
		{
			this.Float += Time.deltaTime * this.Speed;
			if (this.Float > this.Limit)
			{
				this.Down = true;
			}
		}
		else
		{
			this.Float -= Time.deltaTime * this.Speed;
			if (this.Float < -1f * this.Limit)
			{
				this.Down = false;
			}
		}
		base.transform.localPosition += new Vector3(0f, this.Float * Time.deltaTime, 0f);
		if (base.transform.localPosition.y > this.UpLimit)
		{
			base.transform.localPosition = new Vector3(base.transform.localPosition.x, this.UpLimit, base.transform.localPosition.z);
		}
		if (base.transform.localPosition.y < this.DownLimit)
		{
			base.transform.localPosition = new Vector3(base.transform.localPosition.x, this.DownLimit, base.transform.localPosition.z);
		}
	}

	// Token: 0x0400204F RID: 8271
	public bool Down;

	// Token: 0x04002050 RID: 8272
	public float Float;

	// Token: 0x04002051 RID: 8273
	public float Speed;

	// Token: 0x04002052 RID: 8274
	public float Limit;

	// Token: 0x04002053 RID: 8275
	public float DownLimit;

	// Token: 0x04002054 RID: 8276
	public float UpLimit;
}
