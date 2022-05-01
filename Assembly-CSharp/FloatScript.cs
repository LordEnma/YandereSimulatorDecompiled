using System;
using UnityEngine;

// Token: 0x020002CF RID: 719
public class FloatScript : MonoBehaviour
{
	// Token: 0x060014BC RID: 5308 RVA: 0x000CC348 File Offset: 0x000CA548
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

	// Token: 0x04002071 RID: 8305
	public bool Down;

	// Token: 0x04002072 RID: 8306
	public float Float;

	// Token: 0x04002073 RID: 8307
	public float Speed;

	// Token: 0x04002074 RID: 8308
	public float Limit;

	// Token: 0x04002075 RID: 8309
	public float DownLimit;

	// Token: 0x04002076 RID: 8310
	public float UpLimit;
}
