using System;
using UnityEngine;

// Token: 0x020004FC RID: 1276
public class BarScript : MonoBehaviour
{
	// Token: 0x06002120 RID: 8480 RVA: 0x001E69D5 File Offset: 0x001E4BD5
	private void Start()
	{
		base.transform.localScale = new Vector3(0f, 1f, 1f);
	}

	// Token: 0x06002121 RID: 8481 RVA: 0x001E69F8 File Offset: 0x001E4BF8
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

	// Token: 0x040048C9 RID: 18633
	public float Speed;

	// Token: 0x040048CA RID: 18634
	public float Goal;
}
