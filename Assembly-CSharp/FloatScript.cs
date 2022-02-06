using System;
using UnityEngine;

// Token: 0x020002CB RID: 715
public class FloatScript : MonoBehaviour
{
	// Token: 0x0600149C RID: 5276 RVA: 0x000CAA10 File Offset: 0x000C8C10
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

	// Token: 0x04002032 RID: 8242
	public bool Down;

	// Token: 0x04002033 RID: 8243
	public float Float;

	// Token: 0x04002034 RID: 8244
	public float Speed;

	// Token: 0x04002035 RID: 8245
	public float Limit;

	// Token: 0x04002036 RID: 8246
	public float DownLimit;

	// Token: 0x04002037 RID: 8247
	public float UpLimit;
}
