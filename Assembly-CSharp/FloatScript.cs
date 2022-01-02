using System;
using UnityEngine;

// Token: 0x020002CA RID: 714
public class FloatScript : MonoBehaviour
{
	// Token: 0x06001497 RID: 5271 RVA: 0x000CA0E4 File Offset: 0x000C82E4
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

	// Token: 0x04002023 RID: 8227
	public bool Down;

	// Token: 0x04002024 RID: 8228
	public float Float;

	// Token: 0x04002025 RID: 8229
	public float Speed;

	// Token: 0x04002026 RID: 8230
	public float Limit;

	// Token: 0x04002027 RID: 8231
	public float DownLimit;

	// Token: 0x04002028 RID: 8232
	public float UpLimit;
}
