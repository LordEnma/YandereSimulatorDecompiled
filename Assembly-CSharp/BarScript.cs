using System;
using UnityEngine;

// Token: 0x02000501 RID: 1281
public class BarScript : MonoBehaviour
{
	// Token: 0x0600213E RID: 8510 RVA: 0x001E9315 File Offset: 0x001E7515
	private void Start()
	{
		base.transform.localScale = new Vector3(0f, 1f, 1f);
	}

	// Token: 0x0600213F RID: 8511 RVA: 0x001E9338 File Offset: 0x001E7538
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

	// Token: 0x04004945 RID: 18757
	public float Speed;

	// Token: 0x04004946 RID: 18758
	public float Goal;
}
