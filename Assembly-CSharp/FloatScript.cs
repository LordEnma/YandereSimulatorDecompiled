using System;
using UnityEngine;

// Token: 0x020002CE RID: 718
public class FloatScript : MonoBehaviour
{
	// Token: 0x060014B0 RID: 5296 RVA: 0x000CBBB0 File Offset: 0x000C9DB0
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

	// Token: 0x04002064 RID: 8292
	public bool Down;

	// Token: 0x04002065 RID: 8293
	public float Float;

	// Token: 0x04002066 RID: 8294
	public float Speed;

	// Token: 0x04002067 RID: 8295
	public float Limit;

	// Token: 0x04002068 RID: 8296
	public float DownLimit;

	// Token: 0x04002069 RID: 8297
	public float UpLimit;
}
