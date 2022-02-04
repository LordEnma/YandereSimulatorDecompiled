using System;
using UnityEngine;

// Token: 0x020004FA RID: 1274
public class BarScript : MonoBehaviour
{
	// Token: 0x0600210D RID: 8461 RVA: 0x001E573D File Offset: 0x001E393D
	private void Start()
	{
		base.transform.localScale = new Vector3(0f, 1f, 1f);
	}

	// Token: 0x0600210E RID: 8462 RVA: 0x001E5760 File Offset: 0x001E3960
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

	// Token: 0x040048AD RID: 18605
	public float Speed;

	// Token: 0x040048AE RID: 18606
	public float Goal;
}
