using System;
using UnityEngine;

// Token: 0x020002D0 RID: 720
public class FloatScript : MonoBehaviour
{
	// Token: 0x060014BE RID: 5310 RVA: 0x000CC6A8 File Offset: 0x000CA8A8
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

	// Token: 0x04002078 RID: 8312
	public bool Down;

	// Token: 0x04002079 RID: 8313
	public float Float;

	// Token: 0x0400207A RID: 8314
	public float Speed;

	// Token: 0x0400207B RID: 8315
	public float Limit;

	// Token: 0x0400207C RID: 8316
	public float DownLimit;

	// Token: 0x0400207D RID: 8317
	public float UpLimit;
}
