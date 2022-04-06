using System;
using UnityEngine;

// Token: 0x020002CF RID: 719
public class FloatScript : MonoBehaviour
{
	// Token: 0x060014B6 RID: 5302 RVA: 0x000CBCB8 File Offset: 0x000C9EB8
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

	// Token: 0x04002066 RID: 8294
	public bool Down;

	// Token: 0x04002067 RID: 8295
	public float Float;

	// Token: 0x04002068 RID: 8296
	public float Speed;

	// Token: 0x04002069 RID: 8297
	public float Limit;

	// Token: 0x0400206A RID: 8298
	public float DownLimit;

	// Token: 0x0400206B RID: 8299
	public float UpLimit;
}
