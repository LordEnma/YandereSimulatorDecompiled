using System;
using UnityEngine;

// Token: 0x020002CC RID: 716
public class FloatScript : MonoBehaviour
{
	// Token: 0x060014A1 RID: 5281 RVA: 0x000CAB04 File Offset: 0x000C8D04
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

	// Token: 0x04002037 RID: 8247
	public bool Down;

	// Token: 0x04002038 RID: 8248
	public float Float;

	// Token: 0x04002039 RID: 8249
	public float Speed;

	// Token: 0x0400203A RID: 8250
	public float Limit;

	// Token: 0x0400203B RID: 8251
	public float DownLimit;

	// Token: 0x0400203C RID: 8252
	public float UpLimit;
}
