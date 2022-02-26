using System;
using UnityEngine;

// Token: 0x020002CD RID: 717
public class FloatScript : MonoBehaviour
{
	// Token: 0x060014AA RID: 5290 RVA: 0x000CB3E8 File Offset: 0x000C95E8
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

	// Token: 0x04002046 RID: 8262
	public bool Down;

	// Token: 0x04002047 RID: 8263
	public float Float;

	// Token: 0x04002048 RID: 8264
	public float Speed;

	// Token: 0x04002049 RID: 8265
	public float Limit;

	// Token: 0x0400204A RID: 8266
	public float DownLimit;

	// Token: 0x0400204B RID: 8267
	public float UpLimit;
}
