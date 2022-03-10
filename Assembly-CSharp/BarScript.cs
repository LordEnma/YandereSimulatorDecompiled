using System;
using UnityEngine;

// Token: 0x020004FD RID: 1277
public class BarScript : MonoBehaviour
{
	// Token: 0x06002126 RID: 8486 RVA: 0x001E73AD File Offset: 0x001E55AD
	private void Start()
	{
		base.transform.localScale = new Vector3(0f, 1f, 1f);
	}

	// Token: 0x06002127 RID: 8487 RVA: 0x001E73D0 File Offset: 0x001E55D0
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

	// Token: 0x040048E6 RID: 18662
	public float Speed;

	// Token: 0x040048E7 RID: 18663
	public float Goal;
}
