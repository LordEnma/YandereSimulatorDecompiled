using System;
using UnityEngine;

// Token: 0x020004F9 RID: 1273
public class BarScript : MonoBehaviour
{
	// Token: 0x06002105 RID: 8453 RVA: 0x001E3EB5 File Offset: 0x001E20B5
	private void Start()
	{
		base.transform.localScale = new Vector3(0f, 1f, 1f);
	}

	// Token: 0x06002106 RID: 8454 RVA: 0x001E3ED8 File Offset: 0x001E20D8
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

	// Token: 0x04004895 RID: 18581
	public float Speed;

	// Token: 0x04004896 RID: 18582
	public float Goal;
}
