using System;
using UnityEngine;

// Token: 0x020004FA RID: 1274
public class BarScript : MonoBehaviour
{
	// Token: 0x06002107 RID: 8455 RVA: 0x001E4B85 File Offset: 0x001E2D85
	private void Start()
	{
		base.transform.localScale = new Vector3(0f, 1f, 1f);
	}

	// Token: 0x06002108 RID: 8456 RVA: 0x001E4BA8 File Offset: 0x001E2DA8
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

	// Token: 0x0400489C RID: 18588
	public float Speed;

	// Token: 0x0400489D RID: 18589
	public float Goal;
}
