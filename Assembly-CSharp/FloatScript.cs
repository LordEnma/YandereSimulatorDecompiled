using System;
using UnityEngine;

// Token: 0x020002CB RID: 715
public class FloatScript : MonoBehaviour
{
	// Token: 0x0600149B RID: 5275 RVA: 0x000CA3C4 File Offset: 0x000C85C4
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

	// Token: 0x04002027 RID: 8231
	public bool Down;

	// Token: 0x04002028 RID: 8232
	public float Float;

	// Token: 0x04002029 RID: 8233
	public float Speed;

	// Token: 0x0400202A RID: 8234
	public float Limit;

	// Token: 0x0400202B RID: 8235
	public float DownLimit;

	// Token: 0x0400202C RID: 8236
	public float UpLimit;
}
