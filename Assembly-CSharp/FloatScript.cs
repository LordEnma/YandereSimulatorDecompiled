using System;
using UnityEngine;

// Token: 0x020002C9 RID: 713
public class FloatScript : MonoBehaviour
{
	// Token: 0x06001490 RID: 5264 RVA: 0x000C9700 File Offset: 0x000C7900
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

	// Token: 0x04002000 RID: 8192
	public bool Down;

	// Token: 0x04002001 RID: 8193
	public float Float;

	// Token: 0x04002002 RID: 8194
	public float Speed;

	// Token: 0x04002003 RID: 8195
	public float Limit;

	// Token: 0x04002004 RID: 8196
	public float DownLimit;

	// Token: 0x04002005 RID: 8197
	public float UpLimit;
}
