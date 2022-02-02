using System;
using UnityEngine;

// Token: 0x020004FA RID: 1274
public class BarScript : MonoBehaviour
{
	// Token: 0x0600210B RID: 8459 RVA: 0x001E5425 File Offset: 0x001E3625
	private void Start()
	{
		base.transform.localScale = new Vector3(0f, 1f, 1f);
	}

	// Token: 0x0600210C RID: 8460 RVA: 0x001E5448 File Offset: 0x001E3648
	private void Update()
	{
		if (this.Goal == 0f)
		{
			base.transform.localScale = new Vector3(base.transform.localScale.x + this.Speed * Time.deltaTime, 1f, 1f);
			if ((double)base.transform.localScale.x > 0.1)
			{
				base.transform.localScale = new Vector3(0f, 1f, 1f);
				return;
			}
		}
		else
		{
			this.Speed += Time.deltaTime;
			base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(this.Goal, 1f, 1f), Time.deltaTime * this.Speed);
		}
	}

	// Token: 0x040048A7 RID: 18599
	public float Speed;

	// Token: 0x040048A8 RID: 18600
	public float Goal;
}
