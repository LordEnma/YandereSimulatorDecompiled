using System;
using UnityEngine;

// Token: 0x020002CD RID: 717
public class FloatScript : MonoBehaviour
{
	// Token: 0x060014AD RID: 5293 RVA: 0x000CB9A4 File Offset: 0x000C9BA4
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

	// Token: 0x0400205F RID: 8287
	public bool Down;

	// Token: 0x04002060 RID: 8288
	public float Float;

	// Token: 0x04002061 RID: 8289
	public float Speed;

	// Token: 0x04002062 RID: 8290
	public float Limit;

	// Token: 0x04002063 RID: 8291
	public float DownLimit;

	// Token: 0x04002064 RID: 8292
	public float UpLimit;
}
