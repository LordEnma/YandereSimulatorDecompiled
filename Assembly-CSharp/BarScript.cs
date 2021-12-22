using System;
using UnityEngine;

// Token: 0x020004F7 RID: 1271
public class BarScript : MonoBehaviour
{
	// Token: 0x060020F7 RID: 8439 RVA: 0x001E2F25 File Offset: 0x001E1125
	private void Start()
	{
		base.transform.localScale = new Vector3(0f, 1f, 1f);
	}

	// Token: 0x060020F8 RID: 8440 RVA: 0x001E2F48 File Offset: 0x001E1148
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

	// Token: 0x04004878 RID: 18552
	public float Speed;

	// Token: 0x04004879 RID: 18553
	public float Goal;
}
